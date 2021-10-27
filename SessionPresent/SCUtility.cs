using System.Net.Security;
using System.Security.Principal;
using SessionPresent.Model;
using SessionPresent.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using SessionPresent.Tools.SbnTools;
using SessionPresent.ViewModel;
using System.Windows.Media;

namespace SessionPresent
{
    public static class SCUtility
    {
        public static ApplicationDefinitions m_AppDef;
        public static string DefinisionPath = "C:\\Sayban" + "\\Definitions2.xml";

        public static void SaveSetting()
        {

            //if (WindowState == FormWindowState.Maximized)
            //{
            //    Properties.Settings.Default.PropertyValues["IsFormMaximized"].PropertyValue = true;
            //    Properties.Settings.Default.PropertyValues["FormLocation"].PropertyValue = RestoreBounds.Location;
            //    Properties.Settings.Default.PropertyValues["FormSize"].PropertyValue = RestoreBounds.Size;
            //}
            //else
            //{
            //    Properties.Settings.Default.PropertyValues["IsFormMaximized"].PropertyValue = false;
            //    Properties.Settings.Default.PropertyValues["FormLocation"].PropertyValue = Location;
            //    Properties.Settings.Default.PropertyValues["FormSize"].PropertyValue = Size;
            //}


            FileStream fs = new FileStream(SCUtility.DefinisionPath , FileMode.Create);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                formatter.Serialize(fs, SCUtility.m_AppDef);
            }
            catch (SerializationException ex)
            {
                System.Windows.MessageBox.Show("Failed to serialize. Reason: " + ex.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }


            Properties.Settings.Default.Save();
        }

        public static SessionUser CurrentSessionUser { get; set; }

        public static bool AuthenticateProccess()
        {
            var vm = new ViewModel.AuthenticateViewModel();
            var win = new Views.AuthenticateView();
            win.DataContext = vm;
            win.ShowDialog();
            CurrentSessionUser = vm.CurrentModel;

            if (CurrentSessionUser != null && CurrentSessionUser.Id > 0)
                return true;

            return false;
        }

