using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections.ObjectModel;
using System.Printing;

using Sbn.Controls.Imaging.EventArgsFolder;
using Sbn.Controls.Imaging.ImagingObject;


namespace Sbn.Controls.Imaging
{
    
   

    public partial class frmPrintPreView : Form
    {


        //[System.Runtime.InteropServices.DllImport("gdi32.dll")]
        //public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest,
        //    int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        //private Bitmap memoryImage;
        //private void CaptureScreen()
        //{
        //    Graphics mygraphics = Graphics.FromImage(this.Image); // this.CreateGraphics();
        //    Size s = this.Size;
        //    memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
        //    Graphics memoryGraphics = Graphics.FromImage(this.Image);// memoryImage);
        //    IntPtr dc1 = mygraphics.GetHdc();
        //    IntPtr dc2 = memoryGraphics.GetHdc();
        //    BitBlt(dc2, 0, 0, this.ClientRectangle.Width,
        //        this.ClientRectangle.Height, dc1, 0, 0, 13369376);
        //    mygraphics.ReleaseHdc(dc1);
        //    memoryGraphics.ReleaseHdc(dc2);
        //}
        //private void printDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    e.Graphics.DrawImage(memoryImage, 0, 0);
        //}
        //private void printButton_Click(System.Object sender, System.EventArgs e)
        //{
        //    CaptureScreen();
        //    this.PrintDocument.Print();
        //}


       
        enum ViewMode
        {
            FitToWidth = 1,
            Center = 2
        }
        StandardPaper _CurrentStandardPage = new StandardPaper(PaperKind.A4);

        internal StandardPaper CurrentStandardPage
        {
            get { return _CurrentStandardPage; }
            set 
            {
                _CurrentStandardPage = value;
                this.txtPageSetup.Text = value.ToString();
                this.panel1.Size = value.Size;
                FitToPage();
                FillCenter();
            }
        }
        
        public Collection<int> PrintedIndex = new Collection<int>();
        private RectangleF recPrint = new RectangleF(0,0,210,298);
        private float TopMargin = 0;
        private float LeftMargin = 0;
        public int SelectedImageID = 0;


        public SbnImageTools CurrentTools = new SbnImageTools();
        public event EventHandler<PrintDocEventArgs> PrintPage;

        public event EventHandler<ImageEventArg> NeedImage;

        public void OnNeedImage(ImageEventArg e)
        {
            EventHandler<ImageEventArg> handler = NeedImage;
            if (handler != null) handler(this, e);
        }

        PrintDocument _PrintDocument = new PrintDocument();
        public PrintDocument PrintDocument
        {
            get
            {
                return _PrintDocument;
            }
            set
            {
                _PrintDocument = value;
            }
        }


        public ImageDocument CurrentViewImage;
        ImageDocumentBindingSource _AllImage = new ImageDocumentBindingSource();
        public ImageDocumentBindingSource AllImage
        {
            get { return _AllImage; }
            set {
                _AllImage = value;
                if (_AllImage != null)
                {
                    _AllImage.CurrentItemChanged += new EventHandler(_AllImage_CurrentItemChanged);
                }
            }
        }

        void _AllImage_CurrentItemChanged(object sender, EventArgs e)
        {
            textBox2.Text = AllImage.Position + 1 + "/" + AllImage.Count;


            if (_ImageTemp != null)
            {
                _ImageTemp.Dispose();
                _ImageTemp = null;


            }

            
            _ImageTemp = CurrentTools.GetWholeImage(Image);
            //FillCenter();
            //panel1.Invalidate();
            panel1.Refresh();
        }

        private Image _ImageTemp = null;
        public Image ImageTemp
        {
            get
            {
                if (_ImageTemp == null)
                {
                    _ImageTemp = CurrentTools.GetWholeImage(Image);
                }

                return _ImageTemp;
            }
            set { _ImageTemp = value; }
        }




