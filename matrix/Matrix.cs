using System;
using System.Collections.Generic;
using System.Linq;

public class MatrixElement
{
    public int Value { get; set; }
    public int Row { get; set; }
    public int Col { get; set; }
}

public class Matrix
{
    private List<MatrixElement> elements;

    public Matrix(string input)
    {
        elements = new List<MatrixElement>();
        int elementInt = 0;
        int row = 0;
        int col = 0;

        string[] rowArray = input.Split('\n');

        foreach (string rowString in rowArray)
        {
            string[] elementArray = rowString.Split(" ");

            foreach (string elementString in elementArray)
            {
                if (int.TryParse(elementString, out elementInt))
                {
                    MatrixElement element = new MatrixElement
                    {
                        Value = elementInt,
                        Row = row,
                        Col = col
                    };

                    elements.Add(element);
                }
                else
                {
                    throw new ArgumentException("Invalid input. Only integer values are allowed.");
                }

                col++;
            }

            col = 0;
            row++;
        }        
    }

    public int Rows
    {
        get
        {
            return elements.Max(e => e.Row) + 1;
        }
    }

    public int Cols
    {
        get
        {
            return elements.Max(e => e.Col) + 1;
        }
    }

    public int[] Row(int row)
    {
        int[] rowArray = new int[Cols];
        for (int i = 0; i < Cols; i++)
        {
            rowArray[i] = elements
                .Where(e => e.Row == row)
                .Where(e => e.Col == i)
                .Select(e => e.Value)
                .Single();
        }

        return rowArray;
    }

    public int[] Column(int col)
    {
        int[] colArray = new int[Rows];
        for (int i = 0; i < Rows; i++)
        {
            colArray[i] = elements
                .Where(e => e.Col == col)
                .Where(e => e.Row == i)
                .Select(e => e.Value)
                .Single();
        }

        return colArray;
    }
}