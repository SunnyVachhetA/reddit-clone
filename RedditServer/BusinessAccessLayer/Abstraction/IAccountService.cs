using Entities.DTOs.Request;
using Entities.DTOs.Response;

namespace BusinessAccessLayer.Abstraction;

public interface IAccountService
{
    Task<bool> IsDuplicateEmail(string email);

    Task<bool> IsDuplicateUsername(string username);

    Task<UserAuthTokenDto> Login(LoginRequestDto dto, CancellationToken cancellationToken = default);

    Task<UserAuthTokenDto> RefreshToken(string refreshToken, CancellationToken cancellationToken = default);

    Task Register(RegisterRequestDto dto, CancellationToken cancellationToken = default);
}