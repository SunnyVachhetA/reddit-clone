namespace Common.Constants;
public class SystemConstants
{
    private SystemConstants() { }

    public static readonly int PasswordIteration = 5;

    public static readonly string CorsPolicy = "RedditCors";

    public static readonly string RefreshTokenKey = "RefreshToken";

    public static readonly int RefreshTokenExpiryInDays = 15;

    public static readonly int MaxIconSizeInMB = 5;

    public static readonly int MaxBannerSizeInMB = 100;

    public static readonly string DefaultUserAvatar =
        @"https://firebasestorage.googleapis.com/v0/b/reddit-clone-6a660.appspot.com/o/files%2Fprofile-icon.png?alt=media";

    public static readonly string DefaultIconUrl
        = @"https://firebasestorage.googleapis.com/v0/b/reddit-clone-6a660.appspot.com/o/files%2Fsubreddit.png?alt=media";

    public static readonly string DefaultBannerUrl
        = @"https://firebasestorage.googleapis.com/v0/b/reddit-clone-6a660.appspot.com/o/files%2Fbakcground.jpg?alt=media";

    public static readonly string FirebaseSubRedditRoot = "subreddit";

    public static readonly string FirebaseSubRedditIconFolder = $"{FirebaseSubRedditRoot}/icon";

    public static readonly string FirebaseSubRedditBannerFolder = $"{FirebaseSubRedditRoot}/banner";
}
