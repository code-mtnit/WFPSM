using Sbn.AdvancedControls.Imaging.ImageViewer.ListViewFolder;
using Sbn.Controls.Imaging.EventArgsFolder;
using Sbn.Controls.Imaging.ImagingObject;
using Sbn.FramWork.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ItemClickEventArgs = Sbn.AdvancedControls.Imaging.ThumbnailControl.ItemClickEventArgs;
using Point = System.Drawing.Point;

namespace Sbn.Controls.Imaging
{
    [ToolboxItem(true),
    Description("A ImageDocumentsViewer control for Windows forms."),
    ToolboxBitmap(typeof(ImageDocumentsViewer), "ImageDocumentsViewer"),
    DefaultEvent("OnSelectionChanged")]
    public partial class ImageDocumentsManager : UserControl
    {
        public SbnImageTools CurrentImageTools = new SbnImageTools();
        #region Property Events


        public event EventHandler<ImageEventArg> CreatedThumbnailImage;

        public void OnCreatedThumbnailImage(ImageEventArg e)
        {
            EventHandler<ImageEventArg> handler = CreatedThumbnailImage;
            if (handler != null) handler(this, e);
        }

        [Category("Filmstrip events")]
        public event EventHandler<ImageEventArg> CurrenViewImageChanged;

        public void OnCurrenViewImageChanged(ImageEventArg e)
        {
            EventHandler<ImageEventArg> handler = CurrenViewImageChanged;
            if (handler != null) handler(this, e);
        }

        [Category("PrintFilmstripImage events")]
        public event EventHandler<PrintDocEventArgs> PrintPage;

        public void OnPrintPage(PrintDocEventArgs e)
        {
            EventHandler<PrintDocEventArgs> handler = PrintPage;
            if (handler != null) handler(this, e);
        }

        [Category("PrintFilmstripImage events")]
        public event EventHandler<PrintDocEventArgs> StartPrint;

        public void OnStartPrint(PrintDocEventArgs e)
        {
            EventHandler<PrintDocEventArgs> handler = StartPrint;
            if (handler != null) handler(this, e);
        }

        [Category("PrintFilmstripImage events")]
        public event EventHandler<PrintDocEventArgs> PrintedImages;

        public void OnPrintedImages(PrintDocEventArgs e)
        {
            EventHandler<PrintDocEventArgs> handler = PrintedImages;
            if (handler != null) handler(this, e);
        }

        [Category("PrintFilmstripImage events")]
        public event EventHandler<ImageEventArg> BeforPrintPage;

        public void OnBeforPrintPage(ImageEventArg e)
        {
            EventHandler<ImageEventArg> handler = BeforPrintPage;
            if (handler != null) handler(this, e);
        }

        [Category("Filmstrip events")]
        public event EventHandler<ImageEventArg> NeedImage;

        public void OnNeedImage(ImageEventArg e)
        {
            EventHandler<ImageEventArg> handler = NeedImage;
            if (handler != null) handler(this, e);
        }


        [Category("Filmstrip events")]
        public event EventHandler<ImageEventArg> NeedThumbnailsImage;

        public void OnNeedThumbnailsImage(ImageEventArg e)
        {
            EventHandler<ImageEventArg> handler = NeedThumbnailsImage;
            if (handler != null) handler(this, e);
        }

        [Category("Filmstrip events")]
        public event EventHandler<ImageEventArgs> AddedImage;

        public void OnAddedImage(ImageEventArgs e)
        {
            EventHandler<ImageEventArgs> handler = AddedImage;
            if (handler != null) handler(this, e);
        }

        [Category("Filmstrip events")]
        public event EventHandler<ImageEventArg> StartEditImage;

        public void OnStartEditImage(ImageEventArg e)
        {
            EventHandler<ImageEventArg> handler = StartEditImage;
            if (handler != null) handler(this, e);
        }

        [Category("Filmstrip events")]
        public event EventHandler<ImageEventArg> EndEditImage;

        public void OnEndEditImage(ImageEventArg e)
        {

            EventHandler<ImageEventArg> handler = EndEditImage;
            if (handler != null) handler(this, e);
            // this.ToolbarNavigationView = _ToolbarNavigationViewTemp;

        }

        [Category("Filmstrip events")]
        public event EventHandler<ImageEventArg> EditededImage;
        public void OnEditededImage(ImageEventArg e)
        {
            EventHandler<ImageEventArg> handler = EditededImage;
            if (handler != null) handler(this, e);
        }

        [Category("Filmstrip events")]
        public event EventHandler<ImageEventArg> SavedImage;

        public void OnSavedImage(ImageEventArg e)
        {
            EventHandler<ImageEventArg> handler = SavedImage;
            if (handler != null) handler(this, e);
        }

        [Category("Filmstrip events")]
        public event EventHandler<ImageEventArgs> SavedAllImage;

        public void OnSavedAllImage(ImageEventArgs e)
        {
            EventHandler<ImageEventArgs> handler = SavedAllImage;
            if (handler != null) handler(this, e);
        }

