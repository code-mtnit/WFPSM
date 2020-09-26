using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using MSXML2;
using Sbn.Libs.AssemblyTools;

namespace Sbn.Core
{

    [Description("ضمیمه")]
    [DisplayName ("ضمیمه")]
    [Serializable]
    public class SbnBinary : SbnObject  
    {
        #region Constructors

        public SbnBinary()
            : base()
        {

        }

        public SbnBinary(SbnBinary InitialObject)
            : base(InitialObject)
        {
            
            this.Stream = InitialObject.Stream;
        }

        ~SbnBinary() 
        {
            
        }


        #endregion Constructors


        #region Attributes

        private byte[] m_bStream;
        //private HTFAttachmentType m_Type;

        /// <summary>
        /// محتوی
        /// </summary>
        [Description("محتوی")]
        [DisplayName("محتوی")]
        [Category("NormalAttribute")]
        [Browsable (true)]
        public byte[] Stream
        {
            get { return m_bStream; }
            set { m_bStream = value; // NotifyPropertyChanged("Stream"); 
            }
        }

        //[Description("نوع ضمیمه")]
        //public HTFAttachmentType Type
        //{
        //    get { return m_Type; }
        //    set { m_Type = value; }
        //}

        #endregion Attributes

        public override string ToString()
        {
            return this.Title;
        }

        #region xmlParser Implementation

        //public override string GetXML(string sNodeName)
        //{
        //    try
        //    {

        //        base.GetXML(sNodeName);

        //        this.XMLParser.AddChildFromString("ObjectType", this.GetType().ToString(), this.XMLParser.documentElement);
        //        this.XMLParser.AddChildFromString("Title", m_sTitle, this.XMLParser.documentElement);

        //        IXMLDOMNode str = this.XMLParser.AddChildFromString("Stream", "", this.XMLParser.documentElement);
        //        str.set_dataType("bin.base64");
        //        if (m_bStream != null)
        //        {
        //            string attach = Convert.ToBase64String(m_bStream);
        //            str.nodeTypedValue = attach;
        //        }


        //        // this.XMLParser.AddChildFromString("Type", m_Type.ToString(), this.XMLParser.documentElement);

        //        //if (this._InitialAndSaveMode) this.XMLParser.Save(_PhysicalPath, "BaseAttribute.xml");

        //        return this.XMLParser.xml ;
        //    }
        //    catch
        //    {
        //        throw;
        //    }

        //    return null ;
        //}

        //public override void InitializeFromXML(string sXML, string sNodeName)
        //{
        //    try
        //    {
        //        base.InitializeFromXML (sXML, sNodeName);

        //        string sValue = null;
        //        bool bHasNext = false;

        //        sValue = "";
        //        sValue = this.XMLParser.GetNodeValue(this.XMLParser.XMLBaseNode, "Title", bHasNext);
        //        this.Title = sValue;

        //        sValue = "";
        //        sValue = this.XMLParser.GetNodeValue(this.XMLParser.XMLBaseNode, "Stream", bHasNext);

        //        if (sValue != null && sValue != "")
        //            this.Stream = Convert.FromBase64CharArray(sValue.ToCharArray(), 0, sValue.Length);

        //        //sValue = "";
        //        //lret = this.XMLParser.get_NodeValue(this.XMLParser.XMLBaseNode, "Type", ref sValue, bHasNext);
        //        //if(sValue != null && sValue != "")
        //        //    this.Type = (HTFAttachmentType)Enum.Parse(typeof(HTFAttachmentType), sValue);

        //        return;
        //    }
        //    catch
        //    {
        //        throw;
        //    }

        //    return;
        //}

        //public override void Load(string PhysicalPath, string pattern)
        //{
        //    try
        //    {
        //        base.Load(PhysicalPath, pattern);
        //    }
        //    catch
        //    {
        //        throw;
        //    }

        //}

        #endregion xmlParser Implementation

        #region Methdos

        public override SbnObject Clone(string sNodeName)
        {
            try
            {
                SbnBinary att = new SbnBinary(this);

                SbnObject objTemp = (SbnObject)att;
                base.Initialize( ref objTemp);
                
                if (this.Stream != null) att.Stream = (byte[])this.Stream.Clone();
                // att.Type = att.Type;

                return att;
            }
            catch
            {
                throw;
            }
        }

        public override void Initialize()
        {
            base.Initialize();
            this.Stream = new byte[1];
            this.Title = "";
        }

        #endregion

        #region static Members


        public static string at_Stream
        {
            get
            {
                return "SbnBinary.Stream";
            }
        }
        #endregion

    }

}
