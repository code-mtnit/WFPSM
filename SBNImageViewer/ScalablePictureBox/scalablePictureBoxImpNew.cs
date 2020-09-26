using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing.Imaging;

namespace Sbn.AdvancedControls.Imaging.ImageViewer.ScalablePictureBox
{
    public partial class scalablePictureBoxImpNew : UserControl
    {
        private System.Drawing.Point lastMouse = new Point(0, 0);
        bool drag = false;
        private bool isDragging = false;

        /// <summary>
        /// delegate of PictureBox painted event handler
        /// </summary>
        /// <param name="visibleAreaRect">currently visible area of picture</param>
        /// <param name="pictureBoxRect">picture box area</param>
        public delegate void PictureBoxPaintedEventHandler(Rectangle visibleAreaRect, Rectangle pictureBoxRect);

        /// <summary>
        /// PictureBox painted event
        /// </summary>
        public event PictureBoxPaintedEventHandler PictureBoxPaintedEvent;

        /// <summary>
        /// delegate of zoom rate changed handler
        /// </summary>
        /// <param name="zoomRate">current zoom rate</param>
        /// <param name="isFullPictureShown">true if the whole picture is shown</param>
        public delegate void ZoomRateChangedEventHandler(double zoomRate, bool isFullPictureShown);

        /// <summary>
        /// zoom rate changed event
        /// </summary>
        public event ZoomRateChangedEventHandler ZoomRateChangedEvent;


        public scalablePictureBoxImpNew()
        {
            InitializeComponent();


           

            BackColor = SystemColors.AppWorkspace;
            ZoomMode = ZoomMode.PageWidth;
            StartPage = 0;
            //   displayImage = new Bitmap(this.Width, this.Height);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);


           

            // enable double buffering
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
        }

          public event EventHandler DistancChanged;
        /// <summary>
        /// indicating mouse dragging mode of picture tracker control
        /// </summary>
        private bool isDraggingPictureTracker = false;

        /// <summary>
        /// last mouse position of mouse dragging
        /// </summary>
        Point lastMousePos;

        /// <summary>
        /// the new area where the picture tracker control to be dragged
        /// </summary>
        public Rectangle draggingRectangle;

        //-------------------------------------------------------------
        #region ** fields


      

        PrintDocument _doc;
        ZoomMode _zoomMode;
        double _zoom;
        int _startPage;
        Brush _backBrush;
        Point _ptLast;
        PointF _himm2pix = new PointF(-1, -1);
        PageImageList _img = new PageImageList();
        bool _cancel, _rendering;
       

        const int MARGIN = 4;

        #endregion

        //-------------------------------------------------------------
        #region ** ctor

     




      

        #endregion

        //-------------------------------------------------------------
        #region ** object model

        private Image _CurrentImage = null;
        /// <summary>
        /// get the original image that is currently being diplayed
        /// the entire image even though it is not fully displayed
        /// </summary>
        public Image CurrentImage
        {
            get { return _CurrentImage; }
            set
            {
                try
                {
                    if (_CurrentImage != null)
                    {
                        _CurrentImage.Dispose();
                        _CurrentImage = null;
                    }
                }
                catch
                { }
                _CurrentImage = value;
              

                VerticalScroll.Value = 0;
                UpdateScrollBars();
                this.Invalidate();

                VerticalScroll.Value = 0;
            }
        }

     
     

        ///// <summary>
        ///// returns the image that is displayed on the screen
        ///// </summary>
        //public Image CurrentDisplayedImage
        //{
        //    get { return displayImage; }
        //}


