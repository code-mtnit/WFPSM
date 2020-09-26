using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SearchableControls
{
	public class SearchableTextBox : TextBox, ISearchable
	{
		private IContainer components = null;

		private ContextMenuStrip contextMenuStrip;

		private ToolStripMenuItem undoToolStripMenuItem;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripMenuItem cutToolStripMenuItem;

		private ToolStripMenuItem copyToolStripMenuItem;

		private ToolStripMenuItem pasteToolStripMenuItem;

		private ToolStripMenuItem deleteToolStripMenuItem;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripMenuItem selectAllToolStripMenuItem;

		private ToolStripMenuItem findToolStripMenuItem;

		private FindDialog findDialog1;

		private ToolStripMenuItem replaceToolStripMenuItem;

		private ToolStripSeparator toolStripSeparator3;

		private string textBeforeReplace;

		private string textAfterReplace;

		protected int originalSelectionStart;

		public new bool CanUndo
		{
			get
			{
				return this.Text.Equals(this.textAfterReplace) || base.CanUndo;
			}
		}

		public FindDialog FindDialog
		{
			get
			{
				return this.findDialog1;
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
			this.undoToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripSeparator1 = new ToolStripSeparator();
			this.cutToolStripMenuItem = new ToolStripMenuItem();
			this.copyToolStripMenuItem = new ToolStripMenuItem();
			this.pasteToolStripMenuItem = new ToolStripMenuItem();
			this.deleteToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripSeparator2 = new ToolStripSeparator();
			this.findToolStripMenuItem = new ToolStripMenuItem();
			this.replaceToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripSeparator3 = new ToolStripSeparator();
			this.selectAllToolStripMenuItem = new ToolStripMenuItem();
			this.findDialog1 = new FindDialog();
			this.contextMenuStrip.SuspendLayout();
			base.SuspendLayout();
			this.contextMenuStrip.Items.AddRange(new ToolStripItem[]
			{
				this.undoToolStripMenuItem,
				this.toolStripSeparator1,
				this.cutToolStripMenuItem,
				this.copyToolStripMenuItem,
				this.pasteToolStripMenuItem,
				this.deleteToolStripMenuItem,
				this.toolStripSeparator2,
				this.findToolStripMenuItem,
				this.replaceToolStripMenuItem,
				this.toolStripSeparator3,
				this.selectAllToolStripMenuItem
			});
			this.contextMenuStrip.Name = "contextMenuStrip1";
			this.contextMenuStrip.RenderMode = ToolStripRenderMode.System;
			this.contextMenuStrip.ShowImageMargin = false;
			this.contextMenuStrip.Size = new Size(104, 198);
			this.contextMenuStrip.Opening += new CancelEventHandler(this.contextMenuStrip1_Opening);
			this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			this.undoToolStripMenuItem.Size = new Size(103, 22);
			this.undoToolStripMenuItem.Text = "&Undo";
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new Size(100, 6);
			this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
			this.cutToolStripMenuItem.Size = new Size(103, 22);
			this.cutToolStripMenuItem.Text = "C&ut";
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.Size = new Size(103, 22);
			this.copyToolStripMenuItem.Text = "&Copy";
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.Size = new Size(103, 22);
			this.pasteToolStripMenuItem.Text = "&Paste";
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new Size(103, 22);
			this.deleteToolStripMenuItem.Text = "&Delete";
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new Size(100, 6);
			this.findToolStripMenuItem.Name = "findToolStripMenuItem";
			this.findToolStripMenuItem.Size = new Size(103, 22);
			this.findToolStripMenuItem.Text = "&Find";
			this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
			this.replaceToolStripMenuItem.Size = new Size(103, 22);
			this.replaceToolStripMenuItem.Text = "&Replace";
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new Size(100, 6);
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.Size = new Size(103, 22);
			this.selectAllToolStripMenuItem.Text = "Select &All";
			this.findDialog1.ParentControl = this;
			this.findDialog1.ReplaceAvailable = false;
			this.findDialog1.SearchRegularExpression = null;
			this.findDialog1.ReplaceRequested += new ReplaceEventHandler(this.findDialog1_ReplaceRequested);
			this.findDialog1.CancelReplaceRequested += new EventHandler(this.findDialog1_CancelReplaceRequested);
			this.findDialog1.SearchRequested += new SearchEventHandler(this.findDialog1_SearchRequested);
			this.ContextMenuStrip = this.contextMenuStrip;
			base.ReadOnlyChanged += new EventHandler(this.SearchableTextBox_ReadOnlyChanged);
			base.KeyDown += new KeyEventHandler(this.SearchableTextBox_KeyDown);
			this.contextMenuStrip.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		public SearchableTextBox()
		{
			this.InitializeComponent();
			this.findDialog1.ReplaceAvailable = !base.ReadOnly;
			this.undoToolStripMenuItem.Click += new EventHandler(this.undoToolStripMenuItem_Click);
			this.cutToolStripMenuItem.Click += new EventHandler(this.cutToolStripMenuItem_Click);
			this.copyToolStripMenuItem.Click += new EventHandler(this.copyToolStripMenuItem_Click);
			this.pasteToolStripMenuItem.Click += new EventHandler(this.pasteToolStripMenuItem_Click);
			this.deleteToolStripMenuItem.Click += new EventHandler(this.deleteToolStripMenuItem_Click);
			this.selectAllToolStripMenuItem.Click += new EventHandler(this.selectAllToolStripMenuItem_Click);
			this.findToolStripMenuItem.Click += new EventHandler(this.findToolStripMenuItem_Click);
			this.replaceToolStripMenuItem.Click += new EventHandler(this.replaceToolStripMenuItem_Click);
		}

		protected void SearchableTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
			{
				base.SelectAll();
				e.SuppressKeyPress = true;
			}
			else if (e.KeyCode == Keys.F && e.Modifiers == Keys.Control)
			{
				this.NewSearch(false);
				e.SuppressKeyPress = true;
			}
			else if (e.KeyCode == Keys.H && e.Modifiers == Keys.Control)
			{
				if (!base.ReadOnly)
				{
					this.NewSearch(true);
					e.SuppressKeyPress = true;
				}
			}
			else if (e.KeyCode == Keys.F3 && e.Modifiers == Keys.None)
			{
				this.findDialog1.FindNext();
				e.SuppressKeyPress = true;
			}
			else if (e.KeyCode == Keys.Escape && e.Modifiers == Keys.None)
			{
				if (this.findDialog1.Visible)
				{
					this.findDialog1.Close();
					e.SuppressKeyPress = true;
				}
			}
			else if (e.KeyCode == Keys.Z && e.Modifiers == Keys.Control)
			{
				this.Undo();
				e.SuppressKeyPress = true;
			}
			else if (e.KeyCode == Keys.Y && e.Modifiers == Keys.Control)
			{
				this.Redo();
				e.SuppressKeyPress = true;
			}
		}

		private static bool IsWordChar(char p)
		{
			return (p >= 'a' && p <= 'z') || (p >= 'A' && p <= 'Z') || (p >= '0' && p <= '9') || p == '_';
		}

		public new void Undo()
		{
			if (this.Text.Equals(this.textAfterReplace))
			{
				this.Text = this.textBeforeReplace;
			}
			else
			{
				base.Undo();
			}
		}

		public void Redo()
		{
			if (this.Text.Equals(this.textBeforeReplace))
			{
				this.Text = this.textAfterReplace;
			}
		}

		private void NewSearch(bool replaceMode)
		{
			if (this.findDialog1.ReplaceAvailable)
			{
				this.textBeforeReplace = this.Text;
			}
			if (this.SelectedText.Length == 0)
			{
				int num = base.SelectionStart;
				while (num > 0 && SearchableTextBox.IsWordChar(this.Text[num - 1]))
				{
					num--;
				}
				int num2 = base.SelectionStart;
				while (num2 < this.Text.Length && SearchableTextBox.IsWordChar(this.Text[num2]))
				{
					num2++;
				}
				this.originalSelectionStart = num2;
				this.findDialog1.Show(this.Text.Substring(num, num2 - num), replaceMode);
			}
			else if (!this.SelectedText.Contains("\n"))
			{
				this.originalSelectionStart = base.SelectionStart;
				this.findDialog1.Show(this.SelectedText, replaceMode);
			}
			else
			{
				this.originalSelectionStart = base.SelectionStart;
				this.findDialog1.Show(replaceMode);
			}
		}

		private void RestoreHideSelection(object sender, EventArgs e)
		{
			base.HideSelection = true;
		}

		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{
			this.undoToolStripMenuItem.Enabled = this.CanUndo;
			this.cutToolStripMenuItem.Enabled = (!base.ReadOnly && this.SelectionLength > 0);
			this.copyToolStripMenuItem.Enabled = (this.SelectionLength > 0);
			this.pasteToolStripMenuItem.Enabled = !base.ReadOnly;
			this.deleteToolStripMenuItem.Enabled = (!base.ReadOnly && this.SelectionLength > 0);
			this.selectAllToolStripMenuItem.Enabled = (this.SelectionLength < this.Text.Length);
			this.replaceToolStripMenuItem.Enabled = this.findDialog1.ReplaceAvailable;
		}

		private void undoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Undo();
		}

		private void cutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			base.Cut();
		}

		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			base.Copy();
		}

		private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			base.Paste();
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendKeys.Send("{DELETE}");
		}

		private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			base.SelectAll();
		}

		private void findToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.NewSearch(false);
		}

		private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.NewSearch(true);
		}

		internal bool SubSearch(Regex regularExpression, int start, int end)
		{
			Match match = regularExpression.Match(this.Text, start, end - start);
			bool result;
			if (match.Success)
			{
				if (base.HideSelection)
				{
					this.findDialog1.Deactivate += new EventHandler(this.RestoreHideSelection);
					base.HideSelection = false;
				}
				base.Select(match.Index, match.Length);
				try
				{
					base.ScrollToCaret();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		protected void findDialog1_SearchRequested(object sender, SearchEventArgs e)
		{
			int num;
			int length;
			if (e.FirstSearch)
			{
				num = this.originalSelectionStart;
				length = this.Text.Length;
			}
			else
			{
				num = base.SelectionStart + this.SelectionLength;
				if (this.originalSelectionStart >= num)
				{
					length = this.originalSelectionStart;
				}
				else
				{
					length = this.Text.Length;
				}
			}
			bool flag = this.SubSearch(e.SearchRegularExpression, num, length);
			if (!flag && length == this.Text.Length)
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

		private void findDialog1_ReplaceRequested(object sender, ReplaceEventArgs e)
		{
			this.SelectedText = e.ReplaceText;
			if (this.findDialog1.ReplaceAvailable)
			{
				this.textAfterReplace = this.Text;
			}
		}

		private void SearchableTextBox_ReadOnlyChanged(object sender, EventArgs e)
		{
			this.findDialog1.ReplaceAvailable = !base.ReadOnly;
		}

		private void findDialog1_CancelReplaceRequested(object sender, EventArgs e)
		{
			if (this.Text.Equals(this.textAfterReplace))
			{
				this.Text = this.textBeforeReplace;
			}
		}
	}
}
