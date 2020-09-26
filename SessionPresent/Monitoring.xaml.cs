using BaseClass;
using MonitorInfoViewer;
using NetworkRelation;
using SessionPresent.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SessionPresent
{
    /// <summary>
    /// Interaction logic for Monitoring.xaml
    /// </summary>
    public partial class Monitoring : UserControl, ISessionItemViewer
    {
        private int m_ExeQueryTimeToWait = 500;
        private Thread m_ExecutingQueryThread;
        private ClientViewer _ClientViewer;
        public bool _isActive = false;
        bool IsLive = false;

        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;

                m_ExeQueryTimeToWait = Properties.Settings.Default.TimeToWait;

            }
        }


        public Monitoring()
        {
            InitializeComponent();           
          
            
            this.Unloaded +=Monitoring_Unloaded;
            Application.Current.Exit += Current_Exit;
            _ClientViewer = new ClientViewer(Convert.ToInt32(Properties.Settings.Default.PresenterPort));
            _ClientViewer.AddNewClient(Properties.Settings.Default.PresenterIP, "test");

            _ClientViewer.m_AppDef.CurrClient = (BaseClass.ClientInfo)_ClientViewer.m_AppDef.ArrClients[0];
            IsLive = true;
            m_ExecutingQueryThread = new Thread(new ParameterizedThreadStart(ExecutingQueries));
            m_ExecutingQueryThread.Start();
        }

        void Current_Exit(object sender, ExitEventArgs e)
        {
            IsLive = false;
            if (m_ExecutingQueryThread != null)
            {
                m_ExecutingQueryThread.Abort();
            }
        }

        private void Monitoring_Unloaded(object sender, RoutedEventArgs e)
        {
            IsLive = false;
            if (m_ExecutingQueryThread != null)
            {
                m_ExecutingQueryThread.Abort();
            }
        }

        private void ExecutingQueries(Object i_MethodInvoker)
        {
            bool isToWait = true;
            CaptureScreenBL cpScreen = new CaptureScreenBL();
            while (IsLive)
            {
                
                //if (this.IsDisposed)
                //    return;
                try
                {
                    if (IsVisible)// IsActive)
                    {
                        //  if (tabControlMain.SelectedTab == tpScreenCapture)
                        {

                            ReplyData ReplyDataObj = cpScreen.ExecuteQuery("", _ClientViewer.m_AppDef.m_Port, _ClientViewer.m_AppDef.CurrClient);

                            try
                            {

                                if (ReplyDataObj == null || ReplyDataObj.ArrDataContainers.Count == 0)
                                {
                                    // this.pictureBox1.Image = null;
                                }
                                else
                                {
                                    if (ReplyDataObj != null)
                                    {
                                        try
                                        {

                                            byte[] b = (byte[])ReplyDataObj.ArrDataContainers[0];
                                            var bImg = new BitmapImage();
                                            //using (MemoryStream ms = new MemoryStream(b))
                                            MemoryStream ms = new MemoryStream(b);
                                            {

                                                bImg.BeginInit();
                                                bImg.StreamSource = ms;
                                                bImg.EndInit();
                                                bImg.Freeze();
                                            }

                                            Dispatcher.BeginInvoke((Action)(() =>
                                            {
                                                pictureBox1.Source = bImg;

                                            }));
                                          //  ms.Dispose();
                                          

                                                //ThreadPool.QueueUserWorkItem(o =>
                                                //{
                                                   

                                                //});


                                              
                                                


                                           
                                        }
                                        catch
                                        {

                                        }
                                        finally
                                        {

                                        }

                                    }
                                }


                            }
                            catch
                            { }

                        }

                    }
                }
                catch (ThreadAbortException)
                {
                    isToWait = false;
                }
                catch (Exception)
                {

                }
                finally
                {
                    if (isToWait)
                    {
                        // Thread.Sleep(m_ExeQueryTimeToWait);
                        Thread.Sleep(50);
                    }
                }
            }
        }

        public void FillObject(object obj , object mvm)
        {
          
        }

        public void FillMetaData(ArrayList MetaData)
        {

        }

        public ArrayList GetMetaData()
        {
            return null;
        }


        public string GetVotingMetaData()
        {
            throw new NotImplementedException();
        }


        public string GetBallotMetaData()
        {
            throw new NotImplementedException();
        }


        public void InitialVotingViewModel(IVotingViewModel votingViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