        /// <summary>
        /// Gets or sets the <see cref="PrintDocument"/> being previewed.
        /// </summary>
        public PrintDocument Document
        {
            get { return _doc; }
            set
            {
                if (value != _doc)
                {
                    _doc = value;
                    RefreshPreview();
                }
            }
        }
        /// <summary>
        /// Regenerates the preview to reflect changes in the document layout.
        /// </summary>
        public void RefreshPreview()
        {
            // render into PrintController
            if (_doc != null)
            {
                // prepare to render preview document
                _img.Clear();
                PrintController savePC = _doc.PrintController;

                // render preview document
                try
                {
                    _cancel = false;
                    _rendering = true;
                    _doc.PrintController = new PreviewPrintController();
                    _doc.PrintPage += _doc_PrintPage;
                    _doc.EndPrint += _doc_EndPrint;
                    _doc.Print();
                }
                finally
                {
                    _cancel = false;
                    _rendering = false;
                    _doc.PrintPage -= _doc_PrintPage;
                    _doc.EndPrint -= _doc_EndPrint;
                    _doc.PrintController = savePC;
                }
            }

            // update
            OnPageCountChanged(EventArgs.Empty);
            UpdatePreview();
            UpdateScrollBars();
        }
        /// <summary>
        /// Stops rendering the <see cref="Document"/>.
        /// </summary>
        public void Cancel()
        {
            _cancel = true;
        }
        /// <summary>
        /// Gets a value that indicates whether the <see cref="Document"/> is being rendered.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsRendering
        {
            get { return _rendering; }
        }
        /// <summary>
        /// Gets or sets how the zoom should be adjusted when the control is resized.
        /// </summary>
        [DefaultValue(ZoomMode.FullPage)]
        public ZoomMode ZoomMode
        {
            get { return _zoomMode; }
            set
            {
                if (value != _zoomMode)
                {
                    try
                    {
                        _zoomMode = value;
                        UpdateScrollBars();
                        OnZoomModeChanged(EventArgs.Empty);
                    }
                    catch
                    {}
                }
            }
        }
        /// <summary>
        /// Gets or sets a custom zoom factor used when the <see cref="ZoomMode"/> property
        /// is set to <b>Custom</b>.
        /// </summary>
        [
            //Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]
        public double Zoom
        {
            get { return _zoom; }
            set
            {
                if (value != _zoom || ZoomMode != ZoomMode.Custom)
                {
                    ZoomMode = ZoomMode.Custom;
                    _zoom = value;
                  
                    UpdateScrollBars();
                    OnZoomModeChanged(EventArgs.Empty);

                    // Raise zoom rate changed event
                    if (ZoomRateChangedEvent != null)
                    {
                        bool isFullPictureShown = this.Width <= this.ClientSize.Width &&
                                                  this.Height <= this.ClientSize.Height;
                        ZoomRateChangedEvent(_zoom, isFullPictureShown);
                    }
                }
            }
        }
        /// <summary>
        /// Gets or sets the first page being previewed.
        /// </summary>
        /// <remarks>
        /// There may be one or two pages visible depending on the setting of the
        /// <see cref="ZoomMode"/> property.
        /// </remarks>
        [
        Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]
        public int StartPage
        {
            get { return _startPage; }
            set
            {
                // validate new setting
                if (value > PageCount - 1) value = PageCount - 1;
                if (value < 0) value = 0;

                // apply new setting
                if (value != _startPage)
                {
                    _startPage = value;
                    UpdateScrollBars();
                    OnStartPageChanged(EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets the number of pages available for preview.
        /// </summary>
        /// <remarks>
        /// This number increases as the document is rendered into the control.
        /// </remarks>
        [
        Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]
        public int PageCount
        {
            get { return _img.Count; }
        }
        /// <summary>
        /// Gets or sets the control's background color.
        /// </summary>
        [DefaultValue(typeof(Color), "AppWorkspace")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                _backBrush = new SolidBrush(value);
            }
        }
        /// <summary>
        /// Gets a list containing the images of the pages in the document.
        /// </summary>
        [Browsable(false)]
        public PageImageList PageImages
        {
            get { return _img; }
        }
        /// <summary>
        /// Prints the current document honoring the selected page range.
        /// </summary>
        public void Print()
        {
            try
            {
                // select pages to print
                var ps = _doc.PrinterSettings;
                int first = ps.MinimumPage - 1;
                int last = ps.MaximumPage - 1;
                switch (ps.PrintRange)
                {
                    case PrintRange.AllPages:
                        Document.Print();
                        return;
                    case PrintRange.CurrentPage:
                        first = last = StartPage;
                        break;
                    case PrintRange.Selection:
                        first = last = StartPage;
                        if (ZoomMode == ZoomMode.TwoPages)
                        {
                            last = Math.Min(first + 1, PageCount - 1);
                        }
                        break;
                    case PrintRange.SomePages:
                        first = ps.FromPage - 1;
                        last = ps.ToPage - 1;
                        break;
                }

                // print using helper class
                var dp = new DocumentPrinter(this, first, last);
                dp.Print();
            }
            catch
            {

            }

        }

        #endregion

        //-------------------------------------------------------------
        #region ** events

        /// <summary>
        /// Occurs when the value of the <see cref="StartPage"/> property changes.
        /// </summary>
        public event EventHandler StartPageChanged;
        /// <summary>
        /// Raises the <see cref="StartPageChanged"/> event.
        /// </summary>
        /// <param name="e"><see cref="EventArgs"/> that provides the event data.</param>
        protected void OnStartPageChanged(EventArgs e)
        {
            if (StartPageChanged != null)
            {
                StartPageChanged(this, e);
            }
        }
        /// <summary>
        /// Occurs when the value of the <see cref="PageCount"/> property changes.
        /// </summary>
        public event EventHandler PageCountChanged;
        /// <summary>
        /// Raises the <see cref="PageCountChanged"/> event.
        /// </summary>
        /// <param name="e"><see cref="EventArgs"/> that provides the event data/</param>
        protected void OnPageCountChanged(EventArgs e)
        {
            if (PageCountChanged != null)
            {
                PageCountChanged(this, e);
            }
        }
        /// <summary>
        /// Occurs when the value of the <see cref="ZoomMode"/> property changes.
        /// </summary>
        public event EventHandler ZoomModeChanged;
        /// <summary>
        /// Raises the <see cref="ZoomModeChanged"/> event.
        /// </summary>
        /// <param name="e"><see cref="EventArgs"/> that contains the event data.</param>
        protected void OnZoomModeChanged(EventArgs e)
        {
            if (ZoomModeChanged != null)
            {
                ZoomModeChanged(this, e);
            }

          //  switch (ZoomMode)
            //{
            //    case ZoomMode.ActualSize:
            //        _zoom = 1;
            //        displayCenter = new Point(_CurrentImage.Width / 2, _CurrentImage.Height / 2);
            //        break;
            //    //case ZoomMode.FITHEIGHT:
            //    //    mZoom = (double)this.Height / originalImage.Height;
            //    //    displayCenter = new Point(originalImage.Width / 2, originalImage.Height / 2);
            //    //    break;
            //    case ZoomMode.FullPage:
            //        _zoom = (double)this.Height / _CurrentImage.Height;
            //        if ((double)this.Width / _CurrentImage.Width < _zoom)
            //            _zoom = this.Width / _CurrentImage.Width;
            //        displayCenter = new Point(_CurrentImage.Width / 2, _CurrentImage.Height / 2);
            //        break;
            //    case ZoomMode.PageWidth:
            //        _zoom = (double)this.Width / _CurrentImage.Width;
            //        displayCenter = new Point(_CurrentImage.Width / 2, _CurrentImage.Height / 2);
            //        break;
            //    case ZoomMode.Custom:

            //        break;
            //    default:
            //        throw new Exception("Invalid zoom request!!");
            //}
        }

        #endregion

        //-------------------------------------------------------------
        #region ** overrides

        // painting
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // we're painting it all, so don't call base class
            //base.OnPaintBackground(e);
        }

        ////a bitmap that is used to draw the requested portion of the image on to the display
        //Bitmap displayImage;
        ///// <summary>
        ///// a method used by the class to draw the final region of the the original image 
        ///// </summary>
        ///// <param name="rect">the requested region of the image</param>
        //void DrawImage(Rectangle rect)
        //{
        //    /*
        //     * this is the main function that actually does the drawing of the image
        //     * It takes the source rectangle which is to be displayed to the control
        //     * and draws this image on the displayedimage bitmap pbject
        //     */
        //    Graphics gr = Graphics.FromImage(displayImage);

        //    //first draw a white back ground to clear all the drawings performed earlier
        //    gr.FillRectangle(Brushes.White, new Rectangle(0, 0, displayImage.Width, displayImage.Height));
        //    //draw the selected rectangel on to the displayedimage bitmap

        //    gr.DrawImage(_CurrentImage,
        //        new Rectangle(0, 0, displayImage.Width, displayImage.Height),
        //        rect,
        //        GraphicsUnit.Pixel);

        //    //assign this bitmap to the picture control for display
        ////    pic.Image = displayImage;

        //    //save the values to history
        //    AddDisplayLog();
        //}

        /// <summary>
        /// a private method that logs the current display values into the collection
        /// its bahaves as:
        /// it inserts the current value and removes the final one if the capacity is full
        /// </summary>
        private void AddDisplayLog()
        {
            ////insert the last action performed to the first index of the list
            //centerValues.Insert(0, displayCenter);
            //zoomValues.Insert(0, mZoom);

            ////if the list has exceeded its capacity then remove the last item from each of the collections
            //if (centerValues.Count > HISTORYCAPACITY)
            //{
            //    centerValues.RemoveAt(HISTORYCAPACITY);
            //    zoomValues.RemoveAt(HISTORYCAPACITY);
            //}
        }


        int i = 0;
        /// <summary>
        /// scroll picture programmatically by the event from PictureTracker
        /// </summary>
        /// <param name="xMovementRate">horizontal scroll movement rate which may be nagtive value</param>
        /// <param name="yMovementRate">vertical scroll movement rate which may be nagtive value</param>
        /// 
        public void OnScrollPictureEvent(float xMovementRate, float yMovementRate)
        {


            // NOTICE : usage of Math.Abs(this.AutoScrollPosition.X) and Math.Abs(this.AutoScrollPosition.Y)
            // The get method of the Panel.AutoScrollPosition.X property and
            // the get method of the Panel.AutoScrollPosition.Y property return negative values.
            // However, positive values are required.
            // You can use the Math.Abs function to obtain a positive value from the Panel.AutoScrollPosition.X property and
            // the Panel.AutoScrollPosition.Y property


            //int dx = (int)xMovementRate - _ptLast.X;
            //int dy = (int)yMovementRate - _ptLast.Y;
            //if (dx != 0 || dy != 0)
            //{
            //    Point pt = AutoScrollPosition;
            //    AutoScrollPosition = new Point(-(pt.X + dx), -(pt.Y + dy));
            //    _ptLast = new Point((int)xMovementRate, (int)yMovementRate);
            //    this.Invalidate();
            //}


            //return;




            int X = 0;
            int Y = 0;

            if (isDragging)
            {
                X = (int)(Math.Abs(this.AutoScrollPosition.X) - xMovementRate);
                Y = (int)(Math.Abs(this.AutoScrollPosition.Y) - yMovementRate);
                //this.lastMousePosOfDragging.X += X;
                //this.lastMousePosOfDragging.Y += Y;
            }
            else
            {
                X = (int)(Math.Abs(this.AutoScrollPosition.X) + this.AutoScrollMinSize.Width* (xMovementRate));
                Y = (int)(Math.Abs(this.AutoScrollPosition.Y) + this.AutoScrollMinSize.Height * (yMovementRate));

            }


         

         
            this.AutoScrollPosition = new Point(X, Y);
         
         
            i++;

            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                Image img = CurrentImage;// GetImage(StartPage);
                if (img != null)
                {
                    Rectangle rc = GetImageRectangle(img);


                    if (PictureBoxPaintedEvent != null)                   
                    {
                        Rectangle Showingrc = new Rectangle(new Point(Math.Abs(this.AutoScrollPosition.X), Math.Abs(this.AutoScrollPosition.Y)), this.Bounds.Size);
                        //Rectangle thisControlClientRect = this.ClientRectangle;
                        //thisControlClientRect.X -= this.AutoScrollPosition.X;
                        //thisControlClientRect.Y -= this.AutoScrollPosition.Y;
                        PictureBoxPaintedEvent(Showingrc, rc);
                    }

                   

                    //this.pictureTracker.OnPictureBoxPainted(Showingrc, rc);
                    if (rc.Width > 2 && rc.Height > 2)
                    {
                        // adjust for scrollbars
                        rc.Offset(AutoScrollPosition);

                        // render single page
                        if (_zoomMode != ZoomMode.TwoPages)
                        {
                            RenderPage(e.Graphics, img, rc);
                        }
                        else // render two pages
                        {
                            // render first page
                            rc.Width = (rc.Width - MARGIN) / 2;
                            RenderPage(e.Graphics, img, rc);

                            // render second page
                            img = CurrentImage;// GetImage(StartPage + 1);
                            if (img != null)
                            {
                                // update bounds in case orientation changed
                                rc = GetImageRectangle(img);
                                rc.Width = (rc.Width - MARGIN) / 2;

                                // render second page
                                rc.Offset(rc.Width + MARGIN, 0);
                                RenderPage(e.Graphics, img, rc);
                            }
                        }
                    }
                }

                // paint background
                e.Graphics.FillRectangle(_backBrush, ClientRectangle);
            }
            catch
            { }


           
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            //when the size of the image is changed then the size of the bitmap 
            //used to draw the selected image will change 
            //displayImage = new Bitmap(this.Width, this.Height);

            UpdateScrollBars();
            base.OnSizeChanged(e);
        }

        private Point lastMousePosOfDragging = new Point(0, 0);
        // pan by dragging preview pane
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            isDragging = true;
            lastMousePosOfDragging = new Point(e.X, e.Y);

            drag = true;
            lastMouse = new Point(e.X, e.Y);

          

            //in cases where the display mode is pan or region select
            //there is a need to retain the first point of the mouse
            //this coordinate is then stored in the temporary variable 
            switch (previewMode)
            {
                case PreviewMode.REGIONSELECTION:
                    Cursor = Cursors.Cross;
                    tempCenter = e.Location;
                    break;
                case PreviewMode.PAN:
                    if (e.Button == MouseButtons.Left && AutoScrollMinSize != Size.Empty)
                    {
                        Cursor = Cursors.Hand;
                        _ptLast = new Point(e.X, e.Y);
                    }
                    tempCenter = e.Location;
                    break;
                default:
                    Cursor = Cursors.Default;
                    break;
            }
        }
        //determines how the mouse behaves on the image
        PreviewMode previewMode = PreviewMode.PAN;
        /// <summary>
        /// gets or sets how the mouse behaves on the image control display area
        /// </summary>
        public PreviewMode ImagePreviewMode
        {
            get { return previewMode; }
            set
            {
                previewMode = value;
                switch (value)
                {
                    case PreviewMode.PAN:
                    Cursor = Cursors.Default;
                    break;
                    case PreviewMode.REGIONSELECTION:
                    

                    default:
                    Cursor = Cursors.Default;
                    break;


                }
            }

        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            isDragging = false;

            drag = false;

            //when the mouse is up its when most of the previews are commited
            switch (previewMode)
            {
                case PreviewMode.PAN:
                    if (e.Button == MouseButtons.Left)
                        Cursor = Cursors.Default;

                    break;
                case PreviewMode.REGIONSELECTION:
                    //displayCenter = new Point(displayCenter.X + (int)(((double)(tempCenter.X + e.X - this.Width) / 2) / _zoom),
                    //    displayCenter.Y + (int)(((double)(tempCenter.Y + e.Y - this.Height) / 2) / _zoom));


                   

                    double z = _zoom * this.Width / Math.Abs(tempCenter.X - e.X);
                    if (_zoom * this.Height / Math.Abs(tempCenter.Y - e.Y) < z)
                        z = _zoom * this.Height / Math.Abs(tempCenter.Y - e.Y);
                    this.Zoom = z;

                    int w = Math.Abs(tempCenter.X - e.X), h = Math.Abs(tempCenter.Y - e.Y);

                     string strZoom = Math.Floor(z).ToString();
                    this.HorizontalScroll.Value = int.Parse(strZoom) *(tempCenter.X + e.X - w) ;
                    this.VerticalScroll.Value = int.Parse(strZoom) * (tempCenter.Y + e.Y - h);



                   // string strZoom = Math.Floor(z).ToString();
                   
                   
                   //// ZoomImage();
                   // this.HorizontalScroll.Value = tempCenter.X * int.Parse(strZoom);
                   // this.VerticalScroll.Value = (int)tempCenter.Y * int.Parse(strZoom);

                    break;
                case PreviewMode.ZOOMIN:
                    //when zoom in the zoom value is simply multiplied by two
                    //displayCenter = new Point(displayCenter.X + (int)((e.X - this.Width / 2) / mZoom),
                    //    displayCenter.Y + (int)((e.Y - this.Height / 2) / mZoom));
                    //mZoom *= 2;
                    ////redraw the image with the new zoom value
                    //ZoomImage();
                    break;
                case PreviewMode.ZOOMOUT:
                    //when zoom out the zoom value is simply divided by two
                    //displayCenter = new Point(displayCenter.X + (int)((e.X - this.Width / 2) / mZoom),
                    //    displayCenter.Y + (int)((e.Y - this.Height / 2) / mZoom));
                    //mZoom /= 2;
                    ////redraw the image with the new zoom value
                    //ZoomImage();
                    break;
                default:
                    break;
            }

        }
        //this is the coordinate of the center of the image displayed on the control in reference to 
        //the coordinate system of the original image
        Point displayCenter;

        //a private member that temporarly holds points in the process of manipulations
        Point tempCenter;
        float xMovementRate = 0;
        float yMovementRate = 0;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);



