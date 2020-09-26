using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms.Ribbon
{
	public class RibbonMenu : ContextMenuStrip
	{
		private int _radius = 5;

		public RibbonMenu()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
			base.SetStyle(ControlStyles.Opaque, false);
			base.BackColor = Color.Transparent;
			base.DropShadowEnabled = true;
			try
			{
				for (int i = 0; i < this.Items.Count; i++)
				{
					int height = this.Items[i].Size.Height;
					this.Items[i].AutoSize = false;
					this.Items[i].Size = new Size(320, height);
				}
			}
			catch
			{
			}
			base.Renderer = new RibbonMenuRenderer();
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);
			GraphicsPath graphicsPath = new GraphicsPath();
			Rectangle re = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
			Graphics graphics = e.Graphics;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			if (re.Size.Width > 5 & re.Size.Height > 5)
			{
				graphicsPath = new GraphicsPath();
				this.DrawArc(re, graphicsPath);
				graphics.FillPath(new SolidBrush(Color.FromArgb(250, 250, 250)), graphicsPath);
				Rectangle rect = new Rectangle(1, 1, 24, base.Height - 3);
				e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(233, 238, 238)), rect);
				e.Graphics.DrawLine(new Pen(Color.FromArgb(197, 197, 197)), rect.Right - 2, 1, rect.Right - 2, rect.Height + 1);
				e.Graphics.DrawLine(new Pen(Color.FromArgb(245, 245, 245)), rect.Right - 1, 1, rect.Right - 1, rect.Height + 1);
				graphics.DrawPath(new Pen(Color.FromArgb(134, 134, 134)), graphicsPath);
				e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(130, 130, 133)), new Rectangle(base.Width - 2, base.Height - 2, 2, 2));
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
		}

		protected override void OnPaintGrip(PaintEventArgs e)
		{
		}

		public void DrawArc(Rectangle re, GraphicsPath pa)
		{
			int radius = this._radius;
			int radius2 = this._radius;
			int radius3 = this._radius;
			int radius4 = this._radius;
			pa.AddArc(re.X, re.Y, radius, radius, 180f, 90f);
			pa.AddArc(re.Width - radius2, re.Y, radius2, radius2, 270f, 90f);
			pa.AddArc(re.Width - radius4, re.Height - radius4, radius4, radius4, 0f, 90f);
			pa.AddArc(re.X, re.Height - radius3, radius3, radius3, 90f, 90f);
			pa.CloseFigure();
		}

		public Rectangle Deflate(Rectangle re)
		{
			return new Rectangle(re.X + 1, re.Y + 1, re.Width - 2, re.Height - 2);
		}
	}
}
