using Sbn.AdvancedControls.Imaging.Scan;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TwainLib
{
	public class Twain
	{
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		internal struct WINMSG
		{
			public IntPtr hwnd;

			public int message;

			public IntPtr wParam;

			public IntPtr lParam;

			public int time;

			public int x;

			public int y;
		}

		private const short CountryUSA = 1;

		private const short LanguageUSA = 13;

		private IntPtr hwnd;

		private TwIdentity appid;

		private TwIdentity srcds;

		private TwEvent evtmsg;

		private Twain.WINMSG winmsg;

		public event EventHandler<ImageEvent> ScanedImage;

		public static int ScreenBitDepth
		{
			get
			{
				IntPtr intPtr = Twain.CreateDC("DISPLAY", null, null, IntPtr.Zero);
				int num = Twain.GetDeviceCaps(intPtr, 12);
				num *= Twain.GetDeviceCaps(intPtr, 14);
				Twain.DeleteDC(intPtr);
				return num;
			}
		}

		public Twain()
		{
			this.appid = new TwIdentity();
			this.appid.Id = IntPtr.Zero;
			this.appid.Version.MajorNum = 1;
			this.appid.Version.MinorNum = 1;
			this.appid.Version.Language = 13;
			this.appid.Version.Country = 1;
			this.appid.Version.Info = "Hatef Imaging 1.1";
			this.appid.ProtocolMajor = 1;
			this.appid.ProtocolMinor = 9;
			this.appid.SupportedGroups = 3;
			this.appid.Manufacturer = "Hatef";
			this.appid.ProductFamily = "CopyRight ...";
			this.appid.ProductName = "Hatefnetworking Imaging";
			this.srcds = new TwIdentity();
			this.srcds.Id = IntPtr.Zero;
			this.evtmsg.EventPtr = Marshal.AllocHGlobal(Marshal.SizeOf(this.winmsg));
		}

		~Twain()
		{
			Marshal.FreeHGlobal(this.evtmsg.EventPtr);
		}

		public void Init(IntPtr hwndp)
		{
			this.Finish();
			TwRC twRC = Twain.DSMparent(this.appid, IntPtr.Zero, TwDG.Control, TwDAT.Parent, TwMSG.OpenDSM, ref hwndp);
			if (twRC == TwRC.Success)
			{
				twRC = Twain.DSMident(this.appid, IntPtr.Zero, TwDG.Control, TwDAT.Identity, TwMSG.UserSelect, this.srcds);
				if (twRC == TwRC.Success)
				{
					this.hwnd = hwndp;
				}
				else
				{
					twRC = Twain.DSMparent(this.appid, IntPtr.Zero, TwDG.Control, TwDAT.Parent, TwMSG.CloseDSM, ref hwndp);
				}
			}
			TwIdentity twIdentity = this.srcds;
		}

		public void Select()
		{
			this.CloseSrc();
			if (this.appid.Id == IntPtr.Zero)
			{
				this.Init(this.hwnd);
				if (this.appid.Id == IntPtr.Zero)
				{
					return;
				}
			}
			TwRC twRC = Twain.DSMident(this.appid, IntPtr.Zero, TwDG.Control, TwDAT.Identity, TwMSG.UserSelect, this.srcds);
		}

		public void Acquire2()
		{
			this.CloseSrc();
			if (this.appid.Id == IntPtr.Zero)
			{
				this.Init(this.hwnd);
				if (this.appid.Id == IntPtr.Zero)
				{
					return;
				}
			}
			TwRC twRC = Twain.DSMident(this.appid, IntPtr.Zero, TwDG.Control, TwDAT.Identity, TwMSG.OpenDS, this.srcds);
			if (twRC == TwRC.Success)
			{
				TwCapability capa = new TwCapability(TwCap.XferCount, 1, TwType.Int16);
				twRC = Twain.DScap(this.appid, this.srcds, TwDG.Control, TwDAT.Capability, TwMSG.Set, capa);
				if (twRC != TwRC.Success)
				{
					this.CloseSrc();
				}
			}
		}

		public void Acquire()
		{
			this.CloseSrc();
			if (this.appid.Id == IntPtr.Zero)
			{
				this.Init(this.hwnd);
				if (this.appid.Id == IntPtr.Zero)
				{
					return;
				}
			}
			TwRC twRC = Twain.DSMident(this.appid, IntPtr.Zero, TwDG.Control, TwDAT.Identity, TwMSG.OpenDS, this.srcds);
			if (twRC == TwRC.Success)
			{
				TwCapability capa = new TwCapability(TwCap.IPixelType, 0, TwType.UInt16);
				twRC = Twain.DScap(this.appid, this.srcds, TwDG.Control, TwDAT.Capability, TwMSG.Set, capa);
				if (twRC != TwRC.Success)
				{
					this.CloseSrc();
				}
				else
				{
					TwCapability capa2 = new TwCapability(TwCap.RESOLUTION, 200, TwType.Fix32);
					twRC = Twain.DScap(this.appid, this.srcds, TwDG.Control, TwDAT.Capability, TwMSG.Set, capa2);
					if (twRC != TwRC.Success)
					{
						this.CloseSrc();
					}
					else
					{
						TwCapability capa3 = new TwCapability(TwCap.XferCount, 1, TwType.Int16);
						twRC = Twain.DScap(this.appid, this.srcds, TwDG.Control, TwDAT.Capability, TwMSG.Set, capa3);
						if (twRC != TwRC.Success)
						{
							this.CloseSrc();
						}
						else
						{
							TwUserInterface twUserInterface = new TwUserInterface();
							twUserInterface.ShowUI = 1;
							twUserInterface.ModalUI = 1;
							twUserInterface.ParentHand = this.hwnd;
							twRC = Twain.DSuserif(this.appid, this.srcds, TwDG.Control, TwDAT.UserInterface, TwMSG.EnableDS, twUserInterface);
							if (twRC != TwRC.Success)
							{
								this.CloseSrc();
							}
						}
					}
				}
			}
		}

		public ArrayList TransferPictures()
		{
			ArrayList arrayList = new ArrayList();
			ArrayList result;
			if (this.srcds.Id == IntPtr.Zero)
			{
				result = arrayList;
			}
			else
			{
				IntPtr zero = IntPtr.Zero;
				TwPendingXfers twPendingXfers = new TwPendingXfers();
				TwRC twRC;
				while (true)
				{
					twPendingXfers.Count = 0;
					zero = IntPtr.Zero;
					TwImageInfo imginf = new TwImageInfo();
					twRC = Twain.DSiinf(this.appid, this.srcds, TwDG.Image, TwDAT.ImageInfo, TwMSG.Get, imginf);
					if (twRC != TwRC.Success)
					{
						break;
					}
					twRC = Twain.DSixfer(this.appid, this.srcds, TwDG.Image, TwDAT.ImageNativeXfer, TwMSG.Get, ref zero);
					if (twRC != TwRC.XferDone)
					{
						goto Block_3;
					}
					twRC = Twain.DSpxfer(this.appid, this.srcds, TwDG.Control, TwDAT.PendingXfers, TwMSG.EndXfer, twPendingXfers);
					if (twRC != TwRC.Success)
					{
						goto Block_4;
					}
					arrayList.Add(zero);
					if (this.ScanedImage != null)
					{
						this.ScanedImage(zero, new ImageEvent());
					}
					if (twPendingXfers.Count == 0)
					{
						goto Block_6;
					}
				}
				result = arrayList;
				return result;
				Block_3:
				result = arrayList;
				return result;
				Block_4:
				result = arrayList;
				return result;
				Block_6:
				twRC = Twain.DSpxfer(this.appid, this.srcds, TwDG.Control, TwDAT.PendingXfers, TwMSG.Reset, twPendingXfers);
				result = arrayList;
			}
			return result;
		}

		public TwainCommand PassMessage(ref Message m)
		{
			TwainCommand result;
			if (this.srcds.Id == IntPtr.Zero)
			{
				result = TwainCommand.Not;
			}
			else
			{
				int messagePos = Twain.GetMessagePos();
				this.winmsg.hwnd = m.HWnd;
				this.winmsg.message = m.Msg;
				this.winmsg.wParam = m.WParam;
				this.winmsg.lParam = m.LParam;
				this.winmsg.time = Twain.GetMessageTime();
				this.winmsg.x = (int)((short)messagePos);
				this.winmsg.y = (int)((short)(messagePos >> 16));
				Marshal.StructureToPtr(this.winmsg, this.evtmsg.EventPtr, false);
				this.evtmsg.Message = 0;
				TwRC twRC = Twain.DSevent(this.appid, this.srcds, TwDG.Control, TwDAT.Event, TwMSG.ProcessEvent, ref this.evtmsg);
				if (twRC == TwRC.NotDSEvent)
				{
					result = TwainCommand.Not;
				}
				else if (this.evtmsg.Message == 257)
				{
					result = TwainCommand.TransferReady;
				}
				else if (this.evtmsg.Message == 258)
				{
					result = TwainCommand.CloseRequest;
				}
				else if (this.evtmsg.Message == 259)
				{
					result = TwainCommand.CloseOk;
				}
				else if (this.evtmsg.Message == 260)
				{
					result = TwainCommand.DeviceEvent;
				}
				else
				{
					result = TwainCommand.Null;
				}
			}
			return result;
		}

		public void CloseSrc()
		{
			if (this.srcds.Id != IntPtr.Zero)
			{
				TwUserInterface guif = new TwUserInterface();
				TwRC twRC = Twain.DSuserif(this.appid, this.srcds, TwDG.Control, TwDAT.UserInterface, TwMSG.DisableDS, guif);
				twRC = Twain.DSMident(this.appid, IntPtr.Zero, TwDG.Control, TwDAT.Identity, TwMSG.CloseDS, this.srcds);
			}
		}

		public void Finish()
		{
			this.CloseSrc();
			if (this.appid.Id != IntPtr.Zero)
			{
				TwRC twRC = Twain.DSMparent(this.appid, IntPtr.Zero, TwDG.Control, TwDAT.Parent, TwMSG.CloseDSM, ref this.hwnd);
			}
			this.appid.Id = IntPtr.Zero;
		}

		[DllImport("twain_32.dll", EntryPoint = "#1")]
		private static extern TwRC DSMparent([In] [Out] TwIdentity origin, IntPtr zeroptr, TwDG dg, TwDAT dat, TwMSG msg, ref IntPtr refptr);

		[DllImport("twain_32.dll", EntryPoint = "#1")]
		private static extern TwRC DSMident([In] [Out] TwIdentity origin, IntPtr zeroptr, TwDG dg, TwDAT dat, TwMSG msg, [In] [Out] TwIdentity idds);

		[DllImport("twain_32.dll", EntryPoint = "#1")]
		private static extern TwRC DSMstatus([In] [Out] TwIdentity origin, IntPtr zeroptr, TwDG dg, TwDAT dat, TwMSG msg, [In] [Out] TwStatus dsmstat);

		[DllImport("twain_32.dll", EntryPoint = "#1")]
		private static extern TwRC DSuserif([In] [Out] TwIdentity origin, [In] [Out] TwIdentity dest, TwDG dg, TwDAT dat, TwMSG msg, TwUserInterface guif);

		[DllImport("twain_32.dll", EntryPoint = "#1")]
		private static extern TwRC DSevent([In] [Out] TwIdentity origin, [In] [Out] TwIdentity dest, TwDG dg, TwDAT dat, TwMSG msg, ref TwEvent evt);

		[DllImport("twain_32.dll", EntryPoint = "#1")]
		private static extern TwRC DSstatus([In] [Out] TwIdentity origin, [In] TwIdentity dest, TwDG dg, TwDAT dat, TwMSG msg, [In] [Out] TwStatus dsmstat);

		[DllImport("twain_32.dll", EntryPoint = "#1")]
		private static extern TwRC DScap([In] [Out] TwIdentity origin, [In] TwIdentity dest, TwDG dg, TwDAT dat, TwMSG msg, [In] [Out] TwCapability capa);

		[DllImport("twain_32.dll", EntryPoint = "#1")]
		private static extern TwRC DSiinf([In] [Out] TwIdentity origin, [In] TwIdentity dest, TwDG dg, TwDAT dat, TwMSG msg, [In] [Out] TwImageInfo imginf);

		[DllImport("twain_32.dll", EntryPoint = "#1")]
		private static extern TwRC DSixfer([In] [Out] TwIdentity origin, [In] TwIdentity dest, TwDG dg, TwDAT dat, TwMSG msg, ref IntPtr hbitmap);

		[DllImport("twain_32.dll", EntryPoint = "#1")]
		private static extern TwRC DSpxfer([In] [Out] TwIdentity origin, [In] TwIdentity dest, TwDG dg, TwDAT dat, TwMSG msg, [In] [Out] TwPendingXfers pxfr);

		[DllImport("kernel32.dll", ExactSpelling = true)]
		internal static extern IntPtr GlobalAlloc(int flags, int size);

		[DllImport("kernel32.dll", ExactSpelling = true)]
		internal static extern IntPtr GlobalLock(IntPtr handle);

		[DllImport("kernel32.dll", ExactSpelling = true)]
		internal static extern bool GlobalUnlock(IntPtr handle);

		[DllImport("kernel32.dll", ExactSpelling = true)]
		internal static extern IntPtr GlobalFree(IntPtr handle);

		[DllImport("user32.dll", ExactSpelling = true)]
		private static extern int GetMessagePos();

		[DllImport("user32.dll", ExactSpelling = true)]
		private static extern int GetMessageTime();

		[DllImport("gdi32.dll", ExactSpelling = true)]
		private static extern int GetDeviceCaps(IntPtr hDC, int nIndex);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr CreateDC(string szdriver, string szdevice, string szoutput, IntPtr devmode);

		[DllImport("gdi32.dll", ExactSpelling = true)]
		private static extern bool DeleteDC(IntPtr hdc);
	}
}
