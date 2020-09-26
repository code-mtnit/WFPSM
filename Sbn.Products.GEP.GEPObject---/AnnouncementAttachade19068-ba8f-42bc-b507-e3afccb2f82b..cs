namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Controls.Imaging.ImagingObject;
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, Description(""), ItemsType("Sbn.Products.GEP.GEPObject.AnnouncementAttachs"), DisplayName(""), ObjectCode("9284"), SystemName("GEP")]
    public class AnnouncementAttach : ImageDocument
    {
        private GovAnnouncement _CoAnnouncement;

        public AnnouncementAttach()
        {
        }

        public AnnouncementAttach(ImageDocument InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            AnnouncementAttach attach = new AnnouncementAttach {
                ID = base.ID
            };
            if (!object.ReferenceEquals(this.CoAnnouncement, null))
            {
                attach.CoAnnouncement = (GovAnnouncement) this.CoAnnouncement.Clone(sNodeName);
            }
            return attach;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._CoAnnouncement = new GovAnnouncement();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static string at_CoAnnouncement_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "AnnouncementAttach.CoAnnouncement.AttachmentsFirstLevelAttributes";
            }
        }

        public static string at_CoAnnouncement_CoGovSessionFirstLevelAttributes
        {
            get
            {
                return "AnnouncementAttach.CoAnnouncement.CoGovSessionFirstLevelAttributes";
            }
        }

        public static string at_CoAnnouncement_CoOrganFirstLevelAttributes
        {
            get
            {
                return "AnnouncementAttach.CoAnnouncement.CoOrganFirstLevelAttributes";
            }
        }

        public static string at_CoAnnouncementFirstLevelAttributes
        {
            get
            {
                return "AnnouncementAttach.CoAnnouncementFirstLevelAttributes";
            }
        }

        public static string at_CoAnnouncementID
        {
            get
            {
                return "AnnouncementAttach.CoAnnouncementID";
            }
        }

        [Description("اعلان مرتبط"), RelationTable(""), DisplayName("اعلان مرتبط"), Category(""), DocumentAttributeID("27201"), Browsable(true), IsRelational("False"), AttributeType("GovAnnouncement"), IsMiddleTableExist("False")]
        public GovAnnouncement CoAnnouncement
        {
            get
            {
                return this._CoAnnouncement;
            }
            set
            {
                this._CoAnnouncement = value;
            }
        }
    }
}
