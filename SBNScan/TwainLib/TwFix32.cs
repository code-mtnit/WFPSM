using System;
using System.Runtime.InteropServices;

namespace TwainLib
{
	[StructLayout(LayoutKind.Sequential, Pack = 2)]
	internal struct TwFix32
	{
		public short Whole;

		public ushort Frac;

		public float ToFloat()
		{
			return (float)this.Whole + (float)this.Frac / 65536f;
		}

		public void FromFloat(float f)
		{
			int num = (int)(f * 65536f + 0.5f);
			this.Whole = (short)(num >> 16);
			this.Frac = (ushort)(num & 65535);
		}
	}
}
