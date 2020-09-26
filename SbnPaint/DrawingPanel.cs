using System;
using System.Collections.Generic;

using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Security.Permissions;
using Microsoft.Ink;
using Sbn.AdvancedControls.Imaging.SbnPaint.Tools;
using Sbn.FramWork.Drawing.Serialization;


using Sbn.FramWork.Drawing;
using Sbn.FramWork.Drawing.Core.Utilities;
using Cursor = System.Windows.Forms.Cursor;
using Cursors = System.Windows.Forms.Cursors;

namespace Sbn.AdvancedControls.Imaging.SbnPaint
{
    /// <summary>
    /// Panel in which drawing shapes.
    /// </summary>
    public class DrawingPanel : Panel, IDocument
    {

        public InkCollector myInkCollector;

        public float ZoomFactor = 1;


        public event EventHandler<EventArgs> DeleteingShape;


        private Color _imageBackColor = Color.White;
        /// <summary>
        /// رنگ پشت تصویر پس زمینه مورد استفاده در پاکن
        /// </summary>
        public Color ImageBackColor
        {
            get { return _imageBackColor; }
            set { _imageBackColor = value; }
        }

        bool MoveByMouse = true;

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DrawingPanel()
        {

            SetStyle(
                ControlStyles.Selectable |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint, true);



            this.Scroll += new ScrollEventHandler(DrawingPanel_Scroll);

            _shapes.ShapeChanged += new Sbn.FramWork.Drawing.ShapeChangingHandler(_shapes_ShapeChanged);
            _shapes.ShapeMovementOccurred += new MovementHandler(_shapes_ShapeMovementOccurred);
            _shapes.ShapeAppearanceChanged += new AppearanceHandler(_shapes_ShapeAppearanceChanged);

            _gridManager.ResolutionChanged += new GridManager.ResolutionChangedHandler(_gridManager_ResolutionChanged);

            this.BackColor = Color.Khaki;
            this.MouseWheel += new MouseEventHandler(DrawingPanel_MouseWheel);

            ActiveTool = new Pointer();


        }

        void DrawingPanel_MouseWheel(object sender, MouseEventArgs e)
        {

        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            //if (se.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            //{
            //    foreach (Shape sh in _shapes)
            //    {
            //        sh.Transformer.ForceTranslate(se.OldValue - se.NewValue, 0);
            //    }
            //}
            //else
            //{

            //    if (Math.Abs(se.OldValue - se.NewValue) > 10)
            //    {

            //    }
            //    foreach (Shape sh in _shapes)
            //    {
            //        sh.Transformer.ForceTranslate(0, se.OldValue - se.NewValue);
            //    }
            //}

            base.OnScroll(se);
        }

        public void SetScrollValue(ScrollOrientation orientation, int value)
        {
            //if (orientation == ScrollOrientation.HorizontalScroll)
            //{
            //    DrawingPanel_Scroll(this, new ScrollEventArgs(ScrollEventType.First, value, HorizontalScroll.Value, ScrollOrientation.HorizontalScroll));
            //}
            //else
            //{
            //  //  DrawingPanel_Scroll(this, new ScrollEventArgs(ScrollEventType.EndScroll, value, VerticalScroll.Value, ScrollOrientation.VerticalScroll));

            //    foreach (Shape sh in _shapes)
            //    {
            //        sh.Transformer.ForceTranslate(0, value - VerticalScroll.Value);
            //    }
            //}

            //Invalidate();
        }

        void DrawingPanel_Scroll(object sender, ScrollEventArgs e)
        {

            ApplaypActiveCurve();

            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                foreach (Shape sh in _shapes)
                {
                    sh.Transformer.ForceTranslate(e.OldValue - e.NewValue, 0);
                }
            }
            else
            {
                foreach (Shape sh in _shapes)
                {
                    sh.Transformer.ForceTranslate(0, e.OldValue - e.NewValue);

                }
            }

            // Invalidate();
        }

        public void ScrollToShape(Shape shape)
        {
            try
            {
                int deltaY = (int)(((int)(shape.Location.Y - VerticalScroll.Value)) - this.Height + shape.Dimension.Height);

                if (shape.Location.Y <= VerticalScroll.Value + VerticalScroll.LargeChange)
                    deltaY = 0;



                if (deltaY > 0)
                {

                    if (VerticalScroll.Value + deltaY <= VerticalScroll.Maximum - 21)
                        deltaY += 20;

                    this.DrawingPanel_Scroll(null, new ScrollEventArgs(ScrollEventType.ThumbTrack, VerticalScroll.Value, deltaY, ScrollOrientation.VerticalScroll));
                    VerticalScroll.Value += deltaY;
                    VerticalScroll.Value += deltaY;
                }
            }
            catch (Exception)
            {

                FitToWidth();
            }




        }

        #endregion

        #region Properties

        public event EventHandler CurrentPenChange;

        public void OnCurrentPenChange(EventArgs e)
        {
            EventHandler handler = CurrentPenChange;
            if (handler != null) handler(this, e);
        }

        System.Drawing.Pen _CurrentPen = new Pen(Color.Black, 20);

        public System.Drawing.Pen CurrentPen
        {
            get { return _CurrentPen; }
            set
            {


                if (_CurrentPen != value)
                {
                    _CurrentPen = value;
                    OnCurrentPenChange(null);

                }
            }
        }





        bool _ZoomToCurserPosition = true;
        public bool ZoomToCurserPosition
        {
            get
            {
                return _ZoomToCurserPosition;
            }
            set
            {
                _ZoomToCurserPosition = value;
            }
        }

