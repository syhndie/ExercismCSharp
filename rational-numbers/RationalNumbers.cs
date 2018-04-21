using System;
using System.Diagnostics;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        double result = Math.Pow(realNumber, ((double)r.Numerator / (double)r.Denominator));
        return result;
    }
}

public struct RationalNumber
{
    public int Numerator { get; set; }
    public int Denominator { get; set; }

    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new DivideByZeroException("The denominator cannot be zero.");
        }
        else if (numerator == 0)
        {
            Numerator = 0;
            Denominator = 1;
        }
        else
        {
            int gcd = GetGCD(numerator, denominator);

            Numerator = numerator / gcd;
            Denominator = denominator / gcd;
        }
    }

    public RationalNumber Add(RationalNumber r)
    {
        int sumnum = this.Numerator * r.Denominator + r.Numerator * this.Denominator;
        int sumden = this.Denominator * r.Denominator;
        return new RationalNumber(sumnum, sumden);
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        return r1.Add(r2);
    }

    public RationalNumber Sub(RationalNumber r)
    {
        int difnum = this.Numerator * r.Denominator - r.Numerator * this.Denominator;
        int difden = this.Denominator * r.Denominator;
        return new RationalNumber(difnum, difden);
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        return r1.Sub(r2);
    }

    public RationalNumber Mul(RationalNumber r)
    {
        int prodnum = this.Numerator * r.Numerator;
        int prodden = this.Denominator * r.Denominator;
        return new RationalNumber(prodnum, prodden);
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        return r1.Mul(r2);
    }

    public RationalNumber Div(RationalNumber r)
    {
        int quotnum = this.Numerator * r.Denominator;
        int quotden = r.Numerator * this.Denominator;
        return new RationalNumber(quotnum, quotden);
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        return r1.Div(r2);
    }

    public RationalNumber Abs()
    {
        this.Numerator = Math.Abs(this.Numerator);
        this.Denominator = Math.Abs(this.Denominator);
        return this;
    }

    public RationalNumber Reduce()
    {
        return this;
    }

    public RationalNumber Exprational(int power)
    {
        int exprationalnum = 1;
        int exprationalden = 1;

        if (power > 0)
        {
            exprationalnum = (int)Math.Pow(this.Numerator, Math.Abs(power));
            exprationalden = (int)Math.Pow(this.Denominator, Math.Abs(power));
        }
        else if (power < 0)
        {
            exprationalnum = (int)Math.Pow(this.Denominator, Math.Abs(power));
            exprationalden = (int)Math.Pow(this.Numerator, Math.Abs(power));
        }

        return new RationalNumber(exprationalnum, exprationalden);
    }

    private static int GetGCD(int a, int b)
    {
        while (a != 0 && b != 0)
        {
            if (Math.Abs(a) > Math.Abs(b)) a %= b;
            else b %= a;
        }

        if (a == 0) return b;
        else return a;
    }
}