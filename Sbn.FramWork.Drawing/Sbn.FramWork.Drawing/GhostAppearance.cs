using Sbn.FramWork.Drawing.Serialization;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sbn.FramWork.Drawing
{
	[XmlClassSerializable("ghostAppearance")]
	public class GhostAppearance : PolygonAppearance
	{
		public GhostAppearance()
		{
		}

		public GhostAppearance(GhostAppearance ghostAppearance) : base(ghostAppearance)
		{
		}

		public override object Clone()
		{
			return new GhostAppearance(this);
		}

		protected override void DrawSelection(IDocument document, PaintEventArgs e)
		{
			if (base.Shape.Visible && base.IsValidGeometric(base.Shape.Geometric))
			{
				Rectangle rectangle = Rectangle.Round(base.Shape.Geometric.GetBounds());
				Rectangle insideRect = rectangle;
				rectangle.Inflate(base.GrabberDimension / 2, base.GrabberDimension / 2);
				insideRect.Inflate(-base.GrabberDimension / 2, -base.GrabberDimension / 2);
				ControlPaint.DrawSelectionFrame(e.Graphics, true, rectangle, insideRect, document.DrawingControl.BackColor);
			}
		}

		protected virtual void UpdateActivePen(Color backColor)
		{
			base.ActivePen = new Pen(Color.Black, 2f);
		}
	}
}
