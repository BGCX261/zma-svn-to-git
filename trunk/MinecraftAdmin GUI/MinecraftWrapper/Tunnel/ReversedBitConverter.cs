using System;
using System.Collections.Generic;
using System.Text;

namespace Vitt.Andre.TCPTunnelLib.Vitt.Andre.Tunnel
{
    public class ReversedBitConverter
    {
        public static byte[] GetBytes(byte b)
        {
            return new byte[] { b };
        }

        public static byte[] GetBytes(Boolean b)
        {
            return ReversedCopy(BitConverter.GetBytes(b), 0, 1);
        }

        public static byte[] GetBytes(Int16 i)
        {
            return ReversedCopy(BitConverter.GetBytes(i),0,2);
        }

        public static byte[] GetBytes(Int32 i)
        {
            return ReversedCopy(BitConverter.GetBytes(i), 0, 4);
        }

        public static byte[] GetBytes(Int64 i)
        {
            return ReversedCopy(BitConverter.GetBytes(i), 0, 8);
        }

        public static byte[] GetBytes(Single s)
        {
            return ReversedCopy(BitConverter.GetBytes(s), 0, 4);
        }

        public static byte[] GetBytes(Double d)
        {
            return ReversedCopy(BitConverter.GetBytes(d), 0, 8);
        }

        public static Boolean ToBoolean(byte[] data, int start)
        {
            byte[] bytes = ReversedCopy(data, start, 1);// Byte = 1 Byte
            return BitConverter.ToBoolean(bytes, 0);
        }

        public static Byte ToByte(byte[] data, int start)
        {
            byte[] bytes = ReversedCopy(data, start, 1);// Byte = 1 Byte
            return bytes[0];
        }

        public static Int16 ToInt16(byte[] data, int start)
        {
            byte[] bytes = ReversedCopy(data, start, 2);// Int16 = 2 Bytes
            return BitConverter.ToInt16(bytes, 0);
        }

        public static Int32 ToInt32(byte[] data, int start)
        {
            byte[] bytes = ReversedCopy(data, start, 4);// Int32 = 4 Bytes
            return BitConverter.ToInt16(bytes, 0);
        }

        public static Single ToSingle(byte[] data, int start)
        {
            byte[] bytes = ReversedCopy(data, start, 4);// Singe = 4 Bytes
            return BitConverter.ToSingle(bytes, 0);
        }

        public static Double ToDouble(byte[] data, int start)
        {
            byte[] bytes = ReversedCopy(data, start, 8);// Singe = 4 Bytes
            return BitConverter.ToDouble(bytes, 0);
        }

        public static byte[] ReversedCopy(byte[] data, int start, int size)
        {
            byte[] reversedBytes = new byte[size];
            Buffer.BlockCopy(data, start, reversedBytes, 0, size);
            Array.Reverse(reversedBytes);
            return reversedBytes;
        }
    }
}
