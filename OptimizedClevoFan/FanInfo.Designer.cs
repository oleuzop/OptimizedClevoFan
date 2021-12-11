namespace OptimizedClevoFan
{
    partial class FanInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.instantTemperatureLbl = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.maxTemperature = new System.Windows.Forms.Label();
            this.maxTemperatureLbl = new System.Windows.Forms.Label();
            this.avgTemperature = new System.Windows.Forms.Label();
            this.avgTemperatureLbl = new System.Windows.Forms.Label();
            this.instantRPMs = new System.Windows.Forms.Label();
            this.instantRPMsLbl = new System.Windows.Forms.Label();
            this.instantTemperature = new System.Windows.Forms.Label();
            this.temperatures = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // instantTemperatureLbl
            // 
            this.instantTemperatureLbl.AutoSize = true;
            this.instantTemperatureLbl.Location = new System.Drawing.Point(6, 19);
            this.instantTemperatureLbl.Name = "instantTemperatureLbl";
            this.instantTemperatureLbl.Size = new System.Drawing.Size(101, 13);
            this.instantTemperatureLbl.TabIndex = 0;
            this.instantTemperatureLbl.Text = "Instant temperature:";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.temperatures);
            this.groupBox.Controls.Add(this.maxTemperature);
            this.groupBox.Controls.Add(this.maxTemperatureLbl);
            this.groupBox.Controls.Add(this.avgTemperature);
            this.groupBox.Controls.Add(this.avgTemperatureLbl);
            this.groupBox.Controls.Add(this.instantRPMs);
            this.groupBox.Controls.Add(this.instantRPMsLbl);
            this.groupBox.Controls.Add(this.instantTemperature);
            this.groupBox.Controls.Add(this.instantTemperatureLbl);
            this.groupBox.Location = new System.Drawing.Point(3, 3);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(509, 244);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "FanName";
            // 
            // maxTemperature
            // 
            this.maxTemperature.AutoSize = true;
            this.maxTemperature.Location = new System.Drawing.Point(308, 34);
            this.maxTemperature.Name = "maxTemperature";
            this.maxTemperature.Size = new System.Drawing.Size(29, 13);
            this.maxTemperature.TabIndex = 7;
            this.maxTemperature.Text = "40 C";
            // 
            // maxTemperatureLbl
            // 
            this.maxTemperatureLbl.AutoSize = true;
            this.maxTemperatureLbl.Location = new System.Drawing.Point(201, 34);
            this.maxTemperatureLbl.Name = "maxTemperatureLbl";
            this.maxTemperatureLbl.Size = new System.Drawing.Size(89, 13);
            this.maxTemperatureLbl.TabIndex = 6;
            this.maxTemperatureLbl.Text = "Max temperature:";
            // 
            // avgTemperature
            // 
            this.avgTemperature.AutoSize = true;
            this.avgTemperature.Location = new System.Drawing.Point(308, 19);
            this.avgTemperature.Name = "avgTemperature";
            this.avgTemperature.Size = new System.Drawing.Size(29, 13);
            this.avgTemperature.TabIndex = 5;
            this.avgTemperature.Text = "40 C";
            // 
            // avgTemperatureLbl
            // 
            this.avgTemperatureLbl.AutoSize = true;
            this.avgTemperatureLbl.Location = new System.Drawing.Point(201, 19);
            this.avgTemperatureLbl.Name = "avgTemperatureLbl";
            this.avgTemperatureLbl.Size = new System.Drawing.Size(88, 13);
            this.avgTemperatureLbl.TabIndex = 4;
            this.avgTemperatureLbl.Text = "Avg temperature:";
            // 
            // instantRPMs
            // 
            this.instantRPMs.AutoSize = true;
            this.instantRPMs.Location = new System.Drawing.Point(113, 34);
            this.instantRPMs.Name = "instantRPMs";
            this.instantRPMs.Size = new System.Drawing.Size(51, 13);
            this.instantRPMs.TabIndex = 3;
            this.instantRPMs.Text = "100.00 %";
            // 
            // instantRPMsLbl
            // 
            this.instantRPMsLbl.AutoSize = true;
            this.instantRPMsLbl.Location = new System.Drawing.Point(6, 34);
            this.instantRPMsLbl.Name = "instantRPMsLbl";
            this.instantRPMsLbl.Size = new System.Drawing.Size(74, 13);
            this.instantRPMsLbl.TabIndex = 2;
            this.instantRPMsLbl.Text = "Instant RPMs:";
            // 
            // instantTemperature
            // 
            this.instantTemperature.AutoSize = true;
            this.instantTemperature.Location = new System.Drawing.Point(113, 19);
            this.instantTemperature.Name = "instantTemperature";
            this.instantTemperature.Size = new System.Drawing.Size(29, 13);
            this.instantTemperature.TabIndex = 1;
            this.instantTemperature.Text = "40 C";
            // 
            // temperatures
            // 
            this.temperatures.Location = new System.Drawing.Point(9, 51);
            this.temperatures.Name = "temperatures";
            this.temperatures.Size = new System.Drawing.Size(493, 186);
            this.temperatures.TabIndex = 8;
            // 
            // FanInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox);
            this.Name = "FanInfo";
            this.Size = new System.Drawing.Size(518, 252);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label instantTemperatureLbl;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label instantTemperature;
        private System.Windows.Forms.Label instantRPMs;
        private System.Windows.Forms.Label instantRPMsLbl;
        private System.Windows.Forms.Label avgTemperature;
        private System.Windows.Forms.Label avgTemperatureLbl;
        private System.Windows.Forms.Label maxTemperature;
        private System.Windows.Forms.Label maxTemperatureLbl;
        private System.Windows.Forms.FlowLayoutPanel temperatures;
    }
}
