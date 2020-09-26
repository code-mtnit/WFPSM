using Sbn.FramWork.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms.ExtendedDataGridView
{
	internal class PanelQuickSearch : UserControl
	{
		public delegate void SearchHandler(string search);

		private IContainer components = null;

		private TextBox txtToFind;

		private Label lblCol;

		private Label lblQuickFind;

		private Button btnClose;

		private Label lblOn;

		public event PanelQuickSearch.SearchHandler SearchChanged;

		public string Search
		{
			get
			{
				return this.txtToFind.Text;
			}
			set
			{
				this.txtToFind.Text = value;
			}
		}

		public string Column
		{
			get
			{
				return this.lblCol.Text;
			}
			set
			{
				this.lblCol.Text = value;
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
			this.txtToFind = new TextBox();
			this.lblCol = new Label();
			this.lblQuickFind = new Label();
			this.btnClose = new Button();
			this.lblOn = new Label();
			base.SuspendLayout();
			this.txtToFind.Location = new Point(56, 2);
			this.txtToFind.Name = "txtToFind";
			this.txtToFind.Size = new Size(172, 20);
			this.txtToFind.TabIndex = 0;
			this.txtToFind.TextChanged += new EventHandler(this.txtToFind_TextChanged);
			this.txtToFind.KeyDown += new KeyEventHandler(this.txtToFind_KeyDown);
			this.lblCol.AutoSize = true;
			this.lblCol.Location = new Point(261, 6);
			this.lblCol.Name = "lblCol";
			this.lblCol.Size = new Size(33, 13);
			this.lblCol.TabIndex = 2;
			this.lblCol.Text = "ستون";
			this.lblQuickFind.AutoSize = true;
			this.lblQuickFind.BackColor = SystemColors.ButtonShadow;
			this.lblQuickFind.Location = new Point(23, 6);
			this.lblQuickFind.Name = "lblQuickFind";
			this.lblQuickFind.Size = new Size(27, 13);
			this.lblQuickFind.TabIndex = 3;
			this.lblQuickFind.Text = "بیاب";
			this.lblQuickFind.TextAlign = ContentAlignment.MiddleLeft;
			this.btnClose.Dock = DockStyle.Left;
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatStyle = FlatStyle.Flat;
			this.btnClose.Image = Resources.delete;
			this.btnClose.Location = new Point(0, 0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new Size(17, 25);
			this.btnClose.TabIndex = 4;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.lblOn.AutoSize = true;
			this.lblOn.Location = new Point(234, 6);
			this.lblOn.Name = "lblOn";
			this.lblOn.Size = new Size(28, 13);
			this.lblOn.TabIndex = 5;
			this.lblOn.Text = "روی";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.BorderStyle = BorderStyle.FixedSingle;
			base.Controls.Add(this.lblCol);
			base.Controls.Add(this.lblOn);
			base.Controls.Add(this.txtToFind);
			base.Controls.Add(this.lblQuickFind);
			base.Controls.Add(this.btnClose);
			base.Name = "PanelQuickSearch";
			base.Size = new Size(402, 25);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public PanelQuickSearch()
		{
			this.InitializeComponent();
			this.Dock = DockStyle.Bottom;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			this.lblQuickFind.Location = new Point(this.btnClose.Right, this.GetY(this.lblQuickFind));
			this.txtToFind.Location = new Point(this.lblQuickFind.Right, this.GetY(this.txtToFind));
			this.lblOn.Location = new Point(this.txtToFind.Right, this.GetY(this.lblOn));
			this.lblCol.Location = new Point(this.lblOn.Right, this.GetY(this.lblCol));
		}

		private int GetY(Control control)
		{
			return (base.Height - control.Height) / 2;
		}

		private void txtToFind_TextChanged(object sender, EventArgs e)
		{
			this.OnSearchChanged(this.txtToFind.Text);
		}

		public void OnSearchChanged(string search)
		{
			if (this.SearchChanged != null)
			{
				this.SearchChanged(search);
			}
		}

		protected override void OnLeave(EventArgs e)
		{
			base.OnLeave(e);
			base.Hide();
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			this.txtToFind.Focus();
		}

		private void txtToFind_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Escape)
			{
				base.Hide();
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Hide();
		}
	}
}
