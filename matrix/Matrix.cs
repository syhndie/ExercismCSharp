using System;
using System.Collections.Generic;
using System.Linq;

public class Matrix
{
    private int[][] arrayOfArrays;
    public Matrix(string input)
    {
        arrayOfArrays = input
            .Split('\n')
            .Select(a => a.Split(" "))
            .Select(a => a.Select(s => int.Parse(s)).ToArray())
            .ToArray();
    }

    public int Rows
    {
        get
        {
            return arrayOfArrays.Count();
        }
    }

    public int Cols
    {
        get
        {
            return arrayOfArrays[0].Count();
        }
    }

    public int[] Row(int row)
    {
        return arrayOfArrays[row];
    }

    public int[] Column(int col)
    {
        return arrayOfArrays.Select(a => a[col]).ToArray();
    }
}