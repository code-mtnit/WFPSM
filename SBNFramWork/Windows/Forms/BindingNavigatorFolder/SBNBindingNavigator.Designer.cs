using System;

namespace Sbn.FramWork.Windows.Forms
{
    partial class SBNBindingNavigator
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
            this.tsbtnMoveFirst = new System.Windows.Forms.ToolStripButton();
            this.tsbtnMovePrevious = new System.Windows.Forms.ToolStripButton();
            this.tstxtPosition = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslblCountItem = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.tsbtnMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.SuspendLayout();
            // 
            // tsbtnMoveFirst
            // 
            this.tsbtnMoveFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnMoveFirst.Enabled = false;
            this.tsbtnMoveFirst.Image = global::Sbn.FramWork.Properties.Resources.hide_right16;
            this.tsbtnMoveFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnMoveFirst.Name = "tsbtnMoveFirst";
            this.tsbtnMoveFirst.Size = new System.Drawing.Size(23, 22);
            this.tsbtnMoveFirst.Text = "اولین";
            // 
            // tsbtnMovePrevious
            // 
            this.tsbtnMovePrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnMovePrevious.Enabled = false;
            this.tsbtnMovePrevious.Image = global::Sbn.FramWork.Properties.Resources.navigate_right16;
            this.tsbtnMovePrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnMovePrevious.Name = "tsbtnMovePrevious";
            this.tsbtnMovePrevious.Size = new System.Drawing.Size(23, 22);
            this.tsbtnMovePrevious.Text = "قبلی";
            // 
            // tstxtPosition
            // 
            this.tstxtPosition.Name = "tstxtPosition";
            this.tstxtPosition.Size = new System.Drawing.Size(50, 23);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tslblCountItem
            // 
            this.tslblCountItem.Name = "tslblCountItem";
            this.tslblCountItem.Size = new System.Drawing.Size(36, 15);
            this.tslblCountItem.Text = "از {0 }";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 6);
            // 
            // tsbtnMoveNextItem
            // 
            this.tsbtnMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnMoveNextItem.Enabled = false;
            this.tsbtnMoveNextItem.Image = global::Sbn.FramWork.Properties.Resources.navigate_left16;
            this.tsbtnMoveNextItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnMoveNextItem.Name = "tsbtnMoveNextItem";
            this.tsbtnMoveNextItem.Size = new System.Drawing.Size(23, 20);
            this.tsbtnMoveNextItem.Text = "بعدی";
            // 
            // tsbtnMoveLastItem
            // 
            this.tsbtnMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnMoveLastItem.Enabled = false;
            this.tsbtnMoveLastItem.Image = global::Sbn.FramWork.Properties.Resources.hide_left16;
            this.tsbtnMoveLastItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnMoveLastItem.Name = "tsbtnMoveLastItem";
            this.tsbtnMoveLastItem.Size = new System.Drawing.Size(23, 20);
            this.tsbtnMoveLastItem.Text = "آخرین";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 6);
            // 
            // SBNBindingNavigator
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnMoveFirst,
            this.tsbtnMovePrevious,
            this.toolStripSeparator1,
            this.tstxtPosition,
            this.tslblCountItem,
            this.toolStripSeparator2,
            this.tsbtnMoveNextItem,
            this.tsbtnMoveLastItem,
            this.toolStripSeparator3});
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton tsbtnMoveFirst;
        private System.Windows.Forms.ToolStripButton tsbtnMovePrevious;
        private System.Windows.Forms.ToolStripTextBox tstxtPosition;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tslblCountItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnMoveNextItem;
        private System.Windows.Forms.ToolStripButton tsbtnMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}
