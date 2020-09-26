using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using Sbn.FramWork.Windows.Forms.ExtendedDataGridView;

namespace Sbn.FramWork.Windows.Forms
{
    partial class SBNDataGridView
    {
        const string EXPORT_TO_EXCEL = "&Export to Excel",
                     EXPORT_TO_CSV   = "&Export to CSV",
                     TemplateSetting   = "&تنظیمات",
                     SEARCH          = "&Search";

        ContextMenuStrip menuColumnHeader;

        void SetupContextMenu()
        {
            menuColumnHeader              = new ContextMenuStrip();
            menuColumnHeader.Opening     += MenuOpening;
            menuColumnHeader.ItemClicked += MenuItemClicked;
        }

        protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
        {
            base.OnColumnAdded(e);

            e.Column.HeaderCell.ContextMenuStrip = menuColumnHeader;
            MenuOpening(null, new CancelEventArgs());
        }

        string GetColumnText(DataGridViewColumn column)
        {
            if (column.HeaderText == "" && column is DataGridViewButtonColumn)
                return ((DataGridViewButtonColumn)column).Text;

            return column.HeaderText;
        }

        void MenuOpening(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (menuColumnHeader == null)
                return;

            menuColumnHeader.Items.Clear();
            menuColumnHeader.Items.Add(CreateExportMenuItem());
            if (SortedColumn != null)
                menuColumnHeader.Items.Add(new ToolStripMenuItem(SEARCH));

            menuColumnHeader.Items.Add(TemplateSetting);

            if (AllowAddRemoveColumns)
            {
                menuColumnHeader.Items.Add(new ToolStripSeparator());

                foreach (DataGridViewColumn column in Columns)
                {
                    ToolStripMenuItem newItem = new ToolStripMenuItem(GetColumnText(column));
                    if (ModifierKeys == Keys.Shift)
                        newItem.Text         += string.Format(" - ({0} px)", column.Width);
                    newItem.Checked           = column.Visible;
                    newItem.Visible           = newItem.Text != "";
                    newItem.Tag               = column;
                    if (column.Index < 9)
                        newItem.ShortcutKeyDisplayString = "Ctrl + Alt + " + (column.Index + 1);
                    menuColumnHeader.Items.Add(newItem);
                }
            }
        }

        ToolStripMenuItem CreateExportMenuItem()
        {
            if (DataGridViewExporter.IsExcelInstalled)
                return new ToolStripMenuItem(EXPORT_TO_EXCEL, Properties.Resources.IconExcel16);

            return new ToolStripMenuItem(EXPORT_TO_CSV, Properties.Resources.IconCSV16);
        }

        private void MenuItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem menuItem = e.ClickedItem as ToolStripMenuItem;

            if (menuItem == null)
                return;

            switch (menuItem.Text)
            {
                case EXPORT_TO_EXCEL:
                    ToExcel();
                    break;

                case EXPORT_TO_CSV:
                    ToCsv();
                    break; 
                
                case TemplateSetting:
                    menuColumnHeader.Close();
                    var fDialog = new FontDialog();
                    fDialog.Font = this.RowTemplate.DefaultCellStyle.Font;
                    if (fDialog.ShowDialog(this.FindForm()) == DialogResult.OK)
                    {

                        try
                        {
                            
                           // this.RowTemplate.DefaultCellStyle.Font = fDialog.Font;
                            this.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font(fDialog.Font.Name, fDialog.Font.Size, fDialog.Font.Style, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                            this.Invalidate(true);
                           // this.ColumnHeadersDefaultCellStyle.Font = fDialog.Font;
                            //this..Font = fDialog.Font;

                            //System.Windows.Forms.DataGridViewCellStyle dgvCellStyle00 = new System.Windows.Forms.DataGridViewCellStyle();
                            //dgvCellStyle00.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                            //dgvCellStyle00.BackColor = System.Drawing.SystemColors.Control;
                            //dgvCellStyle00.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                            //dgvCellStyle00.ForeColor = System.Drawing.SystemColors.WindowText;
                            //dgvCellStyle00.SelectionBackColor = System.Drawing.SystemColors.Highlight;
                            //dgvCellStyle00.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                            //dgvCellStyle00.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                            //this.ColumnHeadersDefaultCellStyle = dgvCellStyle00;


                            //this.RowsDefaultCellStyle.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                        }
                        catch
                        {
                            this.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                        }
                    }
                    break;

                case SEARCH:
                    ShowSearch();
                    break;

                default:
                    if (!menuItem.Checked || Columns.GetColumnCount(DataGridViewElementStates.Visible) > 1)
                    {
                        DataGridViewColumn column = (DataGridViewColumn)menuItem.Tag;
                        column.Visible            = !menuItem.Checked;
                        menuItem.Checked          = column.Visible;
                    }
                    break;
            }
        }

    }
}
