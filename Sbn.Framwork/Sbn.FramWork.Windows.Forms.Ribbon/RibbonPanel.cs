using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms.Ribbon
{
	public class RibbonPanel : Panel
	{
		private int X0;

		private int XF;

		private int Y0;

		private int YF;

		private int T = 3;

		private int i_Zero = 180;

		private int i_Sweep = 90;

		private int X;

		private int Y;

		private GraphicsPath path;

		private int D = -1;

		private int R0 = 215;

		private int G0 = 227;

		private int B0 = 242;

		private Color _BaseColor = Color.FromArgb(215, 227, 242);

		private Color _BaseColorOn = Color.FromArgb(215, 227, 242);

		private int i_mode = 0;

		private int i_factor = 8;

		private int i_fR = 1;

		private int i_fG = 1;

		private int i_fB = 1;

		private int i_Op = 255;

		private string S_TXT = "";

		private Timer timer1 = new Timer();

		private int activex0 = 0;

		private int activexf = 0;

		private bool activestate = false;

		public Color BaseColor
		{
			get
			{
				return this._BaseColor;
			}
			set
			{
				this._BaseColor = value;
				this.R0 = (int)this._BaseColor.R;
				this.B0 = (int)this._BaseColor.B;
				this.G0 = (int)this._BaseColor.G;
			}
		}

		public Color BaseColorOn
		{
			get
			{
				return this._BaseColorOn;
			}
			set
			{
				this._BaseColorOn = value;
				this.R0 = (int)this._BaseColor.R;
				this.B0 = (int)this._BaseColor.B;
				this.G0 = (int)this._BaseColor.G;
			}
		}

		public string Caption
		{
			get
			{
				return this.S_TXT;
			}
			set
			{
				this.S_TXT = value;
				this.Refresh();
			}
		}

		public int Speed
		{
			get
			{
				return this.i_factor;
			}
			set
			{
				this.i_factor = value;
			}
		}

		public int Opacity
		{
			get
			{
				return this.i_Op;
			}
			set
			{
				if (value < 256 | value > -1)
				{
					this.i_Op = value;
				}
			}
		}

		public RibbonPanel()
		{
			base.Padding = new Padding(0, 3, 0, 0);
			this.timer1.Interval = 1;
			this.timer1.Tick += new EventHandler(this.timer1_Tick);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
			base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			this.X0 = 0;
			this.XF = base.Width + this.X0 - 3;
			this.Y0 = 0;
			this.YF = base.Height + this.Y0 - 3;
			this.T = 6;
			Point point = new Point(this.X0, this.Y0 - 1);
			Point point2 = new Point(this.X0, this.Y0 + this.YF + 8);
			Pen pen = new Pen(Color.FromArgb(this.i_Op, this.R0 - 18, this.G0 - 17, this.B0 - 19));
			Pen pen2 = Pens.Black;
			try
			{
				pen2 = new Pen(Color.FromArgb(this.i_Op, this.R0 - 74, this.G0 - 49, this.B0 - 15));
			}
			catch
			{
				pen2 = new Pen(Color.FromArgb(this.i_Op, this.R0 - 22, this.G0 - 11, this.B0));
			}
			Pen pen3 = new Pen(Color.FromArgb(this.i_Op, this.R0 + 23, this.G0 + 21, this.B0 + 13));
			Pen pen4 = new Pen(Color.FromArgb(this.i_Op, this.R0 + 14, this.G0 + 9, this.B0 + 3));
			Pen pen5 = new Pen(Color.FromArgb(this.i_Op, this.R0 - 8, this.G0 - 4, this.B0 - 2));
			Pen pen6 = new Pen(Color.FromArgb(this.i_Op, this.R0 + 4, this.G0 + 3, this.B0 + 3));
			Pen pen7 = new Pen(Color.FromArgb(this.i_Op, this.R0 - 16, this.G0 - 11, this.B0 - 5));
			Pen pen8 = new Pen(Color.FromArgb(this.i_Op, this.R0 + 12, this.G0 + 17, this.B0 + 13));
			Pen pen9 = new Pen(Color.FromArgb(this.i_Op, this.R0 - 22, this.G0 - 10, this.B0));
			e.Graphics.PageUnit = GraphicsUnit.Pixel;
			Brush brush = pen5.Brush;
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			this.X = this.X0;
			this.Y = this.Y0;
			this.i_Zero = 180;
			this.D = 0;
			this.DrawArc();
			e.Graphics.FillPath(pen6.Brush, this.path);
			Rectangle clipRectangle = e.ClipRectangle;
			LinearGradientBrush brush2 = new LinearGradientBrush(point, point2, pen7.Color, pen8.Color);
			this.DrawArc2(17, this.YF + 7);
			e.Graphics.FillPath(brush2, this.path);
			this.D--;
			this.DrawFHalfArc();
			e.Graphics.DrawPath(pen2, this.path);
			this.DrawSHalfArc();
			e.Graphics.DrawPath(pen3, this.path);
			if (this.activestate)
			{
				e.Graphics.DrawLine(pen6, new Point(this.activex0 + 1, 0), new Point(this.activexf - 9, 0));
			}
			base.OnPaint(e);
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			Point p = Cursor.Position;
			p = base.PointToClient(p);
			if (p.X > 0 | p.X < base.Width | p.Y > 0 | p.Y < base.Height)
			{
				this.i_mode = 0;
				this.timer1.Start();
			}
			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			Point p = Cursor.Position;
			p = base.PointToClient(p);
			if (p.X < 0 | p.X >= base.Width | p.Y < 0 | p.Y >= base.Height)
			{
				this.i_mode = 1;
				this.timer1.Start();
			}
			base.OnMouseLeave(e);
		}

		public void DrawArc()
		{
			this.X = this.X0 - 2;
			this.Y = this.Y0 - 1;
			this.i_Zero = 180;
			this.D++;
			this.path = new GraphicsPath();
			this.path.AddArc(this.X + this.D, this.Y + this.D, this.T, this.T, (float)this.i_Zero, (float)this.i_Sweep);
			this.i_Zero += 90;
			this.X += this.XF;
			this.path.AddArc(this.X - this.D, this.Y + this.D, this.T, this.T, (float)this.i_Zero, (float)this.i_Sweep);
			this.i_Zero += 90;
			this.Y += this.YF;
			this.path.AddArc(this.X - this.D, this.Y - this.D, this.T, this.T, (float)this.i_Zero, (float)this.i_Sweep);
			this.i_Zero += 90;
			this.X -= this.XF;
			this.path.AddArc(this.X + this.D, this.Y - this.D, this.T, this.T, (float)this.i_Zero, (float)this.i_Sweep);
			this.i_Zero += 90;
			this.Y -= this.YF;
			this.path.AddArc(this.X + this.D, this.Y + this.D, this.T, this.T, (float)this.i_Zero, (float)this.i_Sweep);
		}

		public void DrawFHalfArc()
		{
			this.X = this.X0 - 2;
			this.Y = this.Y0 - 1;
			this.i_Zero = 180;
			this.D++;
			this.path = new GraphicsPath();
			this.path.AddArc(this.X + this.D, this.Y + this.D, this.T, this.T, (float)this.i_Zero, (float)this.i_Sweep);
			this.i_Zero += 90;
			this.X += this.XF - 1;
			this.path.AddArc(this.X - this.D, this.Y + this.D, this.T, this.T, (float)this.i_Zero, (float)this.i_Sweep);
			this.i_Zero += 90;
			this.Y += this.YF;
			this.path.AddArc(this.X - this.D, this.Y - this.D, this.T, this.T, (float)this.i_Zero, (float)this.i_Sweep);
		}

		public void DrawSHalfArc()
		{
			this.X = this.X0 - 3;
			this.Y = this.Y0 - 1;
			this.i_Zero = 180;
			this.D++;
			this.path = new GraphicsPath();
			this.i_Zero += 90;
			this.X += this.XF;
			this.path.AddArc(this.X - this.D, this.Y + this.D, this.T, this.T, (float)this.i_Zero, (float)this.i_Sweep);
			this.i_Zero += 90;
			this.Y += this.YF - 1;
			this.path.AddArc(this.X - this.D, this.Y - this.D, this.T, this.T, (float)this.i_Zero, (float)this.i_Sweep);
			this.i_Zero += 90;
			this.X -= this.XF - 1;
			this.path.AddArc(this.X + this.D, this.Y - this.D, this.T, this.T, (float)this.i_Zero, (float)this.i_Sweep);
			this.i_Zero += 90;
			this.Y -= this.YF - 1;
			this.path.AddArc(this.X + this.D, this.Y + this.D, this.T, this.T, (float)this.i_Zero, (float)this.i_Sweep);
		}

		protected override void OnResize(EventArgs eventargs)
		{
			this.Refresh();
			base.OnResize(eventargs);
		}

		public void DrawArc2(int OF_Y, int SW_Y)
		{
			this.X = this.X0 - 1;
			this.Y = this.Y0 + OF_Y;
			this.i_Zero = 180;
			this.path = new GraphicsPath();
			this.path.AddArc(this.X + this.D, this.Y + this.D, this.T, this.T, (float)this.i_Zero, (float)this.i_Sweep);
			this.i_Zero += 90;
			this.X += this.XF - 1;
			this.path.AddArc(this.X - this.D, this.Y + this.D, this.T, this.T, (float)this.i_Zero, (float)this.i_Sweep);
			this.i_Zero += 90;
			this.Y += SW_Y - 20;
			this.path.AddArc(this.X - this.D, this.Y - this.D, this.T, this.T, (float)this.i_Zero, (float)this.i_Sweep);
			this.i_Zero += 90;
			this.X -= this.XF - 1;
			this.path.AddArc(this.X + this.D, this.Y - this.D, this.T, this.T, (float)this.i_Zero, (float)this.i_Sweep);
			this.i_Zero += 90;
			this.Y -= SW_Y - 20;
			this.path.AddArc(this.X + this.D, this.Y + this.D, this.T, this.T, (float)this.i_Zero, (float)this.i_Sweep);
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (this.i_mode == 0)
			{
				if (Math.Abs((int)this._BaseColorOn.R - this.R0) > this.i_factor)
				{
					this.i_fR = this.i_factor;
				}
				else
				{
					this.i_fR = 1;
				}
				if (Math.Abs((int)this._BaseColorOn.G - this.G0) > this.i_factor)
				{
					this.i_fG = this.i_factor;
				}
				else
				{
					this.i_fG = 1;
				}
				if (Math.Abs((int)this._BaseColorOn.B - this.B0) > this.i_factor)
				{
					this.i_fB = this.i_factor;
				}
				else
				{
					this.i_fB = 1;
				}
				if ((int)this._BaseColorOn.R < this.R0)
				{
					this.R0 -= this.i_fR;
				}
				else if ((int)this._BaseColorOn.R > this.R0)
				{
					this.R0 += this.i_fR;
				}
				if ((int)this._BaseColorOn.G < this.G0)
				{
					this.G0 -= this.i_fG;
				}
				else if ((int)this._BaseColorOn.G > this.G0)
				{
					this.G0 += this.i_fG;
				}
				if ((int)this._BaseColorOn.B < this.B0)
				{
					this.B0 -= this.i_fB;
				}
				else if ((int)this._BaseColorOn.B > this.B0)
				{
					this.B0 += this.i_fB;
				}
				if (this._BaseColorOn == Color.FromArgb(this.R0, this.G0, this.B0))
				{
					this.timer1.Stop();
				}
				else
				{
					this.Refresh();
				}
			}
			if (this.i_mode == 1)
			{
				if (Math.Abs((int)this._BaseColor.R - this.R0) < this.i_factor)
				{
					this.i_fR = 1;
				}
				else
				{
					this.i_fR = this.i_factor;
				}
				if (Math.Abs((int)this._BaseColor.G - this.G0) < this.i_factor)
				{
					this.i_fG = 1;
				}
				else
				{
					this.i_fG = this.i_factor;
				}
				if (Math.Abs((int)this._BaseColor.B - this.B0) < this.i_factor)
				{
					this.i_fB = 1;
				}
				else
				{
					this.i_fB = this.i_factor;
				}
				if ((int)this._BaseColor.R < this.R0)
				{
					this.R0 -= this.i_fR;
				}
				else if ((int)this._BaseColor.R > this.R0)
				{
					this.R0 += this.i_fR;
				}
				if ((int)this._BaseColor.G < this.G0)
				{
					this.G0 -= this.i_fG;
				}
				else if ((int)this._BaseColor.G > this.G0)
				{
					this.G0 += this.i_fG;
				}
				if ((int)this._BaseColor.B < this.B0)
				{
					this.B0 -= this.i_fB;
				}
				else if ((int)this._BaseColor.B > this.B0)
				{
					this.B0 += this.i_fB;
				}
				if (this._BaseColor == Color.FromArgb(this.R0, this.G0, this.B0))
				{
					this.timer1.Stop();
				}
				else
				{
					this.Refresh();
				}
			}
		}

		public void LinePos(int x0, int xf, bool state)
		{
			this.activex0 = x0;
			this.activexf = xf;
			this.activestate = state;
			this.Refresh();
		}
	}
}
