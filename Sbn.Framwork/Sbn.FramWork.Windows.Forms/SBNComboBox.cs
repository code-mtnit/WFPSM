using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms
{
	[ComVisible(false)]
	public class SBNComboBox : ComboBox
	{
		private IContainer components = null;

		private TextBox _textbox;

		private bool _isReadOnly;

		private bool _visible = true;

		[Browsable(true), Category("Behavior"), DefaultValue(false), Description("Controls whether the value in the combobox control can be changed or not")]
		public bool ReadOnly
		{
			get
			{
				return this._isReadOnly;
			}
			set
			{
				if (value != this._isReadOnly)
				{
					this._isReadOnly = value;
					this.ShowControl();
				}
			}
		}

		public new bool Visible
		{
			get
			{
				return this._visible;
			}
			set
			{
				this._visible = value;
				this.ShowControl();
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
			base.SuspendLayout();
		}

		public SBNComboBox()
		{
			this._textbox = new TextBox();
		}

		public new void Hide()
		{
			this.Visible = false;
		}

		public new void Show()
		{
			this.Visible = true;
		}

		private void AddTextbox()
		{
			this._textbox.ReadOnly = true;
			this._textbox.Location = base.Location;
			this._textbox.Size = base.Size;
			this._textbox.Dock = this.Dock;
			this._textbox.Anchor = this.Anchor;
			this._textbox.Enabled = base.Enabled;
			this._textbox.Visible = this.Visible;
			this._textbox.RightToLeft = this.RightToLeft;
			this._textbox.Font = this.Font;
			this._textbox.Text = this.Text;
			this._textbox.TabStop = base.TabStop;
			this._textbox.TabIndex = base.TabIndex;
		}

		private void ShowControl()
		{
			if (this._isReadOnly)
			{
				this._textbox.Visible = (this._visible && base.Enabled);
				base.Visible = (this._visible && !base.Enabled);
				this._textbox.Text = this.Text;
			}
			else
			{
				this._textbox.Visible = false;
				base.Visible = this._visible;
			}
		}

		protected override void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged(e);
			if (base.Parent != null)
			{
				this.AddTextbox();
			}
			this._textbox.Parent = base.Parent;
		}

		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			base.OnSelectedIndexChanged(e);
			if (base.SelectedItem == null)
			{
				this._textbox.Clear();
			}
			else
			{
				this._textbox.Text = base.SelectedItem.ToString();
			}
		}

		protected override void OnDropDownStyleChanged(EventArgs e)
		{
			base.OnDropDownStyleChanged(e);
			this._textbox.Text = this.Text;
		}

		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
			this._textbox.Font = this.Font;
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this._textbox.Size = base.Size;
		}

		protected override void OnDockChanged(EventArgs e)
		{
			base.OnDockChanged(e);
			this._textbox.Dock = this.Dock;
		}

		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			this.ShowControl();
		}

		protected override void OnRightToLeftChanged(EventArgs e)
		{
			base.OnRightToLeftChanged(e);
			this._textbox.RightToLeft = this.RightToLeft;
		}

		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			this._textbox.Text = this.Text;
		}

		protected override void OnLocationChanged(EventArgs e)
		{
			base.OnLocationChanged(e);
			this._textbox.Location = base.Location;
		}

		protected override void OnTabIndexChanged(EventArgs e)
		{
			base.OnTabIndexChanged(e);
			this._textbox.TabIndex = base.TabIndex;
		}
	}
}
