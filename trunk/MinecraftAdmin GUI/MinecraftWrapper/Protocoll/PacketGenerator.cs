using System;
using System.Collections.Generic;
using System.Text;
using Vitt.Andre.Tunnel;
using Vitt.Andre.TCPTunnelLib.Vitt.Andre.Tunnel;

namespace MinecraftWrapper.Protocoll
{
    public class PacketGenerator
    {
        public PacketGenerator()
        {
            bytes = new List<byte>();
        }

        public PacketGenerator(int size)
        {
            bytes = new List<byte>(size);
        }

        public PacketGenerator(IEnumerable<Byte> collection)
        {
            bytes = new List<byte>(collection);
        }

        List<byte> bytes;

        public List<byte> Bytes
        {
            get { return bytes; }
            set { bytes = value; }
        }

        public void Add(PacketBytes value)
        {
            Add((byte)value);
        }

        public void Add(Int64 value)
        {
            bytes.AddRange(ByteArythmetic.GetInt64Bytes(value, 0));
        }

        public void Add(Int32 value)
        {
            bytes.AddRange(ByteArythmetic.GetInt32Bytes(value, 0));
        }

        public void Add(Int16 value)
        {
            bytes.AddRange(ByteArythmetic.GetInt16Bytes(value, 0));
        }

        public void Add(Byte value)
        {
            bytes.Add(value);
        }

        public void Add(Boolean value)
        {
            bytes.AddRange(ByteArythmetic.GetBooleanBytes(value, 0));
        }

        public void Add(Single value)
        {
            bytes.AddRange(ByteArythmetic.GetFloatBytes(value, 0));
        }

        public void Add(Double value)
        {
            bytes.AddRange(ByteArythmetic.GetDoubleBytes(value, 0));
        }

        public void Add(String value)
        {
            bytes.AddRange(ByteArythmetic.StoA(value));
        }

        public byte[] ToByteArray()
        {
            return bytes.ToArray();
        }
    }
}
