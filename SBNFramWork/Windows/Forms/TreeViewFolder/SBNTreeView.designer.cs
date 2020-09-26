using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SearchableControls;

namespace Sbn.FramWork.Windows.Forms
{
    partial class SBNTreeView
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
        private void InitializeComponent()
        {

            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findDialog1 = new SearchableControls.FindDialog();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip.ShowImageMargin = false;
            this.contextMenuStrip.Size = new System.Drawing.Size(81, 26);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(80, 22);
            this.findToolStripMenuItem.Text = "&Find";
            // 
            // findDialog1
            // 
            this.findDialog1.ParentControl = this;
            this.findDialog1.ReplaceAvailable = false;
            this.findDialog1.SearchRegularExpression = null;
            this.findDialog1.SearchRequested += new SearchableControls.SearchEventHandler(this.findDialog1_SearchRequested);
            // 
            // SBNTreeView
            // 
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ContextMenuStrip = this.contextMenuStrip;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchableTreeView_KeyDown);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);


        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private FindDialog findDialog1;
    }
}
