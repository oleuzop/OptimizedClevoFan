namespace OptimizedClevoFan
{
    partial class AppWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SystemTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.offsetTrackBar = new System.Windows.Forms.TrackBar();
            this.cpuTempLabel = new System.Windows.Forms.Label();
            this.gpuTempLabel = new System.Windows.Forms.Label();
            this.cpuRpmLabel = new System.Windows.Forms.Label();
            this.gpuRpmLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.offsetTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // SystemTrayIcon
            // 
            this.SystemTrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.SystemTrayIcon.Visible = true;
            this.SystemTrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SystemTrayIconDoubleClick);
            // 
            // offsetTrackBar
            // 
            this.offsetTrackBar.Location = new System.Drawing.Point(12, 13);
            this.offsetTrackBar.Maximum = 25;
            this.offsetTrackBar.Name = "offsetTrackBar";
            this.offsetTrackBar.Size = new System.Drawing.Size(260, 45);
            this.offsetTrackBar.TabIndex = 0;
            // 
            // cpuTempLabel
            // 
            this.cpuTempLabel.AutoSize = true;
            this.cpuTempLabel.Location = new System.Drawing.Point(12, 61);
            this.cpuTempLabel.Name = "cpuTempLabel";
            this.cpuTempLabel.Size = new System.Drawing.Size(35, 13);
            this.cpuTempLabel.TabIndex = 1;
            this.cpuTempLabel.Text = "label1";
            // 
            // gpuTempLabel
            // 
            this.gpuTempLabel.AutoSize = true;
            this.gpuTempLabel.Location = new System.Drawing.Point(12, 88);
            this.gpuTempLabel.Name = "gpuTempLabel";
            this.gpuTempLabel.Size = new System.Drawing.Size(35, 13);
            this.gpuTempLabel.TabIndex = 2;
            this.gpuTempLabel.Text = "label1";
            // 
            // cpuRpmLabel
            // 
            this.cpuRpmLabel.AutoSize = true;
            this.cpuRpmLabel.Location = new System.Drawing.Point(158, 61);
            this.cpuRpmLabel.Name = "cpuRpmLabel";
            this.cpuRpmLabel.Size = new System.Drawing.Size(35, 13);
            this.cpuRpmLabel.TabIndex = 3;
            this.cpuRpmLabel.Text = "label1";
            // 
            // gpuRpmLabel
            // 
            this.gpuRpmLabel.AutoSize = true;
            this.gpuRpmLabel.Location = new System.Drawing.Point(158, 88);
            this.gpuRpmLabel.Name = "gpuRpmLabel";
            this.gpuRpmLabel.Size = new System.Drawing.Size(35, 13);
            this.gpuRpmLabel.TabIndex = 4;
            this.gpuRpmLabel.Text = "label1";
            // 
            // AppWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.gpuRpmLabel);
            this.Controls.Add(this.cpuRpmLabel);
            this.Controls.Add(this.gpuTempLabel);
            this.Controls.Add(this.cpuTempLabel);
            this.Controls.Add(this.offsetTrackBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppWindow";
            ((System.ComponentModel.ISupportInitialize)(this.offsetTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon SystemTrayIcon;
        private System.Windows.Forms.TrackBar offsetTrackBar;
        private System.Windows.Forms.Label cpuTempLabel;
        private System.Windows.Forms.Label gpuTempLabel;
        private System.Windows.Forms.Label cpuRpmLabel;
        private System.Windows.Forms.Label gpuRpmLabel;
    }
}

