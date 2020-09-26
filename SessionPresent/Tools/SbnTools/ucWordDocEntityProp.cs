using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Sbn.Products.GEP.GEPObject;
using Sbn.Core;
using Sbn.Systems.WMC.WMCObject;
using Sbn.AdvancedControls.WordControlDocument;

namespace SessionPresent.Tools.SbnTools.FolderWordDocument
{
    public partial class ucWordDocEntityProp : UserControl 
    {

        public GeneralDocument CurrentGeneralDocument = null;

        bool _ReadOnly = false;

        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                this.panel1.Visible = false;

                try
                {
                    if (this.CurrentGeneralDocument != null)
                        this.lblGDocID.Text = "شاخص : " + this.CurrentGeneralDocument.ID.ToString();
                }
                catch
                { 

                }
               
            }
        }


        bool _IsLocked = false;

        //public bool IsLocked
        //{
        //    get { return _IsLocked; }
        //    set
        //    {
        //        _IsLocked = value;
        //        this.panel1.Visible = value;

        //    }
        //}

        public ucWordDocEntityProp()
        {
            InitializeComponent();
            this.Disposed += new EventHandler(ucWordDocEntityProp_Disposed);
          
        }

        void ucWordDocEntityProp_Disposed(object sender, EventArgs e)
        {
            //if (!this.ReadOnly &&  this.CurrentGeneralDocument != null && this.CurrentGeneralDocument.ID > 0)
            //{
            //    //if (this.CurrentGeneralDocument.IsLocked != SbnBoolean.True)
            //        GEPUtility.LockedGeneralDocument(this.CurrentGeneralDocument, SbnBoolean.False);
            //}
        }

        #region IUCHTFObject Members

        public void ClearData()
        {
            if (!this.ReadOnly && this.CurrentGeneralDocument != null && this.CurrentGeneralDocument.ID > 0)
            {
                //if (this.CurrentGeneralDocument.IsLocked != SbnBoolean.False)
                //    GEPUtility.LockedGeneralDocument(this.CurrentGeneralDocument, SbnBoolean.False);
            }

            this.CurrentGeneralDocument = null;
            this.CurrentObject = null;

            this.wordControlDocument1.CloseActiveDocument();
            //this.wordControlDocument1.CloseWordApp();
        }

        public void RefreshAll()
        {
            this.wordControlDocument1.RefreshAll();
        }

     

        public WordDocument CurrentObject = null;

        public WordDocument CreateObject()
        {
            WordDocument word = this.CurrentObject;
            if (word == null)
            {
                word = CreateNewObject();
            }
           // word.EditionDate = Sbn.Controls.AdvancedControls.FDate.Utils.PersianDate.Now.ToString("G");
            word.Stream = wordControlDocument1.CurrentStream;

            return word;

        }

        public WordDocument StartNewObject()
        {
            WordDocument wd = new WordDocument();
            wd.Title = "ویرایش جدید";
           // wd.EditionDate = Sbn.Controls.AdvancedControls.FDate.Utils.PersianDate.Now.ToString("G");
            wordControlDocument1.NewDocument();
            CurrentObject = wd;
            return wd;   
        }


        public WordDocument CreateNewObject()
        {
            WordDocument wd = new WordDocument();
            wd.Title = "ویرایش جدید";
           // wd.EditionDate = Sbn.Controls.AdvancedControls.FDate.Utils.PersianDate.Now.ToString("G");
            return wd;
        }

        public WordDocument Register(WordDocument wd)
        {
            return null;
        }

        //public WordDocument Save(WordDocument wd)
        //{

        //    if (wd.ID < 0)
        //    {
        //        WordDocument wdTemp = this.CreateObject();
        //        wdTemp.ID = -1;


        //        if (wdTemp.CorrelateDoc != null)
        //            wdTemp.CorrelateDoc = new GeneralDocument {ID = wd.CorrelateDoc.ID};



        //        var rre = GEPUtility.GEPService.Request(null, new WordDocument { Stream = wdTemp.Stream, Title = wdTemp.Title, CorrelateDoc = new GeneralDocument { ID = wd.CorrelateDoc.ID } }, RequestType.Register, "", null,
        //                                                GEPUtility.ActiveRequestArgs);

        //        if (AppUtility.CheckResult(rre, false))
        //        {
        //            wdTemp.ID = ((WordDocument)rre.ResultObject).ID;
        //            return wdTemp;
        //        }
        //        //پیاده سازی شود
        //    }

        //    if (wd.ID > 0 && !ReadOnly)
        //    {
              
        //        WordDocument wdTemp = this.CreateObject();

        //        var reess = GEPUtility.GEPService.Request(new WordDocument{ID =  wdTemp.ID},new WordDocument{ID = wdTemp.ID , Stream = wdTemp.Stream}, RequestType.Update, "",
        //                                                  new List<string> {WordDocument.at_Stream},
        //                                                  GEPUtility.ActiveRequestArgs);
             
        //      //  var res = GEPUtility.GEPService.removeWordDocument(wd.ID, GEPUtility.ActiveRequestArgs);

        //       // if (AppUtility.CheckResult(res, false))
        //        {
        //            //wdTemp.ID = -1;
        //            //wdTemp.CorrelateDoc = wd.CorrelateDoc;
        //            //var res1 = GEPUtility.GEPService.registerWordDocument(wdTemp, GEPUtility.ActiveRequestArgs);

        //            //wdTemp.ID = ((WordDocument)res1.ResultObject).ID;
        //            //this.CurrentObject.ID = wdTemp.ID;

        //            //wdTemp.CorrelateDoc = wd.CorrelateDoc;
        //            //var reess = GEPUtility.GEPService.updateWordDocument(wdTemp, wdTemp.ID, WordDocument.CorrelateDocFirstLevelAttributes, GEPUtility.ActiveRequestArgs);

        //            return wd;
        //        }
        //    }

        //    return null;
        //}

        public void Update(WordDocument wd)
        { 

        }

        public event EventHandler CurrentObjectChanged;

        public void FillBasicInfo()
        {
        }

        public void FillObject(GeneralDocument gDoc, bool IsRefresh, bool IsReadOnly)
        {
            WordDocument obj = null;


            if (gDoc == null || gDoc.ID < 0)
            {
                this.ClearData();
                return;
            }
            this.ReadOnly = IsReadOnly;


            //if (!Sbn.Products.GEP.GEPSessionPresent.SCUtility.CheckIsChangedObject(CurrentGeneralDocument, gDoc) && !IsRefresh)
            //{
            //    return;
            //}

            this.CurrentGeneralDocument = gDoc;

            if (gDoc.FileVersions == null)
            {
                //var ress = GEPUtility.GEPService.Request(null, gDoc, RequestType.Get, "",
                //                                         new List<string> { GeneralDocument.at_FirstLevelAttributes, GeneralDocument.at_FileVersionsFirstLevelAttributes, GeneralDocument.at_OwnerFirstLevelAttributes },
                //                                         GEPUtility.ActiveRequestArgs);

                //if (AppUtility.CheckResult(ress, false))
                //{
                //    this.CurrentGeneralDocument.FileVersions = ((GeneralDocument)ress.ResultObject).FileVersions;
                //    this.CurrentGeneralDocument.IsHidden = ((GeneralDocument)ress.ResultObject).IsHidden;
                //    this.CurrentGeneralDocument.IsLocked = ((GeneralDocument)ress.ResultObject).IsLocked;
                //    this.CurrentGeneralDocument.Title = ((GeneralDocument)ress.ResultObject).Title;
                //    this.CurrentGeneralDocument.Owner = ((GeneralDocument)ress.ResultObject).Owner;

                //}
            }

            if (gDoc.FileVersions != null && gDoc.FileVersions.Count > 0)
            {
                obj = gDoc.FileVersions[gDoc.FileVersions.Count - 1];
                obj.CorrelateDoc = new GeneralDocument { Extension = gDoc.Extension };
                obj.Title = gDoc.Title;
                this.FillObject(obj, false, IsReadOnly);
            }

       
        }

        public void FillObject(WordDocument obj, bool IsRefresh, bool IsReadOnly )
        {
            if (obj == null)
                return;

            //if (!Sbn.Products.GEP.GEPSessionPresent.SCUtility.CheckIsChangedObject(this.CurrentObject, obj))
            //    return;

            CurrentObject = null;
            wordControlDocument1.CloseActiveDocument();
            
            ReadOnly = IsReadOnly;

            if (!IsReadOnly && obj.ID > 0)
            {
                if (this.CurrentGeneralDocument != null && this.CurrentGeneralDocument.IsLocked == SbnBoolean.True)
                {

                    Worker editorWorker = null;
                    string strActiveWorker = "";
                   

                    this.label1.Text = "این مستند تایپی " + strActiveWorker + " در حال ویرایش می باشد";

                
                    
                }
                else
                {
                   // GEPUtility.LockedGeneralDocument(this.CurrentGeneralDocument, SbnBoolean.True);
                }
            }


          //  Hatefnet.Products.Controls.WaitForm.WaitForm.getInstance().startW();
            if (obj.ID > 0 && obj.Stream == null)
            {
                try
                {


                    string strPath = obj._PhysicalPath + "\\Stream.dat";

                    using (var ms = new System.IO.StreamReader(strPath))
                    {
                        obj.Stream = new byte[ms.BaseStream.Length];
                        ms.BaseStream.Read(obj.Stream, 0, obj.Stream.Length);
                        //  ms = new 
                        //this.CurrentImageTools.BaseTools.GetStreamImage()
                    }
                }
                catch
                {
                }

            }

            if (obj.Stream != null)
            {
                try
                {
                    if (obj.Title != null)
                    {
                        obj.Title = obj.Title.Replace("\\", "");
                        obj.Title = obj.Title.Replace("/", "");
                    }


                    this.wordControlDocument1.OpenWordDocument(obj.Stream , obj.Title ,  (FileExtension)Enum.Parse( typeof(FileExtension) , obj.CorrelateDoc.Extension));
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);

                   // Hatefnet.Products.Controls.WaitForm.WaitForm.getInstance().stopW();

                }
            }
            else
            {
                this.wordControlDocument1.NewDocument();
            }

            this.CurrentObject = obj;

            wordControlDocument1.SetFullScreenView();
            

          //  Hatefnet.Products.Controls.WaitForm.WaitForm.getInstance().stopW();
        }

        public void InitializeUI()
        {
            throw new NotImplementedException();
        }

        public bool VerifyDataEntry()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void wordControlDocument1_AfterPrintDocument(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //try
            //{

            //    Sbn.Systems.WMC.Tools.Utility.RegisterEvent("PrintGeneralDocument", "چاپ مستند تایپی", "تعداد صفحات : ",
            //                                                (long) GEPUtility.DocEnum.WordDoc, CurrentGeneralDocument.ID);
            //}
            //catch
            //{ }
        }

        private void wordControlDocument1_AfterGetImageFromDocument(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //try
            //{
               

            //    Sbn.Systems.WMC.Tools.Utility.RegisterEvent("PrintGeneralDocumentToFile", "استخراج تصویر از مستند تایپی", "", (long)GEPUtility.DocEnum.WordDoc, CurrentGeneralDocument.ID);
            //}
            //catch
            //{ }
        }
    }
}
