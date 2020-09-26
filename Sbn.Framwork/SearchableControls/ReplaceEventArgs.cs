using System;

namespace SearchableControls
{
	public class ReplaceEventArgs : EventArgs
	{
		private string replaceText;

		public string ReplaceText
		{
			get
			{
				return this.replaceText;
			}
			set
			{
				this.replaceText = value;
			}
		}
	}
}
