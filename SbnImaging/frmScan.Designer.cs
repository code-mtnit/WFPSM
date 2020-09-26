using System.Windows.Forms;

namespace Sbn.Controls.Imaging
{
    partial class frmScan
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
            this.ucScanImage1 = new Sbn.AdvancedControls.Imaging.Scan.ucScanImage();
            this.vistaButton1 = new System.Windows.Forms.Button();
            this.vistaButton2 = new System.Windows.Forms.Button();
            this.vistaButton3 = new System.Windows.Forms.Button();
            this.gradientPanel1 = new System.Windows.Forms.Panel();
            this.rbtnAddToEnd = new System.Windows.Forms.RadioButton();
            this.rbtnAddToFirst = new System.Windows.Forms.RadioButton();
            this.gradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucScanImage1
            // 
            this.ucScanImage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucScanImage1.BackColor = System.Drawing.Color.Transparent;
            this.ucScanImage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucScanImage1.Location = new System.Drawing.Point(11, 12);
            this.ucScanImage1.Name = "ucScanImage1";
            this.ucScanImage1.Size = new System.Drawing.Size(845, 364);
            this.ucScanImage1.TabIndex = 0;
            this.ucScanImage1.ScanedImage += new System.EventHandler<Sbn.AdvancedControls.Imaging.Scan.ImageEvent>(this.ucScanImage1_ScanedImage);
            // 
            // vistaButton1
            // 
            this.vistaButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.vistaButton1.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton1.Image = global::SbnImaging.Properties.Resources.tick;
            this.vistaButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vistaButton1.Location = new System.Drawing.Point(12, 389);
            this.vistaButton1.Name = "vistaButton1";
            this.vistaButton1.Size = new System.Drawing.Size(87, 32);
            this.vistaButton1.TabIndex = 1;
            this.vistaButton1.Text = "تأیید";
            this.vistaButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.vistaButton1.UseVisualStyleBackColor = true;
            this.vistaButton1.Click += new System.EventHandler(this.vistaButton1_Click);
            // 
            // vistaButton2
            // 
            this.vistaButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.vistaButton2.BackColor = System.Drawing.Color.Transparent;
            
            this.vistaButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vistaButton2.Location = new System.Drawing.Point(105, 389);
            this.vistaButton2.Name = "vistaButton2";
            this.vistaButton2.Size = new System.Drawing.Size(87, 32);
            this.vistaButton2.TabIndex = 2;
            this.vistaButton2.Text = "انصراف";
            this.vistaButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.vistaButton2.UseVisualStyleBackColor = true;
            this.vistaButton2.Click += new System.EventHandler(this.vistaButton2_Click);
            // 
            // vistaButton3
            // 
            this.vistaButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.vistaButton3.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            
            this.vistaButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vistaButton3.Location = new System.Drawing.Point(688, 382);
            this.vistaButton3.Name = "vistaButton3";
            this.vistaButton3.Size = new System.Drawing.Size(167, 46);
            this.vistaButton3.TabIndex = 3;
            this.vistaButton3.Text = "اسکن";
            this.vistaButton3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.vistaButton3.UseVisualStyleBackColor = true;
            this.vistaButton3.Click += new System.EventHandler(this.vistaButton3_Click);
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.gradientPanel1.Controls.Add(this.rbtnAddToEnd);
            this.gradientPanel1.Controls.Add(this.rbtnAddToFirst);
            this.gradientPanel1.Controls.Add(this.ucScanImage1);
            this.gradientPanel1.Controls.Add(this.vistaButton2);
            this.gradientPanel1.Controls.Add(this.vistaButton3);
            this.gradientPanel1.Controls.Add(this.vistaButton1);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(867, 433);
            this.gradientPanel1.TabIndex = 4;
            // 
            // rbtnAddToEnd
            // 
            this.rbtnAddToEnd.AutoSize = true;
            this.rbtnAddToEnd.Checked = true;
            this.rbtnAddToEnd.Location = new System.Drawing.Point(428, 404);
            this.rbtnAddToEnd.Name = "rbtnAddToEnd";
            this.rbtnAddToEnd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbtnAddToEnd.Size = new System.Drawing.Size(89, 17);
            this.rbtnAddToEnd.TabIndex = 7;
            this.rbtnAddToEnd.TabStop = true;
            this.rbtnAddToEnd.Text = "افزودن به انتها";
            this.rbtnAddToEnd.UseVisualStyleBackColor = true;
            // 
            // rbtnAddToFirst
            // 
            this.rbtnAddToFirst.AutoSize = true;
            this.rbtnAddToFirst.Location = new System.Drawing.Point(536, 404);
            this.rbtnAddToFirst.Name = "rbtnAddToFirst";
            this.rbtnAddToFirst.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbtnAddToFirst.Size = new System.Drawing.Size(89, 17);
            this.rbtnAddToFirst.TabIndex = 6;
            this.rbtnAddToFirst.Text = "افزودن به ابتدا";
            this.rbtnAddToFirst.UseVisualStyleBackColor = true;
            this.rbtnAddToFirst.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // frmScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 433);
            this.Controls.Add(this.gradientPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmScan";
            this.Text = "اسکن تصویر";
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Sbn.AdvancedControls.Imaging.Scan.ucScanImage ucScanImage1;
        private System.Windows.Forms.Button vistaButton1;
        private System.Windows.Forms.Button vistaButton2;
        private System.Windows.Forms.Button vistaButton3;
        private System.Windows.Forms.Panel gradientPanel1;
        public RadioButton rbtnAddToFirst;
        public RadioButton rbtnAddToEnd;
    }
}