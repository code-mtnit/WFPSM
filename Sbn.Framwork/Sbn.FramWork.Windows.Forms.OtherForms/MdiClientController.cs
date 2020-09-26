using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms.OtherForms
{
	[ToolboxBitmap(typeof(MdiClientController))]
	public class MdiClientController : NativeWindow, IComponent, IDisposable
	{
		private struct RECT
		{
			public int left;

			public int top;

			public int right;

			public int bottom;

			public RECT(Rectangle rect)
			{
				this.left = rect.Left;
				this.top = rect.Top;
				this.right = rect.Right;
				this.bottom = rect.Bottom;
			}

			public RECT(int left, int top, int right, int bottom)
			{
				this.left = left;
				this.top = top;
				this.right = right;
				this.bottom = bottom;
			}
		}

		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		private struct PAINTSTRUCT
		{
			public IntPtr hdc;

			public int fErase;

			public MdiClientController.RECT rcPaint;

			public int fRestore;

			public int fIncUpdate;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
			public byte[] rgbReserved;
		}

		private struct NCCALCSIZE_PARAMS
		{
			public MdiClientController.RECT rgrc0;

			public MdiClientController.RECT rgrc1;

			public MdiClientController.RECT rgrc2;

			public IntPtr lppos;
		}

		private const int WM_PAINT = 15;

		private const int WM_ERASEBKGND = 20;

		private const int WM_NCPAINT = 133;

		private const int WM_THEMECHANGED = 794;

		private const int WM_NCCALCSIZE = 131;

		private const int WM_SIZE = 5;

		private const int WM_PRINTCLIENT = 792;

		private const uint SWP_NOSIZE = 1u;

		private const uint SWP_NOMOVE = 2u;

		private const uint SWP_NOZORDER = 4u;

		private const uint SWP_NOREDRAW = 8u;

		private const uint SWP_NOACTIVATE = 16u;

		private const uint SWP_FRAMECHANGED = 32u;

		private const uint SWP_SHOWWINDOW = 64u;

		private const uint SWP_HIDEWINDOW = 128u;

		private const uint SWP_NOCOPYBITS = 256u;

		private const uint SWP_NOOWNERZORDER = 512u;

		private const uint SWP_NOSENDCHANGING = 1024u;

		private const int WS_BORDER = 8388608;

		private const int WS_EX_CLIENTEDGE = 512;

		private const int WS_DISABLED = 134217728;

		private const int GWL_STYLE = -16;

		private const int GWL_EXSTYLE = -20;

		private const int SB_HORZ = 0;

		private const int SB_VERT = 1;

		private const int SB_CTL = 2;

		private const int SB_BOTH = 3;

		private Form parentForm;

		private MdiClient mdiClient;

		private BorderStyle borderStyle;

		private Color backColor;

		private bool autoScroll;

		private Image image;

		private ContentAlignment imageAlign;

		private bool stretchImage;

		private ISite site;

		[Category("Appearance"), Description("Occurs when a control needs repainting.")]
		public event PaintEventHandler Paint;

		[Browsable(false)]
		public event EventHandler Disposed;

		[Browsable(false)]
		public event EventHandler HandleAssigned;

		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ISite Site
		{
			get
			{
				return this.site;
			}
			set
			{
				this.site = value;
				if (this.site != null)
				{
					IDesignerHost designerHost = value.GetService(typeof(IDesignerHost)) as IDesignerHost;
					if (designerHost != null)
					{
						Form form = designerHost.RootComponent as Form;
						if (form != null)
						{
							this.ParentForm = form;
						}
					}
				}
			}
		}

		[Browsable(false)]
		public Form ParentForm
		{
			get
			{
				return this.parentForm;
			}
			set
			{
				if (this.parentForm != null)
				{
					this.parentForm.HandleCreated -= new EventHandler(this.ParentFormHandleCreated);
				}
				this.parentForm = value;
				if (this.parentForm != null)
				{
					if (this.parentForm.IsHandleCreated)
					{
						this.InitializeMdiClient();
						this.RefreshProperties();
					}
					else
					{
						this.parentForm.HandleCreated += new EventHandler(this.ParentFormHandleCreated);
					}
				}
			}
		}

		[Browsable(false)]
		public MdiClient MdiClient
		{
			get
			{
				return this.mdiClient;
			}
		}

		[Category("Appearance"), DefaultValue(typeof(Color), "AppWorkspace"), Description("The backcolor used to display text and graphics in the control.")]
		public Color BackColor
		{
			get
			{
				Color result;
				if (this.mdiClient != null)
				{
					result = this.mdiClient.BackColor;
				}
				else
				{
					result = this.backColor;
				}
				return result;
			}
			set
			{
				this.backColor = value;
				if (this.mdiClient != null)
				{
					this.mdiClient.BackColor = value;
				}
			}
		}

		[Category("Appearance"), DefaultValue(BorderStyle.Fixed3D), Description("Indicates whether the MDI area should have a border.")]
		public BorderStyle BorderStyle
		{
			get
			{
				return this.borderStyle;
			}
			set
			{
				if (!Enum.IsDefined(typeof(BorderStyle), value))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(BorderStyle));
				}
				this.borderStyle = value;
				if (this.mdiClient != null)
				{
					if (this.site == null || !this.site.DesignMode)
					{
						int num = MdiClientController.GetWindowLong(this.mdiClient.Handle, -16);
						int num2 = MdiClientController.GetWindowLong(this.mdiClient.Handle, -20);
						switch (this.borderStyle)
						{
						case BorderStyle.None:
							num &= -8388609;
							num2 &= -513;
							break;
						case BorderStyle.FixedSingle:
							num2 &= -513;
							num |= 8388608;
							break;
						case BorderStyle.Fixed3D:
							num2 |= 512;
							num &= -8388609;
							break;
						}
						MdiClientController.SetWindowLong(this.mdiClient.Handle, -16, num);
						MdiClientController.SetWindowLong(this.mdiClient.Handle, -20, num2);
						this.UpdateStyles();
					}
				}
			}
		}

		[Category("Layout"), DefaultValue(true), Description("Determines whether scrollbars will automatically appear if controls are placed outside the MDI client area.")]
		public bool AutoScroll
		{
			get
			{
				return this.autoScroll;
			}
			set
			{
				this.autoScroll = value;
				if (this.mdiClient != null)
				{
					this.UpdateStyles();
				}
			}
		}

		[Category("Appearance"), DefaultValue(null), Description("The image displayed in the MDI client area.")]
		public Image Image
		{
			get
			{
				return this.image;
			}
			set
			{
				this.image = value;
				if (this.mdiClient != null)
				{
					this.mdiClient.Invalidate();
				}
			}
		}

		[Category("Appearance"), DefaultValue(ContentAlignment.MiddleCenter), Description("Determines the position of the image within the MDI client area.")]
		public ContentAlignment ImageAlign
		{
			get
			{
				return this.imageAlign;
			}
			set
			{
				if (!Enum.IsDefined(typeof(ContentAlignment), value))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(ContentAlignment));
				}
				this.imageAlign = value;
				if (this.mdiClient != null)
				{
					this.mdiClient.Invalidate();
				}
			}
		}

		[Category("Appearance"), DefaultValue(false), Description("Determines whether the image should be scaled to fill the entire client area.")]
		public bool StretchImage
		{
			get
			{
				return this.stretchImage;
			}
			set
			{
				this.stretchImage = value;
				if (this.mdiClient != null)
				{
					this.mdiClient.Invalidate();
				}
			}
		}

		[Browsable(false)]
		public new IntPtr Handle
		{
			get
			{
				return base.Handle;
			}
		}

		public MdiClientController() : this(null)
		{
		}

		public MdiClientController(Form parentForm)
		{
			this.site = null;
			this.parentForm = null;
			this.mdiClient = null;
			this.backColor = SystemColors.AppWorkspace;
			this.borderStyle = BorderStyle.Fixed3D;
			this.autoScroll = true;
			this.image = null;
			this.imageAlign = ContentAlignment.MiddleCenter;
			this.stretchImage = false;
			this.ParentForm = parentForm;
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		public void RenewMdiClient()
		{
			this.InitializeMdiClient();
			this.RefreshProperties();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				lock (this)
				{
					if (this.site != null && this.site.Container != null)
					{
						this.site.Container.Remove(this);
					}
					if (this.Disposed != null)
					{
						this.Disposed(this, EventArgs.Empty);
					}
				}
			}
		}

		protected override void WndProc(ref Message m)
		{
			int msg = m.Msg;
			if (msg <= 15)
			{
				if (msg != 5)
				{
					if (msg == 15)
					{
						MdiClientController.PAINTSTRUCT pAINTSTRUCT = default(MdiClientController.PAINTSTRUCT);
						IntPtr hdc = MdiClientController.BeginPaint(m.HWnd, ref pAINTSTRUCT);
						using (Graphics graphics = Graphics.FromHdc(hdc))
						{
							Rectangle clipRect = new Rectangle(pAINTSTRUCT.rcPaint.left, pAINTSTRUCT.rcPaint.top, pAINTSTRUCT.rcPaint.right - pAINTSTRUCT.rcPaint.left, pAINTSTRUCT.rcPaint.bottom - pAINTSTRUCT.rcPaint.top);
							int width = (this.mdiClient.ClientRectangle.Width > 0) ? this.mdiClient.ClientRectangle.Width : 0;
							int height = (this.mdiClient.ClientRectangle.Height > 0) ? this.mdiClient.ClientRectangle.Height : 0;
							using (Image image = new Bitmap(width, height))
							{
								using (Graphics graphics2 = Graphics.FromImage(image))
								{
									IntPtr hdc2 = graphics2.GetHdc();
									Message message = Message.Create(m.HWnd, 792, hdc2, IntPtr.Zero);
									base.DefWndProc(ref message);
									graphics2.ReleaseHdc(hdc2);
									if (this.image != null)
									{
										this.DrawImage(graphics2, clipRect);
									}
									this.OnPaint(new PaintEventArgs(graphics2, clipRect));
								}
								graphics.DrawImage(image, this.mdiClient.ClientRectangle);
							}
						}
						MdiClientController.EndPaint(m.HWnd, ref pAINTSTRUCT);
						return;
					}
				}
				else
				{
					this.mdiClient.Invalidate();
				}
			}
			else
			{
				if (msg == 20)
				{
					return;
				}
				if (msg == 131)
				{
					if (!this.autoScroll)
					{
						MdiClientController.ShowScrollBar(m.HWnd, 3, 0);
					}
				}
			}
			base.WndProc(ref m);
		}

		protected virtual void OnPaint(PaintEventArgs e)
		{
			if (this.Paint != null)
			{
				this.Paint(this, e);
			}
		}

		protected virtual void OnHandleAssigned(EventArgs e)
		{
			if (this.HandleAssigned != null)
			{
				this.HandleAssigned(this, e);
			}
		}

		private void InitializeMdiClient()
		{
			if (this.mdiClient != null)
			{
				this.mdiClient.HandleDestroyed -= new EventHandler(this.MdiClientHandleDestroyed);
			}
			if (this.parentForm != null)
			{
				for (int i = 0; i < this.parentForm.Controls.Count; i++)
				{
					this.mdiClient = (this.parentForm.Controls[i] as MdiClient);
					if (this.mdiClient != null)
					{
						this.ReleaseHandle();
						base.AssignHandle(this.mdiClient.Handle);
						this.OnHandleAssigned(EventArgs.Empty);
						this.mdiClient.HandleDestroyed += new EventHandler(this.MdiClientHandleDestroyed);
					}
				}
			}
		}

		private void DrawImage(Graphics g, Rectangle clipRect)
		{
			if (this.stretchImage)
			{
				g.DrawImage(this.image, this.mdiClient.ClientRectangle);
			}
			else
			{
				Point empty = Point.Empty;
				ContentAlignment contentAlignment = this.imageAlign;
				if (contentAlignment <= ContentAlignment.MiddleCenter)
				{
					switch (contentAlignment)
					{
					case ContentAlignment.TopLeft:
						empty = new Point(0, 0);
						break;
					case ContentAlignment.TopCenter:
						empty = new Point(this.mdiClient.ClientRectangle.Width / 2 - this.image.Width / 2, 0);
						break;
					case (ContentAlignment)3:
						break;
					case ContentAlignment.TopRight:
						empty = new Point(this.mdiClient.ClientRectangle.Width - this.image.Width, 0);
						break;
					default:
						if (contentAlignment != ContentAlignment.MiddleLeft)
						{
							if (contentAlignment == ContentAlignment.MiddleCenter)
							{
								empty = new Point(this.mdiClient.ClientRectangle.Width / 2 - this.image.Width / 2, this.mdiClient.ClientRectangle.Height / 2 - this.image.Height / 2);
							}
						}
						else
						{
							empty = new Point(0, this.mdiClient.ClientRectangle.Height / 2 - this.image.Height / 2);
						}
						break;
					}
				}
				else if (contentAlignment <= ContentAlignment.BottomLeft)
				{
					if (contentAlignment != ContentAlignment.MiddleRight)
					{
						if (contentAlignment == ContentAlignment.BottomLeft)
						{
							empty = new Point(0, this.mdiClient.ClientRectangle.Height - this.image.Height);
						}
					}
					else
					{
						empty = new Point(this.mdiClient.ClientRectangle.Width - this.image.Width, this.mdiClient.ClientRectangle.Height / 2 - this.image.Height / 2);
					}
				}
				else if (contentAlignment != ContentAlignment.BottomCenter)
				{
					if (contentAlignment == ContentAlignment.BottomRight)
					{
						empty = new Point(this.mdiClient.ClientRectangle.Width - this.image.Width, this.mdiClient.ClientRectangle.Height - this.image.Height);
					}
				}
				else
				{
					empty = new Point(this.mdiClient.ClientRectangle.Width / 2 - this.image.Width / 2, this.mdiClient.ClientRectangle.Height - this.image.Height);
				}
				g.DrawImage(this.image, new Rectangle(empty, this.image.Size));
			}
		}

		private void UpdateStyles()
		{
			MdiClientController.SetWindowPos(this.mdiClient.Handle, IntPtr.Zero, 0, 0, 0, 0, 567u);
		}

		private void MdiClientHandleDestroyed(object sender, EventArgs e)
		{
			if (this.mdiClient != null)
			{
				this.mdiClient.HandleDestroyed -= new EventHandler(this.MdiClientHandleDestroyed);
				this.mdiClient = null;
			}
			this.ReleaseHandle();
		}

		private void ParentFormHandleCreated(object sender, EventArgs e)
		{
			this.parentForm.HandleCreated -= new EventHandler(this.ParentFormHandleCreated);
			this.InitializeMdiClient();
			this.RefreshProperties();
		}

		private void RefreshProperties()
		{
			this.BackColor = this.backColor;
			this.BorderStyle = this.borderStyle;
			this.AutoScroll = this.autoScroll;
			this.Image = this.image;
			this.ImageAlign = this.imageAlign;
			this.StretchImage = this.stretchImage;
		}

		[DllImport("user32.dll")]
		private static extern int ShowScrollBar(IntPtr hWnd, int wBar, int bShow);

		[DllImport("user32.dll")]
		private static extern IntPtr BeginPaint(IntPtr hWnd, ref MdiClientController.PAINTSTRUCT paintStruct);

		[DllImport("user32.dll")]
		private static extern bool EndPaint(IntPtr hWnd, ref MdiClientController.PAINTSTRUCT paintStruct);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int GetWindowLong(IntPtr hWnd, int Index);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int SetWindowLong(IntPtr hWnd, int Index, int Value);

		[DllImport("user32.dll", ExactSpelling = true)]
		private static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
	}
}
