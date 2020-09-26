using System;
using System.Runtime.InteropServices;

namespace TwainLib
{
	[StructLayout(LayoutKind.Sequential, Pack = 2)]
	internal class TwCapability
	{
		public short Cap;

		public short ConType;

		public IntPtr Handle;

		public TwCapability(TwCap cap)
		{
			this.Cap = (short)cap;
			this.ConType = -1;
		}

		public TwCapability(TwCap cap, short sval, TwType twType)
		{
			this.Cap = (short)cap;
			this.ConType = 5;
			this.Handle = Twain.GlobalAlloc(66, 6);
			IntPtr ptr = Twain.GlobalLock(this.Handle);
			Marshal.WriteInt16(ptr, 0, (short)twType);
			Marshal.WriteInt32(ptr, 2, (int)sval);
			Twain.GlobalUnlock(this.Handle);
		}

		~TwCapability()
		{
			if (this.Handle != IntPtr.Zero)
			{
				Twain.GlobalFree(this.Handle);
			}
		}
	}
}
