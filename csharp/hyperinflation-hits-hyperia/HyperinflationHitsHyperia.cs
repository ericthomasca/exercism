using System;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try
        {
            var displayDenomination = checked(@base * multiplier);
            return displayDenomination.ToString();
        }
        catch (OverflowException)
        {
            return "*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        float displayGDP = @base * multiplier;
        var displayGDPString = displayGDP switch
        {
            float.PositiveInfinity => "*** Too Big ***",
            _ => displayGDP.ToString()
        };
        return displayGDPString;
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try
        {
            var salary = checked(salaryBase * multiplier);
            return salary.ToString();
        }
        catch (OverflowException)
        {
            return "*** Much Too Big ***";
        }
    }
}
