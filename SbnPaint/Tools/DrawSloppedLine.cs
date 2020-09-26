using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.ObjectModel;

using Sbn.FramWork.Drawing;

namespace Sbn.AdvancedControls.Imaging.SbnPaint
{
    /// <summary>
    /// Draw a slopped line.
    /// </summary>
    public class DrawSloppedLine : Tool
    {
        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DrawSloppedLine()
        {
        }

        #endregion

        #region IActions Interface

        /// <summary>
        /// Mouse up function.
        /// </summary>
        /// <param name="document">Informations transferred from DrawingPanel.</param>
        /// <param name="e">MouseEventArgs.</param>
        public override void MouseUp(IDocument document, MouseEventArgs e)
        {
            base.MouseUp(document, e);

            if (e.Button == MouseButtons.Left)
                _points.Add(document.GridManager.GetRoundedPoint(e.Location));
            else if (e.Button == MouseButtons.Right)
            {
                IShape shape = CreateDrawingShape(e.Location );
                if (shape == null)
                    return;

                document.Shapes.Add(shape);
                _points.Clear();
            }
        }

        /// <summary>
        /// Mouse move function.
        /// </summary>
        /// <param name="document">Informations transferred from DrawingPanel.</param>
        /// <param name="e">MouseEventArgs.</param>
        public override void MouseMove(IDocument document, MouseEventArgs e)
        {
            base.MouseMove(document, e);

            document.DrawingControl.Invalidate();
        }

        /// <summary>
        /// Paint function.
        /// </summary>
        /// <param name="document">Informations transferred from DrawingPanel.</param>
        /// <param name="e">PaintEventArgs.</param>
        public override void Paint(IDocument document, PaintEventArgs e)
        {
            
            if (_points.Count == 0)
                return;

            PointF[] points = ToPointF(_points);
            if (points == null)
                return;

            Pen pen = new Pen(Color.Black, 2);
            pen.MiterLimit = 1;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;

           // e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            if (points.GetLength(0) > 1)
                e.Graphics.DrawLines(pen, points);
            else
            {

            }
            pen.Dispose();

//            e.Graphics.DrawLine(pen, _points[_points.Count - 1], document.GridManager.GetRoundedPoint(document.DrawingControl.PointToClient(Control.MousePosition)));
//            e.Graphics.DrawLine(pen, _points[_points.Count - 1], document.DrawingControl.PointToClient(Control.MousePosition));
        }

        #endregion

        #region Properties

        IShape _shape = new CustomShape();
        /// <summary>
        /// Gets the drawn shape.
        /// </summary>
        protected IShape DrawingShape
        {
            get { return _shape; }
        }

        Collection<PointF> _points = new Collection<PointF>();
        /// <summary>
        /// Gets the drawn points.
        /// </summary>
        protected Collection<PointF> Points
        {
            get { return _points; }
        }


        #endregion

        #region Public Functions

        /// <summary>
        /// Updates the cursor during the tool actions.
        /// </summary>
        /// <param name="document">Informations transferred from DrawingPanel.</param>
        /// <param name="shapes">Shapes to manage.</param>
        /// <param name="point">Mouse point.</param>
        /// <returns>True if it is updated.</returns>
        public override bool UpdateCursor(IDocument document, ShapeCollection shapes, Point point)
        {
            document.ActiveCursor = Cursors.Cross;
            return true;
        }

        #endregion

        #region Protected Functions

        /// <summary>
        /// Tranforms a PointF collection into PointF[].
        /// </summary>
        /// <param name="collection">Collection to transform.</param>
        /// <returns>Points.</returns>
        protected PointF[] ToPointF(Collection<PointF> collection)
        {
            if (collection == null || collection.Count == 0)
                return null;

            PointF[] points = new PointF[collection.Count];
            collection.CopyTo(points, 0);

            return points;
        }


        //virtual protected IShape CreateDrawingShape(PointF point)
        //{
        //    Collection<PointF[]> mcolPoint = new Collection<PointF[]>();

        //    int Counter = 1;

        //    for (int i = 0; i < _points.Count; i++)
        //    {
        //        if (_points[i] != point)
        //        {
        //            Counter++;
        //        }
        //        else
        //        {
        //            PointF[] p1 = new PointF[Counter - 1];
        //            for (int j = 0; j < Counter - 1; j++)
        //            {
        //                p1.SetValue(_points[j], j);
        //            }
        //            mcolPoint.Add(p1);

        //        }
        //    }
        //    _shape.Geometric.AddLines(ToPointF(mcolPoint[0]));
        //    IShape shape = _shape.Clone() as IShape;
        //    shape.Selected = true;

        //    return shape;
        //}

        /// <summary>
        /// Creates a shape relative to actual points.
        /// </summary>
        /// <returns>New Shape.</returns>
        virtual protected IShape CreateDrawingShape(PointF point)
        {
            if (_points.Count == 0)
            {
                //Ellipse el = new Ellipse();
                //el.Center = point;
                //el.Dimension = new SizeF(2, 2);
                ////el.Dimension.Width = 2;
                ////el.Dimension.Height = 2;
                //_shape = new Sbn.AdvancedControls.Imaging.SbnPaint.Ellipse(el);

               // return null;
                _points.Add(point);
                _points.Add(new PointF(point.X+1 , point.Y+1));
            }

            _shape = new CustomShape ();  //added by rm


            Pen pen = new Pen(Color.Black, 2);

            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            _shape.Appearance.ActivePen = pen;
            if (_points.Count == 2)
            {
                _shape.Geometric.AddLines(ToPointF(_points));

//                Line ln = new Line(_points[0], _points[1]);
//                ln.Appearance.ActivePen = pen;

//                _shape = new Sbn.AdvancedControls.Imaging.SbnPaint.Line(ln); cmd by ghmhm
            }
            else
                if (_points.Count != 0)
                {
                    _shape.Geometric.AddLines(ToPointF(_points));
                }
                else
                {
                    return null;
                }

            IShape shape = _shape.Clone() as IShape;

            pen.Dispose();

           // shape.Selected = true;  //Commented by rm
            shape.Selected = false;   //added by rm
            shape.Locked = true;      //added by rm

            return shape;
        }

        #endregion
    }
}
