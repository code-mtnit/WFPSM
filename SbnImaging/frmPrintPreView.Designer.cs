namespace Sbn.Controls.Imaging
{
    partial class frmPrintPreView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbPrinters = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnAllPage = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.txtSelectedPages = new System.Windows.Forms.TextBox();
            this.vistaButton1 = new System.Windows.Forms.Button();
            this.vistaButton2 = new System.Windows.Forms.Button();
            this.btnEndImage = new System.Windows.Forms.Button();
            this.btnFirstImage = new System.Windows.Forms.Button();
            this.btnPreviousImage = new System.Windows.Forms.Button();
            this.btnNextImag = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.vistaButton7 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPageSetup = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnCurrentView = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbModeView = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cboxFitToPage = new System.Windows.Forms.CheckBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLaftMargin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTopMargin = new System.Windows.Forms.TextBox();
            this.cboxCenter = new System.Windows.Forms.CheckBox();
            this.txtPageSetup = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(22, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 274);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.FormattingEnabled = true;
            this.cmbPrinters.Location = new System.Drawing.Point(82, 17);
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(250, 21);
            this.cmbPrinters.TabIndex = 1;
            this.cmbPrinters.SelectedIndexChanged += new System.EventHandler(this.cmbPrinters_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name : ";
            // 
            // rbtnAllPage
            // 
            this.rbtnAllPage.AutoSize = true;
            this.rbtnAllPage.Location = new System.Drawing.Point(16, 20);
            this.rbtnAllPage.Name = "rbtnAllPage";
            this.rbtnAllPage.Size = new System.Drawing.Size(69, 17);
            this.rbtnAllPage.TabIndex = 3;
            this.rbtnAllPage.Text = "All Pages";
            this.rbtnAllPage.UseVisualStyleBackColor = true;
            this.rbtnAllPage.CheckedChanged += new System.EventHandler(this.rbtnAllPage_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(16, 73);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(55, 17);
            this.radioButton3.TabIndex = 5;
            this.radioButton3.Text = "Pages";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // txtSelectedPages
            // 
            this.txtSelectedPages.Enabled = false;
            this.txtSelectedPages.Location = new System.Drawing.Point(82, 72);
            this.txtSelectedPages.Name = "txtSelectedPages";
            this.txtSelectedPages.Size = new System.Drawing.Size(250, 21);
            this.txtSelectedPages.TabIndex = 6;
            // 
            // vistaButton1
            // 
            this.vistaButton1.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton1.Location = new System.Drawing.Point(12, 424);
            this.vistaButton1.Name = "vistaButton1";
            this.vistaButton1.Size = new System.Drawing.Size(100, 32);
            this.vistaButton1.TabIndex = 7;
            this.vistaButton1.Text = "تأیید";
            this.vistaButton1.UseVisualStyleBackColor = true;
            this.vistaButton1.Click += new System.EventHandler(this.vistaButton1_Click);
            // 
            // vistaButton2
            // 
            this.vistaButton2.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton2.Location = new System.Drawing.Point(118, 424);
            this.vistaButton2.Name = "vistaButton2";
            this.vistaButton2.Size = new System.Drawing.Size(100, 32);
            this.vistaButton2.TabIndex = 8;
            this.vistaButton2.Text = "انصراف";
            this.vistaButton2.UseVisualStyleBackColor = true;
            this.vistaButton2.Click += new System.EventHandler(this.vistaButton2_Click);
            // 
            // btnEndImage
            // 
            this.btnEndImage.BackColor = System.Drawing.Color.Transparent;
            this.btnEndImage.Location = new System.Drawing.Point(198, 324);
            this.btnEndImage.Name = "btnEndImage";
            this.btnEndImage.Size = new System.Drawing.Size(45, 29);
            this.btnEndImage.TabIndex = 9;
            this.btnEndImage.Text = ">>";
            this.btnEndImage.UseVisualStyleBackColor = true;
            this.btnEndImage.Click += new System.EventHandler(this.btnEndImage_Click);
            // 
            // btnFirstImage
            // 
            this.btnFirstImage.BackColor = System.Drawing.Color.Transparent;
            this.btnFirstImage.Location = new System.Drawing.Point(6, 325);
            this.btnFirstImage.Name = "btnFirstImage";
            this.btnFirstImage.Size = new System.Drawing.Size(48, 29);
            this.btnFirstImage.TabIndex = 10;
            this.btnFirstImage.Text = "<<";
            this.btnFirstImage.UseVisualStyleBackColor = true;
            this.btnFirstImage.Click += new System.EventHandler(this.btnFirstImage_Click);
            // 
            // btnPreviousImage
            // 
            this.btnPreviousImage.BackColor = System.Drawing.Color.Transparent;
            this.btnPreviousImage.Location = new System.Drawing.Point(60, 325);
            this.btnPreviousImage.Name = "btnPreviousImage";
            this.btnPreviousImage.Size = new System.Drawing.Size(33, 29);
            this.btnPreviousImage.TabIndex = 12;
            this.btnPreviousImage.Text = "<";
            this.btnPreviousImage.UseVisualStyleBackColor = true;
            this.btnPreviousImage.Click += new System.EventHandler(this.btnPreviousImage_Click);
            // 
            // btnNextImag
            // 
            this.btnNextImag.BackColor = System.Drawing.Color.Transparent;
            this.btnNextImag.Location = new System.Drawing.Point(159, 324);
            this.btnNextImag.Name = "btnNextImag";
            this.btnNextImag.Size = new System.Drawing.Size(33, 29);
            this.btnNextImag.TabIndex = 11;
            this.btnNextImag.Text = ">";
            this.btnNextImag.UseVisualStyleBackColor = true;
            this.btnNextImag.Click += new System.EventHandler(this.vistaButton6_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(99, 325);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(54, 28);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "1";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // vistaButton7
            // 
            this.vistaButton7.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton7.Location = new System.Drawing.Point(232, 44);
            this.vistaButton7.Name = "vistaButton7";
            this.vistaButton7.Size = new System.Drawing.Size(100, 32);
            this.vistaButton7.TabIndex = 14;
            this.vistaButton7.Text = "Properties";
            this.vistaButton7.UseVisualStyleBackColor = true;
            this.vistaButton7.Click += new System.EventHandler(this.vistaButton7_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPageSetup);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.vistaButton7);
            this.groupBox1.Controls.Add(this.cmbPrinters);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 89);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Printer";
            // 
            // btnPageSetup
            // 
            this.btnPageSetup.BackColor = System.Drawing.Color.Transparent;
            this.btnPageSetup.Location = new System.Drawing.Point(133, 44);
            this.btnPageSetup.Name = "btnPageSetup";
            this.btnPageSetup.Size = new System.Drawing.Size(93, 32);
            this.btnPageSetup.TabIndex = 15;
            this.btnPageSetup.Text = "PageSetup";
            this.btnPageSetup.UseVisualStyleBackColor = true;
            this.btnPageSetup.Click += new System.EventHandler(this.btnPageSetup_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnCurrentView);
            this.groupBox2.Controls.Add(this.rbtnAllPage);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.txtSelectedPages);
            this.groupBox2.Location = new System.Drawing.Point(12, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(370, 109);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Print Range";
            // 
            // rbtnCurrentView
            // 
            this.rbtnCurrentView.AutoSize = true;
            this.rbtnCurrentView.Checked = true;
            this.rbtnCurrentView.Location = new System.Drawing.Point(16, 46);
            this.rbtnCurrentView.Name = "rbtnCurrentView";
            this.rbtnCurrentView.Size = new System.Drawing.Size(82, 17);
            this.rbtnCurrentView.TabIndex = 7;
            this.rbtnCurrentView.TabStop = true;
            this.rbtnCurrentView.Text = "CurrentView";
            this.rbtnCurrentView.UseVisualStyleBackColor = true;
            this.rbtnCurrentView.CheckedChanged += new System.EventHandler(this.rbtnCurrentView_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnFirstImage);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Controls.Add(this.btnEndImage);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.btnNextImag);
            this.groupBox3.Controls.Add(this.btnPreviousImage);
            this.groupBox3.Location = new System.Drawing.Point(404, 52);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(253, 357);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Preview ";
            // 
            // cbModeView
            // 
            this.cbModeView.Enabled = false;
            this.cbModeView.FormattingEnabled = true;
            this.cbModeView.Items.AddRange(new object[] {
            "FillToWidth",
            "Center"});
            this.cbModeView.Location = new System.Drawing.Point(80, 20);
            this.cbModeView.Name = "cbModeView";
            this.cbModeView.Size = new System.Drawing.Size(250, 21);
            this.cbModeView.TabIndex = 18;
            this.cbModeView.SelectedIndexChanged += new System.EventHandler(this.cbModeView_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbModeView);
            this.groupBox4.Location = new System.Drawing.Point(14, 341);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(373, 68);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "PageSetup";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(401, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Page : ";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cboxFitToPage);
            this.groupBox5.Controls.Add(this.txtHeight);
            this.groupBox5.Controls.Add(this.txtWidth);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Location = new System.Drawing.Point(14, 224);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(166, 111);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Scaled Prin Size ";
            // 
            // cboxFitToPage
            // 
            this.cboxFitToPage.AutoSize = true;
            this.cboxFitToPage.Location = new System.Drawing.Point(18, 20);
            this.cboxFitToPage.Name = "cboxFitToPage";
            this.cboxFitToPage.Size = new System.Drawing.Size(75, 17);
            this.cboxFitToPage.TabIndex = 18;
            this.cboxFitToPage.Text = "FitToPage";
            this.cboxFitToPage.UseVisualStyleBackColor = true;
            this.cboxFitToPage.CheckedChanged += new System.EventHandler(this.cboxFitToPage_CheckedChanged);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(60, 75);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(78, 21);
            this.txtHeight.TabIndex = 21;
            this.txtHeight.Text = "100";
            this.txtHeight.TextChanged += new System.EventHandler(this.txtHeight_TextChanged);
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(60, 48);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(78, 21);
            this.txtWidth.TabIndex = 18;
            this.txtWidth.Text = "100";
            this.txtWidth.TextChanged += new System.EventHandler(this.txtWidth_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Height : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Width : ";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.txtLaftMargin);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.txtTopMargin);
            this.groupBox6.Controls.Add(this.cboxCenter);
            this.groupBox6.Location = new System.Drawing.Point(193, 224);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(189, 111);
            this.groupBox6.TabIndex = 21;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Position ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Left : ";
            // 
            // txtLaftMargin
            // 
            this.txtLaftMargin.Location = new System.Drawing.Point(63, 70);
            this.txtLaftMargin.Name = "txtLaftMargin";
            this.txtLaftMargin.Size = new System.Drawing.Size(88, 21);
            this.txtLaftMargin.TabIndex = 16;
            this.txtLaftMargin.Text = "0";
            this.txtLaftMargin.TextChanged += new System.EventHandler(this.txtLaftMargin_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Top : ";
            // 
            // txtTopMargin
            // 
            this.txtTopMargin.Location = new System.Drawing.Point(63, 43);
            this.txtTopMargin.Name = "txtTopMargin";
            this.txtTopMargin.Size = new System.Drawing.Size(88, 21);
            this.txtTopMargin.TabIndex = 1;
            this.txtTopMargin.Text = "0";
            this.txtTopMargin.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // cboxCenter
            // 
            this.cboxCenter.AutoSize = true;
            this.cboxCenter.Location = new System.Drawing.Point(16, 20);
            this.cboxCenter.Name = "cboxCenter";
            this.cboxCenter.Size = new System.Drawing.Size(57, 17);
            this.cboxCenter.TabIndex = 0;
            this.cboxCenter.Text = "Center";
            this.cboxCenter.UseVisualStyleBackColor = true;
            this.cboxCenter.CheckedChanged += new System.EventHandler(this.cboxCenter_CheckedChanged);
            // 
            // txtPageSetup
            // 
            this.txtPageSetup.Location = new System.Drawing.Point(448, 26);
            this.txtPageSetup.Name = "txtPageSetup";
            this.txtPageSetup.ReadOnly = true;
            this.txtPageSetup.Size = new System.Drawing.Size(162, 21);
            this.txtPageSetup.TabIndex = 8;
            // 
            // frmPrintPreView
            // 
            this.ClientSize = new System.Drawing.Size(683, 468);
            this.Controls.Add(this.txtPageSetup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.vistaButton2);
            this.Controls.Add(this.vistaButton1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmPrintPreView";
            this.Text = "frmPrintPreView";
            this.Load += new System.EventHandler(this.frmPrintPreView_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbPrinters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtnAllPage;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.TextBox txtSelectedPages;
        private System.Windows.Forms.Button vistaButton1;
        private System.Windows.Forms.Button vistaButton2;
        private System.Windows.Forms.Button btnEndImage;
        
        private System.Windows.Forms.Button btnFirstImage;
        private System.Windows.Forms.Button btnPreviousImage;
        private System.Windows.Forms.Button btnNextImag;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button vistaButton7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtnCurrentView;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbModeView;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTopMargin;
        private System.Windows.Forms.CheckBox cboxCenter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLaftMargin;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.CheckBox cboxFitToPage;
        private System.Windows.Forms.Button btnPageSetup;
        private System.Windows.Forms.TextBox txtPageSetup;
    }
}