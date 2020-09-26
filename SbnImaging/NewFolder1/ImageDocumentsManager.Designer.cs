using Sbn.Controls.Imaging.EventArgsFolder;

namespace Sbn.Controls.Imaging
{
    partial class ImageDocumentsManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageDocumentsManager));
            this.ImageViewer = new Sbn.Controls.Imaging.ImageDocumentsViewer();
            this.bindingImageNavigator1 = new Sbn.Controls.Imaging.BindingImageNavigator();
            this.thumbnailList1 = new Sbn.Controls.Imaging.ThumbnailList();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageViewer
            // 
            this.ImageViewer.AllowFilip = false;
            this.ImageViewer.AllowMagnifair = false;
            this.ImageViewer.AllowRotate = true;
            this.ImageViewer.AllowViewContinusePages = true;
            this.ImageViewer.AllowZoom = true;
            this.ImageViewer.CurrentFilmstripImage = null;
            this.ImageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageViewer.Location = new System.Drawing.Point(0, 0);
            this.ImageViewer.Name = "ImageViewer";
            this.ImageViewer.Size = new System.Drawing.Size(813, 411);
            this.ImageViewer.TabIndex = 1;
            this.ImageViewer.ViewContinusePages = false;
            this.ImageViewer.ViewOffset = new System.Drawing.Point(0, 0);
            this.ImageViewer.NeedImage += new System.EventHandler<Sbn.Controls.Imaging.EventArgsFolder.ImageEventArg>(this.thumbnailList1_NeedThumbnailsImage);
            // 
            // bindingImageNavigator1
            // 
            this.bindingImageNavigator1.AllowFilipVerticalHorizontal = false;
            this.bindingImageNavigator1.AllowMeargeImage = false;
            this.bindingImageNavigator1.AllowNavigator = true;
            this.bindingImageNavigator1.AllowOpenSaveImage = true;
            this.bindingImageNavigator1.AllowPrint = true;
            this.bindingImageNavigator1.AllowRemoveImage = true;
            this.bindingImageNavigator1.AllowScanImage = false;
            this.bindingImageNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingImageNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingImageNavigator1.ImageViewer = this.ImageViewer;
            this.bindingImageNavigator1.Location = new System.Drawing.Point(0, 411);
            this.bindingImageNavigator1.Name = "bindingImageNavigator1";
            this.bindingImageNavigator1.Size = new System.Drawing.Size(813, 25);
            this.bindingImageNavigator1.TabIndex = 0;
            this.bindingImageNavigator1.Text = "bindingImageNavigator1";
            this.bindingImageNavigator1.Thumbnail = this.thumbnailList1;
            this.bindingImageNavigator1.RotateAntiClockWise += new System.EventHandler<Sbn.Controls.Imaging.EventArgsFolder.ImageEventArg>(this.bindingImageNavigator1_RotateAntiClockWise);
            this.bindingImageNavigator1.RotateClockWise += new System.EventHandler<Sbn.Controls.Imaging.EventArgsFolder.ImageEventArg>(this.bindingImageNavigator1_RotateClockWise);
            this.bindingImageNavigator1.FilipVertical += new System.EventHandler<Sbn.Controls.Imaging.EventArgsFolder.ImageEventArg>(this.bindingImageNavigator1_FilipVertical);
            this.bindingImageNavigator1.FilipHorizontal += new System.EventHandler<Sbn.Controls.Imaging.EventArgsFolder.ImageEventArg>(this.bindingImageNavigator1_FilipHorizontal);
            this.bindingImageNavigator1.SavedImage += new System.EventHandler<Sbn.Controls.Imaging.EventArgsFolder.ImageEventArg>(this.bindingImageNavigator1_SavedImage);
            this.bindingImageNavigator1.SavedAllImage += new System.EventHandler<Sbn.Controls.Imaging.EventArgsFolder.ImageEventArgs>(this.bindingImageNavigator1_SavedAllImage);
            // 
            // thumbnailList1
            // 
            this.thumbnailList1.AllowDrag = true;
            this.thumbnailList1.AllowDuplicateFileNames = true;
            this.thumbnailList1.AllowMoveItem = true;
            this.thumbnailList1.CurrentViewImage = null;
            this.thumbnailList1.Cursor = System.Windows.Forms.Cursors.Default;
            this.thumbnailList1.DefaultImage = ((System.Drawing.Image)(resources.GetObject("thumbnailList1.DefaultImage")));
            this.thumbnailList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thumbnailList1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("thumbnailList1.ErrorImage")));
            this.thumbnailList1.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.thumbnailList1.ImagesCollection = null;
            this.thumbnailList1.Location = new System.Drawing.Point(0, 0);
            this.thumbnailList1.Name = "thumbnailList1";
            this.thumbnailList1.Size = new System.Drawing.Size(813, 136);
            this.thumbnailList1.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.thumbnailList1.TabIndex = 1;
            this.thumbnailList1.Text = "";
            this.thumbnailList1.MovedItems += new Sbn.AdvancedControls.Imaging.ThumbnailControl.MovedItemsEventHandler(this.thumbnailList1_MovedItems);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ImageViewer);
            this.splitContainer1.Panel1.Controls.Add(this.bindingImageNavigator1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.thumbnailList1);
            this.splitContainer1.Size = new System.Drawing.Size(813, 576);
            this.splitContainer1.SplitterDistance = 436;
            this.splitContainer1.TabIndex = 3;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "\"TiffFile (*.tiff; )|*.tiff;|pngFile (*.png; )|*.png;|xmlFile (*.xml; )|*.xml;|Jp" +
                "egFile(*.jpg;)|*.jpg;\"";
            this.saveFileDialog1.RestoreDirectory = true;
            // 
            // ImageDocumentsManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ImageDocumentsManager";
            this.Size = new System.Drawing.Size(813, 576);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BindingImageNavigator bindingImageNavigator1;
        public  ImageDocumentsViewer ImageViewer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ThumbnailList thumbnailList1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        
        
        
    }
}
