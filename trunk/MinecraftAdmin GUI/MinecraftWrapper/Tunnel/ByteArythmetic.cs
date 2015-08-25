
using System;
using System.Text;
using System.Collections.Generic;

namespace Vitt.Andre.Tunnel 
{

    public static class ByteArythmetic
    {
        public static Encoding EncodingUtf8 = new UTF8Encoding(false);
        public static Encoding EncodingUtf16 = new UnicodeEncoding(true,false);

        

        public static byte[] GetDoubleBytes(double d, int start)
        {
            byte[] data = BitConverter.GetBytes(d);
            Array.Reverse(data);
            return data;
        }

        public static byte[] GetFloatBytes(float f, int start)
        {
            byte[] data = BitConverter.GetBytes(f);
            Array.Reverse(data);
            return data;
        }

        public static byte[] GetInt64Bytes(long i, long start)
        {
            byte[] data = BitConverter.GetBytes(i);
            Array.Reverse(data);
            return data;
        }

        public static byte[] GetInt32Bytes(int i, int start)
        {
            byte[] data = BitConverter.GetBytes(i);
            Array.Reverse(data);
            return data;
        }

        public static byte[] GetInt16Bytes(short s, int start)
        {
            byte[] data = BitConverter.GetBytes(s);
            Array.Reverse(data);
            return data;
        }

        public static byte[] GetDouble(double d, int start)
        {
            byte[] data = BitConverter.GetBytes(d);
            Array.Reverse(data);
            return data;
        }

        public static double GetDouble(byte[] arr, int start)
        {
            return BitConverter.ToDouble(new byte[] { arr[start + 7], arr[start + 6], arr[start + 5], arr[start + 4], arr[start + 3], arr[start + 2], arr[start + 1], arr[start] }, 0);
        }

        public static float GetFloat(byte[] arr, int start)
        {
            return BitConverter.ToSingle(new byte[] { arr[start + 3], arr[start + 2], arr[start + 1], arr[start] }, 0);
        }

        public static int GetInt32(byte[] arr, int start)
        {
            return BitConverter.ToInt32(new byte[] { arr[start + 3], arr[start + 2], arr[start + 1], arr[start] }, 0);
        }

        public static Int64 GetInt64(byte[] arr, int start)
        {
            return BitConverter.ToInt64(new byte[] { arr[start + 7], arr[start + 6], arr[start + 5], arr[start + 4], arr[start + 3], arr[start + 2], arr[start + 1], arr[start] }, 0);
        }

        public static short GetInt16(byte[] arr, int start)
        {
            return BitConverter.ToInt16(new byte[] { arr[start + 1], arr[start] }, 0);
        }

        public static byte GetByte(byte[] arr, int start)
        {
            return arr[start];
        }

        public static bool GetBoolean(byte[] arr, int start)
        {
            return BitConverter.ToBoolean(new byte[] { arr[start] }, 0);
        }

        public static byte[] GetBooleanBytes(bool b, int start)
        {
            byte[] data = BitConverter.GetBytes(b);
            Array.Reverse(data);
            return data;
        }

        public static string GetString(byte[] arr, int start)
        {
            return EncodingUtf16.GetString(arr, start + 2, GetInt16(arr, start)); // update 1.5 *2 because of UTF16
        }

        public static string GetStringUtf8(byte[] arr, int start)
        {
            return EncodingUtf8.GetString(arr, start + 2, GetInt16(arr, start));
        }

        public static bool ContainsInvalidChars(string str, bool isname)
        {
            foreach (char ch in str)
            {
                if (ch == ' ')
                {
                    return true;
                }
            }
            return false;
        }

        public static void NinA(short num, byte[] arr, int start)
        {
            NtoA(num).CopyTo(arr, start);
        }

        public static byte[] NtoA(short num)
        {
            byte[] bytes = BitConverter.GetBytes(num);
            byte num2 = bytes[1];
            bytes[1] = bytes[0];
            bytes[0] = num2;
            return bytes;
        }

        public static void SinA(string str, byte[] arr, int start)
        {
            StoA(str).CopyTo(arr, start);
        }

        public static byte[] StoA(String str, Encoding encoding)
        {
            byte[] bytes = encoding.GetBytes(str);
            if (bytes.Length > 0x7fff)
            {
                return new byte[2];
            }
            byte[] array = new byte[bytes.Length + 2];
            bytes.CopyTo(array, 2);
            NinA((short)(str.Length), array, 0);

            return array;
        }

        //public static byte[] StoA(string str, Encoding encoding)
        //{
        //    List<byte[]> dataBuffer = new List<byte[]>();

        //    int max = 119;
        //    int offset = 0;
        //    int parts = str.Length / max;
        //    int lastSize = str.Length % max;
        //    if (lastSize != 0)
        //        parts++;

        //    for (int i = 0; i < parts; i++)
        //    {
        //        if (i + 1 == parts)
        //        {
        //            String subStr = str.Substring(offset, lastSize);
        //            offset += lastSize;
        //            byte[] strData = StringToBytes(subStr, encoding);
        //            dataBuffer.Add(strData);
        //        }
        //        else
        //        {
        //            String subStr = str.Substring(offset, max);
        //            offset += max;
        //            byte[] strData = StringToBytes(subStr, encoding);
        //            dataBuffer.Add(strData);
        //        }
        //    }
        //    int size = 0;
        //    foreach (var item in dataBuffer)
        //    {
        //        size += item.Length;
        //    }
        //    byte[] array = new byte[size+parts*2];
        //    offset = 0;
        //    foreach (var item in dataBuffer)
        //    {
        //        Buffer.BlockCopy(ByteArythmetic.GetInt16Bytes((short)max,0), 0, array, offset, 2);
        //        offset += 2;
        //        Buffer.BlockCopy(item, 0, array, offset, item.Length);
        //        offset += item.Length;
        //    }
        //    return array;
        //}

        public static byte[] StoA(string str)
        {
            return StoA(str, ByteArythmetic.EncodingUtf16);
        }

        public static byte[] StoAUtf8(string str)
        {
            return StoA(str, ByteArythmetic.EncodingUtf8);
        }
    }
}

