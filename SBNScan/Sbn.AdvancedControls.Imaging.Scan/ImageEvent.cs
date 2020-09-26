using System;
using System.Drawing;

namespace Sbn.AdvancedControls.Imaging.Scan
{
	public class ImageEvent : EventArgs
	{
		private Image _CurrentImage;

		public Image CurrentImage
		{
			get
			{
				return this._CurrentImage;
			}
			set
			{
				this._CurrentImage = value;
			}
		}

		public ImageEvent(Image img)
		{
			this.CurrentImage = img;
		}

		public ImageEvent()
		{
		}
	}
}
