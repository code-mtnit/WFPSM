using System;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Sbn.AdvancedControls.Imaging.ImageViewer.ScalablePictureBox;

namespace Sbn.AdvancedControls.Imaging.ImageViewer
{

    /// <summary>
    /// Represents a preview of one or two pages in a <see cref="PrintDocument"/>.
    /// </summary>
    /// <remarks>
    /// This control is similar to the standard <see cref="PrintPreviewControl"/> but
    /// it displays pages as they are rendered. By contrast, the standard control 
    /// waits until the entire document is rendered before it displays anything.
    /// </remarks>
    public partial class SBNPictureBox : UserControl
    {

        public event EventHandler DistancChanged;
        public event EventHandler ZoomChanged;

        public void OnZoomChanged(EventArgs e)
        {
            EventHandler handler = ZoomChanged;
            if (handler != null) handler(this, e);
        }

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


        bool drag = false;
        private bool isDragging = false;

        /// <summary>
        /// last mouse position in dragging highlight rectangle
        /// </summary>
        private Point lastMousePosOfDragging = new Point(0, 0);
        private System.Drawing.Point lastMouse = new Point(0, 0);

        float xMovementRate = 0;
        float yMovementRate = 0;

        PrintDocument _doc;
        ZoomMode _zoomMode;
        double _zoom;
        int _startPage;
        Brush _backBrush;
        Point _ptLast;
        PointF _himm2pix = new PointF(-1, -1);
        PageImageList _img = new PageImageList();
        bool _cancel, _rendering;
        private PictureTracker pictureTracker;
        private scalablePictureBoxImpNew scalablePictureBoxImpNew1;

        const int MARGIN = 4;

        #endregion

        //-------------------------------------------------------------
        #region ** ctor

        /// <summary>
        /// Initializes a new instance of a <see cref="CoolPrintPreviewControl"/> control.
        /// </summary>
        public SBNPictureBox()
        {

            InitializeComponent();

            pictureTracker.Location = new Point(this.Width - pictureTracker.Width - 50 , 10);
            // register event handler for events from ScalablePictureBox
            //this.scalablePictureBoxImp.PictureBoxPaintedEvent += new ScalablePictureBoxImp.PictureBoxPaintedEventHandler(this.pictureTracker.OnPictureBoxPainted);
            this.scalablePictureBoxImpNew1.PictureBoxPaintedEvent += new scalablePictureBoxImpNew.PictureBoxPaintedEventHandler(this.pictureTracker.OnPictureBoxPainted);
            this.scalablePictureBoxImpNew1.ZoomRateChangedEvent += new scalablePictureBoxImpNew.ZoomRateChangedEventHandler(scalablePictureBoxImpNew1_ZoomRateChangedEvent);

            this.pictureTracker.ScrollPictureEvent += new PictureTracker.ScrollPictureEventHandler(this.scalablePictureBoxImpNew1.OnScrollPictureEvent);
            

            BackColor = SystemColors.AppWorkspace;
            ZoomMode = ZoomMode.PageWidth;
            StartPage = 0;
         //   displayImage = new Bitmap(this.Width, this.Height);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);


            this.pictureTracker.BringToFront();

            // enable double buffering
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);



           
        }

        void scalablePictureBoxImpNew1_ZoomRateChangedEvent(double zoomRate, bool isFullPictureShown)
        {
            if (isFullPictureShown)
            {
                this.pictureTracker.Visible = false;
                this.pictureTracker.Enabled = false;
            }
            else
            {
                this.pictureTracker.Visible = true;
                this.pictureTracker.Enabled = true;
                this.pictureTracker.ZoomRate = zoomRate;
            }
        }



        /// <summary>
        /// Notify current scale percentage to PictureTracker control if current picture is
        /// zoomed in, or hide PictureTracker control if current picture is shown fully.
        /// </summary>
        /// <param name="zoomRate">zoom rate of picture</param>
        /// <param name="isWholePictureShown">true if the whole picture is shown</param>
        private void scalablePictureBox_ZoomRateChanged(double zoomRate, bool isWholePictureShown)
        {
           
        }

     

        #endregion

        //-------------------------------------------------------------
        #region ** object model

        private Image _CurrentImage = null;
        private int _verticalScrollValue;

