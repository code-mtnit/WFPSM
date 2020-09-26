using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
using MSXML2;
using Sbn.Core;
using Sbn.Systems.OPS;
using Sbn.Controls.Imaging;
using Sbn.Systems.WMC;
using Sbn.Systems.WMC.WMCObject;
using Sbn.Products.GAP.GAPObject;
namespace Sbn.Products.GEP.GEPObject
{
    [Description("احکام")]
    [DisplayName("احکام")]
    [ObjectCode("9306")]
    [SystemName("GEP")]
    [ItemsType("Sbn.Products.GEP.GEPObject.Precepts")]
    [Serializable]
    public class Precept : SbnObject
    {
        public Precept()
            : base()
        {
        }
        public Precept(SbnObject InitialObject)
            : base(InitialObject)
        {
        }
        private OrgUnits _CoOrgans;
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        [DisplayName("")]
        [Category("")]
        [DocumentAttributeID("27258")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("OrgUnits")]
        [IsMiddleTableExist("False")]
        [RelationTable("Precept_Organ_M")]
        public OrgUnits CoOrgans
        {
            get { return _CoOrgans; }
            set { _CoOrgans = value; }
        }
        private ApprovalLetter _CoResolution;
        /// <summary>
        /// مصوبه مرتبط
        /// </summary>
        [Description("مصوبه مرتبط")]
        [DisplayName("مصوبه مرتبط")]
        [Category("")]
        [DocumentAttributeID("27259")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("ApprovalLetter")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public ApprovalLetter CoResolution
        {
            get { return _CoResolution; }
            set { _CoResolution = value; }
        }
        private BasicInfoDetail _PreceptType;
        /// <summary>
        /// نوع حکم
        /// </summary>
        [Description("نوع حکم")]
        [DisplayName("نوع حکم")]
        [Category("")]
        [DocumentAttributeID("27260")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("BasicInfoDetail")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public BasicInfoDetail PreceptType
        {
            get { return _PreceptType; }
            set { _PreceptType = value; }
        }
        private Pursuits _Persuits;
        /// <summary>
        /// پیگیریها
        /// </summary>
        [Description("پیگیریها")]
        [DisplayName("پیگیریها")]
        [Category("")]
        [DocumentAttributeID("27273")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Pursuits")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Pursuits Persuits
        {
            get { return _Persuits; }
            set { _Persuits = value; }
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override void Initialize()
        {
            base.Initialize();
            this._CoOrgans = new OrgUnits();
            this._CoResolution = new ApprovalLetter();
            this._PreceptType = new BasicInfoDetail();
            this._Persuits = new Pursuits();
        }
        public override SbnObject Clone(string sNodeName)
        {
            Precept retObject = new Precept(this);
            if (!object.ReferenceEquals(this.CoOrgans, null))
                retObject.CoOrgans = (OrgUnits)this.CoOrgans.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoResolution, null))
                retObject.CoResolution = (ApprovalLetter)this.CoResolution.Clone(sNodeName);
            if (!object.ReferenceEquals(this.PreceptType, null))
                retObject.PreceptType = (BasicInfoDetail)this.PreceptType.Clone(sNodeName);
            if (!object.ReferenceEquals(this.Persuits, null))
                retObject.Persuits = (Pursuits)this.Persuits.Clone(sNodeName);
            return retObject;
        }
        public static string at_CoOrgansID
        {
            get
            {
                return "Precept.CoOrgansID";
            }
        }
        public static string at_CoOrgansTitle
        {
            get
            {
                return "Precept.CoOrgans.Title";
            }
        }
        public static string at_CoOrgansFirstLevelAttributes
        {
            get
            {
                return "Precept.CoOrgansFirstLevelAttributes";
            }
        }
        public static string at_CoResolutionID
        {
            get
            {
                return "Precept.CoResolutionID";
            }
        }
        public static string at_CoResolutionTitle
        {
            get
            {
                return "Precept.CoResolution.Title";
            }
        }
        public static string at_CoResolutionFirstLevelAttributes
        {
            get
            {
                return "Precept.CoResolutionFirstLevelAttributes";
            }
        }
        public static string at_CoResolution_Duration
        {
            get
            {
                return "Precept.CoResolution.Duration";
            }
        }
        public static string at_CoResolution_ResultText
        {
            get
            {
                return "Precept.CoResolution.ResultText";
            }
        }
        public static string at_CoResolution_CorrelateLetterFirstLevelAttributes
        {
            get
            {
                return "Precept.CoResolution.CorrelateLetterFirstLevelAttributes";
            }
        }
        public static string at_CoResolution_ApprovalTypeFirstLevelAttributes
        {
            get
            {
                return "Precept.CoResolution.ApprovalTypeFirstLevelAttributes";
            }
        }
        public static string at_CoResolution_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "Precept.CoResolution.CorrelateOfferFirstLevelAttributes";
            }
        }
        public static string at_CoResolution_CorrelateSessionFirstLevelAttributes
        {
            get
            {
                return "Precept.CoResolution.CorrelateSessionFirstLevelAttributes";
            }
        }
        public static string at_CoResolution_AnnotationPicturesFirstLevelAttributes
        {
            get
            {
                return "Precept.CoResolution.AnnotationPicturesFirstLevelAttributes";
            }
        }
        public static string at_CoResolution_AgainstCommResultTypeFirstLevelAttributes
        {
            get
            {
                return "Precept.CoResolution.AgainstCommResultTypeFirstLevelAttributes";
            }
        }
        public static string at_CoResolution_CorrelateCommSessionFirstLevelAttributes
        {
            get
            {
                return "Precept.CoResolution.CorrelateCommSessionFirstLevelAttributes";
            }
        }
        public static string at_CoResolution_PursuitsFirstLevelAttributes
        {
            get
            {
                return "Precept.CoResolution.PursuitsFirstLevelAttributes";
            }
        }
        public static string at_CoResolution_WordDocFirstLevelAttributes
        {
            get
            {
                return "Precept.CoResolution.WordDocFirstLevelAttributes";
            }
        }
        public static string at_CoResolution_LegalityTypeFirstLevelAttributes
        {
            get
            {
                return "Precept.CoResolution.LegalityTypeFirstLevelAttributes";
            }
        }
        public static string at_CoResolution_OtherLettersFirstLevelAttributes
        {
            get
            {
                return "Precept.CoResolution.OtherLettersFirstLevelAttributes";
            }
        }
        public static string at_CoResolution_PreceptsFirstLevelAttributes
        {
            get
            {
                return "Precept.CoResolution.PreceptsFirstLevelAttributes";
            }
        }
        public static string at_CoResolution_CoIllegalApprovalFirstLevelAttributes
        {
            get
            {
                return "Precept.CoResolution.CoIllegalApprovalFirstLevelAttributes";
            }
        }
        public static string at_PreceptTypeID
        {
            get
            {
                return "Precept.PreceptTypeID";
            }
        }
        public static string at_PreceptTypeTitle
        {
            get
            {
                return "Precept.PreceptType.Title";
            }
        }
        public static string at_PreceptTypeFirstLevelAttributes
        {
            get
            {
                return "Precept.PreceptTypeFirstLevelAttributes";
            }
        }
        public static string at_PreceptType_OrderInList
        {
            get
            {
                return "Precept.PreceptType.OrderInList";
            }
        }
        public static string at_PreceptType_ParentFirstLevelAttributes
        {
            get
            {
                return "Precept.PreceptType.ParentFirstLevelAttributes";
            }
        }
        public static string at_PersuitsID
        {
            get
            {
                return "Precept.PersuitsID";
            }
        }
        public static string at_PersuitsTitle
        {
            get
            {
                return "Precept.Persuits.Title";
            }
        }
        public static string at_PersuitsFirstLevelAttributes
        {
            get
            {
                return "Precept.PersuitsFirstLevelAttributes";
            }
        }
    }
}
