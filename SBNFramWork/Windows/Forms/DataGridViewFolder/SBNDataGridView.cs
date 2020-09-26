using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Sbn.FramWork.Windows.Forms.ExtendedDataGridView;

namespace Sbn.FramWork.Windows.Forms
{

     [DesignerAttribute(typeof(ExtendedDataGridViewDesigner))]
    public partial class SBNDataGridView : System.Windows.Forms.DataGridView
    {

        #region Member variables
        // The embedded ListView control that is used for the ListView mode
        private SBNListView sbnListView1;
        private System.Windows.Forms.ImageList imageList1;
        private View _viewMode = View.Details;

        // true, when the control is visible
        private bool _visible = true;
        private string FullName = "";
        private DataGridViewTextBoxColumn clmnRowOrder;
        #endregion




        private bool _viewRowOrder = false;
        /// <summary>
        /// نمایش ردیف هر سطر در ستون اول
        /// </summary>
        public bool ViewRowOrder
        {
            get { return _viewRowOrder; }
            set
            {
                _viewRowOrder = value;

                if (value)
                {


                    if (clmnRowOrder == null)
                    {
                        clmnRowOrder = new DataGridViewTextBoxColumn();
                        clmnRowOrder.Name = "clmnRowOrder";
                        clmnRowOrder.HeaderText = "ردیف";
                        clmnRowOrder.SortMode = DataGridViewColumnSortMode.Automatic;
                        clmnRowOrder.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        clmnRowOrder.Width = 30;
                        clmnRowOrder.ReadOnly = true;
                        clmnRowOrder.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        Columns.Insert(0, clmnRowOrder);
                    }
                    else
                    {
                        clmnRowOrder.Visible = true;
                    }
                }
                else
                {
                     if (clmnRowOrder != null)
                     {
                         clmnRowOrder.Visible = false;
                     }
                }

            }
        }

        public SBNDataGridView()
        {
            sbnListView1 = new SBNListView();
            imageList1 = new System.Windows.Forms.ImageList();
            // 
            // imageList1
            // 
            imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            imageList1.ImageSize = new System.Drawing.Size(32, 32);
            imageList1.TransparentColor = System.Drawing.Color.Transparent;


            InitializeComponent();
            SetupContextMenu();
            MultiSelectChanged += new EventHandler(SBNDataGridViewMultiSelectChanged);
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // SBNDataGridView
            // 
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToOrderColumns = true;
            this.BackgroundColor = System.Drawing.Color.White;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }


        public event EventHandler WorkStart;
        public event EventHandler WorkFinished;

        public virtual void OnWorkStart(object sender, EventArgs e)
        {
            if (WorkStart != null)
                WorkStart(sender, e);
        }

        public virtual void OnWorkFinished(object sender, EventArgs e)
        {
            if (WorkFinished != null)
                WorkFinished(sender, e);
        }

        public void ToExcel()
        {
            new Thread(delegate()
            {
                OnWorkStart(this, new EventArgs());

                if (DataGridViewExporter.IsExcelInstalled)
                {
                    Excel.Worksheet worksheet = new DataGridViewExporter(this, ExportVisibleColumnsOnly).ToExcel();
                    worksheet.IsApplicationVisible = true;
                }

                OnWorkFinished(this, new EventArgs());
            }).Start();
        }

        public void ToCsv()
        {
            new Thread(delegate()
            {
                OnWorkStart(this, new EventArgs());

                new DataGridViewExporter(this).SaveAsCSV(true);

                OnWorkFinished(this, new EventArgs());
            }).Start();
        }


        private string GetFullName()
        {
            return GetParentFullName(this);
        }







        private string GetParentFullName(Control ctrl)
        {
            string result = ctrl.Name;

            if (ctrl.Parent != null)
            {
                result = result + GetParentFullName(ctrl.Parent);
            }

            return result;
        }