        private System.Drawing.Image _ImageBody;
        public System.Drawing.Image ImageBody
        {
            get
            {
                if (BackgroundLayer == null)
                    return null;
                else
                {
                    _ImageBody = BackgroundLayer.Bitmap;
                    return _ImageBody;
                }

            }
            set
            {


                //if (_ImageBody != null)
                //{
                //    _ImageBody.Dispose();
                //    _ImageBody = null;

                //}

                if (value != null)
                {
                    if (BackgroundLayer == null)
                    {
                        //value.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        var BImage = new BodyBackground(new Bitmap(value), new PointF(0, 0));

                        //BImage.Selected = true;
                        // BImage.Dimension = value.Size;
                        // BImage.Center = new PointF(this.Width / 2, this.Height / 2);
                        BImage.Locked = true;
                        _shapes.Add(BImage);

                    }

                }
                else
                {
                    _shapes.Remove(BackgroundLayer);

                    if (_ImageBody != null)
                    {
                        _ImageBody.Dispose();
                        _ImageBody = null;

                    }
                }

                UpdateDrawPanelSize();

            }
        }


        public BodyBackground BackgroundLayer
        {
            get
            {
                foreach (var shape in Shapes)
                {
                    if (shape is BodyBackground)
                        return shape as BodyBackground;
                }

                return null;
            }
            //set
            //{
            //    this._bodyBackGround = value;
            //}
        }


        public event EventHandler<ToolEventArgs> ActiveToolChaged;

        public void OnActiveToolChaged(ToolEventArgs e)
        {
            EventHandler<ToolEventArgs> handler = ActiveToolChaged;
            if (handler != null) handler(this, e);
        }

        Tool _tool;
        /// <summary>
        /// Gets or sets current tool.
        /// </summary>
        [Browsable(false)]
        public Tool ActiveTool
        {
            get { return _tool; }
            set
            {

                if (myInkCollector != null)
                    myInkCollector.Enabled = false;

                ApplaypActiveCurve();

                if (value != null)
                {
                    _tool = value;

                    if (value is pActiveCurve)
                    {
                        try
                        {
                            if (myInkCollector == null)
                                myInkCollector = new InkCollector(this);

                            if (myInkCollector != null)
                            {
                                (value as pActiveCurve).myInkCollector = myInkCollector;

                                if (CurrentPen != null)
                                {
                                    (value as pActiveCurve).Color = CurrentPen.Color;
                                    (value as pActiveCurve).WidthPen = CurrentPen.Width;
                                }

                                myInkCollector.Enabled = true;
                            }
                        }
                        catch
                        {
                        }
                    }

                    if (value is DrawFreeLine)
                    {
                        Type t = GetType();
                        // Cursor = new Cursor(GetType(), "Pencil.cur");
                    }

                    if (value is Select)
                    {
                        Cursor = Cursors.Default;
                    }
                    //this.Cursor = System.Windows.Forms.Cursors.;

                    if (value is Draft)
                    {
                        // ActiveCursor = Cursors.Help;
                        ;// new Cursor(GetType(), "Eraser.cur");
                        // Cursor = new Cursor(GetType(), "Eraser.cur");

                        ((Draft)value).baseDocument = this;
                        //((Draft)value).CurrentPen = new Pen(CurrentPen;



                    }

                    if (value is DrawShape)
                    {
                        // ActiveCursor = Cursors.Default;
                        //  Cursor = new Cursor(GetType(), "Rectangle.cur");
                    }


                    //_tool = new Sbn.AdvancedControls.Imaging.SbnPaint.Pointer();

                    OnActiveToolChaged(new ToolEventArgs(value));
                }
                else
                {
                    // throw new ApplicationException();


                }
            }
        }


        public bool IsEditBackImage = false;


        float _zoom = 1;
        /// <summary>
        /// Gets or sets zoom percent.
        /// </summary>
        public float Zoom
        {
            get { return _zoom; }

            set
            {

                var VscrollValueTemp = VerticalScroll.Value;
                ApplaypActiveCurve();

                if (value <= 0)
                    throw new ApplicationException();


                _zoom = value;



                if (value != 1)
                    this.ZoomFactor = this.ZoomFactor * value;
                else
                    this.ZoomFactor = 1;

                //if (this.ImageBody != null)
                //{
                //    this.ImageBody = ScaleImage(this.BackgroundImage, (int)(this.BackgroundImage.Width * value), (int)(this.BackgroundImage.Height * value), null);

                //}

                //  this.Refresh();


                PointF center = PointF.Empty;
                //if (BackgroundLayer == null)
                //    return;





                #region
                if (_ZoomToCurserPosition)
                {

                    #region ZoomToCurserPosition
                    // center = new PointF((this.Size.Width) / 2, (this.Size.Height) / 2);
                    center = this.PointToClient(System.Windows.Forms.Control.MousePosition);
                    // this.Parent.Parent.Parent.Parent.Parent.Location

                    #endregion ZoomToCurserPosition
                }
                else
                {


                    var centerx = (this.Size.Width) / 2F;
                    var centery = (this.Size.Height) / 2F;
                    // center = new PointF((this.Size.Width) / 2F, (this.Size.Height) / 2F);

                    //centerx = (BackgroundLayer.Dimension.Width) / 2F;
                    // centery = (BackgroundLayer.Dimension.Height) / 2F;
                    if (BackgroundLayer != null && BackgroundLayer.Dimension.Width > Width)
                    {
                        centerx += HorizontalScroll.Value;
                        // centery += 35;
                    }


                    if (BackgroundLayer != null && BackgroundLayer.Dimension.Height > Height)
                    {
                        centery += VerticalScroll.Value;// +35;
                        // centerx += 35;
                    }

                    center = new PointF(centerx, centery);
                }






                foreach (IShape shape in _shapes)
                {
                    shape.Transformer.Scale(_zoom, _zoom, center);
                }



                #region MoveToCenter

                float offsetX = 0;// -BackgroundLayer.Location.X - BackgroundLayer.Dimension.Width / 2f;
                float offsetY = 0;// - BackgroundLayer.Location.Y - BackgroundLayer.Dimension.Height / 2f; ;


                if (BackgroundLayer != null)
                {
                    //نقطه هدف
                    var EndPoint = new PointF(Width / 2, 0);

                    // نقطه مورد نظر
                    var SelectedPoint = new PointF(BackgroundLayer.Location.X + BackgroundLayer.Dimension.Width / 2f,
                        //  -VscrollValueTemp);
                                                   BackgroundLayer.Location.Y);


                    offsetX = EndPoint.X - SelectedPoint.X;
                    offsetY = EndPoint.Y - SelectedPoint.Y;

                    if (VerticalScroll.Visible)
                    {
                        offsetY -= VerticalScroll.Value;
                    }
                }

                // انتقال نقطه مورد نظر به نقطه هدف
                bool historyIsActive = History<ShapeCollection>.IsActive;
                History<ShapeCollection>.IsActive = false;
                foreach (IShape shape in _shapes)
                {
                    shape.Transformer.ForceTranslate(offsetX, offsetY);

                    //if (shape is CompositeShape)
                    //{
                    //    foreach (var sh in ((CompositeShape)shape).Shapes)
                    //    {
                    //        sh.Transformer.ForceTranslate(offsetX, offsetY);
                    //    }
                    //}
                }
                History<ShapeCollection>.IsActive = historyIsActive;

                #endregion MoveToCenter



                #endregion
                UpdateDrawPanelSize();

                // SetScrollValue(ScrollOrientation.VerticalScroll, VscrollValueTemp);

            }
        }

