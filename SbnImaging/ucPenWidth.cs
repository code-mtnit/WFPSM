using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Sbn.Controls.Imaging
{
    public partial class ucPenWidth : UserControl
    {

        float _SelectedPenWidth = 2;

        public float SelectedPenWidth
        {
            get
            {
                return _SelectedPenWidth;
            }
            set
            {
                if (value != _SelectedPenWidth)
                {
                    _SelectedPenWidth = value;
                    textBox1.Text = value.ToString();
                    try
                    {
                        this.tbPenW.Value = int.Parse(value.ToString());
                    }
                    catch
                    { 

                    }
                }
            }
        }

        public ucPenWidth()
        {
            InitializeComponent();
        }



        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.SelectedPenWidth = float.Parse(listView1.SelectedItems[0].Text);
            }
            catch (Exception ex)
            {

            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectedPenWidth = float.Parse(textBox1.Text);
            }
            
        }

        private void tbPenW_Scroll(object sender, EventArgs e)
        {
            try
            {
                this.SelectedPenWidth = float.Parse(tbPenW.Value.ToString());
            }
            catch (Exception ex)
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.SelectedPenWidth = float.Parse(textBox1.Text);
            }
            catch
            { }
        }
    }
}
