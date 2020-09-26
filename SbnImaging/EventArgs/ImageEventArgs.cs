using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Sbn.Controls.Imaging.ImagingObject;


namespace Sbn.Controls.Imaging.EventArgsFolder
{
    public class ImageEventArgs : System.EventArgs
    {
        Collection<ImageDocument> _Image = new Collection<ImageDocument>();
        public Collection<ImageDocument> Images
        {
            get
            {
                return _Image;
            }
            set
            {
                _Image = value;
            }
        }

        public ImageEventArgs(Collection<ImageDocument> img)
        {
            this.Images = img;
        }

        //public ImageEventArgs(Collection<BaseImage> img)
        //{
        //    var imgs = new BaseImage[img.Count];
        //    for (int i = 0; i < img.Count; i++)
        //    {
        //        imgs[i] = img[i];
        //    }
        //    this.Images = imgs;
        //}
        

    }

    public class PrintDocEventArgs : System.EventArgs
    {

        Collection<int> _PrintPages = new Collection<int>();

        public Collection<int> PrintPages
        {
            get { return _PrintPages; }
            set { _PrintPages = value; }
        }

        string _PrintTitle = "";

        public string PrintTitle
        {
            get { return _PrintTitle; }
            set { _PrintTitle = value; }
        }

        string _PrinterName = "";

        public string PrinterName
        {
            get { return _PrinterName; }
            set { _PrinterName = value; }
        } 


        public PrintDocEventArgs(Collection<int> pages , string Title , string SelectedPrinterName)
        {
            this.PrintPages = pages;

            this.PrintTitle = Title;

            PrinterName = SelectedPrinterName;
        }
    }
}
