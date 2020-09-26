using System;
using System.Drawing;

namespace Sbn.FramWork.Windows.Forms.Ribbon
{
	public class RibbonColor
	{
		public enum C
		{
			Red,
			Green,
			Blue,
			None
		}

		private uint ac = 0u;

		private int rc = 0;

		private int gc = 0;

		private int bc = 0;

		private int hc = 0;

		private int sc = 0;

		private int vc = 0;

		private int maxval = 0;

		private int minval = 0;

		private RibbonColor.C CompMax;

		private RibbonColor.C CompMin;

		public uint AC
		{
			get
			{
				return this.ac;
			}
			set
			{
				Math.Min(value, 255u);
			}
		}

		public int RC
		{
			get
			{
				return this.rc;
			}
			set
			{
				this.rc = Math.Min(value, 255);
			}
		}

		public int GC
		{
			get
			{
				return this.gc;
			}
			set
			{
				this.gc = Math.Min(value, 255);
			}
		}

		public int BC
		{
			get
			{
				return this.bc;
			}
			set
			{
				this.bc = Math.Min(value, 255);
			}
		}

		public float HC
		{
			get
			{
				return (float)this.hc;
			}
			set
			{
				this.hc = (int)Math.Min(value, 359f);
				this.hc = Math.Max(this.hc, 0);
			}
		}

		public float SC
		{
			get
			{
				return (float)this.sc;
			}
			set
			{
				this.sc = (int)Math.Min(value, 100f);
				this.sc = Math.Max(this.sc, 0);
			}
		}

		public float VC
		{
			get
			{
				return (float)this.vc;
			}
			set
			{
				this.vc = (int)Math.Min(value, 100f);
				this.vc = Math.Max(this.vc, 0);
			}
		}

		public RibbonColor(Color color)
		{
			this.rc = (int)color.R;
			this.gc = (int)color.G;
			this.bc = (int)color.B;
			this.ac = (uint)color.A;
			this.HSV();
		}

		public RibbonColor(uint alpha, int hue, int saturation, int brightness)
		{
			this.hc = hue;
			this.sc = saturation;
			this.vc = brightness;
			this.ac = alpha;
			this.GetColor();
		}

		public Color GetColor()
		{
			double num = (double)((float)this.hc / 100f);
			double num2 = (double)((float)this.sc / 100f);
			double num3 = (double)((float)this.vc / 100f);
			Color result;
			if ((float)this.sc == 0f)
			{
				int num4 = (int)(255.0 * num3);
				this.rc = (this.gc = (this.bc = num4));
				result = Color.FromArgb(this.rc, this.gc, this.bc);
			}
			else
			{
				int num5 = (int)(255.0 * (1.0 - num2) * num3);
				switch ((int)((float)this.hc / 60f))
				{
				case 0:
					this.rc = (int)(255.0 * num3);
					this.gc = (int)((255.0 * num3 - (double)num5) * (double)((float)this.hc / 60f) + (double)num5);
					this.bc = num5;
					break;
				case 1:
					this.rc = (int)((255.0 * num3 - (double)num5) * (double)(1f - (float)(this.hc % 60) / 60f) + (double)num5);
					this.gc = (int)(255.0 * num3);
					this.bc = num5;
					break;
				case 2:
					this.rc = num5;
					this.gc = (int)(255.0 * num3);
					this.bc = (int)((255.0 * num3 - (double)num5) * (double)((float)(this.hc % 60) / 60f) + (double)num5);
					break;
				case 3:
					this.rc = num5;
					this.gc = (int)((255.0 * num3 - (double)num5) * (double)(1f - (float)(this.hc % 60) / 60f) + (double)num5);
					this.bc = (int)(255.0 * num3);
					break;
				case 4:
					this.rc = (int)((255.0 * num3 - (double)num5) * (double)((float)(this.hc % 60) / 60f) + (double)num5);
					this.gc = num5;
					this.bc = (int)(255.0 * num3);
					break;
				case 5:
					this.rc = (int)(255.0 * num3);
					this.gc = num5;
					this.bc = (int)((255.0 * num3 - (double)num5) * (double)(1f - (float)(this.hc % 60) / 60f) + (double)num5);
					break;
				}
				result = Color.FromArgb((int)this.ac, this.rc, this.gc, this.bc);
			}
			return result;
		}

		public uint GetRed()
		{
			return (uint)this.GetColor().R;
		}

