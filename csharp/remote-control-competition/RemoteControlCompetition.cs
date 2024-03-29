using System;
using System.Collections.Generic;

public interface IRemoteControlCar : IComparable<IRemoteControlCar>
{
    int DistanceTravelled { get; }
    void Drive();

  
}

public class ProductionRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public int CompareTo(IRemoteControlCar other)
    {
        return this.DistanceTravelled.CompareTo(other.DistanceTravelled);
    }

    public void Drive()
    {
        DistanceTravelled += 10;
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public int CompareTo(IRemoteControlCar other)
    {
        return this.DistanceTravelled.CompareTo(other.DistanceTravelled);
    }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        return prc1.CompareTo(prc2) switch 
        {
            > 0 => new List<ProductionRemoteControlCar> { prc2, prc1 },
            _ => new List<ProductionRemoteControlCar> { prc2, prc1 }
        };
        
    }
}
