using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Sbn.Core
{
    [Serializable]
    public class RequestArgs  : SbnObject
    {
        public RequestArgs()
        {

        }

        private SbnBoolean _IsCollectionRequest = SbnBoolean.True;

        public SbnBoolean IsCollectionRequest
        {
            get { return _IsCollectionRequest; }
            set { _IsCollectionRequest = value; }
        }

        private string _SystemName = null;
        public string SystemName
        {
            get { return _SystemName; }
            set { _SystemName = value; }
        }
        private RequestType _RequestHandler;
        public RequestType RequestHandler
        {
            get { return _RequestHandler; }
            set { _RequestHandler = value; }
        }

        private string _RequestCommand = null;

        public string RequestCommand
        {
            get { return _RequestCommand; }
            set { _RequestCommand = value; }
        }

        private string _RequestKey = null;

        public string RequestKey
        {
            get { return _RequestKey; }
            set { _RequestKey = value; }
        }

        private long  _SessionID = 0;

        public long  SessionID
        {
            get { return _SessionID; }
            set { _SessionID = value; }
        }

        private string _WebServiceURL = null;

        public string WebServiceURL
        {
            get { return _WebServiceURL; }
            set { _WebServiceURL = value; }
        }
        private string _SenderMACAddress = null;

        public string SenderMACAddress
        {
            get { return _SenderMACAddress; }
            set { _SenderMACAddress = value; }
        }
        private string _SenderIPAddress = null;

        public string SenderIPAddress
        {
            get { return _SenderIPAddress; }
            set { _SenderIPAddress = value; }
        }
        private long _CurrentWorkerID = -1;

        public long CurrentWorkerID
        {
            get { return _CurrentWorkerID; }
            set { _CurrentWorkerID = value; }
        }

        private long _CurrentUserID = -1;
        public long CurrentUserID
        {
            get { return _CurrentUserID; }
            set { _CurrentUserID = value; }
        }

        private long _PageNumber = -1;

        public long PageNumber
        {
            get { return _PageNumber; }
            set { _PageNumber = value; }
        }
        private long _RowsPerPage = -1;

        public long RowsPerPage
        {
            get { return _RowsPerPage; }
            set { _RowsPerPage = value; }
        }

        private List<string> _CustomData = new List<string>();
        public List<string> CustomData
        {
            get { return _CustomData; }
            set { _CustomData = value; }
        }

        private List<string> _SortData = new List<string>();
        public List<string> SortData
        {
            get { return _SortData; }
            set { _SortData = value; }
        }

        public RequestArgs Clone()
        {
            RequestArgs req = new RequestArgs();

            req._CurrentUserID = this._CurrentUserID;
            req._CurrentWorkerID = this._CurrentWorkerID;
            req._CustomData = new List<string>();
            req._PageNumber = this._PageNumber;
            req._RequestCommand = this._RequestCommand;
            req._RequestHandler = this._RequestHandler;
            req._RequestKey = this._RequestKey;
            req._RowsPerPage = this._RowsPerPage;
            req._SenderIPAddress = this._SenderIPAddress;
            req._SenderMACAddress = this._SenderMACAddress;
            req._SessionID = this._SessionID;
            req._SystemName = this._SystemName;
            req._WebServiceURL = this._WebServiceURL;

            return req;
        }

        //private long _AttributePattern = -1;

        //public long AttributePattern
        //{
        //    get { return _AttributePattern; }
        //    set { _AttributePattern = value; }
        //}


    }
}
