using System.Diagnostics.CodeAnalysis;
using System.Net;
using UDPServerLibrary;
using UDPServerLibrary.Model;
using UDPServerLibrary.Utils;

namespace ScreenShare.UI
{
    public partial class ScreenReceiverForm : Form
    {
        private readonly IEncoder Encoder = new Encoder(System.Text.Encoding.UTF8);
        private UdpListener? ScreenGetter;

        private readonly ToolStripMenuItem TsmiListen;
        private readonly ToolStripMenuItem TsmiStop;

        private int ExpectedTotalPackets = -1;
        private List<ScreenPacket> PacketBuffer = [];
        private Image? LatestReceivedData = null;

        private bool[]? ReceivedPacketFlags = null;
        private int ReceivedPacketsCount;

        public ScreenReceiverForm()
        {
            InitializeComponent();

            TsmiListen = new("Listen", null, Listen_Click) { Enabled = true };
            TsmiStop = new("Stop", null, Stop_Click) { Enabled = false };
            ContextMenuStrip = new()
            {
                Items = { TsmiListen, TsmiStop }
            };
        }

        private async void Listen_Click(object? sender, EventArgs e)
        {
            DisableTSMI();
            await InitScreenGetter();
            _ = ScreenGetter.StartListening(Program.PORT);
            UpdateTSMI(listening: true);
        }

        private void Stop_Click(object? sender, EventArgs e)
        {
            DisableTSMI();
            ScreenGetter?.StopListening();

            ClearBufferAndData();

            UpdateTSMI(listening: false);
            Refresh();
        }

        private void ClearBufferAndData()
        {
            PacketBuffer.Clear();
            ExpectedTotalPackets = -1;
            LatestReceivedData?.Dispose();
            LatestReceivedData = null;
            ReceivedPacketFlags = null;
            ReceivedPacketsCount = 0;
        }

        [MemberNotNull(nameof(ScreenGetter))]
        private async Task InitScreenGetter()
        {
            if (ScreenGetter != null)
            {
                await ScreenGetter.StopListening();
            }

            ScreenGetter = new UdpListener(Encoder);
            ScreenGetter.MessageReceived += ScreenGetter_MessageReceived;
        }

        private void UpdateTSMI(bool listening)
        {
            TsmiListen.Enabled = !listening;
            TsmiStop.Enabled = listening;
        }

        private void DisableTSMI()
        {
            TsmiListen.Enabled = false;
            TsmiStop.Enabled = false;
        }

        private void ScreenGetter_MessageReceived(IPEndPoint sender, byte[] data)
        {
            ScreenPacket packet = ScreenPacket.Deserialize(data);

            if (ExpectedTotalPackets == -1)
            {
                ExpectedTotalPackets = packet.TotalPackets;
                ReceivedPacketFlags = new bool[ExpectedTotalPackets];
            }

            if (ReceivedPacketFlags[packet.SequenceNumber] == false)
            {
                PacketBuffer.Add(packet);
                ReceivedPacketFlags[packet.SequenceNumber] = true;
                ReceivedPacketsCount++;

                if (ExpectedTotalPackets == -1)
                {
                    ExpectedTotalPackets = packet.TotalPackets;
                    ReceivedPacketFlags = new bool[ExpectedTotalPackets];
                }

                if (ReceivedPacketsCount == ExpectedTotalPackets)
                {
                    ProcessBufferedPackets();
                }
            }
        }

        /*private void ProcessBufferedPackets()
        {
            if (PacketBuffer.Select(p => p.SequenceNumber).SequenceEqual(Enumerable.Range(0, ExpectedTotalPackets)))
            {
                using MemoryStream ms = new();

                foreach (ScreenPacket packet in PacketBuffer.OrderBy(p => p.SequenceNumber))
                {
                    ms.Write(packet.Data, 0, packet.Data.Length);
                }

                ClearBufferAndData();

                ms.Position = 0;
                LatestReceivedData = Image.FromStream(ms);
                Refresh();
            }
        }*/

        private void ProcessBufferedPackets()
        {
            bool[] receivedPackets = new bool[ExpectedTotalPackets];
            int receivedCount = 0;

            foreach (var packet in PacketBuffer)
            {
                if (!receivedPackets[packet.SequenceNumber])
                {
                    receivedPackets[packet.SequenceNumber] = true;
                    receivedCount++;
                }
            }

            if (receivedCount == ExpectedTotalPackets && receivedPackets.All(p => p))
            {
                using var ms = new MemoryStream(new byte[PacketBuffer.Sum(p => p.Data.Length)]);
                int currentPosition = 0;

                for (int i = 0; i < ExpectedTotalPackets; i++)
                {
                    if (receivedPackets[i])
                    {
                        var packet = PacketBuffer.First(p => p.SequenceNumber == i);
                        ms.Write(packet.Data, 0, packet.Data.Length);
                        currentPosition += packet.Data.Length;
                    }
                }

                ClearBufferAndData();

                ms.Position = 0;
                LatestReceivedData = Image.FromStream(ms);
                Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (LatestReceivedData == null)
            {
                e.Graphics.Clear(Color.Black);
                return;
            }

            e.Graphics.DrawImage(LatestReceivedData, 0, 0, Width, Height);
        }
    }
}
