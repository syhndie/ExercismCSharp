using System;
using System.Linq;
using System.Collections.Generic;

public class Robot
{
    private const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private static Random random = new Random();
    public static HashSet<string> allNames = new HashSet<string>();

    private string _name;

    public string Name 
    {
        get
        {
            return _name;
        }
    }

    public Robot()
    {
        _name = GetName();
    }

    public void Reset()
    {
        allNames.Remove(_name);
        _name = GetName();        
    }

    private string GetName()
    {
        int i = 0;
        while (i < 1000)
        {
            string name = $"{letters[random.Next(0, 26)]}{letters[random.Next(0,26)]}{random.Next(0,10)}{random.Next(0,10)}{random.Next(0,10)}";
            if (allNames.Contains(name)) i++;
            else
            {
                allNames.Add(name);
                return name;
            }
        }
        throw new TimeoutException("It took too long to assign a name to the robot.");
    }
}
