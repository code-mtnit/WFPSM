using System;
using System.Collections.Generic;
using System.Text;
using BaseClass;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace MonitorClient3._0
{
    public class MessageBL
    {

        //public static void executeQuery(QueryData receivedQueryData)
        //{
        //    ReplyData returnedReplyData = new ReplyData();
        //    returnedReplyData.Type = Consts.SectionType.Message;



        //    string text = "";
        //    string caption = "";
        //    MessageBoxButtons button = MessageBoxButtons.OK;
        //    MessageBoxIcon icon = MessageBoxIcon.Information;

        //    foreach (ObjectMetaData omd in receivedQueryData.ArrCounter)
        //    {
        //        switch (omd.Tag)
        //        {
        //            case "Text":
        //                text = omd.Text;
        //                break;
        //            case "Caption":
        //                caption = omd.Text;
        //                break;
        //            case "MessageBoxButtons":
        //                button = (MessageBoxButtons)Enum.Parse(typeof(MessageBoxButtons), omd.Text);
        //                break;
        //            case "MessageBoxIcon":
        //                icon = (MessageBoxIcon)Enum.Parse(typeof(MessageBoxIcon), omd.Text);
        //                break;
        //            default:
        //                break;
        //        }
        //    }

        //    Thread clientThread = new Thread(delegate() { MessageShow(receivedQueryData, text, caption, button, icon); });
        //    clientThread.Start();

        //  //  MessageBox.Show(text, caption, button, icon);
        //    //  Image imgDesktop = ScreenCapturing.GetDesktopWindowCaptureAsByteArray();


        //    //MemoryStream ms = new MemoryStream();
        //    //imgDesktop.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        //    // byte[] b = ScreenCapturing.GetDesktopWindowCaptureAsByteArray();

        //    // ms.Dispose();


        //    //  returnedReplyData.ArrDataContainers.Add(b);
        //    //return returnedReplyData;
        //}


        public static ReplyData executeQuery(QueryData receivedQueryData)
        {
            ReplyData returnedReplyData = new ReplyData();
            returnedReplyData.Type = Consts.SectionType.Message;



            string text = "";
            string caption = "";
            MessageBoxButtons button = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;

            foreach (ObjectMetaData omd in receivedQueryData.ArrCounter)
            {
                switch (omd.Tag)
                {
                    case "Text":
                        text = omd.Text;
                        break;
                    case "Caption":
                        caption = omd.Text;
                        break;
                    case "MessageBoxButtons":
                        button = (MessageBoxButtons)Enum.Parse(typeof(MessageBoxButtons), omd.Text);
                        break;
                    case "MessageBoxIcon":
                        icon = (MessageBoxIcon)Enum.Parse(typeof(MessageBoxIcon), omd.Text);
                        break;
                    default:
                        break;
                }
            }



            Thread clientThread = new Thread(delegate() { MessageShow(receivedQueryData, text, caption, button, icon); });
            clientThread.Start();

            //MessageBox.Show(text, caption, button, icon);
            //  Image imgDesktop = ScreenCapturing.GetDesktopWindowCaptureAsByteArray();


            //MemoryStream ms = new MemoryStream();
            //imgDesktop.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            // byte[] b = ScreenCapturing.GetDesktopWindowCaptureAsByteArray();

            // ms.Dispose();


            //  returnedReplyData.ArrDataContainers.Add(b);
            return returnedReplyData;
        }

        public static ReplyData MessageShow(QueryData receivedQueryData, string text, string captionText, MessageBoxButtons messageBoxButtons, MessageBoxIcon icon )
        {
            ReplyData returnedReplyData = new ReplyData();
            returnedReplyData.Type = Consts.SectionType.Message;
            var res = MessageBox.Show(text, captionText, messageBoxButtons, icon);

            return returnedReplyData;
        }
    }
}
