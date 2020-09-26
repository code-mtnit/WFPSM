using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace Sbn.FramWork.Drawing.Core.Converters
{
	public class BitmapConverter
	{
		public static Bitmap BitmapFromBytes(byte[] bytes)
		{
			Bitmap result = null;
			if (bytes != null)
			{
				result = new Bitmap(new MemoryStream(bytes));
			}
			return result;
		}

		public static byte[] BytesFromBitmap(Bitmap bitmap)
		{
			byte[] result;
			try
			{
				TypeConverter converter = TypeDescriptor.GetConverter(bitmap.GetType());
				result = (byte[])converter.ConvertTo(bitmap, typeof(byte[]));
			}
			catch
			{
				throw new ApplicationException();
			}
			return result;
		}
	}
}
