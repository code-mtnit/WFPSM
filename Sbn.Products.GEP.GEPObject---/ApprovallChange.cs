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
namespace Sbn.Products.GEP.GEPObject
{
    [Description("تغییرات مصوبه")]
    [DisplayName("تغییرات مصوبه")]
    [ObjectCode("9308")]
    [SystemName("GEP")]
    [ItemsType("Sbn.Products.GEP.GEPObject.ApprovallChanges")]
    [Serializable]
    public class ApprovallChange : SbnObject
    {
        public ApprovallChange()
            : base()
        {
        }
        public ApprovallChange(SbnObject InitialObject)
            : base(InitialObject)
        {
        }
        private ApprovalLetter _CoApprovalLetter;
        /// <summary>
        /// مصوبه مرتبط
        /// </summary>
        [Description("مصوبه مرتبط")]
        [DisplayName("مصوبه مرتبط")]
        [Category("")]
        [DocumentAttributeID("27276")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("ApprovalLetter")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public ApprovalLetter CoApprovalLetter
        {
            get { return _CoApprovalLetter; }
            set { _CoApprovalLetter = value; }
        }
        private ApprovalLetter _CoFinalApproval;
        /// <summary>
        /// مصوبه نهایی
        /// </summary>
        [Description("مصوبه نهایی")]
        [DisplayName("مصوبه نهایی")]
        [Category("")]
        [DocumentAttributeID("27277")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("ApprovalLetter")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public ApprovalLetter CoFinalApproval
        {
            get { return _CoFinalApproval; }
            set { _CoFinalApproval = value; }
        }
        private BasicInfoDetail _ChangeType;
        /// <summary>
        /// نوع تغییر
        /// </summary>
        [Description("نوع تغییر")]
        [DisplayName("نوع تغییر")]
        [Category("")]
        [DocumentAttributeID("27278")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("BasicInfoDetail")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public BasicInfoDetail ChangeType
        {
            get { return _ChangeType; }
            set { _ChangeType = value; }
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override void Initialize()
        {
            base.Initialize();
            this._CoApprovalLetter = new ApprovalLetter();
            this._CoFinalApproval = new ApprovalLetter();
            this._ChangeType = new BasicInfoDetail();
        }
        public override SbnObject Clone(string sNodeName)
        {
            ApprovallChange retObject = new ApprovallChange(this);
            if (!object.ReferenceEquals(this.CoApprovalLetter, null))
                retObject.CoApprovalLetter = (ApprovalLetter)this.CoApprovalLetter.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoFinalApproval, null))
                retObject.CoFinalApproval = (ApprovalLetter)this.CoFinalApproval.Clone(sNodeName);
            if (!object.ReferenceEquals(this.ChangeType, null))
                retObject.ChangeType = (BasicInfoDetail)this.ChangeType.Clone(sNodeName);
            return retObject;
        }
        public static string at_CoApprovalLetterID
        {
            get
            {
                return "ApprovallChange.CoApprovalLetterID";
            }
        }
        public static string at_CoApprovalLetterTitle
        {
            get
            {
                return "ApprovallChange.CoApprovalLetter.Title";
            }
        }
        public static string at_CoApprovalLetterFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.CoApprovalLetterFirstLevelAttributes";
            }
        }
        public static string at_CoApprovalLetter_Duration
        {
            get
            {
                return "ApprovallChange.CoApprovalLetter.Duration";
            }
        }
        public static string at_CoApprovalLetter_ResultText
        {
            get
            {
                return "ApprovallChange.CoApprovalLetter.ResultText";
            }
        }
        public static string at_CoApprovalLetter_CorrelateLetterFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.CoApprovalLetter.CorrelateLetterFirstLevelAttributes";
            }
        }
        public static string at_CoApprovalLetter_ApprovalTypeFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.CoApprovalLetter.ApprovalTypeFirstLevelAttributes";
            }
        }
        public static string at_CoApprovalLetter_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.CoApprovalLetter.CorrelateOfferFirstLevelAttributes";
            }
        }
        public static string at_CoApprovalLetter_CorrelateSessionFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.CoApprovalLetter.CorrelateSessionFirstLevelAttributes";
            }
        }
        public static string at_CoApprovalLetter_AnnotationPicturesFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.CoApprovalLetter.AnnotationPicturesFirstLevelAttributes";
            }
        }
        public static string at_CoApprovalLetter_AgainstCommResultTypeFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.CoApprovalLetter.AgainstCommResultTypeFirstLevelAttributes";
            }
        }
        public static string at_CoApprovalLetter_CorrelateCommSessionFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.CoApprovalLetter.CorrelateCommSessionFirstLevelAttributes";
            }
        }
        public static string at_CoApprovalLetter_PursuitsFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.CoApprovalLetter.PursuitsFirstLevelAttributes";
            }
        }
        public static string at_CoApprovalLetter_WordDocFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.CoApprovalLetter.WordDocFirstLevelAttributes";
            }
        }
        public static string at_CoApprovalLetter_OtherLettersFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.CoApprovalLetter.OtherLettersFirstLevelAttributes";
            }
        }
        public static string at_CoApprovalLetter_PreceptsFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.CoApprovalLetter.PreceptsFirstLevelAttributes";
            }
        }
        public static string at_CoApprovalLetter_ChangesFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.CoApprovalLetter.ChangesFirstLevelAttributes";
            }
        }
        public static string at_CoFinalApprovalID
        {
            get
            {
                return "ApprovallChange.CoFinalApprovalID";
            }
        }
        public static string at_CoFinalApprovalTitle
        {
            get
            {
                return "ApprovallChange.CoFinalApproval.Title";
            }
        }
        public static string at_CoFinalApprovalFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.CoFinalApprovalFirstLevelAttributes";
            }
        }
        public static string at_CoFinalApproval_Duration
        {
            get
            {
                return "ApprovallChange.CoFinalApproval.Duration";
            }
        }
        public static string at_CoFinalApproval_ResultText
        {
            get
            {
                return "ApprovallChange.CoFinalApproval.ResultText";
            }
        }
        public static string at_CoFinalApproval_CorrelateLetterFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.CoFinalApproval.CorrelateLetterFirstLevelAttributes";
            }
        }
        public static string at_CoFinalApproval_ApprovalTypeFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.CoFinalApproval.ApprovalTypeFirstLevelAttributes";
            }
        }
        public static string at_CoFinalApproval_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.CoFinalApproval.CorrelateOfferFirstLevelAttributes";
            }
        }
        public static string at_CoFinalApproval_CorrelateSessionFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.CoFinalApproval.CorrelateSessionFirstLevelAttributes";
            }
        }
        public static string at_CoFinalApproval_AnnotationPicturesFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.CoFinalApproval.AnnotationPicturesFirstLevelAttributes";
            }
        }
        public static string at_CoFinalApproval_AgainstCommResultTypeFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.CoFinalApproval.AgainstCommResultTypeFirstLevelAttributes";
            }
        }
        public static string at_CoFinalApproval_CorrelateCommSessionFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.CoFinalApproval.CorrelateCommSessionFirstLevelAttributes";
            }
        }
        public static string at_CoFinalApproval_PursuitsFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.CoFinalApproval.PursuitsFirstLevelAttributes";
            }
        }
        public static string at_CoFinalApproval_WordDocFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.CoFinalApproval.WordDocFirstLevelAttributes";
            }
        }
        public static string at_CoFinalApproval_OtherLettersFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.CoFinalApproval.OtherLettersFirstLevelAttributes";
            }
        }
        public static string at_CoFinalApproval_PreceptsFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.CoFinalApproval.PreceptsFirstLevelAttributes";
            }
        }
        public static string at_CoFinalApproval_ChangesFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.CoFinalApproval.ChangesFirstLevelAttributes";
            }
        }
        public static string at_ChangeTypeID
        {
            get
            {
                return "ApprovallChange.ChangeTypeID";
            }
        }
        public static string at_ChangeTypeTitle
        {
            get
            {
                return "ApprovallChange.ChangeType.Title";
            }
        }
        public static string at_ChangeTypeFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.ChangeTypeFirstLevelAttributes";
            }
        }
        public static string at_ChangeType_OrderInList
        {
            get
            {
                return "ApprovallChange.ChangeType.OrderInList";
            }
        }
        public static string at_ChangeType_ParentFirstLevelAttributes
        {
            get
            {
                return "ApprovallChange.ChangeType.ParentFirstLevelAttributes";
            }
        }
    }
}
