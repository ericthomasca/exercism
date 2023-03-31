using System;
using System.Linq;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        // switch (reading)
        // {
        //     case >= -2_147_483_648 and <= -32_769:
        //     case >= 65_536 and <= 2_147_483_647:
        //         reading = (int)reading;
        //         break;
        //     case >= -32_768 and <= -1:
        //         reading = (short)reading;
        //         break;
        //     case >= 0 and <= 65_535:
        //         reading = (ushort)reading;
        //         break;
        //     case >= 2_147_483_648 and <= 4_294_967_295:
        //         reading = (uint)reading;
        //         break;
        //     default:
        //         break;
        // }

        byte[] byteArray = BitConverter.GetBytes(reading);

        byte[] prefixByte = BitConverter.GetBytes(256 - byteArray.Length - 1);

        byte[] prefixedByteArray = prefixByte.Concat(byteArray).ToArray();
        return prefixedByteArray;
    }

    public static long FromBuffer(byte[] buffer)
    {
        return BitConverter.ToInt64(buffer);
    }
}
