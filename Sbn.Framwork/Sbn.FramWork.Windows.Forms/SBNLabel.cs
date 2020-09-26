using System;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms
{
	public class SBNLabel : Label
	{
		private void InitializeComponent()
		{
			base.SuspendLayout();
			this.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			base.ResumeLayout(false);
		}
	}
}
