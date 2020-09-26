using System;
using System.Collections.Generic;
using System.Text;

using Sbn.FramWork.Drawing;
using Sbn.FramWork.Drawing.Serialization;
using System.Drawing;

namespace Sbn.AdvancedControls.Imaging.SbnPaint
{
    public class pActiveAnnotation : Shape , IDisposable 
    {
        
       // public override void Paint(IDocument document, System.Windows.Forms.PaintEventArgs e)
       //{
       //     //if (_bitmap != null)
       //     //    e.Graphics.DrawImage(_bitmap, Location.X, Location.Y, Dimension.Width, Dimension.Height);
       //}


        #region Properties

        Bitmap _bitmap = null;
        /// <summary>
        /// Gets or sets the bitmap image.
        /// </summary>
        public Bitmap Bitmap
        {
            get { return _bitmap; }
            set { _bitmap = value; }
        }

        #endregion
      

        #region Constructors

           /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="bitmap">Reference bitmap.</param>
        public pActiveAnnotation(Bitmap bitmap , PointF location)
        {
           // Geometric.AddLine(new Point(0, 0), new Point(1, 1));
            Geometric.AddRectangle(new System.Drawing.RectangleF(location.X, location.Y, bitmap.Width , bitmap.Height));

            if (bitmap != null)
            {
                _bitmap = bitmap.Clone() as Bitmap;
                this.Appearance.Image = bitmap;
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public pActiveAnnotation()
        {
            Geometric.AddRectangle(new System.Drawing.Rectangle(0, 0, 1, 1));
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="rectangle">Rectangle to copy.</param>
        public pActiveAnnotation(pActiveAnnotation rectangle)
            : base(rectangle)
        {
        }

        #endregion



        public override object Clone()
        {
            var pAct = new pActiveAnnotation(this.Bitmap, this.Location);
            pAct.Tag = Tag;
            return pAct;
        }
        public override System.Drawing.Image GetImage(float ZoomFactor)
        {

            double ll = Math.Truncate(ZoomFactor * 100000);
            float tt = (float)(100000 / ll);

            bool selected = this.Selected;
            bool locked = this.Locked;
            PointF ShapeLocation = this.Location;

            this.Selected = true;
            this.Locked = false;

            this.Location = new PointF(0, 0);


            try
            {
                this.Transformer.Scale(tt, tt);
            }
            catch
            {
            }

            Bitmap bmp = new Bitmap((int)(this.Dimension.Width + 1), (int)(this.Dimension.Height + 1));
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);

            //return base.GetImage();
            g.DrawImage(this.Bitmap, 0, 0, this.Dimension.Width, this.Dimension.Height);

            g.Dispose();

            this.Location = ShapeLocation;
            this.Selected = selected;
            this.Locked = locked;
            return bmp;
        }

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
