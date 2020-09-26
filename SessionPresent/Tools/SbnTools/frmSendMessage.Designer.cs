namespace SessionPresent.Tools.SbnTools
{
    partial class frmSendMessage
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApplay = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.trkDuration = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trcDelay = new System.Windows.Forms.TrackBar();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblDelay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trkDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(135, 154);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 35);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnApplay
            // 
            this.btnApplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnApplay.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnApplay.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplay.Location = new System.Drawing.Point(25, 154);
            this.btnApplay.Name = "btnApplay";
            this.btnApplay.Size = new System.Drawing.Size(104, 35);
            this.btnApplay.TabIndex = 16;
            this.btnApplay.Text = "تأیید";
            this.btnApplay.UseVisualStyleBackColor = true;
            this.btnApplay.Click += new System.EventHandler(this.btnApplay_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(25, 9);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(760, 100);
            this.txtTitle.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(791, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "متن پیام :";
            // 
            // trkDuration
            // 
            this.trkDuration.Location = new System.Drawing.Point(447, 121);
            this.trkDuration.Maximum = 60;
            this.trkDuration.Name = "trkDuration";
            this.trkDuration.Size = new System.Drawing.Size(238, 45);
            this.trkDuration.SmallChange = 5;
            this.trkDuration.TabIndex = 18;
            this.trkDuration.Scroll += new System.EventHandler(this.trkDuration_Scroll);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(686, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "مدت زمان نمایش (ثانیه) :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(686, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "فاصله بین دو نمایش (دقیقه) :";
            // 
            // trcDelay
            // 
            this.trcDelay.Location = new System.Drawing.Point(447, 172);
            this.trcDelay.Maximum = 60;
            this.trcDelay.Name = "trcDelay";
            this.trcDelay.Size = new System.Drawing.Size(238, 45);
            this.trcDelay.SmallChange = 5;
            this.trcDelay.TabIndex = 20;
            this.trcDelay.Scroll += new System.EventHandler(this.trcDelay_Scroll);
            // 
            // lblDuration
            // 
            this.lblDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuration.Location = new System.Drawing.Point(405, 127);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(15, 16);
            this.lblDuration.TabIndex = 22;
            this.lblDuration.Text = "0";
            // 
            // lblDelay
            // 
            this.lblDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDelay.AutoSize = true;
            this.lblDelay.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelay.Location = new System.Drawing.Point(403, 182);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(15, 16);
            this.lblDelay.TabIndex = 23;
            this.lblDelay.Text = "0";
            // 
            // frmSendMessage
            // 
            this.AcceptButton = this.btnApplay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(875, 221);
            this.Controls.Add(this.lblDelay);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trcDelay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trkDuration);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApplay);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSendMessage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "ارسال پیام";
            ((System.ComponentModel.ISupportInitialize)(this.trkDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApplay;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblDuration;
        public System.Windows.Forms.Label lblDelay;
        public System.Windows.Forms.TrackBar trkDuration;
        public System.Windows.Forms.TrackBar trcDelay;
    }
}