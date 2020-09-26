using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Sbn.FramWork.Drawing;
using Sbn.FramWork.Drawing.Serialization;
using System.Drawing;

namespace Sbn.AdvancedControls.Imaging.SbnPaint
{
    /// <summary>
    /// Rectangle shape.
    /// </summary>
    [XmlClassSerializable("rectangle")]
    public class RectangleBody : Shape
    {
        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RectangleBody()
        {
            
            Geometric.AddRectangle(new System.Drawing.Rectangle(0, 0, 1, 1));
        }

        public override void MouseMove(IDocument document, System.Windows.Forms.MouseEventArgs e)
        {
            base.MouseMove(document, e);
            //document.ActiveCursor = new Cursor(GetType(), "Rectangle.cur");
           // document.ActiveCursor = Cursors.Cross;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="rectangle">Rectangle to copy.</param>
        public RectangleBody(RectangleBody rectangle) : base(rectangle)
        {
        }

        #endregion

        #region IShape Interface

        #region ICloneable Interface

        /// <summary>
        /// Clones the shape.
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var rec = new RectangleBody(this);
            rec.Tag = Tag;
            return rec;
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

            Pen pen = new Pen(this.Appearance.ActivePen.Color, this.Appearance.BorderWidth );

            pen.MiterLimit = 1;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;

            g.DrawRectangle(pen, 0, 0, this.Dimension.Width, this.Dimension.Height);

            return bmp;
        }

        #endregion

        #endregion
    }
}
