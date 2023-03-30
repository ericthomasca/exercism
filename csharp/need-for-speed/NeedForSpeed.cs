using System;

class RemoteControlCar
{
    public int speed;
    public int batteryDrain;
    private int metersDriven;
    public int battery;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
        this.battery = 100;
        this.metersDriven = 0;
    }

    public bool BatteryDrained()
    {
        if (this.battery < this.batteryDrain)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int DistanceDriven()
    {
        return this.metersDriven;
    }

    public void Drive()
    {
        if (this.battery >= this.batteryDrain)
        {
            this.metersDriven += this.speed;
            this.battery -= this.batteryDrain;
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}

class RaceTrack
{
    private int distance;

    public RaceTrack(int distance)
    {
        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        var carMaxDistance = car.speed * car.battery / car.batteryDrain;

        if (carMaxDistance >= this.distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
