using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms.OtherForms
{

    public enum RquestType
    { 
        View = 0 , 
        Edit = 1 , 
        New = 2,
        SelectItem = 3
    }


    public partial class frmAddEditView : SBNForm
    {

        public delegate bool VerifyEventHandler(Control sender, bool showMessage);

        public event VerifyEventHandler Verification;


        bool _showVerificationMessage = true;

        public bool ShowVerificationMessage
        {
            get { return _showVerificationMessage; }
            set { _showVerificationMessage = value; }
        }

        RquestType _mode = RquestType.New;

        public RquestType Mode
        {
            get { return _mode; }
            set 
            {
                _mode = value;

                switch (value)
                { 
                    case RquestType.Edit:
                        splitContainer1.Panel2Collapsed = false;
                        break;

                    case RquestType.New:
                        splitContainer1.Panel2Collapsed = false;
                        break;

                    case RquestType.View:
                        splitContainer1.Panel2Collapsed = true;
                        break;
                }
            }
        }



        Control _currentControl;

        public Control CurrentControl
        {
            get { return _currentControl; }
            set
            {

                _currentControl = value;

                if (value != null)
                {
                    Size = new Size(value.Size.Width + 10, value.Size.Height + 120);
                    value.Dock = DockStyle.Fill;
                    splitContainer1.Panel1.Controls.Add(value);
                }
            }
        }

        public frmAddEditView()
        {
            InitializeComponent();
        }

        private void BtnOkClick(object sender, EventArgs e)
        {

            if (Verification != null)
            { 
                if (Verification(this , ShowVerificationMessage))
                {
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {

            DialogResult = DialogResult.OK;
            }
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FrmAddEditViewLoad(object sender, EventArgs e)
        {

        }



        
    }
}
