namespace Common.Constants;

public class ValidationConstants
{
    private ValidationConstants()
    { }

    #region Patterns

    public static readonly string UsernameRegEx = "^[a-zA-Z0-9_-]{3,20}$";

    public static readonly string PasswordRegEx = "^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*_=+-]).{8,20}$";

    public static readonly string EmailRegEx = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,3}$";

    #region SubReddit Patterns

    public static readonly string SubRedditSlugRegEx = "[a-z-]";

    #endregion

    #endregion Patterns

    #region Constants

    public static readonly int MinUsernameLength = 3;

    public static readonly int MaxUsernameLength = 20;

    public static readonly int MinEmailLength = 5;

    public static readonly int MaxEmailLength = 255;

    public static readonly int MinPasswordLength = 5;

    public static readonly int MaxPasswordLength = 20;

    #region SubReddit

    public static readonly int MinSubRedditTitleLength = 3;

    public static readonly int MaxSubRedditTitleLength = 50; //TODO : Change

    public static readonly int MinSubRedditSlugLength = 3;

    public static readonly int MaxSubRedditSlugLength = 25;

    public static readonly int MinSubRedditDescriptionLength = 3;

    public static readonly int MaxSubRedditDescriptionLength = 400; //TODO: Change
    #endregion SubReddit

    #endregion Constants
}