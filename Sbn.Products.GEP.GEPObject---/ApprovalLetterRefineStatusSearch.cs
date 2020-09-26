using Sbn.Core;
using Sbn.Libs.AssemblyTools;
using Sbn.Systems.WMC.WMCObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Sbn.Products.GEP.GEPObject
{
    [Description("جستجوی نتایج نهایی تنقیح شده")]
    [DisplayName("جستجوی نتایج نهایی تنقیح شده")]
    [ObjectCode("9068")]
    [SystemName("GEP")]
    [ItemsType("Sbn.Products.GEP.GEPObject.ApprovalLetterRefineStatusSearchs")]
    [Serializable]
    public class ApprovalLetterRefineStatusSearch : SbnObject
    {
        public ApprovalLetterRefineStatusSearch()
            : base()
        {
        }
        public ApprovalLetterRefineStatusSearch(SbnObject InitialObject)
            : base(InitialObject)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
            this.EditorWorker = new Worker();
            this.ApprovalLetter = new ApprovalLetter();
            this.DocumentPropValue = new DocumentPropValue();
            this.DocumentType = new DocumentType();
        }
        public override SbnObject Clone(string sNodeName)
        {
            ApprovalLetterRefineStatusSearch retObject = new ApprovalLetterRefineStatusSearch(this);
            if (!object.ReferenceEquals(this.EditorWorker, null))
                retObject.EditorWorker= (Worker)this.EditorWorker.Clone(sNodeName);
            if (!object.ReferenceEquals(this.ApprovalLetter, null))
                retObject.ApprovalLetter = (ApprovalLetter)this.ApprovalLetter.Clone(sNodeName);
            if (!object.ReferenceEquals(this.DocumentPropValue, null))
                retObject.DocumentPropValue = (DocumentPropValue)this.DocumentPropValue.Clone(sNodeName);
            if (!object.ReferenceEquals(this.DocumentType, null))
                retObject.DocumentType = (DocumentType)this.DocumentType.Clone(sNodeName);

            return retObject;
        }

        private Worker _EditorWorker;
        /// <summary>
        /// کارمند ویرایشگر
        /// </summary>
        [Description("کارمند ویرایشگر")]
        [DisplayName("کارمند")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Worker")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Worker EditorWorker
        {
            get { return _EditorWorker; }
            set { _EditorWorker = value; }
        }
        private DocumentPropValue _DocumentPropValue;
        /// <summary>
        /// مقادير ويژگي انتخاب شده براي سند در حال گردش در سازمان
        /// </summary>
        [Description("مقادير ويژگي انتخاب شده براي سند در حال گردش در سازمان")]
        [DisplayName("مقادير ويژگي انتخاب شده براي سند در حال گردش در سازمان")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("DocumentPropValue")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public DocumentPropValue DocumentPropValue
        {
            get { return _DocumentPropValue; }
            set { _DocumentPropValue = value; }

        }

        private ApprovalLetter _ApprovalLetter;
        /// <summary>
        /// نامه نتيجه نهايي هيات دولت و كميسيونها روي پيشنهاد
        /// </summary>
        [Description("نامه نتيجه نهايي هيات دولت و كميسيونها روي پيشنهاد")]
        [DisplayName("نامه نتيجه نهايي هيات دولت و كميسيونها روي پيشنهاد")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("_ApprovalLetter")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public ApprovalLetter ApprovalLetter
        {
            get { return _ApprovalLetter; }
            set { _ApprovalLetter = value; }
        }
        private DocumentType _DocumentType;
        /// <summary>
        /// نوع سندي كه در گردش كار بين كارمندان جابجا مي شود. هر زير سيستم محدوده كد نمايشي مخصوص خود را دارد.
        /// </summary>
        [Description("نوع سندي كه در گردش كار بين كارمندان جابجا مي شود. هر زير سيستم محدوده كد نمايشي مخصوص خود را دارد.")]
        [DisplayName("نوع سندي كه در گردش كار بين كارمندان جابجا مي شود. هر زير سيستم محدوده كد نمايشي مخصوص خود را دارد.")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("_DocumentType")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public DocumentType DocumentType
        {
            get { return _DocumentType; }
            set { _DocumentType = value; }
        }
        private DocumentProperty _DocumentProperty;
        /// <summary>
        /// 
        /// </summary>
        [Description("DocumentProperty")]
        [DisplayName("DocumentProperty")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("_DocumentProperty")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public DocumentProperty DocumentProperty
        {
            get { return _DocumentProperty; }
            set { _DocumentProperty = value; }
        }
       
        private ApprovalLetterRefineStatusSearch m_LowerObject;
        private ApprovalLetterRefineStatusSearch m_UpperObject;
        private ApprovalLetterRefineStatusSearch m_EqualObject;
        public ApprovalLetterRefineStatusSearch LowerObject
        {
            get { return m_LowerObject; }
            set
            {
                m_LowerObject = value;
            }
        }

        public ApprovalLetterRefineStatusSearch UpperObject
        {
            get { return m_UpperObject; }
            set
            {
                m_UpperObject = value;
            }
        }
        public ApprovalLetterRefineStatusSearch EqualObject
        {
            get { return m_EqualObject; }
            set
            {
                m_EqualObject = value;
            }
        }

    }
}
