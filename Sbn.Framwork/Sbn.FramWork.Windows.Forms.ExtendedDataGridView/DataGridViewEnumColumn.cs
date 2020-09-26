using System;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms.ExtendedDataGridView
{
	public class DataGridViewEnumColumn : DataGridViewTextBoxColumn
	{
		public DataGridViewEnumColumn()
		{
			this.CellTemplate = new DataGridViewEnumCell();
		}
	}
}
