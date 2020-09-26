using Sbn.Products.GEP.GEPObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SessionPresent.Tools.SbnTools
{
    public partial class frmEditGovSessionInfo : Form
    {
        public frmEditGovSessionInfo()
        {
            InitializeComponent();
        }

        private GovSession CurrentObject = null;
        public void FillObject(GovSession govSession)
        {
            CurrentObject = govSession;
            txtTitle.Text = govSession.Title;
        }
        private void btnApplay_Click(object sender, EventArgs e)
        {
            CurrentObject.Title = txtTitle.Text;
            CurrentObject.GovReasonTitle = txtReason.Text;

            var govTemp = new GovSession
            {
                Title = txtTitle.Text,
                GovReasonTitle = txtReason.Text,
                SessionDate = CurrentObject.SessionDate,
                RegistrationDate = CurrentObject.RegistrationDate,
                SessionTime = CurrentObject.SessionTime
                
            };
            govTemp._PhysicalPath = CurrentObject._PhysicalPath;
            govTemp.Save(govTemp._PhysicalPath);

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}
