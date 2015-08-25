using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Vitt.Andre.Tunnel
{
    public class Utils
    {

        delegate void SetTextDelegate(Control control, String data);

        public static void ExecuteThreadSafe(Control control, String data)
        {
            if (control.InvokeRequired)
            {
                try
                {
                    control.Invoke(new SetTextDelegate(ExecuteThreadSafe), new object[] { control, data });
                }
                catch
                {
                    //...
                }
            }
            else
            {
                control.Text += data + Environment.NewLine;
            }
        }

        public static void ExecuteThreadSafe(Control host, ToolStripProgressBar control, int value)
        {
            if (host.InvokeRequired)
            {
                host.Invoke(new SetTextDelegate(ExecuteThreadSafe), new object[] { control, value });
            }
            else
            {
                if (value <= control.Maximum && value >= control.Minimum)
                {
                    control.Value = value;
                }
            }
        }


        public static String ByteArrayToHex(Byte[] data)
        {
            return BitConverter.ToString(data).Replace("-", string.Empty);
        }

        public static byte[] CutBytes(Byte[] data, int bytes)
        {
            return CutBytes(data, bytes, 0);
        }

        public static byte[] CutBytes(Byte[] data,int bytes,int index)
        {
            byte[] value = new byte[bytes];
            Array.Copy(data, value, bytes);
            return value;
        }

        public static bool IsString(Byte[] data)
        {
            byte firstByte = data[0];            

            if (firstByte == 0x03) // Chat
            {
                return true;
            }
            return false;
        }

        public static bool IsAuth(Byte[] data)
        {
            byte firstByte = data[0];

            if (firstByte == 0x02) // Auth
            {
                return true;
            }
            return false;
        }

        public static int GetBigEndianIntegerFromByteArray(byte[] data, int startIndex)
        {
            return (data[startIndex] << 24)
                 | (data[startIndex + 1] << 16)
                 | (data[startIndex + 2] << 8)
                 | data[startIndex + 3];
        }

        public static int GetLittleEndianIntegerFromByteArray(byte[] data, int startIndex)
        {
            return (data[startIndex + 3] << 24)
                 | (data[startIndex + 2] << 16)
                 | (data[startIndex + 1] << 8)
                 | data[startIndex];
        }

        public static short GetShort(byte[] arr, int start)
        {
            try
            {
               return BitConverter.ToInt16(new byte[] { arr[start + 1], arr[start] }, 0);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //public static String GetString(Byte[] data)
        //{
        //    try
        //    {
        //        short s = Utils.GetShort(data, 1);

        //        try
        //        {
        //            return ByteArythmetic.EncodingUtf16.GetString(data, 3, s);
        //        }
        //        catch
        //        {
                    
        //        }
        //    }
        //    catch
        //    {
                
        //    }
        //    return String.Empty;
        //}
    }
}
