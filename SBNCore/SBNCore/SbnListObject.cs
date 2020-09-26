using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.ComponentModel;
using System.Collections;
using Sbn.Libs.XMLPareser;
using MSXML2;

namespace Sbn.Core
{
    [Serializable]
    abstract public class SbnListObject<T> : List<T>, ISbnObject, ICustomTypeDescriptor
    {

        #region Attributes
        public string _PhysicalPath;
        public bool _InitialAndLoadMode = false;
        public bool _InitialAndSaveMode = false;

        [NonSerialized]
        public XMLParser _XMLParser;

        public XMLParser XMLParser
        {
            get { return _XMLParser; }
            set { _XMLParser = value; }
        }
        #endregion Attributes

        #region Constructors

        public SbnListObject() : base() { }

        #endregion Constructors

        #region Methods

        public abstract object Clone(string sNodeName);

        public DataSet GetDataSet()
        {
            try
            {
                string strXml = "";
                this.GetXML (null);

                strXml = this.XMLParser.documentElement.xml;
                string s = "<?xml version=\"1.0\" encoding=\"windows-1256\"?>";
                strXml = s + strXml;

                byte[] b = new byte[strXml.Length];
                b = Encoding.Default.GetBytes(strXml);

                System.IO.MemoryStream ms = new System.IO.MemoryStream(b);

                DataSet ds = new DataSet();
                ds.EnforceConstraints = true;

                ds.ReadXml(ms);

                ms.Dispose();

                return ds;
            }
            catch
            {
                throw;
            }

            return null;
        }

        public ISbnObject GetItem(int index)
        {
            try
            {
                if (this.Count > index)
                {
                    return (ISbnObject)this[index];
                }
                return null;
            }
            catch
            {
                throw;
            }
            return null;
        }

        #endregion Methods


        public virtual string GetXML(string sNodeName)
        {
            try
            {
                if(sNodeName == null)
                    this.XMLParser = new XMLParser(this.GetType().ToString());
                else
                this.XMLParser = new XMLParser(sNodeName);

                foreach (object objMember in this)
                {
                    if (_InitialAndSaveMode) ((SbnObject)objMember).Save(_PhysicalPath + "\\" + objMember.GetType().Name + "_" + ((SbnObject)objMember).ID);

                    else ((SbnObject)objMember).GetXML (null);

                    this.XMLParser.AddChildFromNode(((SbnObject)objMember).XMLParser.documentElement, this.XMLParser.documentElement);
                }

                return this.XMLParser.xml ;
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

                this.XMLParser.loadXML(sXML);

                if (this.XMLParser.documentElement == null)
                {
                }

                this.XMLParser.XMLBaseNode = this.XMLParser.documentElement;

                if (this.XMLParser.XMLBaseNode == null)
                {
                }

                if (sNodeName == null)
                {
                    if (((IXMLDOMNode)this.XMLParser.XMLBaseNode).firstChild != null)
                    {
                        sNodeName = ((IXMLDOMNode)this.XMLParser.XMLBaseNode).firstChild.nodeName;
                    }

                }

                bool bNext = false;
                if (((IXMLDOMNode)this.XMLParser.XMLBaseNode).selectSingleNode(sNodeName) != null)
                {
                    this.XMLParser.NextSiblingNode = ((IXMLDOMNode)this.XMLParser.XMLBaseNode).selectSingleNode(sNodeName);

                    bNext = true;

                    PropertyInfo pInfo = this.GetType().GetProperty("Item");
                    ISbnObject sbn = (ISbnObject)Activator.CreateInstance(pInfo.PropertyType);

//                    SbnBinary attachment = new SbnBinary();
                    ((SbnObject) sbn).XMLParser = new XMLParser(sNodeName);
                    ((SbnObject)sbn).XMLParser.XMLBaseNode = ((IXMLDOMNode)this.XMLParser.XMLBaseNode).selectSingleNode(sNodeName);
                    while (bNext)
                    {
                        bNext = false;

                        ((SbnObject)sbn).InitializeFromXML(null, sNodeName, pattern);

                        this.Add((T)sbn);

                        if (this.XMLParser.NextSiblingNode != null)
                        {
                            sbn = (ISbnObject)Activator.CreateInstance(pInfo.PropertyType);
                            ((SbnObject)sbn).XMLParser = new XMLParser(sNodeName);
                            ((SbnObject)sbn).XMLParser.XMLBaseNode = this.XMLParser.NextSiblingNode;
                            this.XMLParser.NextSiblingNode = this.XMLParser.NextSiblingNode;
                            bNext = true;
                        }
                    }
                }


                return;
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
                if (PhysicalPath == null)
                {
                    string sLocation = GetType().Assembly.Location.ToLower().Replace("\\" + GetType().Module.ToString().ToLower(), "");

                    _PhysicalPath = sLocation + "\\" + GetType().Name;

                    //this._InitialAndSaveMode = true;

                    foreach (object objMember in this)
                    {
                        ((SbnObject)objMember).GetXML(null);
                        ((SbnObject)objMember).XMLParser.Save(_PhysicalPath, ((SbnObject)objMember).ID + ".xml");
                    }
                }
                else
                {
                    string sLocation = PhysicalPath;

                    _PhysicalPath = sLocation;

                    foreach (object objMember in this)
                    {
                        ((SbnObject)objMember).GetXML(null);
                        ((SbnObject)objMember).XMLParser.Save(_PhysicalPath, ((SbnObject)objMember).ID + ".xml");
                    }
                }
            }
            catch
            {
                throw;
            }
            return;
        }

