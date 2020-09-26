using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms.OtherForms
{
	public class SBNFormController : NativeWindow
	{
		private enum HIT_CONSTANTS
		{
			HTERROR = -2,
			HTTRANSPARENT,
			HTNOWHERE,
			HTCLIENT,
			HTCAPTION,
			HTSYSMENU,
			HTGROWBOX,
			HTMENU,
			HTHSCROLL,
			HTVSCROLL,
			HTMINBUTTON,
			HTMAXBUTTON,
			HTLEFT,
			HTRIGHT,
			HTTOP,
			HTTOPLEFT,
			HTTOPRIGHT,
			HTBOTTOM,
			HTBOTTOMLEFT,
			HTBOTTOMRIGHT,
			HTBORDER,
			HTOBJECT,
			HTCLOSE,
			HTHELP
		}

		private enum PART_TYPE
		{
			WP_MINBUTTON = 15,
			WP_MAXBUTTON = 17,
			WP_CLOSEBUTTON,
			WP_RESTOREBUTTON = 21
		}

		private struct POINT
		{
			internal int X;

			internal int Y;
		}

		private struct SIZE
		{
			public int cx;

			public int cy;
		}

		public struct RECT
		{
			internal int Left;

			internal int Top;

			internal int Right;

			internal int Bottom;

			internal RECT(int X, int Y, int Width, int Height)
			{
				this.Left = X;
				this.Top = Y;
				this.Right = Width;
				this.Bottom = Height;
			}
		}

		private struct PAINTSTRUCT
		{
			internal IntPtr hdc;

			internal int fErase;

			internal SBNFormController.RECT rcPaint;

			internal int fRestore;

			internal int fIncUpdate;

			internal int Reserved1;

			internal int Reserved2;

			internal int Reserved3;

			internal int Reserved4;

			internal int Reserved5;

			internal int Reserved6;

			internal int Reserved7;

			internal int Reserved8;
		}

		private struct MARGINS
		{
			public int cxLeftWidth;

			public int cxRightWidth;

			public int cyTopHeight;

			public int cyBottomHeight;

			public MARGINS(int Left, int Right, int Top, int Bottom)
			{
				this.cxLeftWidth = Left;
				this.cxRightWidth = Right;
				this.cyTopHeight = Top;
				this.cyBottomHeight = Bottom;
			}
		}

		private struct NCCALCSIZE_PARAMS
		{
			internal SBNFormController.RECT rect0;

			internal SBNFormController.RECT rect1;

			internal SBNFormController.RECT rect2;

			internal IntPtr lppos;
		}

		internal class ClippingRegion : IDisposable
		{
			private enum CombineRgnStyles
			{
				RGN_AND = 1,
				RGN_OR,
				RGN_XOR,
				RGN_DIFF,
				RGN_COPY,
				RGN_MIN = 1,
				RGN_MAX = 5
			}

			private IntPtr _hClipRegion;

			private IntPtr _hDc;

			[DllImport("gdi32.dll")]
			private static extern int SelectClipRgn(IntPtr hdc, IntPtr hrgn);

			[DllImport("gdi32.dll")]
			private static extern int GetClipRgn(IntPtr hdc, [In] [Out] IntPtr hrgn);

			[DllImport("gdi32.dll")]
			private static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

			[DllImport("gdi32.dll")]
			private static extern IntPtr CreateEllipticRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

			[DllImport("gdi32.dll")]
			private static extern IntPtr CreateRoundRectRgn(int x1, int y1, int x2, int y2, int cx, int cy);

			[DllImport("gdi32.dll")]
			private static extern int CombineRgn(IntPtr hrgnDest, IntPtr hrgnSrc1, IntPtr hrgnSrc2, SBNFormController.ClippingRegion.CombineRgnStyles fnCombineMode);

			[DllImport("gdi32.dll")]
			private static extern int ExcludeClipRect(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

			[DllImport("gdi32.dll")]
			[return: MarshalAs(UnmanagedType.Bool)]
			private static extern bool DeleteObject(IntPtr hObject);

			public ClippingRegion(IntPtr hdc, Rectangle cliprect, Rectangle canvasrect)
			{
				this.CreateRectangleClip(hdc, cliprect, canvasrect);
			}

			public ClippingRegion(IntPtr hdc, SBNFormController.RECT cliprect, SBNFormController.RECT canvasrect)
			{
				this.CreateRectangleClip(hdc, cliprect, canvasrect);
			}

			public ClippingRegion(IntPtr hdc, Rectangle cliprect, Rectangle canvasrect, uint radius)
			{
				this.CreateRoundedRectangleClip(hdc, cliprect, canvasrect, radius);
			}

			public ClippingRegion(IntPtr hdc, SBNFormController.RECT cliprect, SBNFormController.RECT canvasrect, uint radius)
			{
				this.CreateRoundedRectangleClip(hdc, cliprect, canvasrect, radius);
			}

			public void CreateRectangleClip(IntPtr hdc, Rectangle cliprect, Rectangle canvasrect)
			{
				this._hDc = hdc;
				IntPtr intPtr = SBNFormController.ClippingRegion.CreateRectRgn(cliprect.Left, cliprect.Top, cliprect.Right, cliprect.Bottom);
				IntPtr intPtr2 = SBNFormController.ClippingRegion.CreateRectRgn(canvasrect.Left, canvasrect.Top, canvasrect.Right, canvasrect.Bottom);
				this._hClipRegion = SBNFormController.ClippingRegion.CreateRectRgn(canvasrect.Left, canvasrect.Top, canvasrect.Right, canvasrect.Bottom);
				SBNFormController.ClippingRegion.CombineRgn(this._hClipRegion, intPtr2, intPtr, SBNFormController.ClippingRegion.CombineRgnStyles.RGN_DIFF);
				SBNFormController.ClippingRegion.SelectClipRgn(this._hDc, this._hClipRegion);
				SBNFormController.ClippingRegion.DeleteObject(intPtr);
				SBNFormController.ClippingRegion.DeleteObject(intPtr2);
			}

			public void CreateRectangleClip(IntPtr hdc, SBNFormController.RECT cliprect, SBNFormController.RECT canvasrect)
			{
				this._hDc = hdc;
				IntPtr intPtr = SBNFormController.ClippingRegion.CreateRectRgn(cliprect.Left, cliprect.Top, cliprect.Right, cliprect.Bottom);
				IntPtr intPtr2 = SBNFormController.ClippingRegion.CreateRectRgn(canvasrect.Left, canvasrect.Top, canvasrect.Right, canvasrect.Bottom);
				this._hClipRegion = SBNFormController.ClippingRegion.CreateRectRgn(canvasrect.Left, canvasrect.Top, canvasrect.Right, canvasrect.Bottom);
				SBNFormController.ClippingRegion.CombineRgn(this._hClipRegion, intPtr2, intPtr, SBNFormController.ClippingRegion.CombineRgnStyles.RGN_DIFF);
				SBNFormController.ClippingRegion.SelectClipRgn(this._hDc, this._hClipRegion);
				SBNFormController.ClippingRegion.DeleteObject(intPtr);
				SBNFormController.ClippingRegion.DeleteObject(intPtr2);
			}

			public void CreateRoundedRectangleClip(IntPtr hdc, Rectangle cliprect, Rectangle canvasrect, uint radius)
			{
				this._hDc = hdc;
				IntPtr intPtr = SBNFormController.ClippingRegion.CreateRoundRectRgn(cliprect.Left, cliprect.Top, cliprect.Right, cliprect.Bottom, (int)radius, (int)radius);
				IntPtr intPtr2 = SBNFormController.ClippingRegion.CreateRectRgn(canvasrect.Left, canvasrect.Top, canvasrect.Right, canvasrect.Bottom);
				this._hClipRegion = SBNFormController.ClippingRegion.CreateRoundRectRgn(canvasrect.Left, canvasrect.Top, canvasrect.Right, canvasrect.Bottom, (int)radius, (int)radius);
				SBNFormController.ClippingRegion.CombineRgn(this._hClipRegion, intPtr2, intPtr, SBNFormController.ClippingRegion.CombineRgnStyles.RGN_DIFF);
				SBNFormController.ClippingRegion.SelectClipRgn(this._hDc, this._hClipRegion);
				SBNFormController.ClippingRegion.DeleteObject(intPtr);
				SBNFormController.ClippingRegion.DeleteObject(intPtr2);
			}

			public void CreateRoundedRectangleClip(IntPtr hdc, SBNFormController.RECT cliprect, SBNFormController.RECT canvasrect, uint radius)
			{
				this._hDc = hdc;
				IntPtr intPtr = SBNFormController.ClippingRegion.CreateRoundRectRgn(cliprect.Left, cliprect.Top, cliprect.Right, cliprect.Bottom, (int)radius, (int)radius);
				IntPtr intPtr2 = SBNFormController.ClippingRegion.CreateRectRgn(canvasrect.Left, canvasrect.Top, canvasrect.Right, canvasrect.Bottom);
				this._hClipRegion = SBNFormController.ClippingRegion.CreateRoundRectRgn(canvasrect.Left, canvasrect.Top, canvasrect.Right, canvasrect.Bottom, (int)radius, (int)radius);
				SBNFormController.ClippingRegion.CombineRgn(this._hClipRegion, intPtr2, intPtr, SBNFormController.ClippingRegion.CombineRgnStyles.RGN_DIFF);
				SBNFormController.ClippingRegion.SelectClipRgn(this._hDc, this._hClipRegion);
				SBNFormController.ClippingRegion.DeleteObject(intPtr);
				SBNFormController.ClippingRegion.DeleteObject(intPtr2);
			}

			public void Release()
			{
				if (this._hClipRegion != IntPtr.Zero)
				{
					SBNFormController.ClippingRegion.SelectClipRgn(this._hDc, IntPtr.Zero);
					SBNFormController.ClippingRegion.DeleteObject(this._hClipRegion);
				}
			}

			public void Dispose()
			{
				this.Release();
			}
		}

		private const int SWP_NOSIZE = 1;

		private const int SWP_NOMOVE = 2;

		private const int SWP_NOZORDER = 4;

		private const int SWP_NOREDRAW = 8;

		private const int SWP_NOACTIVATE = 16;

		private const int SWP_FRAMECHANGED = 32;

		private const int SWP_SHOWWINDOW = 64;

		private const int SWP_HIDEWINDOW = 128;

		private const int SWP_NOCOPYBITS = 256;

		private const int SWP_NOOWNERZORDER = 512;

		private const int SWP_NOSENDCHANGING = 1024;

		private const int RDW_INVALIDATE = 1;

		private const int RDW_INTERNALPAINT = 2;

		private const int RDW_ERASE = 4;

		private const int RDW_VALIDATE = 8;

		private const int RDW_NOINTERNALPAINT = 16;

		private const int RDW_NOERASE = 32;

		private const int RDW_NOCHILDREN = 64;

		private const int RDW_ALLCHILDREN = 128;

		private const int RDW_UPDATENOW = 256;

		private const int RDW_ERASENOW = 512;

		private const int RDW_FRAME = 1024;

		private const int RDW_NOFRAME = 2048;

		private const int FRAME_WIDTH = 8;

		private const int CAPTION_HEIGHT = 30;

		private const int FRAME_SMWIDTH = 4;

		private const int CAPTION_SMHEIGHT = 24;

		private const int WM_SYSCOMMAND = 274;

		private const int SC_RESTORE = 61728;

		private const int SC_MAXIMIZE = 61488;

		private const int SM_SWAPBUTTON = 23;

		private const int WM_GETTITLEBARINFOEX = 831;

		private const int VK_LBUTTON = 1;

		private const int VK_RBUTTON = 2;

		private const int KEY_PRESSED = 4096;

		private const int BLACK_BRUSH = 4;

		private const int WM_CREATE = 1;

		private const int WM_NCCALCSIZE = 131;

		private const int WM_NCHITTEST = 132;

		private const int WM_SIZE = 5;

		private const int WM_PAINT = 15;

		private const int WM_TIMER = 275;

		private const int WM_ACTIVATE = 6;

		private const int WM_NCMOUSEMOVE = 160;

		private const int WM_NCMOUSEHOVER = 672;

		private const int WM_NCLBUTTONDOWN = 161;

		private const int WM_NCLBUTTONUP = 162;

		private const int WM_NCLBUTTONDBLCLK = 163;

		private const int WM_NCRBUTTONDOWN = 164;

		private const int WM_NCRBUTTONUP = 165;

		private const int WM_NCRBUTTONDBLCLK = 166;

		private const int WM_DWMCOMPOSITIONCHANGED = 798;

		private const int WVR_ALIGNTOP = 16;

		private const int WVR_ALIGNLEFT = 32;

		private const int WVR_ALIGNBOTTOM = 64;

		private const int WVR_ALIGNRIGHT = 128;

		private const int WVR_HREDRAW = 256;

		private const int WVR_VREDRAW = 512;

		private const int WVR_REDRAW = 768;

		private const int WVR_VALIDRECTS = 1024;

		private Form _currentForm;

		private static IntPtr MSG_HANDLED = new IntPtr(0);

		private bool _bPaintWindow = false;

		private bool _bDrawCaption = false;

		private bool _bIsCompatible = false;

		private bool _bIsAero = false;

		private bool _bPainting = false;

		private bool _bExtendIntoFrame = false;

		private int _iCaptionHeight = 30;

		private int _iFrameHeight = 8;

		private int _iFrameWidth = 8;

		private int _iFrameOffset = 100;

		private int _iStoreHeight = 0;

		private SBNFormController.RECT _tClientRect = default(SBNFormController.RECT);

		private SBNFormController.MARGINS _tMargins = default(SBNFormController.MARGINS);

		private SBNFormController.RECT[] _tButtonSize = new SBNFormController.RECT[3];

		private MdiClient mdiClient;

		[Browsable(false)]
		public event EventHandler HandleAssigned;

		public Form CurrentForm
		{
			get
			{
				return this._currentForm;
			}
			set
			{
				if (this._currentForm != null)
				{
					this._currentForm.HandleCreated -= new EventHandler(this.ParentFormHandleCreated);
				}
				this._currentForm = value;
				if (this._currentForm != null)
				{
					if (this._currentForm.IsHandleCreated)
					{
						this.InitializeMdiClient();
					}
					else
					{
						this._currentForm.HandleCreated += new EventHandler(this.ParentFormHandleCreated);
					}
				}
			}
		}

		private int CaptionHeight
		{
			get
			{
				return this._iCaptionHeight;
			}
		}

		private int FrameWidth
		{
			get
			{
				return this._iFrameWidth;
			}
		}

		private int FrameHeight
		{
			get
			{
				return this._iFrameHeight;
			}
		}

		public SBNFormController(Form currentForm)
		{
			this.CurrentForm = currentForm;
		}

		[DllImport("dwmapi.dll")]
		private static extern int DwmExtendFrameIntoClientArea(IntPtr hdc, ref SBNFormController.MARGINS marInset);

		[DllImport("dwmapi.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool DwmDefWindowProc(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam, ref IntPtr result);

		[DllImport("dwmapi.dll")]
		private static extern int DwmIsCompositionEnabled(ref int pfEnabled);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndAfter, int x, int y, int cx, int cy, uint flags);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool GetCursorPos(ref Point lpPoint);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool PtInRect([In] ref SBNFormController.RECT lprc, Point pt);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool GetWindowRect(IntPtr hWnd, ref SBNFormController.RECT lpRect);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool GetClientRect(IntPtr hWnd, ref SBNFormController.RECT r);

		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateSolidBrush(int crColor);

		[DllImport("gdi32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool DeleteObject(IntPtr hObject);

		[DllImport("user32.dll")]
		private static extern int FillRect(IntPtr hDC, [In] ref SBNFormController.RECT lprc, IntPtr hbr);

		[DllImport("gdi32.dll")]
		private static extern IntPtr GetStockObject(int fnObject);

		[DllImport("user32.dll")]
		private static extern IntPtr BeginPaint(IntPtr hWnd, ref SBNFormController.PAINTSTRUCT ps);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool EndPaint(IntPtr hWnd, ref SBNFormController.PAINTSTRUCT ps);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool InflateRect(ref SBNFormController.RECT lprc, int dx, int dy);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool OffsetRect(ref SBNFormController.RECT lprc, int dx, int dy);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, uint flags);

		public void ExtendMargins(int left, int top, int right, int bottom, bool drawcaption, bool intoframe)
		{
			if (left < 0 || top < 0 || right < 0 || bottom < 0)
			{
				this._bPaintWindow = true;
				this._tMargins.cyTopHeight = -1;
			}
			else if (intoframe)
			{
				this._tMargins.cxLeftWidth = 0;
				this._tMargins.cyTopHeight = top;
				this._tMargins.cxRightWidth = 0;
				this._tMargins.cyBottomHeight = 0;
			}
			else
			{
				this._tMargins.cxLeftWidth = left;
				this._tMargins.cyTopHeight = top;
				this._tMargins.cxRightWidth = right;
				this._tMargins.cyBottomHeight = bottom;
			}
			this._bExtendIntoFrame = intoframe;
			this._bDrawCaption = drawcaption;
			this._bIsCompatible = this.IsCompatableOS();
			this._bIsAero = this.IsAero();
		}

		private void ParentFormHandleCreated(object sender, EventArgs e)
		{
			this.CurrentForm.HandleCreated -= new EventHandler(this.ParentFormHandleCreated);
			this.InitializeMdiClient();
		}

		private void InitializeMdiClient()
		{
			if (this.mdiClient != null)
			{
				this.mdiClient.HandleDestroyed -= new EventHandler(this.MdiClientHandleDestroyed);
			}
			if (this._currentForm != null)
			{
				this.ReleaseHandle();
				base.AssignHandle(this._currentForm.Handle);
			}
		}

		protected virtual void OnHandleAssigned(EventArgs e)
		{
			if (this.HandleAssigned != null)
			{
				this.HandleAssigned(this, e);
			}
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

		private void GetFrameSize()
		{
			if (this.CurrentForm.MinimizeBox)
			{
				this._iFrameOffset = 100;
			}
			else
			{
				this._iFrameOffset = 40;
			}
			switch (this.CurrentForm.FormBorderStyle)
			{
			case FormBorderStyle.FixedSingle:
				this._iCaptionHeight = 25;
				this._iFrameHeight = 2;
				this._iFrameWidth = 2;
				break;
			case FormBorderStyle.Fixed3D:
				this._iCaptionHeight = 27;
				this._iFrameHeight = 4;
				this._iFrameWidth = 4;
				break;
			case FormBorderStyle.FixedDialog:
				this._iCaptionHeight = 25;
				this._iFrameHeight = 2;
				this._iFrameWidth = 2;
				break;
			case FormBorderStyle.Sizable:
				this._iCaptionHeight = 30;
				this._iFrameHeight = 8;
				this._iFrameWidth = 8;
				break;
			case FormBorderStyle.FixedToolWindow:
				this._iFrameOffset = 20;
				this._iCaptionHeight = 21;
				this._iFrameHeight = 2;
				this._iFrameWidth = 2;
				break;
			case FormBorderStyle.SizableToolWindow:
				this._iFrameOffset = 20;
				this._iCaptionHeight = 26;
				this._iFrameHeight = 4;
				this._iFrameWidth = 4;
				break;
			default:
				this._iCaptionHeight = 30;
				this._iFrameHeight = 8;
				this._iFrameWidth = 8;
				break;
			}
		}

		private SBNFormController.HIT_CONSTANTS HitTest()
		{
			SBNFormController.RECT rECT = default(SBNFormController.RECT);
			Point pt = default(Point);
			SBNFormController.GetCursorPos(ref pt);
			SBNFormController.GetWindowRect(this.CurrentForm.Handle, ref rECT);
			pt.X -= rECT.Left;
			pt.Y -= rECT.Top;
			int num = rECT.Right - rECT.Left;
			int num2 = rECT.Bottom - rECT.Top;
			SBNFormController.RECT rECT2 = new SBNFormController.RECT(0, 0, this.FrameWidth, this.FrameHeight);
			SBNFormController.HIT_CONSTANTS result;
			if (SBNFormController.PtInRect(ref rECT2, pt))
			{
				result = SBNFormController.HIT_CONSTANTS.HTTOPLEFT;
			}
			else
			{
				rECT2 = new SBNFormController.RECT(num - this.FrameWidth, 0, num, this.FrameHeight);
				if (SBNFormController.PtInRect(ref rECT2, pt))
				{
					result = SBNFormController.HIT_CONSTANTS.HTTOPRIGHT;
				}
				else
				{
					rECT2 = new SBNFormController.RECT(this.FrameWidth, 0, num - this.FrameWidth * 2 - this._iFrameOffset, this.FrameHeight);
					if (SBNFormController.PtInRect(ref rECT2, pt))
					{
						result = SBNFormController.HIT_CONSTANTS.HTTOP;
					}
					else
					{
						rECT2 = new SBNFormController.RECT(this.FrameWidth, this.FrameHeight, num - (this.FrameWidth * 2 + this._iFrameOffset), this._tMargins.cyTopHeight);
						if (SBNFormController.PtInRect(ref rECT2, pt))
						{
							result = SBNFormController.HIT_CONSTANTS.HTCAPTION;
						}
						else
						{
							rECT2 = new SBNFormController.RECT(0, this.FrameHeight, this.FrameWidth, num2 - this.FrameHeight);
							if (SBNFormController.PtInRect(ref rECT2, pt))
							{
								result = SBNFormController.HIT_CONSTANTS.HTLEFT;
							}
							else
							{
								rECT2 = new SBNFormController.RECT(0, num2 - this.FrameHeight, this.FrameWidth, num2);
								if (SBNFormController.PtInRect(ref rECT2, pt))
								{
									result = SBNFormController.HIT_CONSTANTS.HTBOTTOMLEFT;
								}
								else
								{
									rECT2 = new SBNFormController.RECT(this.FrameWidth, num2 - this.FrameHeight, num - this.FrameWidth, num2);
									if (SBNFormController.PtInRect(ref rECT2, pt))
									{
										result = SBNFormController.HIT_CONSTANTS.HTBOTTOM;
									}
									else
									{
										rECT2 = new SBNFormController.RECT(num - this.FrameWidth, num2 - this.FrameHeight, num, num2);
										if (SBNFormController.PtInRect(ref rECT2, pt))
										{
											result = SBNFormController.HIT_CONSTANTS.HTBOTTOMRIGHT;
										}
										else
										{
											rECT2 = new SBNFormController.RECT(num - this.FrameWidth, this.FrameHeight, num, num2 - this.FrameHeight);
											if (SBNFormController.PtInRect(ref rECT2, pt))
											{
												result = SBNFormController.HIT_CONSTANTS.HTRIGHT;
											}
											else
											{
												result = SBNFormController.HIT_CONSTANTS.HTCLIENT;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		public bool IsAero()
		{
			int num = 0;
			SBNFormController.DwmIsCompositionEnabled(ref num);
			return num == 1;
		}

		public bool IsCompatableOS()
		{
			return Environment.OSVersion.Version.Major >= 6;
		}

		private void FrameChanged()
		{
			SBNFormController.RECT rECT = default(SBNFormController.RECT);
			SBNFormController.GetWindowRect(this.CurrentForm.Handle, ref rECT);
			SBNFormController.SetWindowPos(this.CurrentForm.Handle, IntPtr.Zero, rECT.Left, rECT.Top, rECT.Right - rECT.Left, rECT.Bottom - rECT.Top, 32u);
		}

		private void InvalidateWindow()
		{
			SBNFormController.RedrawWindow(this.CurrentForm.Handle, IntPtr.Zero, IntPtr.Zero, 1285u);
		}

		private void PaintThis(IntPtr hdc, SBNFormController.RECT rc)
		{
			SBNFormController.RECT cliprect = default(SBNFormController.RECT);
			SBNFormController.GetClientRect(this.CurrentForm.Handle, ref cliprect);
			if (this._bExtendIntoFrame)
			{
				cliprect.Left = this._tClientRect.Left - this._tMargins.cxLeftWidth;
				cliprect.Top = this._tMargins.cyTopHeight;
				cliprect.Right -= this._tMargins.cxRightWidth;
				cliprect.Bottom -= this._tMargins.cyBottomHeight;
			}
			else if (!this._bPaintWindow)
			{
				cliprect.Left = this._tMargins.cxLeftWidth;
				cliprect.Top = this._tMargins.cyTopHeight;
				cliprect.Right -= this._tMargins.cxRightWidth;
				cliprect.Bottom -= this._tMargins.cyBottomHeight;
			}
			if (!this._bPaintWindow)
			{
				int crColor;
				IntPtr intPtr;
				using (new SBNFormController.ClippingRegion(hdc, cliprect, rc))
				{
					if (this.IsAero())
					{
						SBNFormController.FillRect(hdc, ref rc, SBNFormController.GetStockObject(4));
					}
					else
					{
						crColor = ColorTranslator.ToWin32(Color.FromArgb(194, 217, 247));
						intPtr = SBNFormController.CreateSolidBrush(crColor);
						SBNFormController.FillRect(hdc, ref cliprect, intPtr);
						SBNFormController.DeleteObject(intPtr);
					}
				}
				crColor = ColorTranslator.ToWin32(this.CurrentForm.BackColor);
				intPtr = SBNFormController.CreateSolidBrush(crColor);
				SBNFormController.FillRect(hdc, ref cliprect, intPtr);
				SBNFormController.DeleteObject(intPtr);
			}
			else
			{
				SBNFormController.FillRect(hdc, ref rc, SBNFormController.GetStockObject(4));
			}
			if (this._bExtendIntoFrame && this._bDrawCaption)
			{
				Rectangle layoutRect = new Rectangle(4, 4, rc.Right, this.CaptionHeight);
				using (Graphics graphics = Graphics.FromHdc(hdc))
				{
					using (Font font = new Font("Segoe UI", 12f, FontStyle.Regular))
					{
						SizeF sizeF = graphics.MeasureString(this.CurrentForm.Text, font);
						int num = (rc.Right - (int)sizeF.Width) / 2;
						if (num < 2 * this.FrameWidth)
						{
							num = 2 * this.FrameWidth;
						}
						layoutRect.X = num;
						layoutRect.Y = 4;
						using (StringFormat stringFormat = new StringFormat())
						{
							stringFormat.HotkeyPrefix = HotkeyPrefix.None;
							stringFormat.FormatFlags = StringFormatFlags.NoWrap;
							stringFormat.Alignment = StringAlignment.Near;
							stringFormat.LineAlignment = StringAlignment.Near;
							using (GraphicsPath graphicsPath = new GraphicsPath())
							{
								graphics.SmoothingMode = SmoothingMode.HighQuality;
								graphicsPath.AddString(this.CurrentForm.Text, font.FontFamily, (int)font.Style, font.Size, layoutRect, stringFormat);
								graphics.FillPath(Brushes.Black, graphicsPath);
							}
						}
					}
				}
			}
		}

		protected override void WndProc(ref Message m)
		{
			if (this._bIsCompatible)
			{
				this.CustomProc(ref m);
			}
			else
			{
				base.WndProc(ref m);
			}
		}

		protected void CustomProc(ref Message m)
		{
			int msg = m.Msg;
			if (msg <= 15)
			{
				if (msg == 1)
				{
					this.GetFrameSize();
					this.FrameChanged();
					m.Result = SBNFormController.MSG_HANDLED;
					base.WndProc(ref m);
					return;
				}
				if (msg != 6)
				{
					if (msg != 15)
					{
						goto IL_316;
					}
					SBNFormController.PAINTSTRUCT pAINTSTRUCT = default(SBNFormController.PAINTSTRUCT);
					if (!this._bPainting)
					{
						this._bPainting = true;
						SBNFormController.BeginPaint(m.HWnd, ref pAINTSTRUCT);
						this.PaintThis(pAINTSTRUCT.hdc, pAINTSTRUCT.rcPaint);
						SBNFormController.EndPaint(m.HWnd, ref pAINTSTRUCT);
						this._bPainting = false;
						base.WndProc(ref m);
					}
					else
					{
						base.WndProc(ref m);
					}
					return;
				}
			}
			else
			{
				switch (msg)
				{
				case 131:
					if (m.WParam != IntPtr.Zero && m.Result == IntPtr.Zero)
					{
						if (this._bExtendIntoFrame)
						{
							SBNFormController.NCCALCSIZE_PARAMS nCCALCSIZE_PARAMS = (SBNFormController.NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(SBNFormController.NCCALCSIZE_PARAMS));
							nCCALCSIZE_PARAMS.rect0.Top = nCCALCSIZE_PARAMS.rect0.Top - ((this._tMargins.cyTopHeight > this.CaptionHeight) ? this.CaptionHeight : this._tMargins.cyTopHeight);
							nCCALCSIZE_PARAMS.rect1 = nCCALCSIZE_PARAMS.rect0;
							Marshal.StructureToPtr(nCCALCSIZE_PARAMS, m.LParam, false);
							m.Result = (IntPtr)1024;
						}
						base.WndProc(ref m);
					}
					else
					{
						base.WndProc(ref m);
					}
					return;
				case 132:
					if (m.Result == (IntPtr)0L)
					{
						IntPtr zero = IntPtr.Zero;
						if (SBNFormController.DwmDefWindowProc(m.HWnd, (uint)m.Msg, m.WParam, m.LParam, ref zero))
						{
							m.Result = zero;
						}
						else
						{
							m.Result = (IntPtr)((long)this.HitTest());
						}
					}
					else
					{
						base.WndProc(ref m);
					}
					return;
				default:
					if (msg == 274)
					{
						uint num;
						if (IntPtr.Size == 4)
						{
							num = (uint)m.WParam.ToInt32();
						}
						else
						{
							num = (uint)m.WParam.ToInt64();
						}
						if ((num & 65520u) == 61728u)
						{
							this.CurrentForm.Height = this._iStoreHeight;
						}
						else if (this.CurrentForm.WindowState == FormWindowState.Normal)
						{
							this._iStoreHeight = this.CurrentForm.Height;
						}
						base.WndProc(ref m);
						return;
					}
					if (msg != 798)
					{
						goto IL_316;
					}
					break;
				}
			}
			SBNFormController.DwmExtendFrameIntoClientArea(this.CurrentForm.Handle, ref this._tMargins);
			m.Result = SBNFormController.MSG_HANDLED;
			base.WndProc(ref m);
			return;
			IL_316:
			base.WndProc(ref m);
		}
	}
}
