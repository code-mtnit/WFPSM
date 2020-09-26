namespace WordInDOTNET
{
    partial class frmTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTest));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.htfWinWordControl1 = new WinWordControl.HTFWinWordControl();
            this.tsbtnAddNewDoc = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAddNewDoc});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(737, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // htfWinWordControl1
            // 
            this.htfWinWordControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htfWinWordControl1.Location = new System.Drawing.Point(0, 25);
            this.htfWinWordControl1.Name = "htfWinWordControl1";
            this.htfWinWordControl1.Size = new System.Drawing.Size(737, 367);
            this.htfWinWordControl1.TabIndex = 1;
            // 
            // tsbtnAddNewDoc
            // 
            this.tsbtnAddNewDoc.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAddNewDoc.Image")));
            this.tsbtnAddNewDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAddNewDoc.Name = "tsbtnAddNewDoc";
            this.tsbtnAddNewDoc.Size = new System.Drawing.Size(73, 22);
            this.tsbtnAddNewDoc.Text = "سند جدید";
            this.tsbtnAddNewDoc.Click += new System.EventHandler(this.tsbtnAddNewDoc_Click);
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 392);
            this.Controls.Add(this.htfWinWordControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private WinWordControl.HTFWinWordControl htfWinWordControl1;
        private System.Windows.Forms.ToolStripButton tsbtnAddNewDoc;
    }
}