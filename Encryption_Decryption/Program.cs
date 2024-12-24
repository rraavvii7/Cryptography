// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using System.Text;
using Encryption_Decryption;


//symmetric encryption
EncryptDecrypt ed = new("+=jsdkkdlo4454GG00155sajuklmbk%@");

var encryptedData = ed.Encrypt("I wish if I were extremely rich");
Console.WriteLine(encryptedData);
var decryptedData = ed.Decrypt(encryptedData);
Console.WriteLine(decryptedData);


//assymetric encryption
var originalData = "this is for assymetric encryption using public key and private key";
using (RSA rsa = RSA.Create())
{
    // Export public and private keys
    string publicKey = Convert.ToBase64String(rsa.ExportRSAPublicKey());
    string privateKey = Convert.ToBase64String(rsa.ExportRSAPrivateKey());

    Console.WriteLine("Public Key:\n" + publicKey);
    Console.WriteLine("\nPrivate Key:\n" + privateKey);

    // Encrypt the data using the public key
    byte[] encryptedDataBytes = AssymeticEncryptDecrypt.EncryptData(Encoding.UTF8.GetBytes(originalData), publicKey);
    Console.WriteLine("\nEncrypted Data (Base64):\n" + Convert.ToBase64String(encryptedDataBytes));

    // Decrypt the data using the private key
    byte[] decryptedDataBytes = AssymeticEncryptDecrypt.DecryptData(encryptedDataBytes, privateKey);
    string decryptedMessage = Encoding.UTF8.GetString(decryptedDataBytes);
    Console.WriteLine("\nDecrypted Message:\n" + decryptedMessage);
}


//hashing
var hashedData1 = Hashing.CreateHash("ravi").ToString();
var hashedData2 = Hashing.CreateHash("ravi").ToString();
Console.WriteLine(hashedData1);
Console.WriteLine(hashedData2);

Console.WriteLine(string.Equals(hashedData1, hashedData2, StringComparison.Ordinal));
Console.ReadLine();


