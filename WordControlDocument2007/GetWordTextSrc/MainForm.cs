#region Copyright (c) 2006-2008 Cellbi
/*
Cellbi Software Component Product
Copyright (c) 2006-2008 Cellbi
www.cellbi.com

Redistribution and use in source and binary forms, with or without modification,
are permitted provided that the following conditions are met:

	1.	Redistributions of source code must retain the above copyright notice,
			this list of conditions and the following disclaimer.

	2.	Redistributions in binary form must reproduce the above copyright notice,
			this list of conditions and the following disclaimer in the documentation
			and/or other materials provided with the distribution.

	3.	The names of the authors may not be used to endorse or promote products derived
			from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED “AS IS” AND ANY EXPRESSED OR IMPLIED WARRANTIES,
INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL CELLBI
OR ANY CONTRIBUTORS TO THIS SOFTWARE BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA,
OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE,
EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
#endregion

using System;
using System.IO;
using System.Windows.Forms;

using Sbn.Words.GetDocText.Doc;

namespace Sbn.Words.GetDocText
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
    // private fields ...
    private System.Windows.Forms.TextBox edPath;
    private System.Windows.Forms.Label lblPath;
    private System.Windows.Forms.Button btnOpen;
    private System.Windows.Forms.RichTextBox rtbText;
    private System.Windows.Forms.OpenFileDialog dlgOpenFile;
		private System.ComponentModel.Container components = null;

    // constructors ...
    #region MainForm
		public MainForm()
		{
			InitializeComponent();
		}
    #endregion
    #region Dispose
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
    #endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.edPath = new System.Windows.Forms.TextBox();
      this.lblPath = new System.Windows.Forms.Label();
      this.btnOpen = new System.Windows.Forms.Button();
      this.rtbText = new System.Windows.Forms.RichTextBox();
      this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
      this.SuspendLayout();
      // 
      // edPath
      // 
      this.edPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
      this.edPath.Location = new System.Drawing.Point(80, 16);
      this.edPath.Name = "edPath";
      this.edPath.Size = new System.Drawing.Size(232, 20);
      this.edPath.TabIndex = 0;
      this.edPath.Text = "";
      // 
      // lblPath
      // 
      this.lblPath.AutoSize = true;
      this.lblPath.Location = new System.Drawing.Point(8, 16);
      this.lblPath.Name = "lblPath";
      this.lblPath.Size = new System.Drawing.Size(54, 16);
      this.lblPath.TabIndex = 1;
      this.lblPath.Text = "File path :";
      // 
      // btnOpen
      // 
      this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btnOpen.Location = new System.Drawing.Point(320, 15);
      this.btnOpen.Name = "btnOpen";
      this.btnOpen.Size = new System.Drawing.Size(64, 23);
      this.btnOpen.TabIndex = 2;
      this.btnOpen.Text = "Open";
      this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
      // 
      // rtbText
      // 
      this.rtbText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
      this.rtbText.Location = new System.Drawing.Point(8, 48);
      this.rtbText.Name = "rtbText";
      this.rtbText.Size = new System.Drawing.Size(376, 211);
      this.rtbText.TabIndex = 3;
      this.rtbText.Text = "";
      // 
      // dlgOpenFile
      // 
      this.dlgOpenFile.DefaultExt = "doc";
      this.dlgOpenFile.Filter = "Doc files|*.doc";
      this.dlgOpenFile.Title = "Open *.doc file";
      // 
      // MainForm
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(392, 271);
      this.Controls.Add(this.rtbText);
      this.Controls.Add(this.btnOpen);
      this.Controls.Add(this.lblPath);
      this.Controls.Add(this.edPath);
      this.MinimumSize = new System.Drawing.Size(400, 300);
      this.Name = "MainForm";
      this.Text = "View text";
      this.ResumeLayout(false);

    }
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.EnableVisualStyles();
			Application.Run(new MainForm());
		}

    // private methods ...    

    // event handlers ...
    private void btnOpen_Click(object sender, System.EventArgs e)
    {
      DialogResult dialogResult = dlgOpenFile.ShowDialog();
      if (dialogResult != DialogResult.OK && dialogResult != DialogResult.Yes)
        return;

      edPath.Clear();
      rtbText.Clear();

      string text;
      TextLoader loader = new TextLoader(dlgOpenFile.FileName);
      if (!loader.LoadText(out text))
        return;

      edPath.Text = dlgOpenFile.FileName;
      rtbText.Text = text;
    }
	}
}