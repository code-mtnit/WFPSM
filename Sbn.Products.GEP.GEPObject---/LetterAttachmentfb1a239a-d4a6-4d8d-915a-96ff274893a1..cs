namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, ObjectCode("9285"), SystemName("GEP"), ItemsType("Sbn.Products.GEP.GEPObject.LetterAttachments"), DisplayName(""), Description("")]
    public class LetterAttachment : SbnBinary
    {
        private string _FileType;

        public LetterAttachment()
        {
        }

        public LetterAttachment(SbnBinary InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            return new LetterAttachment { ID = base.ID, FileType = this._FileType };
        }

        public override void Initialize()
        {
            base.Initialize();
            this._FileType = "";
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static string at_FileType
        {
            get
            {
                return "LetterAttachment.FileType";
            }
        }

        [Description("نوع فایل ضمیمه"), AttributeType("String"), Browsable(true), DisplayName("نوع فایل"), Category("اطلاعات اصلی"), DocumentAttributeID("27056"), IsRelational("false")]
        public string FileType
        {
            get
            {
                return this._FileType;
            }
            set
            {
                this._FileType = value;
            }
        }
    }
}
