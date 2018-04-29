using System;

public class SpaceAge
{
    private double Seconds { get; set; }
    private const double EarthPeriod = 31557600;
    private const double MercuryPeriod = EarthPeriod * 0.2408467;
    private const double VenusPeriod = EarthPeriod * 0.61519726;
    private const double MarsPeriod = EarthPeriod * 1.8808158;
    private const double JupiterPeriod = EarthPeriod * 11.862615;
    private const double SaturnPeriod = EarthPeriod * 29.447498;
    private const double UranusPeriod = EarthPeriod * 84.016846;
    private const double NeptunePeriod = EarthPeriod * 164.79132;

    public SpaceAge(long seconds)
    {
        Seconds = seconds;
    }

    private double CalculateAge(double period)
    {
        return Math.Round(Seconds / period, 2, MidpointRounding.AwayFromZero);
    }

    public double OnEarth()
    {
        return CalculateAge(EarthPeriod);
    }

    public double OnMercury()
    {
        return CalculateAge(MercuryPeriod);
    }

    public double OnVenus()
    {
        return CalculateAge(VenusPeriod);
    }

    public double OnMars()
    {
        return CalculateAge(MarsPeriod);
    }

    public double OnJupiter()
    {
        return CalculateAge(JupiterPeriod);
    }

    public double OnSaturn()
    {
        return CalculateAge(SaturnPeriod);
    }

    public double OnUranus()
    {
        return CalculateAge(UranusPeriod);
    }

    public double OnNeptune()
    {
        return CalculateAge(NeptunePeriod);
    }
}