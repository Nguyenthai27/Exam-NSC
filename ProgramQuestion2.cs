using System;
using System.Security.Cryptography;
using System.Text;

class ProgramQuestion2
{
    static void Main()
    {
        // User information
        string username = "Admin";
        string password = "Adwx!@#$%xdwa";

        // Hash the password
        string hashedPassword = HashPassword(password);

        // Display the hashed password
        Console.WriteLine($"Username: {username}");
        Console.WriteLine($"Hashed Password (SHA-256): {hashedPassword}");
    }

    static string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            // Convert the password string to a byte array
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Compute the hash value of the password bytes
            byte[] hashedBytes = sha256.ComputeHash(passwordBytes);

            // Convert the hashed bytes to a hexadecimal string
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < hashedBytes.Length; i++)
            {
                stringBuilder.Append(hashedBytes[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}
