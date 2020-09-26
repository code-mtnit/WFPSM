using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using Sbn.Libs.XMLPareser;
using MSXML2;
using Sbn.Libs.AssemblyTools;

namespace Sbn.Core
{

    public enum AccessRightType
    {

        Insert = 1,
        Edit = 2,
        Get = 3,
        Remove = 4,
        Print = 5,
        Report = 6 , 
        AddTo = 7,
        RemoveFrom = 8,
        CustomAction = 9
    }

    public enum SbnBoolean
    {
        True = 1,
        False = 0,
        OutOfValue = 999
    }

    public enum SbnOwnershipDomain
    {
        Public = 0,
        Organizational = 1,
        Private = 2,
        OutOfValue = 999
    }

    public enum ResultMessageTypes
    {
        Completed = 1,
        Exception = 2,
        BusinessRuleWarning = 3,
        UnHandledException = 4,
        DataProviderError = 5,
        SessionExpired = 6,
        OutOfValue = 999
    }
    
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    [PropertyChanged.ImplementPropertyChanged]
    abstract public class SbnObject : ISbnObject, IComparable//, INotifyPropertyChanged
    {

        //public bool _InitialAndLoadMode = false;
        //public bool _InitialAndSaveMode = false;
        public string _PhysicalPath = null;

        #region Attributes
        private Guid _Uid = Guid.Empty;

        [Description("شناسه")]
        [DisplayName ("شناسه")]
        [Category("مشخصات فرعی")]
        [Browsable(true)]
        public Guid GUid
        {
            get { return _Uid; }
            set
            {
                _Uid = value;// NotifyPropertyChanged("GUid");
            }
        }

        private long _ID = -1;
        [Description("شماره سریال")]
        [DisplayName("شماره سریال")]
        [Category("مشخصات فرعی")]
        [Browsable(true)]
        public long ID
        {
            get { return _ID; }
            set { _ID = value; //NotifyPropertyChanged("ID"); 
            }
        }
        
        private string _UniqueKey = "";
        [Description("شناسه یکتا")]
        [DisplayName("شناسه یکتا")]
        [Category("مشخصات فرعی")]
        [Browsable(true)]
        public string UniqueKey
        {
            get
            {
                return _UniqueKey;// double.Parse(this.RegistrationDate.Replace("/", "").Replace(" ", "").Replace(":", "") + this.ID.ToString());
            }
            set { _UniqueKey = value; }
        }
        private string _Title = null;
        [Description("عنوان")]
        [DisplayName("عنوان")]
        [Category("مشخصات اصلی")]
        [Browsable(true)]
        [AttributeType("String")]
        public string Title
        {
            get { return _Title; }
            set { _Title = value;  //NotifyPropertyChanged("Title"); 
            }
        }


