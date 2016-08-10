using System.Windows;
using MediaInventory.Properties;
using TMDbLib.Client;
using System.Windows.Threading;
using System.Runtime.InteropServices;
using System;
using MediaInventory.UserControls;
using MediaInventory.Resources;

namespace MediaInventory
{
    public partial class App : Application
    {
        public static TMDbClient Client { get; private set; }
        public App()
        {
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Client = new TMDbClient(Settings.Default.TMDbAPIKey);
            Client.GetConfig();
            //Ticks for every two minutes
            timer.Interval = new TimeSpan(0, 2, 0);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        #region Timeout
        DispatcherTimer timer = new DispatcherTimer();
        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
        [StructLayout(LayoutKind.Sequential)]
        struct LASTINPUTINFO
        {
            public static readonly int SizeOf = Marshal.SizeOf(typeof(LASTINPUTINFO));
            [MarshalAs(UnmanagedType.U4)]
            public int cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public int dwTime;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            var win = (Current.MainWindow as Inventory);
            if (win == null)
                return;
            //If the user is idle for 300 seconds (5 minutes) disable the current MainWindow
            if (GetLastInputTime() >= 300 && !(win.ccMain.Content is Login))
            {
                var login = new Login();
                Globals.Default.CurrentUser = null;
                (Current.MainWindow as Inventory).ccMain.Content = login;
                (Current.MainWindow as Inventory).IsLoggedIn = false;
                (Current.MainWindow as Inventory).CurrentUserAndRole = null;
            }
        }
        //Returns the period of time the user is idle in seconds
        static int GetLastInputTime()
        {
            int idleTime = 0;
            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = Marshal.SizeOf(lastInputInfo);
            lastInputInfo.dwTime = 0;
            int envTicks = (int)Environment.TickCount;
            if (GetLastInputInfo(ref lastInputInfo))
            {
                int lastInputTick = lastInputInfo.dwTime;
                idleTime = envTicks - lastInputTick;
            }
            return ((idleTime > 0) ? (idleTime / 1000) : 0);
        }
        #endregion
    }
}