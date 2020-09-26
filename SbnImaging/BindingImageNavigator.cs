using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing.Printing;

using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Sbn.Controls.Imaging.EventArgsFolder;
using Sbn.Controls.Imaging.Graphic;
using Sbn.Controls.Imaging.ImagingObject;


namespace Sbn.Controls.Imaging
{
    public partial class BindingImageNavigator : ToolStrip
    {
        


        [Category("Filmstrip events")]
        public event EventHandler<ImageEventArg> RotateAntiClockWise;

        public void OnRotateAntiClockWise(ImageEventArg e)
        {
            EventHandler<ImageEventArg> handler = RotateAntiClockWise;
            if (handler != null) handler(this, e);
        }

        [Category("Filmstrip events")]
        public event EventHandler<ImageEventArg> RotateClockWise;

        public void OnRotateClockWise(ImageEventArg e)
        {
            EventHandler<ImageEventArg> handler = RotateClockWise;
            if (handler != null) handler(this, e);
        }

        [Category("Filmstrip events")]
        public event EventHandler<ImageEventArg> FilipVertical;

        public void OnFilipVertical(ImageEventArg e)
        {
            EventHandler<ImageEventArg> handler = FilipVertical;
            if (handler != null) handler(this, e);
        }

        [Category("Filmstrip events")]
        public event EventHandler<ImageEventArg> FilipHorizontal;

        public void OnFilipHorizontal(ImageEventArg e)
        {
            EventHandler<ImageEventArg> handler = FilipHorizontal;
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
                tsbtnOpen.Visible = value;
                tsbtnSave.Visible = value;
                tsbtnSaveAs.Visible = value;
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
                tsbtnPrint.Visible = value;
                //if (value == false && tsbtnScan.Visible == false)
                //{
                //    toolStripSeparator6.Visible = false;
                //}
                //else
                //{
                //    toolStripSeparator6.Visible = true;
                //}

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
                tsbtnScan.Visible = value;

                //if (value == false && tsmnuItmPrint.Visible == false)
                //{
                //    toolStripSeparator6.Visible = false;
                //}
                //else
                //{
                //    toolStripSeparator6.Visible = true;
                //}
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
                tsbtnRemoveItem.Visible = value;

            }
        }


        SbnImageTools CurrentImageTools = new SbnImageTools();

        private ImageDocumentsViewer _imageViewer;
       // [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ImageDocumentsViewer ImageViewer
        {
            get { return _imageViewer; }
            set
            {
                _imageViewer = value;
                if (value != null)
                {
                    _imageViewer.PropertyChanged += _imageViewer_PropertyChanged;
                    tsRotateAntiClockWise.Visible = ImageViewer.AllowRotate;
                    tsRotateClockWise.Visible = ImageViewer.AllowRotate;
                    tsbtnFilipHorizontal.Visible = ImageViewer.AllowFilip;
                    tsbtnFilipVertical.Visible = ImageViewer.AllowFilip;
                    magifierToolsTripButton1.Visible = ImageViewer.AllowMagnifair;
                    tsmnuItmZoomIn.Visible = ImageViewer.AllowZoom;
                    tsmnuItmZoomOut.Visible = ImageViewer.AllowZoom;
                    tsbtnItmFitWidth.Visible = ImageViewer.AllowZoom;
                    tsbtnItmActualSize.Visible = ImageViewer.AllowZoom;
                    tsbtnItmWhole.Visible = ImageViewer.AllowZoom;
                    tsbtnShowContinusPages.Visible = ImageViewer.AllowViewContinusePages;
                }
                else
                {
                    tsRotateAntiClockWise.Visible = false;
                    tsRotateClockWise.Visible = false;
                    tsbtnFilipHorizontal.Visible = false;
                    tsbtnFilipVertical.Visible = false;
                    magifierToolsTripButton1.Visible = false;
                    tsmnuItmZoomIn.Visible = false;
                    tsmnuItmZoomOut.Visible = false;
                    tsbtnItmFitWidth.Visible = false;
                    tsbtnItmActualSize.Visible = false;
                    tsbtnItmWhole.Visible = false;
                    tsbtnShowContinusPages.Visible = false;
                }
            }
        }

