using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Drawing;
using System.ComponentModel;
using SearchableControls;

namespace Sbn.FramWork.Windows.Forms
{
    //public class SBNTreeView : TreeView
    //{
    //}

    /// <summary>
    /// Provides a tree view
    /// control supporting
    /// tri-state checkboxes.
    /// </summary>
    public partial class SBNTreeView : TreeView, ISearchable
    {

        // ~~~ fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        ImageList _ilStateImages;
        bool _bUseTriState;
        bool _bCheckBoxesVisible;
        bool _bPreventCheckEvent;

        // ~~~ constructor ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        /// <summary>
        /// Creates a new instance
        /// of this control.
        /// </summary>
        public SBNTreeView()
            : base()
        {
            CheckBoxState cbsState;
            Graphics gfxCheckBox;
            Bitmap bmpCheckBox;

            _ilStateImages = new ImageList();											// first we create our state image
            cbsState = CheckBoxState.UncheckedNormal;									// list and pre-init check state.

            for (int i = 0; i <= 2; i++)
            {												// let's iterate each tri-state
                bmpCheckBox = new Bitmap(16, 16);										// creating a new checkbox bitmap
                gfxCheckBox = Graphics.FromImage(bmpCheckBox);							// and getting graphics object from
                switch (i)
                {															// it...
                    case 0: cbsState = CheckBoxState.UncheckedNormal; break;
                    case 1: cbsState = CheckBoxState.CheckedNormal; break;
                    case 2: cbsState = CheckBoxState.MixedNormal; break;
                }
                CheckBoxRenderer.DrawCheckBox(gfxCheckBox, new Point(2, 2), cbsState);	// ...rendering the checkbox and...
                gfxCheckBox.Save();
                _ilStateImages.Images.Add(bmpCheckBox);									// ...adding to sate image list.

                _bUseTriState = true;
            }

            InitializeComponent();

            nodeSearcher = new NodeSearchDelegate(DefaultNodeSearch); // create default search delegate

            // Currently there is no designer support for adding menu item event handlers
            findToolStripMenuItem.Click += new EventHandler(findToolStripMenuItem_Click);
        }

        // ~~~ properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        /// <summary>
        /// Gets or sets to display
        /// checkboxes in the tree
        /// view.
        /// </summary>
        [Category("Appearance")]
        [Description("Sets tree view to display checkboxes or not.")]
        [DefaultValue(false)]
        public new bool CheckBoxes
        {
            get { return _bCheckBoxesVisible; }
            set
            {
                _bCheckBoxesVisible = value;
                base.CheckBoxes = _bCheckBoxesVisible;
                StateImageList = _bCheckBoxesVisible ? _ilStateImages : null;

                Refresh(); //Added By rm
            }
        }

        [Browsable(false)]
        public new ImageList StateImageList
        {
            get { return base.StateImageList; }
            set { base.StateImageList = value; }
        }

        /// <summary>
        /// Gets or sets to support
        /// tri-state in the checkboxes
        /// or not.
        /// </summary>
        [Category("Appearance")]
        [Description("Sets tree view to use tri-state checkboxes or not.")]
        [DefaultValue(true)]
        public bool CheckBoxesTriState
        {
            get { return _bUseTriState; }
            set { _bUseTriState = value; }
        }

        // ~~~ functions ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        /// <summary>
        /// Refreshes this
        /// control.
        /// </summary>
        public override void Refresh()
        {
            Stack<TreeNode> stNodes;
            TreeNode tnStacked;

            base.Refresh();

            if (!CheckBoxes)												// nothing to do here if
                return;														// checkboxes are hidden.

            base.CheckBoxes = false;										// hide normal checkboxes...

            stNodes = new Stack<TreeNode>(this.Nodes.Count);				// create a new stack and
            foreach (TreeNode tnCurrent in this.Nodes)						// push each root node.
                stNodes.Push(tnCurrent);

            while (stNodes.Count > 0)
            {										// let's pop node from stack,
                tnStacked = stNodes.Pop();									// set correct state image
                if (tnStacked != null)
                {
                    if (tnStacked.StateImageIndex == -1)						// index if not already done                   tnStacked.StateImageIndex = tnStacked.Checked ? 1 : 0;	// and push each child to stack
                        for (int i = 0; i < tnStacked.Nodes.Count; i++)				// too until there are no
                            stNodes.Push(tnStacked.Nodes[i]);						// nodes left on stack.
                }
            }
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
            Refresh();
        }

        

        protected override void OnAfterExpand(TreeViewEventArgs e)
        {
            base.OnAfterExpand(e);

            //foreach (TreeNode tnCurrent in e.Node.Nodes)					// set tree state image
            //    if (tnCurrent.StateImageIndex == -1)						// to each child node...
            //        tnCurrent.StateImageIndex = tnCurrent.Checked ? 1 : 0;
        }

        protected override void OnAfterCheck(TreeViewEventArgs e)
        {
            base.OnAfterCheck(e);

            if (_bPreventCheckEvent)// || e.Action == TreeViewAction.ByMouse)
                return;

            OnNodeMouseClick(new TreeNodeMouseClickEventArgs(e.Node, MouseButtons.None, 0, 0, 0));

           
        }


