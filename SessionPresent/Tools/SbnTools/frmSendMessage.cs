using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SessionPresent.Tools.SbnTools
{
    public partial class frmSendMessage : Form
    {
        public frmSendMessage()
        {
            InitializeComponent();
        }

        private void trkDuration_Scroll(object sender, EventArgs e)
        {
            this.lblDuration.Text = trkDuration.Value.ToString();
        }

        private void trcDelay_Scroll(object sender, EventArgs e)
        {
            this.lblDelay.Text = trcDelay.Value.ToString();

        }

        private void btnApplay_Click(object sender, EventArgs e)
        {

        }
    }
}
