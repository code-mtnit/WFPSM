using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Sbn.AdvancedControls.Imaging.SbnPaint
{
    public partial class ucAddText : UserControl
    {

        public event EventHandler ApplayAddText;
        public event EventHandler CancelAddText;

        public event EventHandler TextChanged;

        public ucAddText()
        {
            InitializeComponent();


            try
            {
                System.Globalization.CultureInfo cul = new System.Globalization.CultureInfo("fa-ir");
                System.Windows.Forms.InputLanguage.CurrentInputLanguage = System.Windows.Forms.InputLanguage.FromCulture(cul);
            }
            catch
            {

            }
        }


        public RectangleF TextRectangle
        {
            get
            {
                System.Drawing.Graphics g = this.richTextBox1.CreateGraphics();
                SizeF size = g.MeasureString(this.richTextBox1.Text, richTextBox1.Font);
                RectangleF rec = new RectangleF(new PointF(0,0) , size);
                return rec;
            }

        }

        public Font FontText
        {
            get
            {
                return this.richTextBox1.Font;
            }
            set
            {
                this.richTextBox1.Font = value;
            }
        }
     
        public string TextResult
        {
            set
            {
                this.richTextBox1.Text = value;
            }
            get
            {
                return this.richTextBox1.Text; 
            }
        }

        private void tsbtnApplay_Click(object sender, EventArgs e)
        {
           
            if (ApplayAddText != null)
            {
                ApplayAddText(sender, e);
            }
           
        }

        private void tsbtnCancel_Click(object sender, EventArgs e)
        {

            this.TextResult = "";

            if (CancelAddText != null)
            {
                CancelAddText(sender, e);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (TextChanged != null)
            {
                TextChanged(sender, e);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = this.richTextBox1.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                this.FontText = fontDialog1.Font;

               // richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

       
    }
}
