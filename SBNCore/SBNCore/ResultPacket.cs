using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Sbn.Libs.XMLPareser;
using MSXML2;

namespace Sbn.Core
{
    [Serializable]
    public class ResultPacket : SbnObject 
    {

        public ResultPacket()
            : base()
        {
        }


        # region Attributes

        public ResultMessageTypes ResultMessageType = ResultMessageTypes.OutOfValue;
        public String ResultMessage = "";
        public String ExceptionMessage = "";
        public ISbnObject ResultObject;
        public String ResultStrem = "";
        public int AffectedRows = 0;
        public Dictionary<long , object> CustomResult;

        # endregion Attributes
        
        public override string  GetXML(string sNodeName)
        {
            try
            {
                this.XMLParser = new XMLParser(this.GetType().ToString());

                this.XMLParser.AddChildFromString("ResultMessage", ResultMessage, this.XMLParser.documentElement );
                this.XMLParser.AddChildFromString("ExceptionMessage", ExceptionMessage, this.XMLParser.documentElement);

                if (ResultObject  != null)
                {
                    this.ResultObject.GetXML(null);

                    if (this.ResultObject  is IList)
                    {
                        string sXML = this.ResultObject .GetXML(null);
                        this.XMLParser.AddChildFromString("ResultObject", sXML, this.XMLParser.documentElement);
                    }
                    else
                    {
                        this.XMLParser.AddChildFromString("ResultObject", ((SbnObject)this.ResultObject ).XMLParser.documentElement.xml, this.XMLParser.documentElement);
                    }
                }
                return this.XMLParser.xml;
            }
            catch
            {
                throw;
            }
            return null;
        }

        public override void InitializeFromXML(string sXML, string sNodeName , List<string> pattern)
        {
            base.InitializeFromXML(sXML, sNodeName, pattern);

            string sValue = null;
            bool bHasNext = false;


          

            sValue = "";
            sValue = this.XMLParser.GetNodeValue((IXMLDOMNode)this.XMLParser.XMLBaseNode, "ResultMessage", bHasNext);
            this.ResultMessage = sValue;

            sValue = "";
            sValue = this.XMLParser.GetNodeValue((IXMLDOMNode)this.XMLParser.XMLBaseNode, "ExceptionMessage", bHasNext);
            this.ExceptionMessage = sValue;

            sValue = "";
            sValue = this.XMLParser.GetNodeValue((IXMLDOMNode)this.XMLParser.XMLBaseNode, "ResultStream", bHasNext);
            this.ResultStrem  = sValue;

            return ;
        }
        
    }
}
