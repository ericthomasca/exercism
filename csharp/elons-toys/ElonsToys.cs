using System;

class RemoteControlCar
{
    int metersDriven = 0;
    int battery = 100;

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return String.Format("Driven {0} meters", metersDriven);
    }

    public string BatteryDisplay()
    {
        if (battery == 0)
        {
            return "Battery empty";
        }
        else
        {
            return String.Format("Battery at {0}%", battery);
        }
    }

    public void Drive()
    {
        if (battery > 0)
        {
            metersDriven += 20;
            battery--;
        }
    }
}
