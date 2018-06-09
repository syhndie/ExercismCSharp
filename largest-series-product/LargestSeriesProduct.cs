using System;
using System.Linq;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span) 
    {
        if (span < 0 || digits.Length < span) throw new ArgumentException();
        if (digits.Any(c => !Char.IsDigit(c))) throw new ArgumentException();

        int maxProduct = 0;

        for (int i = 0; i <= digits.Length - span; i++)
        {
            var newSegment = digits.Substring(i, span);

            var newProduct = 1;
            for (int j = 0; j < newSegment.Length; j++)
            {
                newProduct = newProduct * int.Parse(newSegment[j].ToString());
            }

            if (newProduct > maxProduct) maxProduct = newProduct;
        }
        return maxProduct; ;
    }
}