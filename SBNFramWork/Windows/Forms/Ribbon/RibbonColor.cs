using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Sbn.FramWork.Windows.Forms.Ribbon
{
    public class RibbonColor
    {

        #region Constructors
        public RibbonColor(Color color)
        {
            rc = color.R;
            gc = color.G;
            bc = color.B;
            ac = color.A;

            HSV();
        }

        public RibbonColor(uint alpha, int hue, int saturation, int brightness)
        {
            hc = hue;
            sc = saturation;
            vc = brightness;
            ac = alpha;

            GetColor();
        }
        #endregion

        #region Alpha
        private uint ac = 0; //Alpha > -1
        public uint AC { get { return ac; } set { System.Math.Min(value, 255); } }
        #endregion

        #region RGB
        private int rc = 0, gc = 0, bc = 0; //RGB Components > -1 

        public int RC { get { return rc; } set { rc = System.Math.Min(value, 255); } }
        public int GC { get { return gc; } set { gc = System.Math.Min(value, 255); } }
        public int BC { get { return bc; } set { bc = System.Math.Min(value, 255); } }


        public Color GetColor()
        {

            int conv;
            double hue, sat, val;
            int basis;

            hue = (float)hc / 100.0f;
            sat = (float)sc / 100.0f;
            val = (float)vc / 100.0f;

            if ((float)sc == 0) // Gray Colors
            {
                conv = (int)(255.0f * val);
                rc = gc = bc = conv;
                return Color.FromArgb((int)rc, (int)gc, (int)bc);
            }

            basis = (int)(255.0f * (1.0 - sat) * val);

            switch ((int)((float)hc / 60.0f))
            {
                case 0:
                    rc = (int)(255.0f * val);
                    gc = (int)((255.0f * val - basis) * (hc / 60.0f) + basis);
                    bc = (int)basis;
                    break;

                case 1:
                    rc = (int)((255.0f * val - basis) * (1.0f - ((hc % 60) / 60.0f)) + basis);
                    gc = (int)(255.0f * val);
                    bc = (int)basis;
                    break;

                case 2:
                    rc = (int)basis;
                    gc = (int)(255.0f * val);
                    bc = (int)((255.0f * val - basis) * ((hc % 60) / 60.0f) + basis);
                    break;

                case 3:
                    rc = (int)basis;
                    gc = (int)((255.0f * val - basis) * (1.0f - ((hc % 60) / 60.0f)) + basis);
                    bc = (int)(255.0f * val);
                    break;

                case 4:
                    rc = (int)((255.0f * val - basis) * ((hc % 60) / 60.0f) + basis);
                    gc = (int)basis;
                    bc = (int)(255.0f * val);
                    break;

                case 5:
                    rc = (int)(255.0f * val);
                    gc = (int)basis;
                    bc = (int)((255.0f * val - basis) * (1.0f - ((hc % 60) / 60.0f)) + basis);
                    break;
            }
            return Color.FromArgb((int)ac, (int)rc, (int)gc, (int)bc);

        }

        public uint GetRed()
        {
            return GetColor().R;
        }

        public uint GetGreen()
        {
            return GetColor().G;
        }

        public uint GetBlue()
        {
            return GetColor().B;
        }

        #endregion

        #region HSV

        private int hc = 0, sc = 0, vc = 0;

        public float HC { get { return hc; } set { hc = (int)System.Math.Min(value, 359); hc = (int)System.Math.Max(hc, 0); } }
        public float SC { get { return sc; } set { sc = (int)System.Math.Min(value, 100); sc = (int)System.Math.Max(sc, 0); } }
        public float VC { get { return vc; } set { vc = (int)System.Math.Min(value, 100); vc = (int)System.Math.Max(vc, 0); } }

        public enum C { Red, Green, Blue, None }
        private int maxval = 0, minval = 0;
        private C CompMax, CompMin;

        private void HSV()
        {
            hc = this.GetHue();
            sc = this.GetSaturation();
            vc = this.GetBrightness();
        }

        public void CMax()
        {
            if (rc > gc)
            {
                if (rc < bc) { maxval = bc; CompMax = C.Blue; }
                else { maxval = rc; CompMax = C.Red; }
            }
            else
            {
                if (gc < bc) { maxval = bc; CompMax = C.Blue; }
                else { maxval = gc; CompMax = C.Green; }
            }
        }

        public void CMin()
        {
            if (rc < gc)
            {
                if (rc > bc) { minval = bc; CompMin = C.Blue; }
                else { minval = rc; CompMin = C.Red; }
            }
            else
            {
                if (gc > bc) { minval = bc; CompMin = C.Blue; }
                else { minval = gc; CompMin = C.Green; }
            }

        }

        public int GetBrightness()  //Brightness is from 0 to 100
        {
            CMax(); return 100 * maxval / 255;
        }

        public int GetSaturation() //Saturation from 0 to 100
        {
            CMax(); CMin();
            if (CompMax == C.None)
                return 0;
            else if (maxval != minval)
            {
                Decimal d_sat = Decimal.Divide(minval, maxval);
                d_sat = Decimal.Subtract(1, d_sat);
                d_sat = Decimal.Multiply(d_sat, 100);
                return Convert.ToUInt16(d_sat);
            }
            else
            {
                return 0;
            }

        }

        public int GetHue()
        {
            CMax(); CMin();

            if (maxval == minval)
            {
                return 0;
            }
            else if (CompMax == C.Red)
            {
                if (gc >= bc)
                {
                    Decimal d1 = Decimal.Divide((gc - bc), (maxval - minval));
                    return Convert.ToUInt16(60 * d1);
                }
                else
                {
                    Decimal d1 = Decimal.Divide((bc - gc), (maxval - minval));
                    d1 = 60 * d1;
                    return Convert.ToUInt16(360 - d1);
                }
            }
            else if (CompMax == C.Green)
            {
                if (bc >= rc)
                {
                    Decimal d1 = Decimal.Divide((bc - rc), (maxval - minval));
                    d1 = 60 * d1;
                    return Convert.ToUInt16(120 + d1);
                }
                else
                {
                    Decimal d1 = Decimal.Divide((rc - bc), (maxval - minval));
                    d1 = 60 * d1;
                    return Convert.ToUInt16(120 - d1);
                }


            }
            else if (CompMax == C.Blue)
            {
                if (rc >= gc)
                {
                    Decimal d1 = Decimal.Divide((rc - gc), (maxval - minval));
                    d1 = 60 * d1;
                    return Convert.ToUInt16(240 + d1);
                }
                else
                {
                    Decimal d1 = Decimal.Divide((gc - rc), (maxval - minval));
                    d1 = 60 * d1;
                    return Convert.ToUInt16(240 - d1);
                }
            }
            else
            {
                return 0;
            }
        }  //Hue from 0 to 100

        #endregion

        #region Methods

        public bool IsDark()
        {
            if (BC > 50)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void IncreaseBrightness(int val)
        {
            this.VC = this.VC + val;

        }

        public void SetBrightness(int val)
        {
            this.VC = val;

        }

        public void IncreaseHue(int val)
        {
            this.HC = this.HC + val;

        }

        public void SetHue(int val)
        {
            this.HC = val;

        }

        public void IncreaseSaturation(int val)
        {
            this.SC = this.SC + val;

        }

        public void SetSaturation(int val)
        {
            this.SC = val;

        }

        public Color IncreaseHSV(int h, int s, int b)
        {
            this.HC = this.HC + h;
            this.SC = this.SC + s;
            this.VC = this.VC + b;
            return GetColor();
        }

        #endregion

    }
}
