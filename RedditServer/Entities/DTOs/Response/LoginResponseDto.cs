namespace Entities.DTOs.Response;
public record LoginResponseDto(string AccessToken,
    string RefreshToken);