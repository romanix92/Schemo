﻿namespace Schemo
{
    partial class WaveFormsWindow
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
            this.SuspendLayout();
            // 
            // WaveFormsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1265, 209);
            this.DoubleBuffered = true;
            this.Name = "WaveFormsWindow";
            this.Text = "WaveFormsWindow";
            this.Load += new System.EventHandler(this.WaveFormsWindow_Load);
            this.Shown += new System.EventHandler(this.WaveFormsWindow_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.WaveFormsWindow_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}