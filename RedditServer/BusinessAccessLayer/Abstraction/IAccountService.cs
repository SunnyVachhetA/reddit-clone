using Entities.DTOs.Request;

namespace BusinessAccessLayer.Abstraction;
public interface IAccountService
{
    Task<bool> IsDuplicateEmail(string email);
    Task Login(LoginRequestDto dto);
    Task Register(RegisterRequestDto dto, CancellationToken cancellationToken = default);
}