        bool _heredity = true;
        /// <summary>
        /// اعمال وراثت در انتخاب نودها
        /// </summary>
        public bool Heredity
        {
            get { return _heredity; }
            set { _heredity = value; }
        }

      
        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            Stack<TreeNode> stNodes;
            TreeNode tnBuffer;
            bool bMixedState;
            int iSpacing;
            int iIndex;

            base.OnNodeMouseClick(e);

           
           
            _bPreventCheckEvent = true;

            iSpacing = ImageList == null ? 0 : 18;							// if user clicked area


            if ((e.X > e.Node.Bounds.Left - iSpacing ||						// *not* used by the state
                 e.X < e.Node.Bounds.Left - (iSpacing + 16)) &&				// image we can leave here.
                 e.Button != MouseButtons.None)
            { return; }
           

            tnBuffer = e.Node;												// buffer clicked node and
            if (e.Button == MouseButtons.Left)								// flip its check state.
                tnBuffer.Checked = !tnBuffer.Checked;

          if (!Heredity)
            {
                if (tnBuffer.Checked)
                {
                    tnBuffer.StateImageIndex = 1;
                }
                else
                {
                    tnBuffer.StateImageIndex = 0;
                }
                _bPreventCheckEvent = false;
                return;
            }
           


            tnBuffer.StateImageIndex = tnBuffer.Checked ?					// set state image index
                                            1 : tnBuffer.StateImageIndex;		// correctly.

            OnAfterCheck(new TreeViewEventArgs(tnBuffer, TreeViewAction.ByMouse));

            stNodes = new Stack<TreeNode>(tnBuffer.Nodes.Count);			// create a new stack and
            stNodes.Push(tnBuffer);											// push buffered node first.
            do
            {															// let's pop node from stack,
                tnBuffer = stNodes.Pop();									// inherit buffered node's
                tnBuffer.Checked = e.Node.Checked;							// check state and push
                for (int i = 0; i < tnBuffer.Nodes.Count; i++)				// each child on the stack
                    stNodes.Push(tnBuffer.Nodes[i]);						// until there is no node
            } while (stNodes.Count > 0);									// left.

            bMixedState = false;
            tnBuffer = e.Node;												// re-buffer clicked node.
            while (tnBuffer.Parent != null)
            {								// while we get a parent we
                foreach (TreeNode tnChild in tnBuffer.Parent.Nodes)			// determine mixed check states
                    bMixedState |= (tnChild.Checked != tnBuffer.Checked |	// and convert current check
                                    tnChild.StateImageIndex == 2);			// state to state image index.
                iIndex = (int)Convert.ToUInt32(tnBuffer.Checked);			// set parent's check state and
                tnBuffer.Parent.Checked = bMixedState || (iIndex > 0);		// state image in dependency
                if (bMixedState)											// of mixed state.
                    tnBuffer.Parent.StateImageIndex = CheckBoxesTriState ? 2 : 1;
                else
                    tnBuffer.Parent.StateImageIndex = iIndex;
                tnBuffer = tnBuffer.Parent;									// finally buffer parent and
            }																// loop here.

            _bPreventCheckEvent = false;
        }



     


        /// <summary>
        /// Delegate of node searching function.
        /// </summary>
        /// <param name="node">The TreeNode to search</param>
        /// <param name="regularExpression">The regular expression to use to match text</param>
        /// <returns>'True' if the treeNode is deemed to have matched</returns>
        public delegate bool NodeSearchDelegate(TreeNode node, Regex regularExpression);

        /// <summary>
        /// Node searching function
        /// </summary>
        /// <remarks>
        /// This is set to a search of the Text property of the treeNode, but can be overridden by the
        /// client to provide custom search facilities of whatever the node conceptually contains, typically
        /// by using the node's Tag value to link it to an object.
        /// </remarks>
        [DesignerSerializationVisibility(0)]
        public NodeSearchDelegate NodeSearcher
        {
            get { return nodeSearcher; }
            set { nodeSearcher = value; }
        }

        private NodeSearchDelegate nodeSearcher;

