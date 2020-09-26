using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms.ToolStripFolder.Renderer
{
	public class AeroglassRenderer : ToolStripProfessionalRenderer
	{
		protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
		{
			if (e.ToolStrip.IsDropDown)
			{
				base.OnRenderToolStripBackground(e);
			}
			else
			{
				e.Graphics.Clear(Color.Transparent);
			}
		}

		protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
		{
			if (e.ToolStrip.IsDropDown)
			{
				base.OnRenderToolStripBorder(e);
			}
		}

		protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
		{
			if (e.ToolStrip.IsDropDown)
			{
				base.OnRenderItemText(e);
			}
			else
			{
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddString(e.Text, e.TextFont.FontFamily, (int)e.TextFont.Style, e.TextFont.Size + 2f, e.TextRectangle.Location, new StringFormat());
				e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				e.Graphics.FillPath(Brushes.Black, graphicsPath);
				graphicsPath.Dispose();
			}
		}

		protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
		{
			if (e.Item.Selected)
			{
				e.Graphics.Clear(Color.FromArgb(20, Color.Navy));
			}
			Rectangle empty = Rectangle.Empty;
			if (e.Item.RightToLeft == RightToLeft.Yes)
			{
				empty = new Rectangle(0, e.Item.Height - 8, 9, 5);
			}
			else
			{
				empty = new Rectangle(e.Item.Width - 12, e.Item.Height - 16, 9, 5);
			}
			base.DrawArrow(new ToolStripArrowRenderEventArgs(e.Graphics, e.Item, empty, SystemColors.ControlText, ArrowDirection.Down));
			e.Graphics.DrawLine(SystemPens.ControlText, empty.Right - 7, empty.Y - 2, empty.Right - 3, empty.Y - 2);
		}
	}
}
