using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;

namespace Sbn.Controls.Imaging
{
    class StandardPaper
    {

        public StandardPaper(PaperKind pk)
        {
            this.Title = pk.ToString();

            this.Kind = PaperKind.A4;
            switch (pk)
            { 
                case PaperKind.A4:
                    this.Size = new Size(210, 297);
                    break;
                case PaperKind.A5:
                    this.Size = new Size(148, 210);
                    break;
                case PaperKind.Letter:
                    this.Size = new Size(215, 279);
                    break;
                default :
                    this.Size = new Size(210, 297);
                    break;
            }
        }


        string _Title = "";

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }


        PaperKind _Kind = PaperKind.A4;

        public PaperKind Kind
        {
            get { return _Kind; }
            set { _Kind = value; }
        }


        Size _size = new Size();

        public Size Size
        {
            get { return _size; }
            set 
            {
                _size = value; 
            }
        }

        public override string ToString()
        {
            return this.Title;
        }

    }
}