        bool _enableWheelZoom = true;
        /// <summary>
        /// Gets or sets if the wheel changes the zoom factor.
        /// </summary>
        public bool EnableWheelZoom
        {
            get { return _enableWheelZoom; }
            set { _enableWheelZoom = value; }
        }

        #endregion

        #region IDocument Interface

        /// <summary>
        /// Gets the DrawingControl (this).
        /// </summary>
        [Browsable(false)]
        public Control DrawingControl
        {
            get { return this; }
        }

        ShapeCollection _shapes = new ShapeCollection();
        /// <summary>
        /// Gets or sets the shapes to draw.
        /// </summary>
        [Browsable(false)]
        public ShapeCollection Shapes
        {
            get { return _shapes; }
            set { _shapes = value; }
        }

        /// <summary>
        /// Gets or sets the active cursor.
        /// </summary>
        [Browsable(false)]
        public Cursor ActiveCursor
        {
            get { return this.Cursor; }
            set { this.Cursor = value; }
        }

        GridManager _gridManager = new GridManager();
        /// <summary>
        /// Gets (set protected) GridManager to handle grid properties.
        /// </summary>
        [System.ComponentModel.TypeConverter(typeof(GridManagerTypeConverter))]
        public GridManager GridManager
        {
            get { return _gridManager; }
            protected set { _gridManager = value; }
        }

        #endregion

        #region Public Functions


        public void ClearImage()
        {
            //if (ImageBody != null)
            //{
            //    try
            //    {
            //        ImageBody.Dispose();
            //        ImageBody = null;

            //    }
            //    catch (Exception)
            //    {


            //    }
            //}

            History<ShapeCollection>.Delete();//.Memorize(_shapes);

            for (int i = 0; i < _shapes.Count; i++)
            {
                // if (_shapes[i].Selected)
                {
                    _shapes.Remove(_shapes[i]);
                    i = -1;
                }
            }

            ImageBody = null;


            // Zoom = 1;

            if (ActiveTool is DrawCurveLine)
            {
                (ActiveTool as DrawCurveLine).Applay();
            }

            Invalidate();


        }


        public void UpdateDrawPanelSize()
        {

            var xLeft = 0F;
            var xRight = 0F;

            var yTop = 0F;
            var yBottum = 0F;

            foreach (Shape sh in this._shapes)
            {

                if (sh.Location.X + sh.Dimension.Width > xRight)
                {
                    xRight = sh.Location.X + sh.Dimension.Width;
                }

                if (sh.Location.X < 0 && sh.Location.X < xLeft)
                {
                    xLeft = sh.Location.X;
                }

                if (sh.Location.Y + sh.Dimension.Height > yBottum)
                {
                    yBottum = sh.Location.Y + sh.Dimension.Height;
                }

                if (sh.Location.Y < 0 && sh.Location.Y < yTop)
                {
                    yTop = sh.Location.Y;
                }
                //if (sh.Location.Y > 0 && BackgroundLayer != null && BackgroundLayer.Dimension.Height > this.Height)
                //{
                //   // yTop = sh.Location.Y;
                //}

            }

            //
            //if (BackgroundLayer != null)
            //{
            //    this.AutoScrollMinSize = new Size((int)BackgroundLayer.Dimension.Width + 5, (int)BackgroundLayer.Dimension.Height + 5);
            //  //  yTop = -(int)BackgroundLayer.Center.Y * 2;
            //}
            //else
            this.AutoScrollMinSize = new Size((int)(xRight - xLeft), (int)(yBottum - yTop));
            try
            {

                if (Math.Abs(HorizontalScroll.Value - Math.Abs((int)xLeft)) > 2)
                {


                    this.HorizontalScroll.Value = Math.Abs((int)xLeft);
                }

                if (Math.Abs(VerticalScroll.Value - Math.Abs((int)yTop)) > 2)
                {
                    this.VerticalScroll.Value = Math.Abs((int)yTop);
                }


            }
            catch
            {

            }

            // this.AutoScrollMinSize = new Size((int)(x2 - x), (int)(y2 - y));
            //try
            //{
            //    this.HorizontalScroll.Value = Math.Abs((int)x);
            //    //int ii = Math.Abs((int)((this.AutoScrollMinSize.Height - (int)(this.Height))/2));
            //    //this.VerticalScroll.Value = ii;

            //    this.VerticalScroll.Value = Math.Abs((int)y);
            //}
            //catch
            //{

            //}

            Invalidate();

        }

        protected override void OnLocationChanged(EventArgs e)
        {

            base.OnLocationChanged(e);
        }


        /// <summary>
        /// Undo action.
        /// </summary>
        virtual public void Undo()
        {

            if (History<ShapeCollection>.IsAtStart())
                return;



            _shapes.Clear();

            _shapes.AddRange(History<ShapeCollection>.Undo());




            Invalidate();
        }

