using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sbn.Windows.Forms.AdvancedControls.WaitForm
{
    public partial class LoadingForm : Form
    {

        bool _ShowPictureBox = false;

        public bool ShowPictureBox
        {
            get { return _ShowPictureBox; }
            set 
            {
                _ShowPictureBox = value;
                this.pictureBox1.Visible = value;
                this.loadingCircle1.Visible = !value;
            }
        }

        public LoadingForm()
        {
            InitializeComponent();
            
           
        }

       

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            loadingCircle1.Active = true;
            loadingCircle1.OuterCircleRadius = 30;
            loadingCircle1.InnerCircleRadius = 22;
            

        }

       
    }
}