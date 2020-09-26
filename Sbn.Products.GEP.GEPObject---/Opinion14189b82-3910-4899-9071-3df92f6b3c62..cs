namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description(""), DisplayName(""), ObjectCode("9080"), ItemsType("Sbn.Products.GEP.GEPObject.Opinions")]
    public class Opinion : SbnObject
    {
        private GEPOpinionType _OpinionType;

        public Opinion()
        {
            this._OpinionType = GEPOpinionType.OutOfValue;
        }

        public Opinion(SbnObject InitialObject) : base(InitialObject)
        {
            this._OpinionType = GEPOpinionType.OutOfValue;
        }

        public override SbnObject Clone(string sNodeName)
        {
            return new Opinion { ID = base.ID, OpinionType = this.OpinionType };
        }

        public override void Initialize()
        {
            base.Initialize();
            this._OpinionType = GEPOpinionType.OutOfValue;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static string at_OpinionType
        {
            get
            {
                return "Opinion.OpinionType";
            }
        }

        [IsRelational("False"), Category(""), RelationTable(""), AttributeType("GEPOpinionType"), DocumentAttributeID("9056"), Browsable(true), IsMiddleTableExist("False"), Description(""), DisplayName("")]
        public GEPOpinionType OpinionType
        {
            get
            {
                return this._OpinionType;
            }
            set
            {
                this._OpinionType = value;
            }
        }
    }
}
