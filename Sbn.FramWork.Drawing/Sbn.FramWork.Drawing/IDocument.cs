using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sbn.FramWork.Drawing
{
	public interface IDocument
	{
		Control DrawingControl
		{
			get;
		}

		ShapeCollection Shapes
		{
			get;
		}

		Cursor ActiveCursor
		{
			get;
			set;
		}

		Tool ActiveTool
		{
			get;
		}

		GridManager GridManager
		{
			get;
		}

		Color ImageBackColor
		{
			get;
			set;
		}

		Pen CurrentPen
		{
			get;
			set;
		}
	}
}
