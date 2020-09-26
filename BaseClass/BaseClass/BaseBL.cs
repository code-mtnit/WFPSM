using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace BaseClass
{
    abstract public class BaseBL
    {
        #region Data Members
        protected ArrayList m_ArrCounters = new ArrayList();

        public ArrayList ArrCounters
        {
            get { return m_ArrCounters; }
            set { m_ArrCounters = value;  }
        }

        private ClientInfo m_CurrClient;

        public ClientInfo CurrClient
        {
            get { return m_CurrClient; }
            set { m_CurrClient = value; }
        }
        #endregion

        public abstract ReplyData ExecuteQuery(string i_IP, int i_Port);

        public abstract ReplyData ExecuteQuery(string i_IP, int i_Port, ClientInfo clientInfo);

        public abstract ReplyData ExecuteQuery(string i_IP, int i_Port, ClientInfo clientInfo , Object CurObj);
    }
}
