using System;
using System.Linq; 
using System.Text.RegularExpressions;

//valid:
//10 digits, first and fourth 2-9, all others 0-9

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        phoneNumber = RemoveWhiteSpace(phoneNumber);
        phoneNumber = RemoveLeadingPlusSign(phoneNumber);
        if (HasInvalidCharacters(phoneNumber)) throw new ArgumentException();
        phoneNumber = RemovePunctuation(phoneNumber);
        if (IsMoreThan11Digits(phoneNumber)) throw new ArgumentException();
        if (HasInvalidCountryCode(phoneNumber)) throw new ArgumentException();
        phoneNumber = RemoveCountryCode(phoneNumber);
        if (IsLessThan10Digits(phoneNumber)) throw new ArgumentException();
        if (HasInvalidAreaCode(phoneNumber)) throw new ArgumentException();
        if (HasInvalidExchangeCode(phoneNumber)) throw new ArgumentException();

        return phoneNumber;
    }

    private static string RemoveWhiteSpace(string phoneNumber)
    {
         return Regex.Replace(phoneNumber, @"\s+", "");
    }

    private static string RemoveLeadingPlusSign(string phoneNumber)
    {
        if (phoneNumber.StartsWith('+')) phoneNumber = phoneNumber.Substring(1);
        return phoneNumber;
    }

    private static bool HasInvalidCharacters (string phoneNumber)
    {
        string validCharacters = "0123456789.()-";
        foreach (char character in phoneNumber)
        {
            if (!validCharacters.Contains(character)) return true;
        }
        return false;
    }

    private static string RemovePunctuation(string phoneNumber)
    {
        return Regex.Replace(phoneNumber, "[^0-9]", "");
    }

    private static bool IsMoreThan11Digits (string phoneNumber)
    {
        if (phoneNumber.Length > 11) return true;
        return false;
    }

    private static bool HasInvalidCountryCode (string phoneNumber)
    {
        if (phoneNumber.Length == 11 && !phoneNumber.StartsWith('1')) return true;
        return false;
    }

    private static string RemoveCountryCode (string phoneNumber)
    {
        if (phoneNumber.Length == 11) phoneNumber = phoneNumber.Substring(1);
        return phoneNumber;
    }

    private static bool IsLessThan10Digits (string phoneNumber)
    {
        if (phoneNumber.Length < 10) return true;
        return false;
    }

    private static bool HasInvalidAreaCode (string phoneNumber)
    {
        if (phoneNumber.StartsWith('0') || phoneNumber.StartsWith('1')) return true;
        return false;
    }

    private static bool HasInvalidExchangeCode (string phoneNumber)
    {
        string exchangeCode = phoneNumber.Substring(3);
        if (exchangeCode.StartsWith('0') || exchangeCode.StartsWith('1')) return true;
        return false;
    }
}