        [Category("Filmstrip events")]
        public event FilmStripBeforRemoveImageEventHandler BeforRemoveImage;

        public void OnBeforRemoveImage(ImageEventArgs e, ref bool checkremove)
        {
            FilmStripBeforRemoveImageEventHandler handler = BeforRemoveImage;
            if (handler != null) handler(this, e, ref checkremove);
        }

        [Category("Filmstrip events")]
        public event EventHandler<ImageEventArgs> RemovedImage;

        public void OnRemovedImage(ImageEventArgs e)
        {
            EventHandler<ImageEventArgs> handler = RemovedImage;
            if (handler != null) handler(this, e);
        }

        [Category("Filmstrip events")]
        public event EventHandler<ImageEventArgs> MovedImage;

        public void OnMovedImage(ImageEventArgs e)
        {
            EventHandler<ImageEventArgs> handler = MovedImage;
            if (handler != null) handler(this, e);
        }


        /// <summary>
        /// Event handler fired when the image selected in the filmstrip control changes.
        /// </summary>
        [Category("Filmstrip events")]
        [Description("Event handler fired when the image selected in the filmstrip control changes.")]
        public event EventHandler SelectionChanged;

        /// <summary>
        /// Event handler fired when the description of the image selected in the filmstrip control changes.
        /// </summary>
        [Category("Filmstrip events")]
        [Description("Event handler fired when the description of the image selected in the filmstrip control changes.")]
        public event EventHandler SelectedImageDescriptionChanged;

        #endregion Property Events

        private ToolStripButton tsbtnSlideShow;
        private ToolStripButton tsbtnEditImage;
        private ImageDocument _currentViewImage;
        public ImageDocumentEditor imageDocumentEditor1;
        private bool _ThumbnailsViewTemp;

        #region Properties
        public ImageDocument CurrentViewImage
        {
            get
            {
                if (BindingSource != null)
                {
                    return BindingSource.Current as ImageDocument;
                }
                return _currentViewImage;
            }
            set
            {
                if (_currentViewImage != value)
                {
                    _currentViewImage = value;
                    OnCurrenViewImageChanged(new ImageEventArg(value));
                }
            }
        }

        //ActiveTools _defalutActiveTools = ActiveTools.Pointer;
        //public ActiveTools DefalutActiveTools
        //{
        //    get { return _defalutActiveTools; }
        //    set
        //    {
        //        _defalutActiveTools = value;
        //        if (imageDocumentEditor1 != null) imageDocumentEditor1.ActiveTool = value;
        //    }
        //}

        bool _allowAllowFilip = false;

        public bool AllowFilip
        {
            get
            {
                return _allowAllowFilip;
            }
            set
            {
                _allowAllowFilip = value;
                ImageViewer.AllowFilip = value;
            }
        }

        bool _allowRotate = true;

        public bool AllowRotate
        {
            get { return _allowRotate; }
            set
            {
                _allowRotate = value;
                ImageViewer.AllowRotate = value;
            }
        }

        bool _allowMagnifair = false;

        public bool AllowMagnifair
        {
            get { return _allowMagnifair; }
            set
            {
                _allowMagnifair = value;
                ImageViewer.AllowMagnifair = value;

            }
        }

        private bool _allowOpenSave = true;
        public bool AllowOpenSaveImage
        {
            get
            {
                return _allowOpenSave;
            }
            set
            {
                _allowOpenSave = value;
                bindingImageNavigator1.AllowOpenSaveImage = value;
            }
        }

        private bool _allowPrint = true;
        public bool AllowPrint
        {
            get
            {
                return _allowPrint;
            }
            set
            {
                _allowPrint = value;
                bindingImageNavigator1.AllowPrint = value;
            }
        }

        bool _allowScanImage = false;
        public bool AllowScanImage
        {
            get
            {
                return _allowScanImage;
            }
            set
            {
                _allowScanImage = value;
                bindingImageNavigator1.AllowScanImage = value;
            }
        }

        private bool _allowZoom = true;
        public bool AllowZoom
        {
            get
            {
                return _allowZoom;
            }
            set
            {
                _allowZoom = value;
                ImageViewer.AllowZoom = value;
            }
        }


        bool _allowRemoveImage = true;
        public bool AllowRemoveImage
        {
            get
            {
                return _allowRemoveImage;
            }
            set
            {
                _allowRemoveImage = value;
                bindingImageNavigator1.AllowRemoveImage = value;
            }
        }

        public void AddImageRange(ImageDocuments imgs)
        {
            foreach (var imageDocument in imgs)
            {
                AddImage(imageDocument);
                //BindingSource.Add(imageDocument);
            }
        }

        bool _allowViewContinusePages = false;

        public bool AllowViewContinusePages
        {
            get { return _allowViewContinusePages; }
            set
            {
                _allowViewContinusePages = value;
                ImageViewer.AllowViewContinusePages = value;


            }
        }





