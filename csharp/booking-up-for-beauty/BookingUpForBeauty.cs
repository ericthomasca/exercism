using System;
using System.Globalization;

static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        return DateTime.Parse(appointmentDateDescription);
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        var now = DateTime.Now;

        if (appointmentDate < now)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        if (appointmentDate.Hour >= 12 && appointmentDate.Hour < 18)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static string Description(DateTime appointmentDate)
    {
        return String.Format("You have an appointment on {0:G}.", appointmentDate);
    }

    public static DateTime AnniversaryDate()
    {
        var thisYear = DateTime.Now.Year;
        return new DateTime(thisYear, 9, 15, 0, 0, 0);

    }
}
