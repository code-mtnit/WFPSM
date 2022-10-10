using BaseClass;
using MonitorInfoViewer;
using Sbn.Controls.AdvancedControls.AddressBar;
using Sbn.Products.GEP.GEPObject;
using SessionPresent.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SessionPresent.Tools.SbnTools;
using SessionPresent.ViewModel;
using System.IO;

namespace SessionPresent.Views
{
    /// <summary>
    /// Interaction logic for SessionToolBarView.xaml
    /// </summary>
    public partial class SessionToolBarView : UserControl
    {
        public SessionToolBarView()
        {
            InitializeComponent();
            Loaded += SessionToolBarView_Loaded;

            try
            {
                bar.PathChanged += bar_PathChanged;
            }
            catch
            {

            }

            
        }

        void SessionToolBarView_Loaded(object sender, RoutedEventArgs e)
        {
            History<string>.Memorize(bar.RootItem.Header.ToString());
        }


         public event EventHandler ToggleTreeView;
        public event EventHandler GoBack;
        public event EventHandler GoNext;

        public void OnGoNext(EventArgs e)
        {
            EventHandler handler = GoNext;
            if (handler != null) handler(this, e);
        }

        public void OnGoBack(EventArgs e)
        {
            EventHandler handler = GoBack;
            if (handler != null) handler(this, e);
        }

        public void OnToggleTreeView(EventArgs e)
        {
            EventHandler handler = ToggleTreeView;
            if (handler != null) handler(this, e);
        }

        public event EventHandler OpenGovSession;
        public event EventHandler RefreshGovSession;
        public event EventHandler CloseGovSession;

        public void OnCloseGovSession(EventArgs e)
        {
            EventHandler handler = CloseGovSession;
            if (handler != null) handler(this, e);
        }

        public event EventHandler SyncPathView;

        public void OnSyncPathView(EventArgs e)
        {
            EventHandler handler = SyncPathView;
            if (handler != null) handler(this, e);
        }

        public void OnRefreshGovSession(EventArgs e)
        {
            EventHandler handler = RefreshGovSession;
            if (handler != null) handler(this, e);
        }

        public void OnOpenGovSession(EventArgs e)
        {
            if (DataContext == null)
                return;
            
            SbnObjectTools.OpenFile(DataContext as TreeViewItemViewModel,((MainViewModel)DataContext).IsSessionManager);

            EventHandler handler = OpenGovSession;
            if (handler != null) handler(this, e);
        }



     

        


        public void ClearData()
        {
            History<string>.Delete();
        }

        void bar_PathChanged(object sender, RoutedPropertyChangedEventArgs<string> e)
        {

            var ff = bar.SelectedItem as SessionItemViewModel;
            if (ff == null)
            {
                if (bar.IsRootSelected)
                {
                    ((MainViewModel)DataContext).CurrentViewItem = null;
                    History<string>.Memorize(e.NewValue);
                }
                return;
            }
            if (ff.Parent != null)
                ff.Parent.IsExpanded = true;
            ff.IsSelected = true;
            if (DataContext != null)
                ((MainViewModel)DataContext).CurrentViewItem = ff;
            if(ff.ObjectViewer != null)
                History<string>.Memorize(e.NewValue);
        }


      

      
     

