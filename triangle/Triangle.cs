using System;
using System.Collections.Generic;
using System.Linq;

public static class Triangle
{
    //no sides are equal
    public static bool IsScalene(double side1, double side2, double side3)
    {
        List<double> sides = new List<double> { side1, side2, side3 };
        if (!IsTriangle(sides)) return false;

        if (sides.Distinct().Count() == 3) return true;

        return false;
    }

    //two or more sides are equal
    public static bool IsIsosceles(double side1, double side2, double side3) 
    {
        List<double> sides = new List<double> { side1, side2, side3 };
        if (!IsTriangle(sides)) return false;

        if (sides.Distinct().Count() < 3) return true;

        return false;
    }

    //all sides are equal
    public static bool IsEquilateral(double side1, double side2, double side3) 
    {
        List<double> sides = new List<double> { side1, side2, side3 };
        if (!IsTriangle(sides)) return false;

        if (sides.Distinct().Count() == 1) return true;

        return false;
    }

    //one side equals the sum of the other two
    public static bool IsDegenerate (double side1, double side2, double side3)
    {
        List<double> sides = new List<double> { side1, side2, side3 };
        if (!IsTriangle(sides)) return false;

        if (sides.Any(d => d == sides.Sum() - d)) return true;

        return false;
    }

    //all sides have to be of length > 0
    //the sum of the lengths of any two sides must be greater than or equal to the length of the third side.
    private static bool IsTriangle (List<double> sides)
    {
        if (sides.Any(d => d <= 0)) return false;

        if (sides.Any(d => d > sides.Sum() - d)) return false;

        return true;
    }    
}