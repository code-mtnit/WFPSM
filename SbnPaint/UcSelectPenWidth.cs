using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sbn.AdvancedControls.Imaging.SbnPaint
{
    public partial class UcSelectPenWidth : UserControl
    {

        public event EventHandler SelectWidthChange;

        public void OnSelectWidthChange(EventArgs e)
        {
            EventHandler handler = SelectWidthChange;
            if (handler != null) handler(this, e);
        }

        private float _penWidth = 100;

        public float PenWidth
        {
            get { return _penWidth; }
            set
            {
                if (value != _penWidth)
                {
                    maskedTextBox1.Text = value.ToString();
                    _penWidth = value;
                    if (value >= trackBar1.Minimum && value <= trackBar1.Maximum)
                        trackBar1.Value = (int) value;

                    OnSelectWidthChange(null);
                }
            }
        }

        public UcSelectPenWidth()
        {
            InitializeComponent();
            maskedTextBox1.Text = PenWidth.ToString();
            trackBar1.Value = (int) PenWidth;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            PenWidth = trackBar1.Value;
        }

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(maskedTextBox1.Text))
                return;
            var i = int.Parse(maskedTextBox1.Text);
            if (i<=0 || i > 400)
                return;
            trackBar1.Value = int.Parse(maskedTextBox1.Text);
        }
    }
}
