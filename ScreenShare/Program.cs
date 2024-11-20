using ScreenShare.UI;

namespace ScreenShare
{
    internal static class Program
    {
        public const int PORT = 23415;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            new ScreenSharerForm().Show();
            Application.Run(new ScreenReceiverForm());
        }
    }
}