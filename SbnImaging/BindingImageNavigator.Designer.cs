namespace Sbn.Controls.Imaging
{
    partial class BindingImageNavigator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BindingImageNavigator));
            this.tsbtnOpen = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSaveAs = new System.Windows.Forms.ToolStripButton();
            this.tsbtnGoToFirstItem = new System.Windows.Forms.ToolStripButton();
            this.tsbtnGotoPrevItem = new System.Windows.Forms.ToolStripButton();
            this.tscmbNavigateItems = new System.Windows.Forms.ToolStripComboBox();
            this.tsbtnGoToNextItem = new System.Windows.Forms.ToolStripButton();
            this.tsbtnGoToLastItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRemoveItem = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRemoveAllItems = new System.Windows.Forms.ToolStripButton();
            this.tsbtnScan = new System.Windows.Forms.ToolStripButton();
            this.tsbtnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnMoveNext = new System.Windows.Forms.ToolStripButton();
            this.tsbtnMoveBack = new System.Windows.Forms.ToolStripButton();
            this.tsRotateClockWise = new System.Windows.Forms.ToolStripButton();
            this.tsRotateAntiClockWise = new System.Windows.Forms.ToolStripButton();
            this.tsbtnFilipHorizontal = new System.Windows.Forms.ToolStripButton();
            this.tsbtnFilipVertical = new System.Windows.Forms.ToolStripButton();
            this.tsbtnItmClear = new System.Windows.Forms.ToolStripButton();
            this.tsbtnViewAll = new System.Windows.Forms.ToolStripButton();
            this.tsbtnShowContinusPages = new System.Windows.Forms.ToolStripButton();
            this.tsbtnShowSinglePage = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSlideShow = new System.Windows.Forms.ToolStripButton();
            this.magifierToolsTripButton1 = new Hatefnet.Products.Controls.Magnifier.MagifierToolsTripButton(this.components);
            this.tsmnuItmZoomIn = new System.Windows.Forms.ToolStripButton();
            this.tsmnuItmZoomOut = new System.Windows.Forms.ToolStripButton();
            this.tsbtnItmFitWidth = new System.Windows.Forms.ToolStripButton();
            this.tsbtnItmActualSize = new System.Windows.Forms.ToolStripButton();
            this.tsbtnItmWhole = new System.Windows.Forms.ToolStripButton();
            this.tslblAllPageCount = new System.Windows.Forms.ToolStripLabel();
            this.SuspendLayout();
            // 
            // tsbtnOpen
            // 
            this.tsbtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnOpen.Image = global::SbnImaging.Properties.Resources.open16;
            this.tsbtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpen.Name = "tsbtnOpen";
            this.tsbtnOpen.Size = new System.Drawing.Size(23, 23);
            this.tsbtnOpen.Text = "Open";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.RestoreDirectory = true;
            // 
            // tsbtnSave
            // 
            this.tsbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSave.Image = global::SbnImaging.Properties.Resources.disk;
            this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSave.Name = "tsbtnSave";
            this.tsbtnSave.Size = new System.Drawing.Size(23, 23);
            this.tsbtnSave.Text = "ذخیره سازی";
            // 
            // tsbtnSaveAs
            // 
            this.tsbtnSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSaveAs.Image = global::SbnImaging.Properties.Resources.disk_multiple;
            this.tsbtnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSaveAs.Name = "tsbtnSaveAs";
            this.tsbtnSaveAs.Size = new System.Drawing.Size(23, 23);
            this.tsbtnSaveAs.Text = "ذخیره سازی";
            // 
            // tsbtnGoToFirstItem
            // 
            this.tsbtnGoToFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnGoToFirstItem.Image = global::SbnImaging.Properties.Resources.resultset_first;
            this.tsbtnGoToFirstItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGoToFirstItem.Name = "tsbtnGoToFirstItem";
            this.tsbtnGoToFirstItem.Size = new System.Drawing.Size(23, 23);
            this.tsbtnGoToFirstItem.Text = "اولین";
            // 
            // tsbtnGotoPrevItem
            // 
            this.tsbtnGotoPrevItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnGotoPrevItem.Image = global::SbnImaging.Properties.Resources.resultset_previous;
            this.tsbtnGotoPrevItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGotoPrevItem.Name = "tsbtnGotoPrevItem";
            this.tsbtnGotoPrevItem.Size = new System.Drawing.Size(23, 23);
            this.tsbtnGotoPrevItem.Text = "قبلی";
            // 
            // tscmbNavigateItems
            // 
            this.tscmbNavigateItems.AutoSize = false;
            this.tscmbNavigateItems.DropDownHeight = 300;
            this.tscmbNavigateItems.DropDownWidth = 40;
            this.tscmbNavigateItems.IntegralHeight = false;
            this.tscmbNavigateItems.Name = "tscmbNavigateItems";
            this.tscmbNavigateItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tscmbNavigateItems.Size = new System.Drawing.Size(40, 26);
            // 
            // tsbtnGoToNextItem
            // 
            this.tsbtnGoToNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnGoToNextItem.Image = global::SbnImaging.Properties.Resources.resultset_next;
            this.tsbtnGoToNextItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGoToNextItem.Name = "tsbtnGoToNextItem";
            this.tsbtnGoToNextItem.Size = new System.Drawing.Size(23, 23);
            this.tsbtnGoToNextItem.Text = "بعدی";
            // 
            // tsbtnGoToLastItem
            // 
            this.tsbtnGoToLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnGoToLastItem.Image = global::SbnImaging.Properties.Resources.resultset_last;
            this.tsbtnGoToLastItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGoToLastItem.Name = "tsbtnGoToLastItem";
            this.tsbtnGoToLastItem.Size = new System.Drawing.Size(23, 23);
            this.tsbtnGoToLastItem.Text = "آخرین";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // tsbtnRemoveItem
            // 
            this.tsbtnRemoveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRemoveItem.Image = global::SbnImaging.Properties.Resources.image_delete;
            this.tsbtnRemoveItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRemoveItem.Name = "tsbtnRemoveItem";
            this.tsbtnRemoveItem.Size = new System.Drawing.Size(23, 23);
            this.tsbtnRemoveItem.Text = "حذف";
            // 
            // tsbtnRemoveAllItems
            // 
            this.tsbtnRemoveAllItems.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRemoveAllItems.Image = global::SbnImaging.Properties.Resources.image_delete;
            this.tsbtnRemoveAllItems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRemoveAllItems.Name = "tsbtnRemoveAllItems";
            this.tsbtnRemoveAllItems.Size = new System.Drawing.Size(23, 23);
            this.tsbtnRemoveAllItems.Text = "حذف تمام تصاویر";
            this.tsbtnRemoveAllItems.Visible = false;
            // 
            // tsbtnScan
            // 
            this.tsbtnScan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnScan.Image = global::SbnImaging.Properties.Resources.briefcase1;
            this.tsbtnScan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnScan.Name = "tsbtnScan";
            this.tsbtnScan.Size = new System.Drawing.Size(23, 23);
            this.tsbtnScan.Text = "اسکن";
            // 
            // tsbtnPrint
            // 
            this.tsbtnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnPrint.Image = global::SbnImaging.Properties.Resources.printer;
            this.tsbtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPrint.Name = "tsbtnPrint";
            this.tsbtnPrint.Size = new System.Drawing.Size(23, 23);
            this.tsbtnPrint.Text = "چاپ";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // tsbtnMoveNext
            // 
            this.tsbtnMoveNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnMoveNext.Image = global::SbnImaging.Properties.Resources.picture_go;
            this.tsbtnMoveNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnMoveNext.Name = "tsbtnMoveNext";
            this.tsbtnMoveNext.Size = new System.Drawing.Size(23, 23);
            this.tsbtnMoveNext.Text = "جابه جایی به جلو";
            this.tsbtnMoveNext.Visible = false;
            // 
            // tsbtnMoveBack
            // 
            this.tsbtnMoveBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnMoveBack.Image = global::SbnImaging.Properties.Resources.picture_go_Back;
            this.tsbtnMoveBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnMoveBack.Name = "tsbtnMoveBack";
            this.tsbtnMoveBack.Size = new System.Drawing.Size(23, 23);
            this.tsbtnMoveBack.Text = "جابه جایی به عقب";
            this.tsbtnMoveBack.Visible = false;
            // 
            // tsRotateClockWise
            // 
            this.tsRotateClockWise.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsRotateClockWise.Image = global::SbnImaging.Properties.Resources.shape_rotate_clockwise;
            this.tsRotateClockWise.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRotateClockWise.Name = "tsRotateClockWise";
            this.tsRotateClockWise.Size = new System.Drawing.Size(23, 23);
            this.tsRotateClockWise.Text = "چرخش ساعتگرد";
            // 
            // tsRotateAntiClockWise
            // 
            this.tsRotateAntiClockWise.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsRotateAntiClockWise.Image = global::SbnImaging.Properties.Resources.shape_rotate_anticlockwise;
            this.tsRotateAntiClockWise.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRotateAntiClockWise.Name = "tsRotateAntiClockWise";
            this.tsRotateAntiClockWise.Size = new System.Drawing.Size(23, 23);
            this.tsRotateAntiClockWise.Text = "چرخش پادساعتگرد";
            // 
            // tsbtnFilipHorizontal
            // 
            this.tsbtnFilipHorizontal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnFilipHorizontal.Image = global::SbnImaging.Properties.Resources.shape_flip_horizontal;
            this.tsbtnFilipHorizontal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFilipHorizontal.Name = "tsbtnFilipHorizontal";
            this.tsbtnFilipHorizontal.Size = new System.Drawing.Size(23, 23);
            this.tsbtnFilipHorizontal.Text = "افقی";
            this.tsbtnFilipHorizontal.Visible = false;
            // 
            // tsbtnFilipVertical
            // 
            this.tsbtnFilipVertical.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnFilipVertical.Image = global::SbnImaging.Properties.Resources.shape_flip_vertical;
            this.tsbtnFilipVertical.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFilipVertical.Name = "tsbtnFilipVertical";
            this.tsbtnFilipVertical.Size = new System.Drawing.Size(23, 23);
            this.tsbtnFilipVertical.Text = "عمودی";
            this.tsbtnFilipVertical.Visible = false;
            // 
            // tsbtnItmClear
            // 
            this.tsbtnItmClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnItmClear.Image = global::SbnImaging.Properties.Resources.picture_empty;
            this.tsbtnItmClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnItmClear.Name = "tsbtnItmClear";
            this.tsbtnItmClear.Size = new System.Drawing.Size(23, 23);
            this.tsbtnItmClear.Text = "Clear";
            this.tsbtnItmClear.ToolTipText = "پاك كردن تمام تصاوير";
            this.tsbtnItmClear.Visible = false;
            // 
            // tsbtnViewAll
            // 
            this.tsbtnViewAll.CheckOnClick = true;
            this.tsbtnViewAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnViewAll.Image = global::SbnImaging.Properties.Resources.pictures;
            this.tsbtnViewAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnViewAll.Name = "tsbtnViewAll";
            this.tsbtnViewAll.Size = new System.Drawing.Size(23, 23);
            this.tsbtnViewAll.Text = "ViewAll";
            this.tsbtnViewAll.ToolTipText = "نمايش تصاوير";
            this.tsbtnViewAll.Visible = false;
            // 
            // tsbtnShowContinusPages
            // 
            this.tsbtnShowContinusPages.CheckOnClick = true;
            this.tsbtnShowContinusPages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnShowContinusPages.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnShowContinusPages.Image")));
            this.tsbtnShowContinusPages.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnShowContinusPages.Name = "tsbtnShowContinusPages";
            this.tsbtnShowContinusPages.Size = new System.Drawing.Size(23, 23);
            this.tsbtnShowContinusPages.Text = "نمایش پیوسته صفحات";
            this.tsbtnShowContinusPages.Visible = false;
            // 
            // tsbtnShowSinglePage
            // 
            this.tsbtnShowSinglePage.Checked = true;
            this.tsbtnShowSinglePage.CheckOnClick = true;
            this.tsbtnShowSinglePage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbtnShowSinglePage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnShowSinglePage.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnShowSinglePage.Image")));
            this.tsbtnShowSinglePage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnShowSinglePage.Name = "tsbtnShowSinglePage";
            this.tsbtnShowSinglePage.Size = new System.Drawing.Size(23, 23);
            this.tsbtnShowSinglePage.Text = "نمایش تک صفحه";
            this.tsbtnShowSinglePage.Visible = false;
            // 
            // tsbtnSlideShow
            // 
            this.tsbtnSlideShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSlideShow.Image = global::SbnImaging.Properties.Resources._134_copy24;
            this.tsbtnSlideShow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSlideShow.Name = "tsbtnSlideShow";
            this.tsbtnSlideShow.Size = new System.Drawing.Size(23, 23);
            this.tsbtnSlideShow.Text = " نمایش اسلاید";
            this.tsbtnSlideShow.Visible = false;
            // 
            // magifierToolsTripButton1
            // 
            this.magifierToolsTripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.magifierToolsTripButton1.Image = global::SbnImaging.Properties.Resources.page_white_magnify;
            this.magifierToolsTripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.magifierToolsTripButton1.Name = "magifierToolsTripButton1";
            this.magifierToolsTripButton1.Size = new System.Drawing.Size(23, 23);
            this.magifierToolsTripButton1.Text = "ذره بین";
            this.magifierToolsTripButton1.Visible = false;
            // 
            // tsmnuItmZoomIn
            // 
            this.tsmnuItmZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmnuItmZoomIn.Image = global::SbnImaging.Properties.Resources.magnifier_zoom_in;
            this.tsmnuItmZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmnuItmZoomIn.Name = "tsmnuItmZoomIn";
            this.tsmnuItmZoomIn.Size = new System.Drawing.Size(23, 23);
            this.tsmnuItmZoomIn.Text = "ZoomIn";
            this.tsmnuItmZoomIn.ToolTipText = "نماي نزديكتر";
            // 
            // tsmnuItmZoomOut
            // 
            this.tsmnuItmZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmnuItmZoomOut.Image = global::SbnImaging.Properties.Resources.magifier_zoom_out;
            this.tsmnuItmZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmnuItmZoomOut.Name = "tsmnuItmZoomOut";
            this.tsmnuItmZoomOut.Size = new System.Drawing.Size(23, 23);
            this.tsmnuItmZoomOut.Text = "ZoomOut";
            this.tsmnuItmZoomOut.ToolTipText = "نماي دورتر";
            // 
            // tsbtnItmFitWidth
            // 
            this.tsbtnItmFitWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnItmFitWidth.Image = global::SbnImaging.Properties.Resources.showFitWidth;
            this.tsbtnItmFitWidth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnItmFitWidth.Name = "tsbtnItmFitWidth";
            this.tsbtnItmFitWidth.Size = new System.Drawing.Size(23, 23);
            this.tsbtnItmFitWidth.Text = "FitWidth";
            this.tsbtnItmFitWidth.ToolTipText = "متناسب با عرض تصوير";
            // 
            // tsbtnItmActualSize
            // 
            this.tsbtnItmActualSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnItmActualSize.Image = global::SbnImaging.Properties.Resources.showActualSize;
            this.tsbtnItmActualSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnItmActualSize.Name = "tsbtnItmActualSize";
            this.tsbtnItmActualSize.Size = new System.Drawing.Size(23, 23);
            this.tsbtnItmActualSize.Text = "ActualSize";
            this.tsbtnItmActualSize.ToolTipText = "اندازه واقعي";
            // 
            // tsbtnItmWhole
            // 
            this.tsbtnItmWhole.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnItmWhole.Image = global::SbnImaging.Properties.Resources.showWhole;
            this.tsbtnItmWhole.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnItmWhole.Name = "tsbtnItmWhole";
            this.tsbtnItmWhole.Size = new System.Drawing.Size(23, 23);
            this.tsbtnItmWhole.Text = "toolStripButton1";
            this.tsbtnItmWhole.ToolTipText = "اندازه قابل رؤيت بصورت كامل";
            // 
            // tslblAllPageCount
            // 
            this.tslblAllPageCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tslblAllPageCount.Name = "tslblAllPageCount";
            this.tslblAllPageCount.Size = new System.Drawing.Size(19, 23);
            this.tslblAllPageCount.Text = "/0";
            // 
            // BindingImageNavigator
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnOpen,
            this.tsbtnSave,
            this.tsbtnSaveAs,
            this.tsbtnScan,
            this.tsbtnPrint,
            this.tsbtnRemoveItem,
            this.tsbtnRemoveAllItems,
            this.magifierToolsTripButton1,
            this.tsbtnItmFitWidth,
            this.tsbtnItmWhole,
            this.tsbtnItmActualSize,
            this.tsmnuItmZoomOut,
            this.tsmnuItmZoomIn,
            this.tsbtnFilipVertical,
            this.tsbtnFilipHorizontal,
            this.tsRotateAntiClockWise,
            this.tsRotateClockWise,
            this.toolStripSeparator1,
            this.tsbtnGoToFirstItem,
            this.tsbtnGotoPrevItem,
            this.tscmbNavigateItems,
            this.tslblAllPageCount,
            this.tsbtnGoToNextItem,
            this.tsbtnGoToLastItem,
            this.toolStripSeparator2,
            this.tsbtnMoveBack,
            this.tsbtnMoveNext,
            this.tsbtnSlideShow,
            this.tsbtnShowSinglePage,
            this.tsbtnShowContinusPages,
            this.tsbtnViewAll,
            this.tsbtnItmClear});
            this.Size = new System.Drawing.Size(914, 26);
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.ToolStripButton tsbtnOpen;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripButton tsbtnSave;
        private System.Windows.Forms.ToolStripButton tsbtnSaveAs;
        private System.Windows.Forms.ToolStripButton tsbtnGoToFirstItem;
        private System.Windows.Forms.ToolStripButton tsbtnGotoPrevItem;
        private System.Windows.Forms.ToolStripComboBox tscmbNavigateItems;
        private System.Windows.Forms.ToolStripButton tsbtnGoToNextItem;
        private System.Windows.Forms.ToolStripButton tsbtnGoToLastItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnRemoveItem;
        private System.Windows.Forms.ToolStripButton tsbtnRemoveAllItems;
        private System.Windows.Forms.ToolStripButton tsbtnScan;
        private System.Windows.Forms.ToolStripButton tsbtnPrint;
        
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnMoveNext;
        private System.Windows.Forms.ToolStripButton tsbtnMoveBack;
        private System.Windows.Forms.ToolStripButton tsRotateClockWise;
        private System.Windows.Forms.ToolStripButton tsRotateAntiClockWise;
        private System.Windows.Forms.ToolStripButton tsbtnFilipHorizontal;
        private System.Windows.Forms.ToolStripButton tsbtnFilipVertical;
        public System.Windows.Forms.ToolStripButton tsbtnItmClear;
        public System.Windows.Forms.ToolStripButton tsbtnViewAll;
        public System.Windows.Forms.ToolStripButton tsbtnShowContinusPages;
        private System.Windows.Forms.ToolStripButton tsbtnShowSinglePage;
        private System.Windows.Forms.ToolStripButton tsbtnSlideShow;
        private Hatefnet.Products.Controls.Magnifier.MagifierToolsTripButton magifierToolsTripButton1;
        public System.Windows.Forms.ToolStripButton tsmnuItmZoomIn;
        public System.Windows.Forms.ToolStripButton tsmnuItmZoomOut;
        public System.Windows.Forms.ToolStripButton tsbtnItmFitWidth;
        public System.Windows.Forms.ToolStripButton tsbtnItmActualSize;
        public System.Windows.Forms.ToolStripButton tsbtnItmWhole;
        private System.Windows.Forms.ToolStripLabel tslblAllPageCount;



    }
}