        private string _Description = null;
        [Description("شرح")]
        [DisplayName("شرح")]
        [Category("مشخصات اصلی")]
        [Browsable(true)]
        [AttributeType("String")]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; //NotifyPropertyChanged("Description"); 
            }
        }

        private string _AliasCode = null;
        [Description("شماره سند")]
        [DisplayName("شماره سند")]
        [Category("مشخصات اصلی")]
        [Browsable(true)]
        [AttributeType("String")]
        public string AliasCode
        {
            get { return _AliasCode; }
            set { _AliasCode = value;// NotifyPropertyChanged("AliasCode"); 
            }
        }

        private string _RegistrationDate = null;
        [Description("تاریخ ایجاد")]
        [DisplayName("تاریخ ایجاد")]
        [Category("مشخصات اصلی")]
        [Browsable(true)]
        [AttributeType("DateString")]
        public string RegistrationDate
        {
            get { return _RegistrationDate; }
            set { _RegistrationDate = value; //NotifyPropertyChanged("RegistrationDate"); 
            }
        }

        private string _LastEditionDate = null;
        [Description("تاریخ آخرین ویرایش")]
        [DisplayName("تاریخ آخرین ویرایش")]
        [Category("مشخصات اصلی")]
        [Browsable(true)]
        [AttributeType("DateString")]
        public string LastEditionDate
        {
            get { return _LastEditionDate; }
            set { _LastEditionDate = value;// NotifyPropertyChanged("LastEditionDate"); 
            }
        }

        private SbnBoolean _IsActive = SbnBoolean.OutOfValue;
        [Description("وضعیت فعالیت")]
        [Browsable(true)]
        public SbnBoolean IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value;// NotifyPropertyChanged("IsActive"); 
            }
        }

        private SbnOwnershipDomain _OwnershipDomainType = SbnOwnershipDomain.OutOfValue;
        [Description("دامنه مالکیت")]
        [Browsable(true)]
        public SbnOwnershipDomain OwnershipDomainType
        {
            get { return _OwnershipDomainType; }
            set { _OwnershipDomainType = value; //NotifyPropertyChanged("OwnershipDomainType"); 
            }
        }

        private Object _Tag;
        [Description("برچسب")]
        [DisplayName("برچسب")]
        [Category("مشخصات تکمیلی")]
        [Browsable(true)]
        [AttributeType("Object")]
        public Object Tag
        {
            get { return _Tag; }
            set { _Tag = value; }
        }

        [NonSerializedAttribute()]
        private XMLParser _XMLParser = null;
        [Browsable(false)]
        public XMLParser XMLParser
        {
            get { return _XMLParser; }
            set { _XMLParser = value; }
        }



        #endregion Attributes

        #region Constructor

        public SbnObject()
        {

        }
        public SbnObject(SbnObject InitialObject)
        {

            this.ID = InitialObject.ID;
            this.IsActive = InitialObject.IsActive;
            if (InitialObject.LastEditionDate != null) this.LastEditionDate = (string)InitialObject.LastEditionDate.Clone();
            if (InitialObject.RegistrationDate != null) this.RegistrationDate = (string)InitialObject.RegistrationDate.Clone();
            if (InitialObject.Title != null) this.Title = (string)InitialObject.Title.Clone();
            if (InitialObject.Description != null) this.Description = (string)InitialObject.Description.Clone();

        }
        ~SbnObject()
        {
            if (!object.ReferenceEquals(this.XMLParser, null))
            {


            }
        }

        #endregion

        #region Methods


        public virtual SbnObject Clone(string sNodeName)
        {

            return null;
        }

        public override bool Equals(object obj)
        {
            if(obj is SbnObject)
                if (!object.ReferenceEquals(this, null) && !object.ReferenceEquals(obj, null))
                {
                    if (this.ID == -1 && ((SbnObject)obj).ID == -1)
                    {
                        return object.ReferenceEquals(this, obj);
                    }
                    else
                        return this.ID == ((SbnObject)obj).ID;
                }
                else if (object.ReferenceEquals(this, null) && object.ReferenceEquals(obj, null))
                    return true;

            return false;

        }

        public static bool operator ==(SbnObject x, SbnObject y)
        {
            if (!object.ReferenceEquals(x, null) && !object.ReferenceEquals(y, null))
            {
                if (x.ID == -1 && y.ID == -1)
                {
                    return object.ReferenceEquals(x, y);
                }
                else
                    return x.ID == y.ID;
            }
            else if (object.ReferenceEquals(x, null) && object.ReferenceEquals(y, null))
                return true;

            return false  ;
        }

        public static bool operator !=(SbnObject x, SbnObject y)
        {
            return !(x == y);
        }


        #endregion Methods

        #region IComparable Members

        public int CompareTo(object obj)
        {

            return this.ToString().CompareTo(((SbnObject)obj).ToString());
        }

        #endregion

        #region Static Members


        public static string at_ID
        {
            get
            {
                return "ID";
            }
        }

        public static string at_Uid
        {
            get
            {
                return "Uid";
            }
        }

        public static string at_Description
        {
            get
            {
                return "Description";
            }
        }

        public static string at_RegistrationDate
        {
            get
            {
                return "RegistrationDate";
            }
        }


        public static string at_LastEditionDate
        {
            get
            {
                return "LastEditionDate";
            }
        }



        public static string at_IsActive
        {
            get
            {
                return "IsActive";
            }
        }




        public static string at_AliasCode
        {
            get
            {
                return "AliasCode";
            }
        }


        public static string at_Title
        {
            get
            {
                return "Title";
            }
        }

        public static string at_OwnershipDomainType
        {
            get
            {
                return "OwnershipDomainType";
            }
        }

        /* Commented By ghmhm 930512
        /// <summary>
        /// درخواست تمام داده ها از تمام سطح ها
        /// شامل : تمام مقادیر ویژگیهای سطح اول
        /// تمام مقادیر ویژگیهای سطح دوم
        /// </summary>
        public static string at_AllAttributes
        {
            get
            {
                return "AllAttributes";
            }
        }

        public static string at_MainCategory
        {
            get
            {
                return "MainCategory";
            }
        }
        */
        /// <summary>
        /// درخواست داده سطح اول 
        /// تمام مقادیر ویژگیهای سطح اول 
        /// بعلاوه عنوان ویژگیهای سطح دوم از نوع اطلاعات پایه
        /// ارسال این پترن برای دریافت مقادیر ویژگی های سطح دوم از نوع موجودیت که به ازاء هر ویژگی در موجودیت تعریف شده است.
        /// </summary>
        public static string at_FirstLevelAttributes
        {
            get
            {
                return "FirstLevelAttributes";
            }
        }


        #endregion

        public override string ToString()
        {
            return this.Title;// +"-" + this.AliasCode + "-" + this.RegistrationDate;
        }

        #region ISbnObject Members
        bool _bSaveMode = false;
        public virtual string GetXML(string sNodeName)
        {
            try
            {
                if (sNodeName == null) sNodeName = GetType().Name;
                this.XMLParser = new XMLParser(sNodeName);

                this.XMLParser.AddAttribute("AssemblyName", this.GetType().Assembly.ManifestModule.Name, (IXMLDOMElement)this.XMLParser.documentElement);
                this.XMLParser.AddAttribute("ObjectType", this.GetType().Name, (IXMLDOMElement)this.XMLParser.documentElement);

                List<PropertyInfo> pInfos = Methods.GetBrowsableAttributes(this.GetType());

                foreach (PropertyInfo pInfo in pInfos)
                {

                    //Type tObj = typeof(ISbnObject);

                    object val = pInfo.GetValue(this, null);

                    if (!object.ReferenceEquals(val, null))
                    {
                        IXMLDOMNode node = null;

                        Type type = val.GetType();

                        if (type == typeof(string) )
                            node = this.XMLParser.AddChildFromString(pInfo.Name, (string)val, this.XMLParser.documentElement);
                        else if (type == typeof(System.Byte[]))
                        {
                            if (!_bSaveMode)
                            {
                                node = this.XMLParser.AddChildFromString(pInfo.Name, "", this.XMLParser.documentElement);
                                node.set_dataType("bin.base64");
                                string attach = Convert.ToBase64String((byte[])val);
                                node.nodeTypedValue = attach;
                            }
                            else
                            {
                                node = this.XMLParser.AddChildFromString(pInfo.Name, _PhysicalPath + "\\" + pInfo.Name + ".dat", this.XMLParser.documentElement);

                                if (!System.IO.Directory.Exists(_PhysicalPath)) System.IO.Directory.CreateDirectory(_PhysicalPath);

                                System.IO.StreamWriter sw = new System.IO.StreamWriter (_PhysicalPath + "\\" + pInfo.Name + ".dat");

                                sw.BaseStream.Write((byte[])val, 0, (int)((byte[])val).Length);

                                sw.Close();

                            }
                        }
                        else if (type == typeof(System.Guid) )
                            node = this.XMLParser.AddChildFromString(pInfo.Name, ((Guid)val).ToString(), this.XMLParser.documentElement);
                        else if (type == typeof(System.Int64) || type == typeof(System.Int32))
                            node = this.XMLParser.AddChildFromString(pInfo.Name, val.ToString(), this.XMLParser.documentElement);
                        else if (type.BaseType == typeof(SbnBinary))
                        {
                            if (!_bSaveMode)
                            {
                                try
                                {
                                    ((SbnObject)val).GetXML(pInfo.Name);

                                    if (((SbnObject)val).XMLParser != null && ((SbnObject)val).XMLParser.documentElement != null)
                                        node = this.XMLParser.AddChildFromNode(((SbnObject)val).XMLParser.documentElement, this.XMLParser.documentElement);
                                }
                                catch (Exception ex)
                                {
                                    string sError = ex.Message;
                                    node = this.XMLParser.AddChildFromString(pInfo.Name, sError, this.XMLParser.documentElement);
                                }
                            }
                        }
                        else if (type.BaseType == typeof(SbnObject) )
                        {
                            if (!_bSaveMode)
                            {
                                try
                                {
                                    ((SbnObject)val).GetXML(pInfo.Name);

                                    if (((SbnObject)val).XMLParser != null && ((SbnObject)val).XMLParser.documentElement != null)
                                        node = this.XMLParser.AddChildFromNode(((SbnObject)val).XMLParser.documentElement, this.XMLParser.documentElement);
                                }
                                catch (Exception ex)
                                {
                                    string sError = ex.Message;
                                    node = this.XMLParser.AddChildFromString(pInfo.Name, sError, this.XMLParser.documentElement);
                                }
                            }
                        }
                        else if (type.BaseType.Name.Contains("SbnListObject"))
                        {
                            if (!_bSaveMode)
                            {
                                try
                                {
                                    node = this.XMLParser.AddChildFromString(pInfo.Name, "", this.XMLParser.documentElement);
                                    Type valType = val.GetType();
                                    object countItems = valType.InvokeMember("Count", BindingFlags.GetProperty, null, val, null);
                                    for (int i = 0; i < (int)countItems; i++)
                                    {
                                        object[] objChildItem = new object[1];
                                        objChildItem[0] = i;

                                        object objItem = valType.InvokeMember("GetItem", BindingFlags.InvokeMethod, null, val, objChildItem);

                                        SbnObject OutObj = (SbnObject)objItem;
                                        OutObj.GetXML(null);

                                        this.XMLParser.AddChildFromNode(OutObj.XMLParser.documentElement, node);

                                    }

                                    /* commented by ghmhm 930512
                                    if (((SbnObject)val).XMLParser != null && ((SbnObject)val).XMLParser.documentElement != null)
                                        node = this.XMLParser.AddChildFromNode(((SbnObject)val).XMLParser.documentElement, this.XMLParser.documentElement);
                                    */
                                }
                                catch (Exception ex)
                                {
                                    string sError = ex.Message;
                                    node = this.XMLParser.AddChildFromString(pInfo.Name, sError, this.XMLParser.documentElement);
                                }
                            }
                        }
                        else if (type.BaseType == typeof(Enum))
                        {
                            node = this.XMLParser.AddChildFromString(pInfo.Name, val.ToString(), this.XMLParser.documentElement);

                        }
                        if (node != null) this.XMLParser.AddAttribute("SystemDataType", type.ToString(), (IXMLDOMElement)node);
                        else
                        {
                            if (pInfo.PropertyType.Name == "ISbnObject")
                            {
                                node = this.XMLParser.AddChildFromString(pInfo.Name, "", this.XMLParser.documentElement);
                                this.XMLParser.AddAttribute("AssemblyName", type.Assembly.ManifestModule.Name , (IXMLDOMElement)node);
                                this.XMLParser.AddAttribute("SystemDataType", type.ToString(), (IXMLDOMElement)node);
                            }
                        }
                    }
                }

                //this.XMLParser.AddChildFromString("UID", this._Uid.ToString(), this.XMLParser.documentElement);
                //this.XMLParser.AddChildFromString("ID", this._ID.ToString(), this.XMLParser.documentElement);
                //if (this._Description != null) this.XMLParser.AddChildFromString("Description", this._Description.ToString(), this.XMLParser.documentElement);
                //this.XMLParser.AddChildFromString("RowIDInList", this._RowIDInList.ToString(), this.XMLParser.documentElement);

                return this.XMLParser.xml;
            }
            catch
            {
                throw;
            }
            return null;
        }

        public virtual void InitializeFromXML(string sXML, string sNodeName , List<string> pattern)
        {
            try
            {
                this.XMLParser = new XMLParser(sNodeName);

                if (sXML != null)
                {
                    this.XMLParser.loadXML(sXML);
                    this.XMLParser.XMLBaseNode = this.XMLParser.documentElement;

                    List<PropertyInfo> pInfos = Methods.GetBrowsableAttributes(this.GetType());

                    foreach (PropertyInfo pInfo in pInfos)
                    {

                        //Type tObj = typeof(ISbnObject);

                            string sValue = null;
                            bool bHasNext = false;
                            object val = null;

                            sValue = this.XMLParser.GetNodeValue((IXMLDOMNode)this.XMLParser.XMLBaseNode, pInfo.Name, bHasNext);

                            Type dtype = pInfo.PropertyType;

                            if (dtype == typeof(string) && !object.ReferenceEquals(sValue, null))
                            {
                                pInfo.SetValue(this, sValue, null);
                            }
                            else if (dtype == typeof(System.Byte[]) && !object.ReferenceEquals(sValue, null))
                            {
                                if (pattern != null && !pattern.Contains("~" + this.GetType().Name + "." + pInfo.Name))
                                {

                                    if (System.IO.File.Exists(_PhysicalPath + "\\" + pInfo.Name + ".dat"))
                                    {
                                        System.IO.StreamReader sr = new System.IO.StreamReader(_PhysicalPath + "\\" + pInfo.Name + ".dat");

                                        byte[] b1 = new byte[sr.BaseStream.Length];

                                        sr.BaseStream.Read(b1, 0, (int)sr.BaseStream.Length);

                                        sr.Close();

                                        pInfo.SetValue(this, b1, null);
                                    }
                                    else
                                    {
                                        byte[] buffer = Convert.FromBase64CharArray(sValue.ToCharArray(), 0, sValue.Length);
                                        pInfo.SetValue(this, buffer, null);
                                    }
                                }
                            }
                            else if (dtype == typeof(System.Guid) && !object.ReferenceEquals(sValue, null))
                            {
                                Guid uID = new Guid(sValue);
                                pInfo.SetValue(this, uID, null);
                            }
                            else if (dtype == typeof(System.Int64) && !object.ReferenceEquals(sValue, null))
                            {
                                long l = long.Parse(sValue);
                                pInfo.SetValue(this, l, null);
                            }
                            else if (dtype == typeof(System.Int32) && !object.ReferenceEquals(sValue, null))
                            {
                                int l = int.Parse(sValue);
                                pInfo.SetValue(this, l, null);

                            }
                            else if (dtype.BaseType == typeof(Enum) && !object.ReferenceEquals(sValue, null))
                            {
                                object oVal = Enum.Parse(dtype ,sValue);
                                pInfo.SetValue(this, oVal, null);
                            }

                    }
                }


                //sValue = "";
                //sValue = this.XMLParser.GetNodeValue(this.XMLParser.XMLBaseNode, "ID", bHasNext);
                //this._ID = Convert.ToInt64(sValue);

                //sValue = "";
                //sValue = this.XMLParser.GetNodeValue(this.XMLParser.XMLBaseNode, "UID", bHasNext);
                //this._Uid = new Guid(sValue);

                //sValue = "";
                //sValue = this.XMLParser.GetNodeValue(this.XMLParser.XMLBaseNode, "RowIDInList", bHasNext);
                //if (sValue != null && sValue != "") this._RowIDInList = Convert.ToInt64(sValue);


                return ;
            }
            catch
            {
                throw;
            }

            return ;
        }

        public virtual void Load(string PhysicalPath, List<string> CustomAttributes)
        {
            try
            {
                if (!System.IO.Directory.Exists(PhysicalPath))
                    return;

                string sLocation = PhysicalPath;

                _PhysicalPath = sLocation;

                //this._InitialAndLoadMode = true;

                XMLParser xmlpars = new XMLParser();
                xmlpars.load(_PhysicalPath + "\\BaseValues.xml");

                this.InitializeFromXML (xmlpars.documentElement.xml, this.GetType().ToString() , CustomAttributes);

                List<PropertyInfo> pInfos = Methods.GetBrowsableAttributes(this.GetType());

                foreach (PropertyInfo pInfo in pInfos)
                {
                    try {
                        if (CustomAttributes != null && CustomAttributes.Contains(pInfo.Name))
                        {

                        }
                        else
                        {
                            Type dtype = pInfo.PropertyType;

                            if (dtype != typeof(string) && dtype != typeof(System.Byte[]) && dtype != typeof(System.Guid) &&
                                dtype != typeof(System.Int64) && dtype != typeof(System.Int32)
                            && dtype != typeof(SbnBoolean)
                            && dtype != typeof(RequestArgs)
                                && dtype != typeof(SbnOwnershipDomain))
                            {
                                if (dtype.Name == "ISbnObject")
                                {
                                    if (System.IO.Directory.Exists(_PhysicalPath + "\\" + pInfo.Name))
                                    {

                                        IXMLDOMNode dNode = this.XMLParser.GetNode((IXMLDOMNode)this.XMLParser.XMLBaseNode, pInfo.Name);

                                        string sNameSpace = this.XMLParser.GetAttributeValue((IXMLDOMElement)dNode, 0);
                                        string sObjectType = this.XMLParser.GetAttributeValue((IXMLDOMElement)dNode, 1);
                                        string sLocation1 = this.GetType().Assembly.Location;
                                        sLocation1 = sLocation1.Replace(this.GetType().Assembly.ManifestModule.Name, "");

                                        Assembly asb = Assembly.LoadFile(sLocation1 + sNameSpace);

                                        object obj = asb.CreateInstance(sObjectType);

                                        try {

                                            ((ISbnObject)obj).Load(_PhysicalPath + "\\" + pInfo.Name, CustomAttributes);

                                            pInfo.SetValue(this, obj, null);
                                        }
                                        catch (Exception ex)
                                        {

                                        }


                                    }
                                }
                                else
                                {
                                    if (System.IO.Directory.Exists(_PhysicalPath + "\\" + pInfo.Name))
                                    {
                                        if (dtype.BaseType.Name.Contains("SbnListObject"))
                                        {

                                            //string sLocation1 = this.GetType().Assembly.Location;
                                            //sLocation1 = sLocation1.Replace(this.GetType().Assembly.ManifestModule.Name, "");

                                            //Assembly asb = Assembly.LoadFile(sLocation1 + "\\" + dtype.Assembly.ManifestModule.Name);

                                            //object obj = asb.CreateInstance(dtype.FullName);

                                            try {
                                                ISbnObject iSbn = (ISbnObject)Activator.CreateInstance(dtype);
                                                iSbn.Load(_PhysicalPath + "\\" + pInfo.Name, CustomAttributes);
                                                pInfo.SetValue(this, iSbn, null);
                                            }
                                            catch (Exception ex)
                                            {

                                            }
                                        }
                                        else
                                        {
                                            try {
                                                ISbnObject iSbn = (ISbnObject)Activator.CreateInstance(dtype);
                                                iSbn.Load(_PhysicalPath + "\\" + pInfo.Name, CustomAttributes);

                                                pInfo.SetValue(this, iSbn, null);
                                            }
                                            catch (Exception ex)
                                            {

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch(Exception ex)
                    {

                    }
                    //Type tObj = typeof(ISbnObject);
                    
                }

                xmlpars = null;

                return;
            }
            catch(Exception ex)
            {
                Console.Write(PhysicalPath);
                throw;
            }
            return;

        }

        public virtual void Save(string PhysicalPath)
        {
            try
            {
//                this.XMLParser.Save(_PhysicalPath, "BaseAttribute.xml");

                _bSaveMode = true;

                if (PhysicalPath == null)
                {
                    string sLocation = GetType().Assembly.Location.ToLower().Replace("\\" + GetType().Module.ToString().ToLower(), "");

                    _PhysicalPath = sLocation;// +"\\" + GetType().Name + "_" + this.ID.ToString();

                    //this._InitialAndSaveMode = true;

                    this.GetXML (null);
                    this.XMLParser.Save(_PhysicalPath, "BaseValues.xml");

                }
                else
                {
                    string sLocation = PhysicalPath;// +"\\" + GetType().Name + "_" + this.ID.ToString();

                    _PhysicalPath = sLocation;

                    //this._InitialAndSaveMode = true;

                    this.GetXML (null);

                    this.XMLParser.Save(_PhysicalPath, "BaseValues.xml");
                }

                List<PropertyInfo> pInfos = Methods.GetBrowsableAttributes(this.GetType());

                foreach (PropertyInfo pInfo in pInfos)
                {
                    

                    Type dtype = pInfo.PropertyType;

                    if (dtype != typeof(string) && dtype != typeof(System.Byte[]) && dtype != typeof(System.Guid) &&
                        dtype != typeof(System.Int64) && dtype != typeof(System.Int32) 
                        && dtype != typeof(SbnBoolean)
                        && dtype != typeof(SbnOwnershipDomain) && dtype.BaseType != typeof(Enum))
                    {
                        object val = pInfo.GetValue(this, null);
                        if (val != null)
                        {
                            Type vType = val.GetType();
                            if (vType.BaseType.Name.Contains("SbnListObject"))
                                ((ISbnObject)val).Save(_PhysicalPath + "\\" + pInfo.Name );
                            else 
                                ((ISbnObject)val).Save(_PhysicalPath + "\\" + pInfo.Name);
                            //MethodInfo[] methods = dtype.GetMethods( );

                            //MethodInfo method = dtype.GetMethods()[8];
                            //method.Invoke(null , param);
                            ////MethodInfo generic = method.MakeGenericMethod(tType);
                            ////generic.Invoke(obj, new object[] { pLoadOut.Data });



                            //var o = Activator.CreateInstance(dtype) as SbnBinaries;
                            //tp.InvokeMember("Save", BindingFlags.InvokeMethod , null, null, param);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            return;
        }

        public virtual void SaveToSingleFile(string PhysicalPath)
        {
            try
            {
                //                this.XMLParser.Save(_PhysicalPath, "BaseAttribute.xml");

                //_bSaveMode = true;

                if (PhysicalPath == null)
                {
                    string sLocation = GetType().Assembly.Location.ToLower().Replace("\\" + GetType().Module.ToString().ToLower(), "");

                    _PhysicalPath = sLocation;// +"\\" + GetType().Name + "_" + this.ID.ToString();

                    //this._InitialAndSaveMode = true;

                    this.GetXML(null);

                    this.XMLParser.Save(_PhysicalPath, this.ID +  ".xml");

                }
                else
                {
                    string sLocation = PhysicalPath;// +"\\" + GetType().Name + "_" + this.ID.ToString();

                    _PhysicalPath = sLocation;

                    //this._InitialAndSaveMode = true;

                    this.GetXML(null);

                    this.XMLParser.Save(_PhysicalPath, this.ID + ".xml");
                }
                /*
                List<PropertyInfo> pInfos = Methods.GetBrowsableAttributes(this.GetType());

                foreach (PropertyInfo pInfo in pInfos)
                {


                    Type dtype = pInfo.PropertyType;

                    if (dtype != typeof(string) && dtype != typeof(System.Byte[]) && dtype != typeof(System.Guid) &&
                        dtype != typeof(System.Int64) && dtype != typeof(System.Int32)
                        && dtype != typeof(SbnBoolean)
                        && dtype != typeof(SbnOwnershipDomain) && dtype.BaseType != typeof(Enum))
                    {
                        object val = pInfo.GetValue(this, null);
                        if (val != null)
                        {
                            Type vType = val.GetType();
                            if (vType.BaseType.Name.Contains("SbnListObject"))
                                ((ISbnObject)val).Save(_PhysicalPath + "\\" + pInfo.Name);
                            else
                                ((ISbnObject)val).Save(_PhysicalPath + "\\" + pInfo.Name);
                            //MethodInfo[] methods = dtype.GetMethods( );

                            //MethodInfo method = dtype.GetMethods()[8];
                            //method.Invoke(null , param);
                            ////MethodInfo generic = method.MakeGenericMethod(tType);
                            ////generic.Invoke(obj, new object[] { pLoadOut.Data });



                            //var o = Activator.CreateInstance(dtype) as SbnBinaries;
                            //tp.InvokeMember("Save", BindingFlags.InvokeMethod , null, null, param);
                        }
                    }
                }
                */
            }
            catch
            {
                throw;
            }
            return;
        }        

        #endregion

        //#region INotifyPropertyChanged Members

        //public event PropertyChangedEventHandler PropertyChanged;

        //public void NotifyPropertyChanged(String info)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(info));
        //    }
        //}

        //#endregion


        public virtual void Initialize(ref SbnObject sbnObject)
        {
            sbnObject.ID = this.ID;
            if (this.AliasCode != null) sbnObject.AliasCode  = (string)this.AliasCode .Clone();
            if (this.Title != null) sbnObject.Title = (string)this.Title.Clone();
            if (this.Description != null) sbnObject.Description = (string)this.Description.Clone();
            sbnObject.IsActive = this.IsActive;
            if (this.RegistrationDate != null) sbnObject.RegistrationDate = (string)this.RegistrationDate.Clone();
            if (this.LastEditionDate != null) sbnObject.LastEditionDate = (string)this.LastEditionDate.Clone();
        }

        public virtual  void Initialize()
        {
            this.ID = -1 ;
            this.Title = "";
            this.Description = "";
            this.AliasCode = "";
            this.IsActive = SbnBoolean.OutOfValue ;
            this.RegistrationDate = "";
            this.LastEditionDate = "";
            this.GUid = Guid.NewGuid();
        }
    }
}
