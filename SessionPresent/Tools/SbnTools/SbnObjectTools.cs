using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Sbn.Products.GEP.GEPObject;
using SessionPresent.ViewModel;
using System.Linq;

namespace SessionPresent.Tools.SbnTools
{
    public class SbnObjectTools
    {

        public static bool StartService(ISessionUser user)
        {


            if (user != null)
            {
                CurrentGovSessionMember = new GovSessionMember();
                CurrentGovSessionMember.Title = user.Title;

                long memId = 0;
                if (long.TryParse(user.AliasCode, out memId))
                {
                    CurrentGovSessionMember.ID = memId;
                }
            }
            else
            {
                //initial from file

                CurrentGovSessionMember = new GovSessionMember();
                CurrentGovSessionMember.Title = "مددی ، رسول";
                CurrentGovSessionMember.ID = 1;
            }

            return true;
        }

       public static SessionItemViewModel GetSessionItem(GovSession govSession, bool isSessionManager)
       {

            try {

                var itmGovSeesion = new SessionItemViewModel();

                itmGovSeesion.Title = "دستور جلسه " + govSession.SessionDate;
                itmGovSeesion.Object = govSession;
                itmGovSeesion.ObjectViewer = new Tools.SbnTools.GovSessionOrderView();

                ((Tools.SbnTools.GovSessionOrderView)itmGovSeesion.ObjectViewer).IsSessionManager = isSessionManager;

                var AllObj = new List<SessionItemViewModel>();

                if (govSession.Catalogues != null)
                {
                    var objViewerCat = new SbnTools.CatalugeView();
                    objViewerCat.IsSessionManager = isSessionManager;
                    foreach (var cat in govSession.Catalogues)
                    {

                        if (cat.Offers.Count == 0)
                            continue;

                        if (cat.Offers.Count == 1)
                        {
                            var objViewerOffer = new SbnTools.OfferView();
                            var off = cat.Offers[0];
                            var itmOff = new SessionItemViewModel(itmGovSeesion);

                            itmOff.Object = off;
                            itmOff.Title = cat.Title;
                            itmOff.ObjectViewer = objViewerOffer;
                            itmOff.Order = cat.OrderInSession;
                            itmOff.CanVoting = true;
                            itmOff.RefrenceAssemblly = "SessionPresent";
                            itmOff.BallotViewerClassName = "SessionPresent.Tools.SbnTools.GovSessionMemberOpinionView";
                            itmOff.IsVisibleInSessionOrderTree = true;
                            itmOff.TitleForeColor = (off.TitleForeColor != null ? off.TitleForeColor : "Black");
                            itmOff.TitleBackColor = (off.TitleBackColor != null ? off.TitleBackColor : "White");
                            AllObj.Add(itmOff);
                        }
                        else
                        {
                            var itmCat = new SessionItemViewModel(itmGovSeesion);
                            itmCat.Title = cat.Title;
                            itmCat.Object = cat;
                            itmCat.Order = cat.OrderInSession;
                            itmCat.ObjectViewer = objViewerCat;
                            itmCat.TitleForeColor = (cat.TitleForeColor != null ? cat.TitleForeColor : "Black");
                            itmCat.TitleBackColor = (cat.TitleBackColor != null ? cat.TitleBackColor : "White");

                            itmCat.IsCatalogue = true;

                            var objViewerOffer = new SbnTools.OfferView();
                            var AllObjOffer = new List<SessionItemViewModel>();

                            foreach (var off in cat.Offers)
                            {

                                var itmOff = new SessionItemViewModel(itmCat);

                                itmOff.Object = off;
                                itmOff.Title = off.OfficialCode;
                                itmOff.ObjectViewer = objViewerOffer;
                                itmOff.Order = off.OrderInCatalogue;
                                itmOff.CanVoting = true;
                                itmOff.RefrenceAssemblly = "SessionPresent";
                                itmOff.BallotViewerClassName = "SessionPresent.Tools.SbnTools.GovSessionMemberOpinionView";
                                itmOff.IsVisibleInSessionOrderTree = false;
                                itmOff.TitleForeColor = (off.TitleForeColor != null ? off.TitleForeColor : "Black");
                                itmOff.TitleBackColor = (off.TitleBackColor != null ? off.TitleBackColor : "White");

                                AllObjOffer.Add(itmOff);

                            }
                            AllObjOffer.Sort();
                            foreach (var itm in AllObjOffer)
                            {
                                itm.Order = AllObjOffer.IndexOf(itm) + 1;
                                ((Offer)itm.Object).OrderInCatalogue = (int)itm.Order;
                                itmCat.Children.Add(itm);
                            }

                            AllObj.Add(itmCat);
                        }



                    }
                }
                /*
                if (govSession.PreOrders != null)
                {
                    foreach (var cat in govSession.PreOrders)
                    {
                        var itmCat = new SessionItemViewModel(itmGovSeesion);
                        itmCat.Title = cat.Title;
                        itmCat.Object = cat;
                        itmCat.Order = cat.OrderInSession;
                        itmCat.TitleBackColor = cat.TitleBackColor;
                        itmCat.TitleForeColor = cat.TitleForeColor;

                        AllObj.Add(itmCat);
                    }
                }
                */

                if (govSession.GovPresents != null)
                {

                    var objViewerCat = new SbnTools.CatalugeView();
                    objViewerCat.IsSessionManager = isSessionManager;
                    var objViewerPrs = new SbnTools.PresentationView();
                    foreach (var cat in govSession.GovPresents)
                    {
                        var itmCat = new SessionItemViewModel(itmGovSeesion);
                        itmCat.Title = cat.Title;
                        itmCat.Object = cat;
                        itmCat.Order = cat.OrderInSession;
                        itmCat.ObjectViewer = objViewerPrs;// new SbnTools.PresentationView(); ; 
                        itmCat.TitleForeColor = (cat.TitleForeColor != null ? cat.TitleForeColor : "Black");
                        itmCat.TitleBackColor = (cat.TitleBackColor != null ? cat.TitleBackColor : "White");


                        var AllObjOffer = new List<SessionItemViewModel>();

                        if (cat.Presentations != null)
                            foreach (var prs in cat.Presentations)
                            {
                                var itmPrs = new SessionItemViewModel(itmCat);
                                itmPrs.ObjectViewer = objViewerPrs;// new SbnTools.PresentationView(); ;
                                itmPrs.Title = prs.Title;
                                itmPrs.Object = prs;
                                itmPrs.Order = prs.OrderInSession;
                                itmPrs.TitleForeColor = (prs.TitleForeColor != null ? prs.TitleForeColor : "Black");
                                itmPrs.TitleBackColor = (prs.TitleBackColor != null ? prs.TitleBackColor : "White");

                                AllObjOffer.Add(itmPrs);
                            }
                        foreach (var itm in AllObjOffer)
                        {
                            itm.Order = AllObjOffer.IndexOf(itm) + 1;
                            ((Presentation)itm.Object).OrderInSession = (int)itm.Order;
                            itmCat.Children.Add(itm);
                        }

                        AllObj.Add(itmCat);
                    }
                }

                if (govSession.Presentations != null)
                {
                    var objViewerPrs = new SbnTools.PresentationView();
                    foreach (var prs in govSession.Presentations)
                    {
                        var itmPrs = new SessionItemViewModel(itmGovSeesion);
                        itmPrs.ObjectViewer = objViewerPrs;
                        itmPrs.Title = prs.Title;
                        itmPrs.Object = prs;
                        itmPrs.Order = prs.OrderInSession;
                        itmPrs.TitleForeColor = (prs.TitleForeColor != null ? prs.TitleForeColor : "Black");
                        itmPrs.TitleBackColor = (prs.TitleBackColor != null ? prs.TitleBackColor : "White");

                        AllObj.Add(itmPrs);
                    }
                }


                AllObj.Sort();
                foreach (var metaData in AllObj)
                {
                    itmGovSeesion.Children.Add(metaData);
                }



                return itmGovSeesion;
            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }

            return null;
        }

