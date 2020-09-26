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
[Description("ويژگي سند")]
[DisplayName ("ويژگي سند")]
[ObjectCode ("2015")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.DocumentProperties")]
    [SystemName("WMC")]
[Serializable]

    public class DocumentProperty : SbnObject
    {
        public DocumentProperty()
            : base()
        {
        }
        public DocumentProperty(SbnObject InitialObject)
            : base(InitialObject)
        {
        }
        private string _ValidationPattern;
        /// <summary>
        /// الگوی سنجش درستی داده
        /// </summary>
        [Description("الگوی سنجش درستی داده")]
        [DisplayName("الگوی سنجش")]
        [Category("")]
        [DocumentAttributeID("27202")]
        [IsRelationalAttribute("false")]
        [AttributeType("String")]
        [Browsable(true)]
        public string ValidationPattern
        {
            get { return _ValidationPattern; }
            set { _ValidationPattern = value; }
        }
        private int _OrderInDocument;
        /// <summary>
        /// ترتیب در سند
        /// </summary>
        [Description("ترتیب در سند")]
        [DisplayName("ترتیب در سند")]
        [Category("")]
        [DocumentAttributeID("27162")]
        [IsRelationalAttribute("false")]
        [AttributeType("Int")]
        [Browsable(true)]
        public int OrderInDocument
        {
            get { return _OrderInDocument; }
            set { _OrderInDocument = value; }
        }
        private string _ObjectAttribute;
        /// <summary>
        /// نام ویژگی در شیء
        /// </summary>
        [Description("نام ویژگی در شیء")]
        [DisplayName("نام ویژگی در شیئ")]
        [Category("")]
        [DocumentAttributeID("2060")]
        [IsRelationalAttribute("false")]
        [AttributeType("String")]
        [Browsable(true)]
        public string ObjectAttribute
        {
            get { return _ObjectAttribute; }
            set { _ObjectAttribute = value; }
        }
        private string _ViewCategory;
        /// <summary>
        /// دستبه بندی نمایش در فرم
        /// </summary>
        [Description("دستبه بندی نمایش در فرم")]
        [DisplayName("دستبه بندی نمایش")]
        [Category("")]
        [DocumentAttributeID("27203")]
        [IsRelationalAttribute("false")]
        [AttributeType("String")]
        [Browsable(true)]
        public string ViewCategory
        {
            get { return _ViewCategory; }
            set { _ViewCategory = value; }
        }
        private string _DataEntryMask;
        /// <summary>
        /// قالب ورود داده
        /// </summary>
        [Description("قالب ورود داده")]
        [DisplayName("قالب ورود داده")]
        [Category("")]
        [DocumentAttributeID("27211")]
        [IsRelationalAttribute("false")]
        [AttributeType("String")]
        [Browsable(true)]
        public string DataEntryMask
        {
            get { return _DataEntryMask; }
            set { _DataEntryMask = value; }
        }
        private string _CultureDescription;
        /// <summary>
        /// زبان ورود اطلاعات
        /// </summary>
        [Description("زبان ورود اطلاعات")]
        [DisplayName("زبان ورود اطلاعات")]
        [Category("مشخصات اصلی")]
        [DocumentAttributeID("27213")]
        [IsRelationalAttribute("false")]
        [AttributeType("String")]
        [Browsable(true)]
        public string CultureDescription
        {
            get { return _CultureDescription; }
            set { _CultureDescription = value; }
        }
        private SbnBoolean _IsLimitted = SbnBoolean.OutOfValue;
        /// <summary>
        /// آیا در تعیین محدودیتهای کارمند مشاهده شود
        /// </summary>
        [Description("آیا در تعیین محدودیتهای کارمند مشاهده شود")]
        [DisplayName("دارای سطح محدویت")]
        [Category("")]
        [DocumentAttributeID("2128")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SbnBoolean")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SbnBoolean IsLimitted
        {
            get { return _IsLimitted; }
            set { _IsLimitted = value; }
        }
        private PropertyType _PropertyType = PropertyType.OutOfValue;
        /// <summary>
        /// نوع
        /// </summary>
        [Description("نوع")]
        [DisplayName("نوع")]
        [Category("")]
        [DocumentAttributeID("2019")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("PropertyType")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public PropertyType PropertyType
        {
            get { return _PropertyType; }
            set { _PropertyType = value; }
        }
        private BasicInfo _BasicInfoLink;
        /// <summary>
        /// اطلاعات پایه مرتبط در صورتی که ویژگی از نوع اطلاعات پایه باشد
        /// </summary>
        [Description("اطلاعات پایه مرتبط در صورتی که ویژگی از نوع اطلاعات پایه باشد")]
        [DisplayName("اطلاعات پایه مرتبط")]
        [Category("")]
        [DocumentAttributeID("2022")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("BasicInfo")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public BasicInfo BasicInfoLink
        {
            get { return _BasicInfoLink; }
            set { _BasicInfoLink = value; }
        }
        private BasicInfoDetail _MesurementType;
        /// <summary>
        /// واحد سنجش
        /// </summary>
        [Description("واحد سنجش")]
        [DisplayName("واحد سنجش")]
        [Category("")]
        [DocumentAttributeID("2076")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("BasicInfoDetail")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public BasicInfoDetail MesurementType
        {
            get { return _MesurementType; }
            set { _MesurementType = value; }
        }
        private DocumentType _CoDocumentType;
        /// <summary>
        /// نوع سند مرتبط
        /// </summary>
        [Description("نوع سند مرتبط")]
        [DisplayName("سند مرتبط")]
        [Category("")]
        [DocumentAttributeID("27061")]
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
        private SbnBoolean _IsPreDefine = SbnBoolean.OutOfValue;
        /// <summary>
        /// ویژگی پیش فرض سند
        /// </summary>
        [Description("ویژگی پیش فرض سند")]
        [DisplayName("ویژگی پیش فرض")]
        [Category("")]
        [DocumentAttributeID("2127")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SbnBoolean")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SbnBoolean IsPreDefine
        {
            get { return _IsPreDefine; }
            set { _IsPreDefine = value; }
        }
        private DocumentPropValues _Values;
        /// <summary>
        /// سوابق مربوط به مقدار ویژگی
        /// </summary>
        [Description("سوابق مربوط به مقدار ویژگی")]
        [DisplayName("مقدار ویژگی")]
        [Category("")]
        [DocumentAttributeID("27062")]
        [Browsable(true)]
        [IsRelationalAttribute("True")]
        [AttributeType("DocumentPropValues")]
        [IsMiddleTableExist("True")]
        [RelationTable("")]
        public DocumentPropValues Values
        {
            get { return _Values; }
            set { _Values = value; }
        }
        private SbnBoolean _IsListView = SbnBoolean.OutOfValue;
        /// <summary>
        /// آیا بصورت لیستی از این نوع است یا خیر
        /// </summary>
        [Description("آیا بصورت لیستی از این نوع است یا خیر")]
        [DisplayName("محتوای لیستی")]
        [Category("")]
        [DocumentAttributeID("27214")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SbnBoolean")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SbnBoolean IsListView
        {
            get { return _IsListView; }
            set { _IsListView = value; }
        }
        private DocumentType _ReferenceDocumentType;
        /// <summary>
        /// نوع سند مرجعی که این ویژگی مقادیرش را از آن انتخاب می کند
        /// </summary>
        [Description("نوع سند مرجعی که این ویژگی مقادیرش را از آن انتخاب می کند")]
        [DisplayName("نوع سند مرجع")]
        [Category("مشخصات اصلی")]
        [DocumentAttributeID("27104")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("DocumentType")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public DocumentType ReferenceDocumentType
        {
            get { return _ReferenceDocumentType; }
            set { _ReferenceDocumentType = value; }
        }
        private SbnBoolean _IsVisible = SbnBoolean.OutOfValue;
        /// <summary>
        /// نمایش در فرم ورود اطلاعات
        /// </summary>
        [Description("نمایش در فرم ورود اطلاعات")]
        [DisplayName("قابل نمایش")]
        [Category("")]
        [DocumentAttributeID("27348")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SbnBoolean")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SbnBoolean IsVisible
        {
            get { return _IsVisible; }
            set { _IsVisible = value; }
        }
        private SbnBoolean _IsMandatory = SbnBoolean.OutOfValue;
        /// <summary>
        /// اجباری
        /// </summary>
        [Description("اجباری")]
        [DisplayName("اجباری")]
        [Category("")]
        [DocumentAttributeID("27254")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SbnBoolean")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SbnBoolean IsMandatory
        {
            get { return _IsMandatory; }
            set { _IsMandatory = value; }
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override void Initialize()
        {
            base.Initialize();
            this._ValidationPattern = "";
            this._OrderInDocument = 0;
            this._ObjectAttribute = "";
            this._ViewCategory = "";
            this._DataEntryMask = "";
            this._CultureDescription = "";
            this._IsLimitted = SbnBoolean.OutOfValue;
            this._PropertyType = PropertyType.OutOfValue;
            this._BasicInfoLink = new BasicInfo();
            this._MesurementType = new BasicInfoDetail();
            this._CoDocumentType = new DocumentType();
            this._IsPreDefine = SbnBoolean.OutOfValue;
            this._Values = new DocumentPropValues();
            this._IsListView = SbnBoolean.OutOfValue;
            this._ReferenceDocumentType = new DocumentType();
            this._IsVisible = SbnBoolean.OutOfValue;
            this._IsMandatory = SbnBoolean.OutOfValue;
        }
        public override SbnObject Clone(string sNodeName)
        {
            DocumentProperty retObject = new DocumentProperty();
            retObject.ID = this.ID;
            retObject.ValidationPattern = this._ValidationPattern;
            retObject.OrderInDocument = this._OrderInDocument;
            retObject.ObjectAttribute = this._ObjectAttribute;
            retObject.ViewCategory = this._ViewCategory;
            retObject.DataEntryMask = this._DataEntryMask;
            retObject.CultureDescription = this._CultureDescription;
            retObject.IsLimitted = this.IsLimitted;
            retObject.PropertyType = this.PropertyType;
            if (!object.ReferenceEquals(this.BasicInfoLink, null))
                retObject.BasicInfoLink = (BasicInfo)this.BasicInfoLink.Clone(sNodeName);
            if (!object.ReferenceEquals(this.MesurementType, null))
                retObject.MesurementType = (BasicInfoDetail)this.MesurementType.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoDocumentType, null))
                retObject.CoDocumentType = (DocumentType)this.CoDocumentType.Clone(sNodeName);
            retObject.IsPreDefine = this.IsPreDefine;
            if (!object.ReferenceEquals(this.Values, null))
                retObject.Values = (DocumentPropValues)this.Values.Clone(sNodeName);
            retObject.IsListView = this.IsListView;
            if (!object.ReferenceEquals(this.ReferenceDocumentType, null))
                retObject.ReferenceDocumentType = (DocumentType)this.ReferenceDocumentType.Clone(sNodeName);
            retObject.IsVisible = this.IsVisible;
            retObject.IsMandatory = this.IsMandatory;
            return retObject;
        }
        public static string at_ValidationPattern
        {
            get
            {
                return "DocumentProperty.ValidationPattern";
            }
        }
        public static string at_OrderInDocument
        {
            get
            {
                return "DocumentProperty.OrderInDocument";
            }
        }
        public static string at_ObjectAttribute
        {
            get
            {
                return "DocumentProperty.ObjectAttribute";
            }
        }
        public static string at_ViewCategory
        {
            get
            {
                return "DocumentProperty.ViewCategory";
            }
        }
        public static string at_DataEntryMask
        {
            get
            {
                return "DocumentProperty.DataEntryMask";
            }
        }
        public static string at_CultureDescription
        {
            get
            {
                return "DocumentProperty.CultureDescription";
            }
        }
        public static string at_IsLimitted
        {
            get
            {
                return "DocumentProperty.IsLimitted";
            }
        }
        public static string at_PropertyType
        {
            get
            {
                return "DocumentProperty.PropertyType";
            }
        }
        public static string at_BasicInfoLinkID
        {
            get
            {
                return "DocumentProperty.BasicInfoLinkID";
            }
        }
        public static string at_BasicInfoLinkFirstLevelAttributes
        {
            get
            {
                return "DocumentProperty.BasicInfoLinkFirstLevelAttributes";
            }
        }
        public static string at_BasicInfoLink_DetailsFirstLevelAttributes
        {
            get
            {
                return "DocumentProperty.BasicInfoLink.DetailsFirstLevelAttributes";
            }
        }
        public static string at_BasicInfoLink_SubSystemFirstLevelAttributes
        {
            get
            {
                return "DocumentProperty.BasicInfoLink.SubSystemFirstLevelAttributes";
            }
        }
        public static string at_MesurementTypeID
        {
            get
            {
                return "DocumentProperty.MesurementTypeID";
            }
        }
        public static string at_MesurementTypeFirstLevelAttributes
        {
            get
            {
                return "DocumentProperty.MesurementTypeFirstLevelAttributes";
            }
        }
        public static string at_MesurementType_ParentFirstLevelAttributes
        {
            get
            {
                return "DocumentProperty.MesurementType.ParentFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentTypeID
        {
            get
            {
                return "DocumentProperty.CoDocumentTypeID";
            }
        }
        public static string at_CoDocumentTypeFirstLevelAttributes
        {
            get
            {
                return "DocumentProperty.CoDocumentTypeFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentType_PictureFirstLevelAttributes
        {
            get
            {
                return "DocumentProperty.CoDocumentType.PictureFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentType_PropertiesFirstLevelAttributes
        {
            get
            {
                return "DocumentProperty.CoDocumentType.PropertiesFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentType_SubSystemFirstLevelAttributes
        {
            get
            {
                return "DocumentProperty.CoDocumentType.SubSystemFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentType_CoDefaultUIFirstLevelAttributes
        {
            get
            {
                return "DocumentProperty.CoDocumentType.CoDefaultUIFirstLevelAttributes";
            }
        }
        public static string at_IsPreDefine
        {
            get
            {
                return "DocumentProperty.IsPreDefine";
            }
        }
        public static string at_ValuesID
        {
            get
            {
                return "DocumentProperty.ValuesID";
            }
        }
        public static string at_ValuesFirstLevelAttributes
        {
            get
            {
                return "DocumentProperty.ValuesFirstLevelAttributes";
            }
        }
        public static string at_IsListView
        {
            get
            {
                return "DocumentProperty.IsListView";
            }
        }
        public static string at_ReferenceDocumentTypeID
        {
            get
            {
                return "DocumentProperty.ReferenceDocumentTypeID";
            }
        }
        public static string at_ReferenceDocumentTypeFirstLevelAttributes
        {
            get
            {
                return "DocumentProperty.ReferenceDocumentTypeFirstLevelAttributes";
            }
        }
        public static string at_ReferenceDocumentType_PictureFirstLevelAttributes
        {
            get
            {
                return "DocumentProperty.ReferenceDocumentType.PictureFirstLevelAttributes";
            }
        }
        public static string at_ReferenceDocumentType_PropertiesFirstLevelAttributes
        {
            get
            {
                return "DocumentProperty.ReferenceDocumentType.PropertiesFirstLevelAttributes";
            }
        }
        public static string at_ReferenceDocumentType_SubSystemFirstLevelAttributes
        {
            get
            {
                return "DocumentProperty.ReferenceDocumentType.SubSystemFirstLevelAttributes";
            }
        }
        public static string at_ReferenceDocumentType_CoDefaultUIFirstLevelAttributes
        {
            get
            {
                return "DocumentProperty.ReferenceDocumentType.CoDefaultUIFirstLevelAttributes";
            }
        }
        public static string at_IsVisible
        {
            get
            {
                return "DocumentProperty.IsVisible";
            }
        }
        public static string at_IsMandatory
        {
            get
            {
                return "DocumentProperty.IsMandatory";
            }
        }
    }

}
