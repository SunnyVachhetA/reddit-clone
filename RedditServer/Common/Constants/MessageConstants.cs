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

    #endregion Success Message

    #region Exception Messages

    public static readonly string DB_OPERATION_FAILED = "Something went wrong during db operation.";

    public static readonly string VALIDATION_ERROR = "One or more validation failures have occured.";

    public const string RESOURCE_NOT_FOUND = "Resource not found.";

    #endregion Exception Messages

    #region Validation Messages

    public static readonly string UsernameRegExFailed = "Username can contain alphabets, -, _";

    public static readonly string PasswordRegExFailed
        = "Password should have at least 8 character, 1 uppercase, 1 lowercase and 1 symbol.";

    public static readonly string EmailRegExFailed = "Invalid email address.";

    public static readonly string EmailAlreadyExists = "User already exists. Please try with other email.";

    public static readonly string InvalidLoginCredential = "Invalid email/username or password.";

    public static readonly string UsernameAlreadyExists = "Username is not available.";

    #endregion Validation Messages
}