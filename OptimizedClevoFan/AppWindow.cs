using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OptimizedClevoFan
{
    public partial class AppWindow : Form
    {
        private FanController configuration = new FanController();

        private Timer timer;

        private FanController fanController;

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
            
            // Create & init fan controller
            this.fanController = new FanController();

            // Create timer for updating fan RPMs and so on
            timer = new Timer { Interval = fanController.updateFanStep };
            timer.Tick += new EventHandler(CheckFansTick);
            timer.Start();

            ///////////////////////////////////////////////////////////////////////////////////////////////
        }

        public void CheckFansTick(object sender, EventArgs e)
        {
            if (sender == timer)
            {
                this.fanController.DoUpdate(this.offsetTrackBar.Value);

                // LABELS
                this.cpuTempLabel.Text = this.fanController.fans[0].GetTemperature().ToString() + " C";
                this.gpuTempLabel.Text = this.fanController.fans[1].GetTemperature().ToString() + " C";


                this.cpuRpmLabel.Text = string.Format("{0:N2}% RPM", Math.Truncate(this.fanController.fans[0].GetLastRPM() * 10.0) / 10.0);
                this.gpuRpmLabel.Text = string.Format("{0:N2}% RPM", Math.Truncate(this.fanController.fans[1].GetLastRPM() * 10.0) / 10.0);
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
            timer.Stop();

            this.fanController.Finish();

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
