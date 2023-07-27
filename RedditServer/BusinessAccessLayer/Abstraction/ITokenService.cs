using Entities.DTOs.Response;
using System.Security.Claims;

namespace BusinessAccessLayer.Abstraction;
public interface ITokenService
{
    public (string token, int jwtExpiryTimeInMinute) GenerateAccessToken(IEnumerable<Claim> claims);

    public RefreshTokenDto GenerateRefreshToken();
}
