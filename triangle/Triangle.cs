using System;

public static class Triangle
{
    public static bool IsScalene(double side1, double side2, double side3)
    {
        return true;
    }

    public static bool IsIsosceles(double side1, double side2, double side3) 
    {
        return true;
    }

    public static bool IsEquilateral(double side1, double side2, double side3) 
    {
        return true;
    }
    
}

public class TriangleException : Exception { }