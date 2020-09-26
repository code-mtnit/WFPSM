using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using Sbn.Controls.Imaging.EventArgsFolder;
using Sbn.Controls.Imaging.Graphic;
using Sbn.Controls.Imaging.ImagingObject;

using System.Drawing;

namespace Sbn.Controls.Imaging
{
    public partial class ImageDocumentBindingSource : BindingSource
    {

        public event EventHandler AllowDuplicateFileNamesChenged;

        public void OnAllowDuplicateFileNamesChenged(EventArgs e)
        {
            EventHandler handler = AllowDuplicateFileNamesChenged;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Gets or sets whether duplicate items (image files pointing to the same path 
        /// on the file system) are allowed.
        /// </summary>
        [Category("Behavior"),
         Description(
             "Gets or sets whether duplicate items (image files pointing to the same path on the file system) are allowed."
             ), DefaultValue(false)] private bool _AllowDuplicateFileNames = false;

        public bool AllowDuplicateFileNames
        {
            get { return _AllowDuplicateFileNames; }
            set { _AllowDuplicateFileNames = value; }
        }



        private bool _raiseCurrentChangedEvents = true;

        public bool RaiseCurrentChangedEvents
        {
            get { return _raiseCurrentChangedEvents; }
            set
            {
                bool fireEvent = _raiseCurrentChangedEvents != value;

                _raiseCurrentChangedEvents = value;

                if (fireEvent)
                    OnAllowDuplicateFileNamesChenged(null);
            }
        }

        public SbnImageTools CurrentImageTools = new SbnImageTools();

        [Category("Filmstrip events")]
        public event EventHandler<PrintDocEventArgs> StartPrint;

        [Category("Filmstrip events")]
        public event EventHandler<PrintDocEventArgs> PrintPage;

        [Category("Filmstrip events")]
        public event EventHandler<ImageEventArg> NeedImage;

        [Category("Filmstrip events")]
        public event EventHandler<PrintDocEventArgs> PrintedImages;

        [Category("Filmstrip events")]
        public event EventHandler<ImageEventArg> BeforPrintPage;

        [Category("Filmstrip events")]
        public event EventHandler<ImageEventArgs> AddedImage;

        [Category("Filmstrip events")]
        public event EventHandler<ImageEventArgs> MovedImages;

        public void OnMovedImages(ImageEventArgs e)
        {
            EventHandler<ImageEventArgs> handler = MovedImages;
            if (handler != null) handler(this, e);
        }

        public void OnAddedImage(ImageEventArgs e)
        {
            EventHandler<ImageEventArgs> handler = AddedImage;
            if (handler != null) handler(this, e);

            if (this.Count == 1)
                OnCurrentChanged(e);
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

        public ImageDocumentBindingSource()
        {
            InitializeComponent();
            ListChanged += new ListChangedEventHandler(ImageDocumentBindingSource_ListChanged);
        }

        void ImageDocumentBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            //if (this. > 0)
            //{
                
            //}
            switch (e.ListChangedType)
            {
                    
                    case ListChangedType.ItemAdded:

                    var fImgs = new Collection<ImageDocument>();
                    (this[e.NewIndex] as ImageDocument).OrderInDocument = e.NewIndex + 1;
                    fImgs.Add(this[e.NewIndex] as ImageDocument);
                    OnAddedImage(new ImageEventArgs(fImgs));
                    break;

                    case ListChangedType.ItemMoved:
                    int j = Math.Abs(e.NewIndex - e.OldIndex) ;
                    var mCol = new Collection<ImageDocument>();
                    // mean move one step
                    if (j == 1)
                    {
                       
                       // var ij = (this[e.NewIndex] as ImageDocument);
                       // (this[e.NewIndex] as ImageDocument).OrderInDocument = e.NewIndex + 1;
                        mCol.Add(this[e.NewIndex] as ImageDocument);

                       // ij = (this[e.OldIndex] as ImageDocument);
                       // (this[e.OldIndex] as ImageDocument).OrderInDocument = e.OldIndex + 1;
                        mCol.Add(this[e.OldIndex] as ImageDocument);
                        OnMovedImages(new ImageEventArgs(mCol));
                    }
                    else
                    {
                        if (e.OldIndex > e.NewIndex)
                        {
                            for (int i = e.NewIndex; i <= e.OldIndex; i++)
                            {
                                mCol.Add(this[i] as ImageDocument);

                            }
                        }
                        else
                        {
                            for (int i = e.NewIndex; i >= e.OldIndex; i--)
                            {
                                mCol.Add(this[i] as ImageDocument);

                            }
                        }
                    }

                    OnMovedImages(new ImageEventArgs(mCol));

                    break;
            }
        }

        public override void Remove(object value)
        {
            try
            {
                if (value is ImageDocument)
                {
                    bool checkAllowRemove = true;
                    var fImgs = new Collection<ImageDocument>();
                    fImgs.Add(value as ImageDocument);

                    if (RaiseListChangedEvents)
                        OnBeforRemoveImage(new ImageEventArgs(fImgs), ref checkAllowRemove);

                    if (checkAllowRemove)
                    {
                        base.Remove(value);
                        if (RaiseListChangedEvents)
                            OnRemovedImage(new ImageEventArgs(fImgs));
                    }
                }
                else if (value is IList)
                {
                    bool checkAllowRemove = true;
                    var fImgs = new Collection<ImageDocument>();
                    for (int i = 0; i < ((IList)value).Count; i++)
                    {
                        fImgs.Add(((IList)value)[i] as ImageDocument);
                    }

                    if (RaiseListChangedEvents)
                        OnBeforRemoveImage(new ImageEventArgs(fImgs), ref checkAllowRemove );

                    if (checkAllowRemove)
                    {

                        

                        bool raiseChangedEvetesTemp = RaiseCurrentChangedEvents;

                        RaiseCurrentChangedEvents = false;
                        foreach (var VARIABLE in (IList) value)
                        {
                            if (((IList) value).IndexOf(VARIABLE) == ((IList) value).Count - 1)
                            {
                                RaiseCurrentChangedEvents = raiseChangedEvetesTemp;
                            }

                            base.Remove(VARIABLE);
                        }
                        OnRemovedImage(new ImageEventArgs(fImgs));
                        RaiseCurrentChangedEvents = raiseChangedEvetesTemp;
                    }


                }
            }
            finally 
            {
               // 
                
            }
          

          


        }

        protected override void OnDataSourceChanged(EventArgs e)
        {
            bool ch = RaiseListChangedEvents;

            RaiseListChangedEvents = false;

            base.OnDataSourceChanged(e);

            RaiseListChangedEvents = ch;
        }




        protected override void OnCurrentChanged(System.EventArgs e)
        {

            
            
            if (RaiseCurrentChangedEvents)
                base.OnCurrentChanged(e);
        }

        public override void RemoveAt(int index)
        {
            Remove(this[index]);
            //base.RemoveAt(index);
        }

        public ImageDocumentBindingSource(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void OnNeedImage(ImageEventArg e)
        {
            EventHandler<ImageEventArg> handler = NeedImage;
            if (handler != null) handler(this, e);
        }

        public void Move(object item, int index)
        {
            if (index < 0 || index >= Count)
                return;


           // var img = item.Tag as BaseImage;

            bool raiseListChangedEvents = RaiseListChangedEvents;

            try
            {
                RaiseListChangedEvents = false;
                int oldeindex = IndexOf(item);

                if (index == oldeindex)
                    return;

                Remove(item);
                Insert(index, item);
               // Items.Move(item, index);
               
                RaiseListChangedEvents = raiseListChangedEvents;
                OnListChanged(new ListChangedEventArgs(ListChangedType.ItemMoved, index, oldeindex));
                
                
                Position = index;
            }
            finally
            {
              
                RaiseListChangedEvents = raiseListChangedEvents;

            }


        }

        public void Print()
        {
            if (StartPrint != null)
            {
                StartPrint(this, null);
            }


            var frmPrint = new frmPrintPreView();
            frmPrint.CurrentTools = CurrentImageTools;
            frmPrint.PrintPage += frmPrint_PrintPage;
            frmPrint.NeedImage += frmPrint_NeedImage;
            frmPrint.CurrentViewImage = Current as ImageDocument;


            if (BeforPrintPage != null)
            {
                var ev = new ImageEventArg(frmPrint.CurrentViewImage);
                BeforPrintPage(this, ev);
            }


            frmPrint.AllImage = this;


            //for (int i = 0; i < Count; i++)
            //{
            //    var img = this[i] as ImageDocument;

            //    frmPrint.AllImage.Add(img);
            //}

            if (frmPrint.ShowDialog() == DialogResult.OK)
            {
                if (PrintedImages != null)
                {
                    try
                    {
                        var ep = new PrintDocEventArgs(frmPrint.PrintedIndex, frmPrint.PrintDocument.DocumentName, frmPrint.PrintDocument.PrinterSettings.PrinterName);
                        PrintedImages(this, ep);
                    }
                    catch
                    { }
                }
            }

            frmPrint.Dispose();
        }

        void frmPrint_NeedImage(object sender, ImageEventArg e)
        {
            OnNeedImage(new ImageEventArg(e.Image));
           // e.Image.ImageFullViewLayer = GetWholeImage(e.Image);
        }

        //public Bitmap GetWholeImage(ImageDocument img)
        //{

        //    if (img == null)
        //        return null;

        //    //      InitialImage(img);


        //    Bitmap bitmap = (Bitmap)img.Image;
        //    // BufferedGraphics bmyBuffer = null;
        //    try
        //    {

        //        Bitmap bmp = new System.Drawing.Bitmap((int)(img.Image.Width), (int)(img.Image.Height));

        //        //double widthZoomed = this.htfImageTool1.Width;
        //        //double heigthZoomed = this.htfImageTool1.Height;


        //        //    #endregion Added by rm
        //        Rectangle drawRect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);



        //        Graphics g = Graphics.FromImage(bmp);
        //        //    // g.DrawImage(img.Image, this.panel1.DisplayRectangle, drawRect, GraphicsUnit.Pixel);

        //        g.DrawImage(bitmap, drawRect, drawRect, GraphicsUnit.Pixel);

        //        if (img != null)
        //        {

        //            if (img.layers != null)
        //            {
        //                foreach (Layer layer in img.layers)
        //                {
        //                    if (layer.elements != null)
        //                    {
        //                        foreach (Element el in layer.elements)
        //                        {

        //                            if (el.Tag == null && el.Stream != null && el.Stream.Length > 10)
        //                            {
        //                                try
        //                                {
        //                                    System.IO.MemoryStream ms = new System.IO.MemoryStream(el.Stream);
        //                                    try
        //                                    {
        //                                        System.Drawing.Image myImage = System.Drawing.Image.FromStream(ms);
        //                                        el.Tag = myImage;
        //                                    }
        //                                    catch
        //                                    {

        //                                    }

        //                                    ms.Dispose();
        //                                }
        //                                catch
        //                                { }
        //                            }

        //                            if (el.Tag != null && el.Tag is Image)
        //                            {
        //                                Image TEmpimg = (Image)el.Tag;
        //                                //      TEmpimg.Save("c:\\pppp.jpg");
        //                                //                            int x = 0;
        //                                //                            if (this.htfImageTool1.DisplayRectangle.Size.Width > img.Image.Width * Zoom)
        //                                //                                x = (int)((this.panel1.DisplayRectangle.Size.Width - img.Image.Width * Zoom) / 2);

        //                                //                            int y = 0;
        //                                //                            if (this.htfImageTool1.DisplayRectangle.Size.Height > img.Image.Height * Zoom)
        //                                //                                y = (int)((this.htfImageTool1.DisplayRectangle.Size.Height - img.Image.Height * Zoom) / 2);


        //                                GraphicsUnit gu = GraphicsUnit.Pixel;
        //                                // g.DrawImage(TEmpimg, new Rectangle((int)(el.LocationX * htfImageTool1.Zoom) + x, (int)(el.LocationY * htfImageTool1.Zoom) + y, (int)(TEmpimg.Width * htfImageTool1.Zoom), (int)(TEmpimg.Height * htfImageTool1.Zoom)), TEmpimg.GetBounds(ref gu), GraphicsUnit.Pixel);
        //                                g.DrawImage(TEmpimg, new Rectangle((int)(el.LocationX), (int)(el.LocationY), (int)(TEmpimg.Width), (int)(TEmpimg.Height)), TEmpimg.GetBounds(ref gu), GraphicsUnit.Pixel);
        //                                //                        }
        //                                //                        else if (el.Stream != null)
        //                                //                        {

        //                            }

        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        g.Dispose();
        //        //System.IO.MemoryStream ms1 = new System.IO.MemoryStream();
        //        //bmp.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
        //        //ms1.Dispose();
        //        return bmp;
        //        // return bitmap;

        //    }
        //    catch (Exception ex)
        //    {
        //        //    if (bmyBuffer != null)
        //        //        bmyBuffer.Dispose();
        //        return (Bitmap)img.Image;
        //        //return null;
        //    }


        //}

        void frmPrint_PrintPage(object sender, PrintDocEventArgs e)
        {
            if (PrintPage != null)
                PrintPage(sender, e);
        }


        public void OpenFromXMLStream(string xmlImage)
        {

            try
            {
                var imgs = new ImageDocuments();
                //imgs.set_XML(xmlImage);

                //imgs.InitializeObject(null);

                var images = new List<ImageDocument>();
                foreach (var img in imgs)
                {


                    var ch = Encoding.Default.GetChars(img.Stream);
                    var bin = Convert.FromBase64CharArray(ch, 0, ch.Length);


                    var ms = new MemoryStream(bin);
                    var myImage = Image.FromStream(ms);

                    var newImageObject = new ImageDocument();
                   // newImageObject.Image = myImage;
                    newImageObject.ID = img.ID;
                    newImageObject.layers = img.layers;
                    newImageObject.Stream = img.Stream;
                    newImageObject.Tag = img.Tag;
                    newImageObject.Title = img.Title;
                    // newImageObject.Type = img.Type;
                    //newImageObject = (BaseImage)img;
                    images.Add(newImageObject);

                    ms.Close();
                    ms.Dispose();
                }


                //List<BaseImage> images = new List<BaseImage>();
                //// foreach (String file in openFileDialog.FileNames)
                //{
                //Image thisImage = Image.FromFile(file);
                //BaseImage newImageObject = new BaseImage(XMLImage);               
                //images.Add(newImageObject);
                //}

                AddImageRange(images.ToArray());

            }
            catch
            {
                try
                {

                  //  Add(new BaseImage(xmlImage));

                }
                catch
                {

                }
            }
        }

        public List<ImageDocument> OpenFromPaths(string[] paths)
        {
            var images = new List<ImageDocument>();
            foreach (var file in paths)
            {

                if (!AllowDuplicateFileNames)
                {
                    // در این قسمت باید ورودی جدید با مقادیر موجود مقایسه شود و اگر تکراری بود اضافه نشود
                    // این قسمت پیاده ساز شود
                    //if (file != null)
                    //{
                    //    if (this.List.Contains().Exists(a => string.Compare(a.FileName, item.FileName, StringComparison.OrdinalIgnoreCase) == 0))
                    //        return;
                    //}
                    //else
                    //{

                    //    if (mItems.Exists(a => string.Compare(a.Guid.ToString(), item.Guid.ToString(), StringComparison.OrdinalIgnoreCase) == 0))
                    //        return;
                    //}
                }


                if (Path.GetExtension(file) == ".xml")
                {
                    var sr = new StreamReader(file);
                    OpenFromXMLStream(sr.ReadToEnd());
                }
                else
                {
                    if (Path.GetExtension(file) == ".tiff" || Path.GetExtension(file) == ".tif" || Path.GetExtension(file) == ".TIF" || Path.GetExtension(file) == ".TIFF")
                    {
                        var myImg = Image.FromFile(file);
                       // myImg.Save("D:\\4545.jpg");
                        var intPages = myImg.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page); // getting the number of pages of this tiff

                        if (intPages >= 2)
                        {
                            //var newImageObjectTif = new BaseImage(myImg, file, file);
                            //newImageObjectTif.Image = myImg;
                            var imgs = CurrentImageTools.BaseTools.getMultiTifImages(myImg);
                            for (var j = 0; j < imgs.Count; j++)
                            {
                                var newImageObject = new ImageDocument();
                                newImageObject.Stream = this.CurrentImageTools.BaseTools.GetStreamImage(imgs[j],
                                                                                              System.Drawing.Imaging.
                                                                                                  ImageFormat.Tiff);
                              //  imgs[j].Save(@"D:\ui.tif");
                                Add(newImageObject);// new BaseImage(imgs[j], "", ""));
                            }
                        }

                        else
                        {
                            var newImageObject = new ImageDocument();// new BaseImage(null, file, file);
                            newImageObject.Description = file;
                            Add(newImageObject);
                        }

                        myImg.Dispose();
                        myImg = null;
                    }
                    else
                    {

                        var newImageObject = new ImageDocument();// new BaseImage(null, file, file);
                        newImageObject.Description = file;
                        Add(newImageObject);
                        //var newImageObject = new BaseImage(null, file, file);
                        //Add(newImageObject);
                        
                    }
                }
            }

           // AddImageRange(images.ToArray());


            return images;
        }

        private void AddImageRange(ImageDocument[] filmstripImages)
        {
            foreach (var fImg in filmstripImages)
            {
                Add(fImg);
                //
            }

        }

        public void Scan()
        {
            frmScan frm = new frmScan();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.AllImageScaned.Count > 0)
                {
                    for (int i = frm.AllImageScaned.Count; i > 0; i--)
                    {
                        if (frm.rbtnAddToFirst.Checked)
                        {
                            Insert(0, frm.AllImageScaned[i - 1]);

                            var mCol = new Collection<ImageDocument>();

                            foreach (ImageDocument imageDocument in this)
                            {
                                mCol.Add(imageDocument);
                            }
                            
                            OnMovedImages(new ImageEventArgs(mCol));


                        }
                        else
                        {
                           
                            Add(frm.AllImageScaned[frm.AllImageScaned.Count - i]);
                        }

                    }
                }
            }
            frm.AllImageScaned.Clear();
            frm.Dispose();
        }
    }
}
