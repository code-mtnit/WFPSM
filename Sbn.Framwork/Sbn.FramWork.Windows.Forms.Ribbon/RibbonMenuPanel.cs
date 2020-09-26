using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms.Ribbon
{
	public class RibbonMenuPanel : Panel
	{
		public enum E_BorderRectangle
		{
			Left,
			Right,
			None,
			All,
			Top,
			Down
		}

		private RibbonMenuPanel.E_BorderRectangle _borderrectangle;

		public RibbonMenuPanel.E_BorderRectangle BorderRectangle
		{
			get
			{
				return this._borderrectangle;
			}
			set
			{
				this._borderrectangle = value;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics graphics = e.Graphics;
			graphics.SmoothingMode = SmoothingMode.Default;
			Rectangle rectangle = new Rectangle(0, 0, base.Width, base.Height);
			Pen white = Pens.White;
			Pen pen = new Pen(Color.FromArgb(155, 175, 202));
			switch (this._borderrectangle)
			{
			case RibbonMenuPanel.E_BorderRectangle.Left:
				graphics.DrawLine(pen, rectangle.X, rectangle.Y, rectangle.X, rectangle.Bottom);
				break;
			case RibbonMenuPanel.E_BorderRectangle.Right:
				graphics.DrawLine(white, rectangle.Width - 1, rectangle.Y, rectangle.Width - 1, rectangle.Height);
				graphics.DrawLine(pen, rectangle.Width - 2, rectangle.Y, rectangle.Width - 2, rectangle.Height);
				break;
			case RibbonMenuPanel.E_BorderRectangle.All:
				graphics.DrawRectangle(white, 0, 0, rectangle.Width - 1, rectangle.Height - 1);
				graphics.DrawRectangle(pen, 1, 1, rectangle.Width - 3, rectangle.Height - 3);
				break;
			case RibbonMenuPanel.E_BorderRectangle.Top:
				graphics.DrawLine(pen, 0, 1, rectangle.Width, 1);
				graphics.DrawLine(white, 0, 2, rectangle.Width, 2);
				break;
			}
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			graphics.SmoothingMode = SmoothingMode.Default;
			Rectangle rectangle = new Rectangle(0, 0, base.Width, base.Height);
			base.OnPaintBackground(e);
		}
	}
}
