using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SearchableControls
{
	public class FindDialog : Component
	{
		internal enum SearchModes
		{
			NullState,
			Ready,
			SearchAgain,
			SearchFailed,
			SearchFinished
		}

		private Control parentControl;

		private FindForm findForm;

		private Stream formRestoreData;

		private FindDialog.SearchModes searchMode;

		private Regex searchRegularExpression;

		private bool replaceAvailable = false;

		private SearchEventHandler searchRequested;

		private ReplaceEventHandler replaceRequested;

		private EventHandler cancelReplaceRequested;

		private IContainer components = null;

		public event EventHandler Deactivate;

		public event SearchEventHandler SearchRequested
		{
			add
			{
				this.searchRequested = (SearchEventHandler)Delegate.Combine(this.searchRequested, value);
			}
			remove
			{
				this.searchRequested = (SearchEventHandler)Delegate.Remove(this.searchRequested, value);
			}
		}

		public event ReplaceEventHandler ReplaceRequested
		{
			add
			{
				this.replaceRequested = (ReplaceEventHandler)Delegate.Combine(this.replaceRequested, value);
			}
			remove
			{
				this.replaceRequested = (ReplaceEventHandler)Delegate.Remove(this.replaceRequested, value);
			}
		}

		public event EventHandler CancelReplaceRequested
		{
			add
			{
				this.cancelReplaceRequested = (EventHandler)Delegate.Combine(this.cancelReplaceRequested, value);
			}
			remove
			{
				this.cancelReplaceRequested = (EventHandler)Delegate.Remove(this.cancelReplaceRequested, value);
			}
		}

		[Browsable(false), DefaultValue("")]
		public Control ParentControl
		{
			get
			{
				if (this.parentControl == null && base.DesignMode)
				{
					IDesignerHost designerHost = (IDesignerHost)this.GetService(typeof(IDesignerHost));
					if (designerHost != null)
					{
						this.parentControl = (designerHost.RootComponent as Control);
					}
				}
				return this.parentControl;
			}
			set
			{
				if (this.parentControl != value)
				{
					this.parentControl = value;
					this.parentControl.Leave += new EventHandler(this.parentControl_Leave);
				}
			}
		}

		public bool Visible
		{
			get
			{
				return this.findForm != null;
			}
		}

		internal FindDialog.SearchModes SearchMode
		{
			get
			{
				return this.searchMode;
			}
			set
			{
				if (this.searchMode != value)
				{
					FindDialog.SearchModes searchModes = this.SearchMode;
					this.searchMode = value;
					if (this.findForm != null)
					{
						this.findForm.ApplySearchMode();
					}
				}
			}
		}

		public Regex SearchRegularExpression
		{
			get
			{
				return this.searchRegularExpression;
			}
			set
			{
				this.searchRegularExpression = value;
			}
		}

		public bool ReplaceAvailable
		{
			get
			{
				return this.replaceAvailable;
			}
			set
			{
				this.replaceAvailable = value;
			}
		}

		public bool Focused
		{
			get
			{
				return this.findForm != null && this.findForm.Focused;
			}
		}

		private void parentControl_Leave(object sender, EventArgs e)
		{
			if (this.findForm != null)
			{
				this.findForm.Hide();
			}
		}

		public FindDialog()
		{
			this.InitializeComponent();
		}

		private void findForm_Deactivate(object sender, EventArgs e)
		{
			if (this.Deactivate != null)
			{
				this.Deactivate(sender, e);
			}
		}

		public void Show(string defaultText, bool replaceMode)
		{
			if (this.findForm == null)
			{
				if (this.formRestoreData != null)
				{
					this.formRestoreData.Seek(0L, SeekOrigin.Begin);
				}
				this.findForm = new FindForm(this, this.formRestoreData, new BinaryFormatter(), defaultText, replaceMode, replaceMode || this.ReplaceAvailable);
				this.findForm.Deactivate += new EventHandler(this.findForm_Deactivate);
				this.findForm.Closing += new CancelEventHandler(this.findForm_Closing);
			}
			this.findForm.Reshow();
			if (this.findForm.ReplaceMode != replaceMode)
			{
				this.findForm.ReplaceMode = replaceMode;
			}
		}

		public void Show(string defaultText)
		{
			this.Show(defaultText, false);
		}

		public void Show(bool replaceMode)
		{
			this.Show(null, replaceMode);
		}

		public void Show()
		{
			this.Show(null, false);
		}

		public void Close()
		{
			this.findForm.Close();
		}

		internal bool Search()
		{
			SearchEventArgs searchEventArgs = new SearchEventArgs(this.SearchRegularExpression, this.SearchMode == FindDialog.SearchModes.Ready);
			if (this.searchRequested == null)
			{
				throw new Exception("No search event supplied");
			}
			this.searchRequested(this, searchEventArgs);
			bool result;
			if (searchEventArgs.Successful)
			{
				this.SearchMode = FindDialog.SearchModes.SearchAgain;
				result = true;
			}
			else
			{
				if (searchEventArgs.FirstSearch)
				{
					this.SearchMode = FindDialog.SearchModes.SearchFailed;
				}
				else
				{
					this.SearchMode = FindDialog.SearchModes.SearchFinished;
				}
				result = false;
			}
			return result;
		}

		public bool FindNextIsAvailable()
		{
			return this.SearchMode == FindDialog.SearchModes.SearchAgain;
		}

		public bool FindNext()
		{
			return this.FindNextIsAvailable() && this.Search();
		}

		private void findForm_Closing(object sender, CancelEventArgs e)
		{
			this.formRestoreData = new MemoryStream();
			this.findForm.GetRestoreData(this.formRestoreData, new BinaryFormatter());
			this.findForm = null;
			this.ParentControl.Focus();
		}

		internal void Replace(string replaceText)
		{
			ReplaceEventArgs replaceEventArgs = new ReplaceEventArgs();
			replaceEventArgs.ReplaceText = replaceText;
			if (this.replaceRequested == null)
			{
				throw new Exception("No replace event handler supplied");
			}
			this.replaceRequested(this, replaceEventArgs);
		}

		internal void CancelReplace()
		{
			if (this.cancelReplaceRequested == null)
			{
				throw new Exception("No replace event handler supplied");
			}
			this.cancelReplaceRequested(this, EventArgs.Empty);
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
		}
	}
}
