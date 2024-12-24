using System.Security.Cryptography;
using System.Text;

namespace Encryption_Decryption
{
	public static class Hashing
	{
        public static StringBuilder CreateHash(string input)
        {

            // Convert the input string to a byte array
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Compute the hash using SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // Convert the hash byte array to a hexadecimal string
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // Converts byte to 2-digit hex
                }
                return sb;
                
            }
        }
        
	}
}

