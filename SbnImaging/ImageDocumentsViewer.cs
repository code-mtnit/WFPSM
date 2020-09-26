using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sbn.Controls.Imaging.EventArgsFolder;

using Sbn.AdvancedControls.Imaging.ImageViewer.ListViewFolder;
using Sbn.Controls.Imaging.ImagingObject;

namespace Sbn.Controls.Imaging
{
    public partial class ImageDocumentsViewer : UserControl// Imaging.ImageViewer.SBNPictureBox
    {

        private Sbn.AdvancedControls.Imaging.ImageViewer.ListViewFolder.ImageListView ucImageListView;
        public event PropertyChangedEventHandler PropertyChanged;

        private BindingSource _bindingSource;

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
        public BindingSource BindingSource
        {
            get
            {
                return _bindingSource;
            }
            set
            {

               // Items.Clear();

                _bindingSource = value;

                if (value != null)
                {
                   
                    value.CurrentChanged += BindingSource_CurrentChanged;
                    value.ListChanged += BindingSource_ListChanged;
                    foreach (ImageDocument img in value)
                    {
                      //  AddImage(img);
                    }
                }
            }
        }

        private void BindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {

            switch (e.ListChangedType)
            {

                case ListChangedType.ItemMoved:
                    if (ucImageListView != null)
                    {
                        ucImageListView.Items.Move(ucImageListView.Items[e.OldIndex], e.NewIndex);
                        var item = ucImageListView.Items[e.NewIndex]; 
                        if (item != null && ucImageListView.IsItemVisible(item) == ItemVisibility.NotVisible)
                            ucImageListView.EnsureVisible(item.Index);
                    }
                    break;

                case ListChangedType.Reset:
                   // if (ucImageListView != null) ucImageListView.Items.Clear();
                    break;

                case ListChangedType.ItemAdded:

                    if (ucImageListView != null)
                    {
                        var img = BindingSource[e.NewIndex] as ImageDocument;
                        ImageListItem ImgItm = null;
                        if (Path.IsPathRooted(img.Description) && File.Exists(img.Description))
                        {
                            ImgItm = new ImageListItem(img.Description);
                        }
                        else
                        {
                            ImgItm = new ImageListItem(img);

                            if (img.GUid != Guid.Empty)
                                ImgItm.FileName = img.GUid.ToString();
                            else
                                ImgItm.FileName = Guid.NewGuid().ToString();
                        }

                        ImgItm.Tag = img;
                        ImgItm.Text = img.OrderInDocument.ToString();
                        ImgItm.ZOrder = img.OrderInDocument;
                       // var ii = BindingSource.IndexOf(img);


                        if (ucImageListView.Items.Count == 0)  //زمانی که اولین تصویر افزوده می شود مقدار طول و عرض از روی آن مشخص می شود
                        {
                            if (sbnPictureBox1.CurrentImage != null)
                            {
                                ucImageListView.ThumbnailSize = new Size((int)((sbnPictureBox1.CurrentImage.Width - 30) * sbnPictureBox1.Zoom), (int)(sbnPictureBox1.CurrentImage.Height * sbnPictureBox1.Zoom));
                            }
                            else
                            {
                                if (img.Width > 100 && img.Height > 100)
                                    ucImageListView.ThumbnailSize = new Size((int)((img.Width - 30) * sbnPictureBox1.Zoom), (int)(img.Height * sbnPictureBox1.Zoom));
                            }
                        }


                        ucImageListView.Items.Insert(BindingSource.IndexOf(img), ImgItm); //.Add(ImgItm);
                    }
                    break;

                case ListChangedType.ItemDeleted:
                    if (ucImageListView != null)
                    {
                        foreach (var item in ucImageListView.Items)
                        {
                            if (item.Tag is ImageDocument)
                            {
                                if (!BindingSource.Contains(item.Tag as ImageDocument))
                                {
                                    ucImageListView.Items.Remove(item);
                                    break;

                                }

                            }
                        }
                    }
                    break;

                default:
                    break;
            }

        }

        private void BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            

            CurrentFilmstripImage = BindingSource.Current as ImageDocument;

           
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }

        bool _allowFilip = false;

        public bool AllowFilip
        {
            get
            {
                return _allowFilip;
            }
            set
            {
                _allowFilip = value;
                OnPropertyChanged(new PropertyChangedEventArgs("AllowFilip"));
               
            }
        }

        bool _allowRotate = true;

        public bool AllowRotate
        {
            get { return _allowRotate; }
            set
            {
                _allowRotate = value;
                OnPropertyChanged(new PropertyChangedEventArgs("AllowRotate"));
            }
        }

        bool _allowMagnifair = false;

