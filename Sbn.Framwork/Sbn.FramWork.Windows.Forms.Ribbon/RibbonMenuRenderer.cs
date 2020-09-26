using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms.Ribbon
{
	public class RibbonMenuRenderer : ToolStripProfessionalRenderer
	{
		private int R0 = 255;

		private int G0 = 214;

		private int B0 = 78;

		public Color StrokeColor = Color.FromArgb(196, 177, 118);

		private int offsetx = 3;

		private int offsety = 2;

		private int imageheight = 0;

		private int imagewidth = 0;

		private int _radius = 6;

		protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
		{
			if (e.Item.Selected)
			{
				Graphics graphics = e.Graphics;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				GraphicsPath graphicsPath = new GraphicsPath();
				Rectangle rectangle = new Rectangle(2, 1, e.Item.Size.Width + 20, e.Item.Size.Height - 1);
				this.DrawArc(rectangle, graphicsPath);
				LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, Color.White, Color.White, LinearGradientMode.Vertical);
				float[] positions = new float[]
				{
					0f,
					0.4f,
					0.45f,
					1f
				};
				Color[] colors = new Color[]
				{
					this.GetColor(0, 50, 100),
					this.GetColor(0, 0, 30),
					Color.FromArgb(this.R0, this.G0, this.B0),
					this.GetColor(0, 50, 100)
				};
				linearGradientBrush.InterpolationColors = new ColorBlend
				{
					Colors = colors,
					Positions = positions
				};
				graphics.FillPath(linearGradientBrush, graphicsPath);
				graphics.DrawPath(new Pen(this.StrokeColor), graphicsPath);
				linearGradientBrush.Dispose();
			}
			else
			{
				base.OnRenderItemBackground(e);
			}
		}

		protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			if (e.Image != null)
			{
				this.imageheight = e.Item.Height - this.offsety * 2;
				this.imagewidth = (int)(Convert.ToDouble(this.imageheight) / (double)e.Image.Height * (double)e.Image.Width);
			}
			e.Graphics.DrawImage(e.Image, new Rectangle(this.offsetx, this.offsety, this.imagewidth, this.imageheight));
		}

		protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
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
			return new Rectangle(re.X, re.Y, re.Width - 1, re.Height - 1);
		}

		public Color GetColor(int R, int G, int B)
		{
			if (R + this.R0 > 255)
			{
				R = 255;
			}
			else
			{
				R += this.R0;
			}
			if (G + this.G0 > 255)
			{
				G = 255;
			}
			else
			{
				G += this.G0;
			}
			if (B + this.B0 > 255)
			{
				B = 255;
			}
			else
			{
				B += this.B0;
			}
			return Color.FromArgb(R, G, B);
		}
	}
}
