using System;

namespace TwainLib
{
	public enum TwainCommand
	{
		Not = -1,
		Null,
		TransferReady,
		CloseRequest,
		CloseOk,
		DeviceEvent
	}
}
