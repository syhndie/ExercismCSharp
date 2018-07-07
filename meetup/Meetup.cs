using System;
using System.Linq;
using System.Collections.Generic;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private readonly DateTime[] _calendar;

    public Meetup(int month, int year)
    {
        int daysInMonth = DateTime.DaysInMonth(year, month);

        _calendar = Enumerable.Range(1, daysInMonth).Select(i => new DateTime(year, month, i)).ToArray();
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        DateTime[] daysOfInterest = _calendar.Where(d => d.DayOfWeek == dayOfWeek).ToArray();

        switch (schedule)
        {
            case Schedule.Teenth:
                return daysOfInterest.Single(d => d.Day > 12 && d.Day < 20);
            case Schedule.First:
                return daysOfInterest[0];
            case Schedule.Second:
                return daysOfInterest[1];
            case Schedule.Third:
                return daysOfInterest[2];
            case Schedule.Fourth:
                return daysOfInterest[3];
            default:
                return daysOfInterest.Last();
        }
    }
}