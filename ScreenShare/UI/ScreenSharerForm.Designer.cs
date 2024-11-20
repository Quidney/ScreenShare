namespace ScreenShare
{
    partial class ScreenSharerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnStartShare = new Button();
            btnStopShare = new Button();
            txtIP = new TextBox();
            cmbQualityMode = new ComboBox();
            numFPS = new NumericUpDown();
            lblDesIP = new Label();
            lblFPS = new Label();
            lblSavingMode = new Label();
            sbTargetRes = new UI.UserControls.SizeBox();
            lblTargetRes = new Label();
            ((System.ComponentModel.ISupportInitialize)numFPS).BeginInit();
            SuspendLayout();
            // 
            // btnStartShare
            // 
            btnStartShare.BackColor = Color.LightGreen;
            btnStartShare.Enabled = false;
            btnStartShare.FlatStyle = FlatStyle.Flat;
            btnStartShare.Font = new Font("Meiryo UI", 14.25F, FontStyle.Bold);
            btnStartShare.Location = new Point(12, 221);
            btnStartShare.Name = "btnStartShare";
            btnStartShare.Size = new Size(100, 55);
            btnStartShare.TabIndex = 0;
            btnStartShare.Text = "Start";
            btnStartShare.UseVisualStyleBackColor = false;
            btnStartShare.Click += BtnStartShare_Click;
            // 
            // btnStopShare
            // 
            btnStopShare.BackColor = Color.Red;
            btnStopShare.Enabled = false;
            btnStopShare.FlatStyle = FlatStyle.Flat;
            btnStopShare.Font = new Font("Meiryo UI", 14.25F, FontStyle.Bold);
            btnStopShare.Location = new Point(277, 221);
            btnStopShare.Name = "btnStopShare";
            btnStopShare.Size = new Size(100, 55);
            btnStopShare.TabIndex = 1;
            btnStopShare.Text = "Stop";
            btnStopShare.UseVisualStyleBackColor = false;
            btnStopShare.Click += BtnStopShare_Click;
            // 
            // txtIP
            // 
            txtIP.Location = new Point(98, 12);
            txtIP.Name = "txtIP";
            txtIP.PlaceholderText = "IP Adress";
            txtIP.Size = new Size(139, 23);
            txtIP.TabIndex = 2;
            txtIP.TextChanged += TxtIP_TextChanged;
            // 
            // cmbQualityMode
            // 
            cmbQualityMode.FormattingEnabled = true;
            cmbQualityMode.Items.AddRange(new object[] { "Save bandwidth", "Save processing power" });
            cmbQualityMode.Location = new Point(98, 41);
            cmbQualityMode.Name = "cmbQualityMode";
            cmbQualityMode.Size = new Size(139, 23);
            cmbQualityMode.TabIndex = 3;
            cmbQualityMode.SelectedIndexChanged += CmbQualityMode_SelectedIndexChanged;
            // 
            // numFPS
            // 
            numFPS.BorderStyle = BorderStyle.FixedSingle;
            numFPS.Location = new Point(98, 70);
            numFPS.Name = "numFPS";
            numFPS.Size = new Size(139, 23);
            numFPS.TabIndex = 4;
            numFPS.Value = new decimal(new int[] { 15, 0, 0, 0 });
            numFPS.ValueChanged += NumFPS_ValueChanged;
            // 
            // lblDesIP
            // 
            lblDesIP.AutoSize = true;
            lblDesIP.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDesIP.Location = new Point(7, 15);
            lblDesIP.Name = "lblDesIP";
            lblDesIP.Size = new Size(85, 15);
            lblDesIP.TabIndex = 5;
            lblDesIP.Text = "Destination IP";
            // 
            // lblFPS
            // 
            lblFPS.AutoSize = true;
            lblFPS.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFPS.Location = new Point(65, 72);
            lblFPS.Name = "lblFPS";
            lblFPS.Size = new Size(27, 15);
            lblFPS.TabIndex = 6;
            lblFPS.Text = "FPS";
            // 
            // lblSavingMode
            // 
            lblSavingMode.AutoSize = true;
            lblSavingMode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSavingMode.Location = new Point(13, 44);
            lblSavingMode.Name = "lblSavingMode";
            lblSavingMode.Size = new Size(79, 15);
            lblSavingMode.TabIndex = 7;
            lblSavingMode.Text = "Saving Mode";
            // 
            // sbTargetRes
            // 
            sbTargetRes.Location = new Point(98, 108);
            sbTargetRes.Name = "sbTargetRes";
            sbTargetRes.Size = new Size(184, 57);
            sbTargetRes.TabIndex = 8;
            sbTargetRes.Value = new Size(1280, 720);
            sbTargetRes.ValueChanged += SbTargetRes_ValueChanged;
            // 
            // lblTargetRes
            // 
            lblTargetRes.AutoSize = true;
            lblTargetRes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTargetRes.Location = new Point(26, 127);
            lblTargetRes.Name = "lblTargetRes";
            lblTargetRes.Size = new Size(66, 15);
            lblTargetRes.TabIndex = 6;
            lblTargetRes.Text = "Resolution";
            // 
            // ScreenSharerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 288);
            Controls.Add(sbTargetRes);
            Controls.Add(lblSavingMode);
            Controls.Add(lblTargetRes);
            Controls.Add(lblFPS);
            Controls.Add(lblDesIP);
            Controls.Add(numFPS);
            Controls.Add(cmbQualityMode);
            Controls.Add(txtIP);
            Controls.Add(btnStopShare);
            Controls.Add(btnStartShare);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ScreenSharerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ScreenShare";
            ((System.ComponentModel.ISupportInitialize)numFPS).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStartShare;
        private Button btnStopShare;
        private TextBox txtIP;
        private ComboBox cmbQualityMode;
        private NumericUpDown numFPS;
        private Label lblDesIP;
        private Label lblFPS;
        private Label lblSavingMode;
        private UI.UserControls.SizeBox sbTargetRes;
        private Label lblTargetRes;
    }
}
