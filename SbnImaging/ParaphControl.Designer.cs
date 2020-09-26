namespace Sbn.Controls.Imaging
{
    partial class ParaphControl
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
            Sbn.AdvancedControls.Imaging.SbnPaint.Pointer pointer1 = new Sbn.AdvancedControls.Imaging.SbnPaint.Pointer();
            Sbn.FramWork.Drawing.Ghost ghost1 = new Sbn.FramWork.Drawing.Ghost();
            Sbn.FramWork.Drawing.GhostAppearance ghostAppearance1 = new Sbn.FramWork.Drawing.GhostAppearance();
            System.Drawing.StringFormat stringFormat1 = new System.Drawing.StringFormat();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParaphControl));
            Sbn.AdvancedControls.Imaging.SbnPaint.BodyBackground bodyBackground1 = new Sbn.AdvancedControls.Imaging.SbnPaint.BodyBackground();
            Sbn.FramWork.Drawing.PolygonAppearance polygonAppearance1 = new Sbn.FramWork.Drawing.PolygonAppearance();
            System.Drawing.StringFormat stringFormat2 = new System.Drawing.StringFormat();
            this.tsTools = new System.Windows.Forms.ToolStrip();
            this.tsbtnCurser = new System.Windows.Forms.ToolStripButton();
            this.tsbtnPen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnItmWhole = new System.Windows.Forms.ToolStripButton();
            this.tsbtnItmActualSize = new System.Windows.Forms.ToolStripButton();
            this.tsbtnItmFitWidth = new System.Windows.Forms.ToolStripButton();
            this.tsbtnZoomIn = new System.Windows.Forms.ToolStripButton();
            this.tsbtnZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRemoveLayer = new System.Windows.Forms.ToolStripButton();
            this.drawingPanel1 = new Sbn.AdvancedControls.Imaging.SbnPaint.DrawingPanel();
            this.tsTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsTools
            // 
            this.tsTools.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnCurser,
            this.tsbtnPen,
            this.toolStripSeparator2,
            this.tsbtnItmWhole,
            this.tsbtnItmActualSize,
            this.tsbtnItmFitWidth,
            this.tsbtnZoomIn,
            this.tsbtnZoomOut,
            this.toolStripSeparator1,
            this.tsbtnRemoveLayer});
            this.tsTools.Location = new System.Drawing.Point(0, 577);
            this.tsTools.Name = "tsTools";
            this.tsTools.Size = new System.Drawing.Size(822, 25);
            this.tsTools.TabIndex = 0;
            this.tsTools.Text = "toolStrip1";
            // 
            // tsbtnCurser
            // 
            this.tsbtnCurser.CheckOnClick = true;
            
            this.tsbtnCurser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCurser.Name = "tsbtnCurser";
            this.tsbtnCurser.Size = new System.Drawing.Size(65, 22);
            this.tsbtnCurser.Text = "انتخابگر";
            this.tsbtnCurser.CheckedChanged += new System.EventHandler(this.tsbtnCurser_CheckedChanged);
            this.tsbtnCurser.Click += new System.EventHandler(this.tsbtnCurser_Click);
            // 
            // tsbtnPen
            // 
            this.tsbtnPen.Checked = true;
            this.tsbtnPen.CheckOnClick = true;
            this.tsbtnPen.CheckState = System.Windows.Forms.CheckState.Checked;
            
            this.tsbtnPen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPen.Name = "tsbtnPen";
            this.tsbtnPen.Size = new System.Drawing.Size(39, 22);
            this.tsbtnPen.Text = "قلم";
            this.tsbtnPen.CheckedChanged += new System.EventHandler(this.tsbtnPen_CheckedChanged);
            this.tsbtnPen.Click += new System.EventHandler(this.tsbtnPen_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnItmWhole
            // 
            this.tsbtnItmWhole.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            
            this.tsbtnItmWhole.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnItmWhole.Name = "tsbtnItmWhole";
            this.tsbtnItmWhole.Size = new System.Drawing.Size(23, 22);
            this.tsbtnItmWhole.Text = "toolStripButton1";
            this.tsbtnItmWhole.ToolTipText = "اندازه قابل رؤيت بصورت كامل";
            this.tsbtnItmWhole.Visible = false;
            this.tsbtnItmWhole.Click += new System.EventHandler(this.tsbtnItmWhole_Click);
            // 
            // tsbtnItmActualSize
            // 
            this.tsbtnItmActualSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            
            this.tsbtnItmActualSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnItmActualSize.Name = "tsbtnItmActualSize";
            this.tsbtnItmActualSize.Size = new System.Drawing.Size(23, 22);
            this.tsbtnItmActualSize.Text = "ActualSize";
            this.tsbtnItmActualSize.ToolTipText = "اندازه واقعي";
            this.tsbtnItmActualSize.Visible = false;
            this.tsbtnItmActualSize.Click += new System.EventHandler(this.tsbtnItmActualSize_Click);
            // 
            // tsbtnItmFitWidth
            // 
            this.tsbtnItmFitWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            
            this.tsbtnItmFitWidth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnItmFitWidth.Name = "tsbtnItmFitWidth";
            this.tsbtnItmFitWidth.Size = new System.Drawing.Size(23, 22);
            this.tsbtnItmFitWidth.Text = "FitWidth";
            this.tsbtnItmFitWidth.ToolTipText = "متناسب با عرض تصوير";
            this.tsbtnItmFitWidth.Click += new System.EventHandler(this.tsbtnItmFitWidth_Click);
            // 
            // tsbtnZoomIn
            // 
            this.tsbtnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            
            this.tsbtnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnZoomIn.Name = "tsbtnZoomIn";
            this.tsbtnZoomIn.Size = new System.Drawing.Size(23, 22);
            this.tsbtnZoomIn.Text = "بزرگنمایی";
            this.tsbtnZoomIn.Click += new System.EventHandler(this.tsbtnZoomIn_Click);
            // 
            // tsbtnZoomOut
            // 
            this.tsbtnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            
            this.tsbtnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnZoomOut.Name = "tsbtnZoomOut";
            this.tsbtnZoomOut.Size = new System.Drawing.Size(23, 22);
            this.tsbtnZoomOut.Text = "کوچک نمایی";
            this.tsbtnZoomOut.Click += new System.EventHandler(this.tsbtnZoomOut_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnRemoveLayer
            // 
            
            this.tsbtnRemoveLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRemoveLayer.Name = "tsbtnRemoveLayer";
            this.tsbtnRemoveLayer.Size = new System.Drawing.Size(48, 22);
            this.tsbtnRemoveLayer.Text = "حذف";
            this.tsbtnRemoveLayer.Click += new System.EventHandler(this.tsbtnRemoveLayer_Click);
            // 
            // drawingPanel1
            // 
            this.drawingPanel1.ActiveCursor = System.Windows.Forms.Cursors.Default;
            ghostAppearance1.BackgroundColor1 = System.Drawing.Color.Transparent;
            ghostAppearance1.BackgroundColor2 = System.Drawing.Color.Transparent;
            ghostAppearance1.BorderColor = System.Drawing.Color.Black;
            ghostAppearance1.BorderWidth = 2F;
            //ghostAppearance1.DisplayedText = ".";
            //ghostAppearance1.Font = new System.Drawing.Font("Times New Roman", 12F);
            ghostAppearance1.GrabberDimension = 6;
            ghostAppearance1.GradientAngle = 0F;
            ghostAppearance1.Image = null;
            ghostAppearance1.MarkerColor = System.Drawing.Color.Black;
            ghostAppearance1.MarkerDimension = 4;
            ghostAppearance1.Shape = null;
            stringFormat1.Alignment = System.Drawing.StringAlignment.Near;
            stringFormat1.FormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            stringFormat1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
            stringFormat1.LineAlignment = System.Drawing.StringAlignment.Near;
            stringFormat1.Trimming = System.Drawing.StringTrimming.Character;
            //ghostAppearance1.StringFormat = stringFormat1;
            ghost1.Appearance = ghostAppearance1;
            ghost1.Center = ((System.Drawing.PointF)(resources.GetObject("ghost1.Center")));
            ghost1.Color = System.Drawing.Color.Black;
            ghost1.Dimension = new System.Drawing.SizeF(0F, 0F);
            ghost1.HorizontalVersor = Sbn.FramWork.Drawing.HorizontalVersors.LeftRight;
            ghost1.IsEdited = false;
            ghost1.Location = ((System.Drawing.PointF)(resources.GetObject("ghost1.Location")));
            ghost1.Locked = false;
            ghost1.Marked = false;
            ghost1.Menu = null;
            ghost1.MirrorPoint = ((System.Drawing.PointF)(resources.GetObject("ghost1.MirrorPoint")));
            ghost1.Rotation = 0F;
            ghost1.Selected = false;
            ghost1.Shape = null;
            ghost1.VerticalVersor = Sbn.FramWork.Drawing.VerticalVersors.TopBottom;
            ghost1.Visible = true;
            pointer1.Ghost = ghost1;
            pointer1.MouseDownPoint = new System.Drawing.Point(0, 0);
            pointer1.MouseUpPoint = new System.Drawing.Point(0, 0);
            this.drawingPanel1.ActiveTool = pointer1;
            this.drawingPanel1.BackColor = System.Drawing.Color.Khaki;
            this.drawingPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            polygonAppearance1.BackgroundColor1 = System.Drawing.Color.Transparent;
            polygonAppearance1.BackgroundColor2 = System.Drawing.Color.Transparent;
            polygonAppearance1.BorderColor = System.Drawing.Color.Black;
            polygonAppearance1.BorderWidth = 2F;
            //polygonAppearance1.DisplayedText = ".";
            //polygonAppearance1.Font = new System.Drawing.Font("Times New Roman", 12F);
            polygonAppearance1.GrabberDimension = 6;
            polygonAppearance1.GradientAngle = 0F;
            polygonAppearance1.Image = null;
            polygonAppearance1.MarkerColor = System.Drawing.Color.Black;
            polygonAppearance1.MarkerDimension = 4;
            polygonAppearance1.Shape = null;
            stringFormat2.Alignment = System.Drawing.StringAlignment.Near;
            stringFormat2.FormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            stringFormat2.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
            stringFormat2.LineAlignment = System.Drawing.StringAlignment.Near;
            stringFormat2.Trimming = System.Drawing.StringTrimming.Character;
            //polygonAppearance1.StringFormat = stringFormat2;
            bodyBackground1.Appearance = polygonAppearance1;
            bodyBackground1.Bitmap = null;
            bodyBackground1.Center = ((System.Drawing.PointF)(resources.GetObject("bodyBackground1.Center")));
            bodyBackground1.Color = System.Drawing.Color.Black;
            bodyBackground1.Dimension = new System.Drawing.SizeF(1F, 1F);
            bodyBackground1.IsEdited = false;
            bodyBackground1.Location = ((System.Drawing.PointF)(resources.GetObject("bodyBackground1.Location")));
            bodyBackground1.Locked = true;
            bodyBackground1.Marked = false;
            bodyBackground1.Menu = null;
            bodyBackground1.Rotation = 0F;
            bodyBackground1.Selected = false;
            bodyBackground1.Visible = true;
            
            this.drawingPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingPanel1.EnableWheelZoom = true;
            this.drawingPanel1.ImageBody = null;
            this.drawingPanel1.Location = new System.Drawing.Point(0, 0);
            this.drawingPanel1.Name = "drawingPanel1";
            this.drawingPanel1.Size = new System.Drawing.Size(822, 577);
            this.drawingPanel1.TabIndex = 0;
            this.drawingPanel1.Zoom = 1F;
            this.drawingPanel1.ZoomToCurserPosition = true;
            this.drawingPanel1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.drawingPanel1_Scroll);
            // 
            // ParaphControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.drawingPanel1);
            this.Controls.Add(this.tsTools);
            this.Name = "ParaphControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(822, 602);
            this.tsTools.ResumeLayout(false);
            this.tsTools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sbn.AdvancedControls.Imaging.SbnPaint.DrawingPanel drawingPanel1;
        private System.Windows.Forms.ToolStripButton tsbtnCurser;
        private System.Windows.Forms.ToolStripButton tsbtnPen;
        private System.Windows.Forms.ToolStripButton tsbtnZoomIn;
        private System.Windows.Forms.ToolStripButton tsbtnZoomOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnRemoveLayer;
        public System.Windows.Forms.ToolStripButton tsbtnItmWhole;
        public System.Windows.Forms.ToolStripButton tsbtnItmActualSize;
        public System.Windows.Forms.ToolStripButton tsbtnItmFitWidth;
        public System.Windows.Forms.ToolStrip tsTools;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}
