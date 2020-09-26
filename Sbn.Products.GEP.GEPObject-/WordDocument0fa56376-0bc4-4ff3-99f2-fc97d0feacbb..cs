namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), ObjectCode("9069"), Description("فايل تايپي"), DisplayName("فايل تايپي"), ItemsType("Sbn.Products.GEP.GEPObject.WordDocuments")]
    public class WordDocument : SbnBinary
    {
        private GeneralDocument _CorrelateDoc;
        private string _EditionDate;

        public WordDocument()
        {
        }

        public WordDocument(SbnBinary InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            WordDocument document = new WordDocument {
                ID = base.ID
            };
            if (this._EditionDate != null)
            {
                document.EditionDate = (string) this._EditionDate.Clone();
            }
            if (!object.ReferenceEquals(this.CorrelateDoc, null))
            {
                document.CorrelateDoc = (GeneralDocument) this.CorrelateDoc.Clone(sNodeName);
            }
            return document;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._EditionDate = "";
            this._CorrelateDoc = new GeneralDocument();
        }

        public override string ToString()
        {
            if (base.Title != null)
            {
                return base.Title;
            }
            return "";
        }

        public static string at_CorrelateDoc_CorrelateFolderFirstLevelAttributes
        {
            get
            {
                return "WordDocument.CorrelateDoc.CorrelateFolderFirstLevelAttributes";
            }
        }

        public static string at_CorrelateDoc_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "WordDocument.CorrelateDoc.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateDoc_DocumentTypeFirstLevelAttributes
        {
            get
            {
                return "WordDocument.CorrelateDoc.DocumentTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateDoc_FileVersionsFirstLevelAttributes
        {
            get
            {
                return "WordDocument.CorrelateDoc.FileVersionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateDoc_OwnerFirstLevelAttributes
        {
            get
            {
                return "WordDocument.CorrelateDoc.OwnerFirstLevelAttributes";
            }
        }

        public static string at_CorrelateDocFirstLevelAttributes
        {
            get
            {
                return "WordDocument.CorrelateDocFirstLevelAttributes";
            }
        }

        public static string at_CorrelateDocID
        {
            get
            {
                return "WordDocument.CorrelateDocID";
            }
        }

        public static string at_EditionDate
        {
            get
            {
                return "WordDocument.EditionDate";
            }
        }

        [DocumentAttributeID("9314"), Description("مستند  تایپی"), Browsable(true), IsRelational("False"), DisplayName("مستند تایپی مرتبط"), AttributeType("GeneralDocument"), IsMiddleTableExist("False"), RelationTable(""), Category("")]
        public GeneralDocument CorrelateDoc
        {
            get
            {
                return this._CorrelateDoc;
            }
            set
            {
                this._CorrelateDoc = value;
            }
        }

        [AttributeType("DateString"), DisplayName("تاریخ آخرین نگارش"), Category(""), DocumentAttributeID("9238"), Description("تاریخ آخرین نگارش"), Browsable(true), IsRelational("false")]
        public string EditionDate
        {
            get
            {
                return this._EditionDate;
            }
            set
            {
                this._EditionDate = value;
            }
        }
    }
}
