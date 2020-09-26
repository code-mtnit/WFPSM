using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms.Ribbon
{
	public class RibbonCommandButton : Button
	{
		public enum mycommands
		{
			Maximize,
			Minimize,
			Close,
			Try
		}

		public enum mystates
		{
			Out,
			On,
			OnClick
		}

		private RibbonCommandButton.mycommands _command;

		private RibbonCommandButton.mystates _state;

		private Color _baseColor = Color.FromArgb(122, 141, 167);

		private Color _blackColor = Color.FromArgb(101, 101, 101);

		private Color _whiteColor = Color.FromArgb(248, 249, 250);

		private Color _onColor = Color.FromArgb(237, 245, 255);

		private Color _pressColor = Color.FromArgb(155, 192, 228);

		private int _radius = 6;

		public RibbonCommandButton.mycommands Command
		{
			get
			{
				return this._command;
			}
			set
			{
				this._command = value;
			}
		}

		public Color ColorBase
		{
			get
			{
				return this._baseColor;
			}
			set
			{
				this._baseColor = value;
			}
		}

		public Color ColorBlack
		{
			get
			{
				return this._blackColor;
			}
			set
			{
				this._blackColor = value;
			}
		}

		public Color ColorWhite
		{
			get
			{
				return this._whiteColor;
			}
			set
			{
				this._whiteColor = value;
			}
		}

		public Color ColorOn
		{
			get
			{
				return this._onColor;
			}
			set
			{
				this._onColor = value;
			}
		}

		public Color ColorPress
		{
			get
			{
				return this._pressColor;
			}
			set
			{
				this._pressColor = value;
			}
		}

		public RibbonCommandButton()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.DoubleBuffer, true);
			base.SetStyle(ControlStyles.Opaque, false);
			base.FlatAppearance.BorderSize = 0;
			base.FlatStyle = FlatStyle.Flat;
			this.BackColor = Color.Transparent;
			base.TextImageRelation = TextImageRelation.ImageAboveText;
			this.Text = "";
			base.Size = new Size(25, 25);
			this._command = RibbonCommandButton.mycommands.Maximize;
			this._state = RibbonCommandButton.mystates.Out;
			this._state = RibbonCommandButton.mystates.Out;
		}

		public Color GetColor(Color _color, int r, int g, int b)
		{
			int red;
			if (r + (int)_color.R > 255)
			{
				red = 255;
			}
			else if (r + (int)_color.R < 0)
			{
				red = 0;
			}
			else
			{
				red = r + (int)_color.R;
			}
			int green;
			if (g + (int)_color.G > 255)
			{
				green = 255;
			}
			else if (g + (int)_color.G < 0)
			{
				green = 0;
			}
			else
			{
				green = g + (int)_color.G;
			}
			int blue;
			if (b + (int)_color.B > 255)
			{
				blue = 255;
			}
			else if (b + (int)_color.B < 0)
			{
				blue = 0;
			}
			else
			{
				blue = b + (int)_color.B;
			}
			return Color.FromArgb((int)_color.A, red, green, blue);
		}

		protected override void OnPaint(PaintEventArgs pevent)
		{
			Graphics graphics = pevent.Graphics;
			Rectangle rectangle = new Rectangle(new Point(-1, -1), new Size(base.Width + this._radius, base.Height + this._radius));
			graphics.SmoothingMode = SmoothingMode.Default;
			Size arg_44_0 = base.Size;
			bool flag = 1 == 0;
			GraphicsPath graphicsPath = new GraphicsPath();
			this.DrawArc(rectangle, graphicsPath);
			base.Region = new Region(graphicsPath);
			switch (this._state)
			{
			case RibbonCommandButton.mystates.On:
			{
				Rectangle rect = new Rectangle(1, 1, base.Width / 2, base.Height - 1);
				Color color = this.SetTransparency(this._whiteColor, 255);
				Color color2 = this.SetTransparency(this.GetColor(this._onColor, -27, -17, 0), 200);
				LinearGradientBrush brush = new LinearGradientBrush(rect, color, color2, LinearGradientMode.BackwardDiagonal);
				graphics.FillRectangle(brush, 1, 1, rect.Width - 1, rect.Height - 1);
				rect = new Rectangle(base.Width / 2, 0, base.Width / 2, base.Height);
				brush = new LinearGradientBrush(rect, color, color2, LinearGradientMode.ForwardDiagonal);
				graphics.FillRectangle(brush, base.Width / 2, 1, rect.Width, rect.Height - 2);
				graphics.FillRectangle(new SolidBrush(Color.FromArgb(100, this._whiteColor)), 1, 1, base.Width - 2, base.Height / 2);
				GraphicsPath graphicsPath2 = new GraphicsPath();
				Rectangle re = new Rectangle(new Point(0, 0), new Size(base.Width - 1, base.Height - 1));
				this.DrawArc(re, graphicsPath2);
				graphics.DrawPath(new Pen(Color.FromArgb(100, this._baseColor)), graphicsPath2);
				graphicsPath2 = new GraphicsPath();
				re = new Rectangle(new Point(1, 1), new Size(base.Width - 2, base.Height - 2));
				this.DrawArc(re, graphicsPath2);
				graphics.DrawPath(new Pen(this._whiteColor), graphicsPath2);
				break;
			}
			case RibbonCommandButton.mystates.OnClick:
			{
				Rectangle rect = new Rectangle(1, 1, base.Width / 2, base.Height - 1);
				Color color = this.SetTransparency(this._whiteColor, 255);
				Color color2 = this.SetTransparency(this.GetColor(this._onColor, -27, -17, 0), 200);
				LinearGradientBrush brush = new LinearGradientBrush(rect, color, color2, LinearGradientMode.BackwardDiagonal);
				graphics.FillRectangle(brush, 1, 1, rect.Width - 1, rect.Height - 1);
				rect = new Rectangle(base.Width / 2, 0, base.Width / 2, base.Height);
				brush = new LinearGradientBrush(rect, color, color2, LinearGradientMode.ForwardDiagonal);
				graphics.FillRectangle(brush, base.Width / 2, 1, rect.Width - 1, rect.Height - 2);
				GraphicsPath graphicsPath2 = new GraphicsPath();
				Rectangle re = new Rectangle(new Point(0, 0), new Size(base.Width - 1, base.Height - 1));
				this.DrawArc(re, graphicsPath2);
				graphics.DrawPath(new Pen(Color.FromArgb(100, this._baseColor)), graphicsPath2);
				graphicsPath2 = new GraphicsPath();
				re = new Rectangle(new Point(1, 1), new Size(base.Width - 2, base.Height - 2));
				this.DrawArc(re, graphicsPath2);
				graphics.DrawPath(new Pen(this._whiteColor), graphicsPath2);
				graphics.FillRectangle(new SolidBrush(Color.FromArgb(100, this._pressColor)), 1, 1, base.Width - 2, base.Height / 2 - 1);
				graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, this._pressColor)), 1, base.Height / 2, base.Width - 2, base.Height / 2 - 1);
				break;
			}
			}
			try
			{
				int num = 6;
				rectangle = new Rectangle(new Point(0, 0), base.Size);
				switch (this._command)
				{
				case RibbonCommandButton.mycommands.Maximize:
				{
					int num2 = 14;
					Pen pen = new Pen(this._baseColor, 1f);
					Point point = new Point(7, rectangle.Height - num2);
					Point pt = new Point(rectangle.Width - 9, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					num2--;
					point = new Point(7, rectangle.Height - num2);
					Rectangle rect2 = new Rectangle(point, new Size(rectangle.Width - 15, 6));
					LinearGradientBrush brush2 = new LinearGradientBrush(rect2, this._baseColor, this._baseColor, LinearGradientMode.Vertical);
					graphics.FillRectangle(brush2, rect2);
					num2 = 7;
					pen = new Pen(this._whiteColor, 1f);
					point = new Point(7, rectangle.Height - num2);
					pt = new Point(rectangle.Width - 9, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					num2 = 11;
					pen = new Pen(this._whiteColor, 1f);
					point = new Point(8, rectangle.Height - num2);
					pt = new Point(rectangle.Width - 10, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					num2--;
					pen = new Pen(this._onColor, 1f);
					point = new Point(8, rectangle.Height - num2);
					pt = new Point(rectangle.Width - 10, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					num2--;
					pen = new Pen(this._onColor, 1f);
					point = new Point(8, rectangle.Height - num2);
					pt = new Point(rectangle.Width - 10, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					break;
				}
				case RibbonCommandButton.mycommands.Minimize:
				{
					int num2 = 9;
					Pen pen = new Pen(this._blackColor, 1f);
					Point point = new Point(7, rectangle.Height - num2);
					Point pt = new Point(rectangle.Width - 9, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					num2--;
					pen = new Pen(this._baseColor, 1f);
					point = new Point(7, rectangle.Height - num2);
					pt = new Point(rectangle.Width - 9, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					num2--;
					pen = new Pen(this._whiteColor, 1f);
					point = new Point(7, rectangle.Height - num2);
					pt = new Point(rectangle.Width - 9, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					break;
				}
				case RibbonCommandButton.mycommands.Close:
				{
					int num2 = 14;
					int num3 = 8;
					Pen pen = new Pen(this._blackColor, 1f);
					Point point = new Point(num3, rectangle.Height - num2);
					Point pt = new Point(num3 + 2, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					point = new Point(num3 + num, rectangle.Height - num2);
					pt = new Point(num3 + 2 + num, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					num2--;
					num3++;
					num = 4;
					pen = new Pen(this._blackColor, 1f);
					point = new Point(num3, rectangle.Height - num2);
					pt = new Point(num3 + 2, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					point = new Point(num3 + num, rectangle.Height - num2);
					pt = new Point(num3 + 2 + num, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					num2--;
					num3++;
					num = 2;
					pen = new Pen(this._blackColor, 1f);
					point = new Point(num3, rectangle.Height - num2);
					pt = new Point(num3 + 2, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					point = new Point(num3 + num, rectangle.Height - num2);
					pt = new Point(num3 + 2 + num, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					num2 = 6;
					num3 = 7;
					num = 7;
					pen = new Pen(this._whiteColor, 1f);
					point = new Point(num3, rectangle.Height - num2);
					pt = new Point(num3 + 3, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					point = new Point(num3 + num, rectangle.Height - num2);
					pt = new Point(num3 + 3 + num, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					num2++;
					num3++;
					num = 5;
					pen = new Pen(this._whiteColor, 1f);
					point = new Point(num3, rectangle.Height - num2);
					pt = new Point(num3 + 3, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					point = new Point(num3 + num, rectangle.Height - num2);
					pt = new Point(num3 + 3 + num, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					num2++;
					num3++;
					num = 3;
					pen = new Pen(this._whiteColor, 1f);
					point = new Point(num3, rectangle.Height - num2);
					pt = new Point(num3 + 3, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					point = new Point(num3 + num, rectangle.Height - num2);
					pt = new Point(num3 + 3 + num, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					Color color3 = Color.FromArgb((int)this._baseColor.R, (int)this._baseColor.G, (int)this._baseColor.B);
					num2 = 13;
					num3 = 9;
					num = 5;
					pen = new Pen(color3, 1f);
					point = new Point(num3, rectangle.Height - num2);
					pt = new Point(num3 + 1, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					point = new Point(num3 + num, rectangle.Height - num2);
					pt = new Point(num3 + 1 + num, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					num2--;
					num3++;
					num = 3;
					color3 = Color.FromArgb((int)color3.R, (int)color3.G, (int)color3.B);
					pen = new Pen(color3, 1f);
					point = new Point(num3, rectangle.Height - num2);
					pt = new Point(num3 + 1, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					point = new Point(num3 + num, rectangle.Height - num2);
					pt = new Point(num3 + 1 + num, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					num2--;
					num3++;
					num = 1;
					color3 = Color.FromArgb((int)color3.R, (int)color3.G, (int)color3.B);
					pen = new Pen(color3, 1f);
					point = new Point(num3, rectangle.Height - num2);
					pt = new Point(num3 + 1, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					point = new Point(num3 + num, rectangle.Height - num2);
					pt = new Point(num3 + 1 + num, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					num2--;
					num = 1;
					color3 = Color.FromArgb((int)color3.R, (int)color3.G, (int)color3.B);
					pen = new Pen(color3, 1f);
					point = new Point(num3, rectangle.Height - num2);
					pt = new Point(num3 + 1, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					point = new Point(num3 + num, rectangle.Height - num2);
					pt = new Point(num3 + 1 + num, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					num2--;
					num3--;
					num = 2;
					color3 = Color.FromArgb((int)color3.R, (int)color3.G, (int)color3.B);
					pen = new Pen(color3, 1f);
					point = new Point(num3, rectangle.Height - num2);
					pt = new Point(num3 + 2, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					point = new Point(num3 + num, rectangle.Height - num2);
					pt = new Point(num3 + 2 + num, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					num2--;
					num3--;
					num = 4;
					color3 = Color.FromArgb((int)color3.R, (int)color3.G, (int)color3.B);
					pen = new Pen(color3, 1f);
					point = new Point(num3, rectangle.Height - num2);
					pt = new Point(num3 + 2, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					point = new Point(num3 + num, rectangle.Height - num2);
					pt = new Point(num3 + 2 + num, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					num2--;
					num3--;
					num = 6;
					color3 = Color.FromArgb((int)color3.R, (int)color3.G, (int)color3.B);
					pen = new Pen(color3, 1f);
					point = new Point(num3, rectangle.Height - num2);
					pt = new Point(num3 + 2, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					point = new Point(num3 + num, rectangle.Height - num2);
					pt = new Point(num3 + 2 + num, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					break;
				}
				case RibbonCommandButton.mycommands.Try:
				{
					int num2 = 7;
					Pen pen = new Pen(this._blackColor, 1f);
					Point point = new Point(7, rectangle.Height - num2);
					Point pt = new Point(rectangle.Width - 6, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					num2--;
					pen = new Pen(this._baseColor, 1f);
					point = new Point(7, rectangle.Height - num2);
					pt = new Point(rectangle.Width - 6, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					num2--;
					pen = new Pen(this._whiteColor, 1f);
					point = new Point(7, rectangle.Height - num2);
					pt = new Point(rectangle.Width - 6, rectangle.Height - num2);
					graphics.DrawLine(pen, point, pt);
					break;
				}
				default:
					graphics.FillRectangle(new SolidBrush(Color.AliceBlue), rectangle);
					break;
				}
			}
			catch
			{
			}
		}

		public void DrawArc(Rectangle re, GraphicsPath pa)
		{
			pa.AddArc(re.X, re.Y, this._radius, this._radius, 180f, 90f);
			pa.AddArc(re.Width - this._radius, re.Y, this._radius, this._radius, 270f, 90f);
			pa.AddArc(re.Width - this._radius, re.Height - this._radius, this._radius, this._radius, 0f, 90f);
			pa.AddArc(re.X, re.Height - this._radius, this._radius, this._radius, 90f, 90f);
			pa.CloseFigure();
		}

		public Color SetTransparency(Color color, int transparency)
		{
			Color result;
			if (transparency >= 0 & transparency <= 255)
			{
				result = Color.FromArgb(transparency, (int)color.R, (int)color.G, (int)color.B);
			}
			else if (transparency > 255)
			{
				result = Color.FromArgb(255, (int)color.R, (int)color.G, (int)color.B);
			}
			else
			{
				result = Color.FromArgb(0, (int)color.R, (int)color.G, (int)color.B);
			}
			return result;
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			this._state = RibbonCommandButton.mystates.On;
			this.Cursor = Cursors.Arrow;
			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			this._state = RibbonCommandButton.mystates.Out;
			base.OnMouseLeave(e);
		}

		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			this._state = RibbonCommandButton.mystates.OnClick;
			base.OnMouseDown(mevent);
		}

		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			this._state = RibbonCommandButton.mystates.On;
			base.OnMouseUp(mevent);
		}
	}
}
