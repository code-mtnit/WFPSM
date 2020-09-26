using System;
using System.Reflection;

namespace Sbn.FramWork.Windows.Forms.ExtendedDataGridView
{
	public class Excel
	{
		public class Worksheet
		{
			private object m_worksheet;

			private Type m_type;

			private object m_cells;

			private PropertyInfo m_cellIndex;

			public string Name
			{
				get
				{
					return (string)this.m_type.GetProperty("Name").GetValue(this.m_worksheet, null);
				}
				set
				{
					this.m_type.GetProperty("Name").SetValue(this.m_worksheet, value, null);
				}
			}

			public Excel.Cell this[object row, object column]
			{
				get
				{
					return new Excel.Cell(this.m_cellIndex.GetValue(this.m_cells, new object[]
					{
						row,
						column
					}));
				}
			}

			public bool IsApplicationVisible
			{
				get
				{
					object value = this.m_type.GetProperty("Application").GetValue(this.m_worksheet, null);
					return (bool)Excel.s_assemblyExcel.GetType("Microsoft.Office.Interop.Excel._Application").GetProperty("Visible").GetValue(value, null);
				}
				set
				{
					object value2 = this.m_type.GetProperty("Application").GetValue(this.m_worksheet, null);
					Excel.s_assemblyExcel.GetType("Microsoft.Office.Interop.Excel._Application").GetProperty("Visible").SetValue(value2, value, null);
				}
			}

			public Worksheet()
			{
				object obj = Excel.s_assemblyExcel.GetType("Microsoft.Office.Interop.Excel.ApplicationClass").GetConstructor(new Type[0]).Invoke(new object[0]);
				object value = obj.GetType().GetProperty("Workbooks").GetValue(obj, null);
				object obj2 = Excel.s_assemblyExcel.GetType("Microsoft.Office.Interop.Excel.Workbooks").GetMethod("Add").Invoke(value, new object[]
				{
					Type.Missing
				});
				object value2 = obj2.GetType().GetProperty("Worksheets").GetValue(obj2, null);
				object worksheet = Excel.s_assemblyExcel.GetType("Microsoft.Office.Interop.Excel.Sheets").GetMethod("get_Item").Invoke(value2, new object[]
				{
					1
				});
				this.m_worksheet = worksheet;
				this.m_type = Excel.s_assemblyExcel.GetType("Microsoft.Office.Interop.Excel._Worksheet");
				this.m_cells = this.m_type.GetProperty("Cells").GetValue(this.m_worksheet, null);
				this.m_cellIndex = Excel.s_assemblyExcel.GetType("Microsoft.Office.Interop.Excel.Range").GetProperty("Item", new Type[]
				{
					typeof(int),
					typeof(int)
				});
			}

			public void Close()
			{
				object value = this.m_type.GetProperty("Application").GetValue(this.m_worksheet, null);
				Excel.s_assemblyExcel.GetType("Microsoft.Office.Interop.Excel._Application").GetMethod("Quit").Invoke(value, null);
			}
		}

		public class Cell
		{
			private static Type s_type;

			private static PropertyInfo s_value;

			private static PropertyInfo s_numberFormat;

			private static PropertyInfo s_font;

			private static PropertyInfo s_entireColumn;

			private static MethodInfo s_autoFit;

			private object m_range;

			public object Value
			{
				get
				{
					return Excel.Cell.s_value.GetValue(this.m_range, null);
				}
				set
				{
					Excel.Cell.s_value.SetValue(this.m_range, value, null);
				}
			}

			public object NumberFormat
			{
				get
				{
					return Excel.Cell.s_numberFormat.GetValue(this.m_range, null);
				}
				set
				{
					Excel.Cell.s_numberFormat.SetValue(this.m_range, value, null);
				}
			}

			public Excel.Font Font
			{
				get
				{
					return new Excel.Font(Excel.Cell.s_font.GetValue(this.m_range, null));
				}
			}

			static Cell()
			{
				Excel.Cell.s_type = Excel.s_assemblyExcel.GetType("Microsoft.Office.Interop.Excel.Range");
				Excel.Cell.s_value = Excel.Cell.s_type.GetProperty("Value2");
				Excel.Cell.s_numberFormat = Excel.Cell.s_type.GetProperty("NumberFormat");
				Excel.Cell.s_font = Excel.Cell.s_type.GetProperty("Font");
				Excel.Cell.s_entireColumn = Excel.Cell.s_type.GetProperty("EntireColumn");
				Excel.Cell.s_autoFit = Excel.Cell.s_type.GetMethod("AutoFit");
			}

			public Cell(object cell)
			{
				this.m_range = cell;
			}

			public void AutoFitEntireColumn()
			{
				object value = Excel.Cell.s_entireColumn.GetValue(this.m_range, null);
				Excel.Cell.s_autoFit.Invoke(value, null);
			}
		}

		public class Font
		{
			private static Type s_type;

			private static PropertyInfo s_bold;

			private object m_font;

			public bool Bold
			{
				get
				{
					return (bool)Excel.Font.s_bold.GetValue(this.m_font, null);
				}
				set
				{
					Excel.Font.s_bold.SetValue(this.m_font, value, null);
				}
			}

			static Font()
			{
				Excel.Font.s_type = Excel.s_assemblyExcel.GetType("Microsoft.Office.Interop.Excel.Font");
				Excel.Font.s_bold = Excel.Font.s_type.GetProperty("Bold");
			}

			public Font(object font)
			{
				this.m_font = font;
			}
		}

		private const string ASSEMBLY2003 = "Microsoft.Office.Interop.Excel, Version=11.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c";

		private static bool? s_isExcelInstalled;

		private static Assembly s_assemblyExcel;

		public static bool IsExcelInstalled
		{
			get
			{
				if (!Excel.s_isExcelInstalled.HasValue)
				{
					Excel.s_isExcelInstalled = new bool?(Excel.IsAssemblyInstalled("Microsoft.Office.Interop.Excel, Version=11.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c"));
				}
				return Excel.s_isExcelInstalled.Value;
			}
		}

		private static bool IsAssemblyInstalled(string assembly)
		{
			bool result;
			try
			{
				Excel.s_assemblyExcel = Assembly.Load(assembly);
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}
	}
}
