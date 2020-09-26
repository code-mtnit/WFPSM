namespace Sbn.Controls.Imaging
{
    partial class ImageDocumentsViewer
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
            this.sbnPictureBox1 = new Sbn.AdvancedControls.Imaging.ImageViewer.SBNPictureBox();
            this.SuspendLayout();
            // 
            // sbnPictureBox1
            // 
            this.sbnPictureBox1.CurrentImage = null;
            this.sbnPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbnPictureBox1.Document = null;
            this.sbnPictureBox1.ImagePreviewMode = Sbn.AdvancedControls.Imaging.ImageViewer.PreviewMode.PAN;
            this.sbnPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.sbnPictureBox1.Name = "sbnPictureBox1";
            this.sbnPictureBox1.Size = new System.Drawing.Size(1031, 525);
            this.sbnPictureBox1.TabIndex = 0;
            this.sbnPictureBox1.ZoomMode = Sbn.AdvancedControls.Imaging.ImageViewer.ZoomMode.PageWidth;
            // 
            // ImageDocumentsViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sbnPictureBox1);
            this.Name = "ImageDocumentsViewer";
            this.Size = new System.Drawing.Size(1031, 525);
            this.ResumeLayout(false);

        }

        #endregion

        public Sbn.AdvancedControls.Imaging.ImageViewer.SBNPictureBox sbnPictureBox1;

    }
}
