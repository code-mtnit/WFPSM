using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms.ExtendedDataGridView
{
	public abstract class AbstractDataGridViewExporter
	{
		private DataGridView m_grid;

		private bool m_exportVisibleOnly;

		public bool ExportVisibleOnly
		{
			get
			{
				return this.m_exportVisibleOnly;
			}
			set
			{
				this.m_exportVisibleOnly = value;
			}
		}

		public static bool IsExcelInstalled
		{
			get
			{
				return Excel.IsExcelInstalled;
			}
		}

		protected AbstractDataGridViewExporter(DataGridView grid, bool exportVisibleColumnsOnly)
		{
			this.m_grid = grid;
			this.ExportVisibleOnly = exportVisibleColumnsOnly;
		}

		public string ToCSV(bool includeColumnHeaders)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (includeColumnHeaders)
			{
				this.ExportHeaders(stringBuilder);
			}
			this.ExportCells(stringBuilder);
			return stringBuilder.ToString();
		}

		private void ExportHeaders(StringBuilder csv)
		{
			string text = "";
			for (int i = 0; i < this.m_grid.ColumnCount; i++)
			{
				if (this.IsExportableColumn(i))
				{
					text = text + "," + this.m_grid.Columns[i].HeaderText;
				}
			}
			csv.AppendLine(text.Substring(1));
		}

		private void ExportCells(StringBuilder csv)
		{
			for (int i = 0; i < this.m_grid.RowCount; i++)
			{
				string text = "";
				for (int j = 0; j < this.m_grid.ColumnCount; j++)
				{
					if (this.IsExportableColumn(j))
					{
						text = text + "," + this.CellValue(this.m_grid[j, i]).ToString();
					}
				}
				csv.AppendLine(text.Substring(1));
			}
		}

		public void SaveAsCSV(bool incluedColumnHeaders)
		{
			this.SaveAsCSV(incluedColumnHeaders, this.m_grid.Name);
		}

		public void SaveAsCSV(bool incluedColumnHeaders, string filename)
		{
			this.m_grid.Invoke(new MethodInvoker(delegate
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.Filter = "Comma Separated Value (*.csv)|*.csv";
				saveFileDialog.FileName = filename;
				saveFileDialog.ValidateNames = true;
				if (saveFileDialog.ShowDialog(this.m_grid) == DialogResult.Cancel)
				{
					filename = null;
				}
				else
				{
					filename = saveFileDialog.FileName;
				}
			}));
			if (filename != null)
			{
				TextWriter textWriter = new StreamWriter(filename);
				textWriter.Write(this.ToCSV(incluedColumnHeaders));
				textWriter.Close();
			}
		}

		public Excel.Worksheet ToExcel()
		{
			bool enabled = this.m_grid.Enabled;
			this.m_grid.Invoke(new MethodInvoker(delegate
			{
				this.m_grid.Enabled = false;
			}));
			Excel.Worksheet worksheet = new Excel.Worksheet();
			this.SetWorksheetName(worksheet);
			this.ExportCells(worksheet);
			this.ExportHeaders(worksheet);
			try
			{
				if (enabled)
				{
					this.m_grid.Invoke(new MethodInvoker(delegate
					{
						this.m_grid.Enabled = true;
					}));
				}
			}
			catch
			{
			}
			return worksheet;
		}

		private void SetWorksheetName(Excel.Worksheet worksheet)
		{
			if (this.m_grid.Parent != null)
			{
				string text = this.m_grid.Parent.Text;
				string text2 = ":\\/?*[]";
				for (int i = 0; i < text2.Length; i++)
				{
					text = text.Replace(text2[i].ToString(), "");
				}
				if (text.Length > 31)
				{
					text = text.Substring(0, 28) + "...";
				}
				if (text != "")
				{
					worksheet.Name = text;
				}
			}
		}

		private void ExportCells(Excel.Worksheet worksheet)
		{
			int i = 0;
			int num = 1;
			while (i < this.m_grid.ColumnCount)
			{
				if (this.IsExportableColumn(i))
				{
					for (int j = 0; j < this.m_grid.RowCount; j++)
					{
						Excel.Cell cell = worksheet[j + 2, num];
						cell.Value = this.CellValue(this.m_grid[i, j]);
						this.SetCellFormat(cell, this.m_grid[i, j]);
					}
					num++;
				}
				i++;
			}
		}

		private void ExportHeaders(Excel.Worksheet worksheet)
		{
			int i = 0;
			int num = 1;
			while (i < this.m_grid.ColumnCount)
			{
				if (this.IsExportableColumn(i))
				{
					Excel.Cell cell = worksheet[1, num++];
					cell.Value = this.m_grid.Columns[i].HeaderText;
					cell.Font.Bold = true;
					cell.AutoFitEntireColumn();
				}
				i++;
			}
		}

		private bool IsExportableColumn(int columnIndex)
		{
			return this.IsExportableColumn(this.m_grid.Columns[columnIndex]);
		}

		public virtual bool IsExportableColumn(DataGridViewColumn column)
		{
			return !this.ExportVisibleOnly || column.Visible;
		}

		private void SetCellFormat(Excel.Cell excelCell, DataGridViewCell gridCell)
		{
			try
			{
				excelCell.NumberFormat = this.CellFormat(gridCell);
			}
			catch
			{
			}
		}

		public abstract object CellFormat(DataGridViewCell cell);

		public abstract object CellValue(DataGridViewCell cell);
	}
}