            try
            {



                if (isDragging && (lastMousePosOfDragging.X != e.X || lastMousePosOfDragging.Y == e.Y))
                {
                    int offsetX = e.X - lastMousePosOfDragging.X;
                    int offsetY = e.Y - lastMousePosOfDragging.Y;
                    lastMousePosOfDragging = new Point(e.X, e.Y);

                    // 1.Calculate horizontal and vertical mouse movement rates relative to the pictureDestRect
                    //   the mouse movement rates may be nagtive value if mouse moved to left or up
                    // 2.Raise ScrollPictureEvent to scroll actual picture in the ScalablePictureBox
                    xMovementRate = (float)offsetX;// / (float)this.pictureBox.ClientRectangle.Width;
                    yMovementRate = (float)offsetY; // / (float)this.pictureBox.ClientRectangle.Height;

                    if (yMovementRate > 20)
                    {
                        
                    }
                   // OnScrollPictureEvent(xMovementRate, yMovementRate);



                }

                //   lastMousePosOfDragging = new Point(e.X, e.Y);

            }
            catch (Exception ex)
            {

            }


            //when a mouse is down and moving 
            //panning and region selection are posibilities
            switch (previewMode)
            {
                case PreviewMode.REGIONSELECTION:
                    if (e.Button == MouseButtons.Left)
                    {
                        //display a rectangular region to the selected region 
                        //to notify the user what he is selecting
                        int w = Math.Abs(tempCenter.X - e.X);

                        int h = Math.Abs(tempCenter.Y - e.Y); // w * this.Height / this.Width;
                        if (w > 1 || h > 1)
                        {
                            this.Refresh();



                            Graphics gr = this.CreateGraphics();
                            gr.DrawString("(" + (tempCenter.X + e.X) / 2 + "," + (tempCenter.Y + e.Y) / 2 + ")", this.Font, Brushes.Khaki, new PointF((tempCenter.X + e.X) / 2, (tempCenter.Y + e.Y) / 2));
                            //gr.DrawRectangle(Pens.Red, new Rectangle((tempCenter.X + e.X - w) / 2, (tempCenter.Y + e.Y - h) / 2, w, h));
                            gr.DrawRectangle(Pens.Red, new Rectangle((tempCenter.X + e.X - w ) / 2, (tempCenter.Y + e.Y - h ) / 2, w, h));
                            gr.Dispose();
                        }
                    }
                    break;
                case PreviewMode.PAN:

                    if (Cursor == Cursors.Hand)
                    {
                        int dx = e.X - _ptLast.X;
                        int dy = e.Y - _ptLast.Y;
                        if (dx != 0 || dy != 0)
                        {
                            Point pt = AutoScrollPosition;
                            AutoScrollPosition = new Point(-(pt.X + dx), -(pt.Y + dy));
                            _ptLast = new Point(e.X, e.Y);
                            this.Invalidate();
                        }
                    }

                    //if (e.Button == MouseButtons.Left && (tempCenter.X != e.X || tempCenter.Y != e.Y))
                    //{
                    //    displayCenter = new Point(displayCenter.X + (int)((tempCenter.X - e.X) / this.Zoom),
                    //        displayCenter.Y + (int)((tempCenter.Y - e.Y) / this.Zoom));
                    //    ZoomImage();
                    //    tempCenter = e.Location;
                    //}
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// this is an over load that retains both the center of the image as well as the zoom value 
        /// mostly used to redraw the image, in cases like resizing the control
        /// </summary>
        public void ZoomImage()
        {
            //using the private members zoomvalue and display center 
            //compute the source rectangel from the original image
            Rectangle rect = new Rectangle(displayCenter.X - (int)(this.Width / (2 * this.Zoom)),
                          displayCenter.Y - (int)(this.Height / (2 * this.Zoom)),
                          (int)((double)this.Width / this.Zoom),
                          (int)((double)this.Height / this.Zoom));

            //call the drawimage function to extract the selected rectangel
            //DrawImage(rect);
        }

        // keyboard support
        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Right:
                case Keys.Down:
                case Keys.PageUp:
                case Keys.PageDown:
                case Keys.Home:
                case Keys.End:
                    return true;
            }
            return base.IsInputKey(keyData);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);


         

