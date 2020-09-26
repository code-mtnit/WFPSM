using JThomas.Extensions;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms.MaskedCell
{
	[ToolboxBitmap(typeof(MaskedTextBox))]
	public class DataGridViewMaskedTextColumn : DataGridViewColumn
	{
		private static Type columnType = typeof(DataGridViewMaskedTextColumn);

		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override DataGridViewCell CellTemplate
		{
			get
			{
				return base.CellTemplate;
			}
			set
			{
				if (value != null && !(value is DataGridViewMaskedTextCell))
				{
					throw new InvalidCastException("DataGridView: WrongCellTemplateType, must be DataGridViewMaskedTextCell");
				}
				base.CellTemplate = value;
			}
		}

		[DefaultValue(1)]
		public new DataGridViewColumnSortMode SortMode
		{
			get
			{
				return base.SortMode;
			}
			set
			{
				base.SortMode = value;
			}
		}

		private DataGridViewMaskedTextCell MaskedTextCellTemplate
		{
			get
			{
				return (DataGridViewMaskedTextCell)this.CellTemplate;
			}
		}

		[ReferencedDescription(typeof(MaskedTextBox), "Mask"), Category("Masking")]
		public string Mask
		{
			get
			{
				if (this.MaskedTextCellTemplate == null)
				{
					throw new InvalidOperationException("DataGridViewColumn: CellTemplate required");
				}
				return this.MaskedTextCellTemplate.Mask;
			}
			set
			{
				if (this.Mask != value)
				{
					this.MaskedTextCellTemplate.Mask = value;
					if (base.DataGridView != null)
					{
						DataGridViewRowCollection rows = base.DataGridView.Rows;
						int count = rows.Count;
						for (int i = 0; i < count; i++)
						{
							DataGridViewMaskedTextCell dataGridViewMaskedTextCell = rows.SharedRow(i).Cells[base.Index] as DataGridViewMaskedTextCell;
							if (dataGridViewMaskedTextCell != null)
							{
								dataGridViewMaskedTextCell.Mask = value;
							}
						}
					}
				}
			}
		}

		public DataGridViewMaskedTextColumn() : this(string.Empty)
		{
		}

		public DataGridViewMaskedTextColumn(string maskString) : base(new DataGridViewMaskedTextCell())
		{
			this.SortMode = DataGridViewColumnSortMode.Automatic;
			this.Mask = maskString;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(64);
			stringBuilder.Append("DataGridViewMaskedTextColumn { Name=");
			stringBuilder.Append(base.Name);
			stringBuilder.Append(", Index=");
			stringBuilder.Append(base.Index.ToString());
			stringBuilder.Append(" }");
			return stringBuilder.ToString();
		}

		public override object Clone()
		{
			DataGridViewMaskedTextColumn dataGridViewMaskedTextColumn = (DataGridViewMaskedTextColumn)base.Clone();
			dataGridViewMaskedTextColumn.Mask = this.Mask;
			dataGridViewMaskedTextColumn.CellTemplate = (DataGridViewMaskedTextCell)this.CellTemplate.Clone();
			return dataGridViewMaskedTextColumn;
		}
	}
}
