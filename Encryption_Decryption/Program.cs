// See https://aka.ms/new-console-template for more information
using Encryption_Decryption;

Console.WriteLine("Hello, World!");

EncryptDecrypt ed = new("+=jsdkkdlo4454GG00155sajuklmbk%@");

var encryptedData = ed.Encrypt("I wish if I were extremely rich");
Console.WriteLine(encryptedData);
var decryptedData = ed.Decrypt(encryptedData);
Console.WriteLine(decryptedData);

