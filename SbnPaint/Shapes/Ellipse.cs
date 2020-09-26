using System;
using System.Collections.Generic;
using System.Text;
using Sbn.FramWork.Drawing.Serialization;
using Sbn.FramWork.Drawing;



namespace Sbn.AdvancedControls.Imaging.SbnPaint
{
    /// <summary>
    /// Ellipse shape.
    /// </summary>
    [XmlClassSerializable("ellipse")]
    public class Ellipse : Shape
    {
        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Ellipse()
        {
            Geometric.AddEllipse(new System.Drawing.Rectangle(0, 0, 1, 1));
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="ellipse">Ellispe to copy.</param>
        public Ellipse(Ellipse ellipse) : base(ellipse)
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
            var el = new Ellipse(this);
            el.Tag = Tag;
            return el;
        }

        #endregion

        #endregion
    }
}
