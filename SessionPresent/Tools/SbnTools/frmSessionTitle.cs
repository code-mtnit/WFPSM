using Sbn.Products.GEP.GEPObject;
using SessionPresent.ViewModel;
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
    public partial class frmSessionTitle : Form
    {
        public frmSessionTitle()
        {
            InitializeComponent();
            try
            {
                txtTitle.Font = new System.Drawing.Font("B Nazanin", 13, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));


            }
            catch
            {

            }
        }

        private GovSession CurrentSessionObject = null;
        private GovPresentation CurrentPresentationObject = null;

        MainViewModel _mvm;
        public void FillObject(GovSession sessionItem , MainViewModel mvm)
        {
            _mvm = mvm;
            if (sessionItem != null )
            {
                CurrentSessionObject = sessionItem;
                txtTitle.Text = CurrentSessionObject.Title;
            }
        }

        private void frmSessionOrderItemInfo_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApplay_Click(object sender, EventArgs e)
        {

            if (CurrentSessionObject != null)
            {
                CurrentSessionObject.Title = txtTitle.Text.Replace("\r\n", " ");

                _mvm.MainTitle = txtTitle.Text;

                var offTemp = new GovSession
                {
                    Title = txtTitle.Text.Replace("\r\n", "#"),
                    SessionDate = CurrentSessionObject.SessionDate
                };

                offTemp._PhysicalPath = CurrentSessionObject._PhysicalPath;
                offTemp.Save(offTemp._PhysicalPath);
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
