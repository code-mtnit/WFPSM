using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.ObjectModel;

using Sbn.FramWork.Drawing;
using System.Runtime.InteropServices;

namespace Sbn.AdvancedControls.Imaging.SbnPaint
{
    /// <summary>
    /// Draw a free line.
    /// </summary>
    public class DrawFreeLine : Tool
    {

        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hWnd);

        #region Constructors
        private IDocument CurrentDocument;

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
            }
        }

        //private bool Applay = false;
        public void Applay()
        {
            this.group = new CompositeShape();
        }

        public void Cancel()
        {
            if (this.CurrentDocument != null)
            {
                this.CurrentDocument.Shapes.Remove(this.group);
                this.group = new CompositeShape();
                this.CurrentDocument.DrawingControl.Invalidate();
            }
        }

        public CompositeShape group = null;


        private Point prev = new Point();
     
      
        /// <summary>
        /// Default constructor.
        /// </summary>
        public DrawFreeLine()
        {
        }

        public DrawFreeLine(CompositeShape _group)
        {
            group = _group;
        }


        #endregion

        #region IActions Interface

        public override void MouseDown(IDocument document, MouseEventArgs e)
        {
            this.isAnnotationActive = true;
            base.MouseDown(document, e);
        }
        /// <summary>
        /// Mouse up function.
        /// </summary>
        /// <param name="document">Informations transferred from DrawingPanel.</param>
        /// <param name="e">MouseEventArgs.</param>
        public override void MouseUp(IDocument document, MouseEventArgs e)
        {

            MousePressed = false;
            this.isAnnotationActive = false;

            IShape shape = CreateDrawingShape(e.Location);

            if (shape == null)
                return;

            if (this.group != null)//Added by rm
            {
                this.group.Shapes.Add(shape);//Added by rm
            }
            else                                            //Added by rm
            {
                this.group = new CompositeShape();
                group.Appearance = shape.Appearance;
                this.group.Shapes.Add(shape);
            }

            if (!document.Shapes.Contains(group) && group != null)          //Added by rm
            {
                document.Shapes.Add(group);               //Added by rm
            }

            Points.Clear();
            //base.MouseMove(document, e);
            document.DrawingControl.Invalidate();

        }

        /// <summary>
        /// Mouse move function.
        /// </summary>
        /// <param name="document">Informations transferred from DrawingPanel.</param>
        /// <param name="e">MouseEventArgs.</param>
        public override void MouseMove(IDocument document, MouseEventArgs e)
        {
            if (!MousePressed)
                return;

            this.isAnnotationActive = true;

            PointF newPoint = new PointF(
                e.Location.X/* + document.GridResolution.Width*/,
                e.Location.Y/* + document.GridResolution.Height*/);

            /*
            Pen pen = new Pen(Color.Black, 2);
            pen.MiterLimit = 1;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;


            using (System.Drawing.Graphics gr = System.Drawing.Graphics.FromHdc(GetDC(IntPtr.Zero)))
            {
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                gr.DrawLine(pen, prev, e.Location);
                prev = e.Location;
            }
            pen.Dispose();
            */
            // newPoint = document.GridManager.GetRoundedPoint(newPoint);

            if (Points.Count > 0)
            {
                //PointF point = Points[Points.Count - 1];
                //if (Math.Abs(point.X - newPoint.X) < _offset && Math.Abs(point.Y - newPoint.Y) < _offset)
                // return;
            }

            Points.Add(newPoint);

            //base.MouseMove(document, e);
            document.DrawingControl.Invalidate();
        }

        #endregion


        public override bool UpdateCursor(IDocument document, ShapeCollection shapes, Point point)
        {
            return base.UpdateCursor(document, shapes, point);
        }
        public override void Paint(IDocument document, PaintEventArgs e)
        {

            //            if (MousePressed)
            //                return;

            if (_points.Count == 0)
                return;

            PointF[] points = ToPointF(_points);
            if (points == null)
                return;

            Pen pen = new Pen(this.Color, this.WidthPen);
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
                _points.Add(new PointF(point.X + 1, point.Y + 1));
            }

            _shape = new CustomShape();  //added by rm


            Pen pen = new Pen(this.Color, this.WidthPen);

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
           // shape.Locked = true;      //added by rm

            return shape;
        }
        #region Properties

        float _offset = 1;
        /// <summary>
        /// Gets or sets the offset between two near points.
        /// </summary>
        public float Offset
        {
            get { return _offset; }
            set { _offset = value; }
        }

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
    }
}
