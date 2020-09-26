using System;

namespace Sbn.FramWork.Drawing.Core.Utilities
{
	public static class Clipboard<State> where State : ICloneable
	{
		private static ICloneable _clip = null;

		public static State Clip
		{
			get
			{
				return (State)((object)Clipboard<State>._clip.Clone());
			}
			set
			{
				Clipboard<State>._clip = (State)((object)value.Clone());
			}
		}
	}
}
