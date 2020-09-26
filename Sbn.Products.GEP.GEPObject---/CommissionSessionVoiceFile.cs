namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.OPS.OPSObject;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Text;

    [Serializable, SystemName("GEP"), Description("فایل صوت جلسه کمیسیون"), DisplayName("فایل صوت جلسه کمیسیون"), ObjectCode("1059"), ItemsType("")]
    public class CommissionSessionVoiceFile : SbnObject
    {
        private string _VoiceStoragePath;
        private string _VoiceSourcePath;
        private byte[] _File;

        public CommissionSessionVoiceFile()
        {
            ID = base.ID;
            File = this.File;
            VoiceStoragePath = this.VoiceStoragePath;
        }

        public CommissionSessionVoiceFile(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            CommissionSessionVoiceFile voiceFile = new CommissionSessionVoiceFile
            {
                ID = base.ID
            };
            if (this._VoiceStoragePath != null)
            {
                voiceFile._VoiceStoragePath = (string)this._VoiceStoragePath.Clone();
            }
            if (this._VoiceSourcePath != null)
            {
                voiceFile._VoiceSourcePath = (string)this._VoiceSourcePath.Clone();
            }
            return voiceFile;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._VoiceStoragePath = "";
        }

        public override string ToString()
        {
            return base.ToString();
        }


        [Browsable(true), Description("آدرس ذخیره سازی صوت"), DisplayName("آدرس ذخیره سازی صوت"), Category(""), DocumentAttributeID(""), IsRelational("false"), AttributeType("LongText")]
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
        [Browsable(true), Description("آدرس صوت"), DisplayName("آدرس صوت"), Category(""), DocumentAttributeID(""), IsRelational("false"), AttributeType("LongText")]
        public string VoiceSourcePath
        {
            get
            {
                return this._VoiceSourcePath;
            }
            set
            {
                this._VoiceSourcePath = value;
            }
        }
        [Browsable(true), Description("صوت"), DisplayName("صوت"), Category(""), DocumentAttributeID(""), IsRelational("false"), AttributeType("LongText")]
        public byte[] File
        {
            get
            {
                return this._File;
            }
            set
            {
                this._File = value;
            }
        }
    }
}
