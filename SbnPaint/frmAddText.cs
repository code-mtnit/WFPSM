using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sbn.AdvancedControls.Imaging.SbnPaint
{
    public partial class frmAddText : Form
    {

        public event EventHandler ApplayAddText;
        public event EventHandler CancelAddText;
        public event EventHandler ChangedFont;

        
        public string TextResult
        {
            get
            {
                return this.ucAddText1.TextResult;
            }
            set
            {
                this.ucAddText1.TextResult = value;

            }

        }

        public frmAddText()
        {
            InitializeComponent();

            try
            {
                this.ucAddText1.FontText = new Font("B Nazanin", 20f, FontStyle.Regular);
            }
            catch
            { 

            }
            
        }


        public RectangleF TextRectangle
        {
            get
            {
              
                return this.ucAddText1.TextRectangle;
            }

        }

        public Font FontText
        {
            get
            {
                return this.ucAddText1.FontText;
            }
            set
            {
                this.ucAddText1.FontText = value;

                if (ChangedFont != null)
                {
                    ChangedFont(value, new EventArgs());
                }
            }
        }

        private void ucAddText1_CancelAddText(object sender, EventArgs e)
        {
            if (this.CancelAddText != null)
            {
               
                CancelAddText(sender, e);
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ucAddText1_ApplayAddText(object sender, EventArgs e)
        {
            if (ApplayAddText != null)
            {
             
                ApplayAddText(sender, e);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}