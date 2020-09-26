using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms
{
	public class SBNForm : Form
	{
		public delegate void LoadCompletedEventHandler();

		private IContainer components = null;

		public event SBNForm.LoadCompletedEventHandler LoadCompleted;

		public SBNForm()
		{
			this.InitializeComponent();
			base.Shown += new EventHandler(this.BaseForm_Shown);
		}

		private void BaseForm_Shown(object sender, EventArgs e)
		{
			Application.DoEvents();
			if (this.LoadCompleted != null)
			{
				this.LoadCompleted();
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(815, 438);
			this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.Name = "SBNForm";
			this.RightToLeft = RightToLeft.Yes;
			this.Text = "Form";
			base.ResumeLayout(false);
		}
	}
}
