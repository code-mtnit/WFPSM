using ColorPicker;
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

        private void button2_Click(object sender, EventArgs e)
        {
            ColorPickerDialog dlg = new ColorPickerDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                this.txtTitle.ForeColor = dlg.ColorPicker.SelectedColor;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorPickerDialog dlg = new ColorPickerDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                this.txtTitle.BackColor = dlg.ColorPicker.SelectedColor;
            }

        }

        private void frmSendMessage_Load(object sender, EventArgs e)
        {

        }
    }
}
