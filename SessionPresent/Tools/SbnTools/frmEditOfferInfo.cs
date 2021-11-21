using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sbn.Products.GEP.GEPObject;


namespace SessionPresent.Tools.SbnTools
{
    public partial class frmEditOfferInfo : Form
    {
        public frmEditOfferInfo()
        {
            InitializeComponent();

            try
            {
                txtOfficalCode.Font = new System.Drawing.Font("B Nazanin", 13, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                txtOrderIncat.Font = new System.Drawing.Font("B Nazanin", 13, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                txtOwnerOrgan.Font = new System.Drawing.Font("B Nazanin", 13, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                txtTitle.Font = new System.Drawing.Font("B Nazanin", 13, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));


            }
            catch
            {

            }
        }

        public Offer CurrentObject = null;
        public void FillObject(Offer off)
        {
            CurrentObject = off;
            txtOfficalCode.Text = off.OfficialCode;
            txtTitle.Text = off.Title;
            txtOrderIncat.Text = off.OrderInCatalogue.ToString();
            if (off.OwnerOrgan != null && off.OwnerOrgan.CorrelateOrgUnit != null)
                txtOwnerOrgan.Text = off.OwnerOrgan.CorrelateOrgUnit.Title;
        }

        private void btnApplay_Click(object sender, EventArgs e)
        {
            try {
                CurrentObject.Title = txtTitle.Text;

                CurrentObject.Title = CurrentObject.Title.Replace('۱', '1').Replace('۲', '2').Replace('۳', '3').Replace('۴', '4').Replace('۵', '5').Replace('۶', '6').Replace('۷', '7').Replace('۸', '8').Replace('۹', '9').Replace('۰', '0');

                if (CurrentObject.OwnerOrgan.CorrelateOrgUnit == null)
                {
                    CurrentObject.OwnerOrgan.CorrelateOrgUnit = new Sbn.Systems.WMC.WMCObject.OrgUnit();
                    CurrentObject.OwnerOrgan.CorrelateOrgUnit._PhysicalPath = CurrentObject.OwnerOrgan._PhysicalPath + "\\CorrelateOrgUnit";
                }

                CurrentObject.OwnerOrgan.CorrelateOrgUnit.Title = txtOwnerOrgan.Text;

                CurrentObject.OwnerOrgan.CorrelateOrgUnit.Save(CurrentObject.OwnerOrgan.CorrelateOrgUnit._PhysicalPath);

                int newOrder = CurrentObject.OrderInCatalogue;
                if (int.TryParse(txtOrderIncat.Text, out newOrder))
                {
                    CurrentObject.OrderInCatalogue = newOrder;
                }
                else
                {
                    MessageBox.Show("خطا در مقدار ردیف پیشنهاد در فهرست");
                    return;
                }

                var offTemp = new Offer
                {
                    Title = CurrentObject.Title,
                    OrderInCatalogue = CurrentObject.OrderInCatalogue,
                    RegisterDate = CurrentObject.RegisterDate,
                    RegistrationDate = CurrentObject.RegistrationDate,
                    OfficialCode = CurrentObject.OfficialCode
                };
                offTemp._PhysicalPath = CurrentObject._PhysicalPath;
                offTemp.Save(offTemp._PhysicalPath);

                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch
            {
                MessageBox.Show("خطا در ذخیره سازی تغییرات !");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
