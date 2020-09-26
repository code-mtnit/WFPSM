using System;
using System.Collections.Generic;
using System.Text;
using BaseClass;
using System.Drawing;
using System.IO;

namespace MonitorClient3._0
{
    public class CaptureScreenBL
    {


        public static ReplyData executeQuery(QueryData receivedQueryData)
        {
            ReplyData returnedReplyData = new ReplyData();
            returnedReplyData.Type = Consts.SectionType.CaptureScreen;
            // byte[] b = ScreenCapturing.GetDesktopWindowCaptureAsByteArray();
            var img = CaptureScreen.CaptureScreen.GetDesktopImage();
            byte[] b = ScreenCapturing.GetBytes(img);


            returnedReplyData.ArrDataContainers.Add(b);
            return returnedReplyData;
        }
    }
}
