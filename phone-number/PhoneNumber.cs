using System;
using System.Text.RegularExpressions;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        string onlyDigits = Regex.Replace(phoneNumber, @"\D", "");
        string pattern = @"^1?([2-9]\d{2}[2-9]\d{6})$";

        if (Regex.IsMatch(onlyDigits, pattern)) return Regex.Replace(onlyDigits, @"^1?", "");
        else throw new ArgumentException();
    }
}
