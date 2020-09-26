namespace Sbn.Controls.Imaging
{
    partial class ThumbnailList
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
            this.SuspendLayout();
            // 
            // ThumbnailList
            // 
            this.ItemClick += new Sbn.AdvancedControls.Imaging.ThumbnailControl.ItemClickEventHandler(this.ThumbnailList_ItemClick);
            this.SelectionChanged += new System.EventHandler(this.ThumbnailList_SelectionChanged);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