		public uint GetGreen()
		{
			return (uint)this.GetColor().G;
		}

		public uint GetBlue()
		{
			return (uint)this.GetColor().B;
		}

		private void HSV()
		{
			this.hc = this.GetHue();
			this.sc = this.GetSaturation();
			this.vc = this.GetBrightness();
		}

		public void CMax()
		{
			if (this.rc > this.gc)
			{
				if (this.rc < this.bc)
				{
					this.maxval = this.bc;
					this.CompMax = RibbonColor.C.Blue;
				}
				else
				{
					this.maxval = this.rc;
					this.CompMax = RibbonColor.C.Red;
				}
			}
			else if (this.gc < this.bc)
			{
				this.maxval = this.bc;
				this.CompMax = RibbonColor.C.Blue;
			}
			else
			{
				this.maxval = this.gc;
				this.CompMax = RibbonColor.C.Green;
			}
		}

		public void CMin()
		{
			if (this.rc < this.gc)
			{
				if (this.rc > this.bc)
				{
					this.minval = this.bc;
					this.CompMin = RibbonColor.C.Blue;
				}
				else
				{
					this.minval = this.rc;
					this.CompMin = RibbonColor.C.Red;
				}
			}
			else if (this.gc > this.bc)
			{
				this.minval = this.bc;
				this.CompMin = RibbonColor.C.Blue;
			}
			else
			{
				this.minval = this.gc;
				this.CompMin = RibbonColor.C.Green;
			}
		}

		public int GetBrightness()
		{
			this.CMax();
			return 100 * this.maxval / 255;
		}

		public int GetSaturation()
		{
			this.CMax();
			this.CMin();
			int result;
			if (this.CompMax == RibbonColor.C.None)
			{
				result = 0;
			}
			else if (this.maxval != this.minval)
			{
				decimal num = decimal.Divide(this.minval, this.maxval);
				num = decimal.Subtract(1m, num);
				num = decimal.Multiply(num, 100m);
				result = (int)Convert.ToUInt16(num);
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public int GetHue()
		{
			this.CMax();
			this.CMin();
			int result;
			if (this.maxval == this.minval)
			{
				result = 0;
			}
			else if (this.CompMax == RibbonColor.C.Red)
			{
				if (this.gc >= this.bc)
				{
					decimal d = decimal.Divide(this.gc - this.bc, this.maxval - this.minval);
					result = (int)Convert.ToUInt16(60m * d);
				}
				else
				{
					decimal d = decimal.Divide(this.bc - this.gc, this.maxval - this.minval);
					d = 60m * d;
					result = (int)Convert.ToUInt16(360m - d);
				}
			}
			else if (this.CompMax == RibbonColor.C.Green)
			{
				if (this.bc >= this.rc)
				{
					decimal d = decimal.Divide(this.bc - this.rc, this.maxval - this.minval);
					d = 60m * d;
					result = (int)Convert.ToUInt16(120m + d);
				}
				else
				{
					decimal d = decimal.Divide(this.rc - this.bc, this.maxval - this.minval);
					d = 60m * d;
					result = (int)Convert.ToUInt16(120m - d);
				}
			}
			else if (this.CompMax == RibbonColor.C.Blue)
			{
				if (this.rc >= this.gc)
				{
					decimal d = decimal.Divide(this.rc - this.gc, this.maxval - this.minval);
					d = 60m * d;
					result = (int)Convert.ToUInt16(240m + d);
				}
				else
				{
					decimal d = decimal.Divide(this.gc - this.rc, this.maxval - this.minval);
					d = 60m * d;
					result = (int)Convert.ToUInt16(240m - d);
				}
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public bool IsDark()
		{
			return this.BC <= 50;
		}

		public void IncreaseBrightness(int val)
		{
			this.VC += (float)val;
		}

		public void SetBrightness(int val)
		{
			this.VC = (float)val;
		}

		public void IncreaseHue(int val)
		{
			this.HC += (float)val;
		}

		public void SetHue(int val)
		{
			this.HC = (float)val;
		}

		public void IncreaseSaturation(int val)
		{
			this.SC += (float)val;
		}

		public void SetSaturation(int val)
		{
			this.SC = (float)val;
		}

		public Color IncreaseHSV(int h, int s, int b)
		{
			this.HC += (float)h;
			this.SC += (float)s;
			this.VC += (float)b;
			return this.GetColor();
		}
	}
}