        /// <summary>
        /// Find Text from context menu
        /// </summary>
        void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findDialog1.Show();
        }

        /// <summary>
        /// Handle key events. Used to provide find functions
        /// </summary>
        /// <param name="sender">Standard system parameter</param>
        /// <param name="e">Standard system parameter</param>
        protected void SearchableTreeView_KeyDown(object sender, KeyEventArgs e)
        {
            // Control F pressed, for 'Find'?
            if (e.KeyCode == Keys.F && e.Modifiers == Keys.Control)
            {
                findDialog1.Show();
                e.SuppressKeyPress = true; // don't pass the event down
            }
            // F3 pressed, for search again?
            else if (e.KeyCode == Keys.F3 && e.Modifiers == Keys.None)
            {
                findDialog1.FindNext();
                e.SuppressKeyPress = true; // don't pass the event down
            }

        }

        /// <summary>
        /// Default function to search a node
        /// </summary>
        /// <param name="treeNode">The TreeNode to search</param>
        /// <param name="regularExpression">The regular expression to use to match text</param>
        /// <returns>'True' if the treeNode is deemed to have matched</returns>
        private bool DefaultNodeSearch(TreeNode treeNode, Regex regularExpression)
        {
          
            return regularExpression.IsMatch(treeNode.Text);
        }

        /// <summary>
        /// The various modes that the recursive scan can be in
        /// </summary>
        private enum TreeSearchState
        {
            NotStarted,
            Started,
            MatchMade,
            HitEndNode
        }

        /// <summary>
        /// A recursive 'sub search' command is used to search part of the tree
        /// </summary>
        /// <param name="regularExpression">The regular expression to use to match text</param>
        /// <param name="treeNodeCollection">The collection of nodes to search down from</param>
        /// <param name="startAfterNode">The node that searching actually begins from
        /// (otherwise just walk the tree until this node is found)</param>
        /// <param name="stopAtNode">A node to terminate the search at</param>
        /// <param name="state">Sends and returns the state of the recursive search</param>
        private void SubSearch(Regex regularExpression, TreeNodeCollection treeNodeCollection, TreeNode startAfterNode, TreeNode stopAtNode, ref TreeSearchState state)
        {
            foreach (TreeNode treeNode in treeNodeCollection)
            {
                if (state == TreeSearchState.Started) // Has the search started?
                {
                    if (treeNode == stopAtNode)
                    {
                        state = TreeSearchState.HitEndNode;
                        return;
                    }


                    if (nodeSearcher(treeNode, regularExpression))
                    {
                        // We need to show search results even when the FindDialog is active
                        // This means turning off HideSelection if it is set.
                        // This unfortunately causes a slight flicker. One way to avoid this is to turn off HideSelection
                        // in individual control instances.
                        if (HideSelection)
                        {
                            // Ensure that the property is restored when the FindDialog is deactivated
                            findDialog1.Deactivate += new EventHandler(RestoreHideSelection);
                            HideSelection = false;
                        }
                        SelectedNode = treeNode;
                        SelectedNode.EnsureVisible();  // Make sure the result node is visible
                        state = TreeSearchState.MatchMade;
                        return;
                    }
                }
                if (startAfterNode == treeNode)
                {
                    state = TreeSearchState.Started;
                }

                // sub search child nodes
                SubSearch(regularExpression, treeNode.Nodes, startAfterNode, stopAtNode, ref state);
                if (state == TreeSearchState.HitEndNode)
                {
                    return;
                }
                if (state == TreeSearchState.MatchMade)
                {
                    return;
                }
            }
        }

        /// <summary>
        /// A record of the first node of a search series
        /// </summary>
        private TreeNode originalSelectionStart;

        private void findDialog1_SearchRequested(object sender, SearchEventArgs e)
        {
            
            if (e.FirstSearch)
            {
                // Store the selection start position on the first search so that when all searches are complete
                // this fact can be reported to the user in the find dialog.
                originalSelectionStart = SelectedNode;
            }

            // First part of search is between item after current selection (inclusive) and the end of the
            // document (exclusive), or the original search position position (exclusive) if this is greater
            // than the current selection position
            TreeNode searchFromBelow = SelectedNode;
            TreeSearchState treeSearchState = TreeSearchState.NotStarted;

            // A SubSearch function is used to search part of the tree
            SubSearch(e.SearchRegularExpression, Nodes, searchFromBelow, originalSelectionStart, ref treeSearchState);
            if (treeSearchState == TreeSearchState.MatchMade)
            {
                e.Successful = true;// We have a match
            }
            else if (treeSearchState != TreeSearchState.HitEndNode)
            {
                // No match? We hit end of document
                // Retry from the beginning if the original start position is before or equal to the current selection
                e.RestartedFromDocumentTop = true; // The user is informed that the search started from the top
                treeSearchState = TreeSearchState.Started;

                // Search first half of the document
                SubSearch(e.SearchRegularExpression, Nodes, null, originalSelectionStart, ref treeSearchState);
                if (treeSearchState == TreeSearchState.MatchMade)
                {
                    e.Successful = true; // We have a match
                }
            }

        }

        public void Search(Regex str )
        {
            
            SearchEventArgs eventArgs = new SearchEventArgs(str, true);

            findDialog1_SearchRequested(this, eventArgs);
        }

        /// <summary>
        /// Put this control's HideSelection property back to normal when the FindDialog is deactivated
        /// </summary>
        /// <remarks>
        /// This unfortunately causes a slight flicker. One way to avoid this is to turn off HideSelection
        /// in individual control instances.
        /// </remarks>
        void RestoreHideSelection(object sender, EventArgs e)
        {
            HideSelection = true;
        }

        #region ISearchable Members

        /// <summary>
        /// Return the FindDialog associated with the control
        /// </summary>
        public FindDialog FindDialog
        {
            get
            {
                return findDialog1;
            }
        }

        #endregion
    }
}
