using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Sbn.FramWork.Windows.Forms.OtherForms.AeroNonClientButtons
{
	public class Dwm
	{
		[StructLayout(LayoutKind.Explicit)]
		public struct RECT
		{
			[FieldOffset(12)]
			public int bottom;

			[FieldOffset(0)]
			public int left;

			[FieldOffset(8)]
			public int right;

			[FieldOffset(4)]
			public int top;

			public int Height
			{
				get
				{
					return this.bottom - this.top;
				}
			}

			public Size Size
			{
				get
				{
					return new Size(this.Width, this.Height);
				}
			}

			public int Width
			{
				get
				{
					return this.right - this.left;
				}
			}

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

			public void Set()
			{
				this.left = (this.top = (this.right = (this.bottom = 0)));
			}

			public void Set(Rectangle rect)
			{
				this.left = rect.Left;
				this.top = rect.Top;
				this.right = rect.Right;
				this.bottom = rect.Bottom;
			}

			public void Set(int left, int top, int right, int bottom)
			{
				this.left = left;
				this.top = top;
				this.right = right;
				this.bottom = bottom;
			}

			public Rectangle ToRectangle()
			{
				return new Rectangle(this.left, this.top, this.right - this.left, this.bottom - this.top);
			}
		}

		public struct SIZE
		{
			public int cx;

			public int cy;
		}

		public struct DWM_BLURBEHIND
		{
			public int dwFlags;

			public int fEnable;

			public IntPtr hRgnBlur;

			public int fTransitionOnMaximized;
		}

		public struct DWM_PRESENT_PARAMETERS
		{
			public int cbSize;

			public int fQueue;

			public long cRefreshStart;

			public int cBuffer;

			public int fUseSourceRate;

			public Dwm.UNSIGNED_RATIO rateSource;

			public int cRefreshesPerFrame;

			public Dwm.DWM_SOURCE_FRAME_SAMPLING eSampling;
		}

		public enum DWM_SOURCE_FRAME_SAMPLING
		{
			DWM_SOURCE_FRAME_SAMPLING_POINT,
			DWM_SOURCE_FRAME_SAMPLING_COVERAGE,
			DWM_SOURCE_FRAME_SAMPLING_LAST
		}

		public struct DWM_THUMBNAIL_PROPERTIES
		{
			public int dwFlags;

			public Dwm.RECT rcDestination;

			public Dwm.RECT rcSource;

			public byte opacity;

			public int fVisible;

			public int fSourceClientAreaOnly;
		}

		public struct DWM_TIMING_INFO
		{
			public int cbSize;

			public Dwm.UNSIGNED_RATIO rateRefresh;

			public Dwm.UNSIGNED_RATIO rateCompose;

			public long qpcVBlank;

			public long cRefresh;

			public long qpcCompose;

			public long cFrame;

			public long cRefreshFrame;

			public long cRefreshConfirmed;

			public int cFlipsOutstanding;

			public long cFrameCurrent;

			public long cFramesAvailable;

			public long cFrameCleared;

			public long cFramesReceived;

			public long cFramesDisplayed;

			public long cFramesDropped;

			public long cFramesMissed;
		}

		public enum DWMNCRENDERINGPOLICY
		{
			DWMNCRP_USEWINDOWSTYLE,
			DWMNCRP_DISABLED,
			DWMNCRP_ENABLED
		}

		public enum DWMWINDOWATTRIBUTE
		{
			DWMWA_ALLOW_NCPAINT = 4,
			DWMWA_CAPTION_BUTTON_BOUNDS,
			DWMWA_FLIP3D_POLICY = 8,
			DWMWA_FORCE_ICONIC_REPRESENTATION = 7,
			DWMWA_LAST = 9,
			DWMWA_NCRENDERING_ENABLED = 1,
			DWMWA_NCRENDERING_POLICY,
			DWMWA_NONCLIENT_RTL_LAYOUT = 6,
			DWMWA_TRANSITIONS_FORCEDISABLED = 3
		}

		public struct UNSIGNED_RATIO
		{
			public int uiNumerator;

			public int uiDenominator;
		}

		public struct MARGINS
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

		public struct WTA_OPTIONS
		{
			public uint Flags;

			public uint Mask;
		}

		public enum WindowThemeAttributeType
		{
			WTA_NONCLIENT = 1
		}

		public const int DWM_BB_BLURREGION = 2;

		public const int DWM_BB_ENABLE = 1;

		public const int DWM_BB_TRANSITIONONMAXIMIZED = 4;

		public const string DWM_COMPOSED_EVENT_BASE_NAME = "DwmComposedEvent_";

		public const string DWM_COMPOSED_EVENT_NAME_FORMAT = "%s%d";

		public const int DWM_COMPOSED_EVENT_NAME_MAX_LENGTH = 64;

		public const int DWM_FRAME_DURATION_DEFAULT = -1;

		public const int DWM_TNP_OPACITY = 4;

		public const int DWM_TNP_RECTDESTINATION = 1;

		public const int DWM_TNP_RECTSOURCE = 2;

		public const int DWM_TNP_SOURCECLIENTAREAONLY = 16;

		public const int DWM_TNP_VISIBLE = 8;

		public const int WM_DWMCOMPOSITIONCHANGED = 798;

		public static readonly bool DwmApiAvailable = Environment.OSVersion.Version.Major >= 6;

		public static uint WTNCA_NODRAWCAPTION = 1u;

		public static uint WTNCA_NODRAWICON = 2u;

		public static uint WTNCA_NOSYSMENU = 4u;

		public static uint WTNCA_NOMIRRORHELP = 8u;

		[DllImport("dwmapi.dll")]
		public static extern int DwmDefWindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, out IntPtr result);

		[DllImport("dwmapi.dll")]
		public static extern int DwmEnableComposition(int fEnable);

		[DllImport("dwmapi.dll")]
		public static extern int DwmEnableMMCSS(int fEnableMMCSS);

		[DllImport("dwmapi.dll")]
		public static extern int DwmExtendFrameIntoClientArea(IntPtr hdc, ref Dwm.MARGINS marInset);

		[DllImport("dwmapi.dll")]
		public static extern int DwmGetColorizationColor(ref int pcrColorization, ref int pfOpaqueBlend);

		[DllImport("dwmapi.dll")]
		public static extern int DwmGetCompositionTimingInfo(IntPtr hwnd, ref Dwm.DWM_TIMING_INFO pTimingInfo);

		[DllImport("dwmapi.dll")]
		public static extern int DwmGetWindowAttribute(IntPtr hwnd, int dwAttribute, IntPtr pvAttribute, int cbAttribute);

		[DllImport("dwmapi.dll")]
		public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

		[DllImport("dwmapi.dll")]
		public static extern int DwmModifyPreviousDxFrameDuration(IntPtr hwnd, int cRefreshes, int fRelative);

		[DllImport("dwmapi.dll")]
		public static extern int DwmQueryThumbnailSourceSize(IntPtr hThumbnail, ref Dwm.SIZE pSize);

		[DllImport("dwmapi.dll")]
		public static extern int DwmRegisterThumbnail(IntPtr hwndDestination, IntPtr hwndSource, ref Dwm.SIZE pMinimizedSize, ref IntPtr phThumbnailId);

		[DllImport("dwmapi.dll")]
		public static extern int DwmSetDxFrameDuration(IntPtr hwnd, int cRefreshes);

		[DllImport("dwmapi.dll")]
		public static extern int DwmSetPresentParameters(IntPtr hwnd, ref Dwm.DWM_PRESENT_PARAMETERS pPresentParams);

		[DllImport("dwmapi.dll")]
		public static extern int DwmSetWindowAttribute(IntPtr hwnd, int dwAttribute, IntPtr pvAttribute, int cbAttribute);

		[DllImport("dwmapi.dll")]
		public static extern int DwmUnregisterThumbnail(IntPtr hThumbnailId);

		[DllImport("dwmapi.dll")]
		public static extern int DwmUpdateThumbnailProperties(IntPtr hThumbnailId, ref Dwm.DWM_THUMBNAIL_PROPERTIES ptnProperties);

		[DllImport("UxTheme.dll")]
		public static extern int SetWindowThemeAttribute(IntPtr hWnd, Dwm.WindowThemeAttributeType wtype, ref Dwm.WTA_OPTIONS attributes, uint size);
	}
}
