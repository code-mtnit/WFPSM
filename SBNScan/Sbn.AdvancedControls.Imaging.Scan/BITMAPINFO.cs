using System;
using System.Drawing;

namespace Sbn.AdvancedControls.Imaging.Scan
{
	public class BITMAPINFO
	{
		public BITMAPINFOHEADER bmi;

		public Rectangle bmprect;

		public IntPtr dibhand;

		public IntPtr bmpptr;

		public IntPtr pixptr;
	}
}
