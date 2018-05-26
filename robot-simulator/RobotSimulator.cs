using System;

public enum Direction
{
    North,
    East,
    South,
    West
}

public struct Coordinate
{
    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }
}

public class RobotSimulator
{
    public RobotSimulator(Direction direction, Coordinate coordinate)
    {
        _direction = direction;
        _coordinate = coordinate;
    }

    private Direction _direction;
    public Direction Direction
    {
        get
        {
            return _direction;
        }
    }

    private Coordinate _coordinate;
    public Coordinate Coordinate
    {
        get
        {
            return _coordinate;
        }
    }

    public void TurnRight()
    {
        switch(Direction)
        {
            case Direction.North:
                _direction = Direction.East;
                break;

            case Direction.East:
                _direction = Direction.South;
                break;

            case Direction.South:
                _direction = Direction.West;
                break;

            case Direction.West:
                _direction = Direction.North;
                break;
        }
    }

    public void TurnLeft()
    {
        switch (Direction)
        {
            case Direction.North:
                _direction = Direction.West;
                break;

            case Direction.East:
                _direction = Direction.North;
                break;

            case Direction.South:
                _direction = Direction.East;
                break;

            case Direction.West:
                _direction = Direction.South;
                break;
        }
    }

    public void Advance()
    {
        switch (Direction)
        {
            case Direction.North:
                _coordinate = new Coordinate(Coordinate.X, Coordinate.Y + 1);
                break;

            case Direction.East:
                _coordinate = new Coordinate(Coordinate.X + 1, Coordinate.Y);
                break;

            case Direction.South:
                _coordinate = new Coordinate(Coordinate.X, Coordinate.Y - 1);
                break;

            case Direction.West:
                _coordinate = new Coordinate(Coordinate.X - 1, Coordinate.Y);
                break;
        }
    }

    public void Simulate(string instructions)
    {
        foreach (char command in instructions)
        {
            switch (command)
            {
                case 'L':
                    TurnLeft();
                    break;

                case 'R':
                    TurnRight();
                    break;

                case 'A':
                    Advance();
                    break;
            }
        }
    }
}