using System;
using System.Linq;
using System.Collections.Generic;

public static class Minesweeper
{
    public static string[] Annotate(string[] input)
    {
        char[][] mines = input.Select(s => s.ToCharArray()).ToArray();
        char[][] counts = mines;
        string[] result = new string[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < mines[i].Length; j++ )
            {
                if (mines[i][j] == '*') counts[i][j] = '*';
                else counts[i][j] = GetCount(mines, i, j);

                if (counts[i][j] == '0') counts[i][j] = ' ';
            } 

            result[i] = new string(counts[i]);
        }

        return result;
    }

    private static char GetCount(char[][] mines, int i, int j)
    {
        List<char> neighbors = new List<char>();

        if (i - 1 >=0)
        {
            if (j - 1 >= 0) neighbors.Add(mines[i - 1][j - 1]);
            neighbors.Add(mines[i - 1][j]);
            if (j + 1 < mines[i].Length) neighbors.Add(mines[i - 1][j + 1]);
        }

        if (i + 1 < mines.Length)
        {
            if (j - 1 >= 0) neighbors.Add(mines[i + 1][j - 1]);
            neighbors.Add(mines[i + 1][j]);
            if (j + 1 < mines[i].Length) neighbors.Add(mines[i + 1][j + 1]);
        }

        if (j - 1 >= 0) neighbors.Add(mines[i][j - 1]);
        if (j + 1 < mines[i].Length) neighbors.Add(mines[i][j + 1]);

        return neighbors.Count(c => c == '*').ToString().ToCharArray()[0];
    }
}
