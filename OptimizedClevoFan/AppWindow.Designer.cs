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
            this.buttonSave = new System.Windows.Forms.Button();
            this.checkBoxStartWithWindows = new System.Windows.Forms.CheckBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
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
            this.offsetTrackBar.AutoSize = false;
            this.offsetTrackBar.Location = new System.Drawing.Point(6, 16);
            this.offsetTrackBar.Maximum = 25;
            this.offsetTrackBar.Name = "offsetTrackBar";
            this.offsetTrackBar.Size = new System.Drawing.Size(188, 34);
            this.offsetTrackBar.TabIndex = 0;
            this.offsetTrackBar.Scroll += new System.EventHandler(this.offsetTrackBar_Scroll);
            // 
            // offsetValue
            // 
            this.offsetValue.AutoSize = true;
            this.offsetValue.Location = new System.Drawing.Point(195, 20);
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
            this.panelFanInfos.Size = new System.Drawing.Size(542, 523);
            this.panelFanInfos.TabIndex = 6;
            this.panelFanInfos.WrapContents = false;
            // 
            // groupBoxOffset
            // 
            this.groupBoxOffset.Controls.Add(this.offsetTrackBar);
            this.groupBoxOffset.Controls.Add(this.offsetValue);
            this.groupBoxOffset.Location = new System.Drawing.Point(290, 10);
            this.groupBoxOffset.Name = "groupBoxOffset";
            this.groupBoxOffset.Size = new System.Drawing.Size(233, 56);
            this.groupBoxOffset.TabIndex = 7;
            this.groupBoxOffset.TabStop = false;
            this.groupBoxOffset.Text = "Fan extra RPM %";
            // 
            // stepLbl
            // 
            this.stepLbl.AutoSize = true;
            this.stepLbl.Location = new System.Drawing.Point(7, 16);
            this.stepLbl.Name = "stepLbl";
            this.stepLbl.Size = new System.Drawing.Size(32, 13);
            this.stepLbl.TabIndex = 8;
            this.stepLbl.Text = "Step:";
            // 
            // groupBoxGeneralInfos
            // 
            this.groupBoxGeneralInfos.Controls.Add(this.step);
            this.groupBoxGeneralInfos.Controls.Add(this.stepLbl);
            this.groupBoxGeneralInfos.Location = new System.Drawing.Point(12, 10);
            this.groupBoxGeneralInfos.Name = "groupBoxGeneralInfos";
            this.groupBoxGeneralInfos.Size = new System.Drawing.Size(275, 76);
            this.groupBoxGeneralInfos.TabIndex = 9;
            this.groupBoxGeneralInfos.TabStop = false;
            this.groupBoxGeneralInfos.Text = "General Info";
            // 
            // step
            // 
            this.step.AutoSize = true;
            this.step.Location = new System.Drawing.Point(45, 16);
            this.step.Name = "step";
            this.step.Size = new System.Drawing.Size(41, 13);
            this.step.TabIndex = 9;
            this.step.Text = "250 ms";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 622);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(166, 23);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Save Configuration";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // checkBoxStartWithWindows
            // 
            this.checkBoxStartWithWindows.AutoSize = true;
            this.checkBoxStartWithWindows.Location = new System.Drawing.Point(290, 69);
            this.checkBoxStartWithWindows.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxStartWithWindows.Name = "checkBoxStartWithWindows";
            this.checkBoxStartWithWindows.Size = new System.Drawing.Size(117, 17);
            this.checkBoxStartWithWindows.TabIndex = 10;
            this.checkBoxStartWithWindows.Text = "Start with Windows";
            this.checkBoxStartWithWindows.UseVisualStyleBackColor = true;
            this.checkBoxStartWithWindows.CheckedChanged += new System.EventHandler(this.checkBoxStartWithWindows_CheckedChanged);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(356, 622);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(167, 23);
            this.buttonExit.TabIndex = 11;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(184, 622);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(166, 23);
            this.buttonClose.TabIndex = 12;
            this.buttonClose.Text = "Close Window";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // AppWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 653);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.checkBoxStartWithWindows);
            this.Controls.Add(this.buttonSave);
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
            this.PerformLayout();

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
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox checkBoxStartWithWindows;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonClose;
    }
}

