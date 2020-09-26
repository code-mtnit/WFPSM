using System;

namespace TwainLib
{
	internal enum TwRC : short
	{
		Success,
		Failure,
		CheckStatus,
		Cancel,
		DSEvent,
		NotDSEvent,
		XferDone,
		EndOfList,
		InfoNotSupported,
		DataNotAvailable
	}
}
