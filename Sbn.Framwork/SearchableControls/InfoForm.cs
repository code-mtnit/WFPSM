using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SearchableControls
{
	internal class InfoForm : Form
	{
		private IContainer components = null;

		private Button button1;

		private Label label1;

		public InfoForm(string text, Form owner)
		{
			base.Owner = owner;
			this.InitializeComponent();
			this.label1.Text = text;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			base.Close();
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
			this.button1 = new Button();
			this.label1 = new Label();
			base.SuspendLayout();
			this.button1.DialogResult = DialogResult.Cancel;
			this.button1.Location = new Point(86, 69);
			this.button1.Name = "button1";
			this.button1.Size = new Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new EventHandler(this.button1_Click);
			this.label1.Location = new Point(12, 21);
			this.label1.Name = "label1";
			this.label1.Size = new Size(212, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "label1";
			base.AcceptButton = this.button1;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.CancelButton = this.button1;
			base.ClientSize = new Size(236, 104);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.button1);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "InfoForm";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.ResumeLayout(false);
		}
	}
}
