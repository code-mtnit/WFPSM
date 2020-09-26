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
    public class Draft : Tool 
    {

        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hWnd);

        #region Constructors

        private Point prev = new Point();
        private IDocument CurrentDocument;

        public DrawingPanel baseDocument;


        System.Drawing.Pen _CurrentPen = new Pen(Color.Black, 20);

        public System.Drawing.Pen  CurrentPen
        {
            get { return _CurrentPen; }
            set
            {
                _CurrentPen = value;

            }
        }

        //private float _width = 2;
        //public float WidthPen
        //{
        //    get
        //    {
        //        return _width;
        //    }

        //    set
        //    {
        //        _width = value;
        //    }
        //}

        //private Color _Color = Color.Black;

        //public Color Color
        //{
        //    get
        //    {
        //        return _Color;
        //    }
        //    set
        //    {
        //        _Color = value;
        //    }
        //}

        //private bool Applay = false;
        //public void Applay()
        //{
        //    this.group = new CompositeShape();
        //}

        public void Cancel()
        {
            this.CurrentDocument.Shapes.Remove(this.group);
            this.group = new CompositeShape();
            this.CurrentDocument.DrawingControl.Invalidate();
        }

        public CompositeShape group = null;
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Draft()
        {
        }

       


                #endregion

        #region IActions Interface

        public override void MouseDown(IDocument document, MouseEventArgs e)
        {

            if (e.Button != MouseButtons.Left)
                return;


            var zoomFactor = baseDocument.ZoomFactor;//
            if (baseDocument.BackgroundLayer != null)
                zoomFactor = baseDocument.BackgroundLayer.Dimension.Width / baseDocument.BackgroundLayer.Bitmap.Width;

            this.isAnnotationActive = true;
            ShapeCollection ss = new ShapeCollection();
            ss =  Select.GetSelectedShapes(document.Shapes);
            RectangleF recEllips = new RectangleF();
            if (ss.Count > 0)
            {
                try
                {
                    selectedShape = (Shape)ss[0];

                    if (selectedShape is Image)
                    {
                        bmp = new Bitmap(selectedShape.Appearance.Image, (int)selectedShape.Appearance.Image.Width, (int)selectedShape.Appearance.Image.Height);
                        RectangleF rect = new RectangleF(0, 0, (int)selectedShape.Appearance.Image.Width, (int)selectedShape.Appearance.Image.Height);
                        g = Graphics.FromImage(bmp);
                        g.DrawImage(selectedShape.Appearance.Image, rect);


                        recEllips = new RectangleF((e.Location.X - selectedShape.Location.X - (CurrentPen.Width * zoomFactor / 2)),
                                                (e.Location.Y - selectedShape.Location.Y - (CurrentPen.Width * zoomFactor / 2)),
                                                this.CurrentPen.Width * zoomFactor, this.CurrentPen.Width* zoomFactor);

                        g.DrawEllipse(new Pen(Color.Transparent, 1), recEllips);
                        g.FillEllipse(new SolidBrush(Color.Transparent), recEllips);
                        
                    }else if (selectedShape is CompositeShape)
                    {
                        foreach (var sh in (selectedShape as CompositeShape).Shapes)
                        {
                            if (selectedShape is DrawFreeLine)
                            {

                            }
                        }
                    }
                    else if (selectedShape is DrawFreeLine)
                    {
                      
                    }


                }
                catch
                { }
            }
            else
            {
                if (this.baseDocument != null && this.baseDocument.BackgroundLayer != null && this.baseDocument.BackgroundLayer.Bitmap != null)
                {
                    selectedShape = this.baseDocument.BackgroundLayer;
                    bmp = new Bitmap(this.baseDocument.BackgroundLayer.Bitmap, (int)baseDocument.BackgroundLayer.Bitmap.Width, (int)baseDocument.BackgroundLayer.Bitmap.Height);
                    g = Graphics.FromImage(bmp);
                    RectangleF rect = new RectangleF(0, 0, (int)baseDocument.BackgroundLayer.Bitmap.Width, (int)baseDocument.BackgroundLayer.Bitmap.Height);
                    g.DrawImage(selectedShape.Appearance.Image, rect);
                     recEllips = new RectangleF((MouseLoc.X - selectedShape.Location.X - (CurrentPen.Width * zoomFactor / 2)) / (zoomFactor),
                                          (MouseLoc.Y - selectedShape.Location.Y - (CurrentPen.Width * zoomFactor / 2)) / (zoomFactor),
                                          this.CurrentPen.Width, this.CurrentPen.Width);

                     g.DrawEllipse(new Pen(CurrentPen.Color, 1), recEllips);
                     g.FillEllipse(new SolidBrush(CurrentPen.Color), recEllips);
                }
            }

           // bmp = new Bitmap(this.baseDocument.BackgroundLayer.Bitmap, (int)baseDocument.BackgroundLayer.Bitmap.Width, (int)baseDocument.BackgroundLayer.Bitmap.Height);







            if (g != null)
            {
                g.Save();
                selectedShape.Appearance.Image = bmp;
                if (selectedShape is Image)
                {
                    ((Image) selectedShape).Bitmap = bmp;
                }
            }
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


            if (selectedShape != null)
            {
                selectedShape = null;
                bmp = null;
                try
                {
                    g.Dispose();
                }
                catch
                { }
                g = null;
            }

            MousePressed = false;
            this.isAnnotationActive = false ;

            IShape shape = null;// CreateDrawingShape(e.Location);
           
            if (shape == null)
                return;


            //if (this.group == null)//Added by rm
            //{
            //    this.group = new CompositeShape();
            //}

            //this.group.Shapes.Add(shape);//Added by rm
            //this.group.Appearance = shape.Appearance;
       
            //if (!document.Shapes.Contains(group) && group != null)          //Added by rm
            //{
                
            //    document.Shapes.Add(group);               //Added by rm
            //}

            //Points.Clear();
            ////base.MouseMove(document, e);
            //document.DrawingControl.Invalidate();


         
           
        }


        Bitmap bmp;
        Shape selectedShape = null;
        System.Drawing.Graphics g;

        /// <summary>
        /// Mouse move function.
        /// </summary>
        /// <param name="document">Informations transferred from DrawingPanel.</param>
        /// <param name="e">MouseEventArgs.</param>
        public override void MouseMove(IDocument document, MouseEventArgs e)
        {
            MouseLoc = e.Location;

            if (document.DrawingControl is DrawingPanel)
            {
                CurrentPen.Width = (document.DrawingControl as DrawingPanel).CurrentPen.Width;
                CurrentPen.Color = (document.DrawingControl as DrawingPanel).ImageBackColor;
            }

            var zoomFactor = baseDocument.ZoomFactor;//
            if (baseDocument.BackgroundLayer != null)
                zoomFactor =  baseDocument.BackgroundLayer.Dimension.Width / baseDocument.BackgroundLayer.Bitmap.Width ;

            if (!MousePressed)
                return;

            this.isAnnotationActive = true;

            

            if (selectedShape != null && g != null)
            {
                if (selectedShape.Contains(e.Location))
                {

                    if (document.DrawingControl is DrawingPanel)
                        CurrentPen.Color = (document.DrawingControl as DrawingPanel).ImageBackColor;

                    var recEllips = new RectangleF((e.Location.X - selectedShape.Location.X - (CurrentPen.Width*zoomFactor/2)) / (zoomFactor),
                                                   (e.Location.Y - selectedShape.Location.Y - (CurrentPen.Width * zoomFactor / 2)) / (zoomFactor),
                                                   this.CurrentPen.Width, this.CurrentPen.Width);

                    g.DrawEllipse(new Pen(CurrentPen.Color, 1), recEllips);
                    g.FillEllipse(new SolidBrush(CurrentPen.Color), recEllips);

                    g.Save();

                   // document.DrawingControl.Cursor = new Cursor(GetType(), "Eraser.cur");


                }
                else
                {
                   // document.DrawingControl.Cursor = Cursors.No;
                }
                
            }

        }

        #endregion





        private Point MouseLoc = new Point(0, 0);       //Record the mouse position

        public override void Paint(IDocument document, PaintEventArgs e)
        {

            //If mouse is on the panel, draw the mouse

            try
            {
                var zoomFactor = baseDocument.ZoomFactor;//
                if (baseDocument.BackgroundLayer != null)
                    zoomFactor = baseDocument.BackgroundLayer.Bitmap.Width / baseDocument.BackgroundLayer.Dimension.Width;




                //if (IsMouseing)
                {
                    e.Graphics.DrawEllipse(new Pen(Color.Blue, 0.5f), MouseLoc.X - (CurrentPen.Width / (2 * zoomFactor)), MouseLoc.Y - (CurrentPen.Width / (2 * zoomFactor)), CurrentPen.Width / zoomFactor, CurrentPen.Width / zoomFactor);
                }

                Rectangle rr = new Rectangle((int)(MouseLoc.X - (CurrentPen.Width / (2 * zoomFactor))) - 3, (int)(MouseLoc.Y - (CurrentPen.Width / (2 * zoomFactor))) - 3, (int)(CurrentPen.Width / zoomFactor) + 6, (int)(CurrentPen.Width / zoomFactor) + 6);
                document.DrawingControl.Invalidate(rr);
            }
            catch
            {

            }

          




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


        ///// <summary>
        ///// Creates a shape relative to actual points.
        ///// </summary>
        ///// <returns>New Shape.</returns>
        //virtual protected IShape CreateDrawingShape(PointF point)
        //{
        //    if (_points.Count == 0)
        //    {
        //        //Ellipse el = new Ellipse();
        //        //el.Center = point;
        //        //el.Dimension = new SizeF(2, 2);
        //        ////el.Dimension.Width = 2;
        //        ////el.Dimension.Height = 2;
        //        //_shape = new Sbn.AdvancedControls.Imaging.SbnPaint.Ellipse(el);

        //        // return null;
        //        _points.Add(point);
        //        _points.Add(new PointF(point.X + 1, point.Y + 1));
        //    }

        //    _shape = new CustomShape();  //added by rm

        //    _shape.Color = this.Color;
        //    Pen pen = new Pen(this.Color, this.WidthPen);
           
        //    pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        //    pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
        //  //  pen.Color = Color.Red;
        //    _shape.Appearance.BorderColor = Color.Blue;
        //    _shape.Appearance.BorderWidth = this.WidthPen;
        //    _shape.Appearance.ActivePen = pen;
            
        //    if (_points.Count == 2)
        //    {
        //        _shape.Geometric.AddLines(ToPointF(_points));

        //        //                Line ln = new Line(_points[0], _points[1]);
        //        //                ln.Appearance.ActivePen = pen;

        //        //                _shape = new Sbn.AdvancedControls.Imaging.SbnPaint.Line(ln); cmd by ghmhm
        //    }
        //    else
        //        if (_points.Count != 0)
        //        {
        //            _shape.Geometric.AddLines(ToPointF(_points));
        //        }
        //        else
        //        {
        //            return null;
        //        }

        //    IShape shape = _shape.Clone() as IShape;

        //    pen.Dispose();

        //    // shape.Selected = true;  //Commented by rm
        //    shape.Selected = false;   //added by rm
        //    shape.Locked = true;      //added by rm

        //    return shape;
        //}
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
