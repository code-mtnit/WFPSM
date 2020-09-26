using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Sbn.AdvancedControls.Imaging.ThumbnailControl;
using Sbn.Controls.Imaging.EventArgsFolder;
using Sbn.Controls.Imaging.ImagingObject;
using Point = System.Drawing.Point;


namespace Sbn.Controls.Imaging
{
    public partial class ThumbnailList : ImageListView
    {
        private bool _allowMoveItem = true;

        public bool AllowMoveItem
        {
            get { return _allowMoveItem; }
            set
            {
                
                _allowMoveItem = value;
                AllowDrag = value;
                AllowDrop = value;
                OnPropertyChanged(new PropertyChangedEventArgs("AllowMoveItem"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }

        [Category("Filmstrip events")]
        public event FilmStripBeforRemoveImageEventHandler BeforRemoveImage2;
        //public event EventHandler<ImageEventArgs> BeforRemoveImage;

        public event EventHandler<ImageEventArg> CreatedThumbnailImage;

        public void OnCreatedThumbnailImage(ImageEventArg e)
        {
            EventHandler<ImageEventArg> handler = CreatedThumbnailImage;
            if (handler != null) handler(this, e);
        }


        [Category("Filmstrip events")]
        public event EventHandler<ImageEventArgs> RemovedImage;

        [Category("Filmstrip events")]
        public event EventHandler<ImageEventArgs> AddedImage;

        [Category("Filmstrip events")]
        public event EventHandler<ImageEventArg> NeedThumbnailsImage;

        public void OnNeedThumbnailsImage(ImageEventArg e)
        {
            EventHandler<ImageEventArg> handler = NeedThumbnailsImage;
            if (handler != null) handler(this, e);

            
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
            get
            {
                return _bindingSource;
            }
            set
            {

                Items.Clear();

                _bindingSource = value;

                if (value != null)
                {
                    
                    value.CurrentChanged += BindingSource_CurrentChanged;
                    value.ListChanged += BindingSource_ListChanged;
                    foreach (ImageDocument img in value)
                    {
                        AddImage(img);
                    }
                }
            }
        }

        void BindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            switch(e.ListChangedType)
            {
                case ListChangedType.ItemMoved:
                    Items.Move(Items[e.OldIndex],e.NewIndex);
                    RefreshThumbnailItems();
                break;

                case ListChangedType.ItemAdded:
                    var tt = BindingSource.IndexOf(BindingSource[e.NewIndex]);
                    if (tt > Items.Count)
                    {
                        
                    }


                    AddImage(BindingSource[e.NewIndex] as ImageDocument);
                    RefreshThumbnailItems();
                    break;

                case ListChangedType.ItemDeleted:
                    foreach (var item in Items)
                    {
                        if (item.Tag is ImageDocument)
                        {
                            if (!BindingSource.Contains(item.Tag as ImageDocument))
                            {
                                Items.Remove(item);
                                break;

                            }                          
                            
                        }
                    }

                    RefreshThumbnailItems();
                    break;

                    case ListChangedType.Reset:
                    RefreshThumbnailItems();
                   // Items.Clear();
                    break;

                default:
                    break;
            }
        }

       

        void BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            RefreshThumbnailItems();

            Sbn.AdvancedControls.Imaging.ThumbnailControl.ImageListViewItem itm = null;
           
            foreach (var item in Items)
            {
                if (item.Tag is ImageDocument)
                    //if ((item.Tag as BaseImage).Guid == (BindingSource.Current as BaseImage).Guid)
                    if (object.ReferenceEquals(item.Tag as ImageDocument , BindingSource.Current as ImageDocument))
                    {
                       itm = item;
                       break;
                    }
                  

             //   Select(false,false);

            }
            if (itm != null)
            {
                if (!itm.Selected)
                {
                    ClearSelection();
                    itm.Selected = true;
                    Invalidate();
                }
                if (IsItemVisible(itm) == ItemVisibility.NotVisible)
                {
                    EnsureVisible(itm.Index);
                }
            }
        }


        public event EventHandler<ImageEventArg> CurrenViewImageChanged;

        public void OnCurrenViewImageChanged(ImageEventArg e)
        {
            EventHandler<ImageEventArg> handler = CurrenViewImageChanged;
            if (handler != null) handler(this, e);
        }

        public static int NO_SELECTION_ID = -1;
        SbnImageTools CurrentImageTools = new SbnImageTools();
        internal int imageIdCounter = 1;
        internal List<int> keys;
        public ThumbnailList()
        {
            InitializeComponent();
            SortOrder = SortOrder.Ascending;
           // SetRenderer(new ImageListViewRenderer{ItemDrawOrder = ThumbnailControl.ItemDrawOrder.ZOrder});
            RetrieveVirtualItemThumbnail += ThumbnailList_RetrieveVirtualItemThumbnail;
        }

        void ThumbnailList_RetrieveVirtualItemThumbnail(object sender,VirtualItemThumbnailEventArgs e)
        {
           // return;
            ImageDocument img = null;

            if (e.Key is ImageDocument)
            {
                img = e.Key as ImageDocument;
            }

            if (e.Key is int)
            {
               // img = Items[(int) e.Key].Tag as BaseImage;
            }

            if (img == null)
                return;

            //if (img.Image == null && (img.Stream == null || img.Stream.Length < 10) && img.ThumbnailImage == null && (img.ThumbnailStream == null || img.ThumbnailStream.Length < 10))
            if ((img.Stream == null || img.Stream.Length < 10) && (img.ThumbnailStream == null || img.ThumbnailStream.Length < 10))
            {
                OnNeedThumbnailsImage(new ImageEventArg(img));
            }


            if (img.ThumbnailStream == null || img.ThumbnailStream.Length < 10)
            {
                if (img.Stream != null && img.Stream.Length > 10)
                {

                    using (var ms = new MemoryStream(img.Stream))
                    {
                        try
                        {
                            using (var imgTemp = Image.FromStream(ms))
                            {
                                e.ThumbnailImage = CurrentImageTools.BaseTools.ScaleImage(imgTemp,
                                                                                          e.ThumbnailDimensions.Width,
                                                                                          e.ThumbnailDimensions.Height, 0);

                                img.ThumbnailStream = CurrentImageTools.BaseTools.GetStreamImage(e.ThumbnailImage,
                                                                                                 System.Drawing.Imaging.
                                                                                                     ImageFormat.Tiff);

                                OnCreatedThumbnailImage(new ImageEventArg(img));
                            }
                            ms.Dispose();
                        }
                        catch (Exception)
                        {
                            
                           // throw;
                        }
                       
                    }

                    return;
                    // img.ThumbnailImage = ScaleImage(img.Image, this.SelectedThumbnailPic.Width, this.SelectedThumbnailPic.Height, scaleRatio);
                }
            }


            if (img.ThumbnailStream != null && img.ThumbnailStream.Length > 10)
            {
                var ms = new System.IO.MemoryStream(img.ThumbnailStream);
                e.ThumbnailImage = Image.FromStream(ms);
                //img.ThumbnailImage = e.ThumbnailImage;

                ms.Dispose();
            }


          

            //if(img.ThumbnailImage != null)
            //{
            //    e.ThumbnailImage = img.ThumbnailImage;
            //    return;
            //}

          

            //if (img.ThumbnailImage == null && img.Image != null)
            //{
            //    e.ThumbnailImage = CurrentImageTools.BaseTools.ScaleImage(img.Image, e.ThumbnailDimensions.Width, e.ThumbnailDimensions.Height, 0);
            //    // img.ThumbnailImage = ScaleImage(img.Image, this.SelectedThumbnailPic.Width, this.SelectedThumbnailPic.Height, scaleRatio);
            //}


            //if (img.ThumbnailImage == null && img.Image == null && img.ThumbnailStream != null && img.ThumbnailStream.Length > 10)
            //{
            //    var ms = new MemoryStream(img.ThumbnailStream);
            //    e.ThumbnailImage = Image.FromStream(ms);
            //    ms.Dispose();
            //}


           // if (img.ThumbnailImage == null && img.Image == null && img.Stream != null && img.Stream.Length > 10)
          

            
        }

        private Dictionary<int, ImageDocument> imagesCollection;

        public Dictionary<int, ImageDocument> ImagesCollection
        {
            get { return imagesCollection; }
            set
            {
                imagesCollection = value;
                
            }
        }


        private ImageDocument _currentViewImage;

        public ImageDocument CurrentViewImage
        {
            get { return _currentViewImage; }
            set
            {
                if ((_currentViewImage != null && value == null) || (_currentViewImage == null && value != null) )//|| (_currentViewImage != null && value != null && _currentViewImage.Counter != value.Counter))
                {
                    _currentViewImage = value;
                    OnCurrenViewImageChanged(new ImageEventArg(value));
                }
            }
        }


        public ImageDocument[] SortImages(ImageDocument[] images)
        {
            ImageDocument[] Returnimages = new ImageDocument[images.Length];
            for (int i = 0; i < images.Length; i++)
            {
                ImageDocument tempInt = new ImageDocument();

                int removedIndex = -1;
                foreach (ImageDocument imgTemp in images)
                {
                    removedIndex++;
                    if (imgTemp != null)
                    {
                        tempInt = imgTemp;

                        break;
                    }
                }



                int tempCont = 0;
                foreach (ImageDocument img in images)
                {
                    if (img != null)
                    {
                        if (img.CompareTo( tempInt) == -1)
                        {
                            tempInt = img;
                            removedIndex = tempCont;
                        }
                    }
                    tempCont++;
                }


                Returnimages[i] = tempInt;


                images.SetValue(null, removedIndex);

            }


            return Returnimages;
        }


        internal void RefreshThumbnailItems()
        {

           

            //foreach (var imgItm in BindingSource)
            //{
            //    if (imgItm is ImageDocument)
            //    {
            //        ImageListViewItem itm = null;
            //        foreach (ImageListViewItem item in Items)
            //        {
            //            if (item.Tag is ImageDocument)
            //            {
            //                if (object.ReferenceEquals((item.Tag as ImageDocument) , (imgItm as ImageDocument)))
            //                {


            //                    itm = item;
            //                    break;
                             
            //                }

            //            }
            //        }

            //        if (itm == null)
            //        {
            //            AddImage(imgItm as ImageDocument);
            //        }

            //    }
            //}






            Collection<ImageListViewItem> removeItems = new Collection<ImageListViewItem>();
            foreach (var item in Items)
            {
                if (item.Tag is ImageDocument)
                {
                    if (BindingSource.Contains(item.Tag as ImageDocument))
                    {
                       
                        if ((item.Tag as ImageDocument).OrderInDocument != BindingSource.IndexOf(item.Tag) + 1)
                        {
                            (item.Tag as ImageDocument).OrderInDocument = BindingSource.IndexOf(item.Tag) + 1;
                            item.ZOrder = BindingSource.IndexOf(item.Tag) + 1;
                            item.Text = (item.Tag as ImageDocument).OrderInDocument.ToString();
                        }
                    }
                    else
                    {
                        /// فکر کنم به این دیگر نیازی نباشه
                       // removeItems.Add(item);
                    }


                }
            }

            foreach (var item in removeItems)
            {
                Items.Remove(item);
            }

        }


        ImageListViewItem Cast(ImageDocument image)
        {
            var ImgItm = new Sbn.AdvancedControls.Imaging.ThumbnailControl.ImageListViewItem();
           
            ImgItm.Tag = image;


            return ImgItm;
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
            var AddedImages = new Collection<ImageDocument>();

            image.OrderInDocument = BindingSource.IndexOf(image) + 1;
            var ImgItm = new ImageListViewItem(image);
            if (Path.IsPathRooted(image.Description) && File.Exists(image.Description))
            {
                ImgItm = new ImageListViewItem(image.Description);
            }
            else
                ImgItm.FileName = image.GUid.ToString();

            ImgItm.Tag = image;
           
            ImgItm.Text = image.OrderInDocument.ToString();
            ImgItm.ZOrder = image.OrderInDocument;

            var ti = BindingSource.IndexOf(image);

            if (ti > Items.Count)
            {

            }

            Items.Insert(BindingSource.IndexOf(image), ImgItm);//.Add(ImgItm);

            //if (image.Image != null)
            //{
            //    image.Image.Dispose();  //Added by rm 901018
            //    image.Image = null;
            //}



            if (null != AddedImage)
            {
                //var fImages = new Collection<BaseImage>();
                //var oi = 0;
                //foreach (var iigg in AddedImages)
                //{
                //    fImages[oi] = iigg;
                //    oi++;
                //}

                var e = new ImageEventArgs(AddedImages);
                AddedImage(this, e);
            }


        }


        public void MoveNext()
        {

            //if (SelectedItems.Count > 0)
            //    BindingSource.Move(SelectedItems[0], SelectedItems[0].Index + 1);

            return;

           
            try
            {
                var img = BindingSource.Current as ImageDocument;
                var i = BindingSource.IndexOf(img) + 1;
                if (i < BindingSource.Count)
                {
                    BindingSource.RemoveCurrent();
                    BindingSource.Insert(i, img);
                    BindingSource.Position = i;
                }
                
            }
            catch (Exception)
            {
                
                
            }

            return;


            SortColumn = ColumnType.Name;

            
            if (SelectedItems.Count > 0)
            {

                foreach (var item in SelectedItems)
                {
                    if (item.Index <= (Items.Count - 2))
                    {
                        item.ZOrder += 1;
                        item.Text = item.ZOrder.ToString();
                        (item.Tag as ImageDocument).OrderInDocument = item.ZOrder;


                        Items[item.Index + 1].ZOrder -= 1;
                        Items[item.Index + 1].Text = Items[item.Index + 1].ZOrder.ToString();
                        (Items[item.Index + 1].Tag as ImageDocument).OrderInDocument = Items[item.Index + 1].ZOrder;
                      
                    }
                   

                }
              

            }
          
            Sort();
       
        }

        public void MoveBack()
        {
            
            if (SelectedItems.Count > 0)
               BindingSource.Move(SelectedItems[0], SelectedItems[0].Index - 1);

            return;

            try
            {
                var img = BindingSource.Current as ImageDocument;
                var i = BindingSource.IndexOf(img) - 1;
                if (i >= 0)
                {
                    BindingSource.RemoveCurrent();
                    BindingSource.Insert(i, img);
                    BindingSource.Position = i;
                }

            }
            catch (Exception)
            {


            }

            return;


            SortColumn = ColumnType.Name;
            if (SelectedItems.Count > 0)
            {

                foreach (var item in SelectedItems)
                {
                    if (item.Index > 0 )
                    {
                        item.ZOrder -= 1;
                        item.Text = item.ZOrder.ToString();
                        (item.Tag as ImageDocument).OrderInDocument = item.ZOrder;


                        Items[item.Index - 1].ZOrder += 1;
                        Items[item.Index - 1].Text = Items[item.Index - 1].ZOrder.ToString();
                        (Items[item.Index - 1].Tag as ImageDocument).OrderInDocument = Items[item.Index - 1].ZOrder;

                    }


                }


            }

            Sort();
        }

        /// <summary>
        /// Adds a collection of images to the collection
        /// </summary>
        /// <param name="images">Array of images to add to the collection.</param>
        /// <exception cref="ArgumentException">System.SystemException.ArgumentException - 
        /// if any of the image ids already exist in the collection</exception>
        public void AddImageRange(ImageDocument[] images0)
        {
            //Cursor.Current = Cursors.WaitCursor;
            var images = SortImages(images0);
            MemoryStream ms = null;

           
            foreach (var image in images)
            {
                AddImage(image);
            }
        }

        /// <summary>
        /// Returns a new unique ID value.
        /// Uses our static counter
        /// </summary>
        /// <returns>Unique ID value for use as new image id</returns>
        private int GetUniqueImageID()
        {
            if (keys == null)
            {
                keys = new List<int>();
            }

            int newID = imageIdCounter++;
            while (keys.Contains(newID))
            {
                newID = imageIdCounter++;
            }
            return newID;
        }

        private void ThumbnailList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var fImg = e.Item.Tag as ImageDocument;

            if (fImg == null)
                return;


            BindingSource.Position =  BindingSource.IndexOf(fImg); // fImg.OrderInDocument;//
            //CurrentViewImage = fImg;
        }

