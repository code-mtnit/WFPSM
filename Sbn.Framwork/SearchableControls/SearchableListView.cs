using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SearchableControls
{
	public class SearchableListView : ListView, ISearchable
	{
		public delegate bool NodeSearchDelegate(ListViewItem node, Regex regularExpression);

		private SearchableListView.NodeSearchDelegate nodeSearcher;

		protected int originalSelectionStart;

		private IContainer components = null;

		private ContextMenuStrip contextMenuStrip;

		private ToolStripMenuItem findToolStripMenuItem;

		private ToolStripMenuItem selectAllToolStripMenuItem;

		private FindDialog findDialog1;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public SearchableListView.NodeSearchDelegate NodeSearcher
		{
			get
			{
				return this.nodeSearcher;
			}
			set
			{
				this.nodeSearcher = value;
			}
		}

		public FindDialog FindDialog
		{
			get
			{
				return this.findDialog1;
			}
		}

		public SearchableListView()
		{
			this.InitializeComponent();
			this.nodeSearcher = new SearchableListView.NodeSearchDelegate(this.DefaultNodeSearch);
			this.findToolStripMenuItem.Click += new EventHandler(this.findToolStripMenuItem_Click);
			this.selectAllToolStripMenuItem.Click += new EventHandler(this.selectAllToolStripMenuItem_Click);
		}

		protected void SearchableListView_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
			{
				this.SelectAll();
				e.SuppressKeyPress = true;
			}
			else if (e.KeyCode == Keys.F && e.Modifiers == Keys.Control)
			{
				this.findDialog1.Show();
				e.SuppressKeyPress = true;
			}
			else if (e.KeyCode == Keys.F3 && e.Modifiers == Keys.None)
			{
				this.findDialog1.FindNext();
				e.SuppressKeyPress = true;
			}
		}

		public void SelectAll()
		{
			foreach (ListViewItem listViewItem in base.Items)
			{
				listViewItem.Selected = true;
			}
		}

		private bool DefaultNodeSearch(ListViewItem listViewItem, Regex regularExpression)
		{
			bool result;
			foreach (ListViewItem.ListViewSubItem listViewSubItem in listViewItem.SubItems)
			{
				if (regularExpression.IsMatch(listViewSubItem.Text))
				{
					result = true;
					return result;
				}
			}
			result = regularExpression.IsMatch(listViewItem.Text);
			return result;
		}

		private void RestoreHideSelection(object sender, EventArgs e)
		{
			base.HideSelection = true;
		}

		private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			bool enabled = false;
			foreach (ListViewItem listViewItem in base.Items)
			{
				if (!listViewItem.Selected)
				{
					enabled = true;
					break;
				}
			}
			this.selectAllToolStripMenuItem.Enabled = enabled;
		}

		private void findToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.findDialog1.Show();
		}

		private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SelectAll();
		}

		protected bool SubSearch(Regex regularExpression, int start, int end)
		{
			bool result;
			for (int i = start; i < end; i++)
			{
				if (this.nodeSearcher(base.Items[i], regularExpression))
				{
					if (base.HideSelection)
					{
						this.findDialog1.Deactivate += new EventHandler(this.RestoreHideSelection);
						base.HideSelection = false;
					}
					base.SelectedIndices.Clear();
					base.Items[i].Selected = true;
					base.EnsureVisible(i);
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}

		private void findDialog1_SearchRequested(object sender, SearchEventArgs e)
		{
			int num;
			if (base.SelectedIndices.Count > 0)
			{
				num = base.SelectedIndices[0];
			}
			else
			{
				num = 0;
			}
			if (e.FirstSearch)
			{
				this.originalSelectionStart = num;
			}
			int count;
			if (this.originalSelectionStart > num)
			{
				count = this.originalSelectionStart;
			}
			else
			{
				count = base.Items.Count;
			}
			bool flag = this.SubSearch(e.SearchRegularExpression, num + 1, count);
			if (!flag && this.originalSelectionStart <= num)
			{
				flag = this.SubSearch(e.SearchRegularExpression, 0, this.originalSelectionStart);
				if (flag)
				{
					e.RestartedFromDocumentTop = true;
				}
			}
			if (flag)
			{
				e.Successful = true;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new Container();
			this.contextMenuStrip = new ContextMenuStrip(this.components);
			this.selectAllToolStripMenuItem = new ToolStripMenuItem();
			this.findToolStripMenuItem = new ToolStripMenuItem();
			this.findDialog1 = new FindDialog();
			this.contextMenuStrip.SuspendLayout();
			base.SuspendLayout();
			this.contextMenuStrip.Items.AddRange(new ToolStripItem[]
			{
				this.selectAllToolStripMenuItem,
				this.findToolStripMenuItem
			});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.RenderMode = ToolStripRenderMode.System;
			this.contextMenuStrip.ShowImageMargin = false;
			this.contextMenuStrip.Size = new Size(104, 48);
			this.contextMenuStrip.Opening += new CancelEventHandler(this.contextMenuStrip_Opening);
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.Size = new Size(103, 22);
			this.selectAllToolStripMenuItem.Text = "Select &All";
			this.findToolStripMenuItem.Name = "findToolStripMenuItem";
			this.findToolStripMenuItem.Size = new Size(103, 22);
			this.findToolStripMenuItem.Text = "&Find";
			this.findDialog1.ParentControl = this;
			this.findDialog1.ReplaceAvailable = false;
			this.findDialog1.SearchRegularExpression = null;
			this.findDialog1.SearchRequested += new SearchEventHandler(this.findDialog1_SearchRequested);
			this.ContextMenuStrip = this.contextMenuStrip;
			base.KeyDown += new KeyEventHandler(this.SearchableListView_KeyDown);
			this.contextMenuStrip.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
