using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptimizedClevoFan
{
    public partial class AppWindow : Form
    {
        private Timer timer;

        private IFanControl fanControl;

        private List<FanControl> fans;

        public AppWindow()
        {
            InitializeComponent();
            this.CenterToScreen();

            this.Icon = Properties.Resources.Default;
            this.SystemTrayIcon.Icon = Properties.Resources.Default;

            // Change the Text property to the name of your application
            this.SystemTrayIcon.Text = "Optimized Clevo Fan";
            this.SystemTrayIcon.Visible = true;

            // Modify the right-click menu of your system tray icon here
            ContextMenu menu = new ContextMenu();
            menu.MenuItems.Add("Exit", ContextMenuExit);
            this.SystemTrayIcon.ContextMenu = menu;

            this.FormClosing += WindowClosing;

            ///////////////////////////////////////////////////////////////////////////////////////////////

            // Create timer for updating fan RPMs and so on
            timer = new Timer { Interval = 250 };
            timer.Tick += new EventHandler(CheckFansTick);
            timer.Start();

            // Create interface to communicate with fans & CPU temps
            fanControl = new ClevoEcInfo();

            fans = new List<FanControl>();

            // 0   1   2   3   4   5   6   7   8   9  10  11  12  13  14   15  16
            // 0   5  10  15  20  25  30  35  40  45  50  55  60  65  70   75  80
            int[] temps1 = new int[] { 25, 25, 25, 25, 25, 25, 35, 40, 40, 40, 50, 60, 70, 80, 90, 100, 100 };
            FanControl fanControl1 = new FanControl(fanControl, 1);
            fanControl1.LoadTemps(temps1);
            fans.Add(fanControl1);

            // 0   1   2   3   4   5   6   7   8   9  10  11  12  13   14   15   16
            // 0   5  10  15  20  25  30  35  40  45  50  55  60  65   70   75   80
            int[] temps2 = new int[] { 25, 25, 25, 25, 35, 35, 35, 35, 40, 50, 60, 70, 80, 90, 100, 100, 100 };
            FanControl fanControl2 = new FanControl(fanControl, 2);
            fanControl2.LoadTemps(temps2);
            fans.Add(fanControl2);

            ///////////////////////////////////////////////////////////////////////////////////////////////
        }

        public void CheckFansTick(object sender, EventArgs e)
        {
            if (sender == timer)
            {
                const int OFFSET = 25;

                int maxOfAllFans = 0;
                foreach (FanControl fan in this.fans)
                {
                    fan.UpdateTemp();
                    fan.CalculateFanRPM(OFFSET);
                    maxOfAllFans = Math.Max(maxOfAllFans, fan.GetCalculatedFanRPM());
                }

                // if one of the fans is at more than 100% then I set all the fans at 100%
                int minimumFanRPM = (int)((double)maxOfAllFans * 0.80);
                if (maxOfAllFans >= 100)
                    minimumFanRPM = 100;

                foreach (FanControl fan in this.fans)
                    fan.SetFanRPM(minimumFanRPM);
            }
        }

        private void SystemTrayIconDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible)
                this.Hide();
            else
                this.Show();
        }

        private void ContextMenuExit(object sender, EventArgs e)
        {
            // Stop timer
            timer.Stop();

            // Set default fan RPMs
            foreach (FanControl fan in this.fans)
                fanControl.SetFansAuto(fan.GetFanNumber());

            // Delete interface for communicating with fans & CPU temps

            this.SystemTrayIcon.Visible = false;
            Application.Exit();
            Environment.Exit(0);
        }

        private void WindowClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
