using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSXML2;
using Sbn.Libs.XMLPareser;

namespace Sbn.Core
{

    public enum RequestType
    {
        Register = 1,
        Update = 2 , 
        Get = 3 , 
        Remove = 4, 
        AddTo  = 5 ,
        RemoveFrom = 6 ,
        Report = 7 ,
        Custom = 10
    }

    [Serializable]
    public class RequestPacket //: SbnObject
    {

        #region Attribute

        private RequestArgs rArgs = null;

        public RequestArgs RequestArgs
        {
            get { return rArgs; }
            set { rArgs = value; }
        }

        private string _ParameterValueStream;

        public string ParameterValueStream
        {
            get { return _ParameterValueStream; }
            set { _ParameterValueStream = value; }
        }

        private ISbnObject _ParameterValueObject = null;

        public ISbnObject ParameterValueObject
        {
            get { return _ParameterValueObject; }
            set { _ParameterValueObject = value; }
        }
        private ISbnObject _BaseParameterValueObject = null;

        public ISbnObject BaseParameterValueObject
        {
            get { return _BaseParameterValueObject; }
            set { _BaseParameterValueObject = value; }
        }

        #endregion

        #region Constructors

        public RequestPacket()
            : base()
        {
            try
            {
            }
            catch
            {
                throw;
            }
        }

        #endregion Constructors




    }

}