        public bool AllowMagnifair
        {
            get { return _allowMagnifair; }
            set
            {
                _allowMagnifair = value;
                OnPropertyChanged(new PropertyChangedEventArgs("AllowMagnifair"));

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
                OnPropertyChanged(new PropertyChangedEventArgs("AllowZoom"));
                //tsmnuItmZoomIn.Visible = value;
                //tsmnuItmZoomOut.Visible = value;
                //tsSbtnZoom.Visible = value;
                //tsbtnItmFitWidth.Visible = value;
                //tsbtnItmActualSize.Visible = value;
                //tsbtnItmWhole.Visible = value;
                //toolStripSeparator4.Visible = value;
            }
        }

        bool _allowViewContinusePages = false;

        public bool AllowViewContinusePages
        {
            get { return _allowViewContinusePages; }
            set
            {
                _allowViewContinusePages = value;
                OnPropertyChanged(new PropertyChangedEventArgs("AllowViewContinusePages"));

               
              
            }
        }

        private bool _viewContinusePages = false;

        public bool ViewContinusePages
        {
            get { return _viewContinusePages; }
            set
            {
                _viewContinusePages = value;
                if (value)
                {
                    if (ucImageListView == null)
                    {
                      
                        ucImageListView = new ImageListView();
                        Controls.Add(ucImageListView);
                        sbnPictureBox1_ZoomChanged(this, null);
                        ucImageListView.NeedDrawImage += new EventHandler<ImageLisViewItemEventArg>(ucImageListView_NeedDrawImage);
                        ucImageListView.ViewItemChanged += new EventHandler(ucImageListView_ViewItemChanged);
                        ucImageListView.RetrieveVirtualItemThumbnail += ucImageListView_RetrieveVirtualItemThumbnail;
                        ucImageListView.RetrieveVirtualItemImage += ucImageListView_RetrieveVirtualItemImage;
                       
                        

                        if (BindingSource != null)
                        {
                            foreach (ImageDocument img in BindingSource)
                            {

                                var ImgItm = new ImageListItem(img);
                                if (Path.IsPathRooted(img.Description) && File.Exists(img.Description))
                                {
                                    ImgItm = new ImageListItem(img.Description);
                                }
                                else
                                    ImgItm.FileName = img.GUid.ToString();

                                ImgItm.Tag = img;
                                ImgItm.Text = img.OrderInDocument.ToString();
                                ImgItm.ZOrder = img.OrderInDocument;
                                ucImageListView.Items.Insert(BindingSource.IndexOf(img), ImgItm);//.Add(ImgItm);
                               
                            }    
                        }
                        

                    }

                    sbnPictureBox1_ZoomChanged(this, null);
                    ucImageListView.Dock = DockStyle.Fill;
                    ucImageListView.BringToFront();
                }
                else
                {
                    
                    sbnPictureBox1.BringToFront();
                }
            }
        }

        void ucImageListView_RetrieveVirtualItemImage(object sender, VirtualItemImageEventArgs e)
        {
            
        }

        void ucImageListView_RetrieveVirtualItemThumbnail(object sender, VirtualItemThumbnailEventArgs e)
        {

            

            // return;
            ImageDocument img = null;

            if (e.Key is ImageDocument)
            {
                img = e.Key as ImageDocument;
            }

            if (img == null)
                return;

            InitialImage(img);

            var imgTemp = CurrentImageTools.GetWholeImage(img);

            if (imgTemp != null)
            {
               
                e.ThumbnailImage = CurrentImageTools.BaseTools.ScaleImage(imgTemp, e.ThumbnailDimensions.Width, e.ThumbnailDimensions.Height, 0);
                imgTemp.Dispose();
                return;
            }

         
        }


        public  void SetFullView()
        {
            sbnPictureBox1.ZoomMode = Sbn.AdvancedControls.Imaging.ImageViewer.ZoomMode.FullPage; 
        }

        public void SetActualSize()
        {
            sbnPictureBox1.ZoomMode = Sbn.AdvancedControls.Imaging.ImageViewer.ZoomMode.ActualSize; 
        }

        public void ClearAll()
        {
            if (ucImageListView != null)
                ucImageListView.Items.Clear();
        }


        public void FitToWidth()
        {
            sbnPictureBox1.ZoomMode = Sbn.AdvancedControls.Imaging.ImageViewer.ZoomMode.PageWidth; 
            //sbnPictureBox1.F
        }

        public void ZoomOut()
        {
            sbnPictureBox1.ZoomOut();
        }

        public void ZoomIn()
        {
            sbnPictureBox1.ZoomIn();
        }