        /// <summary>
        /// Redo action.
        /// </summary>
        virtual public void Redo()
        {
            if (History<ShapeCollection>.IsAtEnd())
                return;

            _shapes.Clear();
            _shapes.AddRange(History<ShapeCollection>.Redo());
            Invalidate();
        }

        /// <summary>
        /// Cut action.
        /// </summary>
        virtual public void Cut()
        {
            History<ShapeCollection>.Memorize(_shapes);
            Clipboard<ShapeCollection>.Clip = Sbn.FramWork.Drawing.Select.GetSelectedShapes(_shapes);

            Delete();
            Invalidate();
        }

        /// <summary>
        /// Copy action.
        /// </summary>
        virtual public void Copy()
        {
            Clipboard<ShapeCollection>.Clip = Sbn.FramWork.Drawing.Select.GetSelectedShapes(_shapes);
        }

        /// <summary>
        /// Paste action.
        /// </summary>
        virtual public void Paste()
        {
            try
            {
                History<ShapeCollection>.Memorize(_shapes);

                foreach (IShape shape in Clipboard<ShapeCollection>.Clip)
                {
                    shape.Location = new PointF(shape.Location.X + 10, shape.Location.Y + 10);
                    _shapes.Add(shape.Clone() as IShape);
                }

                Invalidate();
            }
            catch
            {


            }

        }


        /// <summary>
        /// این متد موقعیت یک نقطه را متناسب با بزرگنمایی و تصویر پس زمینه بر می گرداند
        /// </summary>
        /// <param name="pointTemp"></param>
        /// <returns></returns>
        public PointF GetActualPoint(PointF pointTemp)
        {
            PointF point = new PointF(pointTemp.X, pointTemp.Y);
            //float tt = 1 / ZoomFactor;
            point.X = (int)(point.X * ZoomFactor);
            point.Y = (int)(point.Y * ZoomFactor);
            if (this.BackgroundLayer != null)
            {
                point.X += BackgroundLayer.Location.X;
                point.Y += BackgroundLayer.Location.Y;
            }

            return point;
        }

        /// <summary>
        /// این متد اندازه را متناسب با بزرگنمایی بر می گرداند
        /// </summary>
        /// <param name="pointTemp"></param>
        /// <returns></returns>
        public SizeF GetActualSize(SizeF SizeTemp)
        {
            SizeF point = new SizeF(SizeTemp.Width, SizeTemp.Height);
            point.Width = point.Width * ZoomFactor;
            point.Height = point.Height * ZoomFactor;
            return point;
        }


        public Shape CreateShape(System.Drawing.Image img)
        {
            try
            {

                var Rect = new RectangleF(new PointF(0, 0), img.Size);

                float tt = 1 / ZoomFactor;

                var imgTemp = new Sbn.AdvancedControls.Imaging.SbnPaint.Image(new Bitmap(img), Rect);

                return imgTemp;
            }
            catch (Exception)
            {


            }

            return null;
        }

        //public Shape AddImage(System.Drawing.Image img, PointF location)
        //{
        //    try
        //    {

        //        location = GetActualPoint(location);

        //        var Rect = new RectangleF(location, img.Size);

        //        //Rect.Width = (int)(Rect.Width * ZoomFactor);
        //        //Rect.Height = (int)(Rect.Height * ZoomFactor);

        //        var imgTemp = CreateShape(img);// new Sbn.AdvancedControls.Imaging.SbnPaint.Image((Bitmap)img, Rect);
        //        imgTemp.Visible = true;
        //        imgTemp.Selected = true;
        //        imgTemp.Location = GetActualPoint(location);



        //        this.Shapes.Add(imgTemp);



        //        return imgTemp;
        //    }
        //    catch (Exception)
        //    {


        //    }

        //    Refresh();


        //    return null;

        //}


        public Shape CreateShape(string text, Font font)
        {
            StringFormat m_Formatdd = new StringFormat();
            m_Formatdd.Alignment = StringAlignment.Near;
            m_Formatdd.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.DirectionRightToLeft;
            m_Formatdd.LineAlignment = StringAlignment.Near;

            SizeF siz = new SizeF();
            try
            {
                using (var gp = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    gp.AddString(text, font.FontFamily, (int)font.Style, font.Size, new Point(0, 0), m_Formatdd);
                    siz = gp.GetBounds().Size;
                    siz = new SizeF(siz.Width, siz.Height);
                }
            }
            catch (Exception)
            {


            }


            Text shape = new Text();
            shape.Visible = true;
            shape.Selected = true;

            shape.Dimension = siz;
            //  shape.Location = location;// new PointF(location.X, location.Y);

            shape.Font = font;
            shape.StringFormat = m_Formatdd;
            shape.DisplayedText = text;


            return shape;
        }

        //public Shape AddText(string text, PointF location, Font font)
        //{
        //    StringFormat m_Formatdd = new StringFormat();
        //    m_Formatdd.Alignment = StringAlignment.Near;
        //    m_Formatdd.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.DirectionRightToLeft;
        //    m_Formatdd.LineAlignment = StringAlignment.Near;

        //    Size porposSize = new Size(int.MaxValue, int.MaxValue);
        //    SizeF siz = TextRenderer.MeasureText(text, font, porposSize, TextFormatFlags.NoClipping);

        //    //float tt = 1 / ZoomFactor;
        //    //if (this.BackgroundLayer != null)
        //    //{
        //    //    location.X = (int)(this.BackgroundLayer.Location.X + (location.X / tt));
        //    //    location.Y = (int)(this.BackgroundLayer.Location.Y + (location.Y / tt));
        //    //}
        //    //else
        //    //{
        //    //    location.X = (int)(location.X / tt);
        //    //    location.Y = (int)(location.Y / tt);
        //    //}

        //    location = GetActualPoint(location);


        //    try
        //    {
        //        using (var gp = new System.Drawing.Drawing2D.GraphicsPath())
        //        {
        //            gp.AddString(text, font.FontFamily, (int)font.Style, font.Size, new Point(0, 0), m_Formatdd);
        //            siz = gp.GetBounds().Size;
        //            siz = new SizeF(siz.Width , siz.Height);
        //        }
        //    }
        //    catch (Exception)
        //    {