       public static GovSession InitialGovSession(string path)
        {


            GovSession gov = new GovSession();
          //  Hatefnet.Products.Controls.WaitForm.WaitForm.getInstance().stopW();
            try
            {
                gov.Load(path, new List<string> { "~GovernmentReportPicture.Stream", "~GovernmentReportPicture.ThumbnailStream", "~PresentationAttach.Stream", "~PresentationAttach.ThumbnailStream", "~WordDocument.Stream" });
            }
            catch (Exception ex)
            {

                gov = null;
            }
          //  Hatefnet.Products.Controls.WaitForm.WaitForm.getInstance().stopW();

            return gov;
        }

       public static GovSessions LoadAllGovSession(string path)
        {
            GovSessions AllGSessions = new GovSessions();

            //this.notifyIcon1.ShowBalloonTip(2000, "کارتابل الکترونیکی هیأت دولت", "در حال بارگذاری اطلاعات جلسه", ToolTipIcon.Info);

            Sbn.Windows.Forms.AdvancedControls.WaitForm.WaitForm.getInstance().startW(2);
            Sbn.Windows.Forms.AdvancedControls.WaitForm.WaitForm.getInstance().BringToFront();
            try
            {

                string[] AllPath = System.IO.Directory.GetDirectories(path);
                foreach (string pt in AllPath)
                {

                    string SelectedPath = pt;
                    try
                    {
                        if (!SelectedPath.Contains("GovSession_"))
                        {
                            var AllDocs = Directory.GetDirectories(pt);

                            if (AllDocs != null && AllDocs.Length > 0)
                            {
                                foreach (string doc in AllDocs)
                                {
                                    if (doc.Contains("GovSession_"))
                                    {
                                        SelectedPath = doc;
                                        break;
                                    }
                                    else
                                    {
                                        SelectedPath = "";
                                    }
                                }

                            }
                        }


                        if (SelectedPath != "")
                        {
                            GovSession gov = InitialGovSession(SelectedPath);
                            gov.SessionDate = gov.SessionDate.Substring(0, 10);
                            if (gov != null)
                                AllGSessions.Add(gov);
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {

            }
            Sbn.Windows.Forms.AdvancedControls.WaitForm.WaitForm.getInstance().stopW();

            int gcount = 0;
            while(gcount < AllGSessions.Count)
            {
                GovSession g = AllGSessions[gcount];

                int ccount = 0;
                while (ccount < g.Catalogues.Count)
                {
                    Catalogue c = g.Catalogues[ccount];

                    int fcount = 0;
                    while (fcount < c.Offers.Count)
                    {
                        Offer f = c.Offers[fcount];
                        if(f.PresenterOrgans != null && f.PresenterOrgans.Count >0)
                        {
                            f.OwnerOrgan.CorrelateOrgUnit.Title = "";
                            foreach (Sbn.Systems.WMC.WMCObject.OrgUnit o in f.PresenterOrgans)
                            {
                                if (f.OwnerOrgan.CorrelateOrgUnit.Title != "") f.OwnerOrgan.CorrelateOrgUnit.Title += " , ";

                                f.OwnerOrgan.CorrelateOrgUnit.Title += o.Title; 

                            }
                        }
                        fcount++;
                    }

                    ccount++;

                }


                gcount++;

            }

            return AllGSessions;
        }

       public static GovSessions OpenFile(TreeViewItemViewModel vm,bool isSessionManager)
       {
           try
           {
               var folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
               if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
               {
                   var gSessions = LoadAllGovSession(folderBrowserDialog1.SelectedPath);
                   for (int i=0; i < gSessions.Count; i++ )
                   {
                        GovSession govSession = gSessions[i];
                        var govSes = GetSessionItem(govSession, isSessionManager);
                            
                        SCUtility.InitialPreOrderItems(ref govSession, ref govSes);
                        /*
                        //
                        // load Quran Folder
                        if (System.IO.Directory.Exists(govSession._PhysicalPath + "\\Quran")) //(govOrder.Children[0].Title.Contains("تلاوت"))
                        {
                            var quranViewer = new Tools.FolderLaws.LawView();
                            var files = System.IO.Directory.GetFiles(govSession._PhysicalPath + "\\Quran");

                            var quranItm = new SessionItemViewModel(govSes);

                            if (files.Length > 0)
                            {

                                quranItm.Title = Path.GetFileNameWithoutExtension(files[0]);
                                quranItm.Object = files[0];
                                quranItm.ObjectViewer = quranViewer;
                            }

                            if (govSession.PreOrders != null && govSession.PreOrders.Count > 0)
                            {
                                var orderedItems = govSession.PreOrders.OrderBy(x => x.OrderInSession).ToList();

                                if (((Sbn.Products.GEP.GEPObject.PreSessionOrder)orderedItems[0]).Title.Contains("تلاوت"))
                                {
                                    quranItm.Title = ((Sbn.Products.GEP.GEPObject.PreSessionOrder)orderedItems[0]).Title;

                                    quranItm.TitleBackColor = ((Sbn.Products.GEP.GEPObject.PreSessionOrder)orderedItems[0]).TitleBackColor;
                                    quranItm.TitleForeColor = ((Sbn.Products.GEP.GEPObject.PreSessionOrder)orderedItems[0]).TitleForeColor;
                                    govSes.Children.Insert(0, quranItm);
                                }
                            }
                        }
                        //

                        // Load News Folder

                        if (System.IO.Directory.Exists(govSession._PhysicalPath + "\\News"))//(govOrder.Children[0].Title.Contains("اخبار") || govOrder.Children[1].Title.Contains("اخبار"))
                        {




                            var newsParent = new SessionItemViewModel(govSes);
                            newsParent.Title = "بررسي و تبادل اخبار و اطلاعات در مورد مهمترين مسائل اجرايي روز كشور";
                            newsParent.Object = "بررسي و تبادل اخبار و اطلاعات در مورد مهمترين مسائل اجرايي روز كشور";
                            newsParent.ObjectViewer = null;
                            newsParent.ObjectViewer = new SessionPresent.Tools.FolderLaws.LawsSearchView();


                            var quranViewer = new Tools.FolderLaws.LawView();
                            var files = System.IO.Directory.GetFiles(govSession._PhysicalPath + "\\News");
                            foreach (string sfile in files)
                            {
                                var newsItm = new SessionItemViewModel(newsParent);

                                newsItm.Title = Path.GetFileNameWithoutExtension(sfile);
                                newsItm.Object = sfile;
                                newsItm.ObjectViewer = quranViewer;
                                newsItm.IsVisibleInSessionOrderTree = false;
                                newsParent.Children.Add(newsItm);
                            }
                            //if (NewsItem != null)
                            {
                                if (govSes.Children[0].Title.Contains("تلاوت"))
                                {
                                    //govOrder.Children.RemoveAt(0);
                                    if (govSession.PreOrders != null)
                                    {
                                        var orderedItems = govSession.PreOrders.OrderBy(x => x.OrderInSession).ToList();

                                        if (govSession.PreOrders.Count > 1)
                                        {
                                            if (((Sbn.Products.GEP.GEPObject.PreSessionOrder)orderedItems[1]).Title.Contains("اخبار"))
                                            {
                                                newsParent.TitleBackColor = ((Sbn.Products.GEP.GEPObject.PreSessionOrder)orderedItems[1]).TitleBackColor;
                                                newsParent.TitleForeColor = ((Sbn.Products.GEP.GEPObject.PreSessionOrder)orderedItems[1]).TitleForeColor;
                                            }
                                        }

                                        if (govSession.PreOrders.Count == 1)
                                        {
                                            if (((Sbn.Products.GEP.GEPObject.PreSessionOrder)orderedItems[0]).Title.Contains("اخبار"))
                                            {
                                                newsParent.TitleBackColor = ((Sbn.Products.GEP.GEPObject.PreSessionOrder)orderedItems[0]).TitleBackColor;
                                                newsParent.TitleForeColor = ((Sbn.Products.GEP.GEPObject.PreSessionOrder)orderedItems[0]).TitleForeColor;
                                            }
                                        }
                                    }
                                    govSes.Children.Insert(1, newsParent);
                                }
                                else
                                {
                                    //govOrder.Children.RemoveAt(1);
                                    govSes.Children.Insert(0, newsParent);
                                }
                            }
                        }
                        //
                        */
                        govSes.BackColor = System.Drawing.Color.DarkGreen.Name;
                        govSes.ItemWidth = 200;
                        govSes.ItemIcon = "BookOpen";
                        vm.Children.Add(govSes);                       
                   }

                   return gSessions;

               }
           }
           catch
           {
            }

           return new GovSessions();
       }

       public static GovSessionMember CurrentGovSessionMember { get; set; }
    }
}
