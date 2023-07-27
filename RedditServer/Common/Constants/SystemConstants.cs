namespace Common.Constants;
public class SystemConstants
{
    private SystemConstants() { }

    public static readonly int PasswordIteration = 5;

    public static readonly string CorsPolicy = "RedditCors";

    public static readonly string RefreshTokenKey = "RefreshToken";

    public static readonly int RefreshTokenExpiryInDays = 15;
}
