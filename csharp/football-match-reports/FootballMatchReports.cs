using System;

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        switch (shirtNum)
        {
            case 1:
                return "goalie";
            case 2:
                return "left back";
            case 3: 
            case 4:
                return "center back";
            case 5:
                return "right back";
            case 6:
            case 7:
            case 8:
                return "midfielder";
            case 9:
                return "left wing";
            case 10:
                return "striker";
            case 11:
                return "right wing";
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public static string AnalyzeOffField(object report)
    {
        if (report.GetType() == typeof(int))
        {
            return $"There are {report} supporters at the match.";
        }
        else if (report.GetType() == typeof(string))
        {
            return (string)report;
        }
        else if (report.GetType() == typeof(Injury))
        {
            return $"Oh no! Player {report} is injured. Medics are on the field.";
        }
        else
        {
            throw new ArgumentException();
        }
    }
}
