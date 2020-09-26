namespace Sbn.AdvancedControls.Imaging.SbnPaint
{
    partial class ucToolsSelector
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlForColor = new System.Windows.Forms.Panel();
            this.pnlBackColor = new System.Windows.Forms.Panel();
            this.ucButtomSelectPenWidth1 = new Sbn.AdvancedControls.Imaging.SbnPaint.ucButtomSelectPenWidth();
            this.tsbtnPointer = new System.Windows.Forms.ToolStripButton();
            this.tsbtnHand = new System.Windows.Forms.ToolStripButton();
            this.tsbtnText = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEraser = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRectangle = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEllipse = new System.Windows.Forms.ToolStripButton();
            this.tsbtnPencil = new System.Windows.Forms.ToolStripButton();
            this.tsbtnCurveLine = new System.Windows.Forms.ToolStripButton();
            this.tsbtnPactiveCurve = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(51, 24);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tools";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnPointer,
            this.tsbtnHand,
            this.tsbtnText,
            this.tsbtnEraser,
            this.tsbtnRectangle,
            this.tsbtnEllipse,
            this.tsbtnPencil,
            this.tsbtnCurveLine,
            this.tsbtnPactiveCurve});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 56);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(51, 239);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnlForColor);
            this.panel2.Controls.Add(this.pnlBackColor);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 295);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(51, 61);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(51, 32);
            this.panel3.TabIndex = 0;
            // 
            // pnlForColor
            // 
            this.pnlForColor.BackColor = System.Drawing.Color.Black;
            this.pnlForColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlForColor.Location = new System.Drawing.Point(3, 12);
            this.pnlForColor.Name = "pnlForColor";
            this.pnlForColor.Size = new System.Drawing.Size(29, 30);
            this.pnlForColor.TabIndex = 0;
            this.pnlForColor.BackColorChanged += new System.EventHandler(this.pnlForColor_BackColorChanged);
            this.pnlForColor.Click += new System.EventHandler(this.pnlForColor_Click);
            // 
            // pnlBackColor
            // 
            this.pnlBackColor.BackColor = System.Drawing.Color.White;
            this.pnlBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBackColor.Location = new System.Drawing.Point(18, 23);
            this.pnlBackColor.Name = "pnlBackColor";
            this.pnlBackColor.Size = new System.Drawing.Size(29, 30);
            this.pnlBackColor.TabIndex = 1;
            this.pnlBackColor.BackColorChanged += new System.EventHandler(this.pnlBackColor_BackColorChanged);
            this.pnlBackColor.Click += new System.EventHandler(this.pnlBackColor_Click);
            // 
            // ucButtomSelectPenWidth1
            // 
            this.ucButtomSelectPenWidth1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ucButtomSelectPenWidth1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucButtomSelectPenWidth1.Location = new System.Drawing.Point(0, 356);
            this.ucButtomSelectPenWidth1.Name = "ucButtomSelectPenWidth1";
            this.ucButtomSelectPenWidth1.PenWidth = 100F;
            this.ucButtomSelectPenWidth1.Size = new System.Drawing.Size(51, 45);
            this.ucButtomSelectPenWidth1.TabIndex = 0;
            this.ucButtomSelectPenWidth1.SelectWidthChange += new System.EventHandler(this.ucButtomSelectPenWidth1_SelectWidthChange);
            // 
            // tsbtnPointer
            // 
            this.tsbtnPointer.CheckOnClick = true;
            this.tsbtnPointer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnPointer.Enabled = false;
            this.tsbtnPointer.Image = global::Sbn.AdvancedControls.Imaging.SbnPaint.Resource.cursor;
            this.tsbtnPointer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPointer.Name = "tsbtnPointer";
            this.tsbtnPointer.Size = new System.Drawing.Size(24, 24);
            this.tsbtnPointer.Text = "Pointer";
            this.tsbtnPointer.CheckedChanged += new System.EventHandler(this.tsbtnPointer_CheckedChanged);
            this.tsbtnPointer.Click += new System.EventHandler(this.tsbtnPointer_Click);
            // 
            // tsbtnHand
            // 
            this.tsbtnHand.CheckOnClick = true;
            this.tsbtnHand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnHand.Enabled = false;
            this.tsbtnHand.Image = global::Sbn.AdvancedControls.Imaging.SbnPaint.Resource.tool_pan;
            this.tsbtnHand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnHand.Name = "tsbtnHand";
            this.tsbtnHand.Size = new System.Drawing.Size(24, 24);
            this.tsbtnHand.Text = "Hand";
            this.tsbtnHand.CheckedChanged += new System.EventHandler(this.tsbtnPointer_CheckedChanged);
            this.tsbtnHand.Click += new System.EventHandler(this.tsbtnHand_Click);
            // 
            // tsbtnText
            // 
            this.tsbtnText.CheckOnClick = true;
            this.tsbtnText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnText.Enabled = false;
            this.tsbtnText.Image = global::Sbn.AdvancedControls.Imaging.SbnPaint.Resource.stock_draw_text;
            this.tsbtnText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnText.Name = "tsbtnText";
            this.tsbtnText.Size = new System.Drawing.Size(24, 24);
            this.tsbtnText.Text = "Text";
            this.tsbtnText.CheckedChanged += new System.EventHandler(this.tsbtnPointer_CheckedChanged);
            this.tsbtnText.Click += new System.EventHandler(this.tsbtnText_Click);
            // 
            // tsbtnEraser
            // 
            this.tsbtnEraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnEraser.Enabled = false;
            this.tsbtnEraser.Image = global::Sbn.AdvancedControls.Imaging.SbnPaint.Resource.eraser;
            this.tsbtnEraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEraser.Name = "tsbtnEraser";
            this.tsbtnEraser.Size = new System.Drawing.Size(24, 24);
            this.tsbtnEraser.Text = "Eraser";
            this.tsbtnEraser.CheckedChanged += new System.EventHandler(this.tsbtnPointer_CheckedChanged);
            this.tsbtnEraser.Click += new System.EventHandler(this.tsbtnEraser_Click);
            // 
            // tsbtnRectangle
            // 
            this.tsbtnRectangle.CheckOnClick = true;
            this.tsbtnRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRectangle.Enabled = false;
            this.tsbtnRectangle.Image = global::Sbn.AdvancedControls.Imaging.SbnPaint.Resource.stock_draw_rounded_square;
            this.tsbtnRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRectangle.Name = "tsbtnRectangle";
            this.tsbtnRectangle.Size = new System.Drawing.Size(24, 24);
            this.tsbtnRectangle.Text = "Rectangle";
            this.tsbtnRectangle.CheckedChanged += new System.EventHandler(this.tsbtnPointer_CheckedChanged);
            this.tsbtnRectangle.Click += new System.EventHandler(this.tsbtnRectangle_Click);
            // 
            // tsbtnEllipse
            // 
            this.tsbtnEllipse.CheckOnClick = true;
            this.tsbtnEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnEllipse.Enabled = false;
            this.tsbtnEllipse.Image = global::Sbn.AdvancedControls.Imaging.SbnPaint.Resource.stock_draw_ellipse;
            this.tsbtnEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEllipse.Name = "tsbtnEllipse";
            this.tsbtnEllipse.Size = new System.Drawing.Size(24, 24);
            this.tsbtnEllipse.Text = "Ellipse";
            this.tsbtnEllipse.CheckedChanged += new System.EventHandler(this.tsbtnPointer_CheckedChanged);
            this.tsbtnEllipse.Click += new System.EventHandler(this.tsbtnEllipse_Click);
            // 
            // tsbtnPencil
            // 
            this.tsbtnPencil.CheckOnClick = true;
            this.tsbtnPencil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnPencil.Enabled = false;
            this.tsbtnPencil.Image = global::Sbn.AdvancedControls.Imaging.SbnPaint.Resource.paintbrush;
            this.tsbtnPencil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPencil.Name = "tsbtnPencil";
            this.tsbtnPencil.Size = new System.Drawing.Size(24, 24);
            this.tsbtnPencil.Text = "قلمو";
            this.tsbtnPencil.CheckedChanged += new System.EventHandler(this.tsbtnPointer_CheckedChanged);
            this.tsbtnPencil.Click += new System.EventHandler(this.tsbtnPencil_Click);
            // 
            // tsbtnCurveLine
            // 
            this.tsbtnCurveLine.CheckOnClick = true;
            this.tsbtnCurveLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnCurveLine.Image = global::Sbn.AdvancedControls.Imaging.SbnPaint.Resource.pen;
            this.tsbtnCurveLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCurveLine.Name = "tsbtnCurveLine";
            this.tsbtnCurveLine.Size = new System.Drawing.Size(24, 24);
            this.tsbtnCurveLine.Text = "منحنی";
            this.tsbtnCurveLine.CheckedChanged += new System.EventHandler(this.tsbtnPointer_CheckedChanged);
            this.tsbtnCurveLine.Click += new System.EventHandler(this.tsbtnCurveLine_Click);
            // 
            // tsbtnPactiveCurve
            // 
            this.tsbtnPactiveCurve.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnPactiveCurve.Enabled = false;
            this.tsbtnPactiveCurve.Image = global::Sbn.AdvancedControls.Imaging.SbnPaint.Resource.pen1;
            this.tsbtnPactiveCurve.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPactiveCurve.Name = "tsbtnPactiveCurve";
            this.tsbtnPactiveCurve.Size = new System.Drawing.Size(24, 24);
            this.tsbtnPactiveCurve.Text = "خودنویس";
            this.tsbtnPactiveCurve.CheckedChanged += new System.EventHandler(this.tsbtnPointer_CheckedChanged);
            this.tsbtnPactiveCurve.Click += new System.EventHandler(this.tsbtnPactiveCurve_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(9, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::Sbn.AdvancedControls.Imaging.SbnPaint.Resource.gtk_close;
            this.pictureBox2.Location = new System.Drawing.Point(34, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(13, 12);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // ucToolsSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ucButtomSelectPenWidth1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "ucToolsSelector";
            this.Size = new System.Drawing.Size(51, 401);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnPointer;
        private System.Windows.Forms.ToolStripButton tsbtnText;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripButton tsbtnRectangle;
        private System.Windows.Forms.ToolStripButton tsbtnEllipse;
        private System.Windows.Forms.ToolStripButton tsbtnPencil;
        private System.Windows.Forms.ToolStripButton tsbtnPactiveCurve;
        private System.Windows.Forms.ToolStripButton tsbtnEraser;
        private System.Windows.Forms.ToolStripButton tsbtnHand;
        private System.Windows.Forms.Panel pnlForColor;
        private System.Windows.Forms.Panel pnlBackColor;
        private System.Windows.Forms.ToolStripButton tsbtnCurveLine;
        private ucButtomSelectPenWidth ucButtomSelectPenWidth1;
    }
}
