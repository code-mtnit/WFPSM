using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms.Ribbon
{
	public class RibbonMenuButton : Button
	{
		public enum e_imagelocation
		{
			Top,
			Bottom,
			Left,
			Right,
			None
		}

		public enum e_showbase
		{
			Yes,
			No
		}

		public enum e_groupPos
		{
			None,
			Left,
			Center,
			Right,
			Top,
			Bottom
		}

		public enum e_arrow
		{
			None,
			ToRight,
			ToDown
		}

		public enum e_splitbutton
		{
			No,
			Yes
		}

		private RibbonMenuButton.e_imagelocation _imagelocation;

		private int _imageoffset;

		private Point _maximagesize;

		private RibbonMenuButton.e_showbase _showbase;

		private RibbonMenuButton.e_showbase _tempshowbase;

		private int _radius = 6;

		private RibbonMenuButton.e_groupPos _grouppos;

		private RibbonMenuButton.e_arrow _arrow;

		private RibbonMenuButton.e_splitbutton _splitbutton;

		private int _splitdistance = 0;

		private string _title = "";

		private bool _keeppress = false;

		private bool _ispressed = false;

		private Point _menupos = new Point(0, 0);

		private Color _baseColor = Color.FromArgb(209, 209, 209);

		private Color _onColor = Color.FromArgb(255, 255, 255);

		private Color _pressColor = Color.FromArgb(255, 255, 255);

		private Color _baseStroke = Color.FromArgb(255, 255, 255);

		private Color _onStroke = Color.FromArgb(255, 255, 255);

		private Color _pressStroke = Color.FromArgb(255, 255, 255);

		private Color _colorStroke = Color.FromArgb(255, 255, 255);

		private int A0;

		private int R0;

		private int G0;

		private int B0;

		private int offsetx = 0;

		private int offsety = 0;

		private int imageheight = 0;

		private int imagewidth = 0;

		private Timer timer1 = new Timer();

		private int i_factor = 35;

		private int i_fR = 1;

		private int i_fG = 1;

		private int i_fB = 1;

		private int i_fA = 1;

		private int i_mode = 0;

		private int xmouse = 0;

		private int ymouse = 0;

		private bool mouse = false;

		public RibbonMenuButton.e_imagelocation ImageLocation
		{
			get
			{
				return this._imagelocation;
			}
			set
			{
				this._imagelocation = value;
				this.Refresh();
			}
		}

		public int ImageOffset
		{
			get
			{
				return this._imageoffset;
			}
			set
			{
				this._imageoffset = value;
			}
		}

		public Point MaxImageSize
		{
			get
			{
				return this._maximagesize;
			}
			set
			{
				this._maximagesize = value;
			}
		}

		public RibbonMenuButton.e_showbase ShowBase
		{
			get
			{
				return this._showbase;
			}
			set
			{
				this._showbase = value;
				this.Refresh();
			}
		}

		public int Radius
		{
			get
			{
				return this._radius;
			}
			set
			{
				if (this._radius > 0)
				{
					this._radius = value;
				}
				this.Refresh();
			}
		}

		public RibbonMenuButton.e_groupPos GroupPos
		{
			get
			{
				return this._grouppos;
			}
			set
			{
				this._grouppos = value;
				this.Refresh();
			}
		}

		public RibbonMenuButton.e_arrow Arrow
		{
			get
			{
				return this._arrow;
			}
			set
			{
				this._arrow = value;
				this.Refresh();
			}
		}

		public RibbonMenuButton.e_splitbutton SplitButton
		{
			get
			{
				return this._splitbutton;
			}
			set
			{
				this._splitbutton = value;
				this.Refresh();
			}
		}

		public int SplitDistance
		{
			get
			{
				return this._splitdistance;
			}
			set
			{
				this._splitdistance = value;
				this.Refresh();
			}
		}

		public string Title
		{
			get
			{
				return this._title;
			}
			set
			{
				this._title = value;
				this.Refresh();
			}
		}

		public bool KeepPress
		{
			get
			{
				return this._keeppress;
			}
			set
			{
				this._keeppress = value;
			}
		}

		public bool IsPressed
		{
			get
			{
				return this._ispressed;
			}
			set
			{
				this._ispressed = value;
			}
		}

		public Point MenuPos
		{
			get
			{
				return this._menupos;
			}
			set
			{
				this._menupos = value;
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
				this.R0 = (int)this._baseColor.R;
				this.B0 = (int)this._baseColor.B;
				this.G0 = (int)this._baseColor.G;
				this.A0 = (int)this._baseColor.A;
				RibbonColor ribbonColor = new RibbonColor(this._baseColor);
				if (ribbonColor.BC < 50)
				{
					ribbonColor.SetBrightness(60);
				}
				else
				{
					ribbonColor.SetBrightness(30);
				}
				if (this._baseColor.A > 0)
				{
					this._baseStroke = Color.FromArgb(100, ribbonColor.GetColor());
				}
				else
				{
					this._baseStroke = Color.FromArgb(0, ribbonColor.GetColor());
				}
				this.Refresh();
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
				RibbonColor ribbonColor = new RibbonColor(this._onColor);
				if (ribbonColor.BC < 50)
				{
					ribbonColor.SetBrightness(60);
				}
				else
				{
					ribbonColor.SetBrightness(30);
				}
				if (this._baseStroke.A > 0)
				{
					this._onStroke = Color.FromArgb(100, ribbonColor.GetColor());
				}
				else
				{
					this._onStroke = Color.FromArgb(0, ribbonColor.GetColor());
				}
				this.Refresh();
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
				RibbonColor ribbonColor = new RibbonColor(this._pressColor);
				if (ribbonColor.BC < 50)
				{
					ribbonColor.SetBrightness(60);
				}
				else
				{
					ribbonColor.SetBrightness(30);
				}
				if (this._baseStroke.A > 0)
				{
					this._pressStroke = Color.FromArgb(100, ribbonColor.GetColor());
				}
				else
				{
					this._pressStroke = Color.FromArgb(0, ribbonColor.GetColor());
				}
				this.Refresh();
			}
		}

		public Color ColorBaseStroke
		{
			get
			{
				return this._baseStroke;
			}
			set
			{
				this._baseStroke = value;
			}
		}

		public Color ColorOnStroke
		{
			get
			{
				return this._onStroke;
			}
			set
			{
				this._onStroke = value;
			}
		}

		public Color ColorPressStroke
		{
			get
			{
				return this._pressStroke;
			}
			set
			{
				this._pressStroke = value;
			}
		}

		public int FadingSpeed
		{
			get
			{
				return this.i_factor;
			}
			set
			{
				if (value > -1)
				{
					this.i_factor = value;
				}
			}
		}

		public RibbonMenuButton()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.DoubleBuffer, true);
			base.SetStyle(ControlStyles.Opaque, false);
			base.FlatAppearance.BorderSize = 0;
			base.FlatStyle = FlatStyle.Flat;
			this.BackColor = Color.Transparent;
			this.timer1.Interval = 5;
			this.timer1.Tick += new EventHandler(this.timer1_Tick);
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			this.A0 = (int)this.ColorBase.A;
			this.R0 = (int)this.ColorBase.R;
			this.G0 = (int)this.ColorBase.G;
			this.B0 = (int)this.ColorBase.B;
			this._colorStroke = this._baseStroke;
			Rectangle re = new Rectangle(new Point(-1, -1), new Size(base.Width + this._radius, base.Height + this._radius));
			Size arg_98_0 = base.Size;
			bool flag = 1 == 0;
			GraphicsPath graphicsPath = new GraphicsPath();
			this.DrawArc(re, graphicsPath);
			base.Region = new Region(graphicsPath);
		}

		public Color GetColorIncreased(Color color, int h, int s, int b)
		{
			RibbonColor ribbonColor = new RibbonColor(color);
			int saturation = ribbonColor.GetSaturation();
			float vC = (float)(b + ribbonColor.GetBrightness());
			float hC = (float)(h + ribbonColor.GetHue());
			float sC = (float)(s + saturation);
			ribbonColor.VC = vC;
			ribbonColor.HC = hC;
			ribbonColor.SC = sC;
			return ribbonColor.GetColor();
		}

		public Color GetColor(int A, int R, int G, int B)
		{
			if (A + this.A0 > 255)
			{
				A = 255;
			}
			else
			{
				A += this.A0;
			}
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
			return Color.FromArgb(A, R, G, B);
		}

		protected override void OnPaint(PaintEventArgs pevent)
		{
			Graphics graphics = pevent.Graphics;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.InterpolationMode = InterpolationMode.High;
			Rectangle rectangle = new Rectangle(new Point(-1, -1), new Size(base.Width + this._radius, base.Height + this._radius));
			GraphicsPath pa = new GraphicsPath();
			Rectangle re = new Rectangle(new Point(0, 0), new Size(base.Width - 1, base.Height - 1));
			this.DrawArc(re, pa);
			this.FillGradients(graphics, pa);
			this.DrawImage(graphics);
			this.DrawString(graphics);
			this.DrawArrow(graphics);
		}

		protected override void OnResize(EventArgs e)
		{
			Rectangle re = new Rectangle(new Point(-1, -1), new Size(base.Width + this._radius, base.Height + this._radius));
			Size arg_35_0 = base.Size;
			bool flag = 1 == 0;
			GraphicsPath graphicsPath = new GraphicsPath();
			this.DrawArc(re, graphicsPath);
			base.Region = new Region(graphicsPath);
			base.OnResize(e);
		}

		public void FillGradients(Graphics gr, GraphicsPath pa)
		{
			int num = base.Height / 3;
			int height = base.Height;
			int num2 = (height - num) / 2;
			if (this._showbase == RibbonMenuButton.e_showbase.Yes)
			{
				Rectangle rectangle = new Rectangle(new Point(0, 0), new Size(base.Width - 1, base.Height - 1));
				pa = new GraphicsPath();
				this.DrawArc(rectangle, pa);
				LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, Color.Transparent, Color.Transparent, LinearGradientMode.Vertical);
				float[] positions = new float[]
				{
					0f,
					0.3f,
					0.35f,
					1f
				};
				Color[] array = new Color[4];
				if (this.i_mode == 0)
				{
					array[0] = this.GetColor(0, 35, 24, 9);
					array[1] = this.GetColor(0, 13, 8, 3);
					array[2] = Color.FromArgb(this.A0, this.R0, this.G0, this.B0);
					array[3] = this.GetColor(0, 28, 29, 14);
				}
				else
				{
					array[0] = this.GetColor(0, 0, 50, 100);
					array[1] = this.GetColor(0, 0, 0, 30);
					array[2] = Color.FromArgb(this.A0, this.R0, this.G0, this.B0);
					array[3] = this.GetColor(0, 0, 50, 100);
				}
				linearGradientBrush.InterpolationColors = new ColorBlend
				{
					Colors = array,
					Positions = positions
				};
				gr.FillPath(linearGradientBrush, pa);
				rectangle = new Rectangle(new Point(0, 0), new Size(base.Width, base.Height / 3));
				pa = new GraphicsPath();
				int radius = this._radius;
				this._radius = radius - 1;
				this.DrawArc(rectangle, pa);
				if (this.A0 > 80)
				{
					gr.FillPath(new SolidBrush(Color.FromArgb(60, 255, 255, 255)), pa);
				}
				this._radius = radius;
				if (this._splitbutton == RibbonMenuButton.e_splitbutton.Yes & this.mouse)
				{
					this.FillSplit(gr);
				}
				if (this.i_mode == 2)
				{
					rectangle = new Rectangle(1, 1, base.Width - 2, base.Height);
					pa = new GraphicsPath();
					this.DrawShadow(rectangle, pa);
					gr.DrawPath(new Pen(Color.FromArgb(50, 20, 20, 20), 2f), pa);
				}
				else
				{
					rectangle = new Rectangle(1, 1, base.Width - 2, base.Height - 1);
					pa = new GraphicsPath();
					this.DrawShadow(rectangle, pa);
					if (this.A0 > 80)
					{
						gr.DrawPath(new Pen(Color.FromArgb(100, 250, 250, 250), 3f), pa);
					}
				}
				if (this._splitbutton == RibbonMenuButton.e_splitbutton.Yes)
				{
					if (this._imagelocation == RibbonMenuButton.e_imagelocation.Top)
					{
						switch (this.i_mode)
						{
						case 1:
							gr.DrawLine(new Pen(this._onStroke), new Point(1, base.Height - this._splitdistance), new Point(base.Width - 1, base.Height - this._splitdistance));
							break;
						case 2:
							gr.DrawLine(new Pen(this._pressStroke), new Point(1, base.Height - this._splitdistance), new Point(base.Width - 1, base.Height - this._splitdistance));
							break;
						}
					}
					else if (this._imagelocation == RibbonMenuButton.e_imagelocation.Left)
					{
						switch (this.i_mode)
						{
						case 1:
							gr.DrawLine(new Pen(this._onStroke), new Point(base.Width - this._splitdistance, 0), new Point(base.Width - this._splitdistance, base.Height));
							break;
						case 2:
							gr.DrawLine(new Pen(this._pressStroke), new Point(base.Width - this._splitdistance, 0), new Point(base.Width - this._splitdistance, base.Height));
							break;
						}
					}
				}
				rectangle = new Rectangle(new Point(0, 0), new Size(base.Width - 1, base.Height - 1));
				pa = new GraphicsPath();
				this.DrawArc(rectangle, pa);
				gr.DrawPath(new Pen(this._colorStroke, 0.9f), pa);
				pa.Dispose();
				linearGradientBrush.Dispose();
			}
		}

		public void DrawImage(Graphics gr)
		{
			if (base.Image != null)
			{
				this.offsety = this._imageoffset;
				this.offsetx = this._imageoffset;
				if (this._imagelocation == RibbonMenuButton.e_imagelocation.Left | this._imagelocation == RibbonMenuButton.e_imagelocation.Right)
				{
					this.imageheight = base.Height - this.offsety * 2;
					if (this.imageheight > this._maximagesize.Y & this._maximagesize.Y != 0)
					{
						this.imageheight = this._maximagesize.Y;
					}
					this.imagewidth = (int)(Convert.ToDouble(this.imageheight) / (double)base.Image.Height * (double)base.Image.Width);
				}
				else if (this._imagelocation == RibbonMenuButton.e_imagelocation.Top | this._imagelocation == RibbonMenuButton.e_imagelocation.Bottom)
				{
					this.imagewidth = base.Width - this.offsetx * 2;
					if (this.imagewidth > this._maximagesize.X & this._maximagesize.X != 0)
					{
						this.imagewidth = this._maximagesize.X;
					}
					this.imageheight = (int)(Convert.ToDouble(this.imagewidth) / (double)base.Image.Width * (double)base.Image.Height);
				}
				switch (this._imagelocation)
				{
				case RibbonMenuButton.e_imagelocation.Top:
					this.offsetx = base.Width / 2 - this.imagewidth / 2;
					gr.DrawImage(base.Image, new Rectangle(this.offsetx, this.offsety, this.imagewidth, this.imageheight));
					break;
				case RibbonMenuButton.e_imagelocation.Bottom:
					gr.DrawImage(base.Image, new Rectangle(this.offsetx, base.Height - this.imageheight - this.offsety, this.imagewidth, this.imageheight));
					break;
				case RibbonMenuButton.e_imagelocation.Left:
					gr.DrawImage(base.Image, new Rectangle(this.offsetx, this.offsety, this.imagewidth, this.imageheight));
					break;
				case RibbonMenuButton.e_imagelocation.Right:
					gr.DrawImage(base.Image, new Rectangle(base.Width - this.imagewidth - this.offsetx, this.offsety, this.imagewidth, this.imageheight));
					break;
				}
			}
		}

		public void DrawString(Graphics gr)
		{
			if (this.Text != "")
			{
				int num = (int)gr.MeasureString(this.Text, this.Font).Width;
				int num2 = (int)gr.MeasureString(this.Text, this.Font).Height;
				int num3 = 0;
				Font font = new Font(this.Font, FontStyle.Bold);
				if (this._title != "")
				{
					num3 = num2 / 2;
				}
				string text = this.Text;
				string s = "";
				int num4 = this.Text.IndexOf("\\n");
				if (num4 != -1)
				{
					s = text.Substring(num4 + 3);
					text = text.Substring(0, num4);
				}
				RibbonColor ribbonColor = new RibbonColor(Color.FromArgb(this.R0, this.G0, this.B0));
				RibbonColor ribbonColor2 = new RibbonColor(this.ForeColor);
				if (ribbonColor.GetBrightness() > 50)
				{
					ribbonColor2.BC = 1;
					ribbonColor2.SC = 80f;
				}
				else
				{
					ribbonColor2.BC = 99;
					ribbonColor2.SC = 20f;
				}
				Color color = ribbonColor2.GetColor();
				switch (this._imagelocation)
				{
				case RibbonMenuButton.e_imagelocation.Top:
					gr.DrawString(this.Text, this.Font, new SolidBrush(color), new PointF((float)(base.Width / 2 - num / 2 - 1), (float)(this.offsety + this.imageheight)));
					break;
				case RibbonMenuButton.e_imagelocation.Bottom:
					gr.DrawString(this.Text, this.Font, new SolidBrush(color), new PointF((float)(base.Width / 2 - num / 2 - 1), (float)(base.Height - this.imageheight - num2 - 1)));
					break;
				case RibbonMenuButton.e_imagelocation.Left:
					if (this.Title != "")
					{
						gr.DrawString(this.Title, font, new SolidBrush(color), new PointF((float)(this.offsetx + this.imagewidth + 4), this.Font.Size / 2f));
						gr.DrawString(text, this.Font, new SolidBrush(color), new PointF((float)(this.offsetx + this.imagewidth + 4), 2f * this.Font.Size + 1f));
						gr.DrawString(s, this.Font, new SolidBrush(color), new PointF((float)(this.offsetx + this.imagewidth + 4), 3f * this.Font.Size + 4f));
					}
					else
					{
						gr.DrawString(text, this.Font, new SolidBrush(color), new PointF((float)(this.offsetx + this.imagewidth + 4), (float)(base.Height / 2) - this.Font.Size + 1f));
					}
					break;
				case RibbonMenuButton.e_imagelocation.Right:
					gr.DrawString(this.Title, font, new SolidBrush(color), new PointF((float)this.offsetx, (float)(base.Height / 2) - this.Font.Size + 1f - (float)num3));
					gr.DrawString(this.Text, this.Font, new SolidBrush(color), new PointF((float)this.offsetx, (float)(num3 + base.Height / 2) - this.Font.Size + 1f));
					break;
				}
				font.Dispose();
			}
		}

		public void DrawArc(Rectangle re, GraphicsPath pa)
		{
			int num = this._radius;
			int num2 = this._radius;
			int num3 = this._radius;
			int num4 = this._radius;
			switch (this._grouppos)
			{
			case RibbonMenuButton.e_groupPos.Left:
				num2 = 1;
				num4 = 1;
				break;
			case RibbonMenuButton.e_groupPos.Center:
				num = 1;
				num3 = 1;
				num2 = 1;
				num4 = 1;
				break;
			case RibbonMenuButton.e_groupPos.Right:
				num = 1;
				num3 = 1;
				break;
			case RibbonMenuButton.e_groupPos.Top:
				num3 = 1;
				num4 = 1;
				break;
			case RibbonMenuButton.e_groupPos.Bottom:
				num = 1;
				num2 = 1;
				break;
			}
			pa.AddArc(re.X, re.Y, num, num, 180f, 90f);
			pa.AddArc(re.Width - num2, re.Y, num2, num2, 270f, 90f);
			pa.AddArc(re.Width - num4, re.Height - num4, num4, num4, 0f, 90f);
			pa.AddArc(re.X, re.Height - num3, num3, num3, 90f, 90f);
			pa.CloseFigure();
		}

		public void DrawShadow(Rectangle re, GraphicsPath pa)
		{
			int num = this._radius;
			int num2 = this._radius;
			int num3 = this._radius;
			int num4 = this._radius;
			switch (this._grouppos)
			{
			case RibbonMenuButton.e_groupPos.Left:
				num2 = 1;
				num4 = 1;
				break;
			case RibbonMenuButton.e_groupPos.Center:
				num = 1;
				num3 = 1;
				num2 = 1;
				num4 = 1;
				break;
			case RibbonMenuButton.e_groupPos.Right:
				num = 1;
				num3 = 1;
				break;
			case RibbonMenuButton.e_groupPos.Top:
				num3 = 1;
				num4 = 1;
				break;
			case RibbonMenuButton.e_groupPos.Bottom:
				num = 1;
				num2 = 1;
				break;
			}
			pa.AddArc(re.X, re.Y, num, num, 180f, 90f);
			pa.AddArc(re.Width - num2, re.Y, num2, num2, 270f, 90f);
			pa.AddArc(re.Width - num4, re.Height - num4, num4, num4, 0f, 90f);
			pa.AddArc(re.X, re.Height - num3, num3, num3, 90f, 90f);
			pa.CloseFigure();
		}

		public void DrawArrow(Graphics gr)
		{
			int num = 1;
			RibbonColor ribbonColor = new RibbonColor(Color.FromArgb(this.R0, this.G0, this.B0));
			RibbonColor ribbonColor2 = new RibbonColor(this.ForeColor);
			if (ribbonColor.GetBrightness() > 50)
			{
				ribbonColor2.BC = 1;
				ribbonColor2.SC = 80f;
			}
			else
			{
				ribbonColor2.BC = 99;
				ribbonColor2.SC = 20f;
			}
			Color color = ribbonColor2.GetColor();
			switch (this._arrow)
			{
			case RibbonMenuButton.e_arrow.ToRight:
				if (this._imagelocation == RibbonMenuButton.e_imagelocation.Left)
				{
					int num2 = base.Width - this._splitdistance + 2 * this._imageoffset;
					Point[] points = new Point[]
					{
						new Point(num2 + 4, base.Height / 2 - 4 * num),
						new Point(num2 + 8, base.Height / 2),
						new Point(num2 + 4, base.Height / 2 + 4 * num)
					};
					gr.FillPolygon(new SolidBrush(color), points);
				}
				break;
			case RibbonMenuButton.e_arrow.ToDown:
				if (this._imagelocation == RibbonMenuButton.e_imagelocation.Left)
				{
					Point[] points = new Point[]
					{
						new Point(base.Width - 8 * num - this._imageoffset, base.Height / 2 - num / 2),
						new Point(base.Width - 2 * num - this._imageoffset, base.Height / 2 - num / 2),
						new Point(base.Width - 5 * num - this._imageoffset, base.Height / 2 + num * 2)
					};
					gr.FillPolygon(new SolidBrush(color), points);
				}
				else if (this._imagelocation == RibbonMenuButton.e_imagelocation.Top)
				{
					Point[] points = new Point[]
					{
						new Point(base.Width / 2 + 8 * num - this._imageoffset, base.Height - this._imageoffset - 5 * num),
						new Point(base.Width / 2 + 2 * num - this._imageoffset, base.Height - this._imageoffset - 5 * num),
						new Point(base.Width / 2 + 5 * num - this._imageoffset, base.Height - this._imageoffset - 2 * num)
					};
					gr.FillPolygon(new SolidBrush(color), points);
				}
				break;
			}
		}

		public void FillSplit(Graphics gr)
		{
			Color color = Color.FromArgb(200, 255, 255, 255);
			int num = base.Width - this._splitdistance;
			int num2 = 0;
			int num3 = base.Height - this._splitdistance;
			int num4 = 0;
			SolidBrush solidBrush = new SolidBrush(color);
			if (this._imagelocation == RibbonMenuButton.e_imagelocation.Left)
			{
				if (this.xmouse < base.Width - this._splitdistance & this.mouse)
				{
					Rectangle re = new Rectangle(num + 1, 1, base.Width - 2, base.Height - 1);
					GraphicsPath graphicsPath = new GraphicsPath();
					int radius = this._radius;
					this._radius = 4;
					this.DrawArc(re, graphicsPath);
					this._radius = radius;
					gr.FillPath(solidBrush, graphicsPath);
				}
				else if (this.mouse)
				{
					Rectangle re = new Rectangle(num2 + 1, 1, base.Width - this._splitdistance - 1, base.Height - 1);
					GraphicsPath graphicsPath = new GraphicsPath();
					int radius = this._radius;
					this._radius = 4;
					this.DrawArc(re, graphicsPath);
					this._radius = radius;
					gr.FillPath(solidBrush, graphicsPath);
				}
			}
			else if (this._imagelocation == RibbonMenuButton.e_imagelocation.Top)
			{
				if (this.ymouse < base.Height - this._splitdistance & this.mouse)
				{
					Rectangle re = new Rectangle(1, num3 + 1, base.Width - 1, base.Height - 1);
					GraphicsPath graphicsPath = new GraphicsPath();
					int radius = this._radius;
					this._radius = 4;
					this.DrawArc(re, graphicsPath);
					this._radius = radius;
					gr.FillPath(solidBrush, graphicsPath);
				}
				else if (this.mouse)
				{
					Rectangle re = new Rectangle(1, num4 + 1, base.Width - 1, base.Height - this._splitdistance - 1);
					GraphicsPath graphicsPath = new GraphicsPath();
					int radius = this._radius;
					this._radius = 4;
					this.DrawArc(re, graphicsPath);
					this._radius = radius;
					gr.FillPath(solidBrush, graphicsPath);
				}
			}
			solidBrush.Dispose();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (this.i_mode == 1)
			{
				if (Math.Abs((int)this.ColorOn.R - this.R0) > this.i_factor)
				{
					this.i_fR = this.i_factor;
				}
				else
				{
					this.i_fR = 1;
				}
				if (Math.Abs((int)this.ColorOn.G - this.G0) > this.i_factor)
				{
					this.i_fG = this.i_factor;
				}
				else
				{
					this.i_fG = 1;
				}
				if (Math.Abs((int)this.ColorOn.B - this.B0) > this.i_factor)
				{
					this.i_fB = this.i_factor;
				}
				else
				{
					this.i_fB = 1;
				}
				if ((int)this.ColorOn.R < this.R0)
				{
					this.R0 -= this.i_fR;
				}
				else if ((int)this.ColorOn.R > this.R0)
				{
					this.R0 += this.i_fR;
				}
				if ((int)this.ColorOn.G < this.G0)
				{
					this.G0 -= this.i_fG;
				}
				else if ((int)this.ColorOn.G > this.G0)
				{
					this.G0 += this.i_fG;
				}
				if ((int)this.ColorOn.B < this.B0)
				{
					this.B0 -= this.i_fB;
				}
				else if ((int)this.ColorOn.B > this.B0)
				{
					this.B0 += this.i_fB;
				}
				if (this.ColorOn == Color.FromArgb(this.R0, this.G0, this.B0))
				{
					this.timer1.Stop();
				}
				else
				{
					this.Refresh();
				}
			}
			if (this.i_mode == 0)
			{
				if (Math.Abs((int)this.ColorBase.R - this.R0) < this.i_factor)
				{
					this.i_fR = 1;
				}
				else
				{
					this.i_fR = this.i_factor;
				}
				if (Math.Abs((int)this.ColorBase.G - this.G0) < this.i_factor)
				{
					this.i_fG = 1;
				}
				else
				{
					this.i_fG = this.i_factor;
				}
				if (Math.Abs((int)this.ColorBase.B - this.B0) < this.i_factor)
				{
					this.i_fB = 1;
				}
				else
				{
					this.i_fB = this.i_factor;
				}
				if (Math.Abs((int)this.ColorBase.A - this.A0) < this.i_factor)
				{
					this.i_fA = 1;
				}
				else
				{
					this.i_fA = this.i_factor;
				}
				if ((int)this.ColorBase.R < this.R0)
				{
					this.R0 -= this.i_fR;
				}
				else if ((int)this.ColorBase.R > this.R0)
				{
					this.R0 += this.i_fR;
				}
				if ((int)this.ColorBase.G < this.G0)
				{
					this.G0 -= this.i_fG;
				}
				else if ((int)this.ColorBase.G > this.G0)
				{
					this.G0 += this.i_fG;
				}
				if ((int)this.ColorBase.B < this.B0)
				{
					this.B0 -= this.i_fB;
				}
				else if ((int)this.ColorBase.B > this.B0)
				{
					this.B0 += this.i_fB;
				}
				if ((int)this.ColorBase.A < this.A0)
				{
					this.A0 -= this.i_fA;
				}
				else if ((int)this.ColorBase.A > this.A0)
				{
					this.A0 += this.i_fA;
				}
				if (this.ColorBase == Color.FromArgb(this.A0, this.R0, this.G0, this.B0))
				{
					this.timer1.Stop();
				}
				else
				{
					this.Refresh();
				}
			}
			this.Refresh();
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this._colorStroke = this.ColorOnStroke;
			this._tempshowbase = this._showbase;
			this._showbase = RibbonMenuButton.e_showbase.Yes;
			this.i_mode = 1;
			this.xmouse = base.PointToClient(Cursor.Position).X;
			this.mouse = true;
			this.A0 = 200;
			if (this.i_factor == 0)
			{
				this.R0 = (int)this._onColor.R;
				this.G0 = (int)this._onColor.G;
				this.B0 = (int)this._onColor.B;
			}
			this.timer1.Start();
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.UpdateLeave();
		}

		public void UpdateLeave()
		{
			if (!this._keeppress | (this._keeppress & !this._ispressed))
			{
				this._colorStroke = this.ColorBaseStroke;
				this._showbase = this._tempshowbase;
				this.i_mode = 0;
				this.mouse = false;
				if (this.i_factor == 0)
				{
					this.R0 = (int)this._baseColor.R;
					this.G0 = (int)this._baseColor.G;
					this.B0 = (int)this._baseColor.B;
					this.Refresh();
				}
				else
				{
					this.timer1.Stop();
					this.timer1.Start();
				}
			}
		}

		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			base.OnMouseDown(mevent);
			this.R0 = (int)this.ColorPress.R;
			this.G0 = (int)this.ColorPress.G;
			this.B0 = (int)this.ColorPress.B;
			this._colorStroke = this.ColorPressStroke;
			this._showbase = RibbonMenuButton.e_showbase.Yes;
			this.i_mode = 2;
			this.xmouse = base.PointToClient(Cursor.Position).X;
			this.ymouse = base.PointToClient(Cursor.Position).Y;
			this.mouse = true;
		}

		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			this.R0 = (int)this.ColorOn.R;
			this.G0 = (int)this.ColorOn.G;
			this.B0 = (int)this.ColorOn.B;
			this._colorStroke = this.ColorOnStroke;
			this._showbase = RibbonMenuButton.e_showbase.Yes;
			this.i_mode = 1;
			this.mouse = true;
			if (this._imagelocation == RibbonMenuButton.e_imagelocation.Left & this.xmouse > base.Width - this._splitdistance & this._splitbutton == RibbonMenuButton.e_splitbutton.Yes)
			{
				if (this._arrow == RibbonMenuButton.e_arrow.ToDown)
				{
					if (this.ContextMenuStrip != null)
					{
						this.ContextMenuStrip.Opacity = 1.0;
					}
					this.ContextMenuStrip.Show(this, 0, base.Height);
				}
				else if (this._arrow == RibbonMenuButton.e_arrow.ToRight)
				{
					if (this.ContextMenuStrip != null)
					{
						ContextMenuStrip contextMenuStrip = this.ContextMenuStrip;
						this.ContextMenuStrip.Opacity = 1.0;
						if (this.MenuPos.Y == 0)
						{
							this.ContextMenuStrip.Show(this, base.Width + 2, -base.Height);
						}
						else
						{
							this.ContextMenuStrip.Show(this, base.Width + 2, this.MenuPos.Y);
						}
					}
				}
			}
			else if (this._imagelocation == RibbonMenuButton.e_imagelocation.Top & this.ymouse > base.Height - this._splitdistance & this._splitbutton == RibbonMenuButton.e_splitbutton.Yes)
			{
				if (this._arrow == RibbonMenuButton.e_arrow.ToDown)
				{
					if (this.ContextMenuStrip != null)
					{
						this.ContextMenuStrip.Show(this, 0, base.Height);
					}
				}
			}
			else
			{
				base.OnMouseUp(mevent);
				if (this._keeppress)
				{
					this._ispressed = true;
					try
					{
						foreach (Control control in base.Parent.Controls)
						{
							if (typeof(RibbonMenuButton) == control.GetType() & control.Name != base.Name)
							{
								((RibbonMenuButton)control)._ispressed = false;
								((RibbonMenuButton)control).UpdateLeave();
							}
						}
					}
					catch
					{
					}
				}
			}
		}

		protected override void OnMouseMove(MouseEventArgs mevent)
		{
			if (this.mouse & this.SplitButton == RibbonMenuButton.e_splitbutton.Yes)
			{
				this.xmouse = base.PointToClient(Cursor.Position).X;
				this.ymouse = base.PointToClient(Cursor.Position).Y;
				this.Refresh();
			}
			base.OnMouseMove(mevent);
		}
	}
}
