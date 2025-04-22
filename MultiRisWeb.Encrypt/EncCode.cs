// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Encrypt.Util.EncCode
// Assembly: MultiRisWeb.Encrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEC2A16-CAD8-4818-BF8E-8265F902CC1E
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Encrypt.dll

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MultiRisWeb.Encrypt.Util
{
  public class EncCode
  {
    public static string Encode(string plainText, string initVector, string passPhrase)
    {
      string saltValue = "WS";
      string hashAlgorithm = "SHA1";
      int passwordIterations = 2;
      int keySize = 256;
      return EncCode.Encrypt(plainText, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
    }

    public static string Decode(string cipherText, string initVector, string passPhrase)
    {
      string saltValue = "WS";
      string hashAlgorithm = "SHA1";
      int passwordIterations = 2;
      int keySize = 256;
      return EncCode.Decrypt(cipherText, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
    }

    private static string Encrypt(
      string plainText,
      string passPhrase,
      string saltValue,
      string hashAlgorithm,
      int passwordIterations,
      string initVector,
      int keySize)
    {
      byte[] bytes1 = Encoding.ASCII.GetBytes(initVector);
      byte[] bytes2 = Encoding.ASCII.GetBytes(saltValue);
      byte[] bytes3 = Encoding.UTF8.GetBytes(plainText);
      byte[] bytes4 = new PasswordDeriveBytes(passPhrase, bytes2, hashAlgorithm, passwordIterations).GetBytes(keySize / 8);
      RijndaelManaged rijndaelManaged = new RijndaelManaged();
      rijndaelManaged.Mode = CipherMode.CBC;
      ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(bytes4, bytes1);
      MemoryStream memoryStream = new MemoryStream();
      CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, encryptor, CryptoStreamMode.Write);
      cryptoStream.Write(bytes3, 0, bytes3.Length);
      cryptoStream.FlushFinalBlock();
      byte[] array = memoryStream.ToArray();
      memoryStream.Close();
      cryptoStream.Close();
      return Convert.ToBase64String(array);
    }

    private static string Decrypt(
      string cipherText,
      string passPhrase,
      string saltValue,
      string hashAlgorithm,
      int passwordIterations,
      string initVector,
      int keySize)
    {
      byte[] bytes1 = Encoding.ASCII.GetBytes(initVector);
      byte[] bytes2 = Encoding.ASCII.GetBytes(saltValue);
      byte[] buffer = Convert.FromBase64String(cipherText);
      byte[] bytes3 = new PasswordDeriveBytes(passPhrase, bytes2, hashAlgorithm, passwordIterations).GetBytes(keySize / 8);
      RijndaelManaged rijndaelManaged = new RijndaelManaged();
      rijndaelManaged.Mode = CipherMode.CBC;
      ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(bytes3, bytes1);
      MemoryStream memoryStream = new MemoryStream(buffer);
      CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, decryptor, CryptoStreamMode.Read);
      byte[] numArray = new byte[buffer.Length];
      int count = cryptoStream.Read(numArray, 0, numArray.Length);
      memoryStream.Close();
      cryptoStream.Close();
      return Encoding.UTF8.GetString(numArray, 0, count);
    }
  }
}
