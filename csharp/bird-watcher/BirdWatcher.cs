using System;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return new int[] {0, 2, 5, 3, 7, 8, 4};
    }

    public int Today()
    {
        return birdsPerDay[birdsPerDay.Length - 1];
    }

    public void IncrementTodaysCount()
    {
        birdsPerDay[birdsPerDay.Length - 1]++;
    }

    public bool HasDayWithoutBirds()
    {
        bool birdlessDay = false;
        foreach (int bird in birdsPerDay)
        {
            if (bird == 0)
            {
                birdlessDay = true;
            }
        }
        return birdlessDay;
            
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int totalBirds = 0;
        for (int i = 0; i < numberOfDays; i++)
        {
            totalBirds += birdsPerDay[i];
        }
        return totalBirds;
    }

    public int BusyDays()
    {
        int totalDays = 0;
        foreach (int bird in birdsPerDay)
        {
            if (bird >= 5)
            {
                totalDays++;
            }
        }
        return totalDays;
    }
}
