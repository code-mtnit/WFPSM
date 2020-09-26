using System;

namespace TwainLib
{
	[Flags]
	internal enum TwDG : short
	{
		Control = 1,
		Image = 2,
		Audio = 4
	}
}
