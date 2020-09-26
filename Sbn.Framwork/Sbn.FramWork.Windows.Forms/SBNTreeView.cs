using SearchableControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Sbn.FramWork.Windows.Forms
{
	public class SBNTreeView : TreeView, ISearchable
	{
		public delegate bool NodeSearchDelegate(TreeNode node, Regex regularExpression);

		private enum TreeSearchState
		{
			NotStarted,
			Started,
			MatchMade,
			HitEndNode
		}

		private ImageList _ilStateImages;

		private bool _bUseTriState;

		private bool _bCheckBoxesVisible;

		private bool _bPreventCheckEvent;

		private bool _heredity = true;

		private SBNTreeView.NodeSearchDelegate nodeSearcher;

		private TreeNode originalSelectionStart;

		private IContainer components = null;

		private ContextMenuStrip contextMenuStrip;

		private ToolStripMenuItem findToolStripMenuItem;

		private FindDialog findDialog1;

		[Category("Appearance"), DefaultValue(false), Description("Sets tree view to display checkboxes or not.")]
		public new bool CheckBoxes
		{
			get
			{
				return this._bCheckBoxesVisible;
			}
			set
			{
				this._bCheckBoxesVisible = value;
				base.CheckBoxes = this._bCheckBoxesVisible;
				this.StateImageList = (this._bCheckBoxesVisible ? this._ilStateImages : null);
				this.Refresh();
			}
		}

		[Browsable(false)]
		public new ImageList StateImageList
		{
			get
			{
				return base.StateImageList;
			}
			set
			{
				base.StateImageList = value;
			}
		}

		[Category("Appearance"), DefaultValue(true), Description("Sets tree view to use tri-state checkboxes or not.")]
		public bool CheckBoxesTriState
		{
			get
			{
				return this._bUseTriState;
			}
			set
			{
				this._bUseTriState = value;
			}
		}

		public bool Heredity
		{
			get
			{
				return this._heredity;
			}
			set
			{
				this._heredity = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public SBNTreeView.NodeSearchDelegate NodeSearcher
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

		public SBNTreeView()
		{
			this._ilStateImages = new ImageList();
			CheckBoxState state = CheckBoxState.UncheckedNormal;
			for (int i = 0; i <= 2; i++)
			{
				Bitmap bitmap = new Bitmap(16, 16);
				Graphics graphics = Graphics.FromImage(bitmap);
				switch (i)
				{
				case 0:
					state = CheckBoxState.UncheckedNormal;
					break;
				case 1:
					state = CheckBoxState.CheckedNormal;
					break;
				case 2:
					state = CheckBoxState.MixedNormal;
					break;
				}
				CheckBoxRenderer.DrawCheckBox(graphics, new Point(2, 2), state);
				graphics.Save();
				this._ilStateImages.Images.Add(bitmap);
				this._bUseTriState = true;
			}
			this.InitializeComponent();
			this.nodeSearcher = new SBNTreeView.NodeSearchDelegate(this.DefaultNodeSearch);
			this.findToolStripMenuItem.Click += new EventHandler(this.findToolStripMenuItem_Click);
		}

		public override void Refresh()
		{
			base.Refresh();
			if (this.CheckBoxes)
			{
				base.CheckBoxes = false;
				Stack<TreeNode> stack = new Stack<TreeNode>(base.Nodes.Count);
				foreach (TreeNode item in base.Nodes)
				{
					stack.Push(item);
				}
				while (stack.Count > 0)
				{
					TreeNode treeNode = stack.Pop();
					if (treeNode != null)
					{
						if (treeNode.StateImageIndex == -1)
						{
							for (int i = 0; i < treeNode.Nodes.Count; i++)
							{
								stack.Push(treeNode.Nodes[i]);
							}
						}
					}
				}
			}
		}

		protected override void OnLayout(LayoutEventArgs levent)
		{
			base.OnLayout(levent);
			this.Refresh();
		}

		protected override void OnAfterExpand(TreeViewEventArgs e)
		{
			base.OnAfterExpand(e);
		}

		protected override void OnAfterCheck(TreeViewEventArgs e)
		{
			base.OnAfterCheck(e);
			if (!this._bPreventCheckEvent)
			{
				this.OnNodeMouseClick(new TreeNodeMouseClickEventArgs(e.Node, MouseButtons.None, 0, 0, 0));
			}
		}

		protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
		{
			base.OnNodeMouseClick(e);
			this._bPreventCheckEvent = true;
			int num = (base.ImageList == null) ? 0 : 18;
			if ((e.X <= e.Node.Bounds.Left - num && e.X >= e.Node.Bounds.Left - (num + 16)) || e.Button == MouseButtons.None)
			{
				TreeNode treeNode = e.Node;
				if (e.Button == MouseButtons.Left)
				{
					treeNode.Checked = !treeNode.Checked;
				}
				if (!this.Heredity)
				{
					if (treeNode.Checked)
					{
						treeNode.StateImageIndex = 1;
					}
					else
					{
						treeNode.StateImageIndex = 0;
					}
					this._bPreventCheckEvent = false;
				}
				else
				{
					treeNode.StateImageIndex = (treeNode.Checked ? 1 : treeNode.StateImageIndex);
					this.OnAfterCheck(new TreeViewEventArgs(treeNode, TreeViewAction.ByMouse));
					Stack<TreeNode> stack = new Stack<TreeNode>(treeNode.Nodes.Count);
					stack.Push(treeNode);
					do
					{
						treeNode = stack.Pop();
						treeNode.Checked = e.Node.Checked;
						for (int i = 0; i < treeNode.Nodes.Count; i++)
						{
							stack.Push(treeNode.Nodes[i]);
						}
					}
					while (stack.Count > 0);
					bool flag = false;
					treeNode = e.Node;
					while (treeNode.Parent != null)
					{
						foreach (TreeNode treeNode2 in treeNode.Parent.Nodes)
						{
							flag |= (treeNode2.Checked != treeNode.Checked | treeNode2.StateImageIndex == 2);
						}
						int num2 = (int)Convert.ToUInt32(treeNode.Checked);
						treeNode.Parent.Checked = (flag || num2 > 0);
						if (flag)
						{
							treeNode.Parent.StateImageIndex = (this.CheckBoxesTriState ? 2 : 1);
						}
						else
						{
							treeNode.Parent.StateImageIndex = num2;
						}
						treeNode = treeNode.Parent;
					}
					this._bPreventCheckEvent = false;
				}
			}
		}

		private void findToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.findDialog1.Show();
		}

		protected void SearchableTreeView_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F && e.Modifiers == Keys.Control)
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

		private bool DefaultNodeSearch(TreeNode treeNode, Regex regularExpression)
		{
			return regularExpression.IsMatch(treeNode.Text);
		}

		private void SubSearch(Regex regularExpression, TreeNodeCollection treeNodeCollection, TreeNode startAfterNode, TreeNode stopAtNode, ref SBNTreeView.TreeSearchState state)
		{
			foreach (TreeNode treeNode in treeNodeCollection)
			{
				if (state == SBNTreeView.TreeSearchState.Started)
				{
					if (treeNode == stopAtNode)
					{
						state = SBNTreeView.TreeSearchState.HitEndNode;
						break;
					}
					if (this.nodeSearcher(treeNode, regularExpression))
					{
						if (base.HideSelection)
						{
							this.findDialog1.Deactivate += new EventHandler(this.RestoreHideSelection);
							base.HideSelection = false;
						}
						base.SelectedNode = treeNode;
						base.SelectedNode.EnsureVisible();
						state = SBNTreeView.TreeSearchState.MatchMade;
						break;
					}
				}
				if (startAfterNode == treeNode)
				{
					state = SBNTreeView.TreeSearchState.Started;
				}
				this.SubSearch(regularExpression, treeNode.Nodes, startAfterNode, stopAtNode, ref state);
				if (state == SBNTreeView.TreeSearchState.HitEndNode)
				{
					break;
				}
				if (state == SBNTreeView.TreeSearchState.MatchMade)
				{
					break;
				}
			}
		}

		private void findDialog1_SearchRequested(object sender, SearchEventArgs e)
		{
			if (e.FirstSearch)
			{
				this.originalSelectionStart = base.SelectedNode;
			}
			TreeNode selectedNode = base.SelectedNode;
			SBNTreeView.TreeSearchState treeSearchState = SBNTreeView.TreeSearchState.NotStarted;
			this.SubSearch(e.SearchRegularExpression, base.Nodes, selectedNode, this.originalSelectionStart, ref treeSearchState);
			if (treeSearchState == SBNTreeView.TreeSearchState.MatchMade)
			{
				e.Successful = true;
			}
			else if (treeSearchState != SBNTreeView.TreeSearchState.HitEndNode)
			{
				e.RestartedFromDocumentTop = true;
				treeSearchState = SBNTreeView.TreeSearchState.Started;
				this.SubSearch(e.SearchRegularExpression, base.Nodes, null, this.originalSelectionStart, ref treeSearchState);
				if (treeSearchState == SBNTreeView.TreeSearchState.MatchMade)
				{
					e.Successful = true;
				}
			}
		}

		public void Search(Regex str)
		{
			SearchEventArgs e = new SearchEventArgs(str, true);
			this.findDialog1_SearchRequested(this, e);
		}

		private void RestoreHideSelection(object sender, EventArgs e)
		{
			base.HideSelection = true;
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
			this.contextMenuStrip = new ContextMenuStrip();
			this.findToolStripMenuItem = new ToolStripMenuItem();
			this.findDialog1 = new FindDialog();
			this.contextMenuStrip.SuspendLayout();
			base.SuspendLayout();
			this.contextMenuStrip.Items.AddRange(new ToolStripItem[]
			{
				this.findToolStripMenuItem
			});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.RenderMode = ToolStripRenderMode.System;
			this.contextMenuStrip.ShowImageMargin = false;
			this.contextMenuStrip.Size = new Size(81, 26);
			this.findToolStripMenuItem.Name = "findToolStripMenuItem";
			this.findToolStripMenuItem.Size = new Size(80, 22);
			this.findToolStripMenuItem.Text = "&Find";
			this.findDialog1.ParentControl = this;
			this.findDialog1.ReplaceAvailable = false;
			this.findDialog1.SearchRegularExpression = null;
			this.findDialog1.SearchRequested += new SearchEventHandler(this.findDialog1_SearchRequested);
			this.RightToLeft = RightToLeft.Yes;
			this.RightToLeftLayout = true;
			this.ContextMenuStrip = this.contextMenuStrip;
			base.KeyDown += new KeyEventHandler(this.SearchableTreeView_KeyDown);
			this.contextMenuStrip.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