        private void ThumbnailList_SelectionChanged(object sender, EventArgs e)
        {
            if (SelectedItems.Count > 0)
            {
                var i = SelectedItems[0].Index;
                ThumbnailList_ItemClick(sender, new Sbn.AdvancedControls.Imaging.ThumbnailControl.ItemClickEventArgs(SelectedItems[0], Point.Empty, MouseButtons.Left));
            }
        }


        /// <summary>
        /// Removes the specified image from the collection
        /// </summary>
        /// <param name="id">The id of the image to remove</param>
        /// <exception cref="ArgumentException">System.SystemException.ArgumentException - 
        /// if the image id does not exist in the collection</exception>
        /// <exception cref="ArgumentOutOfRangeException">System.SystemException.ArgumentOutOfRangeException - 
        /// if the image id is -1</exception>
        public void RemoveImage(int id)
        {
            if (NO_SELECTION_ID == id)
            {
                throw new ArgumentOutOfRangeException(String.Format("{0} is an invalid image id, it cannot be removed.", NO_SELECTION_ID.ToString()));
            }

            // Do we have this image id?
            if (imagesCollection.ContainsKey(id))
            {
                ImageDocument fImage = imagesCollection[id];
               // BaseImage[] films = new BaseImage[1] { fImage };
                var films = new Collection<ImageDocument>();
                films.Add(fImage);
                bool CheckRemove = true;
                if (null != BeforRemoveImage2)
                {
                    ImageEventArgs e = new ImageEventArgs(films);

                    BeforRemoveImage2(this as object, e, ref CheckRemove);
                }

                if (!CheckRemove)
                    return;
                // Clear selection if needed
                if (id == CurrentViewImage.OrderInDocument)
                {
                    ClearSelection();
                }


                // Remove it from the collections
                imagesCollection.Remove(id);

                int TempInt = keys.IndexOf(id);


                ImageDocument[] Films = new ImageDocument[imagesCollection.Count - TempInt];



                int jj = 0;
                for (int i = TempInt + 1; i <= imagesCollection.Count; i++)
                {
                    imagesCollection[keys[i]].OrderInDocument--;

                    Films[jj] = imagesCollection[keys[i]];
                    jj++;
                }




                keys.Remove(id);


                if (null != RemovedImage)
                {

                    ImageEventArgs e = new ImageEventArgs(films);
                    RemovedImage(this as object, e);

                }


                //if (null != MovedImage)
                //{
                //    try
                //    {
                //        ImageEventArgs e = new ImageEventArgs(Films);
                //        MovedImage(this, e);
                //    }
                //    catch
                //    {
                //    }
                //}


            }
            else
            {
                throw new ArgumentException(String.Format("The supplied image id ({0}) does not exist in the collection.", id.ToString()));
            }
        }

    }
}