        private void BreadcrumbBar_PopulateItems(object sender, Sbn.Controls.AdvancedControls.AddressBar.BreadcrumbItemEventArgs e)
        {
            BreadcrumbItem item = e.Item;
            if (item.Items.Count == 0)
            {
                PopulateFolders(item);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Populate the Items of the specified BreadcrumbItem with the sub folders if necassary.
        /// </summary>
        /// <param name="item"></param>
        private static void PopulateFolders(BreadcrumbItem item)
        {
            BreadcrumbBar bar = item.BreadcrumbBar;
            string path = bar.PathFromBreadcrumbItem(item);
            string trace = item.TraceValue;
            if (trace.Equals("Computer"))
            {
                string[] dirs = System.IO.Directory.GetLogicalDrives();
                foreach (string s in dirs)
                {
                    //string dir = s;
                    //if (s.EndsWith(bar.SeparatorString)) dir = s.Remove(s.Length - bar.SeparatorString.Length, bar.SeparatorString.Length);
                    //FolderItem fi = new FolderItem();
                    //fi.Folder = dir;

                    //item.Items.Add(fi);
                }
            }
            else
            {
                try
                {
                    if (item.Data is SessionItemViewModel)
                    {
                        foreach (var row in (item.Data as SessionItemViewModel).Children)
                        {
                            item.Items.Add(row as SessionItemViewModel);
                        }
                    }

                }
                catch { }
            }
        }


        private void BreadcrumbBar_PathConversion(object sender, PathConversionEventArgs e)
        {
            if (e.Mode == PathConversionEventArgs.ConversionMode.DisplayToEdit)
            {
                if (e.DisplayPath.StartsWith(@"Computer\", StringComparison.OrdinalIgnoreCase))
                {
                    e.EditPath = e.DisplayPath.Remove(0, 9);
                }
                else if (e.DisplayPath.StartsWith(@"Network\", StringComparison.OrdinalIgnoreCase))
                {
                    string editPath = e.DisplayPath.Remove(0, 8);
                    editPath = @"\\" + editPath.Replace('\\', '/');
                    e.EditPath = editPath;
                }
            }
            else
            {
                if (e.EditPath == null)
                    return;
                if (e.EditPath.StartsWith("c:", StringComparison.OrdinalIgnoreCase))
                {
                    e.DisplayPath = @"Desktop\Computer\" + e.EditPath;
                }
                else if (e.EditPath.StartsWith(@"\\"))
                {
                    e.DisplayPath = @"Desktop\Network\" + e.EditPath.Remove(0, 2).Replace('/', '\\');
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //((MainViewModel)DataContext).IsProgressing = true;

            //Thread tr = new Thread(delegate() { Progress(); });
            //tr.Start();
            ((MainViewModel)DataContext).Children.Clear();
            ((MainViewModel)DataContext).CurrentViewItem = null;


            //DoubleAnimation da = new DoubleAnimation(100, new Duration(new TimeSpan(0, 0, 2)));
            //da.FillBehavior = FillBehavior.Stop;
            //bar.BeginAnimation(BreadcrumbBar.ProgressValueProperty, da);

            SCUtility.LoadDefualtItem(((MainViewModel)DataContext));

            OnRefreshGovSession(e);

            //((MainViewModel)DataContext).IsProgressing = false;
       

         


        }

        /// <summary>
        /// The dropdown menu of a BreadcrumbItem was pressed, so delete the current folders, and repopulate the folders
        /// to ensure actual data.
        /// </summary>
        private void bar_BreadcrumbItemDropDownOpened(object sender, BreadcrumbItemEventArgs e)
        {
            //BreadcrumbItem item = e.Item;

            //// only repopulate, if the BreadcrumbItem is dynamically generated which means, item.Data is a  pointer to itself:
            //if (!(item.Data is BreadcrumbItem))
            //{
            //    item.Items.Clear();
            //    PopulateFolders(item);
            //}
        }

        private void ButtonOpenMeeting_Click(object sender, RoutedEventArgs e)
        {
            OnOpenGovSession(e);
        }

        private void ChatItem_Selected(object sender, RoutedEventArgs e)
        {
            
        }

        private void CurrentReport_Selected(object sender, RoutedEventArgs e)
        {
            
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
           // OnGoBack(e);
            OnGoBack(e);

            // added ghdr go back temporary
            if (((MainViewModel)DataContext).CurrentViewItem.ObjectViewer.GetType().Name == "OfferView" 
                && ((OfferView)((MainViewModel)DataContext).CurrentViewItem.ObjectViewer).getWordControl()._clickCount > 0)
            {
                
                ((OfferView)((MainViewModel)DataContext).CurrentViewItem.ObjectViewer).getWordControl().GoBack();

            }
            else
            {
                History<string>.IsActive = false;
                this.bar.Path = History<string>.Undo();
                History<string>.IsActive = true;
            }
        }

        public GovSession GetCurrnetSession()
        {
            bool check = true;
            GovSession CurrentMet = null;
            //BreadcrumbItem item = bar.SelectedBreadcrumb;
            //while (check)
            //{
            //    if (item.Tag is GovSession)
            //    {
            //        CurrentMet = (item.Tag as GovSession);
            //        check = false;
            //    }
            //    if (item.Tag is TreeNode)
            //    {
            //        if ((item.Tag as TreeNode).Tag is GovSession)
            //        {
            //            CurrentMet = ((item.Tag as TreeNode).Tag as GovSession);
            //            check = false;
            //        }
            //    }
            //    else
            //    {
            //        item = item.ParentBreadcrumbItem;
            //    }

            //    if (item == null)
            //        check = false;

                

            //}

            return CurrentMet;
        }

        private void SyncButton_Click(object sender, RoutedEventArgs e)
        {
            SyncViewPath();
            OnSyncPathView(e);
        }

        private void ButtonViewTree_Click(object sender, RoutedEventArgs e)
        {
            OnToggleTreeView(e);
        }

        private void btnSessionMem_Click(object sender, RoutedEventArgs e)
        {
            var frm = new frmClientsList();
            frm.ShowDialog();
            frm.Close();
        }

        private void btnViewCurrentReport_Click(object sender, RoutedEventArgs e)
        {
        //     bar.Path = (string) ActiveReport.Header;
            bar.Path = ((MainViewModel)DataContext).Title;
        
        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {

            if (((MainViewModel)DataContext).CurrentViewItem.ObjectViewer.GetType().Name == "OfferView"
                    && ((OfferView)((MainViewModel)DataContext).CurrentViewItem.ObjectViewer).getWordControl()._clickCount > 0)
            {

                ((OfferView)((MainViewModel)DataContext).CurrentViewItem.ObjectViewer).getWordControl().GoBack();

            }
            else
            {
                History<string>.IsActive = false;
                this.bar.Path = History<string>.Redo();
                History<string>.IsActive = true;
                OnGoNext(e);
            }
        }

        private void Button_MouseUp(object sender, MouseButtonEventArgs e)
        {
          //  OnGoBack(e);
        }

        private void Button_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            History<string>.Undo();
            OnGoBack(e);
        }

        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                
            }
        }

        private void ButtonCloseMeeting_Click(object sender, RoutedEventArgs e)
        {
            OnCloseGovSession(e);
        }


        delegate void UpdateStatusDelegate(BaseClass.QueryData ReplyDataObj);
        public void SyncViewPath()
        {
            if (SCUtility.m_AppDef == null || SCUtility.m_AppDef.ArrClients == null)
                return;

            ArrayList meta = null;
            var vm = this.DataContext as MainViewModel;
            if (vm != null && vm.CurrentViewItem != null && vm.CurrentViewItem.ObjectViewer != null)
            {
                meta = vm.CurrentViewItem.ObjectViewer.GetMetaData();
            }

            QueryData StatusQueryData = new QueryData();
            StatusQueryData.Type = Consts.SectionType.DoAction;
            ObjectMetaData obj = new ObjectMetaData();
            obj.Text = bar.Path.Clone().ToString();
            obj.Tag = "Path";
            StatusQueryData.ArrCounter.Add(obj);


            if (meta != null)
            {
                foreach (var itm in meta)
                {
                    StatusQueryData.ArrCounter.Add(itm);
                }
            }

            foreach (BaseClass.ClientInfo row in SCUtility.m_AppDef.ArrClients)
            {

                // this.Text = "Waiting for reply...";
                string strPath = bar.Path.Clone().ToString();
                ClientInfo CliInfoS = new ClientInfo(row.IP, row.Name);
                Thread ClientStatusQuery = new Thread(delegate() { ExecutingPathQueries(StatusQueryData, CliInfoS); });
              //  Thread ClientStatusQuery = new Thread(UpdateStatusDelegate() {});
                ClientStatusQuery.Start();

            }
        }

        private void ExecutingPathQueries(QueryData StatusQueryData, BaseClass.ClientInfo cInfo1)
        {

            ReplyData ReplyDataObj;
            var CliInfoS = cInfo1 as BaseClass.ClientInfo;
            try
            {


                //ObjectMetaData ActiveSession = new ObjectMetaData();
                //ActiveSession.Text = this._activeGovSession._PhysicalPath;
                //ActiveSession.Tag = "ActiveSession";
                //StatusQueryData.ArrCounter.Add(ActiveSession);

                //ObjectMetaData PageNumber = new ObjectMetaData();

                //if (CurrentViewControl == _ucOfferReport)
                //{
                //    PageNumber.Text = _ucOfferReport.ucViewGovReportPic1.BindingSource.Position.ToString();
                //}
                //else if (CurrentViewControl == _ucViewPresentation)
                //{
                //    PageNumber.Text = _ucViewPresentation.BindingSource.Position.ToString();
                //}

                //PageNumber.Tag = "PageNumber";
                //StatusQueryData.ArrCounter.Add(PageNumber);

                //ObjectMetaData IsViewWordDoc = new ObjectMetaData();
                //IsViewWordDoc.Text = "False";
                //if (CurrentViewControl == _ucOfferReport)
                //{
                //    IsViewWordDoc.Text = _ucOfferReport.IsViewWordDocument.ToString();
                //}
                //IsViewWordDoc.Tag = "IsViewWordDoc";
                //StatusQueryData.ArrCounter.Add(IsViewWordDoc);
             
                //StatusQueryData.CurrClient = clientInfo;
                string QueryString = StatusQueryData.Serialize();
                String ReplyString = Comm.SendQuery(CliInfoS.IP, SCUtility.m_AppDef.m_Port, QueryString);
                ReplyDataObj = ReplyData.Deserialize(ReplyString);

            }
            catch (Exception)
            {
                ReplyDataObj = null;
            }

        }

        private void ExecutingMessage(QueryData StatusQueryData, BaseClass.ClientInfo cInfo1)
        {

            ReplyData ReplyDataObj;
            var CliInfoS = cInfo1 as BaseClass.ClientInfo;
            try
            {

                //ObjectMetaData ActiveSession = new ObjectMetaData();
                //ActiveSession.Text = this._activeGovSession._PhysicalPath;
                //ActiveSession.Tag = "ActiveSession";
                //StatusQueryData.ArrCounter.Add(ActiveSession);

                //ObjectMetaData PageNumber = new ObjectMetaData();

                //if (CurrentViewControl == _ucOfferReport)
                //{
                //    PageNumber.Text = _ucOfferReport.ucViewGovReportPic1.BindingSource.Position.ToString();
                //}
                //else if (CurrentViewControl == _ucViewPresentation)
                //{
                //    PageNumber.Text = _ucViewPresentation.BindingSource.Position.ToString();
                //}

                //PageNumber.Tag = "PageNumber";
                //StatusQueryData.ArrCounter.Add(PageNumber);

                //ObjectMetaData IsViewWordDoc = new ObjectMetaData();
                //IsViewWordDoc.Text = "False";
                //if (CurrentViewControl == _ucOfferReport)
                //{
                //    IsViewWordDoc.Text = _ucOfferReport.IsViewWordDocument.ToString();
                //}
                //IsViewWordDoc.Tag = "IsViewWordDoc";
                //StatusQueryData.ArrCounter.Add(IsViewWordDoc);

                //StatusQueryData.CurrClient = clientInfo;

                string QueryString = StatusQueryData.Serialize();
                String ReplyString = Comm.SendQuery(CliInfoS.IP, SCUtility.m_AppDef.m_Port, QueryString);
                ReplyDataObj = ReplyData.Deserialize(ReplyString);

            }
            catch (Exception)
            {
                ReplyDataObj = null;
            }

        }
        void Progress()
        {
            while(((MainViewModel)DataContext).IsProgressing)
            {
                if (bar.ProgressValue == 0)
                {
                    DoubleAnimation da = new DoubleAnimation(100, new Duration(new TimeSpan(0, 0, 2)));
                    da.FillBehavior = FillBehavior.Stop;
                    bar.BeginAnimation(BreadcrumbBar.ProgressValueProperty, da);
                }

                if (bar.ProgressValue == 100)
                {
                    DoubleAnimation da = new DoubleAnimation(0, new Duration(new TimeSpan(0, 0, 2)));
                    da.FillBehavior = FillBehavior.Stop;
                    bar.BeginAnimation(BreadcrumbBar.ProgressValueProperty, da);
                }
            }

            
        }

        private void btnEditGovSession_Click(object sender, RoutedEventArgs e)
        {
            if (!((MainViewModel)DataContext).IsSessionManager)
                return;

            var govSession = ((SessionItemViewModel)((MainViewModel)DataContext).Children[0]).Object as GovSession;
            if (govSession != null)
            {
                var frm = new frmEditGovSessionInfo();
                frm.FillObject(govSession);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // dataGridView1.Refresh();
                }

                frm.Dispose();

            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (!((MainViewModel)DataContext).IsSessionManager)
                return;

            var govSession = ((SessionItemViewModel)((MainViewModel)DataContext).Children[0]).Object as GovSession;



            frmSendMessage frm = new frmSendMessage();
            string sMessage = "";
            if (File.Exists(Properties.Settings.Default.OtherDocsPath + "\\پیامها\\پیام عمومی.txt") && File.ReadAllText(Properties.Settings.Default.OtherDocsPath + "\\پیامها\\پیام عمومی.txt") != "")
            {
                string[] sText = File.ReadAllText(Properties.Settings.Default.OtherDocsPath + "\\پیامها\\پیام عمومی.txt").Split('#');
                if(sText.Length >3)
                {
                    sMessage = sText[0];
                    frm.txtTitle.Text = sMessage;
                    frm.trcDelay.Value = int.Parse(sText[1]);
                    frm.trkDuration.Value = int.Parse(sText[2]);
                    if(sText[1] != "0")
                        frm.lblDelay.Text = sText[1];
                    if (sText[2] != "0")
                        frm.lblDuration.Text = sText[2];
                    if (sText[3] != "")
                    {
                        string sC = sText[3].Replace("Color", "").Replace("[", "").Replace("]", "");
                        string[] colors = sC.Split(',');
                        frm.txtTitle.BackColor = System.Drawing.Color.FromArgb(int.Parse(colors[0].Trim().Substring(2)), int.Parse(colors[1].Trim().Substring(2)), int.Parse(colors[2].Trim().Substring(2)), int.Parse(colors[3].Trim().Substring(2)));
                    }
                    if (sText[4] != "")
                    {
                        string sC = sText[4].Replace("Color", "").Replace("[", "").Replace("]", "");
                        string[] colors = sC.Split(',');
                        frm.txtTitle.ForeColor= System.Drawing.Color.FromArgb(int.Parse(colors[0].Trim().Substring(2)), int.Parse(colors[1].Trim().Substring(2)), int.Parse(colors[2].Trim().Substring(2)), int.Parse(colors[3].Trim().Substring(2)));
                    }
                }

            }
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                File.WriteAllText(Properties.Settings.Default.OtherDocsPath + "\\پیامها\\پیام عمومی.txt", frm.txtTitle.Text + "#" + frm.lblDelay.Text + "#" + frm.lblDuration.Text + "#" + frm.txtTitle.BackColor.ToString() + "#" + frm.txtTitle.ForeColor.ToString() 
                    + "#" + frm.txtTitle.Font.Name.ToString() + "#" + frm.txtTitle.Font.Size.ToString());

                ((MainViewModel)DataContext).MessageDealy = int.Parse(frm.lblDelay.Text);
                ((MainViewModel)DataContext).MessageDuration = int.Parse(frm.lblDuration.Text);
                ((MainViewModel)DataContext).MessageTitle = frm.txtTitle.Text;
                ((MainViewModel)DataContext).MessageBackColor = frm.txtTitle.BackColor;
                ((MainViewModel)DataContext).MessageForeColor = frm.txtTitle.ForeColor;
                ((MainViewModel)DataContext).MessageFont = frm.txtTitle.Font;


                /*
                if (SCUtility.m_AppDef == null || SCUtility.m_AppDef.ArrClients == null)
                    return;

                QueryData StatusQueryData = new QueryData();
                StatusQueryData.Type = Consts.SectionType.DoAction;
                ObjectMetaData obj = new ObjectMetaData();
                obj.Text = frm.txtTitle.Text;
                obj.Tag = "Message";
                StatusQueryData.ArrCounter.Add(obj);


                foreach (BaseClass.ClientInfo row in SCUtility.m_AppDef.ArrClients)
                {

                    // this.Text = "Waiting for reply...";
                    string strPath = bar.Path.Clone().ToString();
                    ClientInfo CliInfoS = new ClientInfo(row.IP, row.Name);
                    Thread ClientStatusQuery = new Thread(delegate () { ExecutingMessage(StatusQueryData, CliInfoS); });
                    ClientStatusQuery.Start();

                }
                */

            }

            frm.Dispose();

        }

        private void btnSync_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFirstDoc_Click(object sender, RoutedEventArgs e)
        {

            if (((MainViewModel)DataContext).CurrentViewItem.ObjectViewer.GetType().Name == "OfferView"
                    && ((OfferView)((MainViewModel)DataContext).CurrentViewItem.ObjectViewer).getWordControl() != null)
            {

                ((OfferView)((MainViewModel)DataContext).CurrentViewItem.ObjectViewer).getWordControl().GoFirstDoc();

            }

            if (((MainViewModel)DataContext).CurrentViewItem.ObjectViewer.GetType().Name == "OfferView")
            {
                ((OfferView)((MainViewModel)DataContext).CurrentViewItem.ObjectViewer).UcViewGovReportTabTemplate1.ucViewGovReportPic1.BindingSource.Position = 0;
                //((OfferView)((MainViewModel)DataContext).CurrentViewItem.ObjectViewer).UcViewGovReportTabTemplate1.ucViewGovReportPic1.Refresh();

            }

        }
    }
}

