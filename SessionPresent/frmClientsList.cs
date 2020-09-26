using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Threading;
using System.Net;
using System.IO;
using System.Net.Sockets;
using BaseClass;
using MonitorInfoViewer;

namespace SessionPresent
{
    public partial class frmClientsList : Form
    {

        public TcpClient theClient;//Instant of TCP client
        Stream theStream;//To be attached to the client
        public static String myLine;//To fetch one IP record and siaply it in list view
        public static String theFormat;//To check if the IP range is correct
        public static int flag;


        delegate void UpdateStatusDelegate(ReplyData ReplyDataObj , BaseClass.ClientInfo cinfo);

        private ClientStatusBL m_StatusBL = new ClientStatusBL();
        private ReplyData m_ReplyDataObj = null;
        private string m_TmpClientIP = string.Empty;
        private string m_TmpClientName = string.Empty;

        public frmClientsList()
        {
            InitializeComponent();

            splitContainer1.Panel1Collapsed = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new frmNewClient().ShowDialog(this);
        }

        public void AddNewClient(String newIP, String newName)
        {
            if (newName == "")
            {
                newName = "Unknown";
            }

            m_TmpClientIP = newIP;
            m_TmpClientName = newName;
            bool isClientExists = false;


           

            foreach (ClientInfo CurrClient in SCUtility.m_AppDef.ArrClients)
            {
                if (CurrClient.IP.CompareTo(newIP) == 0)
                {
                  
                    isClientExists = true;
                }
            }

            if (isClientExists)
            {
               
                MessageBox.Show("This IP is already monitored.\n Please choose another new IP.");
            }
            else
            {
                var cc = new ClientInfo(m_TmpClientIP, m_TmpClientName, Consts.ClientStatus.Unknown,
                                        Consts.NetStatus.Offline);
                SCUtility.m_AppDef.ArrClients.Add(cc);

                Thread AddingNewClient = new Thread(new ParameterizedThreadStart(ExecutingQueries));
                AddingNewClient.Start(cc);
            }            
        }

        private void LoadClientsList()
        {
            DataTable ClientsDataTable = new DataTable();

            ClientsDataTable.Columns.Add("IP");
            ClientsDataTable.Columns.Add("Name");
            ClientsDataTable.Columns.Add("Status");
            ClientsDataTable.Columns.Add("NetStatus");
            ClientsDataTable.Columns.Add("HostName");

            DataRow ClientDataRow;

           

            foreach (ClientInfo CurrClientInfo in SCUtility.m_AppDef.ArrClients)
            {
                ClientDataRow = ClientsDataTable.NewRow();
                ClientDataRow[0] = CurrClientInfo.IP;
                ClientDataRow[1] = CurrClientInfo.Name;
                ClientDataRow[2] = CurrClientInfo.Status;
                ClientDataRow[3] = CurrClientInfo.NetStatus;
                ClientDataRow[4] = CurrClientInfo.HostName;
                ClientsDataTable.Rows.Add(ClientDataRow);
            }

            dataGridClients.DataSource = ClientsDataTable;
            dataGridClients.Refresh();
        }

        private void ExecutingQueries()
        {
            ExecutingQueries(null);
        }

        private void UpdateClientStatus(ReplyData ReplyDataObj , BaseClass.ClientInfo cinfo)
        {
            m_ReplyDataObj = ReplyDataObj;
            Consts.ClientStatus NewClientStatus = Consts.ClientStatus.Failure;

            if (m_ReplyDataObj != null)
            {
                NewClientStatus = Consts.ClientStatus.Connected;
                
            }

            for (int CurrClientIndex = 0; CurrClientIndex < SCUtility.m_AppDef.ArrClients.Count; ++CurrClientIndex)
            {
                if (((ClientInfo)SCUtility.m_AppDef.ArrClients[CurrClientIndex]).IP.CompareTo(cinfo.IP) == 0)
                {
                    ((ClientInfo)SCUtility.m_AppDef.ArrClients[CurrClientIndex]).Status = NewClientStatus;
                }
            }

            this.Text = "Clients List";
            LoadClientsList();
        }

