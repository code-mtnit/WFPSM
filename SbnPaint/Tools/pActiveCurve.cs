using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Microsoft.Ink;
using Sbn.FramWork.Drawing;

namespace Sbn.AdvancedControls.Imaging.SbnPaint
{
    public class pActiveCurve : Tool
    {
        public InkCollector myInkCollector;

        private float _width = 2;
        public float WidthPen
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
                if (myInkCollector != null)
                    myInkCollector.DefaultDrawingAttributes.Width = value * 9 ;
                //if (this.CurrentPen != null)
                //    this.CurrentPen.Width = value;
            }
        }

        private Color _Color = Color.Black;

        public Color Color
        {
            get
            {
                return _Color;
            }
            set
            {
                _Color = value;
                //if (this.CurrentPen != null)
                //    this.CurrentPen.Color = value;
                // Set the pen width
                if (myInkCollector != null)
                    myInkCollector.DefaultDrawingAttributes.Color = value;
            }
        }



        public override void MouseMove(IDocument document, System.Windows.Forms.MouseEventArgs e)
        {
            Color = document.CurrentPen.Color;
            WidthPen = document.CurrentPen.Width;

            base.MouseMove(document, e);
        }
          #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public pActiveCurve(float PenWidth , Color inkColor)
        {
            Color = inkColor;
            WidthPen = PenWidth;
        }

        public pActiveCurve()
        {
          
        }

        #endregion
    }
}
