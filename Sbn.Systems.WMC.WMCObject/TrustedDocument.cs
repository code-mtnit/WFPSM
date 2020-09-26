using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
using Sbn.Core;
namespace Sbn.Systems.WMC.WMCObject
{
    [Description("اسنادي كه بدون ملاحظه سطح دسترسي در اختيار كارمند قرار مي گيرد")]
    [DisplayName("اسنادي كه بدون ملاحظه سطح دسترسي در اختيار كارمند قرار مي گيرد")]
    [ObjectCode("2071")]
    [SystemName("WMC")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.TrustedDocuments")]
    [Serializable]
    public class TrustedDocument : SbnObject
    {
        public TrustedDocument()
            : base()
        {
        }
        public TrustedDocument(SbnObject InitialObject)
            : base(InitialObject)
        {
        }
        private string _StartAccountDate;
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        [DisplayName("")]
        [Category("")]
        [DocumentAttributeID("27133")]
        [IsRelationalAttribute("false")]
        [AttributeType("DateString")]
        [Browsable(true)]
        public string StartAccountDate
        {
            get { return _StartAccountDate; }
            set { _StartAccountDate = value; }
        }
        private string _EndAccountDate;
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        [DisplayName("")]
        [Category("")]
        [DocumentAttributeID("27134")]
        [IsRelationalAttribute("false")]
        [AttributeType("DateString")]
        [Browsable(true)]
        public string EndAccountDate
        {
            get { return _EndAccountDate; }
            set { _EndAccountDate = value; }
        }
        private Worker _CoWorker;
        /// <summary>
        /// کارمند مورد نظر
        /// </summary>
        [Description("کارمند مورد نظر")]
        [DisplayName("کارمند")]
        [Category("")]
        [DocumentAttributeID("2123")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Worker")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Worker CoWorker
        {
            get { return _CoWorker; }
            set { _CoWorker = value; }
        }
        private Document _CoDocument;
        /// <summary>
        /// سند مورد نظر
        /// </summary>
        [Description("سند مورد نظر")]
        [DisplayName("سند")]
        [Category("")]
        [DocumentAttributeID("2124")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Document")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Document CoDocument
        {
            get { return _CoDocument; }
            set { _CoDocument = value; }
        }
        private OrgUnit _CoOrgUnit;
        /// <summary>
        /// ساختار
        /// </summary>
        [Description("ساختار")]
        [DisplayName("سازختار")]
        [Category("")]
        [DocumentAttributeID("27512")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("OrgUnit")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public OrgUnit CoOrgUnit
        {
            get { return _CoOrgUnit; }
            set { _CoOrgUnit = value; }
        }
        private DocumentType _CoDocumentType;
        /// <summary>
        /// نوع سند
        /// </summary>
        [Description("نوع سند")]
        [DisplayName("نوع سند")]
        [Category("")]
        [DocumentAttributeID("27513")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("DocumentType")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public DocumentType CoDocumentType
        {
            get { return _CoDocumentType; }
            set { _CoDocumentType = value; }
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override void Initialize()
        {
            base.Initialize();
            this._StartAccountDate = "";
            this._EndAccountDate = "";
            this._CoWorker = new Worker();
            this._CoDocument = new Document();
            this._CoOrgUnit = new OrgUnit();
            this._CoDocumentType = new DocumentType();
        }
        public override SbnObject Clone(string sNodeName)
        {
            TrustedDocument retObject = new TrustedDocument(this);
            if (this._StartAccountDate != null) retObject.StartAccountDate = (string)this._StartAccountDate.Clone();
            if (this._EndAccountDate != null) retObject.EndAccountDate = (string)this._EndAccountDate.Clone();
            if (!object.ReferenceEquals(this.CoWorker, null))
                retObject.CoWorker = (Worker)this.CoWorker.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoDocument, null))
                retObject.CoDocument = (Document)this.CoDocument.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoOrgUnit, null))
                retObject.CoOrgUnit = (OrgUnit)this.CoOrgUnit.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoDocumentType, null))
                retObject.CoDocumentType = (DocumentType)this.CoDocumentType.Clone(sNodeName);
            return retObject;
        }
        public static string at_StartAccountDate
        {
            get
            {
                return "TrustedDocument.StartAccountDate";
            }
        }
        public static string at_EndAccountDate
        {
            get
            {
                return "TrustedDocument.EndAccountDate";
            }
        }
        public static string at_CoWorkerID
        {
            get
            {
                return "TrustedDocument.CoWorkerID";
            }
        }
        public static string at_CoWorkerTitle
        {
            get
            {
                return "TrustedDocument.CoWorker.Title";
            }
        }
        public static string at_CoWorkerFirstLevelAttributes
        {
            get
            {
                return "TrustedDocument.CoWorkerFirstLevelAttributes";
            }
        }
        public static string at_CoWorker_StartWorkDate
        {
            get
            {
                return "TrustedDocument.CoWorker.StartWorkDate";
            }
        }
        public static string at_CoWorker_EndWorkDate
        {
            get
            {
                return "TrustedDocument.CoWorker.EndWorkDate";
            }
        }
        public static string at_CoWorker_IconStream
        {
            get
            {
                return "TrustedDocument.CoWorker.IconStream";
            }
        }
        public static string at_CoWorker_CoPositionFirstLevelAttributes
        {
            get
            {
                return "TrustedDocument.CoWorker.CoPositionFirstLevelAttributes";
            }
        }
        public static string at_CoWorker_RestrictionsFirstLevelAttributes
        {
            get
            {
                return "TrustedDocument.CoWorker.RestrictionsFirstLevelAttributes";
            }
        }
        public static string at_CoWorker_CoPersonFirstLevelAttributes
        {
            get
            {
                return "TrustedDocument.CoWorker.CoPersonFirstLevelAttributes";
            }
        }
        public static string at_CoWorker_AccessrightsFirstLevelAttributes
        {
            get
            {
                return "TrustedDocument.CoWorker.AccessrightsFirstLevelAttributes";
            }
        }
        public static string at_CoWorker_WorkerJobFirstLevelAttributes
        {
            get
            {
                return "TrustedDocument.CoWorker.WorkerJobFirstLevelAttributes";
            }
        }
        public static string at_CoWorker_CoRolesFirstLevelAttributes
        {
            get
            {
                return "TrustedDocument.CoWorker.CoRolesFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentID
        {
            get
            {
                return "TrustedDocument.CoDocumentID";
            }
        }
        public static string at_CoDocumentTitle
        {
            get
            {
                return "TrustedDocument.CoDocument.Title";
            }
        }
        public static string at_CoDocumentFirstLevelAttributes
        {
            get
            {
                return "TrustedDocument.CoDocumentFirstLevelAttributes";
            }
        }
        public static string at_CoDocument_BusinessDocumentCode
        {
            get
            {
                return "TrustedDocument.CoDocument.BusinessDocumentCode";
            }
        }
        public static string at_CoDocument_AttributeValuesFirstLevelAttributes
        {
            get
            {
                return "TrustedDocument.CoDocument.AttributeValuesFirstLevelAttributes";
            }
        }
        public static string at_CoDocument_DocumentTypeFirstLevelAttributes
        {
            get
            {
                return "TrustedDocument.CoDocument.DocumentTypeFirstLevelAttributes";
            }
        }
        public static string at_CoDocument_ActivitiesFirstLevelAttributes
        {
            get
            {
                return "TrustedDocument.CoDocument.ActivitiesFirstLevelAttributes";
            }
        }
        public static string at_CoDocument_OwnerOrganFirstLevelAttributes
        {
            get
            {
                return "TrustedDocument.CoDocument.OwnerOrganFirstLevelAttributes";
            }
        }
        public static string at_CoDocument_CreatorPersonFirstLevelAttributes
        {
            get
            {
                return "TrustedDocument.CoDocument.CreatorPersonFirstLevelAttributes";
            }
        }
        public static string at_CoOrgUnitID
        {
            get
            {
                return "TrustedDocument.CoOrgUnitID";
            }
        }
        public static string at_CoOrgUnitTitle
        {
            get
            {
                return "TrustedDocument.CoOrgUnit.Title";
            }
        }
        public static string at_CoOrgUnitFirstLevelAttributes
        {
            get
            {
                return "TrustedDocument.CoOrgUnitFirstLevelAttributes";
            }
        }
        public static string at_CoOrgUnit_UnitPath
        {
            get
            {
                return "TrustedDocument.CoOrgUnit.UnitPath";
            }
        }
        public static string at_CoOrgUnit_ExpireDate
        {
            get
            {
                return "TrustedDocument.CoOrgUnit.ExpireDate";
            }
        }
        public static string at_CoOrgUnit_BuildingLocationFirstLevelAttributes
        {
            get
            {
                return "TrustedDocument.CoOrgUnit.BuildingLocationFirstLevelAttributes";
            }
        }
        public static string at_CoOrgUnit_ChildUnitsFirstLevelAttributes
        {
            get
            {
                return "TrustedDocument.CoOrgUnit.ChildUnitsFirstLevelAttributes";
            }
        }
        public static string at_CoOrgUnit_ParentUnitFirstLevelAttributes
        {
            get
            {
                return "TrustedDocument.CoOrgUnit.ParentUnitFirstLevelAttributes";
            }
        }
        public static string at_CoOrgUnit_PositionsFirstLevelAttributes
        {
            get
            {
                return "TrustedDocument.CoOrgUnit.PositionsFirstLevelAttributes";
            }
        }
        public static string at_CoOrgUnit_MergedUnitFirstLevelAttributes
        {
            get
            {
                return "TrustedDocument.CoOrgUnit.MergedUnitFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentTypeID
        {
            get
            {
                return "TrustedDocument.CoDocumentTypeID";
            }
        }
        public static string at_CoDocumentTypeTitle
        {
            get
            {
                return "TrustedDocument.CoDocumentType.Title";
            }
        }
        public static string at_CoDocumentTypeFirstLevelAttributes
        {
            get
            {
                return "TrustedDocument.CoDocumentTypeFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentType_ObjectNameSpace
        {
            get
            {
                return "TrustedDocument.CoDocumentType.ObjectNameSpace";
            }
        }
        public static string at_CoDocumentType_IconStream
        {
            get
            {
                return "TrustedDocument.CoDocumentType.IconStream";
            }
        }
        public static string at_CoDocumentType_ObjectName
        {
            get
            {
                return "TrustedDocument.CoDocumentType.ObjectName";
            }
        }
        public static string at_CoDocumentType_PictureFirstLevelAttributes
        {
            get
            {
                return "TrustedDocument.CoDocumentType.PictureFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentType_PropertiesFirstLevelAttributes
        {
            get
            {
                return "TrustedDocument.CoDocumentType.PropertiesFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentType_SubSystemFirstLevelAttributes
        {
            get
            {
                return "TrustedDocument.CoDocumentType.SubSystemFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentType_CoDefaultUIFirstLevelAttributes
        {
            get
            {
                return "TrustedDocument.CoDocumentType.CoDefaultUIFirstLevelAttributes";
            }
        }
    }
}
