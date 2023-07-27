namespace BusinessAccessLayer.Settings;

public class JwtSetting
{
    public string Audiences { get; set; } = string.Empty;
    public string Issuers { get; set; } = string.Empty;
    public int JwtExpireTimeInMinutes { get; set; }
    public int RefreshTokenExpirationInDays { get; set; }
    public string Key { get; set; } = string.Empty;
}
