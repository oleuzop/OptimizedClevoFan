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

        private List<FanInfo> fanInfos;

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
            // Add infos
            this.step.Text = this.fanController.updateFanStep.ToString() + " ms";

            fanInfos = new List<FanInfo>();
            foreach (Fan fan in this.fanController.fans)
            {
                FanInfo fanInfo = new FanInfo(fan);
                this.panelFanInfos.Controls.Add(fanInfo);
                this.fanInfos.Add(fanInfo);
            }
        }

        public void CheckFansTick(object sender, EventArgs e)
        {
            if (sender == timer)
            {
                this.fanController.DoUpdate(this.offsetTrackBar.Value);

                foreach( FanInfo fanInfo in this.fanInfos)
                    fanInfo.UpdateInfos();
            }
        }

        private void SystemTrayIconDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible)
                this.Hide();
            else
            {
                this.WindowState = FormWindowState.Minimized;
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
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

        private void offsetTrackBar_Scroll(object sender, EventArgs e)
        {
            this.offsetValue.Text = this.offsetTrackBar.Value.ToString() + " %";
        }
    }
}
