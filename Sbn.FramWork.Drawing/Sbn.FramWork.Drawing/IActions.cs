using System;
using System.Windows.Forms;

namespace Sbn.FramWork.Drawing
{
	public interface IActions
	{
		void MouseDown(IDocument document, MouseEventArgs e);

		void MouseUp(IDocument document, MouseEventArgs e);

		void MouseClick(IDocument document, MouseEventArgs e);

		void MouseDoubleClick(IDocument document, MouseEventArgs e);

		void MouseMove(IDocument document, MouseEventArgs e);

		void MouseWheel(IDocument document, MouseEventArgs e);

		void Paint(IDocument document, PaintEventArgs e);
	}
}