        /// <summary>
        /// get the original image that is currently being diplayed
        /// the entire image even though it is not fully displayed
        /// </summary>
        public Image CurrentImage
        {
            get { return scalablePictureBoxImpNew1.CurrentImage; }
            set
            {
                scalablePictureBoxImpNew1.CurrentImage = value;
                this.pictureTracker.Picture = value;
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
            get { return scalablePictureBoxImpNew1.Document; }
            set
            {
                scalablePictureBoxImpNew1.Document = value;
            }
        }
        /// <summary>
        /// Regenerates the preview to reflect changes in the document layout.
        /// </summary>
        public void RefreshPreview()
        {
            scalablePictureBoxImpNew1.RefreshPreview();

       
        }
        /// <summary>
        /// Stops rendering the <see cref="Document"/>.
        /// </summary>
        public void Cancel()
        {
            scalablePictureBoxImpNew1.Cancel();
            
        }
        /// <summary>
        /// Gets a value that indicates whether the <see cref="Document"/> is being rendered.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsRendering
        {
            get { return scalablePictureBoxImpNew1.IsRendering; }
        }
        /// <summary>
        /// Gets or sets how the zoom should be adjusted when the control is resized.
        /// </summary>
        [DefaultValue(ZoomMode.FullPage)]
        public ZoomMode ZoomMode
        {
            get { return scalablePictureBoxImpNew1.ZoomMode; }
            set
            {
                scalablePictureBoxImpNew1.ZoomMode = value;
                OnZoomChanged(null);
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
            get { return scalablePictureBoxImpNew1.Zoom; }
            set
            {
              
                    scalablePictureBoxImpNew1.Zoom = value;
                   
               
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
            get { return scalablePictureBoxImpNew1.StartPage; ; }
            set
            {
                scalablePictureBoxImpNew1.StartPage = value;               
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
            get { return scalablePictureBoxImpNew1.PageCount; }
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
            get { return scalablePictureBoxImpNew1.PageImages; }
        }
        /// <summary>
        /// Prints the current document honoring the selected page range.
        /// </summary>
        public void Print()
        {
            this.scalablePictureBoxImpNew1.Print();
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
      
        /// <summary>
        /// gets or sets how the mouse behaves on the image control display area
        /// </summary>
        public PreviewMode ImagePreviewMode
        {
            get { return this.scalablePictureBoxImpNew1.ImagePreviewMode; }
            set
            {
                this.scalablePictureBoxImpNew1.ImagePreviewMode = value;

            }

        }

     

        public Point ViewOffset
        {
            get { return new Point(scalablePictureBoxImpNew1.HorizontalScroll.Value, scalablePictureBoxImpNew1.VerticalScroll.Value); }
            set
            {
               

                if (value.X > scalablePictureBoxImpNew1.HorizontalScroll.Maximum)
                    value.X =scalablePictureBoxImpNew1.HorizontalScroll.Maximum;
                if (value.X < scalablePictureBoxImpNew1.HorizontalScroll.Minimum)
                    value.X = scalablePictureBoxImpNew1.HorizontalScroll.Minimum;

                if (value.Y > scalablePictureBoxImpNew1.VerticalScroll.Maximum)
                    value.Y = scalablePictureBoxImpNew1.VerticalScroll.Maximum;
                if (value.Y < scalablePictureBoxImpNew1.VerticalScroll.Minimum)
                    value.Y = scalablePictureBoxImpNew1.VerticalScroll.Minimum;

                    scalablePictureBoxImpNew1.HorizontalScroll.Value = value.X;
                    scalablePictureBoxImpNew1.VerticalScroll.Value = value.Y;
                scalablePictureBoxImpNew1.Invalidate();

                
            }
        }


        /// <summary>
        /// this is an over load that retains both the center of the image as well as the zoom value 
        /// mostly used to redraw the image, in cases like resizing the control
        /// </summary>
        public void ZoomImage()
        {
            this.scalablePictureBoxImpNew1.ZoomImage();          
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

        /// <summary>
        /// begin to drag picture tracker control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureTracker_MouseDown(object sender, MouseEventArgs e)
        {
            isDraggingPictureTracker = true;    // Make a note that we are dragging picture tracker control

            // Store the last mouse poit for this rubber-band rectangle.
            lastMousePos.X = e.X;
            lastMousePos.Y = e.Y;

            // draw initial dragging rectangle
            draggingRectangle = this.pictureTracker.Bounds;
            DrawReversibleRect(draggingRectangle);
        }

        /// <summary>
        /// dragging picture tracker control in mouse dragging mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureTracker_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDraggingPictureTracker)
            {
                // caculating next candidate dragging rectangle
                Point newPos = new Point(draggingRectangle.Location.X + e.X - lastMousePos.X,
                                         draggingRectangle.Location.Y + e.Y - lastMousePos.Y);
                Rectangle newPictureTrackerArea = draggingRectangle;
                newPictureTrackerArea.Location = newPos;

                // saving current mouse position to be used for next dragging
                this.lastMousePos = new Point(e.X, e.Y);

                // dragging picture tracker only when the candidate dragging rectangle
                // is within this ScalablePictureBox control
                if (this.ClientRectangle.Contains(newPictureTrackerArea))
                {
                    // removing previous rubber-band frame
                    DrawReversibleRect(draggingRectangle);

                    // updating dragging rectangle
                    draggingRectangle = newPictureTrackerArea;

                    // drawing new rubber-band frame
                    DrawReversibleRect(draggingRectangle);
                }
            }
        }

        /// <summary>
        /// end dragging picture tracker control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureTracker_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDraggingPictureTracker)
            {
                isDraggingPictureTracker = false;

                // erase dragging rectangle
                DrawReversibleRect(draggingRectangle);

                // move the picture tracker control to the new position
                this.pictureTracker.Location = draggingRectangle.Location;
            
            }
        }

        public void ZoomIn()
        {
            this.scalablePictureBoxImpNew1.ZoomIn();
            OnZoomChanged(null);
        }

        public void ZoomOut()
        {
            this.scalablePictureBoxImpNew1.ZoomOut();
            OnZoomChanged(null);
        }

        /// <summary>
        /// this method rotated the image 
        /// </summary>
        /// <param name="ClockWise">specifies if its clockwise or the other</param>
        public void RotateImage(bool ClockWise)
        {
            this.scalablePictureBoxImpNew1.RotateImage(ClockWise);
        }

        public void FlipImage(bool Vertical)
        {
            this.scalablePictureBoxImpNew1.FlipImage(Vertical);
            OnZoomChanged(null);
        }

        private void InitializeComponent()
        {
            this.pictureTracker = new PictureTracker();
            this.scalablePictureBoxImpNew1 = new scalablePictureBoxImpNew();
            this.SuspendLayout();
            // 
            // pictureTracker
            // 
            this.pictureTracker.BackColor = System.Drawing.Color.Lavender;
            this.pictureTracker.Location = new System.Drawing.Point(550, 10);
            this.pictureTracker.Name = "pictureTracker";
            this.pictureTracker.Size = new System.Drawing.Size(137, 102);
            
            this.pictureTracker.TabIndex = 0;
            this.pictureTracker.ZoomRate = 0D;
            this.pictureTracker.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureTracker_MouseDown);
            this.pictureTracker.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureTracker_MouseMove);
            this.pictureTracker.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureTracker_MouseUp);
            // 
            // scalablePictureBoxImpNew1
            // 
            this.scalablePictureBoxImpNew1.AutoScroll = true;
            this.scalablePictureBoxImpNew1.AutoScrollMinSize = new System.Drawing.Size(0, 8);
            this.scalablePictureBoxImpNew1.CurrentImage = null;
            this.scalablePictureBoxImpNew1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scalablePictureBoxImpNew1.Document = null;
            this.scalablePictureBoxImpNew1.ImagePreviewMode = PreviewMode.PAN;
            this.scalablePictureBoxImpNew1.Location = new System.Drawing.Point(0, 0);
            this.scalablePictureBoxImpNew1.Name = "scalablePictureBoxImpNew1";
            this.scalablePictureBoxImpNew1.Size = new System.Drawing.Size(586, 417);
            this.scalablePictureBoxImpNew1.TabIndex = 1;
           
            // 
            // HTFImageViewerNew
            // 
            this.Controls.Add(this.pictureTracker);
            this.Controls.Add(this.scalablePictureBoxImpNew1);
            this.Name = "HTFImageViewerNew";
            this.Size = new System.Drawing.Size(586, 417);
            this.ResumeLayout(false);

        }
        
        protected override void OnScroll(ScrollEventArgs se)
        {
            if (se.NewValue > 0)
            { 

            }

            base.OnScroll(se);

            this.pictureTracker.Location = draggingRectangle.Location;
        }

        protected override void OnResize(EventArgs e)
        {
            
            base.OnResize(e);

            pictureTracker.Location = new Point(this.Width - pictureTracker.Width - 50, 10);
        }
    }

   

  

  
}