        public virtual void Save(string PhysicalPath)
        {
            try
            {
                if (PhysicalPath == null)
                {
                    string sLocation = GetType().Assembly.Location.ToLower().Replace("\\" + GetType().Module.ToString().ToLower(), "");

                    _PhysicalPath = sLocation + "\\" + GetType().Name;

                    this._InitialAndSaveMode = true;

                    this.GetXML (null);

                    return;

                }
                else
                {
                    string sLocation = PhysicalPath ;

                    _PhysicalPath = sLocation;

                    this._InitialAndSaveMode = true;

                    this.GetXML (null);

                    return;
                }
            }
            catch
            {
                throw;
            }
            return;
        }

        public virtual void Load(string PhysicalPath, List<string> CustomAttributes)
        {
            _PhysicalPath = PhysicalPath;
            try
            {
                foreach (string sDirName in System.IO.Directory.GetDirectories(PhysicalPath))
                {
                    try
                    {
                        PropertyInfo pInfo =  this.GetType().GetProperty("Item");
                            ISbnObject sbn = (ISbnObject)Activator.CreateInstance(pInfo.PropertyType );
                        sbn.Load(sDirName, CustomAttributes);
                        this.Add((T)sbn);

                    }
                    catch (Exception ex)
                    {

                    }
                    ///((SbnListObject<T>)this).Add(sbn);//.Add((T)sbn);
                }
                return;
            }
            catch(Exception ex)
            {
                Console.Write(PhysicalPath + " " + ex.Message);
                throw;
            }
            return;
        }

        #region ICustomTypeDescriptor impl

        public String GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public String GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }


        ///// <summary>
        ///// Called to get the properties of this type. Returns properties with certain
        ///// attributes. this restriction is not implemented here.
        ///// </summary>
        ///// <param name="attributes"></param>
        ///// <returns></returns>
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return GetProperties();
        }

        ///// <summary>
        ///// Called to get the properties of this type.
        ///// </summary>
        ///// <returns></returns>
        public PropertyDescriptorCollection GetProperties()
        {

            PropertyDescriptorCollection Properties = new PropertyDescriptorCollection(null);

            // Iterate the list of employees
            for (int i = 0; i < this.Count; i++)
            {

                SbnListPropertyDescriptorCollection pd = new SbnListPropertyDescriptorCollection((ISbnObject )this , this[i] , i);


                Properties.Add(pd);

            }

            return Properties;
        }

        #endregion



        public virtual void Initialize()
        {
            return;
        }

    }

    public class PropertyComparer<T> : IComparer<T>
    {
        private PropertyInfo property;
        private ListSortDirection sortDirection;

        public PropertyComparer(PropertyDescriptor sortProperty, ListSortDirection sortDirection)
        {
            property = typeof(T).GetProperty(sortProperty.Name);

            this.sortDirection = sortDirection;
        }

        public int Compare(T x, T y)
        {
            object valueX = property.GetValue(x, null);
            object valueY = property.GetValue(y, null);

            if (sortDirection == ListSortDirection.Ascending)
            {
                return Comparer.Default.Compare(valueX, valueY);
            }
            else
            {
                return Comparer.Default.Compare(valueY, valueX);
            }
        }
    }


}
