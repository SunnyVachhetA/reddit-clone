using BusinessAccessLayer.Abstraction;
using BusinessAccessLayer.Settings;
using Common.Utils;
using Entities.DTOs.Response;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BusinessAccessLayer.Implementation;
public sealed class TokenService : ITokenService
{
    private readonly JwtSetting _jwtSetting;

    public TokenService(JwtSetting jwtSetting)
    {
        _jwtSetting = jwtSetting;
    }

    public RefreshTokenDto GenerateRefreshToken()
    {
        byte[] randomNumber = new byte[32];
        using RandomNumberGenerator rng = RandomNumberGenerator.Create();

        rng.GetBytes(randomNumber);
        return new RefreshTokenDto(Convert.ToBase64String(randomNumber),
            _jwtSetting.RefreshTokenExpirationInDays,
            DateUtil.AddDays(_jwtSetting.RefreshTokenExpirationInDays));
    }

    public (string token, int jwtExpiryTimeInMinute) GenerateAccessToken(IEnumerable<Claim> claims)
    {
        SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(_jwtSetting.Key));

        SigningCredentials signingCredentials = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken jwtSecurityToken = new(
                issuer: _jwtSetting.Issuers,
                audience: _jwtSetting.Audiences,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSetting.JwtExpireTimeInMinutes),
                signingCredentials: signingCredentials
            );

        return (new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken), _jwtSetting.JwtExpireTimeInMinutes);
    }
}