        private bool _allowMoveImage = true;
        public bool AllowMoveImage
        {
            get
            {
                return _allowMoveImage;
            }
            set
            {
                _allowMoveImage = value;
                if (bindingImageNavigator1.Thumbnail != null) bindingImageNavigator1.Thumbnail.AllowMoveItem = value;
            }
        }



        private bool _AllowEditImage = false;
        public bool AllowEditImage
        {
            get
            {
                return _AllowEditImage;
            }
            set
            {
                _AllowEditImage = value;


                if (value)
                {
                    if (tsbtnEditImage == null)
                    {
                        tsbtnEditImage = new ToolStripButton();
                        // 
                        // tsbtnEditImage
                        // 
                        tsbtnEditImage.CheckOnClick = true;
                        tsbtnEditImage.Checked = false;
                        tsbtnEditImage.DisplayStyle = ToolStripItemDisplayStyle.Image;
                        tsbtnEditImage.Image = SbnImaging.Properties.Resources.image_edit;
                        tsbtnEditImage.ImageTransparentColor = Color.Magenta;
                        tsbtnEditImage.Size = new Size(23, 22);
                        tsbtnEditImage.Text = "ويرايش تصوير";
                        tsbtnEditImage.CheckedChanged += this.tsbtnEditImage_CheckedChanged;

                        bindingImageNavigator1.Items.Add(tsbtnEditImage);
                    }
                    else
                    {
                        tsbtnEditImage.Visible = true;
                    }
                }
                else
                {
                    if (tsbtnEditImage != null)
                    {
                        tsbtnEditImage.Visible = false;
                    }
                }

                // this.tsbtnEditImage.Visible = value;

            }

        }

        private bool _allowSlideView = false;
        public bool AllowSlideView
        {
            get { return _allowSlideView; }
            set
            {
                _allowSlideView = value;
                // tsbtnSlideShow.Visible = value;

                if (value)
                {
                    if (tsbtnSlideShow == null)
                    {
                        tsbtnSlideShow = new ToolStripButton();
                        // 
                        // tsbtnSlideShow
                        // 
                        tsbtnSlideShow.DisplayStyle = ToolStripItemDisplayStyle.Image;
                        // tsbtnSlideShow.Image = Properties.Resources._134_copy24;
                        tsbtnSlideShow.ImageTransparentColor = Color.Magenta;
                        tsbtnSlideShow.Text = " نمایش اسلاید";
                        tsbtnSlideShow.Click += new EventHandler(tsbtnSlideShow_Click);
                        bindingImageNavigator1.Items.Add(tsbtnSlideShow);
                    }
                    else
                        tsbtnSlideShow.Visible = true;
                }
                else
                {
                    if (tsbtnSlideShow != null)
                    {
                        this.tsbtnSlideShow.Visible = false;
                    }
                }


            }
        }

        void tsbtnSlideShow_Click(object sender, EventArgs e)
        {

        }

        bool _ThumbnailsView = true;
        public bool ThumbnailsView
        {
            get
            {
                return _ThumbnailsView;
            }
            set
            {
                _ThumbnailsView = value;

                if ((thumbnailList1.Parent as SplitterPanel) != null)
                {
                    if ((thumbnailList1.Parent as SplitterPanel) == splitContainer1.Panel2)
                        splitContainer1.Panel2Collapsed = !value;

                    if ((thumbnailList1.Parent as SplitterPanel) == splitContainer1.Panel1)
                        splitContainer1.Panel1Collapsed = !value;
                }



                // this.panelNavigation.Visible = value;

                //switch (ThumbsStripLocation)
                //{
                //    case StripLocation.Left:
                //        this.splitContainer1.Panel1Collapsed = !value;
                //        break;

                //    case StripLocation.Bottom:
                //        this.splitContainer1.Panel2Collapsed = !value;
                //        break;
                //    case StripLocation.Right:
                //        this.splitContainer1.Panel2Collapsed = !value;
                //        break;
                //    case StripLocation.Top:
                //        this.splitContainer1.Panel1Collapsed = !value;
                //        break;

                //    default:
                //        break;
                //}

            }
        }


        private ImageDocumentBindingSource _bindingSource;

