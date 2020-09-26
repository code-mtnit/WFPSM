using System;

namespace TwainLib
{
	internal enum TwMSG : short
	{
		Null,
		Get,
		GetCurrent,
		GetDefault,
		GetFirst,
		GetNext,
		Set,
		Reset,
		QuerySupport,
		XFerReady = 257,
		CloseDSReq,
		CloseDSOK,
		DeviceEvent,
		CheckStatus = 513,
		OpenDSM = 769,
		CloseDSM,
		OpenDS = 1025,
		CloseDS,
		UserSelect,
		DisableDS = 1281,
		EnableDS,
		EnableDSUIOnly,
		ProcessEvent = 1537,
		EndXfer = 1793,
		StopFeeder,
		ChangeDirectory = 2049,
		CreateDirectory,
		Delete,
		FormatMedia,
		GetClose,
		GetFirstFile,
		GetInfo,
		GetNextFile,
		Rename,
		Copy,
		AutoCaptureDir,
		PassThru = 2305
	}
}
