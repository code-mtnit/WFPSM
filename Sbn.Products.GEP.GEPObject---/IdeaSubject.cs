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
    public enum IdeaSubjectType
    {
        [Description("")]
        Free,
        Offer
    }

    [Description("موضوع نظر")]
    [DisplayName("موضوع نظر")]
    [ObjectCode("")]
    [SystemName("GEP")]
    [ItemsType("Sbn.Products.GEP.GEPObject.IdeaSubject")]
    [Serializable]
    public class IdeaSubject : SbnObject
    {
        public IdeaSubject() { }

        public IdeaSubject(SbnObject InitialObject) : base(InitialObject) { }

        public override void Initialize()
        {
            base.Initialize();
            this._correlateOffer = new Offer();
            this._coWorker = new Worker();
        }

        public override SbnObject Clone(string sNodeName)
        {
            IdeaSubject retObject = new IdeaSubject(this);
            retObject.CorrelateOffer = (Offer)this.CorrelateOffer.Clone(sNodeName);
            retObject.CoWorker = (Worker)this.CoWorker.Clone(sNodeName);
            return retObject;
        }

        IdeaSubjectType _ideaSubjectType;
        Offer _correlateOffer;
        Worker _coWorker;

        /// <summary>
        /// نوع نظر
        /// </summary>
        [Description("نوع نظر")]
        [DisplayName("نوع نظر")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("IdeaSubjectType")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public IdeaSubjectType IdeaSubjectType { get { return _ideaSubjectType; } set { _ideaSubjectType = value; } }

        /// <summary>
        /// پوشه مرتبط
        /// </summary>
        [Description("پوشه مرتبط")]
        [DisplayName("پوشه مرتبط")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Offer")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Offer CorrelateOffer { get { return _correlateOffer; } set { _correlateOffer = value; } }

        /// <summary>
        /// شخص ایجاد کننده
        /// </summary>
        [Description("شخص ایجاد کننده")]
        [DisplayName("شخص ایجاد کننده")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Worker")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Worker CoWorker { get { return _coWorker; } set { _coWorker = value; } }

        public static string at_IdeaSubjectType
        {
            get
            {
                return "IdeaSubject.IdeaSubjectType";
            }
        }

        public static string at_CorrelateOfferID
        {
            get
            {
                return "IdeaSubject.CorrelateOfferID";
            }
        }

        public static string at_CoWorkerID
        {
            get
            {
                return "IdeaSubject.CoWorkerID";
            }
        }
    }
}
