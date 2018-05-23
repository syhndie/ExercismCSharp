using System;
using System.Linq;

public class Queen
{
    public Queen(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }
}

public static class QueenAttack
{
    public static bool CanAttack(Queen white, Queen black)
    {
        if (white.Row == black.Row) return true;
        if (white.Column == black.Column) return true;
        if (Math.Abs(white.Column - black.Column) == Math.Abs(white.Row - black.Row)) return true;
        return false;
    }

    public static Queen Create(int row, int column)
    {
        var allowable =Enumerable.Range(0, 8);

        if (allowable.Contains(row) && allowable.Contains(column)) return new Queen(row, column);
        else throw new ArgumentOutOfRangeException();
    }
}