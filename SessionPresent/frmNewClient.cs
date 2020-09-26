using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using BaseClass;

namespace SessionPresent
{
    public partial class frmNewClient : Form
    {
        private ClientInfo CurrentClientInfo = null;
        public frmNewClient()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        public void FillObject(string strIP , string strName , string strHost)
        {
            this.txtIP.Text = strIP;
            this.txtName.Text = strName;
            this.textBox1.Text = strHost;


        }

        public void FillObject(ClientInfo cInfo)
        {
            CurrentClientInfo = cInfo;
            this.txtIP.Text = CurrentClientInfo.IP;
            this.txtName.Text = CurrentClientInfo.Name;
            this.textBox1.Text = CurrentClientInfo.HostName;


        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            
            {

                if (txtIP.Text.Length == 0)
                {
                    MessageBox.Show("IP can't be empty");
                }
                else if (txtName.Text.Length == 0)
                {
                    MessageBox.Show("Name can't be empty");
                }
                else if (!IsAddressValid(txtIP.Text))
                {
                    MessageBox.Show("The IP you entered is not valid");
                }
                else
                {
                    IPAddress address;
                    IPAddress.TryParse(txtIP.Text, out address);

                    if (CurrentClientInfo == null)
                    {
                        ((frmClientsList)Owner).AddNewClient(address.ToString(), txtName.Text);    
                    }
                    else
                    {
                        CurrentClientInfo.Name = txtName.Text;
                        ((frmClientsList)Owner).EditClient(address.ToString(), txtName.Text);
                    }

                    
                    Close();
                }
            }
        }

        public bool IsAddressValid(string addrString)
        {
            string pattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
            Regex reg = new Regex(pattern, RegexOptions.Singleline | RegexOptions.ExplicitCapture);
            return reg.IsMatch(addrString);
        }
    }
}