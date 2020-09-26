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
    public partial class frmSessionOrderItemInfo : Form
    {
        public frmSessionOrderItemInfo()
        {
            InitializeComponent();
            try
            {
                txtOrderIncat.Font = new System.Drawing.Font("B Nazanin", 13, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                txtTitle.Font = new System.Drawing.Font("B Nazanin", 13, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));


            }
            catch
            {

            }
        }

        private Catalogue CurrentCatalogueObject = null;
        private GovPresentation CurrentPresentationObject = null;
        private PreSessionOrder CurrentPreSessionOrderObject = null;

        private SessionItemViewModel sivm = null;
        public void FillObject(ref SessionItemViewModel sessionItem)
        {
            sivm = sessionItem;
            if (sessionItem != null && sessionItem.Object is Catalogue)
            {
                CurrentCatalogueObject = (Catalogue)sessionItem.Object;
                txtTitle.Text = CurrentCatalogueObject.Title;
                txtOrderIncat.Text = CurrentCatalogueObject.OrderInSession.ToString();
            }
            else if (sessionItem != null && sessionItem.Object is GovPresentation)
            {
                CurrentPresentationObject = (GovPresentation)sessionItem.Object;
                txtTitle.Text = CurrentPresentationObject.Title;
                txtOrderIncat.Text = CurrentPresentationObject.OrderInSession.ToString();
            }
            else if (sessionItem != null && sessionItem.Object is PreSessionOrder)
            {
                CurrentPreSessionOrderObject = (PreSessionOrder)sessionItem.Object;
                txtTitle.Text = CurrentPreSessionOrderObject.Title;
                txtOrderIncat.Text = CurrentPreSessionOrderObject.OrderInSession.ToString();
            }
            else if (sessionItem != null && sessionItem.Object is Offer)
            {
                CurrentCatalogueObject = new Catalogue();
                CurrentCatalogueObject.OrderInSession = (int)sessionItem.Order;
                CurrentCatalogueObject.Title = sessionItem.Title;
                CurrentCatalogueObject.TitleBackColor = sessionItem.BackColor;
                CurrentCatalogueObject.TitleForeColor = sessionItem.TitleForeColor;
                string[] p = ((Offer)sessionItem.Object)._PhysicalPath.Split('\\');
                string pPath = "";
                foreach(string s in p)
                {
                    pPath += s + "\\";
                    if (s.Contains("Catalogue_"))
                    {
                        break;

                    }
                }
                CurrentCatalogueObject._PhysicalPath = pPath;

                txtTitle.Text = CurrentCatalogueObject.Title;
                txtOrderIncat.Text = CurrentCatalogueObject.OrderInSession.ToString();
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

            if (CurrentCatalogueObject != null)
            {
                CurrentCatalogueObject.Title = txtTitle.Text;



                int newOrder = CurrentCatalogueObject.OrderInSession;
                if (int.TryParse(txtOrderIncat.Text, out newOrder))
                {
                    CurrentCatalogueObject.OrderInSession = newOrder;
                    sivm.Order = newOrder;
                }
                else
                {
                    MessageBox.Show("خطا در مقدار ردیف ");
                    return;
                }

                var offTemp = new Catalogue
                {
                    Title = txtTitle.Text,
                    OrderInSession = CurrentCatalogueObject.OrderInSession,
                    TitleBackColor = CurrentCatalogueObject.TitleBackColor,
                    TitleForeColor = CurrentCatalogueObject.TitleForeColor
                };

                sivm.Title = offTemp.Title;
                offTemp._PhysicalPath = CurrentCatalogueObject._PhysicalPath;
                offTemp.Save(offTemp._PhysicalPath);
            }

            if (CurrentPresentationObject != null)
            {
                CurrentPresentationObject.Title = txtTitle.Text;

                int newOrder = CurrentPresentationObject.OrderInSession;
                if (int.TryParse(txtOrderIncat.Text, out newOrder))
                {
                    CurrentPresentationObject.OrderInSession = newOrder;
                    sivm.Order = newOrder;
                }
                else
                {
                    MessageBox.Show("خطا در مقدار ردیف ");
                    return;
                }

                var offTemp = new GovPresentation
                {
                    Title = txtTitle.Text,
                    OrderInSession = CurrentPresentationObject.OrderInSession,
                    TitleBackColor = CurrentPresentationObject.TitleBackColor,
                    TitleForeColor = CurrentPresentationObject.TitleForeColor
                };
                sivm.Title = offTemp.Title;

                offTemp._PhysicalPath = CurrentPresentationObject._PhysicalPath;
                offTemp.Save(offTemp._PhysicalPath);
            }


            if (CurrentPreSessionOrderObject != null)
            {
                CurrentPreSessionOrderObject.Title = txtTitle.Text;

                int newOrder = CurrentPreSessionOrderObject.OrderInSession;
                if (int.TryParse(txtOrderIncat.Text, out newOrder))
                {
                    CurrentPreSessionOrderObject.OrderInSession = newOrder;
                    sivm.Order = newOrder;
                }
                else
                {
                    MessageBox.Show("خطا در مقدار ردیف ");
                    return;
                }

                var offTemp = new GovPresentation
                {
                    Title = txtTitle.Text,
                    OrderInSession = CurrentPreSessionOrderObject.OrderInSession,
                    TitleBackColor = CurrentPreSessionOrderObject.TitleBackColor,
                    TitleForeColor = CurrentPreSessionOrderObject.TitleForeColor
                };
                sivm.Title = offTemp.Title;

                offTemp._PhysicalPath = CurrentPreSessionOrderObject._PhysicalPath;
                offTemp.Save(offTemp._PhysicalPath);
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
