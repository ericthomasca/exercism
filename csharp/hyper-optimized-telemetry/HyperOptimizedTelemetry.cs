using System;
using System.Linq;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        var byteArray switch (reading)
        {
            < 
            default:
        }
    }

    public static long FromBuffer(byte[] buffer)
    {
        return BitConverter.ToInt64(buffer);
    }
}
