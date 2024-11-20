namespace ScreenShare.UI.UserControls
{
    partial class SizeBox
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
            numX = new NumericUpDown();
            lblX = new Label();
            lblY = new Label();
            numY = new NumericUpDown();
            pnlMain = new TableLayoutPanel();
            lblResult = new Label();
            ((System.ComponentModel.ISupportInitialize)numX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numY).BeginInit();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // numX
            // 
            numX.Dock = DockStyle.Fill;
            numX.Location = new Point(39, 31);
            numX.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numX.Name = "numX";
            numX.Size = new Size(79, 23);
            numX.TabIndex = 0;
            numX.ValueChanged += X_ValueChanged;
            // 
            // lblX
            // 
            lblX.Dock = DockStyle.Fill;
            lblX.Location = new Point(3, 28);
            lblX.Name = "lblX";
            lblX.Size = new Size(30, 29);
            lblX.TabIndex = 2;
            lblX.Text = "X";
            lblX.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblY
            // 
            lblY.Dock = DockStyle.Fill;
            lblY.Location = new Point(124, 28);
            lblY.Name = "lblY";
            lblY.Size = new Size(30, 29);
            lblY.TabIndex = 3;
            lblY.Text = "Y";
            lblY.TextAlign = ContentAlignment.MiddleRight;
            // 
            // numY
            // 
            numY.Dock = DockStyle.Fill;
            numY.Location = new Point(160, 31);
            numY.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numY.Name = "numY";
            numY.Size = new Size(82, 23);
            numY.TabIndex = 4;
            numY.ValueChanged += Y_ValueChanged;
            // 
            // pnlMain
            // 
            pnlMain.ColumnCount = 4;
            pnlMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            pnlMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            pnlMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            pnlMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            pnlMain.Controls.Add(numY, 3, 1);
            pnlMain.Controls.Add(lblY, 2, 1);
            pnlMain.Controls.Add(numX, 1, 1);
            pnlMain.Controls.Add(lblX, 0, 1);
            pnlMain.Controls.Add(lblResult, 0, 0);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.RowCount = 2;
            pnlMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            pnlMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            pnlMain.Size = new Size(245, 57);
            pnlMain.TabIndex = 5;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            pnlMain.SetColumnSpan(lblResult, 4);
            lblResult.Dock = DockStyle.Fill;
            lblResult.Location = new Point(3, 0);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(239, 28);
            lblResult.TabIndex = 5;
            lblResult.Text = "{ 0x0 }";
            lblResult.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SizeBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlMain);
            Name = "SizeBox";
            Size = new Size(245, 57);
            ((System.ComponentModel.ISupportInitialize)numX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numY).EndInit();
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private NumericUpDown numX;
        private Label lblX;
        private Label lblY;
        private NumericUpDown numY;
        private TableLayoutPanel pnlMain;
        private Label lblResult;
    }
}
