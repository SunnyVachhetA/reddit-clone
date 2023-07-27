namespace Common.Utils;
public static class DateUtil
{
    public static DateTimeOffset UtcNow => DateTimeOffset.UtcNow;

    public static DateTimeOffset AddDays(int days)
        => UtcNow.AddDays(days);
}
