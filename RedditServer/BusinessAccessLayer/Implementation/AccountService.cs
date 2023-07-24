using BusinessAccessLayer.Abstraction;
using Common.Constants;
using Common.Enums;
using Common.Exceptions;
using Common.Utils;
using DataAccessLayer.Abstraction;
using Entities.DataModels;
using Entities.DTOs.Request;
using Entities.Mapper;
using System.Linq.Expressions;

namespace BusinessAccessLayer.Implementation;

public class AccountService : IAccountService
{
    #region Properties

    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    #endregion Properties

    #region Constructor

    public AccountService(IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
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

    public async Task Login(LoginRequestDto dto)
    {
        User? model = await _userRepository.FirstOrDefaultAsync(CredentialFilter(dto));
        if (model is null || !PasswordHasherUtil.VerifyPassword(dto.Password, model.Password))
            throw new UnauthorizedException(MessageConstants.InvalidLoginCredential);
    }

    public async Task<bool> IsDuplicateEmail(string email)
        => await _userRepository.AnyAsync(UserEmailFilter(email));

    #endregion Interface Methods

    #region Helper methods

    private static User ConvertToUser(RegisterRequestDto dto)
        => dto.ToUser();

    private static string HashPassword(string password)
        => PasswordHasherUtil.HashPassword(password);

    #endregion Helper methods

    #region Filters

    private static Expression<Func<User, bool>> UserEmailFilter(string email)
        => user => user.Email.Equals(email);

    private static Expression<Func<User, bool>> CredentialFilter(LoginRequestDto dto)
        => user => (user.Email.Equals(dto.Username) || user.Username.Equals(dto.Username))
                    && user.Status == UserStatusType.Active;
    #endregion
}