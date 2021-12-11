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
    public partial class FanInfo : UserControl
    {
        private Fan fan;

        public FanInfo(Fan fan)
        {
            InitializeComponent();
            this.fan = fan;
            this.groupBox.Text = this.fan.name;

            // Sliders
            for(int it = 0; it < this.fan.configuredRPMs.Length; it++)
            {
                this.temperatures.Controls.Add(new FanTemp(this.fan, it));
            }
        }

        public void UpdateInfos()
        {
            this.instantTemperature.Text = this.fan.GetTemperature().ToString() + " C";
            this.instantRPMs.Text = string.Format("{0:N2} %", Math.Truncate(this.fan.GetLastRPM() * 10.0) / 10.0);

            this.avgTemperature.Text = this.fan.GetAvgTemperature().ToString() + " C";
            this.maxTemperature.Text = this.fan.GetMaxTemperature().ToString() + " C";
        }
    }
}
