using System;

class WeighingMachine
{
    private int precision;
    private static double weight;
    private static double tareAdjustment;

    public WeighingMachine(int precision)
    {
        this.precision = precision;
        tareAdjustment = 5.0;
    }

    public int Precision
    {
        get => precision;
    }

    public double Weight
    {
        get => weight;
        set => weight = (value >= 0) ? value : throw new ArgumentOutOfRangeException();
    }

    public string DisplayWeight
    {
        get => string.Format("{0:F" + precision.ToString() + "} kg", weight - tareAdjustment);

    }

    public double TareAdjustment
    {
        set => tareAdjustment = value;
    }
}
