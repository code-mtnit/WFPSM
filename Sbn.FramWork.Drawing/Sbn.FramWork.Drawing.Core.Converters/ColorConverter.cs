using System;
using System.Drawing;

namespace Sbn.FramWork.Drawing.Core.Converters
{
	public class ColorConverter
	{
		public static Color ColorFromString(string argb, char separator)
		{
			string[] array = argb.Split(new char[]
			{
				separator
			});
			Color result = Color.White;
			try
			{
				result = Color.FromArgb(int.Parse(array[0]), int.Parse(array[1]), int.Parse(array[2]), int.Parse(array[3]));
			}
			catch
			{
				throw new ApplicationException();
			}
			return result;
		}

		public static string StringFromColor(Color color, char separator)
		{
			return string.Concat(new object[]
			{
				color.A.ToString(),
				separator,
				color.R.ToString(),
				separator,
				color.G.ToString(),
				separator,
				color.B.ToString()
			});
		}
	}
}
