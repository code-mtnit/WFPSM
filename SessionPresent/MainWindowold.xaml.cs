using System.Reflection;
using Sbn.Products.GEP.GEPObject;
using SessionPresent.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
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
using SessionPresent.ViewModel;
using MahApps.Metro;

namespace SessionPresent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowold //: Window
    {
        bool ForceClose = false;
        MainViewModel vm = new MainViewModel();
        TCPClientSocket.Starter strListener = new TCPClientSocket.Starter();
        public MainWindowold()
        {
            InitializeComponent();

            //var adminConfigs = File.ReadAllLines("c:\\Admin.txt");
            //vm.MainTitle = adminConfigs[0].Replace("MainTitle:", "");

            vm.Title = "میز کاری";

            Closing += MainWindow_Closing;
            Loaded += MainWindow_Loaded;

            SCUtility.LoadDefualtItem(vm);

            vm.Version = global::SessionPresent.Properties.Settings.Default.Version;

            vm.PropertyChanged += vm_PropertyChanged;

            DataContext = vm;




            var theme = ThemeManager.DetectAppStyle(Application.Current);
            var accent = ThemeManager.GetAccent("Lime");
            ThemeManager.ChangeAppStyle(Application.Current, accent, theme.Item1);

        }

        govGreattingMessage w = null;
        System.Windows.Forms.Timer _timerMessaging = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer _timerMessagingFirst = new System.Windows.Forms.Timer();

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //if (SCUtility.IsSessionManager)
            //{
            //    toolBar.mnuItmAdmin.Visibility = Visibility.Visible;
            //    toolBar.btnSync.Visibility = Visibility.Visible;
            //    mainAddressBar1.btnSeesionMembers.Visibility = Visibility.Visible;
            //    toolBar.btnClose.Visibility = Visibility.Visible;

            //}
            //else
            //{
            //    mainAddressBar1.btnOpen.Visibility = Visibility.Collapsed;
            //    mainAddressBar1.btnSync.Visibility = Visibility.Collapsed;
            //    mainAddressBar1.btnSeesionMembers.Visibility = Visibility.Collapsed;
            //    mainAddressBar1.btnClose.Visibility = Visibility.Collapsed;
            //}

            InitalClient();

            w = new govGreattingMessage();
            w.DataContext = vm;
            w.ShowDialog();


            _timerMessagingFirst.Interval = 5000;
            _timerMessagingFirst.Enabled = true;
            _timerMessagingFirst.Tick += _timerMessagingFirst_Tick;

            _timerMessaging.Enabled = false;
            _timerMessaging.Interval = 5000;
            _timerMessaging.Tick += _timerMessaging_Tick;



        }

        private void _timerMessagingFirst_Tick(object sender, EventArgs e)
        {

            if (vm.MessageTitle != null && vm.MessageTitle != "")
            {
                _timerMessagingFirst.Enabled = false;
                _timerMessaging.Interval = vm.MessageDealy * 1000 * 60;
                _timerMessaging.Enabled = true;
                /*
                Tools.SbnTools.frmSplashMessageView frm = new Tools.SbnTools.frmSplashMessageView();
                frm.Top = (int)(this.Height - 50 - frm.Height);
                frm.Left = (int)(this.Width /2 - frm.Width/2);
                frm.timer1.Enabled = false;
                frm.lblMessage.Text = vm.MessageTitle;
                frm.Show();
                */
            }
        }

        private void _timerMessaging_Tick(object sender, EventArgs e)
        {


            _timerMessaging.Interval = vm.MessageDealy * 1000 * 60;
            if (vm.MessageTitle != null)
            {

                try {
                    if (File.Exists(Properties.Settings.Default.OtherDocsPath + "\\پیامها\\پیام عمومی.txt") && File.ReadAllText(Properties.Settings.Default.OtherDocsPath + "\\پیامها\\پیام عمومی.txt") != "")
                    {
                        string[] sText = File.ReadAllText(Properties.Settings.Default.OtherDocsPath + "\\پیامها\\پیام عمومی.txt").Split('#');
                        if (sText.Length > 0)
                        {
                            vm.MessageTitle = sText[0];
                            vm.MessageDealy = int.Parse(sText[1]);
                            vm.MessageDuration = int.Parse(sText[2]);

                            string sC = sText[3].Replace("Color", "").Replace("[", "").Replace("]", "");
                            string[] colors = sC.Split(',');
                            vm.MessageBackColor = System.Drawing.Color.FromArgb(int.Parse(colors[0].Trim().Substring(2)), int.Parse(colors[1].Trim().Substring(2)), int.Parse(colors[2].Trim().Substring(2)), int.Parse(colors[3].Trim().Substring(2)));

                            sC = sText[4].Replace("Color", "").Replace("[", "").Replace("]", "");
                            colors = sC.Split(',');
                            vm.MessageForeColor = System.Drawing.Color.FromArgb(int.Parse(colors[0].Trim().Substring(2)), int.Parse(colors[1].Trim().Substring(2)), int.Parse(colors[2].Trim().Substring(2)), int.Parse(colors[3].Trim().Substring(2)));

                            string fontname = sText[5];
                            string fontsize = sText[6];
                            vm.MessageFont = new System.Drawing.Font(fontname, float.Parse(fontsize) , System.Drawing.FontStyle.Bold) ;
                        }
                    }
                        //_timerMessaging.Interval = vm.MessageDealy*1000*60;
                        Tools.SbnTools.frmSplashMessageView frm = new Tools.SbnTools.frmSplashMessageView();

                    frm.lblMessage.Text = vm.MessageTitle;
                    frm.timer1.Interval = vm.MessageDuration * 1000;
                    frm.Top = (int)(this.Height - 50 - frm.Height);
                    frm.Left = (int)(this.Width / 2 - frm.Width / 2);
                    frm.lblMessage.BackColor = vm.MessageBackColor;
                    frm.lblMessage.ForeColor = vm.MessageForeColor;
                    frm.lblMessage.Font = vm.MessageFont;
                    frm.Show();
                }
                catch
                {
                    MessageBox.Show("اشکالی در فراخوانی اطلاعات پیام بوجود آمده است!");
                }


            }
        }

        void MainWindow_Closing(object sender, CancelEventArgs e)
        {

            if (ForceClose)
            {
                strListener.Stop();
                SaveSetting();
            }
            else
            {
                try
                {
                    w.Close();
                }
                catch
                {

                }

                if (System.Windows.Forms.MessageBox.Show("آيا از کارتابل خارج می شوید ؟", "كارتابل الكترونيك هيات دولت", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    strListener.Stop();
                    SaveSetting();
                    //SCUtility.StopService();

                    //Application.ExitThread();
                    //SCUtility.AllGovSessions = null;
                    ////  this.Owner.Dispose();
                    //this.Dispose();

                }
                else
                {
                    e.Cancel = true;
                }
            }

            
        }


        System.Windows.Controls.UserControl CurrentViewPage;
        void ShowControl( System.Windows.Controls.UserControl uc)
        {
            if (uc == null || CurrentViewPage == uc)
                return;


            if (uc == desktop)
            {
                gViewer.Visibility = System.Windows.Visibility.Collapsed;
                desktop.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
               
                if (!gViewer.Children.Contains(uc))
                {
                    gViewer.Children.Add(uc);
                }

                foreach (System.Windows.Controls.UserControl ff in gViewer.Children)
                {
                    if (ff == uc)
                    {


                    }
                    else
                        ff.Visibility = System.Windows.Visibility.Hidden;
                }

                desktop.Visibility = System.Windows.Visibility.Hidden;
            }


           
            //uc.Opacity = 0;
            uc.Visibility = System.Windows.Visibility.Visible;
            //DoubleAnimation da = new DoubleAnimation(0, 1, new Duration(new TimeSpan(0, 0, 1)));
            //da.FillBehavior = FillBehavior.HoldEnd;

            //uc.BeginAnimation(System.Windows.Controls.UserControl.OpacityProperty, da);

            CurrentViewPage = uc;

           
        }

        void vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CurrentViewItem")
            {

                var TempViewModel = vm.CurrentViewItem;
                if (TempViewModel == null)
                {
                    ShowControl(desktop);
                
                    return;
                }

                gViewer.Visibility = System.Windows.Visibility.Visible;
                string path = TempViewModel.Title;
                while (TempViewModel.Parent != null)
                {
                    TempViewModel = TempViewModel.Parent as SessionItemViewModel;

                    path = TempViewModel.Title + "\\" + path;
                }


                toolBar.bar.Path = path;

                if (vm.CurrentViewItem == null)
                    return;

                vm.CurrentViewItem.IsExpanded = true;
                if (vm.CurrentViewItem.ObjectViewer != null)
                {
                    
                    vm.CurrentViewItem.ObjectViewer.FillObject(vm.CurrentViewItem , vm);
                    var ctrl = (vm.CurrentViewItem.ObjectViewer as System.Windows.Controls.UserControl);
                    
                    ShowControl(ctrl);
                 
                }
                else
                {


                }
                gViewer.DataContext = vm.CurrentViewItem.ObjectViewer;

                

            }
        }

        private void treeView1SeletedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (vm != null && e.NewValue != null)
            {
                vm.CurrentViewItem = e.NewValue as SessionItemViewModel;
            }

        }

        public void SaveSetting()
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


            FileStream fs = new FileStream(SCUtility.DefinisionPath, FileMode.Create);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                formatter.Serialize(fs, SCUtility.m_AppDef);
            }
            catch (SerializationException ex)
            {
                MessageBox.Show("Failed to serialize. Reason: " + ex.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }


            Properties.Settings.Default.Save();
        }

        void InitalClient()
        {
            MonitorClient2._.Comm.ReciveMessage += new EventHandler<TCPClientSocket.MessageEventArgs>(Comm_ReciveMessage);
            //  MessageBox.Show("Start");

            try
            {
                if (File.Exists(SCUtility.DefinisionPath))
                {
                    // Open the file containing the data that you want to deserialize.
                    FileStream fs = null;
                    fs = new FileStream(SCUtility.DefinisionPath, FileMode.Open);
                    BinaryFormatter formatter = new BinaryFormatter();



                    // Deserialize the hashtable from the file and 
                    // assign the reference to the local variable.
                    SCUtility.m_AppDef = (ApplicationDefinitions)formatter.Deserialize(fs);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                throw;
            }


            if (SCUtility.m_AppDef == null)
            {
                SCUtility.m_AppDef = new ApplicationDefinitions();
                SCUtility.m_AppDef.m_Port = (int)Properties.Settings.Default.PresenterPort;// 11000;

            }

            // return;

            strListener.Start(false);
        }

        void Comm_ReciveMessage(object sender, TCPClientSocket.MessageEventArgs e)
        {
            UpdateStatusDelegate UpdateStatus = new UpdateStatusDelegate(UpdateClientStatus);            
            //if (UpdateStatus != null)
            //{
            //    UpdateStatus(e.QueryData);
            //}
            this.Dispatcher.Invoke(UpdateStatus, new object[] { e.QueryData });
        }

        delegate void UpdateStatusDelegate(BaseClass.QueryData ReplyDataObj);

        private void UpdateClientStatus(BaseClass.QueryData replydataobj)
        {

            string strPath = "";
            bool Shutdown = false;

            foreach (BaseClass.ObjectMetaData omd in replydataobj.ArrCounter)
            {
                switch (omd.Tag)
                {
                    case "Path":
                        strPath = omd.Text;

                        //text = omd.Text;
                        break;
                    case "ForceClose":

                        ForceClose = true;
                       
                        break;
                    case "Shutdown":

                        Shutdown = true;
                        break;

                    case "Voting":
                     
                      
                      //  XmlDataProvider xml = new XmlDataProvider();
                        var stringReader = new System.IO.StringReader(omd.Text);
                        var serialaizer = new System.Xml.Serialization.XmlSerializer(typeof(Model.Ballot));
                        var obj = serialaizer.Deserialize(stringReader);

                        var ballot = obj as Model.Ballot;

                        if (SCUtility.CurrentSessionUser == null)
                        {
                            SCUtility.AuthenticateProccess();
                        }
                        
                        if (SCUtility.CurrentSessionUser != null && ballot != null)
                        {
                            ballot.SessionUser = SCUtility.CurrentSessionUser;
                            //if (!string.IsNullOrEmpty(ballot.BallotViewerClassName))
                            //{                              

                            //    var assembly = Assembly.Load(ballot.RefrenceAssemblly);
                            //    if (assembly != null)
                            //    {
                            //        var winObject = assembly.CreateInstance(ballot.BallotViewerClassName);

                            //        var ballotViewer = winObject as IBallotViewer;

                            //        if (ballotViewer != null)
                            //        {
                            //            ballotViewer.ShowBallot(ballot.BollotMetaData);
                            //        }
                            //    }
                            //}
                            //else
                            {
                                var win = new Views.BallotRegisterView();
                                var vmBallot = new ViewModel.BallotViewModel();
                                vmBallot.CurrentModel = obj as Model.Ballot;
                                win.DataContext = vmBallot;
                                win.ShowDialog();    
                            }
                            
                        }





                        break;
                        
                            
             
                    default:
                        break;
                }
            }


         

            if (Shutdown)
            {
                ForceClose = true;
                System.Diagnostics.Process.Start("shutdown", "-s -t 10");
                Close();
                return;
            }

            if (ForceClose)
            {
                Close();
                return;
            }

            if (!string.IsNullOrEmpty(strPath))
            {
                toolBar.bar.Path = strPath;             
            }

            if (vm != null && vm.CurrentViewItem != null && vm.CurrentViewItem.ObjectViewer != null)
                vm.CurrentViewItem.ObjectViewer.FillMetaData(replydataobj.ArrCounter);
        }

        private void BtnNextItem_Click(object sender, RoutedEventArgs e)
        {
            treeview.Focus();

            var downKey = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, Key.Down);
            downKey.RoutedEvent = Keyboard.KeyDownEvent;
            InputManager.Current.ProcessInput(downKey);
        }

        private void BtnPreviuseItem_Click(object sender, RoutedEventArgs e)
        {
            treeview.Focus();

            var downKey = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, Key.Up);
            downKey.RoutedEvent = Keyboard.KeyDownEvent;
            InputManager.Current.ProcessInput(downKey);
        }

        private void mnuCut_Click(object sender, RoutedEventArgs e)
        {
            if (vm.CurrentViewItem.Object is Offer)
            {
                vm.CutItem = vm.CurrentViewItem;
            }
            else
                MessageBox.Show("پیغام", "برای انتقال می بایست یک پیشنهاد را انتخاب نمایید.", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void mnuPaste_Click(object sender, RoutedEventArgs e)
        {
            if (!(vm.CurrentViewItem.Object is Catalogue))
            {
                MessageBox.Show( "برای انتقال می بایست یک فهرست را برای مقصد انتخاب نمایید.", "پیغام", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (vm.CutItem.Object is Offer && vm.CurrentViewItem.Object is Catalogue)
            {
                if (MessageBox.Show("آیا پیشنهاد مورد نظر به فهرست انتخاب شده انتقال یابد ؟", "پیغام", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    string OfferPath = ((Sbn.Core.SbnObject)vm.CutItem.Object)._PhysicalPath;
                    DirectoryInfo inf = new DirectoryInfo(OfferPath);

                    string CataloguePath = ((Sbn.Core.SbnObject)vm.CurrentViewItem.Object)._PhysicalPath + "\\Offers\\" + inf.Name;
                    try
                    {
                        System.IO.Directory.Move(OfferPath, CataloguePath);
                    }
                    catch(Exception ex)
                    { 
                        MessageBox.Show( "بروز خطا در انتقال پیشنهاد.", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
    
                    }

                    MessageBox.Show( "پیشنهاد به فهرست انتخاب شده انتقال یافت .\n\rبرای مشاهده تغییرات لطفا به روز رسانی نمایید.", "پیغام", MessageBoxButton.OK, MessageBoxImage.Information);

                }

            }
        }
    }
}
