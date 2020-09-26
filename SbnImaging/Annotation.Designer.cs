namespace Sbn.Controls.Imaging
{
    partial class Annotation
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Annotation));
            Sbn.AdvancedControls.Imaging.SbnPaint.Pointer pointer1 = new Sbn.AdvancedControls.Imaging.SbnPaint.Pointer();
            Sbn.FramWork.Drawing.Ghost ghost1 = new Sbn.FramWork.Drawing.Ghost();
            Sbn.FramWork.Drawing.GhostAppearance ghostAppearance1 = new Sbn.FramWork.Drawing.GhostAppearance();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRedo = new System.Windows.Forms.ToolStripButton();
            this.tsbtnUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsPointer = new System.Windows.Forms.ToolStripButton();
            this.tsbtnPen = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEraser = new System.Windows.Forms.ToolStripButton();
            this.tsbtnClearAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnNewLine = new System.Windows.Forms.ToolStripButton();
            this.tsbtnAddColumn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnApplay = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbtnCancel = new System.Windows.Forms.ToolStripButton();
            this.tsbtnPenColor = new System.Windows.Forms.ToolStripButton();
            this.tsddItmPenWiths = new System.Windows.Forms.ToolStripDropDownButton();
            this.penSelectorViewStrip1 = new Sbn.Controls.Imaging.PenSelectorViewStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.drawingPanel1 = new Sbn.AdvancedControls.Imaging.SbnPaint.DrawingPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmnuItmUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnuItmRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnuItmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnuItmRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnSave,
            this.tsbtnRefresh,
            this.tsbtnRedo,
            this.tsbtnUndo,
            this.toolStripSeparator1,
            this.tsPointer,
            this.tsbtnPen,
            this.tsbtnEraser,
            this.tsbtnClearAll,
            this.toolStripSeparator2,
            this.tsbtnNewLine,
            this.tsbtnAddColumn,
            this.toolStripSeparator3,
            this.tsbtnApplay,
            this.tsbtnDelete,
            this.tsbtnCancel,
            this.tsbtnPenColor,
            this.tsddItmPenWiths});
            this.toolStrip1.Location = new System.Drawing.Point(0, 624);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(821, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnSave
            // 
            this.tsbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSave.Image = global::SbnImaging.Properties.Resources.disk;
            this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSave.Name = "tsbtnSave";
            this.tsbtnSave.Size = new System.Drawing.Size(23, 22);
            this.tsbtnSave.Text = "ذخیره";
            this.tsbtnSave.ToolTipText = "ذخیره";
            this.tsbtnSave.Click += new System.EventHandler(this.tsbtnSave_Click);
            // 
            // tsbtnRefresh
            // 
            this.tsbtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRefresh.Image = global::SbnImaging.Properties.Resources.arrow_refresh;
            this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefresh.Name = "tsbtnRefresh";
            this.tsbtnRefresh.Size = new System.Drawing.Size(23, 22);
            this.tsbtnRefresh.Text = "toolStripButton1";
            this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
            // 
            // tsbtnRedo
            // 
            this.tsbtnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRedo.Image = global::SbnImaging.Properties.Resources.arrow_redo;
            this.tsbtnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRedo.Name = "tsbtnRedo";
            this.tsbtnRedo.Size = new System.Drawing.Size(23, 22);
            this.tsbtnRedo.Text = "Redo";
            this.tsbtnRedo.ToolTipText = "Redo(Ctrl+X)";
            this.tsbtnRedo.Visible = false;
            this.tsbtnRedo.Click += new System.EventHandler(this.tsbtnRedo_Click);
            // 
            // tsbtnUndo
            // 
            this.tsbtnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnUndo.Image = global::SbnImaging.Properties.Resources.arrow_undo;
            this.tsbtnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnUndo.Name = "tsbtnUndo";
            this.tsbtnUndo.Size = new System.Drawing.Size(23, 22);
            this.tsbtnUndo.Text = "Undo";
            this.tsbtnUndo.ToolTipText = "Undo(Ctrl+Z)";
            this.tsbtnUndo.Visible = false;
            this.tsbtnUndo.Click += new System.EventHandler(this.tsbtnUndo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsPointer
            // 
            this.tsPointer.CheckOnClick = true;
            this.tsPointer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsPointer.Image = global::SbnImaging.Properties.Resources.cursor;
            this.tsPointer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPointer.Name = "tsPointer";
            this.tsPointer.Size = new System.Drawing.Size(23, 22);
            this.tsPointer.Text = "Pointer";
            this.tsPointer.ToolTipText = "Pointer";
            this.tsPointer.CheckedChanged += new System.EventHandler(this.tsPointer_CheckedChanged);
            this.tsPointer.Click += new System.EventHandler(this.tsPointer_Click);
            // 
            // tsbtnPen
            // 
            this.tsbtnPen.CheckOnClick = true;
            this.tsbtnPen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnPen.Image = global::SbnImaging.Properties.Resources.paintbrush;
            this.tsbtnPen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPen.Name = "tsbtnPen";
            this.tsbtnPen.Size = new System.Drawing.Size(23, 22);
            this.tsbtnPen.Text = "قلم";
            this.tsbtnPen.ToolTipText = "قلم";
            this.tsbtnPen.CheckedChanged += new System.EventHandler(this.tsbtnPen_CheckedChanged);
            this.tsbtnPen.Click += new System.EventHandler(this.tsbtnPen_Click);
            // 
            // tsbtnEraser
            // 
            this.tsbtnEraser.CheckOnClick = true;
            this.tsbtnEraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnEraser.Image = global::SbnImaging.Properties.Resources.eraser;
            this.tsbtnEraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEraser.Name = "tsbtnEraser";
            this.tsbtnEraser.Size = new System.Drawing.Size(23, 22);
            this.tsbtnEraser.Text = "پاک کن";
            this.tsbtnEraser.Visible = false;
            this.tsbtnEraser.CheckedChanged += new System.EventHandler(this.tsbtnEraser_CheckedChanged);
            // 
            // tsbtnClearAll
            // 
            this.tsbtnClearAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnClearAll.Image = global::SbnImaging.Properties.Resources.picture_empty;
            this.tsbtnClearAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClearAll.Name = "tsbtnClearAll";
            this.tsbtnClearAll.Size = new System.Drawing.Size(23, 22);
            this.tsbtnClearAll.Text = "Clear All";
            this.tsbtnClearAll.Click += new System.EventHandler(this.tsbtnClearAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnNewLine
            // 
            this.tsbtnNewLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnNewLine.Image = global::SbnImaging.Properties.Resources.application_go;
            this.tsbtnNewLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNewLine.Name = "tsbtnNewLine";
            this.tsbtnNewLine.Size = new System.Drawing.Size(23, 22);
            this.tsbtnNewLine.Click += new System.EventHandler(this.tsbtnNewLine_Click);
            // 
            // tsbtnAddColumn
            // 
            this.tsbtnAddColumn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnAddColumn.Image = global::SbnImaging.Properties.Resources.application_put;
            this.tsbtnAddColumn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAddColumn.Name = "tsbtnAddColumn";
            this.tsbtnAddColumn.Size = new System.Drawing.Size(23, 22);
            this.tsbtnAddColumn.Click += new System.EventHandler(this.tsbtnAddColumn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnApplay
            // 
            this.tsbtnApplay.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnApplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnApplay.Image = global::SbnImaging.Properties.Resources.tick;
            this.tsbtnApplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnApplay.Name = "tsbtnApplay";
            this.tsbtnApplay.Size = new System.Drawing.Size(23, 22);
            this.tsbtnApplay.Text = "ÊÃííÏ áÇíå ÌÏíÏ";
            this.tsbtnApplay.Click += new System.EventHandler(this.tsbtnApplay_Click);
            // 
            // tsbtnDelete
            // 
            this.tsbtnDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnDelete.Image = global::SbnImaging.Properties.Resources.Delete;
            this.tsbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDelete.Name = "tsbtnDelete";
            this.tsbtnDelete.Size = new System.Drawing.Size(23, 22);
            this.tsbtnDelete.Text = "ÍÐÝ";
            this.tsbtnDelete.ToolTipText = "ÍÐÝ(Delete)";
            this.tsbtnDelete.Click += new System.EventHandler(this.tsbtnDelete_Click);
            // 
            // tsbtnCancel
            // 
            this.tsbtnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCancel.Name = "tsbtnCancel";
            this.tsbtnCancel.Size = new System.Drawing.Size(23, 22);
            this.tsbtnCancel.Text = "ÇäÕÑÇÝ";
            this.tsbtnCancel.Visible = false;
            this.tsbtnCancel.Click += new System.EventHandler(this.tsbtnCancel_Click);
            // 
            // tsbtnPenColor
            // 
            this.tsbtnPenColor.BackColor = System.Drawing.SystemColors.ControlText;
            this.tsbtnPenColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnPenColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPenColor.Name = "tsbtnPenColor";
            this.tsbtnPenColor.Size = new System.Drawing.Size(23, 22);
            this.tsbtnPenColor.Click += new System.EventHandler(this.tsbtnPenColor_Click);
            // 
            // tsddItmPenWiths
            // 
            this.tsddItmPenWiths.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddItmPenWiths.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.penSelectorViewStrip1});
            this.tsddItmPenWiths.Image = ((System.Drawing.Image)(resources.GetObject("tsddItmPenWiths.Image")));
            this.tsddItmPenWiths.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddItmPenWiths.Name = "tsddItmPenWiths";
            this.tsddItmPenWiths.Size = new System.Drawing.Size(80, 22);
            this.tsddItmPenWiths.Text = "ضخامت قلم";
            this.tsddItmPenWiths.DropDownClosed += new System.EventHandler(this.tsddItmPenWiths_DropDownClosed);
            this.tsddItmPenWiths.DropDownOpening += new System.EventHandler(this.tsddItmPenWiths_DropDownOpening);
            this.tsddItmPenWiths.DropDownOpened += new System.EventHandler(this.tsddItmPenWiths_DropDownOpened);
            // 
            // penSelectorViewStrip1
            // 
            this.penSelectorViewStrip1.Name = "penSelectorViewStrip1";
            this.penSelectorViewStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.penSelectorViewStrip1.Size = new System.Drawing.Size(219, 260);
            this.penSelectorViewStrip1.Text = "penSelectorViewStrip1";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.drawingPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 624);
            this.panel1.TabIndex = 1;
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // drawingPanel1
            // 
            this.drawingPanel1.ActiveCursor = System.Windows.Forms.Cursors.Default;
            ghostAppearance1.BackgroundColor1 = System.Drawing.Color.Transparent;
            ghostAppearance1.BackgroundColor2 = System.Drawing.Color.Transparent;
            ghostAppearance1.BorderColor = System.Drawing.Color.Black;
            ghostAppearance1.BorderWidth = 2F;
            ghostAppearance1.GrabberDimension = 6;
            ghostAppearance1.GradientAngle = 0F;
            ghostAppearance1.Image = null;
            ghostAppearance1.MarkerColor = System.Drawing.Color.Black;
            ghostAppearance1.MarkerDimension = 4;
            ghostAppearance1.Shape = null;
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
            ghost1.VerticalVersor = Sbn.FramWork.Drawing.VerticalVersors.BottomTop;
            ghost1.Visible = true;
            pointer1.Ghost = ghost1;
            pointer1.MouseDownPoint = new System.Drawing.Point(0, 0);
            pointer1.MouseUpPoint = new System.Drawing.Point(0, 0);
            this.drawingPanel1.ActiveTool = pointer1;
            this.drawingPanel1.AutoScroll = true;
            this.drawingPanel1.BackColor = System.Drawing.Color.White;
            this.drawingPanel1.ContextMenuStrip = this.contextMenuStrip1;
            this.drawingPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.drawingPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingPanel1.EnableWheelZoom = true;
            this.drawingPanel1.ImageBackColor = System.Drawing.Color.White;
            this.drawingPanel1.ImageBody = null;
            this.drawingPanel1.Location = new System.Drawing.Point(0, 0);
            this.drawingPanel1.Name = "drawingPanel1";
            this.drawingPanel1.Size = new System.Drawing.Size(821, 624);
            this.drawingPanel1.TabIndex = 0;
            this.drawingPanel1.Zoom = 1F;
            this.drawingPanel1.ZoomToCurserPosition = true;
            this.drawingPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingPanel1_MouseDown);
            this.drawingPanel1.Resize += new System.EventHandler(this.drawingPanel1_Resize);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmnuItmUndo,
            this.tsmnuItmRedo,
            this.tsmnuItmDelete,
            this.tsmnuItmRefresh});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(145, 92);
            // 
            // tsmnuItmUndo
            // 
            this.tsmnuItmUndo.Name = "tsmnuItmUndo";
            this.tsmnuItmUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.tsmnuItmUndo.Size = new System.Drawing.Size(144, 22);
            this.tsmnuItmUndo.Text = "Undo";
            this.tsmnuItmUndo.Visible = false;
            this.tsmnuItmUndo.Click += new System.EventHandler(this.tsmnuItmUndo_Click);
            // 
            // tsmnuItmRedo
            // 
            this.tsmnuItmRedo.Name = "tsmnuItmRedo";
            this.tsmnuItmRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.tsmnuItmRedo.Size = new System.Drawing.Size(144, 22);
            this.tsmnuItmRedo.Text = "Redo";
            this.tsmnuItmRedo.Visible = false;
            this.tsmnuItmRedo.Click += new System.EventHandler(this.tsmnuItmRedo_Click);
            // 
            // tsmnuItmDelete
            // 
            this.tsmnuItmDelete.Name = "tsmnuItmDelete";
            this.tsmnuItmDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.tsmnuItmDelete.Size = new System.Drawing.Size(144, 22);
            this.tsmnuItmDelete.Text = "Delete";
            this.tsmnuItmDelete.Click += new System.EventHandler(this.tsmnuItmDelete_Click);
            // 
            // tsmnuItmRefresh
            // 
            this.tsmnuItmRefresh.Name = "tsmnuItmRefresh";
            this.tsmnuItmRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.tsmnuItmRefresh.Size = new System.Drawing.Size(144, 22);
            this.tsmnuItmRefresh.Text = "Refresh";
            this.tsmnuItmRefresh.Click += new System.EventHandler(this.tsmnuItmRefresh_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "pngFile (*.png; )|*.png;|JpegFile(*.jpg;)|*.jpg|All files (*.*)|*.*";
            // 
            // Annotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Annotation";
            this.Size = new System.Drawing.Size(821, 649);
            this.Load += new System.EventHandler(this.Annotation_Load);
            this.VisibleChanged += new System.EventHandler(this.Annotation_VisibleChanged);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sbn.AdvancedControls.Imaging.SbnPaint.DrawingPanel drawingPanel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmnuItmUndo;
        private System.Windows.Forms.ToolStripMenuItem tsmnuItmRedo;
        private System.Windows.Forms.ToolStripMenuItem tsmnuItmDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmnuItmRefresh;
        public System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton tsPointer;
        public System.Windows.Forms.ToolStripButton tsbtnPen;
        public System.Windows.Forms.ToolStripButton tsbtnSave;
        public System.Windows.Forms.ToolStripButton tsbtnNewLine;
        public System.Windows.Forms.ToolStripButton tsbtnEraser;
        public System.Windows.Forms.ToolStripButton tsbtnUndo;
        public System.Windows.Forms.ToolStripButton tsbtnRedo;
        public System.Windows.Forms.ToolStripButton tsbtnRefresh;
        public System.Windows.Forms.ToolStripButton tsbtnClearAll;
        public System.Windows.Forms.ToolStripButton tsbtnCancel;
        public System.Windows.Forms.ToolStripButton tsbtnApplay;
        public System.Windows.Forms.ToolStripButton tsbtnDelete;
        public System.Windows.Forms.ToolStripButton tsbtnPenColor;
        public System.Windows.Forms.ToolStripButton tsbtnAddColumn;
        private System.Windows.Forms.ToolStripDropDownButton tsddItmPenWiths;
        private PenSelectorViewStrip penSelectorViewStrip1;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}