            if (e.Handled)
                return;

            switch (e.KeyCode)
            {
                // arrow keys scroll or browse, depending on ZoomMode
                case Keys.Left:
                case Keys.Up:
                case Keys.Right:
                case Keys.Down:

                    // browse
                    if (ZoomMode == ZoomMode.FullPage || ZoomMode == ZoomMode.TwoPages)
                    {
                        switch (e.KeyCode)
                        {
                            case Keys.Left:
                            case Keys.Up:
                                StartPage--;
                                break;
                            case Keys.Right:
                            case Keys.Down:
                                StartPage++;
                                break;
                        }
                        break;
                    }

                    // scroll
                    Point pt = AutoScrollPosition;
                    switch (e.KeyCode)
                    {
                        case Keys.Left: pt.X += 20; break;
                        case Keys.Right: pt.X -= 20; break;
                        case Keys.Up: pt.Y += 20; break;
                        case Keys.Down: pt.Y -= 20; break;
                    }
                    AutoScrollPosition = new Point(-pt.X, -pt.Y);
                    break;

                // page up/down browse pages
                case Keys.PageUp:
                    StartPage--;
                    break;
                case Keys.PageDown:
                    StartPage++;
                    break;

                // home/end 
                case Keys.Home:
                    AutoScrollPosition = Point.Empty;
                    StartPage = 0;
                    break;
                case Keys.End:
                    AutoScrollPosition = Point.Empty;
                    StartPage = PageCount - 1;
                    break;

                default:
                    return;
            }

