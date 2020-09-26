namespace SessionPresent.Tools.SbnTools.FolderWordDocument
{
    partial class ucWordDocEntityProp
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
            this.wordControlDocument1 = new Sbn.AdvancedControls.WordControlDocument.WordControlDocument();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGDocID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // wordControlDocument1
            // 
            this.wordControlDocument1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.wordControlDocument1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wordControlDocument1.DocumentChanged = false;
            this.wordControlDocument1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.wordControlDocument1.IsInGettingImageState = false;
            this.wordControlDocument1.IsNewInstance = true;
            this.wordControlDocument1.Location = new System.Drawing.Point(0, 0);
            this.wordControlDocument1.Name = "wordControlDocument1";
            this.wordControlDocument1.ReadOnly = false;
            this.wordControlDocument1.Size = new System.Drawing.Size(669, 489);
            this.wordControlDocument1.TabIndex = 5;
            this.wordControlDocument1.AfterPrintDocument += new System.Drawing.Printing.PrintEventHandler(this.wordControlDocument1_AfterPrintDocument);
            this.wordControlDocument1.AfterGetImageFromDocument += new System.Drawing.Printing.PrintEventHandler(this.wordControlDocument1_AfterGetImageFromDocument);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblGDocID);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 489);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(669, 31);
            this.panel1.TabIndex = 6;
            this.panel1.Visible = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(164, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(472, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "امکان ویرایش این مستند تایپی وجود ندارد";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGDocID
            // 
            this.lblGDocID.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblGDocID.Location = new System.Drawing.Point(0, 0);
            this.lblGDocID.Name = "lblGDocID";
            this.lblGDocID.Size = new System.Drawing.Size(164, 29);
            this.lblGDocID.TabIndex = 2;
            this.lblGDocID.Text = "کد مستند : ";
            this.lblGDocID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
           
            this.pictureBox1.Location = new System.Drawing.Point(636, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // ucWordDocEntityProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wordControlDocument1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "ucWordDocEntityProp";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(669, 520);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Sbn.AdvancedControls.WordControlDocument.WordControlDocument wordControlDocument1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGDocID;

    }
}
