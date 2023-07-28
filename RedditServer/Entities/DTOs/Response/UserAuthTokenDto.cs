namespace Entities.DTOs.Response;

using System.Text.Json.Serialization;

public class UserAuthTokenDto
{
    public string Email { get; }
    public string Username { get; }
    public string AccessToken { get; }

    public int AccessTokenExpirationInMinute { get; }

    [JsonIgnore]
    public RefreshTokenDto? RefreshToken { get; }

    public UserAuthTokenDto(string email,
        string username,
        string accessToken,
        RefreshTokenDto? refreshToken,
        int accessTokenExpirationInMinute)
    {
        Email = email;
        Username = username;
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        AccessTokenExpirationInMinute = accessTokenExpirationInMinute;
    }
}