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
        }

        public void CheckFansTick(object sender, EventArgs e)
        {
            if (sender == timer)
            {
                // do something here
                int i = 10 + 3;
                i = i + 2;
            }
        }

        private void SystemTrayIconDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible)
            {
                this.Hide();
            }
            else
            {
                this.Show();
            }
        }

        private void ContextMenuExit(object sender, EventArgs e)
        {
            // Stop timer
            timer.Stop();

            // Set default fan RPMs

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
