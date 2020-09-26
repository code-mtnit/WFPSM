using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Sbn.AdvancedControls.Imaging.ImageViewer
{
    class SBNImage
    {

        Image _image = null;


        public Image Image
        {
            get { return _image; }
            set 
            {
                _image = value; 
            }
        }



        byte[] _stream = null;


        public byte[] Stream
        {
            get { return _stream; }
            set { _stream = value; }
        }


       

    }
}
