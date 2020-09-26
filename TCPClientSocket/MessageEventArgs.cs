using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseClass;

namespace TCPClientSocket
{
    public class MessageEventArgs : EventArgs
    {
        public QueryData QueryData { get; set; }

        public MessageEventArgs(QueryData queryData)
        {
            QueryData = queryData;
        }
    }
}
