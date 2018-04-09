using System;

public struct Clock
{
    public Clock(int hours, int minutes)
    {
        _minutes = minutes;
        _hours = hours;

        while (_minutes > 59)
        {
            _hours++;
            _minutes = _minutes - 60;
        }
        while (_minutes < 0)
        {
            _hours--;
            _minutes = _minutes + 60;
        }
        while (_hours > 23)
        {
            _hours = _hours - 24;
        }
        while (_hours < 0)
        {
            _hours = _hours + 24;
        }
    }

    private int _minutes { get; set; }
    private int _hours { get; set; }

    public int Minutes
    {
        get
        {
            return _minutes;
        }
    }

    public int Hours
    {
        get
        {
            return _hours;
        }
    }

    public Clock Add(int minutesToAdd)
    {
        _minutes = _minutes + minutesToAdd;
        return new Clock(_hours, _minutes);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        _minutes = _minutes - minutesToSubtract;
        return new Clock(_hours, _minutes);
    }

    public override string ToString()
    {
        return $"{Hours.ToString("D2")}:{Minutes.ToString("D2")}";
    }
}