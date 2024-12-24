// See https://aka.ms/new-console-template for more information
using Encryption_Decryption;


//symmetric encryption
EncryptDecrypt ed = new("+=jsdkkdlo4454GG00155sajuklmbk%@");

var encryptedData = ed.Encrypt("I wish if I were extremely rich");
Console.WriteLine(encryptedData);
var decryptedData = ed.Decrypt(encryptedData);
Console.WriteLine(decryptedData);


//hashing
var hashedData1 = Hashing.CreateHash("ravi").ToString();
var hashedData2 = Hashing.CreateHash("ravi").ToString();
Console.WriteLine(hashedData1);
Console.WriteLine(hashedData2);

Console.WriteLine(string.Equals(hashedData1, hashedData2, StringComparison.Ordinal));
Console.ReadLine();


