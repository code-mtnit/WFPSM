

/// Demo form for marking errors (Scenarios found in transcription - quality check applications)

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WordInDOTNET
{
	/// <summary>
	/// Summary description for frmMarkError.
	/// </summary>
	public class frmMarkError : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox grpErrorWeight;
		private System.Windows.Forms.RadioButton rbMinor;
		private System.Windows.Forms.RadioButton rbMajor;
		private System.Windows.Forms.RadioButton rbCritical;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		public System.Windows.Forms.TextBox txtChanged;
		public System.Windows.Forms.TextBox txtOriginal;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMarkError()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtChanged = new System.Windows.Forms.TextBox();
			this.txtOriginal = new System.Windows.Forms.TextBox();
			this.grpErrorWeight = new System.Windows.Forms.GroupBox();
			this.rbCritical = new System.Windows.Forms.RadioButton();
			this.rbMajor = new System.Windows.Forms.RadioButton();
			this.rbMinor = new System.Windows.Forms.RadioButton();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.grpErrorWeight.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtChanged
			// 
			this.txtChanged.Location = new System.Drawing.Point(8, 88);
			this.txtChanged.Multiline = true;
			this.txtChanged.Name = "txtChanged";
			this.txtChanged.Size = new System.Drawing.Size(264, 56);
			this.txtChanged.TabIndex = 0;
			this.txtChanged.Text = "";
			// 
			// txtOriginal
			// 
			this.txtOriginal.Location = new System.Drawing.Point(8, 8);
			this.txtOriginal.Multiline = true;
			this.txtOriginal.Name = "txtOriginal";
			this.txtOriginal.ReadOnly = true;
			this.txtOriginal.Size = new System.Drawing.Size(264, 64);
			this.txtOriginal.TabIndex = 1;
			this.txtOriginal.Text = "";
			// 
			// grpErrorWeight
			// 
			this.grpErrorWeight.Controls.Add(this.rbCritical);
			this.grpErrorWeight.Controls.Add(this.rbMajor);
			this.grpErrorWeight.Controls.Add(this.rbMinor);
			this.grpErrorWeight.Location = new System.Drawing.Point(288, 8);
			this.grpErrorWeight.Name = "grpErrorWeight";
			this.grpErrorWeight.Size = new System.Drawing.Size(120, 112);
			this.grpErrorWeight.TabIndex = 2;
			this.grpErrorWeight.TabStop = false;
			this.grpErrorWeight.Text = "Error Weight";
			// 
			// rbCritical
			// 
			this.rbCritical.Location = new System.Drawing.Point(8, 80);
			this.rbCritical.Name = "rbCritical";
			this.rbCritical.TabIndex = 2;
			this.rbCritical.Text = "Critical";
			// 
			// rbMajor
			// 
			this.rbMajor.Location = new System.Drawing.Point(8, 48);
			this.rbMajor.Name = "rbMajor";
			this.rbMajor.TabIndex = 1;
			this.rbMajor.Text = "Major";
			// 
			// rbMinor
			// 
			this.rbMinor.Checked = true;
			this.rbMinor.Location = new System.Drawing.Point(8, 16);
			this.rbMinor.Name = "rbMinor";
			this.rbMinor.TabIndex = 0;
			this.rbMinor.TabStop = true;
			this.rbMinor.Text = "Minor";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(72, 160);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(240, 160);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmMarkError
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(424, 205);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.grpErrorWeight);
			this.Controls.Add(this.txtOriginal);
			this.Controls.Add(this.txtChanged);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmMarkError";
			this.Text = "frmMarkError";
			this.Load += new System.EventHandler(this.frmMarkError_Load);
			this.grpErrorWeight.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void frmMarkError_Load(object sender, System.EventArgs e)
		{
		
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
	}
}
