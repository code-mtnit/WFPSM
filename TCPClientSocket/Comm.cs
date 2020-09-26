using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using TCPClientSocket;

namespace MonitorClient2._
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using MonitorClient2._0;
    using System.Collections;
    using MonitorClient3;
    using MonitorClient3._0;
    using BaseClass;

    // State object for reading client data asynchronously
    public class StateObject
    {
        // Client  socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 1024;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }

    public class Comm
    {
        // Thread signal.
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        static bool IsStopped = false;

        public static event EventHandler<TCPClientSocket.MessageEventArgs> ReciveMessage;

        public static void OnReciveMessage(TCPClientSocket.MessageEventArgs e)
        {
            EventHandler<TCPClientSocket.MessageEventArgs> handler = ReciveMessage;
            if (handler != null) handler(null, e);
        }

        public static void StopListening()
        {
            ////allDone.Reset();
            ////allDone.Close();
            //IsStopped = true;
        }

        public static void StartMonitoring()
        {
           Thread ThreadMonitoring = new Thread(ScreenCapture);
            CheckScreenCapture = true;
           ThreadMonitoring.Start(null);
        }

        public static void StopMonitoring()
        {
            CheckScreenCapture = false;
        }

        public static byte[] LastScreenCapture = null;

        private static bool CheckScreenCapture = false;

        public static int SleepTime = 100;

        private static void ScreenCapture(Object cInfo1)
        {
            try
            {
                Bitmap img = null;
                while (CheckScreenCapture)
                {
                    // = 
                     img = CaptureScreen.CaptureScreen.GetDesktopImage();
                    LastScreenCapture = ScreenCapturing.GetBytes(img);

                    Thread.Sleep(SleepTime);
                }
            }
            catch 
            {
                
            }

           
            //UpdateStatusDelegate UpdateStatus = new UpdateStatusDelegate(UpdateClientStatus);
            //this.Invoke(UpdateStatus, new object[] { ReplyDataObj, cInfo1 });

        }

        public static void StartListening(int port)
        {
            try
            {
                
                // Data buffer for incoming data.
              //  byte[] bytes = new Byte[1024];

                // Establish the local endpoint for the socket. 

                

                IPHostEntry ipHostInfo = Dns.GetHostByName(Dns.GetHostName());// Dns.GetHostEntry(ClientDef.ServerIP);
                IPEndPoint localEndPoint = new IPEndPoint(ipHostInfo.AddressList[0],port);// Convert.ToInt32(ClientDef.Port));
                
                // Create a TCP/IP socket.
                Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                listener.SendBufferSize = 51200;
                listener.ReceiveBufferSize = 51200;

                // Bind the socket to the local endpoint and listen for incoming connections.            
                listener.Bind(localEndPoint);
                listener.Listen(200);
                
               // IsStopped = false;
                while (true)
                {
                    try
                    {
                       
                        // Set the event to nonsignaled state.
                        allDone.Reset();

                        // Start an asynchronous socket to listen for connections.                        
                        listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);

                        // Wait until a connection is made before continuing.
                        allDone.WaitOne();
                    }
                    catch (ThreadAbortException)
                    {
                        
                      
                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show(e.Message);
                    }
                }
            }
            catch (ThreadAbortException)
            {
              
            }
            catch (Exception e)
            {
                if (e.Message.CompareTo("The requested address is not valid in its context") == 0)
                {
                   // System.Windows.Forms.MessageBox.Show("The IP " + ClientDef.ServerIP.ToString() + " that is written in the Definitions file as this computer IP is not availble.\nMake sure the defintiontions file includes your computer right IP and restart the program");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(e.Message);
                }
            }
        }

        public static void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.
            allDone.Set();

            // Get the socket that handles the client request.
            Socket listener = (Socket)ar.AsyncState;

          
            Socket handler = listener.EndAccept(ar);

            // Create the state object.
            StateObject state = new StateObject();
            state.workSocket = handler;
         //   handler.SendBufferSize = 100000;
            try
            {
                //
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ReadCallback(IAsyncResult ar)
        {
            try
            {
                String content = String.Empty;

                // Retrieve the state object and the handler socket
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
                Socket handler = state.workSocket;

                // Read data from the client socket. 
                int bytesRead = handler.EndReceive(ar);

                // There  might be more data, so store the data received so far.
                //state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                state.sb.Append(Encoding.UTF8.GetString(state.buffer, 0, bytesRead));

                if (handler.Available > 0)
                {
                    // Not all data received. Get more.
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
                }
                else
                {
                    content = state.sb.ToString();

                    // All the data has been read from the 
                    // client. Display it on the console.               
                    //Console.WriteLine("Read {0} bytes from socket.", content.Length);
                    // Log.WriteToLog(string.Format("Read {0} bytes from socket.", content.Length));

                    if (content.Length > 0)
                    {
                        QueryData receviedQueryData = QueryData.Deserialize(content);

                        OnReciveMessage(new MessageEventArgs(receviedQueryData));

                        ReplyData returnedReplyData = null;

                        switch (receviedQueryData.Type)
                        {
                            case Consts.SectionType.Message:
                                returnedReplyData = MessageBL.executeQuery(receviedQueryData);
                                // MessageBL.executeQuery(receviedQueryData);
                                break;

                            case Consts.SectionType.Processes:
                                returnedReplyData = ProcessesBL.executeQuery(receviedQueryData);
                                break;
                            case Consts.SectionType.Performance:
                                returnedReplyData = PerformanceBL.executeQuery(receviedQueryData);
                                break;
                            case Consts.SectionType.Properties:
                                returnedReplyData = PropertiesBL.executeQuery(receviedQueryData);
                                break;
                            case Consts.SectionType.SysInfo:
                                returnedReplyData = SysInfoBL.executeQuery(receviedQueryData);
                                break;
                            case Consts.SectionType.Status:
                                returnedReplyData = new ReplyData();
                                returnedReplyData.ArrDataContainers = new ArrayList();
                                Counter cnter = new Counter();
                                cnter.Name = "UserName";
                                cnter.Value = Environment.UserName;

                                Counter cnterhostName = new Counter();
                                cnterhostName.Name = "HostName";
                                cnterhostName.Value = Environment.UserName;

                                var dc = new DataContainer("127.0.0.1");
                                dc.ArrCounters = new ArrayList();
                                dc.ArrCounters.Add(cnter);
                                dc.ArrCounters.Add(cnterhostName);
                                returnedReplyData.ArrDataContainers.Add(dc);
                                break;
                            case Consts.SectionType.CaptureScreen:

                                if (CheckScreenCapture)
                                {
                                    if (LastScreenCapture != null)
                                    {
                                        returnedReplyData = new ReplyData();
                                        returnedReplyData.Type = Consts.SectionType.CaptureScreen;

                                        returnedReplyData.ArrDataContainers.Add(LastScreenCapture);
                                    }
                                }
                                else
                                {
                                    returnedReplyData = CaptureScreenBL.executeQuery(receviedQueryData);
                                }
                                break;
                            case Consts.SectionType.ExplorerLogicalDrive:

                                foreach (ObjectMetaData CurrCounter in receviedQueryData.ArrCounter)
                                {
                                    switch (CurrCounter.Tag)
                                    {
                                        case "ViewPath":

                                            try
                                            {
                                                DataContainer SysLogicalDirectoryDataContainer = new DataContainer("ViewPath");

                                                System.IO.DirectoryInfo dinfo = new System.IO.DirectoryInfo(CurrCounter.Text);


                                                System.IO.DirectoryInfo[] AllDirectoryInfo = dinfo.GetDirectories();

                                                foreach (System.IO.DirectoryInfo strDir in AllDirectoryInfo)
                                                {
                                                    SysLogicalDirectoryDataContainer.ArrCounters.Add(new Counter("FolderName", strDir.Name + '-' + strDir.FullName + '-' + " "));
                                                }

                                                foreach (System.IO.FileInfo strFile in dinfo.GetFiles())
                                                {
                                                    SysLogicalDirectoryDataContainer.ArrCounters.Add(new Counter("FileName", strFile.Name + '-' + strFile.FullName + '-' + " "));
                                                }

                                                if (returnedReplyData == null)
                                                    returnedReplyData = new ReplyData();

                                                returnedReplyData.ArrDataContainers.Add(SysLogicalDirectoryDataContainer);
                                            }
                                            catch
                                            { }
                                            break;
                                        case "OSLogicalDrives":
                                            DataContainer SysLogicalDrivesDataContainer = new DataContainer("OSLogicalDrives");

                                            System.IO.DriveInfo[] AllDriveInfo = System.IO.DriveInfo.GetDrives();


                                            foreach (System.IO.DriveInfo CurrLogicalDrive in System.IO.DriveInfo.GetDrives())
                                            {
                                                try
                                                {
                                                    if (CurrLogicalDrive.Name == "A:\\")  //Added by rm
                                                    {
                                                        // if (!CurrLogicalDrive.IsReady)
                                                        SysLogicalDrivesDataContainer.ArrCounters.Add(new Counter("DiskName", CurrLogicalDrive.Name + '-' + CurrLogicalDrive.Name + '-' + "Not accessable" + '-' + "Not accessable"));
                                                        continue;
                                                    }


                                                    if (CurrLogicalDrive.IsReady)
                                                    {

                                                        decimal FreeSpacePercent = decimal.Divide(CurrLogicalDrive.TotalFreeSpace, CurrLogicalDrive.TotalSize) * 10000;
                                                        int tempNum = Convert.ToInt32(FreeSpacePercent);
                                                        long TotalSizeMB = CurrLogicalDrive.TotalSize / 1000000;
                                                        FreeSpacePercent = decimal.Divide(tempNum, 100);
                                                        SysLogicalDrivesDataContainer.ArrCounters.Add(new Counter("DiskName", CurrLogicalDrive.Name + '-' + CurrLogicalDrive.Name + '-' + FreeSpacePercent.ToString() + "%" + '-' + TotalSizeMB.ToString("#,#", System.Globalization.CultureInfo.InvariantCulture)));
                                                    }
                                                    else
                                                    {
                                                        SysLogicalDrivesDataContainer.ArrCounters.Add(new Counter("DiskName", CurrLogicalDrive.Name + '-' + CurrLogicalDrive.Name + '-' + "Not accessable" + '-' + "Not accessable"));
                                                    }
                                                }
                                                catch (Exception)
                                                {
                                                    SysLogicalDrivesDataContainer.ArrCounters.Add(new Counter("DiskName", CurrLogicalDrive.Name + '-' + CurrLogicalDrive.Name + '-' + "Not accessable" + '-' + "Not accessable"));
                                                }
                                            }

                                            if (returnedReplyData == null)
                                                returnedReplyData = new ReplyData();

                                            returnedReplyData.ArrDataContainers.Add(SysLogicalDrivesDataContainer);
                                            break;
                                        default:
                                            break;
                                    }
                                }




                                // returnedReplyData.ArrDataContainers.Add(SysLogicalDrivesDataContainer);

                                break;
                            default:
                                break;
                        }

                        try
                        {
                            // Echo the data back to the client.
                            if (returnedReplyData != null)
                                Send(handler, returnedReplyData.Serialize());
                            else
                            {
                            }
                        }
                        catch (SocketException e)
                        {
                            Log.WriteToLog(e.ToString());
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Log.WriteToLog(ex.ToString());
            }
            
        }

        private static void Send(Socket handler, String data)
        {
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(data);
           // var tt = handler.RemoteEndPoint;
            // Begin sending the data to the remote device.
            handler.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), handler);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);
               // Log.WriteToLog(bytesSent.ToString() + " were sent to the monitoring server" + " " + handler.RemoteEndPoint.ToString());
                
                handler.Close();
            }
            catch (Exception e)
            {
                Log.WriteToLog(e.ToString());
            }
        }
    }
}
