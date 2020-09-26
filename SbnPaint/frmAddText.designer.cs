namespace Sbn.AdvancedControls.Imaging.SbnPaint
{
    partial class frmAddText
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
            this.ucAddText1 = new Sbn.AdvancedControls.Imaging.SbnPaint.ucAddText();
            this.SuspendLayout();
            // 
            // ucAddText1
            // 
            this.ucAddText1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucAddText1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAddText1.FontText = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucAddText1.Location = new System.Drawing.Point(0, 0);
            this.ucAddText1.Name = "ucAddText1";
            this.ucAddText1.Size = new System.Drawing.Size(571, 505);
            this.ucAddText1.TabIndex = 0;
            this.ucAddText1.TextResult = "";
            this.ucAddText1.ApplayAddText += new System.EventHandler(this.ucAddText1_ApplayAddText);
            this.ucAddText1.CancelAddText += new System.EventHandler(this.ucAddText1_CancelAddText);
            // 
            // frmAddText
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(571, 505);
            this.Controls.Add(this.ucAddText1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddText";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmAddText";
            this.TransparencyKey = System.Drawing.Color.White;
            this.ResumeLayout(false);

        }

        #endregion

        public ucAddText ucAddText1;

    }
}