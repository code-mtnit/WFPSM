using System;
using System.Collections.Generic;
using System.Text;
using Sbn.Controls.Imaging.ImagingObject;


namespace Sbn.Controls.Imaging.EventArgsFolder
{
    public class ImageEventArg : System.EventArgs
    {
        ImageDocument _Image = new ImageDocument();
        public ImageDocument Image
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

        public ImageEventArg(ImageDocument img)
        {
            this.Image = img;
        }

     


    }
}
