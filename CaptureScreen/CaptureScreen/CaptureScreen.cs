using System;
using System.Drawing;

namespace CaptureScreen
{
	public class CaptureScreen
	{
		public static Bitmap GetDesktopImage()
		{
			IntPtr dC = PlatformInvokeUSER32.GetDC(PlatformInvokeUSER32.GetDesktopWindow());
			IntPtr intPtr = PlatformInvokeGDI32.CreateCompatibleDC(dC);
			SIZE sIZE;
			sIZE.cx = PlatformInvokeUSER32.GetSystemMetrics(0);
			sIZE.cy = PlatformInvokeUSER32.GetSystemMetrics(1);
			IntPtr intPtr2 = PlatformInvokeGDI32.CreateCompatibleBitmap(dC, sIZE.cx, sIZE.cy);
			Bitmap result;
			if (intPtr2 != IntPtr.Zero)
			{
				IntPtr bmp = PlatformInvokeGDI32.SelectObject(intPtr, intPtr2);
				PlatformInvokeGDI32.BitBlt(intPtr, 0, 0, sIZE.cx, sIZE.cy, dC, 0, 0, 13369376);
				PlatformInvokeGDI32.SelectObject(intPtr, bmp);
				PlatformInvokeGDI32.DeleteDC(intPtr);
				PlatformInvokeUSER32.ReleaseDC(PlatformInvokeUSER32.GetDesktopWindow(), dC);
				Bitmap bitmap = Image.FromHbitmap(intPtr2);
				PlatformInvokeGDI32.DeleteObject(intPtr2);
				GC.Collect();
				result = bitmap;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
