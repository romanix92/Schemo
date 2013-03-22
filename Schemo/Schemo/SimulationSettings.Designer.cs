namespace Schemo
{
    partial class SimulationSettings
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
            this.labelSimTime = new System.Windows.Forms.Label();
            this.labelPixPerTick = new System.Windows.Forms.Label();
            this.simTimeVal = new System.Windows.Forms.NumericUpDown();
            this.pixPerTickVal = new System.Windows.Forms.NumericUpDown();
            this.buttonOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.simTimeVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixPerTickVal)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSimTime
            // 
            this.labelSimTime.AutoSize = true;
            this.labelSimTime.Location = new System.Drawing.Point(13, 13);
            this.labelSimTime.Name = "labelSimTime";
            this.labelSimTime.Size = new System.Drawing.Size(77, 13);
            this.labelSimTime.TabIndex = 0;
            this.labelSimTime.Text = "Simulation time";
            // 
            // labelPixPerTick
            // 
            this.labelPixPerTick.AutoSize = true;
            this.labelPixPerTick.Location = new System.Drawing.Point(13, 45);
            this.labelPixPerTick.Name = "labelPixPerTick";
            this.labelPixPerTick.Size = new System.Drawing.Size(72, 13);
            this.labelPixPerTick.TabIndex = 1;
            this.labelPixPerTick.Text = "Pixels per tick";
            // 
            // simTimeVal
            // 
            this.simTimeVal.Location = new System.Drawing.Point(96, 11);
            this.simTimeVal.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.simTimeVal.Name = "simTimeVal";
            this.simTimeVal.Size = new System.Drawing.Size(72, 20);
            this.simTimeVal.TabIndex = 2;
            this.simTimeVal.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // pixPerTickVal
            // 
            this.pixPerTickVal.Location = new System.Drawing.Point(96, 43);
            this.pixPerTickVal.Name = "pixPerTickVal";
            this.pixPerTickVal.Size = new System.Drawing.Size(72, 20);
            this.pixPerTickVal.TabIndex = 2;
            this.pixPerTickVal.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(48, 69);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // SimulationSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 97);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.pixPerTickVal);
            this.Controls.Add(this.simTimeVal);
            this.Controls.Add(this.labelPixPerTick);
            this.Controls.Add(this.labelSimTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SimulationSettings";
            this.Text = "Simulation Settings";
            ((System.ComponentModel.ISupportInitialize)(this.simTimeVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixPerTickVal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSimTime;
        private System.Windows.Forms.Label labelPixPerTick;
        private System.Windows.Forms.NumericUpDown simTimeVal;
        private System.Windows.Forms.NumericUpDown pixPerTickVal;
        private System.Windows.Forms.Button buttonOK;
    }
}