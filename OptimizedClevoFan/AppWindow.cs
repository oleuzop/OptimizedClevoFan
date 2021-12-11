using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OptimizedClevoFan
{
    public partial class AppWindow : Form
    {
        private Timer timer;

        private IFanControl fanControl;

        private List<Fan> fans;

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
            fanControl = new FanControl();

            fans = new List<Fan>();

                                     // 0   1   2   3   4   5   6   7   8   9  10  11  12  13  14   15  16
                                     // 0   5  10  15  20  25  30  35  40  45  50  55  60  65  70   75  80
            int[] temps1 = new int[] { 25, 25, 25, 25, 25, 25, 35, 40, 40, 40, 40, 50, 65, 80, 95, 100, 100 };
            Fan fanControl1 = new Fan(fanControl, 1);
            fanControl1.LoadTemps(temps1);
            fans.Add(fanControl1);

                                     // 0   1   2   3   4   5   6   7   8   9  10  11  12  13   14   15   16
                                     // 0   5  10  15  20  25  30  35  40  45  50  55  60  65   70   75   80
            int[] temps2 = new int[] { 25, 25, 25, 25, 35, 35, 35, 35, 35, 45, 55, 70, 85, 100, 100, 100, 100 };
            Fan fanControl2 = new Fan(fanControl, 2);
            fanControl2.LoadTemps(temps2);
            fans.Add(fanControl2);

            ///////////////////////////////////////////////////////////////////////////////////////////////
        }

        public void CheckFansTick(object sender, EventArgs e)
        {
            if (sender == timer)
            {
                int maxOfAllFans = 0;
                foreach (Fan fan in this.fans)
                {
                    fan.UpdateAvgTemperature();
                    fan.CalculateDesiredRPM(this.offsetTrackBar.Value);
                    maxOfAllFans = Math.Max(maxOfAllFans, fan.GetDesiredRPM());
                }

                // set all fans to 80% of the one that is running faster (at more RPMs)
                int minimumFanRPM = (int)((double)maxOfAllFans * 0.80);
                // if one of the fans is at more than 100% then I set all the fans at 100%
                if (maxOfAllFans >= 100)
                    minimumFanRPM = 100;

                foreach (Fan fan in this.fans)
                    fan.SetFanRPM(minimumFanRPM);


                // LABELS
                this.cpuTempLabel.Text = this.fans[0].GetTemperature().ToString() + "º C";
                this.gpuTempLabel.Text = this.fans[1].GetTemperature().ToString() + "º C";

                
                this.cpuRpmLabel.Text = string.Format("{0:N2}% RPM", Math.Truncate(this.fans[0].GetLastRPM() * 10.0) / 10.0);
                this.gpuRpmLabel.Text = string.Format("{0:N2}% RPM", Math.Truncate(this.fans[1].GetLastRPM() * 10.0) / 10.0);
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
            foreach (Fan fan in this.fans)
                fanControl.SetFansAuto(fan.GetFanNumber());

            // Delete interface for communicating with fans & CPU temps
            fanControl.Dispose();

            this.SystemTrayIcon.Visible = false;
            Application.Exit();
            Environment.Exit(0);
        }

        private void WindowClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void offsetTrackBar_Scroll(object sender, EventArgs e)
        {

        }
    }
}
