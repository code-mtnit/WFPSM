using System;

namespace TwainLib
{
	internal enum TwCC : short
	{
		Success,
		Bummer,
		LowMemory,
		NoDS,
		MaxConnections,
		OperationError,
		BadCap,
		BadProtocol = 9,
		BadValue,
		SeqError,
		BadDest,
		CapUnsupported,
		CapBadOperation,
		CapSeqError,
		Denied,
		FileExists,
		FileNotFound,
		NotEmpty,
		PaperJam,
		PaperDoubleFeed,
		FileWriteError,
		CheckDeviceOnline
	}
}