        public static void LoadDefualtItem(MainViewModel vm)
        {
            SbnObjectTools.StartService(null);
            var gSessions = SbnObjectTools.LoadAllGovSession(Properties.Settings.Default.DefaultPath);

            vm.IsSessionManager = Properties.Settings.Default.IsAdmin;
            var fInfo = new FileInfo("c:\\Admin.txt");
            if (fInfo.Exists)
                vm.IsSessionManager = true;

            for (int i = 0 ; i< gSessions.Count;i++)
            {
                var gItm = gSessions[i];

                if (gItm.Messages!=null)
                {
                    vm.MessageTitle = gItm.Messages[0].MessageText;
                }

                if (gItm.Title != null)
                {
                    vm.MainTitle = gItm.Title.Replace("#", "\r\n");
                }
                if (gItm.GovReasonTitle != null)
                {
                    vm.Description = gItm.GovReasonTitle;
                }
                else
                {
                    vm.Description = "";
                }

                var govOrder = SbnObjectTools.GetSessionItem(gItm, vm.IsSessionManager);

                govOrder.BackColor = System.Drawing.Color.DarkGreen.Name;
                govOrder.ItemWidth = 200;
                govOrder.ItemIcon = "BookOpen";

                InitialPreOrderItems(ref gItm,ref govOrder);

                if (gItm.Messages != null && gItm.Messages.Count >0)
                {
                    vm.MessageTitle = gItm.Messages[0].MessageText;
                    vm.MessageDealy = gItm.Messages[0].DelayTime;
                    vm.MessageDuration = gItm.Messages[0].DurationTime;
                }
                //
                vm.Children.Add(govOrder);
            }



            //
            //var govSession = new GovSession();
            //govSession.SessionDate = "1393/02/25";
            //govSession.Catalogues = new Catalogues();
            //govSession.Catalogues.Add(
            //    new Catalogue
            //    {
            //        Title = "فهرست 1",
            //        Offers = new Offers
            //         {
            //             new Offer { OfficialCode = "45721", GovernReports = new GovernmentReports { new GovernmentReport { Title = "گزارش 1" } } } ,
            //             new Offer { OfficialCode = "54721", GovernReports = new GovernmentReports { new GovernmentReport { Title = "گزارش 1" } } } 
            //         }
            //    });
            //govSession.Catalogues.Add(
            //   new Catalogue
            //   {
            //       Title = "فهرست 2",
            //       Offers = new Offers
            //         {
            //             new Offer { OfficialCode = "45721", GovernReports = new GovernmentReports { new GovernmentReport { Title = "گزارش 1" } } } ,
            //             new Offer { OfficialCode = "54721", GovernReports = new GovernmentReports { new GovernmentReport { Title = "گزارش 1" } } } 
            //         }
            //   });

            //var itmGovSeesion = SbnObjectTools.GetSessionItem(govSession);

            //vm.Children.Add(itmGovSeesion);

            var itm0 = new SessionItemViewModel
            {
                Title = " جستجوگر متین",
                ObjectViewer = new Monitoring(),
                BackColor = System.Drawing.Color.DarkOrange.Name
                ,
                ItemWidth = 170,
                ItemIcon = "Magnify"
            };
            //vm.Children.Add(itm0);

            var itm1 = new SessionItemViewModel { Title = "گزارش جاری",
                ObjectViewer = new Monitoring() , BackColor=System.Drawing.Color.DarkBlue.Name 
                , ItemWidth = 200  , ItemIcon= "ClipboardPaper"};
            vm.Children.Add(itm1);

            // CurrentItems = new ObservableCollection<SessionItem>();
            // Properties.Settings.Default.OtherDocsPath
            try {
                var dirs = System.IO.Directory.GetDirectories(Properties.Settings.Default.OtherDocsPath);

                foreach (var dir in dirs)
                {
                    if (dir.IndexOf("پیامها") >= 0) continue;

                    var tt = Path.GetFileNameWithoutExtension(dir);
                    var itm2 = new SessionItemViewModel { Title = Path.GetFileNameWithoutExtension(dir), ObjectViewer = new SessionPresent.Tools.FolderLaws.LawsSearchView() , TitleForeColor = "Black"  , TitleBackColor= "White"};
                    var files = System.IO.Directory.GetFiles(dir);

                    var lawViewer = new Tools.FolderLaws.LawView();
                    foreach (var itm in files)
                    {
                        var sItm = new SessionItemViewModel(itm2);
                        if (dir.Contains("تلاوت"))//|| dir.Contains("اخبار و تبادل اطلاعات"))
                        {
                            sItm = new SessionItemViewModel((SessionItemViewModel)vm.Children[0]);
                        }
                        if (dir.Contains("تبادل اخبار و اطلاعات"))
                        {
                            foreach (SessionItemViewModel si in vm.Children[0].Children)
                            {
                                if (si.Title.Contains("تبادل اخبار و اطلاعات"))
                                    sItm = new SessionItemViewModel(si);
                            }
                        }

                        sItm.Title = Path.GetFileNameWithoutExtension(itm);
                        sItm.Object = itm;
                        sItm.ObjectViewer = lawViewer;
                        sItm.TitleForeColor = "Black";
                        sItm.TitleBackColor = "White";
                        itm2.Children.Add(sItm);

                    }

                    //vm.Children.Add(itm2);

                    if (dir.Contains("تلاوت"))
                    {
                        vm.Children[0].Children.Insert(0, itm2.Children[0]);
                    }
                    else if (dir.Contains("تبادل اخبار و اطلاعات"))
                    {
                        foreach (SessionItemViewModel si in vm.Children[0].Children)
                        {
                            if (si.Title.Contains("تبادل اخبار و اطلاعات"))
                            {
                                foreach (SessionItemViewModel i in itm2.Children)
                                {
                                    si.Children.Insert(si.Children.Count, i);
                                }
                            }
                        }
                    }
                    else if (itm2.Title == "قوانین کاربردی" || itm2.Title.Contains("بارش") || itm2.Title.Contains("ماهانه دفتر")) 
                    {

                        if(itm2.Title =="قوانین کاربردی")
                        {
                            itm2.ItemWidth = 200;
                            itm2.ItemIcon = "FolderOpen";
                            itm2.BackColor = System.Drawing.Color.DarkSalmon.Name;
                        }
                        if (itm2.Title.Contains("بارش"))
                        {
                            itm2.ItemIcon = "GraphBar";
                            itm2.ItemWidth = 200;
                            itm2.BackColor = System.Drawing.Color.BlueViolet.Name;

                        }
                        if (itm2.Title.Contains("ماهانه"))
                        {
                            itm2.ItemIcon = "CalendarMonth";
                            itm2.ItemWidth = 200;
                            itm2.BackColor = System.Drawing.Color.DarkTurquoise.Name;

                        }
                        vm.Children.Add(itm2);

                    }
                    else
                    {
                        itm2.ItemIcon = "FolderOpen";
                        itm2.ItemWidth = 200;
                        itm2.BackColor = System.Drawing.Color.DarkTurquoise.Name;

                        vm.Children.Add(itm2);
                    }

                }
            }
            catch(Exception ex)
            {
                

            }
          


          
            
        }

