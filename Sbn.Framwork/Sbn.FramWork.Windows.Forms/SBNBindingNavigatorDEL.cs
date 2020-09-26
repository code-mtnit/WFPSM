using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms
{
	public class SBNBindingNavigatorDEL : BindingNavigator
	{
		private IContainer components = null;

		public SBNBindingNavigatorDEL()
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
			this.RightToLeft = RightToLeft.Yes;
			base.ResumeLayout(false);
		}
	}
}
