using System;

namespace TwainLib
{
	internal enum TwDAT : short
	{
		Null,
		Capability,
		Event,
		Identity,
		Parent,
		PendingXfers,
		SetupMemXfer,
		SetupFileXfer,
		Status,
		UserInterface,
		XferGroup,
		TwunkIdentity,
		CustomDSData,
		DeviceEvent,
		FileSystem,
		PassThru,
		ImageInfo = 257,
		ImageLayout,
		ImageMemXfer,
		ImageNativeXfer,
		ImageFileXfer,
		CieColor,
		GrayResponse,
		RGBResponse,
		JpegCompression,
		Palette8,
		ExtImageInfo,
		SetupFileXfer2 = 769
	}
}
