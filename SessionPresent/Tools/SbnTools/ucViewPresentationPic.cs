using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Sbn.Controls.Imaging.EventArgsFolder;
using Sbn.Controls.Imaging.ImagingObject;
using Sbn.Core;
using Sbn.Products.GEP.GEPObject;

namespace SessionPresent.Tools.SbnTools
{
    public partial class ucViewPresentationPic : Sbn.Controls.Imaging.ImageDocumentsManager
    {
        public ucViewPresentationPic()
        {
            InitializeComponent();

            if(!DesignMode)
            {
                this.NeedImage += new EventHandler<ImageEventArg>(ucViewPresentationPic_NeedImage);
                this.NeedThumbnailsImage += new EventHandler<ImageEventArg>(ucViewPresentationPic_NeedThumbnailsImage);    
            }
            
        }

        void ucViewPresentationPic_NeedThumbnailsImage(object sender, ImageEventArg e)
        {
            if (e.Image.Stream == null)
            {
                try
                {


                    string strPath = CurrentObject._PhysicalPath + "\\Attachments\\PresentationAttach_" + e.Image.ID + "\\ThumbnailStream.dat";

                    using (var ms = new System.IO.StreamReader(strPath))
                    {
                        e.Image.ThumbnailStream = new byte[ms.BaseStream.Length];
                        ms.BaseStream.Read(e.Image.ThumbnailStream, 0, e.Image.ThumbnailStream.Length);
                        //  ms = new 
                        //this.CurrentImageTools.BaseTools.GetStreamImage()
                    }
                }
                catch
                {
                }

            }
        }

        void ucViewPresentationPic_NeedImage(object sender, ImageEventArg e)
        {
            if (e.Image.Stream == null)
            {
                try
                {

                    var gRepPic = new PresentationAttach();
                    string strPath = CurrentObject._PhysicalPath + "\\Attachments\\PresentationAttach_" + e.Image.ID + "\\Stream.dat";



                    using (var ms = new System.IO.StreamReader(strPath))
                    {
                        e.Image.Stream = new byte[ms.BaseStream.Length];
                        ms.BaseStream.Read(e.Image.Stream, 0, e.Image.Stream.Length);
                        //  ms = new 
                        //this.CurrentImageTools.BaseTools.GetStreamImage()
                    }
                }
                catch
                {
                }

            }
        }

        #region IUCHTFObject Members

        public void ClearData()
        {
            try
            {
                BindingSource.Position = 0;
                //this.CurrentObject.Attachments = null;
                //this.CurrentObject = new Presentation  ();
                this.ClearAll();
            }
            catch
            { }
        }

     

        public Presentation CurrentObject = new   Presentation ();
        
        public event EventHandler CurrentObjectChanged;

     

        public void FillObject(Presentation gRep, bool IsRefresh)
        {

            this.ClearData();

            this.CurrentObject = gRep;
            if (gRep.Attachments  != null && gRep.Attachments .Count > 0)
            {
                ImageDocuments imgs = new ImageDocuments();//[gRep.Attachments.Count];
                int i = 0;

                try
                {
                    foreach (PresentationAttach letPic in gRep.Attachments )
                    {
                        ImageDocument img = new ImageDocument();

                        img.OrderInDocument = letPic.OrderInDocument  ;
                        img.ID = letPic.ID;
                        img.layers = letPic.layers;
                        img.Stream = letPic.Stream;
                        img.Tag = letPic.Tag;
                        img.Title = letPic.Title;
                        //img.Type = letPic.Type;
                        if(i+1 == gRep.Attachments.Count)
                            img.ThumbnailStream = letPic.Stream  ;

                        if (letPic.ThumbnailStream != null && letPic.ThumbnailStream.Length > 10)
                            img.ThumbnailStream = letPic.ThumbnailStream;

                        imgs.Add(img);
                        //imgs[i] = img;

                        i++;
                    }

                    if (imgs.Count <= 1)
                    {
                        ThumbnailsView = false;
                        AllowViewContinusePages= false;
                        
                        //htfImageTool1.ZoomMode = ImageViewerList.ZoomMode.PageWidth;
                    }
                    else
                    {
                      //  ThumbnailsView = true;
                        AllowViewContinusePages = true;
                    }

                    try
                    {
                        PropertyDescriptorCollection properties
                                                = TypeDescriptor.GetProperties(typeof(ImageDocument));
                        PropertyDescriptor propertyDesc = properties.Find("OrderInDocument", true);
                        PropertyComparer<ImageDocument> pc = new PropertyComparer<ImageDocument>(propertyDesc, ListSortDirection.Ascending);
                        imgs.Sort(pc);

                    }
                    catch
                    {

                    }
                    AddImageRange(imgs);
                }
                catch
                {
                    throw;
                }

            }

            
            ImageViewer.ViewContinusePages = true;
            ImageViewer.FitToWidth();
            ImageViewer.ViewOffset = new System.Drawing.Point(1,0);
           

        }

        public void InitializeUI()
        {
            AllowMoveImage = false;
        }

        public bool VerifyDataEntry()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void ucViewPresentationPic_Load(object sender, EventArgs e)
        {
            InitializeUI();
        }

        private void ucViewPresentationPic_BeforSelectImage(object sender, ref ImageDocument selectedImage)
        {
//            try
//            {
//                if (selectedImage != null)
//                {
//                    long SelectedID = selectedImage.ID;
//                    if (SelectedID > 0)
//                    {
//                        PresentationAttach ff = (PresentationAttach)SCUtility.GEPService.getPresentationAttach(SelectedID, PresentationAttach.Stream_basic_sfg , new HTFCommon.RequestArgs()).parameter;
//                        selectedImage.Stream = ff.Stream;
////                         selectedImage.ThumbnailStream = ff.ThumbnailStream;
//                    }
//                }
//            }
//            catch
//            {

//            }
        }

        private void ucViewPresentationPic_MovedImage(object sender, ImageEventArgs e)
        {
        }

        

        private void ucViewPresentationPic_BeforFirstShowBigThumbNailImage(object sender, ImageEventArg e)
        {
           
        }
    }
}
