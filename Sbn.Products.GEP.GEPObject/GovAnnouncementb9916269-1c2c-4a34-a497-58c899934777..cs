namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description(""), DisplayName(""), ItemsType("Sbn.Products.GEP.GEPObject.GovAnnouncements"), ObjectCode("9292")]
    public class GovAnnouncement : SbnObject
    {
        private AnnouncementAttachs _Attachments;
        private GovSession _CoGovSession;
        private OrgUnit _CoOrgan;

        public GovAnnouncement()
        {
        }

        public GovAnnouncement(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            GovAnnouncement announcement = new GovAnnouncement {
                ID = base.ID
            };
            if (!object.ReferenceEquals(this.CoOrgan, null))
            {
                announcement.CoOrgan = (OrgUnit) this.CoOrgan.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CoGovSession, null))
            {
                announcement.CoGovSession = (GovSession) this.CoGovSession.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Attachments, null))
            {
                announcement.Attachments = (AnnouncementAttachs) this.Attachments.Clone(sNodeName);
            }
            return announcement;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._CoOrgan = new OrgUnit();
            this._CoGovSession = new GovSession();
            this._Attachments = new AnnouncementAttachs();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static string at_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "GovAnnouncement.AttachmentsFirstLevelAttributes";
            }
        }

        public static string at_AttachmentsID
        {
            get
            {
                return "GovAnnouncement.AttachmentsID";
            }
        }

        public static string at_CoGovSession_CataloguesFirstLevelAttributes
        {
            get
            {
                return "GovAnnouncement.CoGovSession.CataloguesFirstLevelAttributes";
            }
        }

        public static string at_CoGovSession_CoLettersFirstLevelAttributes
        {
            get
            {
                return "GovAnnouncement.CoGovSession.CoLettersFirstLevelAttributes";
            }
        }

        public static string at_CoGovSession_CorrelateOffersFirstLevelAttributes
        {
            get
            {
                return "GovAnnouncement.CoGovSession.CorrelateOffersFirstLevelAttributes";
            }
        }

        public static string at_CoGovSession_MembersFirstLevelAttributes
        {
            get
            {
                return "GovAnnouncement.CoGovSession.MembersFirstLevelAttributes";
            }
        }

        public static string at_CoGovSession_OrganAnnouncementFirstLevelAttributes
        {
            get
            {
                return "GovAnnouncement.CoGovSession.OrganAnnouncementFirstLevelAttributes";
            }
        }

        public static string at_CoGovSession_PreOrdersFirstLevelAttributes
        {
            get
            {
                return "GovAnnouncement.CoGovSession.PreOrdersFirstLevelAttributes";
            }
        }

        public static string at_CoGovSession_PresentationsFirstLevelAttributes
        {
            get
            {
                return "GovAnnouncement.CoGovSession.PresentationsFirstLevelAttributes";
            }
        }

        public static string at_CoGovSession_SessionOrderFirstLevelAttributes
        {
            get
            {
                return "GovAnnouncement.CoGovSession.SessionOrderFirstLevelAttributes";
            }
        }

        public static string at_CoGovSessionFirstLevelAttributes
        {
            get
            {
                return "GovAnnouncement.CoGovSessionFirstLevelAttributes";
            }
        }

        public static string at_CoGovSessionID
        {
            get
            {
                return "GovAnnouncement.CoGovSessionID";
            }
        }

        public static string at_CoOrgan_BuildingLocationFirstLevelAttributes
        {
            get
            {
                return "GovAnnouncement.CoOrgan.BuildingLocationFirstLevelAttributes";
            }
        }

        public static string at_CoOrgan_ChildUnitsFirstLevelAttributes
        {
            get
            {
                return "GovAnnouncement.CoOrgan.ChildUnitsFirstLevelAttributes";
            }
        }

        public static string at_CoOrgan_MergedUnitFirstLevelAttributes
        {
            get
            {
                return "GovAnnouncement.CoOrgan.MergedUnitFirstLevelAttributes";
            }
        }

        public static string at_CoOrgan_ParentUnitFirstLevelAttributes
        {
            get
            {
                return "GovAnnouncement.CoOrgan.ParentUnitFirstLevelAttributes";
            }
        }

        public static string at_CoOrgan_PositionsFirstLevelAttributes
        {
            get
            {
                return "GovAnnouncement.CoOrgan.PositionsFirstLevelAttributes";
            }
        }

        public static string at_CoOrganFirstLevelAttributes
        {
            get
            {
                return "GovAnnouncement.CoOrganFirstLevelAttributes";
            }
        }

        public static string at_CoOrganID
        {
            get
            {
                return "GovAnnouncement.CoOrganID";
            }
        }

        [IsRelational("False"), IsMiddleTableExist("False"), RelationTable(""), DisplayName("ضمائم"), Category(""), DocumentAttributeID("27200"), Browsable(true), AttributeType("AnnouncementAttachs"), Description("ضمائم")]
        public AnnouncementAttachs Attachments
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

        [DocumentAttributeID("27199"), IsRelational("False"), AttributeType("GovSession"), IsMiddleTableExist("False"), RelationTable(""), Browsable(true), Category(""), Description("جلسه مرتبط"), DisplayName("جلسه مرتبط")]
        public GovSession CoGovSession
        {
            get
            {
                return this._CoGovSession;
            }
            set
            {
                this._CoGovSession = value;
            }
        }

        [DisplayName("دستگاه مرتبط"), Category(""), RelationTable(""), Description(""), DocumentAttributeID("27198"), Browsable(true), IsRelational("False"), AttributeType("OrgUnit"), IsMiddleTableExist("False")]
        public OrgUnit CoOrgan
        {
            get
            {
                return this._CoOrgan;
            }
            set
            {
                this._CoOrgan = value;
            }
        }
    }
}
