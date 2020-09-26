using Sbn.FramWork.Properties;
using Sbn.FramWork.Windows.Forms.ExtendedDataGridView;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms
{
	[Designer(typeof(ExtendedDataGridViewDesigner))]
	public class SBNDataGridView : DataGridView
	{
		private const string EXPORT_TO_EXCEL = "&Export to Excel";

		private const string EXPORT_TO_CSV = "&Export to CSV";

		private const string TemplateSetting = "&تنظیمات";

		private const string SEARCH = "&Search";

		private SBNListView sbnListView1;

		private ImageList imageList1;

		private View _viewMode = View.Details;

		private bool _visible = true;

		private string FullName = "";

		private DataGridViewTextBoxColumn clmnRowOrder;

		private bool _viewRowOrder = false;

		private Size _imageSize = new Size(32, 32);

		private int _mainColumnIndex = 0;

		private int _imageColumnIndex = 0;

		private bool m_allowAddRemoveColumns = true;

		private bool m_exportVisibleColumnsOnly = true;

		private ContextMenuStrip menuColumnHeader;

		private PanelQuickSearch m_pnlQuickSearch;

		public event EventHandler WorkStart;

		public event EventHandler WorkFinished;

		public bool ViewRowOrder
		{
			get
			{
				return this._viewRowOrder;
			}
			set
			{
				this._viewRowOrder = value;
				if (value)
				{
					if (this.clmnRowOrder == null)
					{
						this.clmnRowOrder = new DataGridViewTextBoxColumn();
						this.clmnRowOrder.Name = "clmnRowOrder";
						this.clmnRowOrder.HeaderText = "ردیف";
						this.clmnRowOrder.SortMode = DataGridViewColumnSortMode.Automatic;
						this.clmnRowOrder.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
						this.clmnRowOrder.Width = 30;
						this.clmnRowOrder.ReadOnly = true;
						this.clmnRowOrder.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						this.Columns.Insert(0, this.clmnRowOrder);
					}
					else
					{
						this.clmnRowOrder.Visible = true;
					}
				}
				else if (this.clmnRowOrder != null)
				{
					this.clmnRowOrder.Visible = false;
				}
			}
		}

		[Browsable(true), Category("Behavior"), DefaultValue(View.Details), Description("نحوه نمایش اطلاعات")]
		public View ViewMode
		{
			get
			{
				return this._viewMode;
			}
			set
			{
				this._viewMode = value;
				this.sbnListView1.View = value;
				this.ShowControl();
				this.Refresh();
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

		public Size ImageSize
		{
			get
			{
				return this._imageSize;
			}
			set
			{
				if (this.imageList1 != null)
				{
					this.imageList1.ImageSize = value;
					this._imageSize = value;
				}
			}
		}

		[Description("ستون اصلی به منظور نمایش عنوان آیتم در حالت ها مشاهده ای دیگر")]
		public int MainColumnIndex
		{
			get
			{
				return this._mainColumnIndex;
			}
			set
			{
				if (value + 1 > this.Columns.Count)
				{
					value = this._mainColumnIndex;
				}
				this._mainColumnIndex = value;
				this.Refresh();
			}
		}

		[Description("ستون اصلی به منظور آیکون آیتم در حالت ها مشاهده ای دیگر")]
		public int ImageColumnIndex
		{
			get
			{
				return this._imageColumnIndex;
			}
			set
			{
				if (value + 1 > this.Columns.Count)
				{
					value = 0;
				}
				this._imageColumnIndex = value;
				this.Refresh();
			}
		}

		[DefaultValue(true)]
		public bool AllowAddRemoveColumns
		{
			get
			{
				return this.m_allowAddRemoveColumns;
			}
			set
			{
				this.m_allowAddRemoveColumns = value;
			}
		}

		[DefaultValue(true)]
		public bool ExportVisibleColumnsOnly
		{
			get
			{
				return this.m_exportVisibleColumnsOnly;
			}
			set
			{
				this.m_exportVisibleColumnsOnly = value;
			}
		}

		[Editor(typeof(ExtendedDataGridViewColumnCollectionEditor), typeof(UITypeEditor))]
		public new DataGridViewColumnCollection Columns
		{
			get
			{
				return base.Columns;
			}
		}

		public SBNDataGridView()
		{
			this.sbnListView1 = new SBNListView();
			this.imageList1 = new ImageList();
			this.imageList1.ColorDepth = ColorDepth.Depth32Bit;
			this.imageList1.ImageSize = new Size(32, 32);
			this.imageList1.TransparentColor = Color.Transparent;
			this.InitializeComponent();
			this.SetupContextMenu();
			base.MultiSelectChanged += new EventHandler(this.SBNDataGridViewMultiSelectChanged);
		}

		private void InitializeComponent()
		{
			((ISupportInitialize)this).BeginInit();
			base.SuspendLayout();
			base.AllowUserToAddRows = false;
			base.AllowUserToDeleteRows = false;
			base.AllowUserToOrderColumns = true;
			base.BackgroundColor = Color.White;
			this.RightToLeft = RightToLeft.Yes;
			((ISupportInitialize)this).EndInit();
			base.ResumeLayout(false);
		}

		public virtual void OnWorkStart(object sender, EventArgs e)
		{
			if (this.WorkStart != null)
			{
				this.WorkStart(sender, e);
			}
		}

		public virtual void OnWorkFinished(object sender, EventArgs e)
		{
			if (this.WorkFinished != null)
			{
				this.WorkFinished(sender, e);
			}
		}

		public void ToExcel()
		{
			new Thread(delegate
			{
				this.OnWorkStart(this, new EventArgs());
				if (AbstractDataGridViewExporter.IsExcelInstalled)
				{
					Excel.Worksheet worksheet = new DataGridViewExporter(this, this.ExportVisibleColumnsOnly).ToExcel();
					worksheet.IsApplicationVisible = true;
				}
				this.OnWorkFinished(this, new EventArgs());
			}).Start();
		}

		public void ToCsv()
		{
			new Thread(delegate
			{
				this.OnWorkStart(this, new EventArgs());
				new DataGridViewExporter(this).SaveAsCSV(true);
				this.OnWorkFinished(this, new EventArgs());
			}).Start();
		}

		private string GetFullName()
		{
			return this.GetParentFullName(this);
		}

		private string GetParentFullName(Control ctrl)
		{
			string text = ctrl.Name;
			if (ctrl.Parent != null)
			{
				text += this.GetParentFullName(ctrl.Parent);
			}
			return text;
		}

		public void SetColumnOrder()
		{
			try
			{
				if (gfDataGridViewSetting.Default.ColumnOrder.ContainsKey(this.FullName))
				{
					if (!string.IsNullOrEmpty(this.FullName))
					{
						List<ColumnOrderItem> list = gfDataGridViewSetting.Default.ColumnOrder[this.FullName];
						if (list != null)
						{
							IOrderedEnumerable<ColumnOrderItem> orderedEnumerable = from i in list
							orderby i.DisplayIndex
							select i;
							foreach (ColumnOrderItem current in orderedEnumerable)
							{
								if (current.Name != null && this.Columns.Contains(current.Name))
								{
									if (current.DisplayIndex < this.Columns.Count)
									{
										this.Columns[current.Name].DisplayIndex = current.DisplayIndex;
										this.Columns[current.Name].Visible = current.Visible;
										this.Columns[current.Name].Width = current.Width;
									}
								}
							}
						}
					}
				}
			}
			catch (Exception var_3_161)
			{
			}
		}

		public void SaveColumnOrder()
		{
			try
			{
				if (base.AllowUserToOrderColumns)
				{
					List<ColumnOrderItem> list = new List<ColumnOrderItem>();
					DataGridViewColumnCollection columns = this.Columns;
					for (int i = 0; i < columns.Count; i++)
					{
						list.Add(new ColumnOrderItem
						{
							Name = columns[i].Name,
							ColumnIndex = i,
							DisplayIndex = columns[i].DisplayIndex,
							Visible = columns[i].Visible,
							Width = columns[i].Width
						});
					}
					if (gfDataGridViewSetting.Default.ColumnOrder.ContainsKey(this.FullName))
					{
						gfDataGridViewSetting.Default.ColumnOrder[this.FullName] = list;
						gfDataGridViewSetting.Default.Save();
					}
					else
					{
						gfDataGridViewSetting.Default.ColumnOrder.Add(this.FullName, list);
						gfDataGridViewSetting.Default.Save();
					}
				}
			}
			catch (Exception)
			{
			}
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			this.FullName = this.GetFullName();
			this.SetColumnOrder();
		}

		protected override void Dispose(bool disposing)
		{
			this.SaveColumnOrder();
			base.Dispose(disposing);
		}

		protected override void OnRowsAdded(DataGridViewRowsAddedEventArgs e)
		{
			base.OnRowsAdded(e);
			this.Refresh();
		}

		protected override void OnRowsRemoved(DataGridViewRowsRemovedEventArgs e)
		{
			base.OnRowsRemoved(e);
			this.Refresh();
		}

		private void SBNDataGridViewMultiSelectChanged(object sender, EventArgs e)
		{
			this.sbnListView1.MultiSelect = base.MultiSelect;
		}

		public new void Hide()
		{
			this.Visible = false;
		}

		public new void Show()
		{
			this.Visible = true;
		}

		private void AddListView()
		{
			this.sbnListView1.Location = base.Location;
			this.sbnListView1.Size = base.Size;
			this.sbnListView1.Dock = this.Dock;
			this.sbnListView1.Anchor = this.Anchor;
			this.sbnListView1.Enabled = base.Enabled;
			this.sbnListView1.Visible = this.Visible;
			this.sbnListView1.RightToLeft = this.RightToLeft;
			this.sbnListView1.RightToLeftLayout = (this.sbnListView1.RightToLeft == this.RightToLeft);
			this.sbnListView1.Font = this.Font;
			this.sbnListView1.Text = this.Text;
			this.sbnListView1.TabStop = base.TabStop;
			this.sbnListView1.TabIndex = base.TabIndex;
			this.sbnListView1.LargeImageList = this.imageList1;
			this.sbnListView1.SmallImageList = this.imageList1;
			this.sbnListView1.StateImageList = this.imageList1;
			this.sbnListView1.UseCompatibleStateImageBehavior = false;
			this.sbnListView1.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(this.sbnListView1_ItemSelectionChanged);
			this.sbnListView1.MouseDoubleClick += new MouseEventHandler(this.sbnListView1_MouseDoubleClick);
			this.sbnListView1.Click += new EventHandler(this.sbnListView1_Click);
			this.sbnListView1.MouseDown += new MouseEventHandler(this.sbnListView1_MouseDown);
			this.sbnListView1.MouseClick += new MouseEventHandler(this.sbnListView1_MouseClick);
			this.sbnListView1.SelectedIndexChanged += new EventHandler(this.sbnListView1_SelectedIndexChanged);
		}

		private void sbnListView1_MouseDown(object sender, MouseEventArgs e)
		{
		}

		private void sbnListView1_MouseClick(object sender, MouseEventArgs e)
		{
			ListViewItem itemAt = this.sbnListView1.GetItemAt(e.X, e.Y);
			DataGridViewRow dataGridViewRow = itemAt.Tag as DataGridViewRow;
			MouseEventArgs e2 = new MouseEventArgs(e.Button, e.Clicks, dataGridViewRow.AccessibilityObject.Bounds.X, dataGridViewRow.AccessibilityObject.Bounds.Y, e.Delta);
			this.OnMouseClick(e2);
		}

		private void sbnListView1_Click(object sender, EventArgs e)
		{
		}

		private void ShowControl()
		{
			if (this._viewMode != View.Details)
			{
				this.FillListViewItems();
				this.sbnListView1.Visible = (this._visible && base.Enabled);
				this.sbnListView1.Focus();
				this.sbnListView1.BringToFront();
			}
			else
			{
				this.sbnListView1.Visible = false;
				base.Visible = this._visible;
			}
		}

		protected override void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged(e);
			if (base.Parent != null)
			{
				this.AddListView();
			}
			this.sbnListView1.Parent = base.Parent;
			if (this.ViewMode != View.Details)
			{
				this.sbnListView1.BringToFront();
			}
		}

		protected override void OnRowEnter(DataGridViewCellEventArgs e)
		{
			base.OnRowEnter(e);
		}

		protected override void OnSelectionChanged(EventArgs e)
		{
			base.OnSelectionChanged(e);
		}

		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
			this.sbnListView1.Font = this.Font;
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.sbnListView1.Size = base.Size;
		}

		protected override void OnDockChanged(EventArgs e)
		{
			base.OnDockChanged(e);
			this.sbnListView1.Dock = this.Dock;
		}

		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			this.ShowControl();
		}

		protected override void OnRightToLeftChanged(EventArgs e)
		{
			base.OnRightToLeftChanged(e);
			this.sbnListView1.RightToLeft = this.RightToLeft;
		}

		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			this.sbnListView1.Text = this.Text;
		}

		protected override void OnLocationChanged(EventArgs e)
		{
			base.OnLocationChanged(e);
			this.sbnListView1.Location = base.Location;
		}

		protected override void OnTabIndexChanged(EventArgs e)
		{
			base.OnTabIndexChanged(e);
			this.sbnListView1.TabIndex = base.TabIndex;
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right || e.Location.Y >= base.ColumnHeadersHeight)
			{
				base.OnMouseClick(e);
			}
		}

		protected override void OnRowPrePaint(DataGridViewRowPrePaintEventArgs e)
		{
			if (this.ViewRowOrder && this.clmnRowOrder != null)
			{
				base.Rows[e.RowIndex].Cells[this.clmnRowOrder.Index].Value = e.RowIndex + 1;
			}
			base.OnRowPrePaint(e);
		}

		protected override void OnCurrentCellChanged(EventArgs e)
		{
			base.OnCurrentCellChanged(e);
			if (Control.MouseButtons != MouseButtons.Left)
			{
				foreach (ListViewItem listViewItem in this.sbnListView1.Items)
				{
					if (base.CurrentCell != null && ((DataGridViewRow)listViewItem.Tag).Index == base.CurrentCell.RowIndex)
					{
						listViewItem.Selected = true;
					}
					else
					{
						listViewItem.Selected = false;
					}
				}
			}
		}

		private void sbnListView1_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		public override void Refresh()
		{
			base.Refresh();
			this.FillListViewItems();
		}

		private void sbnListView1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.OnMouseDoubleClick(e);
		}

		private void sbnListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (this.ViewMode != View.Details && ((DataGridViewRow)e.Item.Tag).DataGridView != null)
			{
				this.SetSelectedRowCore(((DataGridViewRow)e.Item.Tag).Index, e.IsSelected);
				if (e.IsSelected)
				{
					try
					{
						this.SetCurrentCellAddressCore(0, ((DataGridViewRow)e.Item.Tag).Index, true, true, false);
					}
					catch (Exception)
					{
					}
					DataGridViewCellEventArgs e2 = new DataGridViewCellEventArgs(0, ((DataGridViewRow)e.Item.Tag).Index);
					this.OnRowEnter(e2);
				}
			}
		}

		private void FillListViewItems()
		{
			this.sbnListView1.Items.Clear();
			this.imageList1.Images.Clear();
			if (this.ViewMode != View.Details && this.Columns.Count != 0 && base.Rows.Count != 0)
			{
				this.sbnListView1.MultiSelect = base.MultiSelect;
				foreach (DataGridViewRow row in ((IEnumerable)base.Rows))
				{
					this.sbnListView1.Items.Add(this.Cast(row));
				}
			}
		}

		private ListViewItem Cast(DataGridViewRow row)
		{
			ListViewItem result;
			try
			{
				if (row != null)
				{
					row.Selected = false;
					ListViewItem listViewItem = new ListViewItem();
					object value = row.Cells[this.MainColumnIndex].Value;
					if (value != null)
					{
						listViewItem.Text = value.ToString();
					}
					else
					{
						listViewItem.Text = " ";
					}
					listViewItem.Selected = row.Selected;
					listViewItem.Tag = row;
					try
					{
						this.imageList1.Images.Add(row.Index.ToString(), (Image)row.Cells[this.ImageColumnIndex].Value);
						listViewItem.ImageKey = row.Index.ToString();
					}
					catch
					{
					}
					result = listViewItem;
					return result;
				}
			}
			catch
			{
			}
			result = null;
			return result;
		}

		private void SetupContextMenu()
		{
			this.menuColumnHeader = new ContextMenuStrip();
			this.menuColumnHeader.Opening += new CancelEventHandler(this.MenuOpening);
			this.menuColumnHeader.ItemClicked += new ToolStripItemClickedEventHandler(this.MenuItemClicked);
		}

		protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
		{
			base.OnColumnAdded(e);
			e.Column.HeaderCell.ContextMenuStrip = this.menuColumnHeader;
			this.MenuOpening(null, new CancelEventArgs());
		}

		private string GetColumnText(DataGridViewColumn column)
		{
			string result;
			if (column.HeaderText == "" && column is DataGridViewButtonColumn)
			{
				result = ((DataGridViewButtonColumn)column).Text;
			}
			else
			{
				result = column.HeaderText;
			}
			return result;
		}

		private void MenuOpening(object sender, CancelEventArgs e)
		{
			e.Cancel = false;
			if (this.menuColumnHeader != null)
			{
				this.menuColumnHeader.Items.Clear();
				this.menuColumnHeader.Items.Add(this.CreateExportMenuItem());
				if (base.SortedColumn != null)
				{
					this.menuColumnHeader.Items.Add(new ToolStripMenuItem("&Search"));
				}
				this.menuColumnHeader.Items.Add("&تنظیمات");
				if (this.AllowAddRemoveColumns)
				{
					this.menuColumnHeader.Items.Add(new ToolStripSeparator());
					foreach (DataGridViewColumn dataGridViewColumn in this.Columns)
					{
						ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(this.GetColumnText(dataGridViewColumn));
						if (Control.ModifierKeys == Keys.Shift)
						{
							ToolStripMenuItem expr_EB = toolStripMenuItem;
							expr_EB.Text += string.Format(" - ({0} px)", dataGridViewColumn.Width);
						}
						toolStripMenuItem.Checked = dataGridViewColumn.Visible;
						toolStripMenuItem.Visible = (toolStripMenuItem.Text != "");
						toolStripMenuItem.Tag = dataGridViewColumn;
						if (dataGridViewColumn.Index < 9)
						{
							toolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + Alt + " + (dataGridViewColumn.Index + 1);
						}
						this.menuColumnHeader.Items.Add(toolStripMenuItem);
					}
				}
			}
		}

		private ToolStripMenuItem CreateExportMenuItem()
		{
			ToolStripMenuItem result;
			if (AbstractDataGridViewExporter.IsExcelInstalled)
			{
				result = new ToolStripMenuItem("&Export to Excel", Resources.IconExcel16);
			}
			else
			{
				result = new ToolStripMenuItem("&Export to CSV", Resources.IconCSV16);
			}
			return result;
		}

		private void MenuItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = e.ClickedItem as ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				string text = toolStripMenuItem.Text;
				if (text != null)
				{
					if (text == "&Export to Excel")
					{
						this.ToExcel();
						return;
					}
					if (text == "&Export to CSV")
					{
						this.ToCsv();
						return;
					}
					if (text == "&تنظیمات")
					{
						this.menuColumnHeader.Close();
						FontDialog fontDialog = new FontDialog();
						fontDialog.Font = base.RowTemplate.DefaultCellStyle.Font;
						if (fontDialog.ShowDialog(base.FindForm()) == DialogResult.OK)
						{
							try
							{
								base.RowTemplate.DefaultCellStyle.Font = new Font(fontDialog.Font.Name, fontDialog.Font.Size, fontDialog.Font.Style, GraphicsUnit.Point, 178);
								base.Invalidate(true);
							}
							catch
							{
								base.RowTemplate.DefaultCellStyle.Font = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.Point, 178);
							}
						}
						return;
					}
					if (text == "&Search")
					{
						this.ShowSearch();
						return;
					}
				}
				if (!toolStripMenuItem.Checked || this.Columns.GetColumnCount(DataGridViewElementStates.Visible) > 1)
				{
					DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)toolStripMenuItem.Tag;
					dataGridViewColumn.Visible = !toolStripMenuItem.Checked;
					toolStripMenuItem.Checked = dataGridViewColumn.Visible;
				}
			}
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			if (e.KeyChar == '`')
			{
				this.ShowSearch();
			}
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			if (e.Control)
			{
				foreach (DataGridViewColumn dataGridViewColumn in this.Columns)
				{
					if (!dataGridViewColumn.HeaderText.StartsWith(dataGridViewColumn.Index + 1 + ". "))
					{
						dataGridViewColumn.HeaderText = string.Format("{0}. {1}", dataGridViewColumn.Index + 1, dataGridViewColumn.HeaderText);
					}
				}
			}
			if ((ushort)e.KeyValue >= 49 && (ushort)e.KeyValue <= 57)
			{
				if (e.Modifiers == (Keys.Control | Keys.Alt))
				{
					foreach (ToolStripItem toolStripItem in this.menuColumnHeader.Items)
					{
						ToolStripMenuItem toolStripMenuItem = toolStripItem as ToolStripMenuItem;
						if (toolStripMenuItem != null && toolStripMenuItem.ShortcutKeyDisplayString == "Ctrl + Alt + " + (char)e.KeyValue)
						{
							this.MenuItemClicked(this, new ToolStripItemClickedEventArgs(toolStripItem));
						}
					}
				}
				else if (e.Modifiers == Keys.Control)
				{
					DataGridViewColumn dataGridViewColumn2 = this.Columns[int.Parse(((char)e.KeyValue).ToString()) - 1];
					MouseEventArgs e2 = new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 0);
					DataGridViewCellMouseEventArgs e3 = new DataGridViewCellMouseEventArgs(dataGridViewColumn2.Index, -1, 1, 1, e2);
					this.OnColumnHeaderMouseClick(e3);
				}
			}
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);
			if (!e.Control)
			{
				foreach (DataGridViewColumn dataGridViewColumn in this.Columns)
				{
					if (dataGridViewColumn.HeaderText.StartsWith(dataGridViewColumn.Index + 1 + ". "))
					{
						dataGridViewColumn.HeaderText = dataGridViewColumn.HeaderText.Replace(dataGridViewColumn.Index + 1 + ". ", "");
					}
				}
			}
		}

		private void ShowSearch()
		{
			if (base.SortedColumn != null)
			{
				if (this.m_pnlQuickSearch == null)
				{
					this.m_pnlQuickSearch = new PanelQuickSearch();
					base.Controls.Add(this.m_pnlQuickSearch);
					this.m_pnlQuickSearch.SearchChanged += new PanelQuickSearch.SearchHandler(this.m_pnlQuickSearch_SearchChanged);
				}
				if (base.SelectedRows.Count > 0)
				{
					this.m_pnlQuickSearch.Search = base.SelectedRows[0].Cells[base.SortedColumn.Index].Value.ToString();
				}
				this.m_pnlQuickSearch.Column = base.SortedColumn.HeaderText;
				this.m_pnlQuickSearch.Show();
				this.m_pnlQuickSearch.Focus();
			}
		}

		private void m_pnlQuickSearch_SearchChanged(string search)
		{
			foreach (DataGridViewRow dataGridViewRow in base.SelectedRows)
			{
				dataGridViewRow.Selected = false;
			}
			if (base.SortOrder == SortOrder.Ascending)
			{
				base.Rows[this.BinarySearchAsc(search)].Selected = true;
			}
			else
			{
				base.Rows[this.BinarySearchDesc(search)].Selected = true;
			}
			base.FirstDisplayedScrollingRowIndex = base.SelectedRows[0].Index;
		}

		private int BinarySearchAsc(string value)
		{
			int i = base.Rows.Count - 1;
			int num = 0;
			int index = base.SortedColumn.Index;
			int result;
			while (i >= num)
			{
				int num2 = (i - num) / 2 + num;
				int num3 = base[index, num2].Value.ToString().CompareTo(value);
				if (num3 > 0)
				{
					i = num2 - 1;
				}
				else
				{
					if (num3 >= 0)
					{
						result = num2;
						return result;
					}
					num = num2 + 1;
				}
			}
			if (num >= base.Rows.Count)
			{
				result = base.Rows.Count - 1;
				return result;
			}
			result = num;
			return result;
		}

		private int BinarySearchDesc(string value)
		{
			int i = base.Rows.Count - 1;
			int num = 0;
			int index = base.SortedColumn.Index;
			int result;
			while (i >= num)
			{
				int num2 = (i - num) / 2 + num;
				int num3 = base[index, num2].Value.ToString().CompareTo(value);
				if (num3 < 0)
				{
					i = num2 - 1;
				}
				else
				{
					if (num3 <= 0)
					{
						result = num2;
						return result;
					}
					num = num2 + 1;
				}
			}
			if (i < 0)
			{
				result = 0;
				return result;
			}
			result = i;
			return result;
		}
	}
}
