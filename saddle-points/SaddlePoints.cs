using System;
using System.Collections.Generic;
using System.Linq;

public class SaddlePoints
{
    private int[,] Values { get; set; }

    public SaddlePoints(int[,] values)
    {
        Values = values;
   }

    public IEnumerable<Tuple<int, int>> Calculate()
    {
        int[] rowMaxes = new int[Values.GetLength(0)];
        for (int row = 0; row < Values.GetLength(0); row++)
        {
            rowMaxes[row] = int.MinValue;
            for (int col = 0; col < Values.GetLength(1); col++)
            {
                if (Values[row, col] > rowMaxes[row])
                {
                    rowMaxes[row] = Values[row, col];
                }
            }
        }

        int[] colMins = new int[Values.GetLength(1)];
        for (int col = 0; col < Values.GetLength(1); col++)
        {
            colMins[col] = int.MaxValue;
            for (int row = 0; row < Values.GetLength(0); row++)
            {
                if (Values[row, col] < colMins[col])
                {
                    colMins[col] = Values[row, col];
                }
            }
        }

        var saddleCoordinates = new List<Tuple<int, int>>();
        for (int row = 0; row < Values.GetLength(0); row++)
        {
            for (int col = 0; col < Values.GetLength(1); col++)
            {
                if (Values[row, col] == rowMaxes[row] && Values[row, col] == colMins[col])
                {
                    saddleCoordinates.Add(Tuple.Create(row, col));
                }
            }
        }
        return saddleCoordinates;
    }
}