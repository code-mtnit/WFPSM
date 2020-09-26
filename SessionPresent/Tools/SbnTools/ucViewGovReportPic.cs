using System;
using System.ComponentModel;
using System.Windows.Forms;

using Sbn.Core;
using Sbn.Products.GEP.GEPObject;
using Sbn.Controls.Imaging.ImagingObject;
using Sbn.Controls.Imaging.EventArgsFolder;

namespace SessionPresent.Tools.SbnTools
{
    public partial class UcViewGovReportPic : Sbn.Controls.Imaging.ImageDocumentsManager
    {
        public UcViewGovReportPic()
        {
            InitializeComponent();
            NeedImage += UcViewGovReportPic_NeedImage;
            NeedThumbnailsImage += UcViewGovReportPic_NeedThumbnailsImage;
            //this.ToolbarNavigationView = false;
            //this.AllowRotate = false;
            //this.AllowMagnifair = false;
            this.AllowRotate = true;

        }

        public bool ReadOnly
        {
            get {
                return _readOnly;
            }
            set {
                _readOnly = value;
            }
        }

        void UcViewGovReportPic_NeedThumbnailsImage(object sender, ImageEventArg e)
        {
            if (e.Image.Stream == null)
            {
                try
                {

                   
                    string strPath = CurrentObject._PhysicalPath + "\\Pictures\\GovernmentReportPicture_" + e.Image.ID + "\\ThumbnailStream.dat";

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

        void UcViewGovReportPic_NeedImage(object sender, ImageEventArg e)
        {
            if (e.Image.Stream == null)
            {
                try
                {

                    var gRepPic = new GovernmentReportPicture();
                    string strPath = CurrentObject._PhysicalPath + "\\Pictures\\GovernmentReportPicture_" + e.Image.ID + "\\Stream.dat";



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
        
        public void ClearData()
        {
            try
            {
                BindingSource.Position = 0;
                CurrentObject = new GovernmentReport();
                ClearAll();

            }
            catch
            { }
        }

        public GovernmentReport CurrentObject = new GovernmentReport();
        private bool _readOnly;

        public void FillObject(GovernmentReport gRep, bool isRefresh)
        {

            //if (!SCUtility.CheckIsChangedObject(CurrentObject, gRep))
            //    return;

          
           
            ClearData();
            

            CurrentObject = gRep;
            if (gRep.Pictures != null && gRep.Pictures.Count > 0)
            {



                if (gRep.Pictures.Count == 1)
                {

                    ThumbnailsView = false;
                    AllowViewContinusePages = false;
                   // ImageViewer.ViewContinusePages = false;

                }
                else
                {
                 //   ThumbnailsView = true;
                    AllowViewContinusePages = true;
                 




                    try
                    {
                        PropertyDescriptorCollection properties
                                                = TypeDescriptor.GetProperties(typeof(GovernmentReportPicture));
                        PropertyDescriptor propertyDesc = properties.Find("OrderInDocument", true);
                        PropertyComparer<GovernmentReportPicture> pc = new PropertyComparer<GovernmentReportPicture>(propertyDesc, ListSortDirection.Ascending);
                        gRep.Pictures.Sort(pc);
                      
                    }
                    catch
                    {

                    }


                }

                
                var imgs = new ImageDocument[gRep.Pictures.Count];
                int i = 0;

                try
                {
                    foreach (var letPic in gRep.Pictures)
                    {
                        var img = new ImageDocument();

                        img.OrderInDocument = letPic.OrderInDocument;
                        img.ID = letPic.ID;
                        img.layers = letPic.layers;
                        img.Stream = letPic.Stream;
                        img.Tag = letPic.Tag;
                        img.OrderInDocument = letPic.OrderInDocument;
                        img.Title = letPic.Title;
                        img.GUid = letPic.GUid;
                        if (letPic.ThumbnailStream != null && letPic.ThumbnailStream.Length > 10)
                            img.ThumbnailStream = letPic.ThumbnailStream;


                        imgs[i] = img;

                        i++;
                    }

                    
                    AddImageRange(imgs);

                    if (AllowViewContinusePages)
                        ImageViewer.ViewContinusePages = AllowViewContinusePages;
                    ImageViewer.FitToWidth();
                    
                    //if (imgs.Length <= 1)
                    //{
                    //    ThumbnailsView = false;
                    //    tsbtnShowContinusPages.Checked = false;
                    //}
                    //else
                    //{
                    //    ThumbnailsView = true;
                    //    tsbtnShowContinusPages.Checked = true;

                    //}


                }
                catch
                {
                    throw;
                }

               

            }

            CurrentObject = gRep;


           
            
            ImageViewer.FitToWidth();

        }


    
      

      
       
    }
}
