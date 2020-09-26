using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms
{
	public class SBNUserControl : UserControl
	{
		private IContainer components = null;

		[ToolboxItem(false)]
		public SBNUserControl()
		{
			this.InitializeComponent();
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
			this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.Name = "SBNUserControl";
			this.RightToLeft = RightToLeft.Yes;
			base.Size = new Size(337, 155);
			base.ResumeLayout(false);
		}
	}
}
