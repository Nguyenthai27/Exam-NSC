using System;
using System.Security.Cryptography;
using System.Text;

class ProgramQuestion1  
{
    static void Main()
    {
        // Generate public and private key pair
        using (var rsa = new RSACryptoServiceProvider())
        {
            // Get public key
            string publicKey = rsa.ToXmlString(false);
            Console.WriteLine("Public Key:");
            Console.WriteLine(publicKey);

            // Get private key
            string privateKey = rsa.ToXmlString(true);
            Console.WriteLine("\nPrivate Key:");
            Console.WriteLine(privateKey);

            // Original data
            string originalData = "Hello, World!";

            // Encrypt using the public key
            byte[] encryptedData = EncryptData(originalData, publicKey);
            Console.WriteLine("\nEncrypted Data:");
            Console.WriteLine(Convert.ToBase64String(encryptedData));

            // Decrypt using the private key
            string decryptedData = DecryptData(encryptedData, privateKey);
            Console.WriteLine("\nDecrypted Data:");
            Console.WriteLine(decryptedData);
        }
    }

    static byte[] EncryptData(string data, string publicKey)
    {
        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(publicKey);
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            return rsa.Encrypt(dataBytes, false);
        }
    }

    static string DecryptData(byte[] encryptedData, string privateKey)
    {
        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(privateKey);
            byte[] decryptedData = rsa.Decrypt(encryptedData, false);
            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}
