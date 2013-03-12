namespace Shemo
{
    partial class ElProp
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
            this.delayVal = new System.Windows.Forms.NumericUpDown();
            this.labelElementTitle = new System.Windows.Forms.Label();
            this.labelDelayTitle = new System.Windows.Forms.Label();
            this.labelElementName = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.delayVal)).BeginInit();
            this.SuspendLayout();
            // 
            // delayVal
            // 
            this.delayVal.Location = new System.Drawing.Point(70, 41);
            this.delayVal.Name = "delayVal";
            this.delayVal.Size = new System.Drawing.Size(103, 20);
            this.delayVal.TabIndex = 0;
            this.delayVal.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // labelElementTitle
            // 
            this.labelElementTitle.AutoSize = true;
            this.labelElementTitle.Location = new System.Drawing.Point(13, 13);
            this.labelElementTitle.Name = "labelElementTitle";
            this.labelElementTitle.Size = new System.Drawing.Size(48, 13);
            this.labelElementTitle.TabIndex = 1;
            this.labelElementTitle.Text = "Element:";
            // 
            // labelDelayTitle
            // 
            this.labelDelayTitle.AutoSize = true;
            this.labelDelayTitle.Location = new System.Drawing.Point(13, 43);
            this.labelDelayTitle.Name = "labelDelayTitle";
            this.labelDelayTitle.Size = new System.Drawing.Size(34, 13);
            this.labelDelayTitle.TabIndex = 1;
            this.labelDelayTitle.Text = "Delay";
            // 
            // labelElementName
            // 
            this.labelElementName.AutoSize = true;
            this.labelElementName.Location = new System.Drawing.Point(67, 13);
            this.labelElementName.Name = "labelElementName";
            this.labelElementName.Size = new System.Drawing.Size(46, 13);
            this.labelElementName.TabIndex = 2;
            this.labelElementName.Text = "ERROR";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(98, 67);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(14, 67);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 3;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // ElProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(178, 101);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelElementName);
            this.Controls.Add(this.labelDelayTitle);
            this.Controls.Add(this.labelElementTitle);
            this.Controls.Add(this.delayVal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ElProp";
            this.Text = "ElProp";
            ((System.ComponentModel.ISupportInitialize)(this.delayVal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown delayVal;
        private System.Windows.Forms.Label labelElementTitle;
        private System.Windows.Forms.Label labelDelayTitle;
        private System.Windows.Forms.Label labelElementName;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
    }
}