using Hatefnet.Products.Controls.Magnifier.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Hatefnet.Products.Controls.Magnifier
{
	public class MagnifierForm : Form
	{
		private delegate void RepositionAndShowDelegate();

		private Timer mTimer;

		private Configuration mConfiguration;

		private Image mImageMagnifier;

		private Image mBufferImage = null;

		private Image mScreenImage = null;

		private Point mStartPoint;

		private PointF mTargetPoint;

		private PointF mCurrentPoint;

		private Point mOffset;

		private bool mFirstTime = true;

		private static Point mLastMagnifierPosition = Cursor.Position;

		private IContainer components = null;

		public MagnifierForm(Configuration configuration, Point startPoint)
		{
			this.InitializeComponent();
			this.mConfiguration = configuration;
			base.FormBorderStyle = FormBorderStyle.None;
			base.ShowInTaskbar = this.mConfiguration.ShowInTaskbar;
			base.TopMost = this.mConfiguration.TopMostWindow;
			base.Width = this.mConfiguration.MagnifierWidth;
			base.Height = this.mConfiguration.MagnifierHeight;
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddEllipse(base.ClientRectangle);
			base.Region = new Region(graphicsPath);
			this.mImageMagnifier = Resources.magnifierGlass;
			this.mTimer = new Timer();
			this.mTimer.Enabled = true;
			this.mTimer.Interval = 20;
			this.mTimer.Tick += new EventHandler(this.HandleTimer);
			this.mScreenImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
			this.mStartPoint = startPoint;
			this.mTargetPoint = startPoint;
			if (this.mConfiguration.ShowInTaskbar)
			{
				base.ShowInTaskbar = true;
			}
			else
			{
				base.ShowInTaskbar = false;
			}
		}

		protected override void OnShown(EventArgs e)
		{
			this.RepositionAndShow();
		}

		private void RepositionAndShow()
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new MagnifierForm.RepositionAndShowDelegate(this.RepositionAndShow));
			}
			else
			{
				Graphics graphics = Graphics.FromImage(this.mScreenImage);
				graphics.CopyFromScreen(0, 0, 0, 0, new Size(this.mScreenImage.Width, this.mScreenImage.Height));
				graphics.Dispose();
				if (this.mConfiguration.HideMouseCursor)
				{
					Cursor.Hide();
				}
				else
				{
					this.Cursor = Cursors.Cross;
				}
				base.Capture = true;
				if (this.mConfiguration.RememberLastPoint)
				{
					base.Left = Cursor.Position.X - base.Width / 2;
					base.Top = Cursor.Position.Y - base.Height / 2;
				}
				else
				{
					this.mCurrentPoint = Cursor.Position;
				}
				base.Show();
			}
		}

		private void HandleTimer(object sender, EventArgs e)
		{
			float num = this.mConfiguration.SpeedFactor * (this.mTargetPoint.X - this.mCurrentPoint.X);
			float num2 = this.mConfiguration.SpeedFactor * (this.mTargetPoint.Y - this.mCurrentPoint.Y);
			if (this.mFirstTime)
			{
				this.mFirstTime = false;
				this.mCurrentPoint.X = this.mTargetPoint.X;
				this.mCurrentPoint.Y = this.mTargetPoint.Y;
				base.Left = (int)this.mCurrentPoint.X - base.Width / 2;
				base.Top = (int)this.mCurrentPoint.Y - base.Height / 2;
			}
			else
			{
				this.mCurrentPoint.X = this.mCurrentPoint.X + num;
				this.mCurrentPoint.Y = this.mCurrentPoint.Y + num2;
				if (Math.Abs(num) < 1f && Math.Abs(num2) < 1f)
				{
					this.mTimer.Enabled = false;
				}
				else
				{
					base.Left = (int)this.mCurrentPoint.X - base.Width / 2;
					base.Top = (int)this.mCurrentPoint.Y - base.Height / 2;
					MagnifierForm.mLastMagnifierPosition = new Point((int)this.mCurrentPoint.X, (int)this.mCurrentPoint.Y);
				}
				this.Refresh();
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			this.mOffset = new Point(base.Width / 2 - e.X, base.Height / 2 - e.Y);
			this.mCurrentPoint = base.PointToScreen(new Point(e.X + this.mOffset.X, e.Y + this.mOffset.Y));
			this.mTargetPoint = this.mCurrentPoint;
			this.mTimer.Enabled = true;
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (this.mConfiguration.CloseOnMouseUp)
			{
				base.Close();
				this.mScreenImage.Dispose();
			}
			Cursor.Show();
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.mTargetPoint = base.PointToScreen(new Point(e.X + this.mOffset.X, e.Y + this.mOffset.Y));
				this.mTimer.Enabled = true;
			}
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			if (!this.mConfiguration.DoubleBuffered)
			{
				base.OnPaintBackground(e);
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (this.mBufferImage == null)
			{
				this.mBufferImage = new Bitmap(base.Width, base.Height);
			}
			Graphics graphics = Graphics.FromImage(this.mBufferImage);
			Graphics graphics2;
			if (this.mConfiguration.DoubleBuffered)
			{
				graphics2 = graphics;
			}
			else
			{
				graphics2 = e.Graphics;
			}
			if (this.mScreenImage != null)
			{
				Rectangle destRect = new Rectangle(0, 0, base.Width, base.Height);
				int num = (int)((float)base.Width / this.mConfiguration.ZoomFactor);
				int num2 = (int)((float)base.Height / this.mConfiguration.ZoomFactor);
				int srcX = base.Left - num / 2 + base.Width / 2;
				int srcY = base.Top - num2 / 2 + base.Height / 2;
				graphics2.DrawImage(this.mScreenImage, destRect, srcX, srcY, num, num2, GraphicsUnit.Pixel);
			}
			if (this.mImageMagnifier != null)
			{
				graphics2.DrawImage(this.mImageMagnifier, 0, 0, base.Width, base.Height);
			}
			if (this.mConfiguration.DoubleBuffered)
			{
				e.Graphics.DrawImage(this.mBufferImage, 0, 0, base.Width, base.Height);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(292, 269);
			base.Name = "MagnifierForm";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "MagnifierUI";
			base.ResumeLayout(false);
		}
	}
}
