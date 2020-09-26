using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TwainLib;

namespace Sbn.AdvancedControls.Imaging.Scan
{
	public class ucScanImage : UserControl, IMessageFilter
	{
		private IContainer components = null;

		public FlowLayoutPanel PnlPictures;

		private bool msgfilter;

		private Twain tw;

		private int picnumber = 0;

		private Collection<Image> _AllScanedImage = new Collection<Image>();

		private ArrayList _pics = null;

		private ArrayList _DibHands = null;

		private BITMAPINFOHEADER bmi;

		private Rectangle bmprect;

		private IntPtr dibhand;

		private IntPtr bmpptr;

		private IntPtr pixptr;

		public event EventHandler<ImageEvent> ScanedImage;

		public Collection<Image> AllScanedImage
		{
			get
			{
				return this._AllScanedImage;
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
			this.PnlPictures = new FlowLayoutPanel();
			base.SuspendLayout();
			this.PnlPictures.AutoScroll = true;
			this.PnlPictures.BackColor = Color.Transparent;
			this.PnlPictures.BorderStyle = BorderStyle.FixedSingle;
			this.PnlPictures.Dock = DockStyle.Fill;
			this.PnlPictures.Location = new Point(0, 0);
			this.PnlPictures.Name = "PnlPictures";
			this.PnlPictures.Size = new Size(610, 520);
			this.PnlPictures.TabIndex = 0;
			this.PnlPictures.Paint += new PaintEventHandler(this.PnlPictures_Paint);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.Transparent;
			base.BorderStyle = BorderStyle.FixedSingle;
			base.Controls.Add(this.PnlPictures);
			base.Name = "ucScanImage";
			base.Size = new Size(610, 520);
			base.Load += new EventHandler(this.ucScanImage_Load);
			base.ResumeLayout(false);
		}

		public ucScanImage()
		{
			this.InitializeComponent();
			base.AutoScrollMinSize = new Size(this.bmprect.Width, this.bmprect.Height);
		}

		private void tw_ScanedImage(object sender, ImageEvent e)
		{
			if (sender is IntPtr)
			{
				IntPtr intPtr = (IntPtr)sender;
				this.bmprect = new Rectangle(0, 0, 0, 0);
				this.dibhand = intPtr;
				if (this._DibHands == null)
				{
					this._DibHands = new ArrayList();
				}
				this._DibHands.Add(this.dibhand);
				this.bmpptr = ucScanImage.GlobalLock(this.dibhand);
				this.pixptr = this.GetPixelInfo(this.bmpptr);
				Bitmap bitmap = new Bitmap(this.bmprect.Width, this.bmprect.Height);
				Graphics graphics = Graphics.FromImage(bitmap);
				IntPtr hdc = graphics.GetHdc();
				ucScanImage.SetDIBitsToDevice(hdc, 0, 0, this.bmprect.Width, this.bmprect.Height, 0, 0, 0, this.bmprect.Height, this.pixptr, this.bmpptr, 0);
				graphics.ReleaseHdc(hdc);
				Image thumbnailImage = bitmap.GetThumbnailImage(150, 200, new Image.GetThumbnailImageAbort(this.ThumbnailCallback), IntPtr.Zero);
				PictureBox pictureBox = new PictureBox();
				pictureBox.Height = 200;
				pictureBox.BorderStyle = BorderStyle.FixedSingle;
				pictureBox.Width = 150;
				pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
				pictureBox.Image = thumbnailImage;
				pictureBox.Tag = bitmap;
				this.PnlPictures.Controls.Add(pictureBox);
				if (this.ScanedImage != null)
				{
					ImageEvent e2 = new ImageEvent(bitmap);
					this.ScanedImage(this, e2);
				}
			}
		}

		private bool ThumbnailCallback()
		{
			return false;
		}

		bool IMessageFilter.PreFilterMessage(ref Message m)
		{
			ArrayList arrayList = this.tw.TransferPictures();
			this._DibHands = new ArrayList();
			bool result;
			if (arrayList.Count != 0)
			{
				this.EndingScan();
				this.tw.Finish();
				this.picnumber++;
				for (int i = 0; i < arrayList.Count; i++)
				{
				}
				result = true;
			}
			else
			{
				TwainCommand twainCommand = this.tw.PassMessage(ref m);
				if (twainCommand == TwainCommand.Null || twainCommand == TwainCommand.Not)
				{
					result = false;
				}
				else
				{
					switch (twainCommand)
					{
					case TwainCommand.TransferReady:
						this.EndingScan();
						this.tw.CloseSrc();
						this.picnumber++;
						for (int i = 0; i < arrayList.Count; i++)
						{
							IntPtr intPtr = (IntPtr)arrayList[i];
						}
						break;
					case TwainCommand.CloseRequest:
						this.EndingScan();
						this.tw.CloseSrc();
						break;
					case TwainCommand.CloseOk:
						this.EndingScan();
						this.tw.CloseSrc();
						break;
					}
					result = true;
				}
			}
			return result;
		}

		private void EndingScan()
		{
			if (this.msgfilter)
			{
				Application.RemoveMessageFilter(this);
				this.msgfilter = false;
			}
		}

		public void ucDispose()
		{
			try
			{
				if (this.dibhand != IntPtr.Zero)
				{
					foreach (IntPtr handle in this._DibHands)
					{
						ucScanImage.GlobalFree(handle);
					}
					this._DibHands.Clear();
					this._DibHands = null;
				}
				if (this.components != null)
				{
					this.components.Dispose();
				}
			}
			catch
			{
				throw;
			}
		}

		public void AquireImage()
		{
			try
			{
				this.tw = new Twain();
				this.tw.Init(base.Handle);
				this.tw.ScanedImage += new EventHandler<ImageEvent>(this.tw_ScanedImage);
				if (!this.msgfilter)
				{
					this.msgfilter = true;
					Application.AddMessageFilter(this);
				}
				this.tw.Acquire();
			}
			catch
			{
				throw;
			}
		}

		private void ucScanImage_Load(object sender, EventArgs e)
		{
		}

		protected IntPtr GetPixelInfo(IntPtr bmpptr)
		{
			IntPtr result;
			try
			{
				this.bmi = new BITMAPINFOHEADER();
				Marshal.PtrToStructure(bmpptr, this.bmi);
				this.bmprect.X = (this.bmprect.Y = 0);
				this.bmprect.Width = this.bmi.biWidth;
				this.bmprect.Height = this.bmi.biHeight;
				if (this.bmi.biSizeImage == 0)
				{
					this.bmi.biSizeImage = ((this.bmi.biWidth * (int)this.bmi.biBitCount + 31 & -32) >> 3) * this.bmi.biHeight;
				}
				int num = this.bmi.biClrUsed;
				if (num == 0 && this.bmi.biBitCount <= 8)
				{
					num = 1 << (int)this.bmi.biBitCount;
				}
				num = num * 4 + this.bmi.biSize + (int)bmpptr;
				if (this._pics == null)
				{
					this._pics = new ArrayList();
				}
				BITMAPINFO bITMAPINFO = new BITMAPINFO();
				bITMAPINFO.bmi = this.bmi;
				bITMAPINFO.bmpptr = bmpptr;
				bITMAPINFO.bmprect = this.bmprect;
				bITMAPINFO.pixptr = (IntPtr)num;
				this._pics.Add(bITMAPINFO);
				result = (IntPtr)num;
			}
			catch
			{
				throw;
			}
			return result;
		}

		[DllImport("gdi32.dll", ExactSpelling = true)]
		internal static extern int SetDIBitsToDevice(IntPtr hdc, int xdst, int ydst, int width, int height, int xsrc, int ysrc, int start, int lines, IntPtr bitsptr, IntPtr bmiptr, int color);

		[DllImport("kernel32.dll", ExactSpelling = true)]
		internal static extern IntPtr GlobalLock(IntPtr handle);

		[DllImport("kernel32.dll", ExactSpelling = true)]
		internal static extern IntPtr GlobalFree(IntPtr handle);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		public static extern void OutputDebugString(string outstr);

		[DllImport("gdi32.dll")]
		public static extern int SetDIBitsToDevice(IntPtr hDC, int DestX, int DestY, uint wDestWidth, uint wDestHeight, int SrcX, int SrcY, uint uStartScan, uint uScanLines, byte[] lpBits, ref BITMAPINFOHEADER BitsInfo, uint uColorUse);

		[DllImport("gdi32.dll")]
		public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

		private void PnlPictures_Paint(object sender, PaintEventArgs e)
		{
		}
	}
}