        /// <summary>
        /// Gets or sets the <see cref="T:System.Windows.Forms.BindingSource"/> component that is the source of data.
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// The <see cref="T:System.Windows.Forms.BindingSource"/> component associated with this <see cref="T:System.Windows.Forms.BindingNavigator"/>. The default is null.
        /// 
        /// </returns>
        [TypeConverter(typeof(ReferenceConverter))]
        [DefaultValue(null)]
        public ImageDocumentBindingSource BindingSource
        {
            get { return _bindingSource; }
            set
            {
                _bindingSource = value;
                bindingImageNavigator1.BindingSource = value;
                thumbnailList1.BindingSource = value;
                ImageViewer.BindingSource = value;
                value.AllowDuplicateFileNames = true;

                if (value != null)
                {

                    value.PrintPage += BindingSource_PrintPage;
                    value.NeedImage += BindingSource_NeedImage;
                    value.StartPrint += BindingSource_StartPrint;
                    value.PrintedImages += BindingSource_PrintedImages;
                    value.BeforPrintPage += BindingSource_BeforPrintPage;
                    value.AddedImage += BindingSource_AddedImage;
                    value.CurrentChanged += BindingSource_CurrentChanged;
                    value.ListChanged += BindingSource_ListChanged;
                    value.BeforRemoveImage += BindingSource_BeforRemoveImage;
                    value.RemovedImage += BindingSource_RemovedImage;
                    value.MovedImages += BindingSource_MovedImages;
                    value.AllowDuplicateFileNamesChenged += value_AllowDuplicateFileNamesChenged;
                    value.CurrentImageTools = CurrentImageTools;

                }


            }
        }

        void value_AllowDuplicateFileNamesChenged(object sender, EventArgs e)
        {
            if (thumbnailList1 != null)
                thumbnailList1.AllowDuplicateFileNames = BindingSource.AllowDuplicateFileNames;
        }

        #endregion Properties


        public ImageDocumentsManager()
        {

            InitializeComponent();

            ImageViewer.NeedImage += BindingSource_NeedImage;
            thumbnailList1.NeedThumbnailsImage += thumbnailList1_NeedThumbnailsImage;
            thumbnailList1.CreatedThumbnailImage += thumbnailList1_CreatedThumbnailImage;


            BindingSource = new ImageDocumentBindingSource();
            CurrentImageTools.NeedImage += BindingSource_NeedImage;

            RightToLeft = RightToLeft.No;

        }

        void BindingSource_MovedImages(object sender, ImageEventArgs e)
        {
            OnMovedImage(e);
        }

        void thumbnailList1_CreatedThumbnailImage(object sender, ImageEventArg e)
        {
            OnCreatedThumbnailImage(e);
        }


        void BindingSource_RemovedImage(object sender, ImageEventArgs e)
        {
            OnRemovedImage(e);
        }

        void BindingSource_BeforRemoveImage(object sender, ImageEventArgs e, ref bool checkRemove)
        {
            OnBeforRemoveImage(e, ref checkRemove);
        }

