using System;
using System.Runtime.InteropServices;

namespace TwainLib
{
	[StructLayout(LayoutKind.Sequential, Pack = 2)]
	internal struct TwEvent
	{
		public IntPtr EventPtr;

		public short Message;
	}
}
