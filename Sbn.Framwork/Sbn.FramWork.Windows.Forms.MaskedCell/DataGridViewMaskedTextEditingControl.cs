using System;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms.MaskedCell
{
	public class DataGridViewMaskedTextEditingControl : MaskedTextBox, IDataGridViewEditingControl
	{
		private DataGridView dataGridView;

		private bool valueChanged;

		private int rowIndex;

		public DataGridView EditingControlDataGridView
		{
			get
			{
				return this.dataGridView;
			}
			set
			{
				this.dataGridView = value;
			}
		}

		public object EditingControlFormattedValue
		{
			get
			{
				return this.Text;
			}
			set
			{
				if (value is string)
				{
					this.Text = (string)value;
				}
			}
		}

		public int EditingControlRowIndex
		{
			get
			{
				return this.rowIndex;
			}
			set
			{
				this.rowIndex = value;
			}
		}

		public bool EditingControlValueChanged
		{
			get
			{
				return this.valueChanged;
			}
			set
			{
				this.valueChanged = value;
			}
		}

		public Cursor EditingPanelCursor
		{
			get
			{
				return base.Cursor;
			}
		}

		public bool RepositionEditingControlOnValueChange
		{
			get
			{
				return false;
			}
		}

		public DataGridViewMaskedTextEditingControl()
		{
			base.Mask = string.Empty;
		}

		public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
		{
			this.Font = dataGridViewCellStyle.Font;
			DataGridViewMaskedTextCell dataGridViewMaskedTextCell = this.dataGridView.CurrentCell as DataGridViewMaskedTextCell;
			if (dataGridViewMaskedTextCell != null)
			{
				base.Mask = dataGridViewMaskedTextCell.Mask;
			}
		}

		public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
		{
			bool result;
			switch (key & Keys.KeyCode)
			{
			case Keys.End:
			case Keys.Home:
			case Keys.Left:
			case Keys.Right:
				result = true;
				return result;
			}
			result = false;
			return result;
		}

		public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
		{
			return this.EditingControlFormattedValue;
		}

		public void PrepareEditingControlForEdit(bool selectAll)
		{
			if (selectAll)
			{
				base.SelectAll();
			}
			else
			{
				base.SelectionStart = 0;
				this.SelectionLength = 0;
			}
		}

		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			this.EditingControlValueChanged = true;
			if (this.EditingControlDataGridView != null)
			{
				this.EditingControlDataGridView.CurrentCell.Value = this.Text;
			}
		}
	}
}