        void BindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemDeleted)
            {

            }
            if (e.ListChangedType == ListChangedType.Reset)
            {

            }
        }

        void BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            OnCurrenViewImageChanged(new ImageEventArg(BindingSource.Current as ImageDocument));
        }

        void BindingSource_AddedImage(object sender, ImageEventArgs e)
        {
            OnAddedImage(e);
        }

        void BindingSource_BeforPrintPage(object sender, ImageEventArg e)
        {
            OnBeforPrintPage(e);
        }

        void BindingSource_PrintedImages(object sender, PrintDocEventArgs e)
        {
            OnPrintedImages(e);
        }

        void BindingSource_StartPrint(object sender, PrintDocEventArgs e)
        {
            OnStartPrint(e);
        }

        void thumbnailList1_NeedThumbnailsImage(object sender, ImageEventArg e)
        {
            OnNeedThumbnailsImage(e);
        }

        void BindingSource_NeedImage(object sender, ImageEventArg e)
        {
            OnNeedImage(e);
        }

        void BindingSource_PrintPage(object sender, PrintDocEventArgs e)
        {
            OnPrintPage(e);
        }

        public virtual void OnEndEditImage()
        {
            this.ThumbnailsView = _ThumbnailsViewTemp;
            bindingImageNavigator1.Visible = true;
            ImageViewer.BringToFront();

        }

        void imageDocumentEditor1_OnCancel(object sender, EventArgs e)
        {
            OnEndEditImage();
            OnEndEditImage(new ImageEventArg(BindingSource.Current as ImageDocument));
            // imageDocumentEditor1.drawingPanel1.Delete();
            tsbtnEditImage.Checked = false;
            if (imageDocumentEditor1.DrawLine != null)
            {
                imageDocumentEditor1.DrawLine.group = new Sbn.FramWork.Drawing.CompositeShape();
            }


            imageDocumentEditor1.Clear();





        }

        void imageDocumentEditor1_OnApplay(object sender, EventArgs e)
        {
            this.tsbtnEditImage.Checked = false;
            if (this.CurrentViewImage == null)
            {
                ImageDocument newimg = imageDocumentEditor1.GetImage() as ImageDocument;                
                this.CurrentViewImage = newimg;
            }
            else
            {
                ImageDocument ff = imageDocumentEditor1.GetImage();
                CurrentViewImage.layers = ff.layers;
                CurrentViewImage.Stream = ff.Stream;

                ImageViewer.RefreshCurrent();
            }

            try
            {
                CurrentViewImage.ThumbnailStream = CurrentImageTools.GetThumbnailStream(CurrentViewImage.Stream, this.thumbnailList1.ThumbnailSize.Width, this.thumbnailList1.ThumbnailSize.Height, 1.0);

                OnCreatedThumbnailImage(new ImageEventArg(CurrentViewImage));
            }
            catch (Exception) { }

            OnEditededImage(new ImageEventArg(CurrentViewImage));
            OnEndEditImage(new ImageEventArg(CurrentViewImage));
            OnEndEditImage();

            imageDocumentEditor1.Clear();
        }

        private void tsbtnEditImage_CheckedChanged(object sender, EventArgs e)
        {
            if (BindingSource.Current == null)
                return;

            if (tsbtnEditImage.Checked)
            {
                if (imageDocumentEditor1 == null)
                {
                    imageDocumentEditor1 = new ImageDocumentEditor();
                    ImageViewer.Parent.Controls.Add(imageDocumentEditor1);
                    imageDocumentEditor1.Dock = DockStyle.Fill;

                    imageDocumentEditor1.drawingPanel1.Shapes.InsertedItem += new Sbn.FramWork.Drawing.ShapeCollection.OnInsertedItem(Shapes_InsertedItem);
                    imageDocumentEditor1.OnApplay += imageDocumentEditor1_OnApplay;
                    imageDocumentEditor1.OnCancel += imageDocumentEditor1_OnCancel;

                }


                OnStartEditImage();
                OnStartEditImage(new ImageEventArg(BindingSource.Current as ImageDocument));
                this.imageDocumentEditor1.drawingPanel1.ZoomFactor = 1;

                imageDocumentEditor1.CurrentImage = BindingSource.Current as ImageDocument;
                imageDocumentEditor1.drawingPanel1.Zoom = (float)this.ImageViewer.sbnPictureBox1.Zoom;
                // this.imageDocumentEditor1.drawingPanel1.FitToWidth();
                imageDocumentEditor1.Refresh();
                imageDocumentEditor1.BringToFront();
            }
            else
            {
                ImageViewer.BringToFront();
            }
        }

        private void Shapes_InsertedItem(IShape shape, int index)
        {


        }

        //private void filmstripImageViewer1_NeedImage(object sender, ImageEventArg e)
        //{
        //    OnNeedThumbnailsImage(e);
        //}


        //################################################


        public bool IsEditMode
        {
            get
            {
                if (tsbtnEditImage != null)
                    return tsbtnEditImage.Checked;
                else
                    return false;


            }
            set
            {
                if (tsbtnEditImage != null)
                    tsbtnEditImage.Checked = value;
            }
        }


        public bool IsContinusePagesMode
        {
            get
            {
                if (ImageViewer != null)
                    return ImageViewer.ViewContinusePages;
                return false;
            }
            set
            {
                bindingImageNavigator1.tsbtnShowContinusPages.Checked = value;
                if (ImageViewer != null)
                    ImageViewer.ViewContinusePages = value;
            }
        }



        bool _allowVerticalHorizontal = false;

        public bool AllowVerticalHorizontal
        {
            get
            {
                return _allowVerticalHorizontal;
            }
            set
            {
                _allowVerticalHorizontal = value;
                bindingImageNavigator1.AllowFilipVerticalHorizontal = value;

            }
        }

        bool _allowMeargeImage = false;

        public bool AllowMeargeImage
        {
            get { return _allowMeargeImage; }
            set
            {
                _allowMeargeImage = value;
                bindingImageNavigator1.AllowMeargeImage = value;

            }
        }



        StripLocation _ThumbsStripLocation = StripLocation.Bottom;
        public StripLocation ThumbsStripLocation
        {
            get { return _ThumbsStripLocation; }
            set
            {
                _ThumbsStripLocation = value;


                try
                {
                    // Also change the dock syle of the thumbs strip and the main picture location
                    switch (value)
                    {
                        case StripLocation.Bottom:
                            if (imageDocumentEditor1 != null)
                            {
                                imageDocumentEditor1.Parent = splitContainer1.Panel1;
                                //imageDocumentEditor1.Dock = DockStyle.Fill;
                            }
                            if (ImageViewer != null)
                            {
                                ImageViewer.Parent = splitContainer1.Panel1;
                                // filmstripImageViewer1.Dock = DockStyle.Fill;
                            }


                            bindingImageNavigator1.Parent = splitContainer1.Panel1;
                            bindingImageNavigator1.Dock = DockStyle.Bottom;
                            thumbnailList1.Parent = splitContainer1.Panel2;
                            splitContainer1.FixedPanel = FixedPanel.Panel2;
                            splitContainer1.SplitterDistance = splitContainer1.Height - thumbnailList1.ThumbnailSize.Height - 45;
                            this.splitContainer1.Orientation = Orientation.Horizontal;
                            break;
                        case StripLocation.Top:
                            if (imageDocumentEditor1 != null)
                            {
                                imageDocumentEditor1.Parent = splitContainer1.Panel2;
                                //imageDocumentEditor1.Dock = DockStyle.Fill;
                            }
                            if (ImageViewer != null)
                            {
                                ImageViewer.Parent = splitContainer1.Panel2;
                                // filmstripImageViewer1.Dock = DockStyle.Fill;
                            }

                            thumbnailList1.Parent = splitContainer1.Panel1;
                            bindingImageNavigator1.Parent = splitContainer1.Panel2;
                            // bindingImageNavigator1.Dock = DockStyle.Bottom;

                            splitContainer1.FixedPanel = FixedPanel.Panel1;
                            splitContainer1.SplitterDistance = thumbnailList1.ThumbnailSize.Height + 45;

                            this.splitContainer1.Orientation = Orientation.Horizontal;
                            break;
                        case StripLocation.Left:
                            if (imageDocumentEditor1 != null)
                            {
                                imageDocumentEditor1.Parent = splitContainer1.Panel2;
                                //imageDocumentEditor1.Dock = DockStyle.Fill;
                            }
                            if (ImageViewer != null)
                            {
                                ImageViewer.Parent = splitContainer1.Panel2;
                                // filmstripImageViewer1.Dock = DockStyle.Fill;
                            }



                            bindingImageNavigator1.Parent = splitContainer1.Panel2;
                            bindingImageNavigator1.Dock = DockStyle.Bottom;
                            thumbnailList1.Parent = splitContainer1.Panel1;


                            splitContainer1.FixedPanel = FixedPanel.Panel1;


                            splitContainer1.SplitterDistance = thumbnailList1.ThumbnailSize.Width + 40;
                            if (thumbnailList1.vScrollBar.Visible)
                            {
                                splitContainer1.SplitterDistance += 5;
                            }
                            this.splitContainer1.Orientation = Orientation.Vertical;
                            break;
                        case StripLocation.Right:
                            if (imageDocumentEditor1 != null)
                            {
                                imageDocumentEditor1.Parent = splitContainer1.Panel1;
                                //imageDocumentEditor1.Dock = DockStyle.Fill;
                            }
                            if (ImageViewer != null)
                            {
                                ImageViewer.Parent = splitContainer1.Panel1;
                                // filmstripImageViewer1.Dock = DockStyle.Fill;
                            }

                            thumbnailList1.Parent = splitContainer1.Panel2;
                            bindingImageNavigator1.Parent = splitContainer1.Panel1;
                            bindingImageNavigator1.Dock = DockStyle.Bottom;
                            splitContainer1.FixedPanel = FixedPanel.Panel2;
                            this.splitContainer1.Orientation = Orientation.Vertical;
                            splitContainer1.SplitterDistance = splitContainer1.Width - thumbnailList1.ThumbnailSize.Width - 40;
                            if (thumbnailList1.vScrollBar.Visible)
                            {
                                splitContainer1.SplitterDistance -= 5;
                            }
                            break;
                        default:
                            // Do nothing
                            break;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }


                if (!IsEditMode)
                {
                    if (ImageViewer != null)
                    {
                        ImageViewer.BringToFront();
                        // filmstripImageViewer1.Dock = DockStyle.Fill;
                    }
                }

                //  ThumbsStripHeight = 150;
            }
        }

        private bool _allowNavigator = true;
        public bool AllowNavigator
        {
            get
            {
                return _allowNavigator;
            }
            set
            {
                _allowNavigator = value;
                bindingImageNavigator1.AllowNavigator = value;
            }
        }


        public void ClearAll()
        {
            if (imageDocumentEditor1 != null) imageDocumentEditor1.drawingPanel1.ClearImage();
            if (BindingSource != null) BindingSource.Clear();
            if (thumbnailList1 != null) thumbnailList1.Items.Clear();
            ImageViewer.ClearAll();
        }

        public virtual void OnStartEditImage()
        {
            // this.htfImageTool1.ZoomMode = Sbn.AdvancedControls.Imaging.ImageViewer.ZoomMode.PageWidth;//.FitToWidth();
            _ThumbnailsViewTemp = _ThumbnailsView;
            bindingImageNavigator1.Visible = false;
            //_ToolbarNavigationViewTemp = _toolbarNavigationView;
            this.ThumbnailsView = false;
            //  this.ToolbarNavigationView = false;
        }


        public void SetEditMode()
        {
            if (AllowEditImage)
            {
                IsEditMode = true;
            }
            //tsbtnEditImage.Checked = true;
        }



        public Shape AddLayer(Image img, PointF point)
        {
            var shape = imageDocumentEditor1.drawingPanel1.CreateShape(img);
            shape.Dimension = imageDocumentEditor1.drawingPanel1.GetActualSize(shape.Dimension);
            shape.Location = imageDocumentEditor1.drawingPanel1.GetActualPoint(point);
            imageDocumentEditor1.drawingPanel1.Shapes.Add(shape);
            return shape;
            //return imageDocumentEditor1.drawingPanel1.AddImage(img , point);
        }

        public Shape AddLayer(string txt, PointF point, Font font)
        {
            var shape = imageDocumentEditor1.drawingPanel1.CreateShape(txt, font);
            shape.Dimension = imageDocumentEditor1.drawingPanel1.GetActualSize(shape.Dimension);
            shape.Location = imageDocumentEditor1.drawingPanel1.GetActualPoint(point);
            imageDocumentEditor1.drawingPanel1.Shapes.Add(shape);

            return shape;

            //return imageDocumentEditor1.drawingPanel1.AddText(txt, point,font);
        }

        /// <summary>
        /// Adds an image to the collection
        /// </summary>
        /// <param name="newImage">Images to add to the collection.</param>
        /// <returns>The ID value of the added image.
        /// If the orginally supplied id value was negative then a new ID value is created.</returns>
        /// <exception cref="ArgumentException">System.SystemException.ArgumentException - 
        /// if any of the image ids already exist in the collection</exception>
        public void AddImage(ImageDocument image)
        {
            if (image.GUid.Equals(Guid.Empty))
                image.GUid = Guid.NewGuid();

            BindingSource.Add(image);


            //  thumbnailList1.AddImage(image);
        }

        /// <summary>
        /// Adds a collection of images to the collection
        /// </summary>
        /// <param name="images">Array of images to add to the collection.</param>
        /// <exception cref="ArgumentException">System.SystemException.ArgumentException - 
        /// if any of the image ids already exist in the collection</exception>
        public void AddImageRange(ImageDocument[] images)
        {
            foreach (var baseImage in images)
            {
                AddImage(baseImage);
                //BindingSource.Add(baseImage);
            }

            // thumbnailList1.AddImageRange(images);


            //if (tsbtnShowContinusPages.Checked)
            //{
            //    RefreshImageListViewer();
            //}

            // Fire the event
            //            ImageAdded handler = AddedImage;

        }


        public virtual bool OnSaveImage()
        {
            //  saveFileDialog1.CreatePrompt = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bool CheckSaved = false;
                string strPath = saveFileDialog1.FileName;

                if (Path.GetExtension(strPath) == ".xml")
                {
                    (BindingSource.Current as ImageDocument).Save(Path.GetDirectoryName(strPath));
                    CheckSaved = true;
                }


                if (!CheckSaved)
                {

                    var img = CurrentImageTools.GetWholeImage(BindingSource.Current as ImageDocument);
                    if (img != null)
                        img.Save(saveFileDialog1.FileName);

                }

            }

            return true;
        }



        public virtual bool OnSaveAllImage()
        {
            if (this.BindingSource == null || this.BindingSource.Count == 0)
                return false;
            //else
            //{
            //    foreach (ImageDocument img in this.BindingSource)
            //    {

            //       CurrentImageTools.InitialImage(img);
            //    }
            //}

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                bool Check = false;

                string strPath = Path.GetDirectoryName(saveFileDialog1.FileName);
                string strFileNameFull = Path.GetFileName(saveFileDialog1.FileName);
                string strFileFormat = strFileNameFull.Split('.')[1];
                string strFileName = strFileNameFull.Split('.')[0];


                string strTempPath = saveFileDialog1.FileName;


                if (Path.GetExtension(strTempPath) == ".tif" || Path.GetExtension(strTempPath) == ".tiff")
                {
                    try
                    {
                        // Image[] Allimg = new Image[BindingSource.Count];


                        try
                        {

                            ImageCodecInfo codecInfo = CurrentImageTools.BaseTools.getCodecForstring("TIFF");

                            File.Delete(strTempPath);

                            if (BindingSource.Count == 1)
                            {
                                using (Image bmp = CurrentImageTools.GetWholeImage(BindingSource[0] as ImageDocument))
                                {
                                    if (bmp != null)
                                    {
                                        EncoderParameters iparams = new EncoderParameters(1);
                                        System.Drawing.Imaging.Encoder iparam =
                                            System.Drawing.Imaging.Encoder.Compression;
                                        EncoderParameter iparamPara = new EncoderParameter(iparam,
                                                                                           (long)
                                                                                           (EncoderValue.
                                                                                               CompressionCCITT4));
                                        iparams.Param[0] = iparamPara;
                                        bmp.Save(strTempPath, codecInfo, iparams);
                                        bmp.Dispose();
                                    }
                                }

                                Check = true;

                            }
                            else if (BindingSource.Count > 1)
                            {

                                System.Drawing.Imaging.Encoder saveEncoder;
                                System.Drawing.Imaging.Encoder compressionEncoder;

                                EncoderParameter SaveEncodeParam;
                                EncoderParameter CompressionEncodeParam;

                                EncoderParameters EncoderParams = new EncoderParameters(2);

                                saveEncoder = System.Drawing.Imaging.Encoder.SaveFlag;
                                compressionEncoder = System.Drawing.Imaging.Encoder.Compression;

                                // Save the first page (frame).
                                SaveEncodeParam = new EncoderParameter(saveEncoder, (long)EncoderValue.MultiFrame);
                                CompressionEncodeParam = new EncoderParameter(compressionEncoder, (long)EncoderValue.CompressionCCITT4);

                                EncoderParams.Param[0] = CompressionEncodeParam;
                                EncoderParams.Param[1] = SaveEncodeParam;

                                using (Image finalImage = CurrentImageTools.BaseTools.ConvertToBitonal(CurrentImageTools.GetWholeImage(BindingSource[0] as ImageDocument)))
                                {
                                    if (finalImage != null)
                                    {
                                        // finalImage = (Image)CurrentImageTools.BaseTools.ConvertToBitonal((Bitmap)finalImage);
                                        finalImage.Save(strTempPath, codecInfo, EncoderParams);
                                        for (int i = 1; i < BindingSource.Count; i++)
                                        {

                                            using (Image imgPage = CurrentImageTools.BaseTools.ConvertToBitonal(CurrentImageTools.GetWholeImage(BindingSource[i] as ImageDocument)))
                                            {
                                                if (imgPage == null)
                                                    continue;

                                                // imgPage = (Image)CurrentImageTools.BaseTools.ConvertToBitonal((Bitmap)imgPage);

                                                SaveEncodeParam = new EncoderParameter(saveEncoder,
                                                                                       (long)
                                                                                       EncoderValue.FrameDimensionPage);
                                                CompressionEncodeParam = new EncoderParameter(compressionEncoder,
                                                                                              (long)
                                                                                              EncoderValue.
                                                                                                  CompressionCCITT4);
                                                EncoderParams.Param[0] = CompressionEncodeParam;
                                                EncoderParams.Param[1] = SaveEncodeParam;
                                                finalImage.SaveAdd(imgPage, EncoderParams);
                                                imgPage.Dispose();
                                            }



                                        }

                                        SaveEncodeParam = new EncoderParameter(saveEncoder, (long)EncoderValue.Flush);
                                        EncoderParams.Param[0] = SaveEncodeParam;

                                        finalImage.SaveAdd(EncoderParams);
                                        finalImage.Dispose();
                                    }
                                }


                                Check = true;


                            }



                        }
                        catch (System.Exception ee)
                        {

                        }

                    }
                    catch
                    { }

                }


                if (!Check)
                {

                    foreach (ImageDocument img in BindingSource)
                    {
                        strTempPath = strPath + "\\" + strFileName + img.OrderInDocument + "." + strFileFormat;

                        try
                        {
                            if (Path.GetExtension(strTempPath) == ".xml")
                            {
                                img.Save(strTempPath);
                                Check = true;
                            }
                            else
                            {
                                using (Image fImgTemp = CurrentImageTools.GetWholeImage(img))
                                {
                                    if (fImgTemp != null)
                                    {
                                        //Image imgTemp = (Image)ConvertToBitonal((Bitmap)fImgTemp);
                                        fImgTemp.Save(strTempPath);
                                        Check = true;
                                        fImgTemp.Dispose();

                                    }
                                }


                            }
                        }
                        catch
                        {

                        }
                    }
                }
            }

            return true;
        }

        private void bindingImageNavigator1_SavedImage(object sender, ImageEventArg e)
        {
            OnSaveImage();

            OnSavedImage(e);


        }

        private void bindingImageNavigator1_SavedAllImage(object sender, ImageEventArgs e)
        {

            OnSaveAllImage();

            OnSavedAllImage(e);



        }

        private void bindingImageNavigator1_RotateAntiClockWise(object sender, ImageEventArg e)
        {
            if (!ImageViewer.ViewContinusePages)
                ImageViewer.sbnPictureBox1.RotateImage(false);
        }

        private void bindingImageNavigator1_RotateClockWise(object sender, ImageEventArg e)
        {
            if (!ImageViewer.ViewContinusePages)
                ImageViewer.sbnPictureBox1.RotateImage(true);
        }

        private void bindingImageNavigator1_FilipHorizontal(object sender, ImageEventArg e)
        {
            if (!ImageViewer.ViewContinusePages)
                ImageViewer.sbnPictureBox1.FlipImage(false);
        }

        private void bindingImageNavigator1_FilipVertical(object sender, ImageEventArg e)
        {
            if (!ImageViewer.ViewContinusePages)
                ImageViewer.sbnPictureBox1.FlipImage(true);
        }

        private void thumbnailList1_MovedItems(object sender, AdvancedControls.Imaging.ThumbnailControl.MovedItemsEventArgs e)
        {
            e.Cancel = true;

            int i = 0;

            if (!e.DropToRight)
                e.Items.Reverse();

            foreach (var imageListViewItem in e.Items)
            {
                i = e.Index;

                if (e.DropToRight && !e.MdropToAfterEndItem)
                {
                    i--;
                }

                BindingSource.Move(imageListViewItem.Tag, i);
                thumbnailList1.Refresh();
            }



        }




    }

    public enum StripLocation
    {
        Top = 1,
        Bottom = 2,
        Left = 3,
        Right = 4
    };
}
