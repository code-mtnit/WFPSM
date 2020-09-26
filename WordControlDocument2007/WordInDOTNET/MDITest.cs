using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordInDOTNET
{
    public partial class MDITest : Form
    {
        public MDITest()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void tsbtnAddNewWord_Click(object sender, EventArgs e)
        {
            frmWord frm = new frmWord();
            frm.MdiParent = this;
            frm.Show();
            frm.wordControlDocumentNew21.CreatNewDocument2();
        }
    }
}
