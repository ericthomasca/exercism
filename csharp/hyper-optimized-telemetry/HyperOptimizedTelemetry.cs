using System;
using System.Linq;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] byteArray;
        
        switch (reading)
        {
            case > int.MaxValue and <= uint.MaxValue:
                byteArray = BitConverter.GetBytes((uint)reading).Prepend((byte)(2)).ToArray();
                break;
            case > ushort.MaxValue and <= int.MaxValue:
                byteArray = BitConverter.GetBytes((int)reading).Prepend((byte)(256 - 2)).ToArray();
                break;
            case >= ushort.MinValue and <= ushort.MaxValue:
                byteArray = BitConverter.GetBytes((ushort)reading).Prepend((byte)(2)).ToArray();
                break;
            case >= short.MinValue and < ushort.MinValue:
                byteArray = BitConverter.GetBytes((short)reading).Prepend((byte)(256 - 2)).ToArray();
                break;
            case >= int.MinValue and < short.MinValue:
                byteArray = BitConverter.GetBytes((int)reading).Prepend((byte)(256 - 4)).ToArray();
                break;
            default:
                byteArray = BitConverter.GetBytes(reading).Prepend((byte)(256 - 2)).ToArray();
                break;
        }

        return byteArray;
    }

    public static long FromBuffer(byte[] buffer)
    {
        return BitConverter.ToInt64(buffer);
    }
}
