using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms.OtherForms
{
	public class frmAddEditView : SBNForm
	{
		public delegate bool VerifyEventHandler(Control sender, bool showMessage);

		private IContainer components = null;

		private SBNButton btnCancel;

		private SBNButton btnOk;

		private SplitContainer splitContainer1;

		private bool _showVerificationMessage = true;

		private RquestType _mode = RquestType.New;

		private Control _currentControl;

		public event frmAddEditView.VerifyEventHandler Verification;

		public bool ShowVerificationMessage
		{
			get
			{
				return this._showVerificationMessage;
			}
			set
			{
				this._showVerificationMessage = value;
			}
		}

		public RquestType Mode
		{
			get
			{
				return this._mode;
			}
			set
			{
				this._mode = value;
				switch (value)
				{
				case RquestType.View:
					this.splitContainer1.Panel2Collapsed = true;
					break;
				case RquestType.Edit:
					this.splitContainer1.Panel2Collapsed = false;
					break;
				case RquestType.New:
					this.splitContainer1.Panel2Collapsed = false;
					break;
				}
			}
		}

		public Control CurrentControl
		{
			get
			{
				return this._currentControl;
			}
			set
			{
				this._currentControl = value;
				if (value != null)
				{
					base.Size = new Size(value.Size.Width + 10, value.Size.Height + 120);
					value.Dock = DockStyle.Fill;
					this.splitContainer1.Panel1.Controls.Add(value);
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.btnCancel = new SBNButton();
			this.btnOk = new SBNButton();
			this.splitContainer1 = new SplitContainer();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			base.SuspendLayout();
			this.btnCancel.BackColor = Color.Transparent;
			this.btnCancel.ButtonText = "انصراف";
			this.btnCancel.CornerRadius = 2;
			this.btnCancel.Location = new Point(118, 14);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new Size(100, 32);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "sbnButton2";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new EventHandler(this.BtnCancelClick);
			this.btnOk.BackColor = Color.Transparent;
			this.btnOk.ButtonText = "تأیید";
			this.btnOk.CornerRadius = 2;
			this.btnOk.Location = new Point(12, 14);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new Size(100, 32);
			this.btnOk.TabIndex = 0;
			this.btnOk.Text = "sbnButton1";
			this.btnOk.UseVisualStyleBackColor = false;
			this.btnOk.Click += new EventHandler(this.BtnOkClick);
			this.splitContainer1.Dock = DockStyle.Fill;
			this.splitContainer1.FixedPanel = FixedPanel.Panel2;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = Orientation.Horizontal;
			this.splitContainer1.Panel1.AutoScroll = true;
			this.splitContainer1.Panel1.RightToLeft = RightToLeft.Yes;
			this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
			this.splitContainer1.Panel2.Controls.Add(this.btnOk);
			this.splitContainer1.Panel2.RightToLeft = RightToLeft.Yes;
			this.splitContainer1.Size = new Size(571, 420);
			this.splitContainer1.SplitterDistance = 357;
			this.splitContainer1.TabIndex = 0;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(571, 420);
			base.Controls.Add(this.splitContainer1);
			base.Name = "frmAddEditView";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "";
			base.Load += new EventHandler(this.FrmAddEditViewLoad);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		public frmAddEditView()
		{
			this.InitializeComponent();
		}

		private void BtnOkClick(object sender, EventArgs e)
		{
			if (this.Verification != null)
			{
				if (this.Verification(this, this.ShowVerificationMessage))
				{
					base.DialogResult = DialogResult.OK;
				}
			}
			else
			{
				base.DialogResult = DialogResult.OK;
			}
		}

		private void BtnCancelClick(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void FrmAddEditViewLoad(object sender, EventArgs e)
		{
		}
	}
}