        //    }


        //    Text shape = new Text();
        //    shape.Visible = true;
        //    shape.Selected = true;

        //    shape.Dimension = siz;
        //    shape.Location = location;// new PointF(location.X, location.Y);

        //    shape.Font = font;
        //    shape.StringFormat = m_Formatdd;
        //    shape.DisplayedText = text;

        //    var shape1 = CreateShape(text, font);

        //    Shapes.Add(shape1);
        //    Refresh();

        //    return shape;
        //}

        /// <summary>
        /// Delete action.
        /// </summary>
        virtual public void Delete()
        {
            ApplaypActiveCurve();

            History<ShapeCollection>.Memorize(_shapes);

            for (int i = 0; i < _shapes.Count; i++)
            {
                if (_shapes[i].Selected)
                {
                    if (DeleteingShape != null)
                    {
                        DeleteingShape(_shapes[i], null);
                    }
                    _shapes.Remove(_shapes[i]);


                    i = -1;
                }
            }
            Invalidate();
        }

        #endregion

        #region Protected Functions

        protected override void OnInvalidated(InvalidateEventArgs e)
        {

            base.OnInvalidated(e);
            //  UpdateDrawPanelSize();
            //  this.Shapes.SendToBack(this.BackgroundLayer);
            //  this.BackgroundLayer.Locked = true;

            //this.BackgroundLayer.Appearance.s
        }
        protected override void OnResize(EventArgs eventargs)
        {
            ApplaypActiveCurve();
            base.OnResize(eventargs);
            UpdateDrawPanelSize();


        }

        /// <summary>
        /// Mouse down.
        /// </summary>
        /// <param name="e">MouseEventArgs.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {

            Focus();

            lastMouse = new Point(e.X, e.Y);

            _tool.MouseDown(this, e);

            if (_tool is Sbn.AdvancedControls.Imaging.SbnPaint.Draft && e.Button == System.Windows.Forms.MouseButtons.Left)
                IsEditBackImage = true;

