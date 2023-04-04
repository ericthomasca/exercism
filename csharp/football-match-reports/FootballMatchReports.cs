using System;

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        string position;
        switch (shirtNum)
        {
            case 1:
                position = "goalie";
                break;
            case 2:
                position = "left back";
                break;
            case 3:
            case 4:
                position = "center back";
                break;
            case 5:
                position = "right back";
                break;
            case 6:
            case 7:
            case 8:
                position = "midfielder";
                break;
            case 9:
                position = "left wing";
                break;
            case 10:
                position = "striker";
                break;
            case 11:
                position = "right wing";
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        return position;
    }

    public static string AnalyzeOffField(object report)
    {
        string reportDisplayed;
        switch (report)
        {
            case int supporters:
                reportDisplayed = $"There are {supporters} supporters at the match.";
                break;
            case string announcement:
                reportDisplayed = announcement;
                break;
            case Injury injury:
                reportDisplayed = $"Oh no! {injury.GetDescription()} Medics are on the field.";
                break;
            case Incident incident:
                reportDisplayed = $"{incident.GetDescription()}";
                break;
            case Manager manager when manager.Club is null:
                reportDisplayed = $"{manager.Name}";
                break;
            case Manager manager when manager.Club is not null:
                reportDisplayed = $"{manager.Name} ({manager.Club})";
                break;
            default:
                throw new ArgumentException();
        }
        return reportDisplayed;
    }
}
