using Common.Constants;
using Common.Utils;
using Entities.DTOs.Response;
using Microsoft.Net.Http.Headers;

namespace RedditAPI.Helpers;

public static class CookieHelper
{
    public static void SetCookie(HttpResponse response,
        string key,
        string value,
        int days)
    {
        // Create a Set-Cookie header value with your cookie name and value
        var cookieHeaderValue = new SetCookieHeaderValue(key, value)
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(days),
            Path = "/", // Set the cookie path
            Domain = "localhost", // Set the cookie domain
            Secure = true,
            SameSite = Microsoft.Net.Http.Headers.SameSiteMode.None// Set whether the cookie requires a secure connection (https)
        };
        response.Headers[HeaderNames.SetCookie] = cookieHeaderValue.ToString();
    }

    public static CookieOptions GetCookieOptions(int days)
        => new()
        {
            HttpOnly = true,
            Expires = DateUtil.AddDays(days)
        };

    public static void SetRefreshTokenInCookie(HttpResponse response, RefreshTokenDto dto)
    {
        SetCookie(response, SystemConstants.RefreshTokenKey, dto.Token, dto.ActiveDays);
    }
}