        public System.Drawing.Point ViewOffset
        {
            get
            {
                if (ViewContinusePages)
                {
                    if (ucImageListView != null)
                    {
                       return ucImageListView.ViewOffset;
                        //if (ucImageListView.hScrollBar != null)
                        //    return ucImageListView.hScrollBar.Value;
                    }
                }
                else
                {
                    return sbnPictureBox1.ViewOffset;

                }

                return new System.Drawing.Point(0, 0);
            }
            set
            {
                if (ViewContinusePages)
                {
                    if (ucImageListView != null)
                    {
                         ucImageListView.ViewOffset = value;
                        ucImageListView.Refresh();
                        //if (ucImageListView.hScrollBar != null)
                        //    return ucImageListView.hScrollBar.Value;
                    }
                }
                else
                {
                     sbnPictureBox1.ViewOffset = value;

                }
            }
        }
      

        /// <summary>
        /// بروزرسانی کامل کنترل نمایش پیوسته تصاویر
        /// </summary>
        public void RefreshImageListViewer()
        {
            if (ucImageListView == null)
            {
                ucImageListView = new ImageListView();
                Controls.Add(ucImageListView);

                ucImageListView.NeedDrawImage += new EventHandler<ImageLisViewItemEventArg>(ucImageListView_NeedDrawImage);
                ucImageListView.ViewItemChanged += new EventHandler(ucImageListView_ViewItemChanged);


            }

            foreach (var itm in ucImageListView.Items)
            {
                
            }

            ucImageListView.ClearThumbnailCache();

            //ucImageListView.Items.Clear();


            //foreach (var filmstripImage in ImagesCollection)
            //{
            //    var itm = Cast(filmstripImage);

            //    if (itm != null) ucImageListView.Items.Add(itm);
            //}

            //try
            //{
            //    ucImageListView.ThumbnailSize = new Size((int)(selectedImage.ImageFullViewLayer.Width * htfImageTool1.Zoom), (int)(selectedImage.ImageFullViewLayer.Height * htfImageTool1.Zoom));
            //}
            //catch
            //{

            //    ucImageListView.ThumbnailSize = new Size(800, 600);
            //}

            ucImageListView.Focus();
        }

        private void ucImageListView_ViewItemChanged(object sender, EventArgs e)
        {
            var itm = sender as ImageListItem;

            if (itm != null)
            {
                var fImg = itm.Tag as ImageDocument;

                if (fImg != null) BindingSource.Position = BindingSource.IndexOf(fImg);
            }
        }

        private void ucImageListView_NeedDrawImage(object sender, ImageLisViewItemEventArg e)
        {
            throw new NotImplementedException();
        }

        public void Move(int oldIndex, int newIndex)
        {
            
           if (ucImageListView != null)
           {
               if (newIndex < 0 || newIndex >= BindingSource.Count)
                   return;

               ImageListItem item = ucImageListView.Items[oldIndex];
               ucImageListView.Items.Move(item , newIndex);

               if (item != null && ucImageListView.IsItemVisible(item) == ItemVisibility.NotVisible)
                   ucImageListView.EnsureVisible(item.Index);
           }


        }


        [Category("Filmstrip events")]
        public event EventHandler<ImageEventArg> NeedImage;

        public void OnNeedImage(ImageEventArg e)
        {
            EventHandler<ImageEventArg> handler = NeedImage;
            if (handler != null) handler(this, e);
        }




        SbnImageTools CurrentImageTools = new SbnImageTools();
        public ImageDocumentsViewer()
        {
            InitializeComponent();

            sbnPictureBox1.ZoomChanged += sbnPictureBox1_ZoomChanged;
            CurrentImageTools.NeedImage += CurrentImageTools_NeedImage;
        }

        void CurrentImageTools_NeedImage(object sender, ImageEventArg e)
        {
            OnNeedImage(e);
        }

      

