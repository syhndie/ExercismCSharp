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

        for (int horizShift = -1; horizShift <= 1; horizShift++)
        {
            for (int vertShift = -1; vertShift <= 1; vertShift++)
            {
                bool notItself = horizShift != 0 || vertShift != 0;
                bool notAboveGrid = row + horizShift >= 0;
                bool notBelowGrid = row + horizShift < mines.Length;
                bool notLeftOfGrid = col + vertShift >= 0;
                bool notRightOfGrid = col + vertShift < mines[row].Length;

                bool validNeighbor = notItself && notAboveGrid && notBelowGrid && notLeftOfGrid && notRightOfGrid;

                if (validNeighbor && mines[row + horizShift][col + vertShift] == '*')
                {
                    neighborMineCount++;
                }
            }
        }

        char neighborMineCountAsChar = neighborMineCount.ToString().ToCharArray()[0];
        if (neighborMineCountAsChar == '0') neighborMineCountAsChar = ' ';

        return neighborMineCountAsChar;
    }
}
