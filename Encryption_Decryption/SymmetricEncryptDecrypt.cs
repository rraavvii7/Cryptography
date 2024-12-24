using System;
using System.Security.Cryptography;
using System.Text;

namespace Encryption_Decryption
{
	public class EncryptDecrypt
	{
        private readonly string KEY;
        private const short KEYSIZE = 256;
        private const short IVSIZE = 16;

        public EncryptDecrypt(string key)
		{
            KEY = key;
		}
        public string Encrypt(string dataToEncrypt)
        {
            if (string.IsNullOrEmpty(KEY))
            {
                throw new ArgumentNullException(nameof(KEY));
            }
            if (string.IsNullOrEmpty(dataToEncrypt))
            {
                return string.Empty;
            }

            byte[] array;
            using (Aes aes = Aes.Create())
            {
                aes.KeySize = KEYSIZE;
                aes.Key = Encoding.UTF8.GetBytes(KEY);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.GenerateIV();

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    memoryStream.Write(aes.IV);
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {

                            streamWriter.Write(dataToEncrypt);
                        }
                        array = memoryStream.ToArray();
                    }
                }
            }
            string result = Convert.ToBase64String(array);
            return result;
        }

        public string Decrypt(string dataToDecrypt)
        {
            if (string.IsNullOrEmpty(KEY))
            {
                throw new ArgumentNullException(nameof(KEY));
            }
            if (string.IsNullOrEmpty(dataToDecrypt))
            {
                return string.Empty;
            }

            byte[] iv = new byte[IVSIZE];

            using (Aes aes = Aes.Create())
            {
                aes.KeySize = KEYSIZE;
                aes.Key = Encoding.UTF8.GetBytes(KEY);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                var buffer = Convert.FromBase64String(dataToDecrypt);
                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    int read = memoryStream.Read(iv, 0, IVSIZE);
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(aes.Key, iv), CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}

