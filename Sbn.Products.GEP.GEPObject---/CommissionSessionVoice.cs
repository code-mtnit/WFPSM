namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.OPS.OPSObject;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description("صوت جلسه کمیسیون"), DisplayName("صوت جلسه کمیسیون"), ObjectCode("1058"), ItemsType("Sbn.Products.GEP.GEPObject.CommissionSessionVoices")]
    public class CommissionSessionVoice : SbnObject
    {
        private string _VoiceStoragePath;
        private long _CorrelateCommissionID;

        public CommissionSessionVoice()
        {
            ID = base.ID;
        }

        public CommissionSessionVoice(SbnObject InitialObject) : base(InitialObject)
        {
            ID = base.ID;
        }

        public override SbnObject Clone(string sNodeName)
        {
            CommissionSessionVoice voice = new CommissionSessionVoice
            {
                ID = base.ID,
                
            };
            if (!object.ReferenceEquals(this.CorrelateCommissionID, null))
                voice.CorrelateCommissionID = this.CorrelateCommissionID;
            if (!object.ReferenceEquals(this.VoiceStoragePath, null))
                voice.VoiceStoragePath = this.VoiceStoragePath;
            //voice.VoiceStoragePath = this._VoiceStoragePath;
            //voice.CorrelateCommissionID = this._CorrelateCommissionID;
            //if (this._VoiceStoragePath != null)
            //{
            //    voice._VoiceStoragePath = this._VoiceStoragePath;
            //}
            //if (!object.ReferenceEquals(this.CorrelateCommissionID, null))
            //{
            //    voice.CorrelateCommissionID =this.CorrelateCommissionID;
            //}
            return voice;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override string ToString()
        {
            return base.ToString();
        }
        public static string at_CommissionSessionVoice_ParentFirstLevelAttributes
        {
            get
            {
                return "CommissionSessionVoice.CommissionSession.ParentFirstLevelAttributes";
            }
        }
        public static string at_CommissionSessionVoiceFirstLevelAttributes
        {
            get
            {
                return "CommissionSessionVoice.CommissionSessionFirstLevelAttributes";
            }
        }
        public static string at_CommissionSessionVoiceID

        {
            get
            {
                return "CommissionSessionVoice.CommissionSessionID";
            }
        }

        public static string at_VoiceStoragePath
        {
            get
            {
                return "CommissionSessionVoice.VoiceStoragePath";
            }
        }


        [Browsable(true), Description("آدرس ذخیره سازی صوت"), DisplayName("آدرس ذخیره سازی صوت"), Category(""), DocumentAttributeID("1059"), IsRelational("false"), AttributeType("String")]
        public string VoiceStoragePath
        {
            get
            {
                return this._VoiceStoragePath;
            }
            set
            {
                this._VoiceStoragePath = value;
            }
        }
        [Browsable(true), Description("شاخص کمیسیون"), DisplayName("شاخص کمیسیون"), Category(""), DocumentAttributeID("1060"), IsRelational("false"), AttributeType("Long")]
        public long CorrelateCommissionID
        {
            get
            {
                return this._CorrelateCommissionID;
            }
            set
            {
                this._CorrelateCommissionID = value;
            }
        }
    }
}
