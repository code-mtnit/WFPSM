using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms
{
	[DefaultEvent("Click")]
	public class SBNButton : Button
	{
		private enum State
		{
			None,
			Hover,
			Pressed
		}

		public enum Style
		{
			Default,
			Flat
		}

		private Container components = null;

		public bool _setByColorTable = false;

		private bool calledbykey = false;

		private SBNButton.State mButtonState = SBNButton.State.None;

		private Timer mFadeIn = new Timer();

		private Timer mFadeOut = new Timer();

		private int mGlowAlpha = 0;

		private string mText;

		private Color mForeColor = Color.White;

		private ContentAlignment mTextAlign = ContentAlignment.MiddleCenter;

		private Image mImage;

		private ContentAlignment mImageAlign = ContentAlignment.MiddleLeft;

		private Size mImageSize = new Size(24, 24);

		private SBNButton.Style mButtonStyle = SBNButton.Style.Default;

		private int mCornerRadius = 8;

		private Color mHighlightColor = Color.White;

		private Color mButtonColor = Color.Black;

		private Color mGlowColor = Color.FromArgb(141, 189, 255);

		private Image mBackImage;

		private Color mBaseColor = Color.Black;

		[Browsable(true), Category("SbnControls"), DefaultValue(false), Description("با فعال كردن اين گزينه تمام خواص رنگي اين كنترل از جدول رنگ كنترل در بر گيرنده آن ارث برده مي شود.")]
		public bool SetByColorTable
		{
			get
			{
				return this._setByColorTable;
			}
			set
			{
				this._setByColorTable = value;
			}
		}

		[Category("Text"), Description("The text that is displayed on the button.")]
		public string ButtonText
		{
			get
			{
				return this.mText;
			}
			set
			{
				this.mText = value;
				base.Invalidate();
			}
		}

		[Browsable(true), Category("Text"), DefaultValue(typeof(Color), "White"), Description("The color with which the text is drawn.")]
		public override Color ForeColor
		{
			get
			{
				return this.mForeColor;
			}
			set
			{
				this.mForeColor = value;
				base.Invalidate();
			}
		}

		[Category("Text"), DefaultValue(typeof(ContentAlignment), "MiddleCenter"), Description("The alignment of the button text that is displayed on the control.")]
		public override ContentAlignment TextAlign
		{
			get
			{
				return this.mTextAlign;
			}
			set
			{
				this.mTextAlign = value;
				base.Invalidate();
			}
		}

		[Category("Image"), DefaultValue(null), Description("The image displayed on the button that is used to help the user identifyit's function if the text is ambiguous.")]
		public new Image Image
		{
			get
			{
				return this.mImage;
			}
			set
			{
				this.mImage = value;
				base.Invalidate();
			}
		}

		[Category("Image"), DefaultValue(typeof(ContentAlignment), "MiddleLeft"), Description("The alignment of the image in relation to the button.")]
		public new ContentAlignment ImageAlign
		{
			get
			{
				return this.mImageAlign;
			}
			set
			{
				this.mImageAlign = value;
				base.Invalidate();
			}
		}

		[Category("Image"), DefaultValue(typeof(Size), "24, 24"), Description("The size of the image to be displayed on thebutton. This property defaults to 24x24.")]
		public Size ImageSize
		{
			get
			{
				return this.mImageSize;
			}
			set
			{
				this.mImageSize = value;
				base.Invalidate();
			}
		}

		[Category("Appearance"), DefaultValue(typeof(SBNButton.Style), "Default"), Description("Sets whether the button background is drawn while the mouse is outside of the client area.")]
		public SBNButton.Style ButtonStyle
		{
			get
			{
				return this.mButtonStyle;
			}
			set
			{
				this.mButtonStyle = value;
				base.Invalidate();
			}
		}

		[Category("Appearance"), DefaultValue(8), Description("The radius for the button corners. The greater this value is, the more 'smooth' the corners are. This property should not be greater than half of the controls height.")]
		public int CornerRadius
		{
			get
			{
				return this.mCornerRadius;
			}
			set
			{
				this.mCornerRadius = value;
				base.Invalidate();
			}
		}

		[Category("Appearance"), DefaultValue(typeof(Color), "White"), Description("The colour of the highlight on the top of the button.")]
		public Color HighlightColor
		{
			get
			{
				return this.mHighlightColor;
			}
			set
			{
				this.mHighlightColor = value;
				base.Invalidate();
			}
		}

		[Category("Appearance"), DefaultValue(typeof(Color), "Black"), Description("The bottom color of the button that will be drawn over the base color.")]
		public Color ButtonColor
		{
			get
			{
				return this.mButtonColor;
			}
			set
			{
				this.mButtonColor = value;
				base.Invalidate();
			}
		}

		[Category("Appearance"), DefaultValue(typeof(Color), "141,189,255"), Description("The colour that the button glows when the mouse is inside the client area.")]
		public Color GlowColor
		{
			get
			{
				return this.mGlowColor;
			}
			set
			{
				this.mGlowColor = value;
				base.Invalidate();
			}
		}

		[Category("Appearance"), DefaultValue(null), Description("The background image for the button, this image is drawn over the base color of the button.")]
		public Image BackImage
		{
			get
			{
				return this.mBackImage;
			}
			set
			{
				this.mBackImage = value;
				base.Invalidate();
			}
		}

		[Category("Appearance"), DefaultValue(typeof(Color), "Black"), Description("The backing color that the rest ofthe button is drawn. For a glassier effect set this property to Transparent.")]
		public Color BaseColor
		{
			get
			{
				return this.mBaseColor;
			}
			set
			{
				this.mBaseColor = value;
				base.Invalidate();
			}
		}

		public SBNButton()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			base.SetStyle(ControlStyles.DoubleBuffer, true);
			base.SetStyle(ControlStyles.ResizeRedraw, true);
			base.SetStyle(ControlStyles.Selectable, true);
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			base.SetStyle(ControlStyles.UserPaint, true);
			this.BackColor = Color.Transparent;
			this.mFadeIn.Interval = 30;
			this.mFadeOut.Interval = 30;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.components != null)
				{
					this.components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			base.Name = "VistaButton";
			base.Size = new Size(100, 32);
			base.Paint += new PaintEventHandler(this.VistaButton_Paint);
			base.KeyUp += new KeyEventHandler(this.VistaButton_KeyUp);
			base.KeyDown += new KeyEventHandler(this.VistaButton_KeyDown);
			base.MouseEnter += new EventHandler(this.VistaButton_MouseEnter);
			base.MouseLeave += new EventHandler(this.VistaButton_MouseLeave);
			base.MouseUp += new MouseEventHandler(this.VistaButton_MouseUp);
			base.MouseDown += new MouseEventHandler(this.VistaButton_MouseDown);
			base.GotFocus += new EventHandler(this.VistaButton_MouseEnter);
			base.LostFocus += new EventHandler(this.VistaButton_MouseLeave);
			this.mFadeIn.Tick += new EventHandler(this.mFadeIn_Tick);
			this.mFadeOut.Tick += new EventHandler(this.mFadeOut_Tick);
			base.Resize += new EventHandler(this.VistaButton_Resize);
		}

		private GraphicsPath RoundRect(RectangleF r, float r1, float r2, float r3, float r4)
		{
			float x = r.X;
			float y = r.Y;
			float width = r.Width;
			float height = r.Height;
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddBezier(x, y + r1, x, y, x + r1, y, x + r1, y);
			graphicsPath.AddLine(x + r1, y, x + width - r2, y);
			graphicsPath.AddBezier(x + width - r2, y, x + width, y, x + width, y + r2, x + width, y + r2);
			graphicsPath.AddLine(x + width, y + r2, x + width, y + height - r3);
			graphicsPath.AddBezier(x + width, y + height - r3, x + width, y + height, x + width - r3, y + height, x + width - r3, y + height);
			graphicsPath.AddLine(x + width - r3, y + height, x + r4, y + height);
			graphicsPath.AddBezier(x + r4, y + height, x, y + height, x, y + height - r4, x, y + height - r4);
			graphicsPath.AddLine(x, y + height - r4, x, y + r1);
			return graphicsPath;
		}

		private StringFormat StringFormatAlignment(ContentAlignment textalign)
		{
			StringFormat stringFormat = new StringFormat();
			if (textalign > ContentAlignment.MiddleCenter)
			{
				if (textalign <= ContentAlignment.BottomLeft)
				{
					if (textalign == ContentAlignment.MiddleRight)
					{
						goto IL_65;
					}
					if (textalign != ContentAlignment.BottomLeft)
					{
						goto IL_79;
					}
				}
				else if (textalign != ContentAlignment.BottomCenter && textalign != ContentAlignment.BottomRight)
				{
					goto IL_79;
				}
				stringFormat.LineAlignment = StringAlignment.Far;
				goto IL_79;
			}
			switch (textalign)
			{
			case ContentAlignment.TopLeft:
			case ContentAlignment.TopCenter:
			case ContentAlignment.TopRight:
				stringFormat.LineAlignment = StringAlignment.Near;
				goto IL_79;
			case (ContentAlignment)3:
				goto IL_79;
			default:
				if (textalign != ContentAlignment.MiddleLeft && textalign != ContentAlignment.MiddleCenter)
				{
					goto IL_79;
				}
				break;
			}
			IL_65:
			stringFormat.LineAlignment = StringAlignment.Center;
			IL_79:
			if (textalign <= ContentAlignment.MiddleCenter)
			{
				switch (textalign)
				{
				case ContentAlignment.TopLeft:
					break;
				case ContentAlignment.TopCenter:
					goto IL_D7;
				case (ContentAlignment)3:
					return stringFormat;
				case ContentAlignment.TopRight:
					goto IL_E1;
				default:
					if (textalign != ContentAlignment.MiddleLeft)
					{
						if (textalign != ContentAlignment.MiddleCenter)
						{
							return stringFormat;
						}
						goto IL_D7;
					}
					break;
				}
			}
			else if (textalign <= ContentAlignment.BottomLeft)
			{
				if (textalign == ContentAlignment.MiddleRight)
				{
					goto IL_E1;
				}
				if (textalign != ContentAlignment.BottomLeft)
				{
					return stringFormat;
				}
			}
			else
			{
				if (textalign == ContentAlignment.BottomCenter)
				{
					goto IL_D7;
				}
				if (textalign != ContentAlignment.BottomRight)
				{
					return stringFormat;
				}
				goto IL_E1;
			}
			stringFormat.Alignment = StringAlignment.Near;
			return stringFormat;
			IL_D7:
			stringFormat.Alignment = StringAlignment.Center;
			return stringFormat;
			IL_E1:
			stringFormat.Alignment = StringAlignment.Far;
			return stringFormat;
		}

		private void DrawOuterStroke(Graphics g)
		{
			if (this.ButtonStyle != SBNButton.Style.Flat || this.mButtonState != SBNButton.State.None)
			{
				Rectangle clientRectangle = base.ClientRectangle;
				clientRectangle.Width--;
				clientRectangle.Height--;
				using (GraphicsPath graphicsPath = this.RoundRect(clientRectangle, (float)this.CornerRadius, (float)this.CornerRadius, (float)this.CornerRadius, (float)this.CornerRadius))
				{
					using (Pen pen = new Pen(this.ButtonColor))
					{
						g.DrawPath(pen, graphicsPath);
					}
				}
			}
		}

		private void DrawInnerStroke(Graphics g)
		{
			if (this.ButtonStyle != SBNButton.Style.Flat || this.mButtonState != SBNButton.State.None)
			{
				Rectangle clientRectangle = base.ClientRectangle;
				clientRectangle.X++;
				clientRectangle.Y++;
				clientRectangle.Width -= 3;
				clientRectangle.Height -= 3;
				using (GraphicsPath graphicsPath = this.RoundRect(clientRectangle, (float)this.CornerRadius, (float)this.CornerRadius, (float)this.CornerRadius, (float)this.CornerRadius))
				{
					using (Pen pen = new Pen(this.HighlightColor))
					{
						g.DrawPath(pen, graphicsPath);
					}
				}
			}
		}

		private void DrawBackground(Graphics g)
		{
			if (this.ButtonStyle != SBNButton.Style.Flat || this.mButtonState != SBNButton.State.None)
			{
				int alpha = (this.mButtonState == SBNButton.State.Pressed) ? 204 : 127;
				Rectangle clientRectangle = base.ClientRectangle;
				clientRectangle.Width--;
				clientRectangle.Height--;
				using (GraphicsPath graphicsPath = this.RoundRect(clientRectangle, (float)this.CornerRadius, (float)this.CornerRadius, (float)this.CornerRadius, (float)this.CornerRadius))
				{
					using (SolidBrush solidBrush = new SolidBrush(this.BaseColor))
					{
						g.FillPath(solidBrush, graphicsPath);
					}
					this.SetClip(g);
					if (this.BackImage != null)
					{
						g.DrawImage(this.BackImage, base.ClientRectangle);
					}
					g.ResetClip();
					using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(alpha, this.ButtonColor)))
					{
						g.FillPath(solidBrush, graphicsPath);
					}
				}
			}
		}

		private void DrawHighlight(Graphics g)
		{
			if (this.ButtonStyle != SBNButton.Style.Flat || this.mButtonState != SBNButton.State.None)
			{
				int num = (this.mButtonState == SBNButton.State.Pressed) ? 60 : 150;
				Rectangle r = new Rectangle(0, 0, base.Width, base.Height / 2);
				using (GraphicsPath graphicsPath = this.RoundRect(r, (float)this.CornerRadius, (float)this.CornerRadius, 0f, 0f))
				{
					using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(graphicsPath.GetBounds(), Color.FromArgb(num, this.HighlightColor), Color.FromArgb(num / 3, this.HighlightColor), LinearGradientMode.Vertical))
					{
						g.FillPath(linearGradientBrush, graphicsPath);
					}
				}
			}
		}

		private void DrawGlow(Graphics g)
		{
			if (this.mButtonState != SBNButton.State.Pressed)
			{
				this.SetClip(g);
				using (GraphicsPath graphicsPath = new GraphicsPath())
				{
					graphicsPath.AddEllipse(-5, base.Height / 2 - 10, base.Width + 11, base.Height + 11);
					using (PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath))
					{
						pathGradientBrush.CenterColor = Color.FromArgb(this.mGlowAlpha, this.GlowColor);
						pathGradientBrush.SurroundColors = new Color[]
						{
							Color.FromArgb(0, this.GlowColor)
						};
						g.FillPath(pathGradientBrush, graphicsPath);
					}
				}
				g.ResetClip();
			}
		}

		private void DrawText(Graphics g)
		{
			StringFormat format = this.StringFormatAlignment(this.TextAlign);
			Rectangle r = new Rectangle(8, 8, base.Width - 17, base.Height - 17);
			g.DrawString(this.ButtonText, this.Font, new SolidBrush(this.ForeColor), r, format);
		}

		private void DrawImage(Graphics g)
		{
			if (this.Image != null)
			{
				Rectangle rect = new Rectangle(8, 8, this.ImageSize.Width, this.ImageSize.Height);
				ContentAlignment imageAlign = this.ImageAlign;
				if (imageAlign <= ContentAlignment.MiddleCenter)
				{
					switch (imageAlign)
					{
					case ContentAlignment.TopCenter:
						rect = new Rectangle(base.Width / 2 - this.ImageSize.Width / 2, 8, this.ImageSize.Width, this.ImageSize.Height);
						break;
					case (ContentAlignment)3:
						break;
					case ContentAlignment.TopRight:
						rect = new Rectangle(base.Width - 8 - this.ImageSize.Width, 8, this.ImageSize.Width, this.ImageSize.Height);
						break;
					default:
						if (imageAlign != ContentAlignment.MiddleLeft)
						{
							if (imageAlign == ContentAlignment.MiddleCenter)
							{
								rect = new Rectangle(base.Width / 2 - this.ImageSize.Width / 2, base.Height / 2 - this.ImageSize.Height / 2, this.ImageSize.Width, this.ImageSize.Height);
							}
						}
						else
						{
							rect = new Rectangle(8, base.Height / 2 - this.ImageSize.Height / 2, this.ImageSize.Width, this.ImageSize.Height);
						}
						break;
					}
				}
				else if (imageAlign <= ContentAlignment.BottomLeft)
				{
					if (imageAlign != ContentAlignment.MiddleRight)
					{
						if (imageAlign == ContentAlignment.BottomLeft)
						{
							rect = new Rectangle(8, base.Height - 8 - this.ImageSize.Height, this.ImageSize.Width, this.ImageSize.Height);
						}
					}
					else
					{
						rect = new Rectangle(base.Width - 8 - this.ImageSize.Width, base.Height / 2 - this.ImageSize.Height / 2, this.ImageSize.Width, this.ImageSize.Height);
					}
				}
				else if (imageAlign != ContentAlignment.BottomCenter)
				{
					if (imageAlign == ContentAlignment.BottomRight)
					{
						rect = new Rectangle(base.Width - 8 - this.ImageSize.Width, base.Height - 8 - this.ImageSize.Height, this.ImageSize.Width, this.ImageSize.Height);
					}
				}
				else
				{
					rect = new Rectangle(base.Width / 2 - this.ImageSize.Width / 2, base.Height - 8 - this.ImageSize.Height, this.ImageSize.Width, this.ImageSize.Height);
				}
				g.DrawImage(this.Image, rect);
			}
		}

		private void SetClip(Graphics g)
		{
			Rectangle clientRectangle = base.ClientRectangle;
			clientRectangle.X++;
			clientRectangle.Y++;
			clientRectangle.Width -= 3;
			clientRectangle.Height -= 3;
			using (GraphicsPath graphicsPath = this.RoundRect(clientRectangle, (float)this.CornerRadius, (float)this.CornerRadius, (float)this.CornerRadius, (float)this.CornerRadius))
			{
				g.SetClip(graphicsPath);
			}
		}

		private void VistaButton_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			this.DrawBackground(e.Graphics);
			this.DrawHighlight(e.Graphics);
			this.DrawImage(e.Graphics);
			this.DrawText(e.Graphics);
			this.DrawGlow(e.Graphics);
			this.DrawOuterStroke(e.Graphics);
			this.DrawInnerStroke(e.Graphics);
		}

		private void VistaButton_Resize(object sender, EventArgs e)
		{
			Rectangle clientRectangle = base.ClientRectangle;
			clientRectangle.X--;
			clientRectangle.Y--;
			clientRectangle.Width += 2;
			clientRectangle.Height += 2;
			using (GraphicsPath graphicsPath = this.RoundRect(clientRectangle, (float)this.CornerRadius, (float)this.CornerRadius, (float)this.CornerRadius, (float)this.CornerRadius))
			{
				base.Region = new Region(graphicsPath);
			}
		}

		private void VistaButton_MouseEnter(object sender, EventArgs e)
		{
			this.mButtonState = SBNButton.State.Hover;
			this.mFadeOut.Stop();
			this.mFadeIn.Start();
		}

		private void VistaButton_MouseLeave(object sender, EventArgs e)
		{
			this.mButtonState = SBNButton.State.None;
			if (this.mButtonStyle == SBNButton.Style.Flat)
			{
				this.mGlowAlpha = 0;
			}
			this.mFadeIn.Stop();
			this.mFadeOut.Start();
		}

		private void VistaButton_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.mButtonState = SBNButton.State.Pressed;
				if (this.mButtonStyle != SBNButton.Style.Flat)
				{
					this.mGlowAlpha = 255;
				}
				this.mFadeIn.Stop();
				this.mFadeOut.Stop();
				base.Invalidate();
			}
		}

		private void mFadeIn_Tick(object sender, EventArgs e)
		{
			if (this.ButtonStyle == SBNButton.Style.Flat)
			{
				this.mGlowAlpha = 0;
			}
			if (this.mGlowAlpha + 30 >= 255)
			{
				this.mGlowAlpha = 255;
				this.mFadeIn.Stop();
			}
			else
			{
				this.mGlowAlpha += 30;
			}
			base.Invalidate();
		}

		private void mFadeOut_Tick(object sender, EventArgs e)
		{
			if (this.ButtonStyle == SBNButton.Style.Flat)
			{
				this.mGlowAlpha = 0;
			}
			if (this.mGlowAlpha - 30 <= 0)
			{
				this.mGlowAlpha = 0;
				this.mFadeOut.Stop();
			}
			else
			{
				this.mGlowAlpha -= 30;
			}
			base.Invalidate();
		}

		private void VistaButton_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space)
			{
				MouseEventArgs e2 = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0);
				this.VistaButton_MouseDown(sender, e2);
			}
		}

		private void VistaButton_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space)
			{
				MouseEventArgs e2 = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0);
				this.calledbykey = true;
				this.VistaButton_MouseUp(sender, e2);
			}
		}

		private void VistaButton_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.mButtonState = SBNButton.State.Hover;
				this.mFadeIn.Stop();
				this.mFadeOut.Stop();
				base.Invalidate();
				if (this.calledbykey)
				{
					this.OnClick(EventArgs.Empty);
					this.calledbykey = false;
				}
			}
		}
	}
}
