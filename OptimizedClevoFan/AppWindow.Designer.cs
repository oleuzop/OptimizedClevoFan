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
            this.offsetValue = new System.Windows.Forms.Label();
            this.panelFanInfos = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxOffset = new System.Windows.Forms.GroupBox();
            this.stepLbl = new System.Windows.Forms.Label();
            this.groupBoxGeneralInfos = new System.Windows.Forms.GroupBox();
            this.step = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.offsetTrackBar)).BeginInit();
            this.groupBoxOffset.SuspendLayout();
            this.groupBoxGeneralInfos.SuspendLayout();
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
            this.offsetTrackBar.Location = new System.Drawing.Point(6, 24);
            this.offsetTrackBar.Maximum = 25;
            this.offsetTrackBar.Name = "offsetTrackBar";
            this.offsetTrackBar.Size = new System.Drawing.Size(260, 45);
            this.offsetTrackBar.TabIndex = 0;
            this.offsetTrackBar.Scroll += new System.EventHandler(this.offsetTrackBar_Scroll);
            // 
            // offsetValue
            // 
            this.offsetValue.AutoSize = true;
            this.offsetValue.Location = new System.Drawing.Point(280, 28);
            this.offsetValue.Name = "offsetValue";
            this.offsetValue.Size = new System.Drawing.Size(24, 13);
            this.offsetValue.TabIndex = 1;
            this.offsetValue.Text = "0 %";
            // 
            // panelFanInfos
            // 
            this.panelFanInfos.AutoScroll = true;
            this.panelFanInfos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelFanInfos.Location = new System.Drawing.Point(6, 93);
            this.panelFanInfos.Name = "panelFanInfos";
            this.panelFanInfos.Size = new System.Drawing.Size(542, 563);
            this.panelFanInfos.TabIndex = 6;
            this.panelFanInfos.WrapContents = false;
            // 
            // groupBoxOffset
            // 
            this.groupBoxOffset.Controls.Add(this.offsetTrackBar);
            this.groupBoxOffset.Controls.Add(this.offsetValue);
            this.groupBoxOffset.Location = new System.Drawing.Point(13, 11);
            this.groupBoxOffset.Name = "groupBoxOffset";
            this.groupBoxOffset.Size = new System.Drawing.Size(331, 76);
            this.groupBoxOffset.TabIndex = 7;
            this.groupBoxOffset.TabStop = false;
            this.groupBoxOffset.Text = "Fan Offset";
            // 
            // stepLbl
            // 
            this.stepLbl.AutoSize = true;
            this.stepLbl.Location = new System.Drawing.Point(13, 24);
            this.stepLbl.Name = "stepLbl";
            this.stepLbl.Size = new System.Drawing.Size(32, 13);
            this.stepLbl.TabIndex = 8;
            this.stepLbl.Text = "Step:";
            // 
            // groupBoxGeneralInfos
            // 
            this.groupBoxGeneralInfos.Controls.Add(this.step);
            this.groupBoxGeneralInfos.Controls.Add(this.stepLbl);
            this.groupBoxGeneralInfos.Location = new System.Drawing.Point(351, 11);
            this.groupBoxGeneralInfos.Name = "groupBoxGeneralInfos";
            this.groupBoxGeneralInfos.Size = new System.Drawing.Size(159, 76);
            this.groupBoxGeneralInfos.TabIndex = 9;
            this.groupBoxGeneralInfos.TabStop = false;
            this.groupBoxGeneralInfos.Text = "General Info";
            // 
            // step
            // 
            this.step.AutoSize = true;
            this.step.Location = new System.Drawing.Point(51, 24);
            this.step.Name = "step";
            this.step.Size = new System.Drawing.Size(41, 13);
            this.step.TabIndex = 9;
            this.step.Text = "250 ms";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 662);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // AppWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 697);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBoxGeneralInfos);
            this.Controls.Add(this.groupBoxOffset);
            this.Controls.Add(this.panelFanInfos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppWindow";
            ((System.ComponentModel.ISupportInitialize)(this.offsetTrackBar)).EndInit();
            this.groupBoxOffset.ResumeLayout(false);
            this.groupBoxOffset.PerformLayout();
            this.groupBoxGeneralInfos.ResumeLayout(false);
            this.groupBoxGeneralInfos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon SystemTrayIcon;
        private System.Windows.Forms.TrackBar offsetTrackBar;
        private System.Windows.Forms.Label offsetValue;
        private System.Windows.Forms.FlowLayoutPanel panelFanInfos;
        private System.Windows.Forms.GroupBox groupBoxOffset;
        private System.Windows.Forms.Label stepLbl;
        private System.Windows.Forms.GroupBox groupBoxGeneralInfos;
        private System.Windows.Forms.Label step;
        private System.Windows.Forms.Button button1;
    }
}

