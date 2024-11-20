using System.Buffers.Binary;

namespace ScreenShare
{
    internal class ScreenPacket
    {
        public int SequenceNumber { get; set; }
        public bool IsLastPacket { get; set; }
        public int TotalPackets { get; set; }
        public byte[] Data { get; set; }

        public ScreenPacket(int sequenceNumber, bool isLastPacket, int totalPackets, byte[] data)
        {
            SequenceNumber = sequenceNumber;
            IsLastPacket = isLastPacket;
            TotalPackets = totalPackets;
            Data = data;
        }

        public byte[] Serialize()
        {
            int packetSize = 13 + Data.Length;
            byte[] buffer = new byte[packetSize];

            BinaryPrimitives.WriteInt32LittleEndian(buffer.AsSpan(0, 4), SequenceNumber);
            buffer[4] = (byte)(IsLastPacket ? 1 : 0);
            BinaryPrimitives.WriteInt32LittleEndian(buffer.AsSpan(5, 4), TotalPackets);
            BinaryPrimitives.WriteInt32LittleEndian(buffer.AsSpan(9, 4), Data.Length);
            Data.CopyTo(buffer, 13);

            return buffer;
        }

        public static ScreenPacket Deserialize(byte[] packetData)
        {
            int sequenceNumber = BinaryPrimitives.ReadInt32LittleEndian(packetData.AsSpan(0, 4));
            bool isLastPacket = packetData[4] == 1;
            int totalPackets = BinaryPrimitives.ReadInt32LittleEndian(packetData.AsSpan(5, 4));
            int dataLength = BinaryPrimitives.ReadInt32LittleEndian(packetData.AsSpan(9, 4));
            byte[] data = packetData.AsSpan(13, dataLength).ToArray();

            return new ScreenPacket(sequenceNumber, isLastPacket, totalPackets, data);
        }
    }
}
