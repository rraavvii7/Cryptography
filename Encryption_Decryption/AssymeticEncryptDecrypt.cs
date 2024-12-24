using System;
using System.Security.Cryptography;

namespace Encryption_Decryption
{
	public static class AssymeticEncryptDecrypt
	{

        public static byte[] EncryptData(byte[] data, string publicKeyBase64)
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportRSAPublicKey(Convert.FromBase64String(publicKeyBase64), out _);
                return rsa.Encrypt(data, RSAEncryptionPadding.OaepSHA256);
            }
        }

        public static byte[] DecryptData(byte[] data, string privateKeyBase64)
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportRSAPrivateKey(Convert.FromBase64String(privateKeyBase64), out _);
                return rsa.Decrypt(data, RSAEncryptionPadding.OaepSHA256);
            }
        }
    }
}

