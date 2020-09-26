using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WordInDOTNET
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void tsbtnAddNewDoc_Click(object sender, EventArgs e)
        {
            this.htfWinWordControl1.NewDocument();
        }
    }
}
