using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms.MaskedCell
{
	public class DataGridViewMaskedTextCell : DataGridViewTextBoxCell
	{
		private static Type cellType = typeof(DataGridViewMaskedTextCell);

		private static Type valueType = typeof(string);

		private static Type editorType = typeof(DataGridViewMaskedTextEditingControl);

		private string mask;

		public override Type EditType
		{
			get
			{
				return DataGridViewMaskedTextCell.editorType;
			}
		}

		public override Type ValueType
		{
			get
			{
				return DataGridViewMaskedTextCell.valueType;
			}
		}

		public string Mask
		{
			get
			{
				return (this.mask == null) ? string.Empty : this.mask;
			}
			set
			{
				this.mask = value;
			}
		}

		public DataGridViewMaskedTextCell()
		{
			this.Mask = string.Empty;
		}

		public override object Clone()
		{
			DataGridViewMaskedTextCell dataGridViewMaskedTextCell = base.Clone() as DataGridViewMaskedTextCell;
			dataGridViewMaskedTextCell.Mask = this.Mask;
			return dataGridViewMaskedTextCell;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(64);
			stringBuilder.Append("DataGridViewMaskedTextCell { ColumnIndex=");
			stringBuilder.Append(base.ColumnIndex.ToString());
			stringBuilder.Append(", RowIndex=");
			stringBuilder.Append(base.RowIndex.ToString());
			stringBuilder.Append(" }");
			return stringBuilder.ToString();
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public override void DetachEditingControl()
		{
			DataGridView dataGridView = base.DataGridView;
			if (dataGridView == null || dataGridView.EditingControl == null)
			{
				throw new InvalidOperationException();
			}
			MaskedTextBox maskedTextBox = dataGridView.EditingControl as MaskedTextBox;
			if (maskedTextBox != null)
			{
				maskedTextBox.ClearUndo();
			}
			base.DetachEditingControl();
		}

		public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
		{
			base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
			DataGridViewMaskedTextEditingControl dataGridViewMaskedTextEditingControl = base.DataGridView.EditingControl as DataGridViewMaskedTextEditingControl;
			if (dataGridViewMaskedTextEditingControl != null)
			{
				if (base.Value == null || base.Value is DBNull)
				{
					dataGridViewMaskedTextEditingControl.Text = (string)this.DefaultNewRowValue;
				}
				else
				{
					dataGridViewMaskedTextEditingControl.Text = (string)base.Value;
				}
			}
		}
	}
}