        private void frmClientsList_Load(object sender, EventArgs e)
        {
          //  textBox1.Text = ((frmMainForm)Owner).m_AppDef.m_Port.ToString();
            
            LoadClientsList();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Collection<DataGridViewRow> RemoeTemp = new Collection<DataGridViewRow>();
            
            foreach (DataGridViewRow dataGridViewRow in dataGridClients.SelectedRows)
            {
                RemoeTemp.Add(dataGridViewRow);
                
                
            }

            foreach (DataGridViewRow dataGridViewRow in RemoeTemp)
            {
                RemoveClient(dataGridViewRow.Cells[0].Value.ToString());
                dataGridClients.Rows.Remove(dataGridViewRow);
            }
            dataGridClients.Refresh();
            //if (dataGridClients.SelectedCells.Count > 0)
            //{
            //    RemoveClient(dataGridClients.Rows[dataGridClients.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
            //    dataGridClients.Rows.RemoveAt(dataGridClients.SelectedCells[0].RowIndex);
            //    dataGridClients.Refresh();
            //}
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //int port;

            //if (Int32.TryParse(textBox1.Text, out port))
            //{
            // //   ((frmMainForm)Owner).m_AppDef.m_Port = port;
            //}
            //else
            //{
            //    MessageBox.Show("Invalid value for Server Port");
            //    //frmMainForm)Owner).toolStripStatusLabel1.Text = "Invalid value for Server Port";
            //}

            //Close();
        }

        private void dataGridClients_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            RemoveClient(e.Row.Cells[0].Value.ToString());
        }

