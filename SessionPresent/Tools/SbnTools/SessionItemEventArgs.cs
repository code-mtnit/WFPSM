using System;
using System.Collections.Generic;
using System.Text;

namespace SessionPresent.Tools.SbnTools
{
    public class SessionItemEventArgs : EventArgs
    {
        public object Data { get; set; }

        public SessionItemEventArgs(object data)
        {
            Data = data;
        }
    }
}
