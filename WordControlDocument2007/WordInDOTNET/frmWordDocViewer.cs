using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace WordInDOTNET
{
    public partial class frmWordDocViewer : Form
    {
        public frmWordDocViewer()
        {
            InitializeComponent();
            button1.MouseEnter += new EventHandler(button1_MouseEnter);

            this.Disposed += new EventHandler(frmWord_Disposed);
        }

        

        void frmWord_Disposed(object sender, EventArgs e)
        {
           
        }

        

        protected override void OnClosing(CancelEventArgs e)
        {
          //  this.wordControlDocumentNew21.CloseWordApp();
            base.OnClosing(e);
        }

        private void tsbtnNew_Click(object sender, EventArgs e)
        {
            this.wordControlDocumentNew21.CreatNewDocument2();
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {




            try
            {


                byte[] b =  wordControlDocumentNew21.CurrentStream;

              //  wordControlDocumentNew21.Save(ref b, false);

                //b = this.wordControlDocumentNew21.GetStreamOfCurrentDocument();



                //this.DialogResult = DialogResult.OK;

                //this.Close();

                ////objWinWordControl.docum();
                //byte[] b = null;

                //string f = this.wordControlDocumentNew21.SaveAndCloseDocument(ref b);
                //this.wordControlDocumentNew21.LoadWordDocument(b);
            }
            catch
            { }
        }

        private void tsbtnSaveAs_Click(object sender, EventArgs e)
        {
            wordControlDocumentNew21.Save();
        }

        private void tsbtnClear_Click(object sender, EventArgs e)
        {

         

        }

        private void btnExportText_Click(object sender, EventArgs e)
        {
            //this.wordControlDocumentNew21.GetStreamOfCurrentDocument();

            //this.richTextBox1.Text = wordControlDocumentNew21.CurrentText;



            this.richTextBox1.Text = wordControlDocumentNew21.CurrentText;

            tabControl1.SelectedTab = tabPage2;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            wordControlDocumentNew21.PrintSelectedDocumentToImage(true, false);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(wordControlDocumentNew21.DocumentChanged.ToString());
        }

        private void tsbtnLock_CheckedChanged(object sender, EventArgs e)
        {
            this.wordControlDocumentNew21.ReadOnly = !wordControlDocumentNew21.ReadOnly;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
          //  Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y + 30);            
          //  wordControlDocumentNew21.GoBack();
            wordControlDocumentNew21.Focus();
            wordControlDocumentNew21.wd.Activate();
            wordControlDocumentNew21.wd.ActiveWindow.Activate();

            wordControlDocumentNew21.wd.ActiveWindow.SetFocus();
            wordControlDocumentNew21.wd.ActiveWindow.ActivePane.Activate();
            SendKeys.Send("%{LEFT}");

        }

        private void button1_Click(object sender, EventArgs e)
        {

           
            //wordControlDocumentNew21.wd.Activate();
            ////wordControlDocumentNew21.Focus();
            ////wordControlDocumentNew21.wd.ActiveWindow.SetFocus();
            ////wordControlDocumentNew21.wd.ActiveWindow.ActivePane.Activate();
            //SendKeys.Send("%{LEFT}");

            ////SendKeys.Send("^s");

            ////wordControlDocumentNew21.wd.Activate();
            ////wordControlDocumentNew21.Focus();
            ////wordControlDocumentNew21.wd.ActiveWindow.SetFocus();
            ////wordControlDocumentNew21.wd.ActiveWindow.ActivePane.Activate();
        }



        void button1_MouseEnter(object sender, EventArgs e)
        {
            //wordControlDocumentNew21.Focus();
            //wordControlDocumentNew21.wd.ActiveWindow.SetFocus();
            //wordControlDocumentNew21.wd.ActiveWindow.ActivePane.Activate();
            //SendKeys.Send("%{LEFT}");

            ////SendKeys.Send("^s");

            //wordControlDocumentNew21.Focus();
            //wordControlDocumentNew21.wd.ActiveWindow.SetFocus();
            //wordControlDocumentNew21.wd.ActiveWindow.ActivePane.Activate();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            OpenFileDialog frm = new OpenFileDialog();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                wordControlDocumentNew21.OpenWordDocument(frm.FileName);
            }
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            wordControlDocumentNew21.GoBack();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            wordControlDocumentNew21.SetSetting();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
           // wordControlDocumentNew21.SaveToImage();
        }
    }
}
