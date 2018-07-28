using System;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

public class SimpleCipher
{
    string _key;

    public SimpleCipher()
    {
        _key = GetRandomKey();
    }

    public SimpleCipher(string key)
    {
        _key = key;
    }
    
    public string Key 
    {
        get
        {
            return _key;
        }
    }

    private string GetRandomKey()
    {
        char[] potentialChars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        byte[] randomBytes = new byte[100];

        using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
        {
            crypto.GetNonZeroBytes(randomBytes);
        }

        StringBuilder randomString = new StringBuilder(100);

        foreach (byte b in randomBytes)
        {
            randomString.Append(potentialChars[b % potentialChars.Length]);
        }

        return randomString.ToString();
    }

    public string Encode(string plaintext)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public string Decode(string ciphertext)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}