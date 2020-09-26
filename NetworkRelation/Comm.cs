using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace MonitorInfoViewer
{
    // State object for receiving data from remote device.
    public class StateObject
    {
        // Client socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 256;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }

    public class Comm
    {
        // The port number for the remote device.
        //private const int port = 11000;

        // ManualResetEvent instances signal completion.
        private static ManualResetEvent connectDone = new ManualResetEvent(false);
        private static ManualResetEvent sendDone = new ManualResetEvent(false);
        private static ManualResetEvent receiveDone = new ManualResetEvent(false);

        // The response from the remote device.
        private static String response = String.Empty;

        public static String SendQuery(string i_IP, int i_Port, string i_QueryString)
        {
            // Connect to a remote device.
            try
            {
                // Create a TCP/IP socket.
                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.ReceiveBufferSize = 51200;
                client.SendBufferSize = 51200;

                Connect(client, i_IP, i_Port);

                // Send test data to the remote device.
                Send(client, i_QueryString);

                // Receive the response from the remote device.
                response = Receive(client);

                // Release the socket.
                client.Close();
            }
            catch (Exception)
            {
                response = "";             
            }

            return response;
        }

        private static void Connect(Socket client, String i_IP, int i_Port)
        {
            // Establish the remote endpoint for the socket.     
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(i_IP), i_Port);
            

            // Connect to the remote endpoint.
            IAsyncResult result = client.BeginConnect(remoteEP, null, null);
            bool success = result.AsyncWaitHandle.WaitOne(300, true);

            // Came answer beck from the client before we hit timeout
            if (success)
            {
                // The sokcet could not be connected
                if (!client.Connected)
                {
                    client.Close();
                }
                
                // Complete the connection.
                client.EndConnect(result);
            }
            else
            {
                client.Close();
                throw new Exception("A connection to " + remoteEP.Address + " couldn't have been made");
            }
        }

        private static String Receive(Socket client)
        {
            byte[] recievedBytes = null;
            StringBuilder strBuilder = new StringBuilder();
            int numOfBytesRead = 0;

            if (client.Connected)
            {
                // Initialzing the bytes array that will read the socket data                
                recievedBytes = new byte[102400];

                // Begin receiving the data from the remote device.
                client.ReceiveTimeout = 15000;
                IAsyncResult result = client.BeginReceive(recievedBytes, 0, StateObject.BufferSize, 0, null, null);                
                bool success = result.AsyncWaitHandle.WaitOne(15000, true);

                // check if we timeout
                if (success)
                {                    
                    client.ReceiveTimeout = 200;
                    numOfBytesRead = client.EndReceive(result);

                    // Append the new data to the string
                    strBuilder.Append(Encoding.ASCII.GetString(recievedBytes, 0, numOfBytesRead));

                    // While there is data to be read in the reader buffer.
                    while (client.Available > 0)
                    {
                        // Read data in chuncks and place it into recievedChar
                        numOfBytesRead = client.Receive(recievedBytes);
                        // Append the new data to the string
                        strBuilder.Append(Encoding.ASCII.GetString(recievedBytes, 0, numOfBytesRead));

                        // Check that we did not get the message terminator
                        if (Encoding.ASCII.GetString(recievedBytes)[(numOfBytesRead - 1)] == '\0')
                        {
                            // End of message was recieved
                            break;
                        }
                        Thread.Sleep(2);
                    }

                    if (strBuilder.Length == 0)
                    {

                    }
                }
                else
                {
                    client.Close();
                }
            }
            else
            {
                throw new Exception("Unable to connect to client");
            }
            

            return strBuilder.ToString();
        }

        private static void Send(Socket client, String data)
        {
            if (client.Connected)
            {
                // Convert the string data to byte data using ASCII encoding.
              //  byte[] byteData = Encoding.ASCII.GetBytes(data);

                byte[] byteData = Encoding.UTF8.GetBytes(data);

                // Begin sending the data to the remote device.
                //byteData.Length
                IAsyncResult result = client.BeginSend(byteData, 0, byteData.Length, 0, null, null);
                // todo to think about the hard coded vaule
                bool success = result.AsyncWaitHandle.WaitOne(200, true);

                int iSentResult = 0;
                if (success)
                {
                    iSentResult = client.EndSend(result);
                }
                else
                {
                    client.Close();
                }
            }
        }
    }
}
