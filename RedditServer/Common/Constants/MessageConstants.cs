namespace Common.Constants;

public class MessageConstants
{
    private MessageConstants()
    { }

    #region Success Message

    public const string GlobalSuccess = "Success";

    public const string GlobalCreated = "Resource created successfully.";

    public static readonly string AccountCreated = "Account created successfully.";

    public static readonly string LoginSuccess = "Successfully logged in.";

    public static readonly string AccessTokenRefreshSuccess = "Access token refreshed successfully.";

    public static readonly string SubRedditCreated = "Subreddit created successfully.";

    #endregion Success Message

    #region Exception Messages

    public static readonly string DB_OPERATION_FAILED = "Something went wrong during db operation.";

    public static readonly string VALIDATION_ERROR = "One or more validation failures have occured.";

    public const string RESOURCE_NOT_FOUND = "Resource not found.";

    public const string SUBREDDIT_NOT_FOUND = "SubReddit '#' not found.";

    #endregion Exception Messages

    #region Validation Messages

    public static readonly string UsernameRegExFailed = "Username can contain alphabets, -, _";

    public static readonly string PasswordRegExFailed
        = "Password should have at least 8 character, 1 uppercase, 1 lowercase and 1 symbol.";

    public static readonly string EmailRegExFailed = "Invalid email address.";

    public static readonly string EmailAlreadyExists = "User already exists. Please try with other email.";

    public static readonly string InvalidLoginCredential = "Invalid email/username or password.";

    public static readonly string UsernameAlreadyExists = "Username is not available.";

    public static readonly string InvalidRefreshToken = "Refresh token is either expired or not passed.";

    #region SubReddit Validation Message

    public static readonly string InvalidIconImageFile = "For Icon, only jpeg, png and jpg images are allowed.";

    public static readonly string InvalidBannerImageFile = "For Banner, only jpeg, png and jpg images are allowed.";

    public static readonly string InvalidSubRedditSlug = "Slug should be made of a-z and -.";

    public static readonly string InvalidSubRedditType = "Subreddit can be private/public only.";

    public static readonly string InvalidRedditTopicId = "Reddit topic is either deleted or not active.";

    public static readonly string MaxSubRedditIconSizeLength
        = $"Subreddit icon size should be less than or equal to {SystemConstants.MaxIconSizeInMB}";

    public static readonly string MaxSubRedditBannerSizeLength
    = $"Subreddit banner size should be less than or equal to {SystemConstants.MaxBannerSizeInMB}";

    #endregion SubReddit Validation Message

    #endregion Validation Messages
}