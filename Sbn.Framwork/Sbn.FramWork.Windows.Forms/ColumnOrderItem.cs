using System;

namespace Sbn.FramWork.Windows.Forms
{
	[Serializable]
	public sealed class ColumnOrderItem
	{
		public string Name
		{
			get;
			set;
		}

		public int DisplayIndex
		{
			get;
			set;
		}

		public int Width
		{
			get;
			set;
		}

		public bool Visible
		{
			get;
			set;
		}

		public int ColumnIndex
		{
			get;
			set;
		}
	}
}
