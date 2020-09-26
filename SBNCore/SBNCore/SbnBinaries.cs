using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sbn.Libs.XMLPareser;

namespace Sbn.Core
{
    [Serializable]
    public class SbnBinaries : SbnListObject<SbnBinary>
    {
        #region Constructors

        public SbnBinaries()
            : base()
        {

        }

        #endregion Constructors

        public override object  Clone(string sNodeName)
        {
            SbnBinaries Col = new  SbnBinaries ();

            foreach (SbnBinary objMember in this)
            {
                Col.Add((SbnBinary)objMember.Clone(sNodeName));
            }

            return Col;

        }


        #region xmlParser Implementation

        //public override void InitializeFromXML(string sXML, string sNodeName)
        //{
        //    try
        //    {
        //        base.InitializeFromXML(sXML, sNodeName);

        //        bool bNext = false;
        //        if (this.XMLParser.XMLBaseNode.selectSingleNode(sNodeName) != null)
        //        {
        //            this.XMLParser.NextSiblingNode = this.XMLParser.XMLBaseNode.selectSingleNode(sNodeName);

        //            bNext = true;
        //            SbnBinary attachment = new SbnBinary();
        //            attachment.XMLParser = new XMLParser(sNodeName);
        //            attachment.XMLParser.XMLBaseNode = this.XMLParser.XMLBaseNode.selectSingleNode(sNodeName);
        //            while (bNext)
        //            {
        //                bNext = false;

        //                attachment.InitializeFromXML (null , sNodeName);
        //                this.Add(attachment);

        //                if (this.XMLParser.NextSiblingNode != null)
        //                {
        //                    attachment = new SbnBinary();
        //                    attachment.XMLParser = new XMLParser(sNodeName);
        //                    attachment.XMLParser.XMLBaseNode = this.XMLParser.NextSiblingNode;
        //                    this.XMLParser.NextSiblingNode = this.XMLParser.NextSiblingNode;
        //                    bNext = true;
        //                }
        //            }
        //        }

        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        #endregion xmlParser Implementation

        //public override void Load(string PhysicalPath, List<string> CustomAttributes)
        //{
        //    _PhysicalPath = PhysicalPath;
        //    try
        //    {
        //        foreach (string sDirName in System.IO.Directory.GetDirectories(PhysicalPath))
        //        {

        //            SbnBinary att = new SbnBinary();
        //            att.Load(sDirName, CustomAttributes );
        //            this.Add(att);

        //        }
        //        return ;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return ;
        //}


        /*
                #region Sort

                private string _propertyName;
                private bool _ascending;

                public override void Sort(string propertyName, bool ascending)
                {
                    try
                    {

                        if (_propertyName == propertyName && _ascending == ascending)
                            _ascending = !ascending;
                        //Else, new properties are set with the new values
                        else
                        {
                            _propertyName = propertyName;
                            _ascending = ascending;
                        }



                        PropertyDescriptorCollection properties
                                                = TypeDescriptor.GetProperties(typeof(Attachment));

                        PropertyDescriptor propertyDesc = properties.Find(propertyName, true);


                        // Apply and set the sort, if items to sort


                        PropertyComparer<Attachment> pc = new PropertyComparer<Attachment>(propertyDesc,
                                  (_ascending) ? ListSortDirection.Ascending :
                                   ListSortDirection.Descending);
                        this.Sort(pc);
                    }
                    catch
                    {
                        throw;
                    }
                }



                #endregion Sort
                */

        
    }
}
