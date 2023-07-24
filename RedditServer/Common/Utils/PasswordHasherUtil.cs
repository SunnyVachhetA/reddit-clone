using Common.Constants;

namespace Common.Utils;
public static class PasswordHasherUtil
{
    public static string HashPassword(string password)
    {
        // Generate a new salt for the user
        string salt = BCrypt.Net.BCrypt.GenerateSalt();

        // Hash the password with the generated salt and work factor of 12 iterations
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, workFactor: SystemConstants.PasswordIteration);

        // Combine the hashed password and salt and store it in the database (along with other user details)
        string passwordWithSalt = $"{hashedPassword}{salt}";

        return passwordWithSalt;
    }

    public static bool VerifyPassword(string password, string hashedPasswordWithSalt)
    {
        // Extract the hashed password and salt from the stored hashed password
        string hashedPassword = hashedPasswordWithSalt.Substring(0, 60); // The length of the Bcrypt hashed password is typically 60 characters.
        string salt = hashedPasswordWithSalt.Substring(60);

        // Verify the password by using BCrypt's Verify method
        bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(password, hashedPassword);

        return isPasswordCorrect;
    }
}
