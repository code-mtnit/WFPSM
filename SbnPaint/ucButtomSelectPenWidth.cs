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
    public partial class ucButtomSelectPenWidth : UserControl
    {
        private Form mForm;

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
                _penWidth = value;
                OnSelectWidthChange(null);
                Invalidate();
            }
        }
        
        public ucButtomSelectPenWidth()
        {
            InitializeComponent();
        }

        public void Show()
        {
            if (mForm != null)
            {
                mForm.Close();
            }
            mForm = new Form();
           // OnDropDown(mParent, new EventArgs());
        }
        private Size mWindowSize = new Size(0, 0);
        
      

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var frm = new Form();
            frm.StartPosition = FormStartPosition.CenterScreen;
            var uc = new UcSelectPenWidth();
            //frm.FormBorderStyle = FormBorderStyle.None;
            uc.PenWidth = this.PenWidth;
            frm.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            frm.LostFocus += new EventHandler(frm_LostFocus);
            frm.ShowDialog(this);
            PenWidth = uc.PenWidth;
        }

        void frm_LostFocus(object sender, EventArgs e)
        {
            //(sender as Form).Close();
        }

        private void ucButtomSelectPenWidth_Paint(object sender, PaintEventArgs e)
        {
            if (this.PenWidth <= 25)
                e.Graphics.FillEllipse(Brushes.Black, 3, 3, PenWidth, PenWidth);
            else
            {
                e.Graphics.FillEllipse(Brushes.Black, 3, 3, 25, 25);
            }

            

            e.Graphics.DrawString(PenWidth.ToString(),new Font("tahoma",9),Brushes.Black,3,30);
        }
    }
}