        private void RemoveClient(String RemovedIP)
        {
            int RemovedIndex = -1;

            for (int CurrClientIndex = 0; CurrClientIndex < SCUtility.m_AppDef.ArrClients.Count; ++CurrClientIndex)
            {
                if (((ClientInfo)SCUtility.m_AppDef.ArrClients[CurrClientIndex]).IP.CompareTo(RemovedIP) == 0)
                {
                    RemovedIndex = CurrClientIndex;
                }
            }

            SCUtility.m_AppDef.ArrClients.RemoveAt(RemovedIndex);


            if (SCUtility.m_AppDef.CurrClient != null)
            {
                if (SCUtility.m_AppDef.CurrClient.IP.CompareTo(RemovedIP) == 0)
                {
                    SCUtility.m_AppDef.CurrClient = null;
                    //switch (((frmMainForm)Owner).CurrTab)
                    //{
                    //    case Consts.SectionType.Processes:
                    //        ((frmMainForm)Owner).dataGridProcesses.DataSource = null;
                    //        break;
                    //    case Consts.SectionType.Performance:
                    //        ((frmMainForm)Owner).ClearCurvesLists();
                    //        break;
                    //    case Consts.SectionType.SysInfo:
                    //        // todo CLEAR SYSINFO
                    //        break;
                    //    default:
                    //        break;
                    //}
                }
            }
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            //if (dataGridClients.SelectedCells.Count > 0)
            //{
            //    m_TmpClientIP = dataGridClients.Rows[dataGridClients.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
            //    m_TmpClientName = dataGridClients.Rows[dataGridClients.SelectedCells[0].RowIndex].Cells[1].Value.ToString();

            //    this.Text = "Waiting for reply...";

            //    Thread ClientStatusQuery = new Thread(new ParameterizedThreadStart(ExecutingQueries));
            //    ClientStatusQuery.Start();

            //}


            // if (dataGridClients.SelectedCells.Count > 0)
            foreach (DataGridViewRow row in dataGridClients.Rows)
            {
               // if (row.Index == 0)
                {
                    var cInfo = new BaseClass.ClientInfo(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), Consts.ClientStatus.Unknown, Consts.NetStatus.Offline);
                    m_TmpClientIP = row.Cells[0].Value.ToString();
                    m_TmpClientName = row.Cells[1].Value.ToString();

                    this.Text = "درانتظار پاسخ...";

                    Thread ClientStatusQuery = new Thread(new ParameterizedThreadStart(ExecutingQueries));
                    ClientStatusQuery.Start(cInfo);
                }

            }
        }

      

        private void label1_Click(object sender, EventArgs e)
        {

        }

     


        //**************************************************************************************

     

      

        private void button2_Click(object sender, EventArgs e)
        {
            checkIP(txtFrom.Text, txtTo.Text);//Check the validity of the IP range


            DataTable ClientsDataTable = new DataTable();

            ClientsDataTable.Columns.Add("IP");
            ClientsDataTable.Columns.Add("Name");
            ClientsDataTable.Columns.Add("Status");
            ClientsDataTable.Columns.Add("NetStatus");
            ClientsDataTable.Columns.Add("HostName");

            DataRow ClientDataRow;

         

           


            if (txtFrom.Text != "" && txtTo.Text != "" && theFormat == "Correct")
            {

                dataGridViewHostInformation.DataSource = ClientsDataTable;
               // dataGridViewHostInformation.Rows.Clear();
                dataGridViewHostInformation.Refresh();
               
            
                string[] fromAddress = txtFrom.Text.Trim().Split(new Char[] { '.' });//Split the lower bound IP address into four octets
                string[] toAddress = txtTo.Text.Trim().Split(new Char[] { '.' });//Split the upper bound IP address into four octets

                String fromFirst = fromAddress[0];//Lower bound first octet
                String fromSecond = fromAddress[1];//Lower bound second octet
                String fromThird = fromAddress[2];//Lower bound third octet
                String fromFourth = fromAddress[3];//Lower bound fourth octet
                String toFourth = toAddress[3];//Upper bound last octet

                ReplyData replydata = null;
                NetworkInfoBL netBL = null;
                
                ClientInfo cInfo = null;
                //The below routine does the ping for each IP address in the range
                for (int x = int.Parse(fromFourth); x <= int.Parse(toFourth); x++)
                {
                    cInfo = new ClientInfo(fromFirst.ToString() + "." + fromSecond.ToString() + "." + fromThird.ToString() + "." + x.ToString(), "");
                    cInfo.NetStatus = Consts.NetStatus.Offline;
                    netBL = new NetworkInfoBL();

                    //replydata = netBL.ExecuteQuery(cInfo.IP, SCUtility.m_AppDef.m_Port, cInfo);
                    replydata = m_StatusBL.ExecuteQuery(cInfo.IP, SCUtility.m_AppDef.m_Port, cInfo);
                    

                    if (replydata != null && replydata.ArrDataContainers != null && replydata.ArrDataContainers.Count > 0)
                    {

                        cInfo.Status = Consts.ClientStatus.Connected;
                        if (replydata.ArrDataContainers[0] is DataContainer)
                        {
                            if (((DataContainer)replydata.ArrDataContainers[0]).ArrCounters != null)
                            {
                                foreach (object obj in ((DataContainer)replydata.ArrDataContainers[0]).ArrCounters)
                                {
                                    if (obj is Counter)
                                    {
                                        if (((Counter)obj).Name == "NetStatus")
                                        {
                                            try
                                            {
                                                cInfo.NetStatus = (Consts.NetStatus)Enum.Parse(typeof(Consts.NetStatus), ((Counter)obj).Value.ToString());
                                            }
                                            catch
                                            { }
                                        }

                                        if (((Counter)obj).Name == "HostName")
                                        {
                                            try
                                            {
                                                cInfo.HostName = ((Counter)obj).Value.ToString();
                                               
                                            }
                                            catch
                                            { }
                                        }

                                        if (((Counter)obj).Name == "UserName")
                                        {
                                            try
                                            {
                                                cInfo.Name = ((Counter)obj).Value.ToString();
                                            }
                                            catch
                                            { }
                                        }
                                    }

                                }

                                //cInfo.NetStatus = Enum.Parse(typeof(Consts.NetStatus),
                            }


                        }
                    }

                    //netBL = new NetworkInfoBL(fromFirst.ToString() + "." + fromSecond.ToString() + "." + fromThird.ToString() + "." + x.ToString());
                    //myLine = NetworkInfoBL.ExecuteQuery(((frmMainForm)Owner).m_AppDef.CurrCenter.IP, ((frmMainForm)Owner).m_AppDef.m_Port,
                    //    fromFirst.ToString() + "." + fromSecond.ToString() + "." + fromThird.ToString() + "." + x.ToString());
                  //  clientInfoBindingSource.Add(cInfo);


                    ClientDataRow = ClientsDataTable.NewRow();
                    ClientDataRow[0] = cInfo.IP;
                    ClientDataRow[1] = cInfo.Name;
                    ClientDataRow[2] = cInfo.Status;
                    ClientDataRow[3] = cInfo.NetStatus;
                    ClientDataRow[4] = cInfo.HostName;
                    ClientsDataTable.Rows.Add(ClientDataRow);

                    dataGridViewHostInformation.Refresh();

                
                }//end of for loop

                //dataGridViewHostInformation.DataSource = ClientsDataTable;
                //dataGridViewHostInformation.Refresh();

                return;
            }

            else//Show error message if the IP range is in the wrong format
                MessageBox.Show("Please enter the IP range in a correct format", "IP range error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           
        }

     

        //The below routine checks the formatof the IP addresses range
        private void checkIP(string fromIP, string toIP)
        {
            try
            {

                string[] fromAddress = fromIP.Split(new Char[] { '.' });//Split the lower bound IP address into four octets
                string[] toAddress = toIP.Split(new Char[] { '.' });//Split the upper bound IP address into four octets

                if (Convert.ToInt64(fromAddress[0]) < 255 && Convert.ToInt64(fromAddress[1]) < 255 && Convert.ToInt64(fromAddress[2]) < 255 && Convert.ToInt64(fromAddress[3]) < 255 &&
                    Convert.ToInt64(toAddress[0]) < 255 && Convert.ToInt64(toAddress[1]) < 255 && Convert.ToInt64(toAddress[2]) < 255 && Convert.ToInt64(toAddress[3]) < 255)
                {


                    if (fromAddress[0] == toAddress[0] && fromAddress[1] == toAddress[1] && fromAddress[2] == toAddress[2] && Convert.ToInt64(fromAddress[3]) < Convert.ToInt64(toAddress[3]))
                        theFormat = "Correct";
                    else
                        theFormat = "False";
                }
                else
                {
                    theFormat = "False";
                }
            }

            catch (Exception ex)
            {
                theFormat = "False";
            }

        }

        private void btnAddToClientList_Click(object sender, EventArgs e)
        {

            if (dataGridViewHostInformation.SelectedRows.Count == 1)
            {

                frmNewClient frm = new frmNewClient();
                frm.Owner = this;
                frm.FillObject(dataGridViewHostInformation.SelectedRows[0].Cells["IP"].Value.ToString(),
                               dataGridViewHostInformation.SelectedRows[0].Cells["Name"].Value.ToString(),
                               dataGridViewHostInformation.SelectedRows[0].Cells["HostName"].Value.ToString());
                frm.ShowDialog();
                frm.Dispose();
            }
            else
            {
                foreach (DataGridViewRow dataGridViewRow in dataGridViewHostInformation.SelectedRows)
                {
                    AddNewClient(dataGridViewRow.Cells["IP"].Value.ToString(),
                               dataGridViewRow.Cells["Name"].Value.ToString());
                }
            }


            //if (dataGridViewHostInformation.SelectedRows.Count > 0)
              //  AddNewClient(dataGridViewHostInformation.SelectedRows[0].Cells["IP"].Value.ToString(), dataGridViewHostInformation.SelectedRows[0].Cells["HostName"].Value.ToString());
            //
        }

        private void dataGridViewHostInformation_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void btnSearchIP_Click(object sender, EventArgs e)
        {
            //if (this.Width == 517)
            //{
            //    this.Width = 1017;
            //}
            //else
            //{
            //    this.Width = 517;
            //}
        }

        private void ExecutingQueries(Object cInfo1)
        {
            if (cInfo1 == null) throw new ArgumentNullException("cInfo1");
            ReplyData ReplyDataObj;
            var CliInfoS = cInfo1 as BaseClass.ClientInfo;
            try
            {
                // var cInfo = new BaseClass.ClientInfo(m_TmpClientIP, m_TmpClientName, Consts.ClientStatus.Unknown,Consts.NetStatus.Offline);
                ReplyDataObj = m_StatusBL.ExecuteQuery(CliInfoS.IP, SCUtility.m_AppDef.m_Port, CliInfoS);
            }
            catch (Exception)
            {
                ReplyDataObj = null;
            }

            UpdateStatusDelegate UpdateStatus = new UpdateStatusDelegate(UpdateClientStatus);
            this.Invoke(UpdateStatus, new object[] { ReplyDataObj, cInfo1 });  
            
        }

        private void tsbtnSearch_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = !tsbtnSearch.Checked;
        }

        private void dataGridClients_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridClients.SelectedCells.Count > 0)
            {

                frmNewClient frm = new frmNewClient();
                frm.Owner = this;

                ClientInfo ClientInfoTemp = null;
                foreach (ClientInfo CurrClient in SCUtility.m_AppDef.ArrClients)
                {
                    if (CurrClient.IP.CompareTo(dataGridClients.SelectedRows[0].Cells["IP"].Value.ToString()) == 0)
                    {
                        ClientInfoTemp = CurrClient;
                    }
                }

                if (ClientInfoTemp != null)
                {
                    frm.FillObject(ClientInfoTemp);
                    frm.ShowDialog();
                    frm.Dispose();    
                }
                
             
            }
        }

        public void EditClient(string strIP, string strName)
        {
            foreach (DataGridViewRow row in dataGridClients.Rows)
            {
                if (strIP.CompareTo(row.Cells["IP"].Value.ToString()) == 0)
                {

                    row.Cells["Name"].Value = strName;
                    break;
                }
            }
        }

        private void dataGridViewHostInformation_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnAddToClientList_Click(sender, e);
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
           SCUtility.SaveSetting();
        }

        private void tsbtnCloseClient_Click(object sender, EventArgs e)
        {
            QueryData StatusQueryData = new QueryData();
            StatusQueryData.Type = Consts.SectionType.DoAction;
            ObjectMetaData obj = new ObjectMetaData();
            obj.Text = "";
            obj.Tag = "ForceClose";
            StatusQueryData.ArrCounter.Add(obj);


            Collection<BaseClass.ClientInfo> AllCliecnt = new Collection<ClientInfo>();
            foreach (DataGridViewRow itm in dataGridClients.SelectedRows)
            {
                BaseClass.ClientInfo ClientInfoTemp = null;
                foreach (ClientInfo CurrClient in SCUtility.m_AppDef.ArrClients)
                {
                    if (CurrClient.IP.CompareTo(itm.Cells["IP"].Value.ToString()) == 0)
                    {
                        ClientInfoTemp = CurrClient;
                    }
                }

                if (ClientInfoTemp != null)
                {
                    AllCliecnt.Add(ClientInfoTemp);
                }

                
            }

            foreach (BaseClass.ClientInfo row in AllCliecnt)//SCUtility.m_AppDef.ArrClients)
            {

                // this.Text = "Waiting for reply...";
                
                ClientInfo CliInfoS = new ClientInfo(row.IP, row.Name);
                Thread ClientStatusQuery = new Thread(delegate() { ExecutingPathQueries(StatusQueryData, CliInfoS); });
                //  Thread ClientStatusQuery = new Thread(UpdateStatusDelegate() {});
                ClientStatusQuery.Start();

            }
        }

        private void ExecutingPathQueries(QueryData StatusQueryData, ClientInfo cInfo1)
        {
            ReplyData ReplyDataObj;
            var CliInfoS = cInfo1 as BaseClass.ClientInfo;
            try
            {
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

        private void tsbtnShutdownPC_Click(object sender, EventArgs e)
        {
            QueryData StatusQueryData = new QueryData();
            StatusQueryData.Type = Consts.SectionType.DoAction;
            ObjectMetaData obj = new ObjectMetaData();
            obj.Text = "";
            obj.Tag = "Shutdown";
            StatusQueryData.ArrCounter.Add(obj);


            Collection<BaseClass.ClientInfo> AllCliecnt = new Collection<ClientInfo>();
            foreach (DataGridViewRow itm in dataGridClients.SelectedRows)
            {
                BaseClass.ClientInfo ClientInfoTemp = null;
                foreach (ClientInfo CurrClient in SCUtility.m_AppDef.ArrClients)
                {
                    if (CurrClient.IP.CompareTo(itm.Cells["IP"].Value.ToString()) == 0)
                    {
                        ClientInfoTemp = CurrClient;
                    }
                }

                if (ClientInfoTemp != null)
                {
                    AllCliecnt.Add(ClientInfoTemp);
                }


            }

            foreach (BaseClass.ClientInfo row in AllCliecnt)//SCUtility.m_AppDef.ArrClients)
            {

                // this.Text = "Waiting for reply...";

                ClientInfo CliInfoS = new ClientInfo(row.IP, row.Name);
                Thread ClientStatusQuery = new Thread(delegate() { ExecutingPathQueries(StatusQueryData, CliInfoS); });
                //  Thread ClientStatusQuery = new Thread(UpdateStatusDelegate() {});
                ClientStatusQuery.Start();

            }
        }
    }
}