            // if we got here, the event was handled
            e.Handled = true;
        }

        #endregion

        //-------------------------------------------------------------
        #region ** implementation

        void _doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            SyncPageImages(false);
            if (_cancel)
            {
                e.Cancel = true;
            }
        }
        void _doc_EndPrint(object sender, PrintEventArgs e)
        {
            SyncPageImages(true);
        }
        void SyncPageImages(bool lastPageReady)
        {
            var pv = (PreviewPrintController)_doc.PrintController;
            if (pv != null)
            {
                var pageInfo = pv.GetPreviewPageInfo();
                int count = lastPageReady ? pageInfo.Length : pageInfo.Length - 1;
                for (int i = _img.Count; i < count; i++)
                {
                    var img = pageInfo[i].Image;
                    _img.Add(img);

                    OnPageCountChanged(EventArgs.Empty);

                    if (StartPage < 0) StartPage = 0;
                    if (i == StartPage || i == StartPage + 1)
                    {
                        Refresh();
                    }
                    Application.DoEvents();
                }
            }
        }
        //Image GetImage(int page)
        //{
        //    return page > -1 && page < PageCount ? _img[page] : null;
        //}
        Rectangle GetImageRectangle(Image img)
        {
            // start with regular image rectangle
            Size sz = GetImageSizeInPixels(img);
            Rectangle rc = new Rectangle(0, 0, sz.Width, sz.Height);

            // calculate zoom
            Rectangle rcCli = this.ClientRectangle;
            switch (_zoomMode)
            {
                case ZoomMode.ActualSize:
                    _zoom = 1;
                    break;
                case ZoomMode.TwoPages:
                    rc.Width *= 2; // << two pages side-by-side
                    goto case ZoomMode.FullPage;
                case ZoomMode.FullPage:
                    double zoomX = (rc.Width > 0) ? rcCli.Width / (double)rc.Width : 0;
                    double zoomY = (rc.Height > 0) ? rcCli.Height / (double)rc.Height : 0;
                    _zoom = Math.Min(zoomX, zoomY);
                    break;
                case ZoomMode.PageWidth:
                    _zoom = (rc.Width > 0) ? rcCli.Width / (double)rc.Width : 0;
                    break;
            }

            // apply zoom factor
            rc.Width = (int)(rc.Width * _zoom);
            rc.Height = (int)(rc.Height * _zoom);

            // center image
            int dx = (rcCli.Width - rc.Width) / 2;
            if (dx > 0) rc.X += dx;
            int dy = (rcCli.Height - rc.Height) / 2;
            if (dy > 0) rc.Y += dy;

            // add some extra space
            rc.Inflate(-MARGIN, -MARGIN);
            if (_zoomMode == ZoomMode.TwoPages)
            {
                rc.Inflate(-MARGIN / 2, 0);
            }

            // done
            return rc;
        }
        Size GetImageSizeInPixels(Image img)
        {
            // get image size
            SizeF szf = img.PhysicalDimension;

            // if it is a metafile, convert to pixels
            if (img is Metafile)
            {
                // get screen resolution
                if (_himm2pix.X < 0)
                {
                    using (Graphics g = this.CreateGraphics())
                    {
                        _himm2pix.X = g.DpiX / 2540f;
                        _himm2pix.Y = g.DpiY / 2540f;
                    }
                }

                // convert himetric to pixels
                szf.Width *= _himm2pix.X;
                szf.Height *= _himm2pix.Y;
            }

            // done
            return Size.Truncate(szf);
        }
        void RenderPage(Graphics g, Image img, Rectangle rc)
        {
            // draw the page
            rc.Offset(1, 1);

            g.DrawRectangle(Pens.Black, rc);
            rc.Offset(-1, -1);
            g.FillRectangle(Brushes.White, rc);
            g.DrawImage(img, rc);
            g.DrawRectangle(Pens.Black, rc);

            // exclude cliprect to paint background later
            rc.Width++;
            rc.Height++;
            g.ExcludeClip(rc);
            rc.Offset(1, 1);
            g.ExcludeClip(rc);
        }
        void UpdateScrollBars()
        {
            // get image rectangle to adjust scroll size
            Rectangle rc = Rectangle.Empty;
            Image img = this.CurrentImage;// this.GetImage(StartPage);
            if (this.CurrentImage != null)
            {
                rc = GetImageRectangle(img);

                //if (previewMode == PreviewMode.REGIONSELECTION)
                //{
                //    rc = new Rectangle(tempCenter.X, tempCenter.Y, displayImage.Width, displayImage.Height);
                //}
            }

            // calculate new scroll size
            Size scrollSize = new Size(0, 0);
            switch (_zoomMode)
            {
                case ZoomMode.PageWidth:
                    scrollSize = new Size(0, rc.Height + 2 * MARGIN);
                    break;
                case ZoomMode.ActualSize:
                case ZoomMode.Custom:
                    scrollSize = new Size(rc.Width + 2 * MARGIN, rc.Height + 2 * MARGIN);
                    break;
            }

            // apply if needed
            if (scrollSize != AutoScrollMinSize)
            {
                AutoScrollMinSize = scrollSize;
            }

            // ready to update
            UpdatePreview();


           
        }
        void UpdatePreview()
        {
            // validate current page
            if (_startPage < 0) _startPage = 0;
            if (_startPage > PageCount - 1) _startPage = PageCount - 1;

            // repaint
            Invalidate();
        }
        #endregion

        //-------------------------------------------------------------
        #region ** nested class

        // helper class that prints the selected page range in a PrintDocument.
        internal class DocumentPrinter : PrintDocument
        {
            int _first, _last, _index;
            PageImageList _imgList;

            public DocumentPrinter(scalablePictureBoxImpNew preview, int first, int last)
            {
                // save page range and image list
                _first = first;
                _last = last;
                _imgList = preview.PageImages;

                // copy page and printer settings from original document
                DefaultPageSettings = preview.Document.DefaultPageSettings;
                PrinterSettings = preview.Document.PrinterSettings;
            }

            protected override void OnBeginPrint(PrintEventArgs e)
            {
                // start from the first page
                _index = _first;
            }
            protected override void OnPrintPage(PrintPageEventArgs e)
            {
                // render the current page and increment the index
                e.Graphics.PageUnit = GraphicsUnit.Display;
                e.Graphics.DrawImage(_imgList[_index++], e.PageBounds);

                // stop when we reach the last page in the range
                e.HasMorePages = _index <= _last;
            }
        }

        #endregion

        /// <summary>
        /// Draw a reversible rectangle
        /// </summary>
        /// <param name="rect">rectangle to be drawn</param>
        public void DrawReversibleRect(Rectangle rect)
        {
            // Convert the location of rectangle to screen coordinates.
            rect.Location = PointToScreen(rect.Location);

            // Draw the reversible frame.
            ControlPaint.DrawReversibleFrame(rect, Color.Black, FrameStyle.Dashed);
        }

   
        public void ZoomIn()
        {
            this.Zoom += 0.02;
        }

        public void ZoomOut()
        {
            if (this.Zoom - 0.02 > 0.1)
                this.Zoom -= 0.02;

        }

        /// <summary>
        /// this method rotated the image 
        /// </summary>
        /// <param name="ClockWise">specifies if its clockwise or the other</param>
        public void RotateImage(bool ClockWise)
        {
            if (this.CurrentImage != null)
            {
                if (ClockWise)
                {
                    this.CurrentImage.RotateFlip(RotateFlipType.Rotate90FlipNone);//.Rotate90FlipXY);
                }
                else
                {
                    this.CurrentImage.RotateFlip(RotateFlipType.Rotate90FlipXY);
                }
                ZoomMode = ZoomMode.FullPage;
                this.Invalidate();
            }
        }

        public void FlipImage(bool Vertical)
        {
            if (this.CurrentImage != null)
            {
                if (Vertical)
                {
                    this.CurrentImage.RotateFlip(RotateFlipType.Rotate180FlipX);//.Rotate90FlipXY);
                }
                else
                {
                    this.CurrentImage.RotateFlip(RotateFlipType.Rotate180FlipY);//.Rotate90FlipXY);
                }
                ZoomMode = ZoomMode.FullPage;
                this.Invalidate();
            }
        }
    }
}