        public void SetColumnOrder()
        {

            try
            {
                if (!gfDataGridViewSetting.Default.ColumnOrder.ContainsKey(this.FullName))
                    return;


                if (string.IsNullOrEmpty(FullName))
                    return;

                List<ColumnOrderItem> columnOrder =
                    gfDataGridViewSetting.Default.ColumnOrder[FullName];

                if (columnOrder != null)
                {
                    var sorted = columnOrder.OrderBy(i => i.DisplayIndex);
                    foreach (var item in sorted)
                    {

                        if (item.Name != null && Columns.Contains(item.Name))
                        {
                            if (item.DisplayIndex >= this.Columns.Count)
                                continue;

                            this.Columns[item.Name].DisplayIndex = item.DisplayIndex;
                            this.Columns[item.Name].Visible = item.Visible;
                            this.Columns[item.Name].Width = item.Width;
                        }



                        //if (item.DisplayIndex >= this.Columns.Count)
                        //    continue;

                        //this.Columns[item.ColumnIndex].DisplayIndex = item.DisplayIndex;
                        //this.Columns[item.ColumnIndex].Visible = item.Visible;
                        //this.Columns[item.ColumnIndex].Width = item.Width;
                    }
                }
                
            }
            catch(Exception ex)
            {
               // throw;
            }
           
        }
        //---------------------------------------------------------------------
        public void SaveColumnOrder()
        {
            try
            {
                if (this.AllowUserToOrderColumns)
                {
                    List<ColumnOrderItem> columnOrder = new List<ColumnOrderItem>();
                    DataGridViewColumnCollection columns = this.Columns;
                    for (int i = 0; i < columns.Count; i++)
                    {
                        columnOrder.Add(new ColumnOrderItem
                        {
                            Name = columns[i].Name,
                            ColumnIndex = i,
                            DisplayIndex = columns[i].DisplayIndex,
                            Visible = columns[i].Visible,
                            Width = columns[i].Width
                        });
                    }

                    if (gfDataGridViewSetting.Default.ColumnOrder.ContainsKey(FullName))
                    {
                        gfDataGridViewSetting.Default.ColumnOrder[this.FullName] = columnOrder;
                        gfDataGridViewSetting.Default.Save();
                       
                        
                    }
                    else
                    {
                        gfDataGridViewSetting.Default.ColumnOrder.Add(FullName, columnOrder);
                        gfDataGridViewSetting.Default.Save();
                    }

                   
                  
                    
                }
            }
            catch (Exception)
            {

               
            }
           
        }
        //---------------------------------------------------------------------
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            FullName = GetFullName();
            SetColumnOrder();
        }
        //---------------------------------------------------------------------
        protected override void Dispose(bool disposing)
        {
            SaveColumnOrder();
            base.Dispose(disposing);
        }

        protected override void OnRowsAdded(DataGridViewRowsAddedEventArgs e)
        {
            if (ViewRowOrder && clmnRowOrder != null)
            {
                Rows[e.RowIndex].Cells[clmnRowOrder.Index].Value = e.RowIndex + 1;
            }

            base.OnRowsAdded(e);
            Refresh();
        }
        protected override void OnRowsRemoved(DataGridViewRowsRemovedEventArgs e)
        {
            base.OnRowsRemoved(e);
            Refresh();
        }


      

        void SBNDataGridViewMultiSelectChanged(object sender, EventArgs e)
        {
            sbnListView1.MultiSelect = MultiSelect;
        }


        [Browsable(true)]
        [DefaultValue(View.Details)]
        [Category("Behavior")]
        [Description("نحوه نمایش اطلاعات")]
        public View ViewMode
        {
            get { return _viewMode; }
            set
            {
                _viewMode = value;

                
                sbnListView1.View = value;
                ShowControl();



               
                Refresh();
            }

        }


        /// <summary>
        /// Gets or sets a value indicating wether the control is displayed.
        /// </summary>
        /// <value><b>true</b> if the control is displayed; otherwise, <b>false</b>. 
        /// The default is <b>true</b>.</value>
        public new bool Visible
        {
            get { return _visible; }
            set
            {
                _visible = value;
                ShowControl();
            }
        }

        /// <summary>
        /// Conceals the control from the user.
        /// </summary>
        /// <remarks>
        /// Hiding the control is equvalent to setting the <see cref="Visible"/> property to <b>false</b>. 
        /// After the <b>Hide</b> method is called, the <b>Visible</b> property returns a value of 
        /// <b>false</b> until the <see cref="Show"/> method is called.
        /// </remarks>
        public new void Hide()
        {
            Visible = false;
        }

