using System;
using BaseClass;

namespace SessionPresent
{
    partial class frmClientsList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientsList));
            this.dataGridClients = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridViewHostInformation = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.lblRec = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbtnStartSearch = new System.Windows.Forms.ToolStripButton();
            this.tsbtnAddToCliens = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRemove = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRefreshStatus = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tstxtPort = new System.Windows.Forms.ToolStripTextBox();
            this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsbtnCloseClient = new System.Windows.Forms.ToolStripButton();
            this.tsbtnShutdownPC = new System.Windows.Forms.ToolStripButton();
            this.clientInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClients)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHostInformation)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridClients
            // 
            this.dataGridClients.AllowUserToAddRows = false;
            this.dataGridClients.BackgroundColor = System.Drawing.Color.Lavender;
            this.dataGridClients.ColumnHeadersHeight = 32;
            this.dataGridClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridClients.Location = new System.Drawing.Point(4, 24);
            this.dataGridClients.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridClients.Name = "dataGridClients";
            this.dataGridClients.ReadOnly = true;
            this.dataGridClients.RowHeadersWidth = 100;
            this.dataGridClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridClients.Size = new System.Drawing.Size(605, 377);
            this.dataGridClients.TabIndex = 0;
            this.dataGridClients.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridClients_UserDeletingRow);
            this.dataGridClients.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridClients_MouseDoubleClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dataGridViewHostInformation);
            this.groupBox4.Location = new System.Drawing.Point(4, 171);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(333, 254);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "موارد یافت شده ";
            // 
            // dataGridViewHostInformation
            // 
            this.dataGridViewHostInformation.AllowUserToAddRows = false;
            this.dataGridViewHostInformation.BackgroundColor = System.Drawing.Color.Lavender;
            this.dataGridViewHostInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHostInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewHostInformation.Location = new System.Drawing.Point(4, 24);
            this.dataGridViewHostInformation.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewHostInformation.Name = "dataGridViewHostInformation";
            this.dataGridViewHostInformation.ReadOnly = true;
            this.dataGridViewHostInformation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewHostInformation.Size = new System.Drawing.Size(325, 226);
            this.dataGridViewHostInformation.TabIndex = 1;
            this.dataGridViewHostInformation.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewHostInformation_CellMouseDoubleClick);
            this.dataGridViewHostInformation.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewHostInformation_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtFrom);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTo);
            this.groupBox1.Location = new System.Drawing.Point(46, 54);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(286, 108);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "محدوده IP ";
            // 
            // txtFrom
            // 
            this.txtFrom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtFrom.Location = new System.Drawing.Point(9, 28);
            this.txtFrom.Margin = new System.Windows.Forms.Padding(4);
            this.txtFrom.MaxLength = 15;
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(194, 27);
            this.txtFrom.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(214, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "از : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(214, 70);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "تا : ";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(9, 66);
            this.txtTo.Margin = new System.Windows.Forms.Padding(4);
            this.txtTo.MaxLength = 15;
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(194, 27);
            this.txtTo.TabIndex = 4;
            // 
            // lblRec
            // 
            this.lblRec.AutoSize = true;
            this.lblRec.Location = new System.Drawing.Point(1344, 231);
            this.lblRec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRec.Name = "lblRec";
            this.lblRec.Size = new System.Drawing.Size(0, 19);
            this.lblRec.TabIndex = 22;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridClients);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 25);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(613, 405);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "سایر کاربران ";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(960, 430);
            this.splitContainer1.SplitterDistance = 341;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 31;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnStartSearch,
            this.tsbtnAddToCliens});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip2.Size = new System.Drawing.Size(341, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbtnStartSearch
            // 
            this.tsbtnStartSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnStartSearch.Image")));
            this.tsbtnStartSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnStartSearch.Name = "tsbtnStartSearch";
            this.tsbtnStartSearch.Size = new System.Drawing.Size(61, 22);
            this.tsbtnStartSearch.Text = "جستجو";
            this.tsbtnStartSearch.Click += new System.EventHandler(this.button2_Click);
            // 
            // tsbtnAddToCliens
            // 
            this.tsbtnAddToCliens.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAddToCliens.Image")));
            this.tsbtnAddToCliens.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAddToCliens.Name = "tsbtnAddToCliens";
            this.tsbtnAddToCliens.Size = new System.Drawing.Size(109, 22);
            this.tsbtnAddToCliens.Text = "افزودن به کاربران";
            this.tsbtnAddToCliens.Click += new System.EventHandler(this.btnAddToClientList_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAdd,
            this.tsbtnRemove,
            this.tsbtnRefreshStatus,
            this.tsbtnSearch,
            this.toolStripLabel1,
            this.tstxtPort,
            this.tsbtnSave,
            this.tsbtnCloseClient,
            this.tsbtnShutdownPC});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(613, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnAdd
            // 
            this.tsbtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAdd.Image")));
            this.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAdd.Name = "tsbtnAdd";
            this.tsbtnAdd.Size = new System.Drawing.Size(60, 22);
            this.tsbtnAdd.Text = "افزودن";
            this.tsbtnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tsbtnRemove
            // 
            this.tsbtnRemove.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRemove.Image")));
            this.tsbtnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRemove.Name = "tsbtnRemove";
            this.tsbtnRemove.Size = new System.Drawing.Size(52, 22);
            this.tsbtnRemove.Text = "حذف";
            this.tsbtnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // tsbtnRefreshStatus
            // 
            this.tsbtnRefreshStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefreshStatus.Name = "tsbtnRefreshStatus";
            this.tsbtnRefreshStatus.Size = new System.Drawing.Size(60, 22);
            this.tsbtnRefreshStatus.Text = "بروزرسانی";
            this.tsbtnRefreshStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // tsbtnSearch
            // 
            this.tsbtnSearch.CheckOnClick = true;
            this.tsbtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSearch.Image")));
            this.tsbtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSearch.Name = "tsbtnSearch";
            this.tsbtnSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tsbtnSearch.Size = new System.Drawing.Size(61, 22);
            this.tsbtnSearch.Text = "جستجو";
            this.tsbtnSearch.CheckedChanged += new System.EventHandler(this.tsbtnSearch_CheckedChanged);
            this.tsbtnSearch.Click += new System.EventHandler(this.btnSearchIP_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(73, 22);
            this.toolStripLabel1.Text = " : Server Port";
            this.toolStripLabel1.Visible = false;
            // 
            // tstxtPort
            // 
            this.tstxtPort.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tstxtPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tstxtPort.Name = "tstxtPort";
            this.tstxtPort.Size = new System.Drawing.Size(148, 25);
            this.tstxtPort.Visible = false;
            // 
            // tsbtnSave
            // 
            this.tsbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSave.Image")));
            this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSave.Name = "tsbtnSave";
            this.tsbtnSave.Size = new System.Drawing.Size(83, 22);
            this.tsbtnSave.Text = "ذخیره سازی";
            this.tsbtnSave.Click += new System.EventHandler(this.tsbtnSave_Click);
            // 
            // tsbtnCloseClient
            // 
            this.tsbtnCloseClient.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnCloseClient.Image")));
            this.tsbtnCloseClient.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCloseClient.Name = "tsbtnCloseClient";
            this.tsbtnCloseClient.Size = new System.Drawing.Size(88, 22);
            this.tsbtnCloseClient.Text = "بستن کارتابل";
            this.tsbtnCloseClient.Click += new System.EventHandler(this.tsbtnCloseClient_Click);
            // 
            // tsbtnShutdownPC
            // 
            this.tsbtnShutdownPC.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnShutdownPC.Image")));
            this.tsbtnShutdownPC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnShutdownPC.Name = "tsbtnShutdownPC";
            this.tsbtnShutdownPC.Size = new System.Drawing.Size(82, 22);
            this.tsbtnShutdownPC.Text = "ShutDown";
            this.tsbtnShutdownPC.Click += new System.EventHandler(this.tsbtnShutdownPC_Click);
            // 
            // clientInfoBindingSource
            // 
            this.clientInfoBindingSource.DataSource = typeof(BaseClass.ClientInfo);
            // 
            // frmClientsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 430);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblRec);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmClientsList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "مدیریت حاضرین";
            this.Load += new System.EventHandler(this.frmClientsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClients)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHostInformation)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientInfoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridClients;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label lblRec;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.BindingSource clientInfoBindingSource;
        private System.Windows.Forms.DataGridView dataGridViewHostInformation;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnAdd;
        private System.Windows.Forms.ToolStripButton tsbtnRemove;
        private System.Windows.Forms.ToolStripButton tsbtnRefreshStatus;
        private System.Windows.Forms.ToolStripButton tsbtnSearch;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbtnStartSearch;
        private System.Windows.Forms.ToolStripButton tsbtnAddToCliens;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tstxtPort;
        private System.Windows.Forms.ToolStripButton tsbtnSave;
        private System.Windows.Forms.ToolStripButton tsbtnCloseClient;
        private System.Windows.Forms.ToolStripButton tsbtnShutdownPC;
    }
}