       // ImageDocument _image = null;
        public ImageDocument Image
        {
            get
            {
                return AllImage.Current as ImageDocument;
                //if (_image != null && _image.Stream == null)
                //    OnNeedImage(new ImageEventArg(_image));
                //return _image;
            }
            set
            {

                AllImage.Position = AllImage.IndexOf(value);

                //if (_ImageTemp != null)
                //{
                //    _ImageTemp.Dispose();
                //    _ImageTemp = null;


                //}
                // _image = value;
                recPrint = FillCenter();
                panel1.Invalidate();
                // textBox2.Text = value.Counter.ToString();
            }
        }

        public frmPrintPreView()
        {
            
            InitializeComponent();
            
            
            cbModeView.SelectedIndex = 0;

            this.CurrentStandardPage = new StandardPaper(this.PrintDocument.DefaultPageSettings.PaperSize.Kind);
            this.txtPageSetup.Text = this.CurrentStandardPage.Title;


            _PrintDocument.PrintPage += new PrintPageEventHandler(_PrintDocument_PrintPage);

          
            
        }

        public int CurrentImageIndex = 0;
        void _PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {

            try
            {

                
                Image = AllImage[PrintedIndex[CurrentImageIndex]] as ImageDocument;

                //if (Image.ImageFullViewLayer == null)
                //{
                //    OnNeedImage(new ImageEventArg(Image));
                //}


            

                if (cboxFitToPage.Checked)
                {
                    // 
                    e.Graphics.DrawImage(ImageTemp, e.PageSettings.PrintableArea);
                }
                else
                {
                    //float WZoom = e.PageBounds.Width / this.recPrint.Width;
                    float WZoom =  this.recPrint.Width /CurrentStandardPage.Size.Width ;


                    RectangleF rec = new RectangleF();
                    rec.Y = recPrint.Y * WZoom;
                    rec.X = recPrint.X * WZoom;
                    rec.Width = e.PageBounds.Width * WZoom;
                    rec.Height = e.PageBounds.Height * WZoom;

                    e.Graphics.DrawImage(ImageTemp, rec);
                }



                //  int i = AllImage.IndexOf(this.Image);

                if (CurrentImageIndex < PrintedIndex.Count - 1)
                {
                    e.HasMorePages = true;
                    CurrentImageIndex++;
                    //this.Image = AllImage[i+1];
                }
                else
                {
                    e.HasMorePages = false;
                    CurrentImageIndex = 0;
                    // PrintedIndex.Clear();
                }




                //{
                //    e.HasMorePages = false;
                //    CurrentImageIndex = 0;
                //}


                //if (rbtnAllPage.Checked)
                //{

                //    //  int i = AllImage.IndexOf(this.Image);

                //    if (CurrentImageIndex < AllImage.Count - 1)
                //    {
                //        e.HasMorePages = true;
                //        CurrentImageIndex++;
                //        //this.Image = AllImage[i+1];
                //    }
                //    else
                //    {
                //        e.HasMorePages = false;
                //        CurrentImageIndex = 0;
                //    }



                //}
                //else
                //{
                //    e.HasMorePages = false;
                //    CurrentImageIndex = 0;
                //}

                try
                {
                    Collection<int> pages = new Collection<int>();
                    pages.Add(PrintedIndex[CurrentImageIndex] + 1);
                    if (PrintPage != null)
                        PrintPage(this, new PrintDocEventArgs(pages, "", this.cmbPrinters.Text));
                }
                catch
                { }
            }
            catch (Exception)
            {

                MessageBox.Show("خطا در چاپ تصویر شماره" + CurrentImageIndex + 1, "خطا", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }


        }


        private void GetPrintTicketFromPrinter()
        {
            PrintQueue printQueue = null;

            LocalPrintServer localPrintServer = new LocalPrintServer();

            // Retrieving collection of local printer on user machine
            PrintQueueCollection localPrinterCollection =
                localPrintServer.GetPrintQueues();

            System.Collections.IEnumerator localPrinterEnumerator =
                localPrinterCollection.GetEnumerator();

            while (localPrinterEnumerator.MoveNext())
            {
                // Get PrintQueue from first available printer
                printQueue = (PrintQueue)localPrinterEnumerator.Current;
            }
            //else
            //{
            //    // No printer exist, return null PrintTicket
            //    return ;
            //}

            return;

            // Get default PrintTicket from printer
            //PrintTicket printTicket = printQueue.DefaultPrintTicket;

            //PrintCapabilities printCapabilites = printQueue.GetPrintCapabilities();

            //// Modify PrintTicket
            //if (printCapabilites.CollationCapability.Contains(Collation.Collated))
            //{
            //    printTicket.Collation = Collation.Collated;
            //}

            //if (printCapabilites.DuplexingCapability.Contains(
            //        Duplexing.TwoSidedLongEdge))
            //{
            //    printTicket.Duplexing = Duplexing.TwoSidedLongEdge;
            //}

            //if (printCapabilites.StaplingCapability.Contains(Stapling.StapleDualLeft))
            //{
            //    printTicket.Stapling = Stapling.StapleDualLeft;
            //}

            //return printTicket;
        }// end:GetPrintTicketFromPrinter()




       void FitToPage()
       {
           if (Image != null)
           {

               if (ImageTemp.Width > ImageTemp.Height)
               {
                   recPrint = FillToWidth();
               }
               else
               {
                   recPrint = FillToHeight();

               }
               
           }
       }


      

        private void frmPrintPreView_Load(object sender, EventArgs e)
        {

            int i;
            string defultPrinterName = "";

            try
            {
                var printDoc = new PrintDocument();
                for (i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
                {
                    // pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                    //  comboInstalledPrinters.Items.Add(pkInstalledPrinters);
                    if (printDoc.PrinterSettings.IsDefaultPrinter)
                    {
                        defultPrinterName = printDoc.PrinterSettings.PrinterName;
                        break;
                    }
                }
            }
            catch
            { }
            
            try
            {

                var localPrintServer1 = new PrintServer();
            }
            catch
            {
                MessageBox.Show("invalid Framwork 3.5");
            }

            try
            {
                PrintQueue printQueue = null;



                var localPrintServer = new PrintServer();
                
                var FiltterPrinterType = new EnumeratedPrintQueueTypes[2];
                FiltterPrinterType[0] = EnumeratedPrintQueueTypes.Connections;
                FiltterPrinterType[1] = EnumeratedPrintQueueTypes.Local;
                

               
                
              

                // Retrieving collection of local printer on user machine
                var localPrinterCollection = new PrintQueueCollection();
                
                try
                {
                    localPrinterCollection  = localPrintServer.GetPrintQueues(FiltterPrinterType);
                }
                catch
                {
                    MessageBox.Show("vvv");
                }

                
                //printQueue = localPrintServer.;


                IEnumerator<PrintQueue> all = null;

                try
                {
                    all = localPrinterCollection.GetEnumerator();
                }
                catch
                {
                    MessageBox.Show("ss");
                }
                var AllPrinter = new Collection<PrintQueue>();
                PrintQueue defultPrinter = null; 


                while (all.MoveNext())
                {

                    try
                    {
                       // printQueue = all.Current;

                        //  if (printQueue.DefaultPrintTicket )
                        //  this.comboBox1.Items.Add(printQueue.FullName);

                        if (defultPrinterName == all.Current.Name)
                        {
                            defultPrinter = all.Current;
                        }

                        AllPrinter.Add(all.Current);
                    }
                    catch
                    {
                        MessageBox.Show("kkk");
                    }
                }

                //System.Printing.LocalPrintServer lPrint = new System.Printing.LocalPrintServer();
                //System.Printing.PrintQueueCollection pCol = lPrint.GetPrintQueues();

              



                try
                {
                    cmbPrinters.DataSource = AllPrinter;
                    cmbPrinters.DisplayMember = "FullName";

                    try
                    {
                        if (defultPrinter != null)
                        {
                            this.cmbPrinters.SelectedItem = defultPrinter;
                        }
                    }
                    catch
                    { }
                }
                catch
                {
                    MessageBox.Show("tttt");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Image = CurrentViewImage;// AllImage[0];
            rbtnCurrentView.Checked = true;
           // 
            
            cmbPrinters.Enabled = true;
            cboxFitToPage.Checked = true;
            cboxCenter.Checked = true;




          

        }

      


        private RectangleF FillToWidth()
        {
            RectangleF rec = new RectangleF();
            if (this.ImageTemp != null)
            {

             
                rec.X = recPrint.X;
                rec.Y = recPrint.Y;

                float Contrast = (float)ImageTemp.Width / (float)ImageTemp.Height;


                //if (Image.Width > Image.Height)
                //{
                cbModeView.SelectedIndex = 0;
                //    rec.Height = 298;
                //    rec.Width = Contrast * 298;
                //}
                //else
                {

                    rec.Width = this.CurrentStandardPage.Size.Width;
                    rec.Height = this.CurrentStandardPage.Size.Width / Contrast;
                }
            }
            return rec;
        }
        private RectangleF FillCenter()
        {
            RectangleF rec = new RectangleF();

            if (this.Image != null)
            {
               // this.Image.Save("C:\\dffggh.jpg");
                rec.X = 0;
                rec.Y = 0;

              

              //  float Contrast = (float)Image.ImageFullViewLayer.Width / (float)Image.ImageFullViewLayer.Height;


                //if (Image.Width > Image.Height)
                //{

                cbModeView.SelectedIndex = 1;

                //    rec.Height = 298;
                //    rec.Width = Contrast * 298;
                //}
                //else
                {

                    rec.Width = recPrint.Width;
                    rec.Height = recPrint.Height;
                }

                //rec.X = (this.panel1.Width - rec.wi)
                rec.Y = (this.panel1.Height - rec.Height) / 2;
                rec.X = (this.panel1.Width - rec.Width) / 2;
            }
            return rec;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (this.PrintDocument != null)
            {
                // Graphics eg = null;
               // BufferedGraphics bb = null;
                //e.Graphics.DrawImage(this.Image, new Point (0,0));
                //recPrint = FillToWidth();
               // recPrint = FillCenter();

                //if (Image.ImageFullViewLayer == null)
                //    OnNeedImage(new ImageEventArg(Image));


                if (Image != null && ImageTemp != null) e.Graphics.DrawImage(ImageTemp, recPrint);
            }
        }

        private void vistaButton2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cbModeView_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if (cbModeView.SelectedIndex == 0)
            {
                recPrint = FillToWidth();
            }
            if (cbModeView.SelectedIndex == 1)
            {
                recPrint = FillCenter();
            }
            panel1.Invalidate();
        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            PrintedIndex.Clear();

            if (rbtnCurrentView.Checked)
            {
               // int i = AllImage.IndexOf(this.Image);
                PrintedIndex.Add(Image.OrderInDocument -1);
            }


            if (rbtnAllPage.Checked)
            {
                for (int i = 0; i < AllImage.Count; i++)
                {
                    PrintedIndex.Add(i);
                }
            }

            if (radioButton3.Checked)
            {
                if (txtSelectedPages.Text == "")
                    return;
                else
                {
                    try
                    {
                        if (txtSelectedPages.Text.Contains("-"))
                        {
                            int lowerIndex = int.Parse(txtSelectedPages.Text.Split('-')[0]);
                            int upperIndex = int.Parse(txtSelectedPages.Text.Split('-')[1]);

                            for (int i = lowerIndex; i <= upperIndex; i++)
                            {
                                PrintedIndex.Add(i-1);
                            }

                           
                        }
                        if (txtSelectedPages.Text.Contains(","))
                        {
                            string[] strarr = txtSelectedPages.Text.Split(',');

                            for (int i = 0; i < strarr.Length; i++)
                            {
                                PrintedIndex.Add(int.Parse(strarr[i])-1);
                            }

                           
                        }

                        if (!txtSelectedPages.Text.Contains(",") && !txtSelectedPages.Text.Contains("-"))
                        {
                            if ( int.Parse(txtSelectedPages.Text) > 0 && int.Parse(txtSelectedPages.Text) <= AllImage.Count )
                            {
                                PrintedIndex.Add(int.Parse(txtSelectedPages.Text)-1);
                            }
                            else
                            {
                                txtSelectedPages.Focus();
                                txtSelectedPages.SelectAll();
                                return;
                            }
                        }
                    }
                    catch
                    {
                        txtSelectedPages.Focus();
                        txtSelectedPages.SelectAll();
                        return;
                    }
                }
                
            }


            this.PrintDocument.DocumentName = "Document";
            this.PrintDocument.Print();

            this.DialogResult = DialogResult.OK;
            

          
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (txtTopMargin.Text != "")
            {
                this.recPrint.Y = float.Parse(txtTopMargin.Text);
                panel1.Invalidate();
            }
        }

        private void cboxCenter_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxCenter.Checked)
            {
                recPrint = FillCenter();
                txtLaftMargin.Enabled = false;
                txtTopMargin.Enabled = false;
                txtTopMargin.Text = recPrint.Y.ToString();
                txtLaftMargin.Text = recPrint.X.ToString();
                

            }
            else
            {
                txtLaftMargin.Enabled = true;
                txtTopMargin.Enabled = true;
                if (txtLaftMargin.Text != "" && txtTopMargin.ToString() != "")
                {

                    recPrint.X = float.Parse(txtLaftMargin.Text);
                    recPrint.Y = float.Parse(txtTopMargin.Text);
                }
            }
            panel1.Invalidate();
        }

        private void txtLaftMargin_TextChanged(object sender, EventArgs e)
        {
            if (txtLaftMargin.Text != "")
            {
                recPrint.X = float.Parse(txtLaftMargin.Text);
                panel1.Invalidate();
            }

        }

        private void cboxFitToPage_CheckedChanged(object sender, EventArgs e)
        {
            if (Image == null)
            {
                return;
                //this.Image = AllImage[0];
            }
               
            if (this.cboxFitToPage.Checked)
            {
                txtWidth.Enabled = false;
                txtHeight.Enabled = false;
                FitToPage();
               
                recPrint = FillCenter();
                txtWidth.Text = recPrint.Width.ToString();
                txtHeight.Text = recPrint.Height.ToString();
            }
            else
            {
                txtWidth.Enabled = true;
                txtHeight.Enabled = true;
                if (txtHeight.Text != "" && txtWidth.Text != "")
                {
                    recPrint.Width = float.Parse(txtWidth.Text);
                    recPrint.Height = float.Parse(txtHeight.Text);
                }
            }

            panel1.Invalidate();
        }

        private RectangleF FillToHeight()
        {
            RectangleF rec = new RectangleF();
            if (this.Image != null)
            {


                rec.X = recPrint.X;
                rec.Y = recPrint.Y;

                float Contrast = (float)_ImageTemp.Width / (float)_ImageTemp.Height;


                //if (Image.Width > Image.Height)
                //{
                cbModeView.SelectedIndex = 0;
                //    rec.Height = 298;
                //    rec.Width = Contrast * 298;
                //}
                //else
                {
                    // _PrintDocument.DefaultPageSettings.PaperSize.Kind
                    rec.Width = this.CurrentStandardPage.Size.Height * Contrast;
                    rec.Height = this.CurrentStandardPage.Size.Height;
                }
            }
            return rec;
        }

        private void txtWidth_TextChanged(object sender, EventArgs e)
        {
            if (txtWidth.Text != "" && txtHeight.Text != "" && checkScaleGB == true)
            {
                float cn = (float)this.ImageTemp.Height / (float)this.ImageTemp.Width;
                recPrint.Width = float.Parse(txtWidth.Text);
                recPrint.Height = recPrint.Width * cn;
                checkScaleGB = false;
                txtHeight.Text = recPrint.Height.ToString();
                checkScaleGB = true;
            }
            panel1.Invalidate();
        }

        bool checkScaleGB = true;

        private void txtHeight_TextChanged(object sender, EventArgs e)
        {
            if (txtWidth.Text != "" && txtHeight.Text != "" && checkScaleGB == true)
            {
                
               // float cn = (float)this.Image.ImageFullViewLayer.Height / (float)this.Image.ImageFullViewLayer.Width;
               // recPrint.Height = float.Parse(txtHeight.Text);
               //// float cn1 = ((int)(recPrint.Width * 100000)) / 100000;

               // recPrint.Width = recPrint.Height / cn;

               // checkScaleGB = false;
               // txtWidth.Text = recPrint.Width.ToString();
               // checkScaleGB = true;
               
            }
            panel1.Invalidate();
        }

        private void vistaButton6_Click(object sender, EventArgs e)
        {
            try
            {

                AllImage.MoveNext();
                //int temp = Image.OrderInDocument - 1;
                //this.Image = this.AllImage[temp + 1];

             
            }
            catch
            { 

            }
          
        }

        private void btnPreviousImage_Click(object sender, EventArgs e)
        {
            try
            {
                AllImage.MovePrevious();
                //int temp = Image.OrderInDocument - 1;
                //this.Image = this.AllImage[temp - 1];

            }
            catch
            {

            }

        }

        private void vistaButton3_Click(object sender, EventArgs e)
        {
            this.PrintDocument.Print();
        }

        private void vistaButton7_Click(object sender, EventArgs e)
        {
            PrintDialog pp = new PrintDialog();
            pp.ShowDialog();
        }

      

        private void btnPageSetup_Click(object sender, EventArgs e)
        {
            PageSetupDialog pss = new PageSetupDialog();
            pss.PageSettings = this.PrintDocument.DefaultPageSettings;
            pss.ShowDialog();
            this.PrintDocument.DefaultPageSettings.PaperSize = pss.PageSettings.PaperSize;
            this.CurrentStandardPage = new StandardPaper(pss.PageSettings.PaperSize.Kind);
        
        }

        private void cmbPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.PrintDocument.PrinterSettings.PrinterName = cmbPrinters.Text;
                this.CurrentStandardPage = new StandardPaper(this.PrintDocument.PrinterSettings.DefaultPageSettings.PaperSize.Kind);


                if (cboxFitToPage.Checked)
                {
                    //if (this.Image.ImageFullViewLayer.Width > this.Image.ImageFullViewLayer.Height)
                    //{
                    //    recPrint = FillToWidth();
                    //}
                    //else
                    //{
                    //    recPrint = FillToHeight();

                    //}
                }

                if (cboxCenter.Checked)
                    recPrint = FillCenter();
            }
            catch
            { }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            txtSelectedPages.Enabled = radioButton3.Checked;
        }

        private void rbtnAllPage_CheckedChanged(object sender, EventArgs e)
        {

           
            if (rbtnAllPage.Checked && AllImage != null && AllImage.Count > 0)
                AllImage.MoveFirst();
                //this.Image = AllImage[0];    
        }

        private void rbtnCurrentView_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnCurrentView.Checked)
                this.Image = CurrentViewImage;

        
        }

        private void btnEndImage_Click(object sender, EventArgs e)
        {
            AllImage.MoveLast();
        }

        private void btnFirstImage_Click(object sender, EventArgs e)
        {
            AllImage.MoveFirst();
        }

       

    }
}
