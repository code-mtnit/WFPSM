namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;


    [Serializable, Description("پیشنهاد"), SystemName("GEP"), DisplayName("ارائه گزارش در دولت"), ObjectCode("9998"), ItemsType("Sbn.Products.GEP.GEPObject.Offers")]
    public class GovPresentation : SbnObject
    {
        private Presentations _GovPresents;
        private PresentationAttachs _Attachments;
        [DocumentAttributeID("9365"), IsMiddleTableExist("False"), RelationTable("PRESENTATION_ATTACHMENTS_M"), AttributeType("PresentationAttachs"), Description("ضمائم"), DisplayName("ضمائم"), Category(""), Browsable(true), IsRelational("False")]
        public PresentationAttachs Attachments
        {
            get
            {
                return this._Attachments;
            }
            set
            {
                this._Attachments = value;
            }
        }
        private int _OrderInSession;
        private string _TitleBackColor;
        private string _TitleForeColor;
        private Single _TitleFontSize;
        public Single TitleFontSize
        {
            get
            {
                return _TitleFontSize;
            }

            set
            {
                _TitleFontSize = value;
            }
        }
        public string TitleBackColor
        {
            get
            {
                return _TitleBackColor;
            }

            set
            {
                _TitleBackColor = value;
            }
        }


        public string TitleForeColor
        {
            get
            {
                return _TitleForeColor;
            }

            set
            {
                _TitleForeColor = value;
            }
        }
        public GovPresentation()
        {
        }

        public GovPresentation(SbnObject InitialObject)
            : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            GovPresentation offer = new GovPresentation
            {
                OrderInSession = this._OrderInSession,
                ID = base.ID, Title = base.Title
            };
            if (!object.ReferenceEquals(this.Presentations, null))
            {
                offer.Presentations = (Presentations)this.Presentations.Clone(sNodeName);
            }

            return offer;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._GovPresents  = new   Presentations  ();
        }

        public override string ToString()
        {
            return this.Title;
        }


        public static string at_GovPresentsFirstLevelAttributes
        {
            get
            {
                return "GovPresentation.GovPresentsFirstLevelAttributes";
            }
        }

        public static string at_GovPresentsID
        {
            get
            {
                return "GovPresentation.GovPresentsID";
            }
        }
        

        [RelationTable(""), Description("گزارشهای قابل ارائه در دولت"), DisplayName("ارائه در دولت"), Category(""), DocumentAttributeID("9027"), Browsable(true), IsRelational("True"), AttributeType("GovPresentations"), IsMiddleTableExist("True")]
        public Presentations Presentations
        {
            get
            {
                return this._GovPresents;
            }
            set
            {
                this._GovPresents = value;
            }
        }

        [Browsable(true), Description("ردیف"), DisplayName("ردیف"), Category(""), DocumentAttributeID("9261"), IsRelational("false"), AttributeType("Int")]
        public int OrderInSession
        {
            get
            {
                return this._OrderInSession;
            }
            set
            {
                this._OrderInSession = value;
            }
        }

    }
}
