using System;
using System.Runtime.InteropServices;

namespace TwainLib
{
	[StructLayout(LayoutKind.Sequential, Pack = 2)]
	internal class TwIdentity
	{
		public IntPtr Id;

		public TwVersion Version;

		public short ProtocolMajor;

		public short ProtocolMinor;

		public int SupportedGroups;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 34)]
		public string Manufacturer;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 34)]
		public string ProductFamily;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 34)]
		public string ProductName;
	}
}