        void _imageViewer_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "AllowFilip":
                    tsbtnFilipHorizontal.Visible = ImageViewer.AllowFilip;
                    tsbtnFilipVertical.Visible = ImageViewer.AllowFilip;
                    break;
                case "AllowRotate":
                    tsRotateAntiClockWise.Visible = ImageViewer.AllowRotate;
                    tsRotateClockWise.Visible = ImageViewer.AllowRotate;
                    break;
                case "AllowMagnifair":
                    magifierToolsTripButton1.Visible = ImageViewer.AllowMagnifair;
                    break;
                case "AllowZoom":
                    tsmnuItmZoomIn.Visible = ImageViewer.AllowZoom;
                    tsmnuItmZoomOut.Visible = ImageViewer.AllowZoom;
                    tsbtnItmFitWidth.Visible = ImageViewer.AllowZoom;
                    tsbtnItmActualSize.Visible = ImageViewer.AllowZoom;
                    tsbtnItmWhole.Visible = ImageViewer.AllowZoom;
                    break;
                case "AllowViewContinusePages":
                    tsbtnShowContinusPages.Visible = ImageViewer.AllowViewContinusePages;

                   // if (tsbtnShowContinusPages.Visible)
                        tsbtnShowContinusPages.Checked = ImageViewer.ViewContinusePages;
                    
                    break;
                    

