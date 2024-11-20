using ScreenShare.Utils;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net;
using UDPServerLibrary;
using UDPServerLibrary.Model;

using Encoder = UDPServerLibrary.Utils.Encoder;

namespace ScreenShare
{
    public partial class ScreenSharerForm : Form
    {
        private readonly IEncoder Encoder = new Encoder(System.Text.Encoding.UTF8);
        private UdpMessageSender? ScreenSharer;
        CancellationTokenSource? CTS;

        private int FPS = 15;
        private ScreenShareMode ScreenShareMode = ScreenShareMode.BandwidthSaving;
        private Size TargetResolution = new(1280, 720);

        public ScreenSharerForm()
        {
            InitializeComponent();
        }

        private void TxtIP_TextChanged(object sender, EventArgs e) =>
            SetControlEnabledState(btnStartShare, IPAddress.TryParse(txtIP.Text, out _));

        private void BtnStartShare_Click(object sender, EventArgs e)
        {
            SetControlStates(isSharing: true);
            Task.Run(() => ShareScreen(ScreenShareMode, FPS, TargetResolution));
        }

        private void BtnStopShare_Click(object sender, EventArgs e)
        {
            SetControlStates(isSharing: false);
            CTS?.Cancel();
        }

        private void SetControlStates(bool isSharing)
        {
            SetControlEnabledState(btnStartShare, !isSharing);
            SetControlEnabledState(btnStopShare, isSharing);
            SetControlEnabledState(txtIP, !isSharing);
        }
        private void SetControlEnabledState(Control control, bool enabled) => control.Enabled = enabled;

        private async Task ShareScreen(ScreenShareMode scrShareMode, int fps, Size targetResolution)
        {
            RefreshCTS();
            ScreenSharer?.Dispose();
            ScreenSharer = new UdpMessageSender(Encoder);
            IPEndPoint endPoint = new(IPAddress.Parse(txtIP.Text), Program.PORT);
            const int MaxUdpPacketSize = 4096;
            int delay = (int)MathF.Round(1000f / fps);

            if (Screen.PrimaryScreen is not { } screen)
            {
                Debug.WriteLine("ERROR: Screen is null");
                CTS.Cancel();
                return;
            }

            ImageFormat format = scrShareMode == ScreenShareMode.BandwidthSaving ? ImageFormat.Jpeg : ImageFormat.Png;

            try
            {
                using Bitmap screenShot = new(screen.Bounds.Width, screen.Bounds.Height);
                using Bitmap compressedImage = new(targetResolution.Width, targetResolution.Height);
                using Graphics g = Graphics.FromImage(screenShot);
                using Graphics gCompressed = Graphics.FromImage(compressedImage);
                using MemoryStream ms = new();

                gCompressed.InterpolationMode = InterpolationMode.HighQualityBicubic;

                while (!CTS.IsCancellationRequested)
                {
                    g.CopyFromScreen(screen.Bounds.X, screen.Bounds.Y, 0, 0, screen.Bounds.Size);
                    gCompressed.DrawImage(screenShot, 0, 0, targetResolution.Width, targetResolution.Height);

                    ms.SetLength(0);
                    compressedImage.Save(ms, format);

                    byte[] imageData = ms.ToArray();
                    int totalPackets = (imageData.Length + MaxUdpPacketSize - 1) / MaxUdpPacketSize;

                    Debug.WriteLine($"Total Packets: {totalPackets}");

                    for (int i = 0; i < totalPackets; i++)
                    {
                        bool isLastPacket = i == totalPackets - 1;
                        byte[] chunk = imageData.AsSpan(i * MaxUdpPacketSize, Math.Min(MaxUdpPacketSize, imageData.Length - i * MaxUdpPacketSize)).ToArray();

                        ScreenPacket packet = new(i, isLastPacket,totalPackets, chunk);
                        await ScreenSharer.SendMessage(endPoint, packet.Serialize(), CTS.Token).ConfigureAwait(false);
                    }
                    await Task.Delay(delay, CTS.Token).ConfigureAwait(false);
                }
            }
            catch (OperationCanceledException)
            {
                Debug.WriteLine("Screen sharing stopped.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR: {ex.Message}");
            }
        }

        [MemberNotNull(nameof(CTS))]
        private void RefreshCTS()
        {
            CTS?.Dispose();
            CTS = new();
        }

        private void CmbQualityMode_SelectedIndexChanged(object sender, EventArgs e) => ScreenShareMode = (ScreenShareMode)cmbQualityMode.SelectedIndex;
        private void NumFPS_ValueChanged(object sender, EventArgs e) 
        {
            numFPS.Value = Mathi.Clamp((int)numFPS.Value, 1, 120);
            FPS = (int)numFPS.Value;
        }
        private void SbTargetRes_ValueChanged(object sender, EventArgs e) => TargetResolution = sbTargetRes.Value;
    }
}