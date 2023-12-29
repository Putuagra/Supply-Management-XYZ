namespace Supply_Management_XYZ.Server.Utilities.Handlers;

public class HashingHandler
{
    private static string GenerateSalt()
    {
        return BCrypt.Net.BCrypt.GenerateSalt();
    }

    public static string Hash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, GenerateSalt());
    }

    public static bool Validate(string password, string hashPasword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashPasword);
    }
}