                default:
                    break;
            }
        }

        private ImageDocumentEditor _imageEditor;
        [DefaultValue(null)]
        public ImageDocumentEditor ImageEditor
        {
            get { return _imageEditor; }
            set { _imageEditor = value; }
        }

        private ThumbnailList _thumbnail;
        [DefaultValue(null)]
      // [System.ComponentModel.Localizable(false)]
      // [TypeConverter(typeof(ExpandableObjectConverter))]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ThumbnailList Thumbnail
        {
            get { return _thumbnail; }
            set
            {
                _thumbnail = value;

                if (value != null)
                {
                    _thumbnail.PropertyChanged += _thumbnail_PropertyChanged;
                    tsbtnMoveBack.Visible = Thumbnail.AllowMoveItem;
                    tsbtnMoveNext.Visible = Thumbnail.AllowMoveItem;
                }
                else
                {
                    tsbtnMoveBack.Visible = false;
                    tsbtnMoveNext.Visible = false;
                }
            }
        }


      

        void _thumbnail_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "AllowMoveItem":
                    tsbtnMoveBack.Visible = Thumbnail.AllowMoveItem;
                    tsbtnMoveNext.Visible = Thumbnail.AllowMoveItem;
                    break;

                    default:
                    break;
            }
        }

        

        public BindingImageNavigator()
        {
            InitializeComponent();

            
            tsbtnOpen.Click += tsbtnOpen_Click;
            tsbtnSave.Click += tsbtnSave_Click;
            tsbtnSaveAs.Click += tsbtnSaveAs_Click;

            tsbtnRemoveItem.Click += tsbtnRemoveItem_Click;
            tsbtnRemoveAllItems.Click += tsbtnRemoveAllItems_Click;
            tsbtnScan.Click += tsbtnScan_Click;
            tsbtnPrint.Click += tsbtnPrint_Click;


            tsbtnGoToFirstItem.Click += tsbtnGoToFirstItem_Click;
            tsbtnGoToLastItem.Click += tsbtnGoToLastItem_Click;
            tscmbNavigateItems.KeyDown += tscmbNavigateItems_KeyDown;
            tscmbNavigateItems.DropDownWidth = tscmbNavigateItems.Width;
            tscmbNavigateItems.ComboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            
            
            tsbtnGoToNextItem.Click += tsbtnGoToNextItem_Click;
            tsbtnGotoPrevItem.Click += tsbtnGotoPrevItem_Click;
           
            tsbtnMoveBack.Click += tsbtnMoveBack_Click;
            tsbtnMoveNext.Click += tsbtnMoveNext_Click;

            tsmnuItmZoomIn.Click += tsmnuItmZoomIn_Click;
            tsmnuItmZoomOut.Click += tsmnuItmZoomOut_Click;

            tsbtnItmFitWidth.Click += tsbtnItmFitWidth_Click;
            tsbtnItmWhole.Click += tsbtnItmWhole_Click;
            tsbtnItmActualSize.Click += tsbtnItmActualSize_Click;
            tsbtnShowContinusPages.CheckOnClick = true;
            tsbtnShowContinusPages.CheckedChanged += tsbtnShowContinusPages_CheckedChanged;

            tsRotateAntiClockWise.Click += tsRotateAntiClockWise_Click;
            tsRotateClockWise.Click += tsRotateClockWise_Click;

            tsbtnFilipHorizontal.Click += tsbtnFilipHorizontal_Click;
            tsbtnFilipVertical.Click += tsbtnFilipVertical_Click;
        }

        void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (tscmbNavigateItems.SelectedItem == null)
                return;


          if ( BindingSource.RaiseListChangedEvents)
                BindingSource.Position =  (tscmbNavigateItems.SelectedItem as ImageDocument).OrderInDocument - 1;
        }

      

    

        public void PopulateImagesCombo()
        {
            if (BindingSource == null)
                return;
            tscmbNavigateItems.ComboBox.ResetBindings();
            tscmbNavigateItems.ComboBox.DataSource = null;
            tscmbNavigateItems.ComboBox.DataSource = BindingSource.List;
            tscmbNavigateItems.ComboBox.DisplayMember = "OrderInDocument";
          //  tscmbNavigateItems.ComboBox.Text = (BindingSource.Position + 1) + "/" + BindingSource.Count;
            return;

            tscmbNavigateItems.ComboBox.DataSource = null;
            tscmbNavigateItems.Items.Clear();

            // Add 'No selection' to clear selection
            //  tsItmcomboImages.Items.Add(NO_SELECTION);
            
            foreach (ImageDocument image in this.BindingSource)
            {
                //tsItmcomboImages.Items.Add(image.Id);
                //int kk = keys.IndexOf(image.Counter) + 1;
                tscmbNavigateItems.ComboBox.Items.Add(image.OrderInDocument + "/" + BindingSource.Count);
                
            }

         //   tscmbNavigateItems.ComboBox.Text = (BindingSource.Position + 1) + "/" + BindingSource.Count;

            if (BindingSource != null)
            {
               

                //if (this.tsItmcomboImages.ComboBox.SelectedIndex > 0)
                //{
                //    this.SelectedImageID = keys[this.tsItmcomboImages.ComboBox.SelectedIndex];// Int32.Parse(this.tsItmcomboImages.ComboBox.SelectedItem.ToString());
                //    tsItmcomboImages.ComboBox.Text = (keys.IndexOf(SelectedImage.Counter) + 1).ToString() + "/" + this.ImagesCollection.Length;
                //}
                //else
                //{

                //    tsItmcomboImages.ComboBox.Text = "1" + "/" + this.ImagesCollection.Length;
                //}

            }

        }

      

        void tscmbNavigateItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    long order ;
                   if(long.TryParse(tscmbNavigateItems.ComboBox.Text, System.Globalization.NumberStyles.Number, null, out order))
                   {
                       if (order > 0)
                        BindingSource.Position = (int) (order - 1);
                   }
                }
                catch
                {
                    
                }
            }
        }

        void tsbtnSaveAs_Click(object sender, EventArgs e)
        {

            if (BindingSource != null && BindingSource.Count > 0)
            {
                Collection<ImageDocument> All = new Collection<ImageDocument>();
                foreach (var itm in BindingSource)
                {
                    if (itm is ImageDocument)
                    {
                        All.Add(itm as ImageDocument);
                    }
                }

                OnSavedAllImage(new ImageEventArgs(All));
            }
               

           
        }

        void tsbtnSave_Click(object sender, EventArgs e)
        {
            if (BindingSource.Current != null && BindingSource.Current is ImageDocument)
                OnSavedImage(new ImageEventArg(BindingSource.Current as ImageDocument));
        }

        void tsbtnFilipVertical_Click(object sender, EventArgs e)
        {
            OnFilipVertical(new ImageEventArg(BindingSource.Current as ImageDocument)); 
        }

        void tsbtnFilipHorizontal_Click(object sender, EventArgs e)
        {
            OnFilipHorizontal(new ImageEventArg(BindingSource.Current as ImageDocument));
        }

        void tsRotateClockWise_Click(object sender, EventArgs e)
        {
            OnRotateClockWise(new ImageEventArg(BindingSource.Current as ImageDocument));
        }

        void tsRotateAntiClockWise_Click(object sender, EventArgs e)
        {
            OnRotateAntiClockWise(new ImageEventArg(BindingSource.Current as ImageDocument));
        }

        void tsbtnShowContinusPages_CheckedChanged(object sender, EventArgs e)
        {
            ImageViewer.ViewContinusePages = tsbtnShowContinusPages.Checked;
        }

        void tsbtnItmActualSize_Click(object sender, EventArgs e)
        {
            if (ImageViewer != null)
            {
                ImageViewer.SetActualSize();
            }
        }

        void tsbtnItmWhole_Click(object sender, EventArgs e)
        {
            if (ImageViewer != null)
            {
                ImageViewer.SetFullView();
            }
        }

        void tsbtnItmFitWidth_Click(object sender, EventArgs e)
        {
            if (ImageViewer != null)
            {
                ImageViewer.FitToWidth();
            }
        }

        void tsmnuItmZoomOut_Click(object sender, EventArgs e)
        {

            if (ImageViewer != null)
            {
                ImageViewer.ZoomOut();
            }
        }

        void tsmnuItmZoomIn_Click(object sender, EventArgs e)
        {
            if (ImageViewer != null)
            {
                ImageViewer.ZoomIn(); 
            }
        }

        void tsbtnMoveNext_Click(object sender, EventArgs e)
        {

            if (BindingSource.Current != null) BindingSource.Move(BindingSource.Current, BindingSource.Position + 1);
            


            //if (ImageViewer != null)
            //{
            //    ImageViewer.Move(BindingSource.Position, BindingSource.Position + 1);
            //}

            //if (Thumbnail != null)
            //    Thumbnail.MoveNext();



          
        }

        private void tsbtnMoveBack_Click(object sender, EventArgs e)
        {
            if (BindingSource.Current != null) BindingSource.Move(BindingSource.Current, BindingSource.Position - 1);

            //if (Thumbnail != null)
            //    Thumbnail.MoveBack();

            //if (ImageViewer != null)
            //{
            //    ImageViewer.Move(BindingSource.Position, BindingSource.Position - 1);
            //}

           

            //var i = Thumbnail.SelectedItems[0].Index;
        }

       

        void tsbtnPrint_Click(object sender, EventArgs e)
        {

            BindingSource.Print();
 
          
        }

        void tsbtnScan_Click(object sender, EventArgs e)
        {

            this.BindingSource.Scan();

            
        }

        void tsbtnRemoveAllItems_Click(object sender, EventArgs e)
        {
            BindingSource.Clear();
        }

        void tsbtnRemoveItem_Click(object sender, EventArgs e)
        {
            if (Thumbnail != null)
            {

                var allRemoveImage = new Collection<ImageDocument>();

                foreach (var item in Thumbnail.SelectedItems)
                {
                    allRemoveImage.Add(item.Tag as ImageDocument);
                }

                if (allRemoveImage.Count > 1)
                {
                     BindingSource.Remove(allRemoveImage);
                }
                else
                {
                     if (allRemoveImage.Count == 1)
                     {
                         BindingSource.Remove(allRemoveImage[0]);
                     }
                    
                }

                //if (Thumbnail.SelectedItems.Count > 1)
                //{

                //    var fImgs = new BaseImage[Thumbnail.SelectedItems.Count];
                //    for (int i = 0; i < fImgs.Length; i++)
                //    {
                //        fImgs[i] = Thumbnail.SelectedItems[i].Tag as BaseImage;
                //    }

                //    BindingSource.Remove(fImgs);
                //}
                //else
                //{

                //    foreach (var item in Thumbnail.SelectedItems)
                //    {
                //        if (item.Tag is BaseImage)
                //        {
                //            if (BindingSource != null && BindingSource.Contains(item.Tag))
                //            {
                //                BindingSource.Remove(item.Tag);
                //            }
                //        }
                //    }
                //}
            }
            else
            {
                if (BindingSource.Current != null)
                    BindingSource.RemoveCurrent();    
            }

            
        }

        void tsbtnGotoPrevItem_Click(object sender, EventArgs e)
        {
            BindingSource.MovePrevious();
        }

        void tsbtnGoToNextItem_Click(object sender, EventArgs e)
        {
            BindingSource.MoveNext();
        }

        void tsbtnGoToLastItem_Click(object sender, EventArgs e)
        {
            BindingSource.MoveLast();
        }

        void BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            
        }

        void tsbtnGoToFirstItem_Click(object sender, EventArgs e)
        {
            BindingSource.MoveFirst();
        }

      

        void tsbtnOpen_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
               // List<ImageDocument> images = new List<ImageDocument>();
                BindingSource.OpenFromPaths(openFileDialog.FileNames);
            }

        }

      


        private ImageDocumentBindingSource _bindingSource;
        private bool _allowNavigator;
        private bool _allowFilipVerticalHorizontal;
        private bool _allowMeargeImage;

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
                
                
                if (value != null)
                {
                    //tscmbNavigateItems.ComboBox.DataSource = value.List;
                    
                    //tscmbNavigateItems.ComboBox.DisplayMember = "OrderInDocument";
                    
                    value.CurrentChanged += BindingSource_CurrentChanged;
                    value.PositionChanged += BindingSource_PositionChanged;
                    value.ListChanged += BindingSource_ListChanged;
                   
                }
            }
        }

        public bool AllowNavigator
        {
            get {
                return _allowNavigator;
            }
            set {
                _allowNavigator = value;
                tsbtnGoToFirstItem.Visible = value;
                tsbtnGotoPrevItem.Visible = value;
                tscmbNavigateItems.Visible = value;
                tslblAllPageCount.Visible = value;
                tsbtnGoToNextItem.Visible = value;
                tsbtnGoToLastItem.Visible = value;
            }
        }

        public bool AllowFilipVerticalHorizontal
        {
            get {
                return _allowFilipVerticalHorizontal;
            }
            set {
                _allowFilipVerticalHorizontal = value;
                this.tsbtnFilipVertical.Visible = value;
                this.tsbtnFilipHorizontal.Visible = value;
            }
        }

        public bool AllowMeargeImage
        {
            get {
                return _allowMeargeImage;
            }
            set {
                _allowMeargeImage = value;
                
            }
        }


        void BindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                    case ListChangedType.ItemDeleted:
                    case ListChangedType.ItemAdded:
                    PopulateImagesCombo();
                    BindingSource_PositionChanged(sender, e);
                    
                    
                    break;


                    case ListChangedType.ItemMoved:
                    PopulateImagesCombo();
                    break;
                    case ListChangedType.Reset:
                    break;
            }
        }

        void BindingSource_PositionChanged(object sender, EventArgs e)
        {
           // PopulateImagesCombo();
            tslblAllPageCount.Text = "/" + BindingSource.Count;
            tscmbNavigateItems.ComboBox.Text = (BindingSource.Position + 1).ToString();// +"/" + BindingSource.Count;
            
        }

      
    }
}
