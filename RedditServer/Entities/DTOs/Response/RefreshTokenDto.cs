namespace Entities.DTOs.Response;
public record RefreshTokenDto(string Token, int ActiveDays, DateTimeOffset ExpirationDate);
