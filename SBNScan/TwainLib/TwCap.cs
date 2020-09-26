using System;

namespace TwainLib
{
	internal enum TwCap : short
	{
		XferCount = 1,
		ICompression = 256,
		IPixelType,
		IUnits,
		IXferMech,
		DUPLEXENABLED = 4115,
		RESOLUTION = 4376
	}
}
