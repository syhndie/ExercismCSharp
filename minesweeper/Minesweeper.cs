using System.Linq;

public static class Minesweeper
{
    public static string[] Annotate(string[] input)
    {
        char[][] inputAsChars = input.Select(s => s.ToCharArray()).ToArray();
        char[][] outputAsChars = inputAsChars;
        string[] outputAsStrings = new string[input.Length];

        for (int row = 0; row < input.Length; row++)
        {
            for (int col = 0; col < inputAsChars[row].Length; col++ )
            {
                if (inputAsChars[row][col] == '*') continue;
                else outputAsChars[row][col] = GetCountAsChar(inputAsChars, row, col);
            } 

            outputAsStrings[row] = new string(outputAsChars[row]);
        }

        return outputAsStrings;
    }
    
    private static char GetCountAsChar(char[][] mines, int row, int col)
    {
        int neighborMineCount = 0;

        for (int vertChange = -1; vertChange <= 1; vertChange++)
        {
            for (int hoirzChange = -1; hoirzChange <= 1; hoirzChange++)
            {
                if (vertChange == 0 && hoirzChange == 0) continue;
                if (row + vertChange < 0) continue;
                if (row + vertChange >= mines.Length) continue;
                if (col + hoirzChange < 0) continue;
                if (col + hoirzChange >= mines[row].Length) continue;

                if (mines[row + vertChange][col + hoirzChange] == '*') neighborMineCount++;                
            }
        }

        char neighborMineCountAsChar = neighborMineCount.ToString().ToCharArray()[0];
        if (neighborMineCountAsChar == '0') neighborMineCountAsChar = ' ';

        return neighborMineCountAsChar;
    }
}
