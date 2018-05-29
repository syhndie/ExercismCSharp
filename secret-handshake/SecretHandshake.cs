using System;
using System.Linq;
using System.Text.RegularExpressions;

[Flags]
public enum Events
{
    wink = 1,
    double_blink = 2,
    close_your_eyes = 4,
    jump = 8,
    reverse = 16
}

public static class SecretHandshake
{
    public static string[] Commands(int commandValue)
    {
        commandValue %= 32;

        if (commandValue == 0) return new string[] { };

        Events commandEnum = (Events)commandValue;

        var commandArray = commandEnum.ToString().Split(", ");
        for (int i = 0; i < commandArray.Length; i++)
        {
            commandArray[i] = Regex.Replace(commandArray[i], "_", " ");
        }

        if (commandArray.Last() == "reverse")
        {
            commandArray = commandArray.Reverse().Skip(1).ToArray();
        }

        return commandArray; ;
    }
}