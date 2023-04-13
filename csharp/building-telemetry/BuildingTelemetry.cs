using System;
using System.Linq;

public class RemoteControlCar
{
    private int batteryPercentage = 100;
    private int distanceDrivenInMeters = 0;
    private string[] sponsors = new string[0];
    private int latestSerialNum = 0;

    public void Drive()
    {
        if (batteryPercentage > 0)
        {
            batteryPercentage -= 10;
            distanceDrivenInMeters += 2;
        }
    }

    public void SetSponsors(params string[] sponsors)
    {
        this.sponsors = sponsors ?? Array.Empty<string>();
    }

    public string DisplaySponsor(int sponsorNum) 
        => this.sponsors[sponsorNum];

    public bool GetTelemetryData(ref int serialNum,
        out int batteryPercentage, out int distanceDrivenInMeters)
    {
        if (serialNum > this.latestSerialNum)
        {
            this.latestSerialNum = serialNum;
            batteryPercentage = 80;
            distanceDrivenInMeters = 4;
            return true;
        }
        else
        {
            serialNum = this.latestSerialNum;
            batteryPercentage = -1;
            distanceDrivenInMeters = -1;
            return false;
        }
    }

    public static RemoteControlCar Buy() => new RemoteControlCar();

}

public class TelemetryClient
{
    private RemoteControlCar car;

    public TelemetryClient(RemoteControlCar car)
    {
        this.car = car;
    }

    public string GetBatteryUsagePerMeter(int serialNum)
    {
        bool telemetryData = car.GetTelemetryData(ref serialNum, out int batteryPercentage, out int distanceDrivenInMeters);
        if (telemetryData || (batteryPercentage == 100 && distanceDrivenInMeters == 0))
        {
            return "no data";
        }
        else
        {
            var usagePerMeter = (100 - batteryPercentage) / distanceDrivenInMeters;
            return $"usage-per-meter={usagePerMeter}";
        }
    }

}