        void sbnPictureBox1_ZoomChanged(object sender, EventArgs e)
        {
            if (ucImageListView != null)
            {
                if (CurrentFilmstripImage != null)
                {
                    if (sbnPictureBox1.CurrentImage != null)
                    {
                        ucImageListView.ThumbnailSize =
                            new Size((int) ((sbnPictureBox1.CurrentImage.Width - 30)*sbnPictureBox1.Zoom),
                                     (int) (sbnPictureBox1.CurrentImage.Height*sbnPictureBox1.Zoom));
                    }
                }
              
                //else if (CurrentFilmstripImage.Image != null)
                //{
                //    ucImageListView.ThumbnailSize = new Size((int)(sbnPictureBox1.CurrentImage.Width * sbnPictureBox1.Zoom), (int)(CurrentFilmstripImage.Image.Height * sbnPictureBox1.Zoom));
                //}
                //else if (Path.IsPathRooted(CurrentFilmstripImage.Path) && File.Exists(CurrentFilmstripImage.Path))
                //{

                //    var itm = ucImageListView.Items[0];
                //} 
                
                
                //if (CurrentFilmstripImage.ImageFullViewLayer != null)
                //{
                //    ucImageListView.ThumbnailSize = new Size((int)((CurrentFilmstripImage.ImageFullViewLayer.Width - 10) * sbnPictureBox1.Zoom), (int)(CurrentFilmstripImage.ImageFullViewLayer.Height * sbnPictureBox1.Zoom));
                //}
                //else if (CurrentFilmstripImage.Image != null)
                //{
                //    ucImageListView.ThumbnailSize = new Size((int)(CurrentFilmstripImage.Image.Width * sbnPictureBox1.Zoom), (int)(CurrentFilmstripImage.Image.Height * sbnPictureBox1.Zoom));
                //}
                //else if (Path.IsPathRooted(CurrentFilmstripImage.Path) && File.Exists(CurrentFilmstripImage.Path))
                //{

                //    var itm = ucImageListView.Items[0];
                //}
            }
            else
            {
                
            }
        }


        public Image CurrentImage
        {
            get { return this.sbnPictureBox1.CurrentImage; }

        }

        private ImageDocument _currentFilmstripImage;

        public ImageDocument CurrentFilmstripImage
        {
            get { return _currentFilmstripImage; }
            set
            {

               // if ((_currentFilmstripImage != null && value == null) || (_currentFilmstripImage == null && value != null) || (_currentFilmstripImage != null && value != null && _currentFilmstripImage.Counter != value.Counter))
                if (!object.ReferenceEquals(value , _currentFilmstripImage))
                {
                    //if (_currentFilmstripImage != null && _currentFilmstripImage.ImageFullViewLayer != null )
                    //{
                    //    if (object.ReferenceEquals(_currentFilmstripImage.ImageFullViewLayer, _currentFilmstripImage.Image))
                    //    {
                    //        _currentFilmstripImage.ImageFullViewLayer.Dispose();
                    //        _currentFilmstripImage.ImageFullViewLayer = null;
                    //        _currentFilmstripImage.Image = null;

                    //    }
                    //    else
                    //    {
                    //        _currentFilmstripImage.ImageFullViewLayer.Dispose();
                    //        _currentFilmstripImage.ImageFullViewLayer = null;
                    //    }

                        
                    //}

                    _currentFilmstripImage =  value;

                    if (_currentFilmstripImage != null)
                    {
                        InitialImage(value);
                        sbnPictureBox1.CurrentImage = CurrentImageTools.GetWholeImage(value);

                        ImageListItem itm = null;
                        if (ucImageListView != null)
                        {
                           
                            foreach (var item in ucImageListView.Items)
                            {
                                if (item.Tag != null)
                                    if (item.Tag == CurrentFilmstripImage)
                                    {
                                        itm = item;
                                        break;
                                    }
                            }
                            if (itm != null && ucImageListView.IsItemVisible(itm) == ItemVisibility.NotVisible)
                                ucImageListView.EnsureVisible(itm.Index);

                        }
                      
                    }
                    else
                    {
                        sbnPictureBox1.CurrentImage = null;
                    }
                }
            }
        }

      

        public ImageDocument InitialImage(ImageDocument img)
        {
           
          
            return CurrentImageTools.InitialImage(img);
            //try
            //{
            //    img.Image.Save("c:\\aeae.jpeg");
            //}
            //catch
            //{ }

            try
            {
                
                MemoryStream ms;
                if (img.Stream == null || img.Stream.Length < 10)
                {
                    if (Path.IsPathRooted(img.Description) && File.Exists(img.Description))
                    {
                        using (Image image = Image.FromFile(img.Description))
                        {
                          //  image.Save("D:\\4545.jpg");
                           img.Stream = this.CurrentImageTools.BaseTools.GetStreamImage(image , System.Drawing.Imaging.ImageFormat.Tiff);
                          // var inm = this.CurrentImageTools.BaseTools.GetImage(img.Stream);
                          // inm.Save("D:\\4545.jpg");
                        }
                        
                    }
                    else 
                    {
                        OnNeedImage(new ImageEventArg(img));
                    }

                }

                return img;

            }
            catch
            { }

            return null;
        }

        public void MoveNext()
        {
          
            return;
        }

        public void MoveBack()
        {
            throw new NotImplementedException();
        }

        public void RefreshCurrent()
        {
          // if (!ViewContinusePages)
           {
               var imgTemp = CurrentFilmstripImage;
               CurrentFilmstripImage = null;

               CurrentFilmstripImage = imgTemp;

               RefreshImageListViewer();

           }
         
        }
    }
}