            base.OnMouseDown(e);
            //if (!this.ActiveTool.isAnnotationActive) 
            //    Invalidate();


        }

        /// <summary>
        /// Mouse up.
        /// </summary>
        /// <param name="e">MouseEventArgs.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {


            _tool.MouseUp(this, e);

            base.OnMouseUp(e);
            Invalidate();

            if (this.ActiveTool is DrawShape)
            {
                this.ActiveTool = new Pointer();
            }





        }


        Point oldpos = new Point(0, 0);
        System.Drawing.Point lastMouse;
        /// <summary>
        /// Mouse move.
        /// </summary>
        /// <param name="e">MouseEventArgs.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {



            if (this.MoveByMouse && e.Button == MouseButtons.Left)
            {

                //if (oldpos.X != 0)
                //    Invalidate(new Rectangle(oldpos.X - 1, oldpos.Y - 1, Math.Abs(oldpos.X - e.X - 2), Math.Abs(oldpos.Y - e.Y - 2)));
                //else
                //    Invalidate(new Rectangle(e.X - 10, e.Y - 10, 20, 20));

                if (ActiveTool is Hand)
                {


                }

                // اين خطوط به منظور جابجايي اشيا ميباشد كه به دليل اختلال در اسكرول كردن حذف شده اند commented by rm

                //if (vChang < this.VerticalScroll.Maximum && vChang > this.VerticalScroll.Minimum)
                //    this.HorizontalScroll.Value += lastMouse.X - e.X;

                //if (hChang < this.HorizontalScroll.Maximum && hChang > this.HorizontalScroll.Minimum)
                //    this.VerticalScroll.Value += lastMouse.Y - e.Y;

                // Rectangle rc = new Rectangle(e.X - 30 , e.Y - 30 , 60 , 60);

                // this.Painting(Shapes , new PaintEventArgs(;
                //     System.Drawing.Graphics g =  this.CreateGraphics();

                //sh.Paint(this, new PaintEventArgs(this.CreateGraphics(), this.ClientRectangle));


                //                this.CreateGraphics().DrawCurve (new Pen(this.ForeColor, 4)  , );


                // this.Invalidate(false);


                //                        eg.Graphics. (new Pen(Color.Black), ((Point[])sh.Geometric.PathData )  );
                // sh.Paint(this,eg);



                // }

                //    ((Shape)this.ActiveTool).Paint(this, eg);


            }



            oldpos = new Point(e.X, e.Y);

            _tool.MouseMove(this, e);


            if (_tool is DrawShape && _tool.Ghost != null)
            {
                //if ((_tool.Ghost.Shape is RectangleBody) || (_tool.Ghost.Shape is Ellipse) || (_tool.Ghost.Shape is Text))
                //    ActiveCursor = Cursors.Cross;
            }

            if (_tool is Pointer)
            {
                // ActiveCursor = Cursors.Default;
            }

            if (_tool is Draft)
            {

                // Cursor = new Cursor(GetType(), "Eraser.cur");
                //  ActiveCursor = Cursors.Help;
            }

            // base.OnMouseMove(e);
            //  lastMouse = e.Location;
        }

        public void FitToWidth()
        {
            if (ImageBody == null)
                return;


            try
            {
                var i = Math.Abs(Width - BackgroundLayer.Dimension.Width);

                if ((i < 1))
                    return;

                float width = BackgroundLayer.Dimension.Width;
                float zoomTemp = ((float)Width) / width;

                if (VerticalScroll.Visible)
                {
                    zoomTemp = ((float)Width - 35) / width;
                }


                ZoomFactor = 1;

                Zoom = zoomTemp;


                //this.VerticalScroll.Value = this.VerticalScroll.SmallChange;
                //Invalidate();
            }
            catch (Exception)
            {


            }






        }



        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.OemCloseBrackets)
            {
                try
                {
                    this.CurrentPen = new Pen(CurrentPen.Color, CurrentPen.Width + 20);
                }
                catch
                { }
            }

            if (e.KeyCode == Keys.OemOpenBrackets)
            {
                try
                {

                    CurrentPen = new Pen(CurrentPen.Color, CurrentPen.Width - 20);
                    if (this.CurrentPen.Width < 0)
                        this.CurrentPen.Width = 1;

                }
                catch
                { }
            }
            base.OnKeyDown(e);
        }


        /// <summary>
        /// Mouse wheel.
        /// </summary>
        /// <param name="e">MouseEventArgs.</param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            ApplaypActiveCurve();

            if (!_enableWheelZoom)
                return;

            if (Control.ModifierKeys == Keys.Control)
            {


                if (Math.Sign(e.Delta) == -1)
                    Zoom = 0.9f;
                else if (Math.Sign(e.Delta) == 1)
                    Zoom = 1.1f;



                //  base.OnMouseWheel(e);
            }
            else
            {

                int hChang = -e.Delta;
                int vChang = -e.Delta;// lastMouse.Y - e.Y;
                if (Control.ModifierKeys == Keys.Alt)
                {
                    vChang = 0;

                    if (!HorizontalScroll.Visible)
                        hChang = 0;
                    else
                    {
                        if (BackgroundLayer != null)
                        {

                            if (BackgroundLayer.Location.X - hChang > 0)
                            {
                                hChang = HorizontalScroll.Minimum - HorizontalScroll.Value + HorizontalScroll.LargeChange;
                                // hChang = 0;
                            }

                            //if ((BackgroundLayer.Dimension.Height + BackgroundLayer.Location.Y < this.Height - 6))
                            //    vChang = 0;

                            if (HorizontalScroll.Value + HorizontalScroll.LargeChange + hChang > HorizontalScroll.Maximum)
                            {
                                hChang = HorizontalScroll.Maximum - HorizontalScroll.Value - HorizontalScroll.LargeChange;
                                // hChang = 0;
                            }

                        }
                    }
                }
                else
                {
                    hChang = 0;
                    if (!VerticalScroll.Visible)
                        vChang = 0;
                    else
                    {
                        if (BackgroundLayer != null)
                        {

                            if (BackgroundLayer.Location.Y - vChang > 0)
                            {
                                vChang = VerticalScroll.Minimum - VerticalScroll.Value;
                                // vChang = 0;
                            }

                            //if ((BackgroundLayer.Dimension.Height + BackgroundLayer.Location.Y < this.Height - 6))
                            //    vChang = 0;

                            if (VerticalScroll.Value + VerticalScroll.LargeChange + vChang > VerticalScroll.Maximum)
                            {

                                vChang = VerticalScroll.Maximum - VerticalScroll.Value - VerticalScroll.LargeChange;
                                //vChang = 0;

                            }

                        }
                    }
                }








                bool historyIsActive = History<ShapeCollection>.IsActive;
                History<ShapeCollection>.IsActive = false;
                foreach (IShape shape in _shapes)
                {
                    shape.Transformer.ForceTranslate(-hChang, -vChang);
                }
                History<ShapeCollection>.IsActive = historyIsActive;

                try
                {
                    UpdateDrawPanelSize();
                    VerticalScroll.Value += vChang;
                }
                catch (Exception)
                {

                    // throw;
                }


                //lastMouse = new Point(e.X, e.Y);



                //try
                //{
                //    if (e.Delta < 0)
                //    {
                //        this.VerticalScroll.Value += 10;
                //    }
                //    else
                //    {
                //        this.VerticalScroll.Value -= 10;
                //    }
                ////    this.Invalidate();
                //}
                //catch
                //{
                //    if (e.Delta < 0)
                //        this.VerticalScroll.Value = 0;



                //}
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Sbn.FramWork.Drawing.Select.LastSelectedShape == null)
                return base.ProcessDialogKey(keyData);

            ShapeCollection selectedShapes = new ShapeCollection();

            Keys key = keyData & Keys.KeyCode;

            if (System.Windows.Forms.Control.ModifierKeys == Keys.Control)
                selectedShapes.AddRange(Sbn.FramWork.Drawing.Select.GetSelectedShapes(_shapes));
            else
                selectedShapes.Add(Sbn.FramWork.Drawing.Select.LastSelectedShape);

            float offsetX = _gridManager.Resolution.Width;
            if (_gridManager.Resolution.Width == 0)
                offsetX = 1;

            float offsetY = _gridManager.Resolution.Height;
            if (_gridManager.Resolution.Height == 0)
                offsetY = 1;

            switch (key)
            {
                case Keys.Up:
                    foreach (IShape shape in selectedShapes)
                        shape.Transformer.Translate(0, -offsetY);

                    Invalidate();
                    break;

                case Keys.Down:

                    foreach (IShape shape in selectedShapes)
                        shape.Transformer.Translate(0, offsetY);

                    Invalidate();
                    break;

                case Keys.Left:
                    foreach (IShape shape in selectedShapes)
                        shape.Transformer.Translate(-offsetX, 0);

                    Invalidate();
                    break;

                case Keys.Right:
                    foreach (IShape shape in selectedShapes)
                        shape.Transformer.Translate(offsetX, 0);

                    Invalidate();
                    break;
            }

            return base.ProcessDialogKey(keyData);
        }

        PaintEventArgs eg = null;
        IDocument Idoc = null;
        /// <summary>
        /// Paint.
        /// </summary>
        /// <param name="e">PaintEventArgs.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            eg = e;

            //  base.OnPaint(e);
            // this.BackgroundImage

            e.Graphics.Clear(Color.Khaki); //cmd by ghmhm
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            Painting(_shapes, e);

            _tool.Paint(this, e);

            // this.Shapes.SendToBack(this.BackgroundLayer);

        }


        /// <summary>
        /// Draws shapes and other.
        /// </summary>
        /// <param name="shapes">Shapes to draw.</param>
        /// <param name="e">PaintEventArgs.</param>
        protected void Painting(ShapeCollection shapes, PaintEventArgs e)
        {


            //foreach (IShape shape in shapes)
            //{

            //    shape.Paint(this, e);

            //}


            foreach (IShape shape in shapes)
            {

                if (this.ActiveTool.isAnnotationActive)
                {
                    //if ((shape is BodyBackground))
                    //{
                    //    // this.BackgroundImage = shape.Appearance.Image;
                    //}
                    //else
                    {
                        shape.Paint(this, e);
                    }
                }
                else
                {
                    shape.Paint(this, e);
                }
            }

        }

        #endregion

        #region Private Functions

        void _shapes_ShapeChanged(IShape shape, object changing)
        {
            History<ShapeCollection>.Memorize(_shapes);

            RectangleF rectangle = new RectangleF(
                new PointF(
                shape.Location.X - shape.Appearance.GrabberDimension,
                shape.Location.Y - shape.Appearance.GrabberDimension),
                new SizeF(
                shape.Dimension.Width + shape.Appearance.GrabberDimension,
                shape.Dimension.Height + shape.Appearance.GrabberDimension));

            Invalidate(System.Drawing.Rectangle.Round(rectangle));
        }

        void _shapes_ShapeMovementOccurred(Transformer transformer)
        {
            return;
            History<ShapeCollection>.Memorize(_shapes);

            RectangleF rectangle = new RectangleF(
                new PointF(
                transformer.Shape.Location.X - transformer.Shape.Appearance.GrabberDimension,
                transformer.Shape.Location.Y - transformer.Shape.Appearance.GrabberDimension),
                new SizeF(
                transformer.Shape.Dimension.Width + transformer.Shape.Appearance.GrabberDimension,
                transformer.Shape.Dimension.Height + transformer.Shape.Appearance.GrabberDimension));

            Invalidate(System.Drawing.Rectangle.Round(rectangle));
        }

        void _shapes_ShapeAppearanceChanged(Sbn.FramWork.Drawing.Appearance appearance)
        {
            History<ShapeCollection>.Memorize(_shapes);

            RectangleF rectangle = new RectangleF(
                new PointF(
                appearance.Shape.Location.X - appearance.Shape.Appearance.GrabberDimension,
                appearance.Shape.Location.Y - appearance.Shape.Appearance.GrabberDimension),
                new SizeF(
                appearance.Shape.Dimension.Width + appearance.Shape.Appearance.GrabberDimension,
                appearance.Shape.Dimension.Height + appearance.Shape.Appearance.GrabberDimension));

            Invalidate(System.Drawing.Rectangle.Round(rectangle));
        }

        void _gridManager_ResolutionChanged(GridManager sender, SizeF oldValue, SizeF newValue)
        {
            GridManager.SnapToGrid(_shapes);
            Invalidate();
        }

        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DrawingPanel
            // 
            //            this.BackgroundImage = global::Sbn.AdvancedControls.Imaging.SbnPaint.Resource.Blue_hills;
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DrawingPanel_Scroll);
            this.ResumeLayout(false);

        }


        protected override void OnBackgroundImageChanged(EventArgs e)
        {

            History<ShapeCollection>.Memorize(_shapes);





            //    this.BackgroundLayer.Dimension = new SizeF(this.BackgroundImage.Width, this.BackgroundImage.Height);
            //   _shapes.Add(this.BackgroundLayer);
            base.OnBackgroundImageChanged(e);
            //this.BackgroundLayer.BodyBackImage = this.BackgroundImage;
            this.Invalidate(true);
        }




        public System.Drawing.Image GetFlattedImage(ShapeCollection AllShape)
        {


            ApplaypActiveCurve();

            BodyBackground bImage = null;


            if (AllShape == null || AllShape.Count == 0)
                return null;


            foreach (Shape film in AllShape)
            {
                if (film is BodyBackground)
                {
                    bImage = film as BodyBackground;
                    break;
                }
            }

            Bitmap bmResult = null;

            Rectangle cropRectangle = new Rectangle();


            if (bImage != null)
            {
                bmResult = new System.Drawing.Bitmap(bImage.Bitmap.Width, bImage.Bitmap.Height);


            }
            else
            {


                var xLeft = _shapes[0].Location.X;
                var xRight = 0F;

                var yTop = _shapes[0].Location.Y;
                var yBottum = 0F;

                foreach (Shape sh in this._shapes)
                {

                    if (sh.Location.X + sh.Dimension.Width > xRight)
                    {
                        xRight = sh.Location.X + sh.Dimension.Width;
                    }

                    if (sh.Location.X < xLeft)
                    {
                        xLeft = sh.Location.X;
                    }

                    //if (sh.Location.X > 0 && sh.Location.X > xLeft)
                    //{
                    //    xLeft = sh.Location.X;
                    //}

                    if (sh.Location.Y + sh.Dimension.Height > yBottum)
                    {
                        yBottum = sh.Location.Y + sh.Dimension.Height;
                    }

                    if (sh.Location.Y < yTop)
                    {

                        yTop = sh.Location.Y;
                    }

                    //if (sh.Location.Y > 0 && sh.Location.Y > yTop)
                    //{

                    //    yTop = sh.Location.Y;
                    //}

                    //if (sh.Location.Y > 0 && BackgroundLayer != null && BackgroundLayer.Dimension.Height > this.Height)
                    //{
                    //   // yTop = sh.Location.Y;
                    //}

                }

                cropRectangle = new Rectangle((int)xLeft, (int)yTop, (int)(xRight - xLeft) + 2, (int)(yBottum - yTop) + 2);

                // bmResult = new Bitmap((int)(xRight - xLeft) + 2, (int)(yBottum - yTop) + 2);

                bmResult = new Bitmap(Width, Height);
            }
            using (Graphics g = Graphics.FromImage(bmResult))
            {
                float zoomFactorTemp = 1;
                if (bImage != null)
                {

                    // bImage.Appearance.Image.Save(@"D:\5858.Tiff");
                    //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                    //g.PageUnit = GraphicsUnit.Display;
                    //g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    g.DrawImage(bImage.Appearance.Image, new Rectangle(0, 0, bImage.Bitmap.Width, bImage.Bitmap.Height));//, 0, 0, bImage.Bitmap.Width, bImage.Bitmap.Height, GraphicsUnit.Point);

                    zoomFactorTemp = bImage.Dimension.Width / bImage.Bitmap.Width;
                    // bmResult.MakeTransparent(BackColor);
                    // bmResult.Save(@"D:\Result.Tiff");
                }



                foreach (Shape film in AllShape)
                {
                    if (!(film is SbnPaint.BodyBackground))// && !(film is SbnPaint.Image))
                    {

                        try
                        {

                            if (bImage != null)
                            {
                                var tt = (1 / zoomFactorTemp);
                                int x = (int)(film.Location.X - bImage.Location.X);
                                int y = (int)(film.Location.Y - bImage.Location.Y);
                                var LocationX = (long)(x * tt);
                                var LocationY = (long)(y * tt);


                                if (film.Appearance.Shape == null)
                                {
                                    film.Appearance.Shape = film;
                                }
                                var TEmpimg = film.Appearance.GetImage(1 / zoomFactorTemp);

                                GraphicsUnit gu = GraphicsUnit.Pixel;
                                var rec = TEmpimg.GetBounds(ref gu);

                                //try
                                //{
                                //    TEmpimg.Save(@"D:\2.Png");
                                //}
                                //catch (Exception)
                                //{
                                //}

                                g.DrawImage(TEmpimg, new Rectangle((int)(LocationX), (int)(LocationY), (int)(TEmpimg.Width), (int)(TEmpimg.Height)));//, TEmpimg.GetBounds(ref gu), GraphicsUnit.Pixel);
                            }
                            else
                            {
                                var tt = (1 / zoomFactorTemp);
                                int x = (int)(film.Location.X);
                                int y = (int)(film.Location.Y);
                                var LocationX = (long)(x * tt);
                                var LocationY = (long)(y * tt);

                                if (film.Appearance.Shape == null)
                                {
                                    film.Appearance.Shape = film;
                                }

                                var TEmpimg = film.Appearance.GetImage(1 / zoomFactorTemp);
                                GraphicsUnit gu = GraphicsUnit.Pixel;

                                g.DrawImage(TEmpimg, new Rectangle((int)(LocationX), (int)(LocationY), (int)(TEmpimg.Width), (int)(TEmpimg.Height)));//, TEmpimg.GetBounds(ref gu), GraphicsUnit.Pixel);
                            }


                        }
                        catch (Exception)
                        {


                        }

                    }
                    else
                    {


                    }

                }


                g.Save();
                // bmResult.Save(@"D:\Result1.Tiff");
                g.Dispose();
                // bmResult.Save(@"D:\Result2.Tiff");
            }

            //  bmResult.Save(@"D:\Result3.Tiff");

            if (cropRectangle.Width > 1)
            {

                var imgResult = new Bitmap(cropRectangle.Width, cropRectangle.Height);
                using (Graphics g = Graphics.FromImage(imgResult))
                {
                    g.DrawImage(bmResult, new Rectangle(Point.Empty, cropRectangle.Size), cropRectangle, GraphicsUnit.Pixel);
                    g.Save();
                    g.Dispose();
                }

                bmResult = imgResult;
            }



            return bmResult;
        }

        public IShape ApplaypActiveCurve()
        {

            try
            {

                if (myInkCollector == null || myInkCollector.Ink.Strokes.Count == 0)
                    return null;


                myInkCollector.Enabled = false;
                System.IO.MemoryStream annms;
                System.Drawing.Image AnnImg = null;
                try
                {

                    //save New Annotaion
                    //var dd = myInkCollector.Ink.ClipboardCopy(InkClipboardFormats.Bitmap, InkClipboardModes.Default);
                    //var ig = Clipboard.GetImage();
                    //ig.Save("D:\\6.Png");


                    byte[] b = myInkCollector.Ink.Save(PersistenceFormat.Gif);
                    annms = new System.IO.MemoryStream(b);
                    AnnImg = System.Drawing.Image.FromStream(annms);

                    //try
                    //{
                    //    AnnImg.Save("D:\\hhhh.gif", System.Drawing.Imaging.ImageFormat.Gif);
                    //}
                    //catch
                    //{

                    //}
                    annms.Close();

                    Rectangle Rect = myInkCollector.Ink.GetBoundingBox();

                    myInkCollector.Ink.Strokes[0].DrawingAttributes.Color = Color.Blue;

                    System.Drawing.Point pointTopLeft = new System.Drawing.Point(Rect.Left, Rect.Top);
                    System.Drawing.Point pointBottomRight = new System.Drawing.Point(Rect.Left, Rect.Top);
                    pointBottomRight.Offset(Rect.Width, Rect.Height);
                    myInkCollector.Renderer.InkSpaceToPixel(this.CreateGraphics(),
                ref pointTopLeft);
                    myInkCollector.Renderer.InkSpaceToPixel(this.CreateGraphics(),
                ref pointBottomRight);


                    Rectangle convertedRect = new Rectangle(pointTopLeft.X,
                pointTopLeft.Y, pointBottomRight.X - pointTopLeft.X,
                pointBottomRight.Y - pointTopLeft.Y);


                    var pActiveSh1 = new Sbn.AdvancedControls.Imaging.SbnPaint.Image(new Bitmap(AnnImg), convertedRect);
                    myInkCollector.Enabled = false;
                    pActiveSh1.Selected = true;
                    Shapes.Add(pActiveSh1);
                    Strokes strokesToDelete = myInkCollector.Ink.Strokes;
                    myInkCollector.Ink.DeleteStrokes(strokesToDelete);
                    ActiveTool = new Pointer();
                    // Check to ensure that the ink collector isn't currently
                    // in the middle of a stroke before clearing the ink.
                    // Deleting a stroke that is currently being collected
                    // will result in an error condition.
                    return pActiveSh1;

                }
                catch
                {

                }

            }

            catch
            { }

            return null;

        }


    }
}
