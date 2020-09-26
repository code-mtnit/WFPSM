using System;
using System.Runtime.InteropServices;

namespace TwainLib
{
	[StructLayout(LayoutKind.Sequential, Pack = 2)]
	internal class TwPendingXfers
	{
		public short Count;

		public int EOJ;
	}
}
