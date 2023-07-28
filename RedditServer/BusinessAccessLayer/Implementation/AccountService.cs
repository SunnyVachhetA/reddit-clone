using BusinessAccessLayer.Abstraction;
using Common.Constants;
using Common.Enums;
using Common.Exceptions;
using Common.Utils;
using DataAccessLayer.Abstraction;
using Entities.DataModels;
using Entities.DTOs.Request;
using Entities.DTOs.Response;
using Entities.Mapper;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;

namespace BusinessAccessLayer.Implementation;

public class AccountService : IAccountService
{
    #region Properties

    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenService _tokenService;

    #endregion Properties

    #region Constructor

    public AccountService(IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        ITokenService tokenService)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    #endregion Constructor

    #region Interface Methods

    public async Task Register(RegisterRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        dto.Password = HashPassword(dto.Password);

        User model = ConvertToUser(dto);

        await _userRepository.AddAsync(model, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);
    }

    public async Task<UserAuthTokenDto> Login(LoginRequestDto dto, CancellationToken cancellationToken = default)
    {
        User? model = await _userRepository.FirstOrDefaultAsync(CredentialFilter(dto), cancellationToken);

        if (model is null || !PasswordHasherUtil.VerifyPassword(dto.Password, model.Password))
            throw new UnauthorizedException(MessageConstants.InvalidLoginCredential);

        UserAuthTokenDto authDto = await GetAuthTokenDto(model, cancellationToken);

        return authDto;
    }

    public async Task<UserAuthTokenDto> RefreshToken(string refreshToken,
        CancellationToken cancellationToken = default)
    {
        User model = await _userRepository.FirstOrDefaultAsync(IsRefreshTokenValid(refreshToken), cancellationToken)
                    ?? throw new UnauthorizedException(MessageConstants.InvalidRefreshToken);

        UserAuthTokenDto authDto = await GetAuthTokenDto(model, cancellationToken);

        return authDto;
    }

    public async Task<bool> IsDuplicateEmail(string email)
        => await _userRepository.AnyAsync(UserEmailFilter(email));

    public async Task<bool> IsDuplicateUsername(string username)
        => await _userRepository.AnyAsync(UsernameFilter(username));

    #endregion Interface Methods

    #region Helper methods

    private static User ConvertToUser(RegisterRequestDto dto)
        => dto.ToUser();

    private static string HashPassword(string password)
        => PasswordHasherUtil.HashPassword(password);

    private static IEnumerable<Claim> GenerateUserClaims(User model)
        => new List<Claim>()
        {
            new(JwtRegisteredClaimNames.Sub, model.Username),
            new(JwtRegisteredClaimNames.NameId, model.Id.ToString()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

    private UserAuthTokenDto GenerateTokenModel(User model)
    {
        IEnumerable<Claim> claims = GenerateUserClaims(model);

        (string token, int jwtExpiryTimeInMinute) = _tokenService.GenerateAccessToken(claims);

        RefreshTokenDto? refreshToken = GenerateRefreshToken(model);

        return new UserAuthTokenDto(model.Email, model.Username, token, refreshToken, jwtExpiryTimeInMinute);
    }

    private RefreshTokenDto? GenerateRefreshToken(User model)
    {
        if ((model.RefreshToken is not null && model.RefreshTokenExpirationTime is not null)
            && (model.RefreshTokenExpirationTime > DateUtil.UtcNow))
        {
            return new RefreshTokenDto(model.RefreshToken,
                DateUtil.Difference(model.RefreshTokenExpirationTime.Value), model.RefreshTokenExpirationTime.Value);
        }

        RefreshTokenDto? refreshToken = _tokenService.GenerateRefreshToken();
        model.RefreshToken = refreshToken.Token;
        model.RefreshTokenExpirationTime = refreshToken.ExpirationDate;

        return refreshToken;
    }

    private async Task<UserAuthTokenDto> GetAuthTokenDto(User model,
        CancellationToken cancellationToken = default)
    {
        UserAuthTokenDto authDto = GenerateTokenModel(model);

        await _userRepository.UpdateAsync(model, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);
        return authDto;
    }

    #endregion Helper methods

    #region Filters

    private static Expression<Func<User, bool>> UserEmailFilter(string email)
        => user => user.Email.Equals(email);

    private static Expression<Func<User, bool>> UsernameFilter(string username)
        => user => user.Username.Equals(username);

    private static Expression<Func<User, bool>> CredentialFilter(LoginRequestDto dto)
        => user => (user.Email.Equals(dto.Username) || user.Username.Equals(dto.Username))
                    && user.Status == UserStatusType.Active;

    private static Expression<Func<User, bool>> IsRefreshTokenValid(string token)
        => user => user.RefreshToken == token && DateUtil.UtcNow < user.RefreshTokenExpirationTime;

    #endregion Filters
}