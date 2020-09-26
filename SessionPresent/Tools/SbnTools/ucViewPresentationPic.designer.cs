using Sbn.Controls.Imaging;
using Sbn.Controls.Imaging.EventArgsFolder;

namespace SessionPresent.Tools.SbnTools
{
    partial class ucViewPresentationPic
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
            Sbn.Controls.Imaging.ThumbnailList thumbnailList1 = null;// new Sbn.Controls.Imaging.ThumbnailList(); comment by ghmhm 960619
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucViewPresentationPic));
            this.thumbnailList1 = new ThumbnailList();
            this.SuspendLayout();
            // 
            // ImageViewer
            // 
            this.ImageViewer.AllowMagnifair = true;
            this.ImageViewer.Size = new System.Drawing.Size(877, 460);
            //thumbnailList1.AllowDrop = true;
            //thumbnailList1.BackColor = System.Drawing.SystemColors.Window;
            //thumbnailList1.Cursor = System.Windows.Forms.Cursors.Default;
            //thumbnailList1.Size = new System.Drawing.Size(132, 485);
            // 
            // thumbnailList1
            // 
            this.thumbnailList1.AllowDrag = true;
            this.thumbnailList1.AllowDrop = true;
            this.thumbnailList1.AllowMoveItem = true;
            this.thumbnailList1.CurrentViewImage = null;
            this.thumbnailList1.Cursor = System.Windows.Forms.Cursors.Default;
            this.thumbnailList1.DefaultImage = ((System.Drawing.Image)(resources.GetObject("thumbnailList1.DefaultImage")));
            this.thumbnailList1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("thumbnailList1.ErrorImage")));
            this.thumbnailList1.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.thumbnailList1.ImagesCollection = null;
            this.thumbnailList1.Location = new System.Drawing.Point(0, 0);
            this.thumbnailList1.Name = "thumbnailList1";
            this.thumbnailList1.Size = new System.Drawing.Size(120, 100);
            this.thumbnailList1.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.thumbnailList1.TabIndex = 0;
            this.thumbnailList1.Text = "";
            // 
            // ucViewPresentationPic
            // 
            this.AllowMagnifair = true;
            this.AllowMoveImage = false;
            this.AllowOpenSaveImage = false;
            this.AllowPrint = false;
            this.AllowRemoveImage = false;
            this.AllowViewContinusePages = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucViewPresentationPic";
            this.Size = new System.Drawing.Size(877, 485);
            this.ThumbnailsView = false;
            this.ThumbsStripLocation = Sbn.Controls.Imaging.StripLocation.Right;
            this.MovedImage += new System.EventHandler<Sbn.Controls.Imaging.EventArgsFolder.ImageEventArgs>(this.ucViewPresentationPic_MovedImage);
            this.Load += new System.EventHandler(this.ucViewPresentationPic_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ThumbnailList thumbnailList1;
    }
}
