using System;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GdiPlusLib
{
	public class Gdip
	{
		private static ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

		private static bool GetCodecClsid(string filename, out Guid clsid)
		{
			clsid = Guid.Empty;
			string text = Path.GetExtension(filename);
			bool result;
			if (text == null)
			{
				result = false;
			}
			else
			{
				text = "*" + text.ToUpper();
				ImageCodecInfo[] array = Gdip.codecs;
				for (int i = 0; i < array.Length; i++)
				{
					ImageCodecInfo imageCodecInfo = array[i];
					if (imageCodecInfo.FilenameExtension.IndexOf(text) >= 0)
					{
						clsid = imageCodecInfo.Clsid;
						result = true;
						return result;
					}
				}
				result = false;
			}
			return result;
		}

		public static bool SaveDIBAs(string picname, IntPtr bminfo, IntPtr pixdat)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = picname;
			saveFileDialog.Title = "Save bitmap as...";
			saveFileDialog.Filter = "Bitmap file (*.bmp)|*.bmp|TIFF file (*.tif)|*.tif|JPEG file (*.jpg)|*.jpg|PNG file (*.png)|*.png|GIF file (*.gif)|*.gif|All files (*.*)|*.*";
			saveFileDialog.FilterIndex = 1;
			bool result;
			Guid guid;
			if (saveFileDialog.ShowDialog() != DialogResult.OK)
			{
				result = false;
			}
			else if (!Gdip.GetCodecClsid(saveFileDialog.FileName, out guid))
			{
				MessageBox.Show("Unknown picture format for extension " + Path.GetExtension(saveFileDialog.FileName), "Image Codec", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				result = false;
			}
			else
			{
				IntPtr zero = IntPtr.Zero;
				if (Gdip.GdipCreateBitmapFromGdiDib(bminfo, pixdat, ref zero) != 0 || zero == IntPtr.Zero)
				{
					result = false;
				}
				else
				{
					int num = Gdip.GdipSaveImageToFile(zero, saveFileDialog.FileName, ref guid, IntPtr.Zero);
					Gdip.GdipDisposeImage(zero);
					result = (num == 0);
				}
			}
			return result;
		}

		[DllImport("gdiplus.dll", ExactSpelling = true)]
		internal static extern int GdipCreateBitmapFromGdiDib(IntPtr bminfo, IntPtr pixdat, ref IntPtr image);

		[DllImport("gdiplus.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern int GdipSaveImageToFile(IntPtr image, string filename, [In] ref Guid clsid, IntPtr encparams);

		[DllImport("gdiplus.dll", ExactSpelling = true)]
		internal static extern int GdipDisposeImage(IntPtr image);
	}
}
