using System;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms.ExtendedDataGridView
{
	public class DataGridViewExporter : AbstractDataGridViewExporter
	{
		public DataGridViewExporter(DataGridView grid) : base(grid, true)
		{
		}

		public DataGridViewExporter(DataGridView grid, bool exportVisibleColumnsOnly) : base(grid, exportVisibleColumnsOnly)
		{
		}

		public override bool IsExportableColumn(DataGridViewColumn column)
		{
			return !(column is DataGridViewButtonColumn) && !(column is DataGridViewImageColumn) && base.IsExportableColumn(column);
		}

		public override object CellFormat(DataGridViewCell cell)
		{
			string text = string.IsNullOrEmpty(cell.Style.Format) ? cell.OwningColumn.DefaultCellStyle.Format : cell.Style.Format;
			if (text.ToUpper() == "C" || text.ToUpper() == "C2")
			{
				text = "$0.00";
			}
			if (cell.Value is DateTime && text == "")
			{
				text = "d/mm/yyyy";
			}
			return text;
		}

		public override object CellValue(DataGridViewCell cell)
		{
			object result;
			if (cell is DataGridViewCheckBoxCell)
			{
				if (cell.Value is DBNull)
				{
					result = "Unknown";
					return result;
				}
				if (cell.FormattedValue is bool)
				{
					result = (((bool)cell.FormattedValue) ? "Yes" : "No");
					return result;
				}
				object falseValue = ((DataGridViewCheckBoxColumn)cell.DataGridView.Columns[cell.ColumnIndex]).FalseValue;
				if (falseValue != null)
				{
					result = (falseValue.Equals(cell.Value.ToString()) ? "No" : "Yes");
					return result;
				}
			}
			else if (DataGridViewExporter.IsNumeric(cell.Value) || cell.Value is DateTime)
			{
				result = cell.Value;
				return result;
			}
			result = cell.FormattedValue;
			return result;
		}

		private static bool IsNumeric(object value)
		{
			return value is int || value is double || value is float || value is decimal;
		}
	}
}