        /// <summary>
        /// Displays the control to the user.
        /// </summary>
        /// <remarks>
        /// Showing the control is equivalent to setting the <see cref="Visible"/> property to <b>true</b>.
        /// After the <b>Show</b> method is called, the <b>Visible</b> property returns a value of 
        /// <b>true</b> until the <see cref="Hide"/> method is called.
        /// </remarks>
        public new void Show()
        {
            Visible = true;
        }

        /// <summary>
        /// Initializes the embedded TextBox with the default values from the ComboBox
        /// </summary>
        private void AddListView()
        {
           // sbnListView1.ReadOnly = true;
            sbnListView1.Location = this.Location;
            sbnListView1.Size = this.Size;
            sbnListView1.Dock = this.Dock;
            sbnListView1.Anchor = this.Anchor;
            sbnListView1.Enabled = base.Enabled;
            sbnListView1.Visible = this.Visible;
            sbnListView1.RightToLeft = this.RightToLeft;
            sbnListView1.RightToLeftLayout = (sbnListView1.RightToLeft == this.RightToLeft);
            sbnListView1.Font = this.Font;
            sbnListView1.Text = this.Text;
            sbnListView1.TabStop = this.TabStop;
            sbnListView1.TabIndex = this.TabIndex;


            // 
            // sbnListView1
            // 
            this.sbnListView1.LargeImageList = this.imageList1;
            this.sbnListView1.SmallImageList = this.imageList1;
            this.sbnListView1.StateImageList = this.imageList1;
            this.sbnListView1.UseCompatibleStateImageBehavior = false;
            sbnListView1.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(sbnListView1_ItemSelectionChanged);
            sbnListView1.MouseDoubleClick += new MouseEventHandler(sbnListView1_MouseDoubleClick);
            sbnListView1.Click += new EventHandler(sbnListView1_Click);
            sbnListView1.MouseDown += new MouseEventHandler(sbnListView1_MouseDown);
            sbnListView1.MouseClick += new MouseEventHandler(sbnListView1_MouseClick);
            sbnListView1.SelectedIndexChanged += new EventHandler(sbnListView1_SelectedIndexChanged);
        }

        void sbnListView1_MouseDown(object sender, MouseEventArgs e)
        {

        }


        void sbnListView1_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = sbnListView1.GetItemAt(e.X, e.Y);
            var dRow = item.Tag as DataGridViewRow;

