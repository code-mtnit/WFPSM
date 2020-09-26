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
    public class DrawCurveLine : Tool 
    {

        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hWnd);

        #region Constructors

        private Point prev = new Point();
        private IDocument CurrentDocument;
        Collection<byte> m_colpathType = new Collection<byte>();
        Collection<PointF[]> m_colAllCurve = new Collection<PointF[]>();
         

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
                if (this.CurrentPen != null)
                    this.CurrentPen.Width = value;
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
                if (this.CurrentPen != null)
                    this.CurrentPen.Color = value;
            }
        }

        private Pen _CurrentPen = new Pen(Color.Black, 3);

        public Pen CurrentPen
        {
            get { return _CurrentPen; }
            set { _CurrentPen = value; }
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
        /// <summary>
        /// Default constructor.
        /// </summary>
        public DrawCurveLine()
        {
            
            this.CurrentPen.MiterLimit = 1;
            this.CurrentPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            this.CurrentPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
          //  this.CurrentPen.Graphics.SmoothingMode = SmoothingMode.HighQuality;
        }

        public void ClearAll()
        {
            this.Points.Clear();
            m_colpathType.Clear();
          //  mcolAllCurrv.Clear();
           
        }


                #endregion

        #region IActions Interface


        Collection<PointF> mcolTempPoint = new Collection<PointF>();
        public override void MouseDown(IDocument document, MouseEventArgs e)
        {
            this.isAnnotationActive = true;
            Points.Add(e.Location);
            mcolTempPoint.Add(e.Location);
            m_colpathType.Add(byte.Parse("1"));
            base.MouseDown(document, e);
        }
        /// <summary>
        /// Mouse up function.
        /// </summary>
        /// <param name="document">Informations transferred from DrawingPanel.</param>
        /// <param name="e">MouseEventArgs.</param>
        public override void MouseUp(IDocument document, MouseEventArgs e)
        {
            this.CurrentDocument = document;
            MousePressed = false;
            this.isAnnotationActive = false ;

            Points.Add(e.Location);
            m_colpathType.Add(byte.Parse("0"));
            mcolTempPoint.Add(e.Location);
            IShape shape = CreateDrawingShape(e.Location , mcolTempPoint);
            mcolTempPoint.Clear();
            if (shape == null)
                return;

            if (this.group == null)//Added by rm
            {
                this.group = new CompositeShape();
            }

            this.group.Shapes.Add(shape);//Added by rm
            this.group.Appearance = shape.Appearance;

            if (!document.Shapes.Contains(group) && group != null)          //Added by rm
            {
                document.Shapes.Add(group);               //Added by rm
            }

            Points.Clear();
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

            if (e.Button == MouseButtons.Left)
            {
                try
                {
                   mcolTempPoint.Add(e.Location);
                   Points.Add(e.Location);
                   m_colpathType.Add(byte.Parse("1"));
                   prev = e.Location;
                }
                catch
                { }

                var zoomFactor = (document.DrawingControl as DrawingPanel).ZoomFactor;//
                if ((document.DrawingControl as DrawingPanel).BackgroundLayer != null)
                    zoomFactor = (document.DrawingControl as DrawingPanel).BackgroundLayer.Bitmap.Width / (document.DrawingControl as DrawingPanel).BackgroundLayer.Dimension.Width;

                //Rectangle rr = new Rectangle(new Point((int)(MouseLoc.X - this.CurrentPen.Width / 4), (int)(MouseLoc.Y - this.CurrentPen.Width / 4)), new Size((int)this.CurrentPen.Width + 20, (int)this.CurrentPen.Width + 20));
                Rectangle rr = new Rectangle((int)(e.X - (CurrentPen.Width / (2 * zoomFactor))) - 3, (int)(e.Y - (CurrentPen.Width / (2 * zoomFactor))) - 3, (int)(CurrentPen.Width / zoomFactor) + 6, (int)(CurrentPen.Width / zoomFactor) + 6);
                ////  cr.DrawStretched(gg,rr); 

                document.DrawingControl.Invalidate(rr);

                

            }

        }

        #endregion





        public override void Paint(IDocument document, PaintEventArgs e)
        {

            if (_points.Count == 0)
                return;

            PointF[] points = ToPointF(mcolTempPoint);
            if (points == null || points.Length < 2)
                return;
            this.CurrentPen.Width = this.WidthPen;
            e.Graphics.DrawCurve(this.CurrentPen, points);
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


        private byte[] getPathType(Collection<byte> collection)
        {
            if (collection == null || collection.Count == 0)
                return null;

            byte[] points = new byte[collection.Count];
            collection.CopyTo(points, 0);

            return points;
        }

        /// <summary>
        /// Creates a shape relative to actual points.
        /// </summary>
        /// <returns>New Shape.</returns>
        virtual protected IShape CreateDrawingShape(PointF point , Collection<PointF> ppO)
        {
            if (ppO.Count == 0)
            {
                //Ellipse el = new Ellipse();
                //el.Center = point;
                //el.Dimension = new SizeF(2, 2);
                ////el.Dimension.Width = 2;
                ////el.Dimension.Height = 2;
                //_shape = new Sbn.AdvancedControls.Imaging.SbnPaint.Ellipse(el);

                // return null;
                ppO.Add(point);
                ppO.Add(new PointF(point.X + 1, point.Y + 1));
            }

            _shape = new CustomShape();  //added by rm

            _shape.Color = this.Color;
            Pen pen = new Pen(this.Color, this.WidthPen);
           
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.MiterLimit = 1;
          //  pen.Color = Color.Red;
            _shape.Appearance.BorderColor = this.Color;
            _shape.Appearance.BorderWidth = this.WidthPen;
            _shape.Appearance.ActivePen = pen;
             
            if (ppO.Count == 2)
            {

                PointF[] pf = ToPointF(ppO);
                if (pf[0] == pf[1])
                {
                    pf[1].X += 0.5f;
                }
                _shape.Geometric.AddLines(pf);
                

                //                Line ln = new Line(_points[0], _points[1]);
                //                ln.Appearance.ActivePen = pen;

                //                _shape = new Sbn.AdvancedControls.Imaging.SbnPaint.Line(ln); cmd by ghmhm
            }
            else
                if (ppO.Count > 2)
                {
                    
                //    GraphicsPath pp = new GraphicsPath(ToPointF(_points), getPathType(m_colpathType));
                    _shape.Geometric.AddCurve(ToPointF(ppO));
                    //_shape.Geometric.AddLines(ToPointF(_points));
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
