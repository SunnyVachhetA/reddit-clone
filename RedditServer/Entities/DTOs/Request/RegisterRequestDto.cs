using Entities.Abstract;

namespace Entities.DTOs.Request;

public class RegisterRequestDto : BaseValidationModel<RegisterRequestDto>
{
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}