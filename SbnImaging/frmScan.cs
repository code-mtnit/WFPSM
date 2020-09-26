using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Sbn.Controls.Imaging.ImagingObject;

namespace Sbn.Controls.Imaging
{
    public partial class frmScan : Form
    {

        private Collection<ImageDocument> _AllImageScaned = new Collection<ImageDocument>();

        public Collection<ImageDocument> AllImageScaned
        {
            get
            {
                return _AllImageScaned; 
            }
            set 
            {
                _AllImageScaned = value; 
            }
        }


        public frmScan()
        {
            InitializeComponent();
        }

        private void vistaButton3_Click(object sender, EventArgs e)
        {
            this.ucScanImage1.AquireImage();
        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            //foreach (Image img in this.ucScanImage1.AllScanedImage)
            //{
            //    if (img != null)
            //    {
            //        Filmstrip.FilmstripImage fIMg = new FilmstripImage(img, "", "");
            //        this.AllImageScaned.Add(fIMg);
            //    }
            //}
            this.ucScanImage1.AllScanedImage.Clear();
            this.Close();
        }

        private void vistaButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void ucScanImage1_ScanedImage(object sender, Sbn.AdvancedControls.Imaging.Scan.ImageEvent e)
        {
            if (e.CurrentImage != null)
            {
                ImageDocument fIMg = new ImageDocument();
                SbnImageTools tool = new SbnImageTools();
                fIMg.Stream = tool.BaseTools.GetStreamImage(e.CurrentImage , System.Drawing.Imaging.ImageFormat.Tiff);
                e.CurrentImage.Dispose();
                e.CurrentImage = null;
                this.AllImageScaned.Add(fIMg);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}