using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSXML2;
using System.Runtime.Serialization;

namespace Sbn.Libs.XMLPareser
{
    public class XMLParser 
    {
        #region Attributes

        DOMDocument _root = new DOMDocument();

        private object m_XMLNode;
        private object m_SiblingNode;

        public object NextSiblingNode
        {
            get
            {
                if (m_SiblingNode != null)
                {
                    return ((IXMLDOMNode)m_SiblingNode).nextSibling;
                }
                return null;
            }
            set { m_SiblingNode = (IXMLDOMNode)value; }
        }

        public IXMLDOMNode firstChild
        {
            get { return _root.firstChild ; }
        }
        

        public object XMLBaseNode
        {
            get { return m_XMLNode; }
            set { m_XMLNode = (IXMLDOMNode)value; }
        }

        public string xml
        {
            get { return _root.xml ; }
        }
        
        public IXMLDOMElement documentElement
        {
            get { return _root.documentElement; }
        }


        #endregion Attributes

        #region Constructors

        public XMLParser(string BaseNode, string Encoding)
        {
            try
            {
                IXMLDOMNode oNode = _root.createProcessingInstruction("xml", "version='1.0' encoding='" + Encoding + "'");
                oNode = _root.insertBefore(oNode, _root.childNodes[0]);

                IXMLDOMElement oRoot = _root.createElement(BaseNode);
                _root.documentElement = oRoot;
            }
            catch
            {
                throw;
            }
            return;
        }

        public XMLParser(string BaseNode)
        {
            try
            {

                IXMLDOMNode oNode = _root.createProcessingInstruction("xml", "version='1.0' encoding='windows-1256'");
                oNode = _root.insertBefore(oNode, _root.childNodes[0]);

                IXMLDOMElement oRoot = _root.createElement(BaseNode);
                _root.documentElement = oRoot;
            }
            catch
            {
               
                    throw;

            }
            return;

        }

        public XMLParser()
        {

        }

        ~XMLParser()
        {
            
            _root = null;
        }

        #endregion Constructors


        #region Methods

        public void loadXML(string sXML)
        {
            try
            {
                _root.loadXML(sXML);

            }
            catch
            {
                throw;
            }
        }
        public void load(string sXMLPath)
        {
            try
            {
                _root.load(sXMLPath);

            }
            catch
            {
                throw;
            }
        }

        

        public IXMLDOMNode GetNode(IXMLDOMNode xnodCurrentNode, int nodeIndex)
        {
            try
            {
                if (xnodCurrentNode != null)
                {
                    IXMLDOMNode xnodSelected = xnodCurrentNode.childNodes[nodeIndex];
                    if (xnodSelected != null)
                    {
                        return xnodSelected;
                    }
                }
                else
                    throw new Exception("XMLParser : CurrentNode is null");
            }
            catch
            {
                throw;

            }

            return null;
        }

        public IXMLDOMNode GetNode(IXMLDOMNode xnodCurrentNode, string sNodename)
        {
            try
            {
                if (xnodCurrentNode != null)
                {
                    IXMLDOMNode xnodSelected = xnodCurrentNode.selectSingleNode(sNodename);
                    if (xnodSelected != null)
                    {
                        return xnodSelected;
                    }
                }
                else
                    throw new Exception("XMLParser : CurrentNode is null");
            }
            catch
            {
                throw;

            }

            return null;
        }

        public string GetAttributeValue(IXMLDOMElement xnodCurrentNode, int iIndex)
        {
            try
            {
                return xnodCurrentNode.attributes[iIndex].text;

            }
            catch
            {
                throw;

            }
            return null;
        }

        public string GetNodeValue(IXMLDOMNode xnodCurrentNode, string sNodename, bool bHasNext)
        {
            try
            {
                string sValue = null;

                if (xnodCurrentNode == null) throw new Exception("xnodCurrentNode == null");

                IXMLDOMNode xnodSelected = xnodCurrentNode.selectSingleNode(sNodename);
                if (xnodSelected != null)
                {
                    sValue = xnodSelected.text;

                    xnodSelected = xnodSelected.nextSibling;

                    if (xnodSelected != null)
                    {
                        bHasNext = true;
                    }

                    return sValue;
                }

                return null;
            }
            catch
            {
                throw;
            }

            return null;
        }

        public IXMLDOMNode AddChildFromString(string newNodeName, string Value, IXMLDOMNode Parent)
        {
            try
            {
                IXMLDOMNode xnodReturn = _root.createElement(newNodeName);

                xnodReturn.text = Value;

                Parent.appendChild(xnodReturn);

                return xnodReturn;
            }
            catch
            {
                throw;

            }
            return null;
        }

        public IXMLDOMNode AddChildFromBinary(string newNodeName, byte[] bValue, IXMLDOMNode Parent)
        {
            try
            {
                IXMLDOMNode xnodReturn = _root.createElement(newNodeName);
                xnodReturn.set_dataType("bin.Base64");

                xnodReturn.nodeTypedValue = bValue;

                Parent.appendChild(xnodReturn);

                return xnodReturn;
            }
            catch
            {
                throw;

            }
            return null;
        }

        public IXMLDOMNode AddChildFromNode(IXMLDOMNode newNode, IXMLDOMNode Parent)
        {
            try
            {
                IXMLDOMElement xnod = _root.createElement(newNode.nodeName);

                DOMDocument doc = new DOMDocument();

                doc.loadXML(newNode.xml);
                IXMLDOMNode xnodReturn = Parent.appendChild(doc.documentElement);

                return xnodReturn;
            }
            catch
            {
                throw;

            }
            return null;
        }

        public void AddAttribute(string newAttributeName, string Value, IXMLDOMElement Parent)
        {
            try
            {

                Parent.setAttribute(newAttributeName, Value);

                return;
            }
            catch
            {
                throw;

            }

            return;
        }

        public void Save(string PhysicalPath, string FileName)
        {
            try
            {
                if (!System.IO.Directory.Exists(PhysicalPath))
                {
                    System.IO.Directory.CreateDirectory(PhysicalPath);
                }

                _root.save(PhysicalPath + "\\" + FileName);

                return;
            }
            catch
            {
                throw;

            }

            return;
        }


        #endregion Methods

    }

}
