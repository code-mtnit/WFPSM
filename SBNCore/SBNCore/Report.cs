using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Sbn.Libs.XMLPareser;
using MSXML2;

namespace Sbn.Core
{
    [Serializable]
    public class Report : SbnObject
    {
        #region Constructors

        public Report()
            : base()
        {
        }

        #endregion Constructors

        #region Attributes

        private SbnObject m_LowerObject;
        private SbnObject m_UpperObject;
        private ISbnObject m_EqualObject;

        private Type _ReportObjectType;

        private long m_NumOfRows;

        public Type ReportObjectType
        {
            get { return _ReportObjectType; }
            set { _ReportObjectType = value; }
        }

        public long NumOfRows
        {
            get { return m_NumOfRows; }
            set { m_NumOfRows = value; }
        }

        public SbnObject LowerObject
        {
            get { return m_LowerObject; }
            set
            {
//                if (value != null) ((SbnObject)value).m_sNodename = "LowerObject";
                m_LowerObject = value;
            }
        }

        public SbnObject UpperObject
        {
            get { return m_UpperObject; }
            set
            {
//                if (value != null) ((SbnObject)value).m_sNodename = "UpperObject";
                m_UpperObject = value;
            }
        }
        public ISbnObject EqualObject
        {
            get { return m_EqualObject; }
            set
            {
//                if (value != null) ((SbnObject)value).m_sNodename = "EqualObject";
                m_EqualObject = value;
            }
        }

        #endregion Attributes
        /*
        #region xmlParser Implementation

        public override string GetXML(string sNodeName)
        {
            try
            {


                this.XMLParser = new XMLParser();

                this.XMLParser.AddChildFromString("ObjectType", this.GetType().ToString(), this.XMLParser.documentElement);

                this.XMLParser.AddChildFromString("ReportObjectType", _ReportObjectType.GetType().ToString() , this.XMLParser.documentElement);

                string sValue = null;
                sValue = this.m_NumOfRows.ToString();
                this.XMLParser.AddChildFromString("NomOfRows", sValue, this.XMLParser.documentElement);



                if (this.m_EqualObject != null)
                {
                    this.m_EqualObject.GetXML (null );
                //    this.XMLParser.AddChildFromNode(this.m_EqualObject.XMLParser.documentElement , this.XMLParser.documentElement);
                }

                if (this.m_LowerObject != null)
                {
                    this.m_LowerObject.GetXML (null );
                    this.XMLParser.AddChildFromNode(this.m_LowerObject.XMLParser.documentElement, this.XMLParser.documentElement);
                }

                if (this.m_UpperObject != null)
                {
                    this.m_UpperObject.GetXML(null);
                    this.XMLParser.AddChildFromNode(this.m_UpperObject.XMLParser.documentElement, this.XMLParser.documentElement);
                }

                return this.XMLParser.xml ;
            }
            catch
            {
                throw;
            }

            return null ;
        }

        public override void InitializeFromXML(string sXML, string sNodeName, List<string> pattern)
        {
            try
            {
                string sValue = "";
                bool bHasNext = false;

                sValue = this.XMLParser.GetNodeValue((IXMLDOMNode)this.XMLParser.XMLBaseNode, "ObjectType", bHasNext);

                sValue = this.XMLParser.GetNodeValue((IXMLDOMNode)this.XMLParser.XMLBaseNode, "NomOfRows", bHasNext);
                this.m_NumOfRows = Convert.ToInt64(sValue);

                if ((IXMLDOMNode)this.XMLParser.GetNode((IXMLDOMNode)this.XMLParser.XMLBaseNode, 0) != null)
                {
                    if (this.m_LowerObject != null)
                    {
                        this.m_LowerObject.XMLParser = new XMLParser("LowrObject");

                        this.m_LowerObject.XMLParser.XMLBaseNode = (IXMLDOMNode)this.XMLParser.GetNode((IXMLDOMNode)this.XMLParser.XMLBaseNode, 0);

                        this.m_LowerObject.InitializeFromXML (null , null , pattern);
                    }
                }
                else
                {
                    this.m_LowerObject = null;
                }

                if (this.XMLParser.GetNode((IXMLDOMNode)this.XMLParser.XMLBaseNode, 1) != null)
                {
                    if (this.UpperObject != null)
                    {
                        this.UpperObject.XMLParser = new XMLParser("UpperObject");

                        this.UpperObject.XMLParser.XMLBaseNode = (IXMLDOMNode)this.XMLParser.GetNode((IXMLDOMNode)this.XMLParser.XMLBaseNode, 1);

                        this.UpperObject.InitializeFromXML (null , null , pattern);
                    }
                }
                else
                {
                    this.m_UpperObject = null;
                }

                if (this.XMLParser.GetNode((IXMLDOMNode)this.XMLParser.XMLBaseNode, 2) != null)
                {
                    if (this.EqualObject != null)
                    {
                    //    this.EqualObject.XMLParser = new XMLParser("EqualObject");

                    //    this.EqualObject.XMLParser.XMLBaseNode = this.XMLParser.GetNode((IXMLDOMNode)this.XMLParser.XMLBaseNode, 2);

                    //    this.EqualObject.InitializeFromXML (null , null , pattern);
                    }
                }
                else
                {
                    this.m_EqualObject = null;
                }


                return ;
            }
            catch
            {
                throw;
            }
            return ;
        }
        #endregion xmlParser Implementation
        */
    }

}