            var ee = new MouseEventArgs(e.Button, e.Clicks, dRow.AccessibilityObject.Bounds.X, dRow.AccessibilityObject.Bounds.Y, e.Delta);
            OnMouseClick(ee);
        }

        void sbnListView1_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Shows either the ComboBox or the TextBox or nothing, depending on the state
        /// of the ReadOnly, Enable and Visible flags.
        /// </summary>
        private void ShowControl()
        {
            if (_viewMode != View.Details)
            {
                FillListViewItems();
                sbnListView1.Visible = _visible && this.Enabled;
              // base.Visible = _visible && !this.Enabled;
                sbnListView1.Focus();
                //sbnListView1.Text = this.Text;
                
                

                //sbnListView1.Dock = DockStyle.Fill;
                sbnListView1.BringToFront();
                //sbnListView1.Visible = true;
               
                //ScrollBars = ScrollBars.None;

                //if (!this.Controls.Contains(sbnListView1))
                //{
                //    this.Controls.Add(sbnListView1);
                   
                //    sbnListView1.RightToLeft = RightToLeft;
                //    if (RightToLeft == RightToLeft.Yes)
                //        sbnListView1.RightToLeftLayout = true;
                //    else
                //    {
                //        sbnListView1.RightToLeftLayout = false;
                //    }

                //}

            }
            else
            {
                sbnListView1.Visible = false;
                base.Visible = _visible;
            }
        }





        #region OnXXXX()
        /// <summary>
        /// This member overrides <see cref="Control.OnParentChanged"/>
        /// </summary>
        /// <param name="e"></param>
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (Parent != null)
                AddListView();
            sbnListView1.Parent = this.Parent;

            if (ViewMode != View.Details)
                sbnListView1.BringToFront();
        }

        ///// <summary>
        ///// This member overrides <see cref="ReadOnlyComboBox.OnSelectedIndexChanged"/>.
        ///// </summary>
        //protected override void OnSelectedIndexChanged(EventArgs e)
        //{
        //    base.OnSelectedIndexChanged(e);
        //    if (this.SelectedItem == null)
        //        _textbox.Clear();
        //    else
        //        _textbox.Text = this.SelectedItem.ToString();
        //}

        protected override void OnRowEnter(DataGridViewCellEventArgs e)
        {
            base.OnRowEnter(e);
            
        }

        protected override void OnSelectionChanged(EventArgs e)
        {
            base.OnSelectionChanged(e);
           
            
        }
       

        /// <summary>
        /// This member overrides <see cref="ReadOnlyComboBox.OnFontChanged"/>.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            sbnListView1.Font = this.Font;
        }

        /// <summary>
        /// This member overrides <see cref="ReadOnlyComboBox.OnResize"/>.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            sbnListView1.Size = this.Size;

           // sbnListView1.Size = new Size(Size.Width / 2 , Size.Height); 
        }

        /// <summary>
        /// This member overrides <see cref="Control.OnDockChanged"/>.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDockChanged(EventArgs e)
        {
            base.OnDockChanged(e);
            sbnListView1.Dock = this.Dock;
        }

        /// <summary>
        /// This member overrides <see cref="Control.OnEnabledChanged"/>.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            ShowControl();
        }

        /// <summary>
        /// This member overrides <see cref="Control.OnRightToLeftChanged"/>.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRightToLeftChanged(EventArgs e)
        {
            base.OnRightToLeftChanged(e);
            sbnListView1.RightToLeft = this.RightToLeft;
        }

        /// <summary>
        /// This member overrides <see cref="Control.OnTextChanged"/>.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            sbnListView1.Text = this.Text;
        }

        /// <summary>
        /// This member overrides <see cref="Control.OnLocationChanged"/>.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            sbnListView1.Location = this.Location;
        }

        /// <summary>
        /// This member overrides <see cref="Control.OnTabIndexChanged"/>.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTabIndexChanged(EventArgs e)
        {
            base.OnTabIndexChanged(e);
            sbnListView1.TabIndex = this.TabIndex;
        }


        protected override void OnMouseClick(MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right && e.Location.Y < this.ColumnHeadersHeight)
                return;

           base.OnMouseClick(e);
        }


        
        #endregion


        protected override void OnRowPrePaint(DataGridViewRowPrePaintEventArgs e)
        {
            if (ViewRowOrder && clmnRowOrder != null)
            {
                Rows[e.RowIndex].Cells[clmnRowOrder.Index].Value = e.RowIndex + 1;
            }

            base.OnRowPrePaint(e);
        }
        protected override void OnCurrentCellChanged(EventArgs e)
        {

            base.OnCurrentCellChanged(e);

            if (MouseButtons == MouseButtons.Left)
                return;
            
            foreach (ListViewItem item in this.sbnListView1.Items)
            {
                if (CurrentCell != null && ((DataGridViewRow)item.Tag).Index == CurrentCell.RowIndex)
                {
                    item.Selected = true;
                }
                else
                    item.Selected = false;
               
            }

        }


        void sbnListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
         
        }

        public override void Refresh()
        {
            base.Refresh();
            FillListViewItems();
        }

        void sbnListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OnMouseDoubleClick(e);
        }

        void sbnListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (ViewMode == View.Details || ((DataGridViewRow)e.Item.Tag).DataGridView == null)
                return;

            this.SetSelectedRowCore(((DataGridViewRow)e.Item.Tag).Index, e.IsSelected);


            if (e.IsSelected)
            {
                try
                {
                    SetCurrentCellAddressCore(0, ((DataGridViewRow)e.Item.Tag).Index, true, true, false);
                }
                catch (Exception)
                {

                    
                }
                
                //this.CurrentCell = ((DataGridViewRow)e.Item.Tag).Cells[0];
               // ((DataGridViewRow)e.Item.Tag).Selected = true;
                ////ListViewItem lsvItm = ((SBNListView)sender).FocusedItem;
                var ee = new DataGridViewCellEventArgs(0, ((DataGridViewRow)e.Item.Tag).Index);
                OnRowEnter(ee);
               
            }

           //
            //else
            //{
            //    ((DataGridViewRow)e.Item.Tag).Selected = false;
            //}
        }


        private Size _imageSize = new Size(32,32);
        public Size ImageSize
        {
            get { return _imageSize; }
            set
            {
                if (imageList1 != null)
                {
                    imageList1.ImageSize = value;
                    _imageSize = value;
                }
            }
        }

        private int _mainColumnIndex = 0;
        /// <summary>
        /// ستون اصلی به منظور نمایش عنوان آیتم در حالت ها مشاهده ای دیگر
        /// </summary>
        [Description("ستون اصلی به منظور نمایش عنوان آیتم در حالت ها مشاهده ای دیگر")]
        public int MainColumnIndex
        {
            get { return _mainColumnIndex; }
            set
            {

                if (value + 1 > Columns.Count)
                {
                    value = _mainColumnIndex;
                }

                _mainColumnIndex = value;



                Refresh();
            }
        }

        private int _imageColumnIndex = 0;
        /// <summary>
        /// ستون اصلی به منظور نمایش آیکون آیتم در حالت ها مشاهده ای دیگر
        /// </summary>
        [Description("ستون اصلی به منظور آیکون آیتم در حالت ها مشاهده ای دیگر")]
        public int ImageColumnIndex
        {
            get { return _imageColumnIndex; }
            set
            {
                if (value + 1 > Columns.Count)
                {
                    value = 0;
                }


                _imageColumnIndex = value;
               Refresh();
            }
        }

        void FillListViewItems()
        {
            sbnListView1.Items.Clear();
            imageList1.Images.Clear();
            if (ViewMode == View.Details || Columns.Count == 0 || Rows.Count == 0)
                return;

            
            sbnListView1.MultiSelect = MultiSelect;
            foreach(DataGridViewRow row in Rows)
            {
                sbnListView1.Items.Add(Cast(row));
            }
        }


        ListViewItem Cast(DataGridViewRow row)
        {

            try
            {
                if (row != null)
                {
                    row.Selected = false;
                    var lsvItem = new ListViewItem();
                    var value = row.Cells[MainColumnIndex].Value;
                    if (value != null)
                    {
                        lsvItem.Text = value.ToString();
                    }
                    else
                    {
                        lsvItem.Text = " ";
                    }
                    lsvItem.Selected = row.Selected;

                    lsvItem.Tag = row;

                    try
                    {
                      //  if (!imageList1.Images.Contains((Image)row.Cells[ImageColumnIndex].Value))
                        {
                            imageList1.Images.Add(row.Index.ToString(), (Image) row.Cells[ImageColumnIndex].Value);
                        }
                        lsvItem.ImageKey = row.Index.ToString();// imageList1.Images.IndexOf((Image)row.Cells[ImageColumnIndex].Value);
                        //lsvItem.ima = lsvItem.ImageIndex;
                    }
                    catch
                    { }
                   
                    return lsvItem;
                }
            }
            catch
            {

            }
           
            return null;
        }

        

       


    }


    [Serializable]
    public sealed class ColumnOrderItem
    {
        public string Name { get; set; }
        public int DisplayIndex { get; set; }
        public int Width { get; set; }
        public bool Visible { get; set; }
        public int ColumnIndex { get; set; }
    }

    //-------------------------------------------------------------------------
    internal sealed class gfDataGridViewSetting : ApplicationSettingsBase
    {
        private static gfDataGridViewSetting _defaultInstace =
            (gfDataGridViewSetting)ApplicationSettingsBase
            .Synchronized(new gfDataGridViewSetting());
        //---------------------------------------------------------------------
        public static gfDataGridViewSetting Default
        {
            get { return _defaultInstace; }
        }
        //---------------------------------------------------------------------
        // Because there can be more than one DGV in the user-application
        // a dictionary is used to save the settings for this DGV.
        // As key the name of the control is used.
        [UserScopedSetting]
        [SettingsSerializeAs(SettingsSerializeAs.Binary)]
        [DefaultSettingValue("")]
        public Dictionary<string, List<ColumnOrderItem>> ColumnOrder
        {
            get
            {
                
                return this["ColumnOrder"] as Dictionary<string, List<ColumnOrderItem>>;
            }
            set { this["ColumnOrder"] = value; }
        }
    }
}