        public static void InitialPreOrderItems(ref Sbn.Products.GEP.GEPObject.GovSession gItm, ref SessionItemViewModel govOrder)
        {
            // load Quran Folder
            if (System.IO.Directory.Exists(gItm._PhysicalPath + "\\Quran")) //(govOrder.Children[0].Title.Contains("تلاوت"))
            {

                var quranViewer = new Tools.FolderLaws.LawView();
                var files = System.IO.Directory.GetFiles(gItm._PhysicalPath + "\\Quran");
                var quranItm = new SessionItemViewModel(govOrder);
                int iOrder = 0;
                if (files.Length > 0)
                {
                    quranItm.Title = Path.GetFileNameWithoutExtension(files[0]);
                    quranItm.Object = files[0];
                    quranItm.ObjectViewer = quranViewer;
                }
                else
                {
                    quranItm.Title = "تلاوت آیاتی از قرآن کریم";

                }

                if (gItm.PreOrders != null && gItm.PreOrders.Count > 0)
                {
                    var orderedItems = gItm.PreOrders.OrderBy(x => x.OrderInSession).ToList();

                    if (((Sbn.Products.GEP.GEPObject.PreSessionOrder)orderedItems[0]).Title.Contains("تلاوت"))
                    {
                        quranItm.TitleBackColor = ((Sbn.Products.GEP.GEPObject.PreSessionOrder)orderedItems[0]).TitleBackColor;
                        quranItm.TitleForeColor = ((Sbn.Products.GEP.GEPObject.PreSessionOrder)orderedItems[0]).TitleForeColor;
                    }
                    quranItm.Object = orderedItems[0];
                }

                /*
                var quranItem = govOrder.Children[0];
                quranItm.TitleBackColor =  ((SessionItemViewModel)quranItem).TitleBackColor;
                quranItm.TitleForeColor =  ((SessionItemViewModel)quranItem).TitleForeColor;
                */
                //govOrder.Children.RemoveAt(0);
                quranItm.Order = iOrder++;
                govOrder.Children.Insert(0, quranItm);

            }

            // Load News Folder
            if (System.IO.Directory.Exists(Properties.Settings.Default.OtherDocsPath + "\\پیامها"))//(govOrder.Children[0].Title.Contains("اخبار") || govOrder.Children[1].Title.Contains("اخبار"))
            {
                var quranViewer = new Tools.FolderLaws.LawView();
                var files = System.IO.Directory.GetFiles(Properties.Settings.Default.OtherDocsPath + "\\پیامها");
                var newsParent = new SessionItemViewModel(govOrder);
                newsParent.Title = "پیام ها";
                newsParent.Object = "پیام ها";
                newsParent.ObjectViewer = null;
                newsParent.ObjectViewer = new SessionPresent.Tools.FolderLaws.LawsSearchView();
                gItm.Messages = new Sbn.Products.GEP.GEPObject.GovSessionMessagings();


                foreach (string sfile in files)
                {
                    var newsItm = new SessionItemViewModel(newsParent);

                    newsItm.Title = Path.GetFileNameWithoutExtension(sfile);

                    string sMessage = File.ReadAllText(sfile);

                    try
                    {
                        string[] msg = sMessage.Split('#');

                        var m = new Sbn.Products.GEP.GEPObject.GovSessionMessaging { MessageText = msg[0], MessageTitle = sfile, DelayTime = (int.Parse(msg[1]) == 0 ? 5 : int.Parse(msg[1])), DurationTime = (int.Parse(msg[2]) == 0 ? 15 : int.Parse(msg[2])) };
                        newsItm.Object = m;
                        gItm.Messages.Add(m);
                        newsItm.ObjectViewer = quranViewer;
                        newsItm.IsVisibleInSessionOrderTree = false;
                        newsParent.Children.Add(newsItm);
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            //else {
            //    System.IO.Directory.CreateDirectory(Properties.Settings.Default.OtherDocsPath + "\\پیامها");
            //}
            
            if (System.IO.Directory.Exists(gItm._PhysicalPath + "\\News"))//(govOrder.Children[0].Title.Contains("اخبار") || govOrder.Children[1].Title.Contains("اخبار"))
            {

                //var NewsItem = null as TreeViewItemViewModel;

                /*
                if (govOrder.Children[0].Title.Contains("اخبار"))
                    NewsItem = govOrder.Children[0];
                if(govOrder.Children[1].Title.Contains("اخبار"))
                    NewsItem = govOrder.Children[1];
                */


                var newsParent = new SessionItemViewModel(govOrder);
                newsParent.Title = "بررسي و تبادل اخبار و اطلاعات در مورد مهمترين مسائل اجرايي روز كشور";
                newsParent.Object = "بررسي و تبادل اخبار و اطلاعات در مورد مهمترين مسائل اجرايي روز كشور";
                newsParent.ObjectViewer = null;
                newsParent.ObjectViewer = new SessionPresent.Tools.FolderLaws.LawsSearchView();

                /*
                newsParent.TitleBackColor = ((SessionItemViewModel)NewsItem).TitleBackColor;
                newsParent.TitleForeColor = ((SessionItemViewModel)NewsItem).TitleForeColor;
                */

                var quranViewer = new Tools.FolderLaws.LawView();
                var files = System.IO.Directory.GetFiles(gItm._PhysicalPath + "\\News");
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
                    if (govOrder.Children[0].Title.Contains("تلاوت"))
                    {
                        if (gItm.PreOrders != null)
                        {
                            var orderedItems = gItm.PreOrders.OrderBy(x => x.OrderInSession).ToList();

                            if (gItm.PreOrders.Count > 1)
                            {
                                if (((Sbn.Products.GEP.GEPObject.PreSessionOrder)orderedItems[1]).Title.Contains("اخبار"))
                                {
                                    newsParent.TitleBackColor = ((Sbn.Products.GEP.GEPObject.PreSessionOrder)orderedItems[1]).TitleBackColor;
                                    newsParent.TitleForeColor = ((Sbn.Products.GEP.GEPObject.PreSessionOrder)orderedItems[1]).TitleForeColor;
                                    if (newsParent.TitleForeColor == null)
                                    {
                                        newsParent.TitleBackColor = "White";
                                        newsParent.TitleForeColor = "Black";
                                    }
                                }
                            }

                            if (gItm.PreOrders.Count == 1)
                            {
                                if (((Sbn.Products.GEP.GEPObject.PreSessionOrder)orderedItems[0]).Title.Contains("اخبار"))
                                {
                                    newsParent.TitleBackColor = ((Sbn.Products.GEP.GEPObject.PreSessionOrder)orderedItems[0]).TitleBackColor;
                                    newsParent.TitleForeColor = ((Sbn.Products.GEP.GEPObject.PreSessionOrder)orderedItems[0]).TitleForeColor;
                                }
                            }
                        }

                        //govOrder.Children.RemoveAt(0);
                        govOrder.Children.Insert(1, newsParent);
                    }
                    else
                    {
                        //govOrder.Children.RemoveAt(1);
                        govOrder.Children.Insert(0, newsParent);
                    }

                    
                }
                foreach(Sbn.Products.GEP.GEPObject.PreSessionOrder pre in gItm.PreOrders)
                {
                    if (pre.Title.Contains("تلاوت") || pre.Title.Contains("قرآن") || pre.Title.Contains("اخبار") || pre.Title.Contains("خبر")) continue;

                    var preOrderfiles = System.IO.Directory.GetFiles(pre._PhysicalPath ).ToList();
                    var preItem = new SessionItemViewModel(govOrder);

                    if (preOrderfiles.Count > 1)
                    {
                        var fs = preOrderfiles.Where(x => x.Contains("mht")).ToList();

                        var preOrderViewer = new Tools.FolderLaws.LawView();
                        preItem.TitleBackColor = pre.TitleBackColor;
                        preItem.TitleForeColor = pre.TitleForeColor;

                        preItem.Title = Path.GetFileNameWithoutExtension(fs[0]);
                        preItem.Object = fs[0];
                        preItem.ObjectViewer = preOrderViewer;
                    }
                    else
                    {
                        preItem.Title = pre.Title;
                    }
                    govOrder.Children.Insert(gItm.PreOrders.Count-1, preItem);


                }

            }
        }
    }
}
