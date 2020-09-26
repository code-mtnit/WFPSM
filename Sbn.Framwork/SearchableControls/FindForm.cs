using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SearchableControls
{
	internal class FindForm : Form
	{
		private enum SearchType
		{
			PlainTextSearch,
			Wildcards,
			RegularExpression
		}

		private IContainer components = null;

		private Button searchButton;

		private CheckBox ignoreCaseCheckBox;

		private ComboBox searchTypeComboBox;

		private ComboBox searchHistoryComboBox;

		private Label label1;

		private Label label2;

		private ComboBox replaceHistoryComboBox;

		private Button replaceButton;

		private Button replaceAllButton;

		private CheckBox replaceModeCheckBox;

		private Button cancelButton;

		protected FindDialog findDialog;

		private int numberFindAllReplaces = 0;

		private Regex searchRegularExpression;

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

		internal bool ReplaceMode
		{
			get
			{
				return this.replaceModeCheckBox.Checked;
			}
			set
			{
				this.replaceModeCheckBox.Checked = value;
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
			this.searchButton = new Button();
			this.ignoreCaseCheckBox = new CheckBox();
			this.searchTypeComboBox = new ComboBox();
			this.searchHistoryComboBox = new ComboBox();
			this.label1 = new Label();
			this.label2 = new Label();
			this.replaceHistoryComboBox = new ComboBox();
			this.replaceButton = new Button();
			this.replaceAllButton = new Button();
			this.replaceModeCheckBox = new CheckBox();
			this.cancelButton = new Button();
			base.SuspendLayout();
			this.searchButton.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.searchButton.Location = new Point(300, 24);
			this.searchButton.Name = "searchButton";
			this.searchButton.Size = new Size(79, 23);
			this.searchButton.TabIndex = 2;
			this.searchButton.Text = "&Search";
			this.searchButton.UseVisualStyleBackColor = true;
			this.searchButton.Click += new EventHandler(this.searchButton_Click);
			this.searchButton.KeyDown += new KeyEventHandler(this.FindDialog_KeyDown);
			this.ignoreCaseCheckBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.ignoreCaseCheckBox.AutoSize = true;
			this.ignoreCaseCheckBox.Checked = true;
			this.ignoreCaseCheckBox.CheckState = CheckState.Checked;
			this.ignoreCaseCheckBox.Location = new Point(11, 102);
			this.ignoreCaseCheckBox.Name = "ignoreCaseCheckBox";
			this.ignoreCaseCheckBox.Size = new Size(82, 17);
			this.ignoreCaseCheckBox.TabIndex = 3;
			this.ignoreCaseCheckBox.Text = "Ignore &case";
			this.ignoreCaseCheckBox.UseVisualStyleBackColor = true;
			this.ignoreCaseCheckBox.CheckedChanged += new EventHandler(this.ignoreCaseCheckBox_CheckedChanged);
			this.ignoreCaseCheckBox.KeyDown += new KeyEventHandler(this.FindDialog_KeyDown);
			this.searchTypeComboBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.searchTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.searchTypeComboBox.FlatStyle = FlatStyle.Flat;
			this.searchTypeComboBox.FormattingEnabled = true;
			this.searchTypeComboBox.Location = new Point(90, 100);
			this.searchTypeComboBox.Name = "searchTypeComboBox";
			this.searchTypeComboBox.Size = new Size(119, 21);
			this.searchTypeComboBox.TabIndex = 4;
			this.searchTypeComboBox.SelectedIndexChanged += new EventHandler(this.searchTypeComboBox_SelectedIndexChanged);
			this.searchTypeComboBox.KeyDown += new KeyEventHandler(this.FindDialog_KeyDown);
			this.searchHistoryComboBox.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.searchHistoryComboBox.FormattingEnabled = true;
			this.searchHistoryComboBox.Location = new Point(6, 26);
			this.searchHistoryComboBox.Name = "searchHistoryComboBox";
			this.searchHistoryComboBox.Size = new Size(288, 21);
			this.searchHistoryComboBox.TabIndex = 5;
			this.searchHistoryComboBox.TextChanged += new EventHandler(this.searchHistoryComboBox_TextChanged);
			this.searchHistoryComboBox.KeyDown += new KeyEventHandler(this.FindDialog_KeyDown);
			this.label1.AutoSize = true;
			this.label1.Location = new Point(5, 10);
			this.label1.Name = "label1";
			this.label1.Size = new Size(47, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Find text";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(5, 50);
			this.label2.Name = "label2";
			this.label2.Size = new Size(69, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Replace with";
			this.replaceHistoryComboBox.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.replaceHistoryComboBox.FormattingEnabled = true;
			this.replaceHistoryComboBox.Location = new Point(6, 64);
			this.replaceHistoryComboBox.Name = "replaceHistoryComboBox";
			this.replaceHistoryComboBox.Size = new Size(288, 21);
			this.replaceHistoryComboBox.TabIndex = 7;
			this.replaceButton.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.replaceButton.Location = new Point(300, 62);
			this.replaceButton.Name = "replaceButton";
			this.replaceButton.Size = new Size(79, 23);
			this.replaceButton.TabIndex = 2;
			this.replaceButton.Text = "&Replace";
			this.replaceButton.UseVisualStyleBackColor = true;
			this.replaceButton.Click += new EventHandler(this.replaceButton_Click);
			this.replaceButton.KeyDown += new KeyEventHandler(this.FindDialog_KeyDown);
			this.replaceAllButton.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.replaceAllButton.Location = new Point(300, 100);
			this.replaceAllButton.Name = "replaceAllButton";
			this.replaceAllButton.Size = new Size(79, 23);
			this.replaceAllButton.TabIndex = 2;
			this.replaceAllButton.Text = "Replace &All";
			this.replaceAllButton.UseVisualStyleBackColor = true;
			this.replaceAllButton.Click += new EventHandler(this.replaceAllButton_Click);
			this.replaceAllButton.KeyDown += new KeyEventHandler(this.FindDialog_KeyDown);
			this.replaceModeCheckBox.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.replaceModeCheckBox.AutoSize = true;
			this.replaceModeCheckBox.Checked = true;
			this.replaceModeCheckBox.CheckState = CheckState.Checked;
			this.replaceModeCheckBox.Location = new Point(319, 5);
			this.replaceModeCheckBox.Name = "replaceModeCheckBox";
			this.replaceModeCheckBox.Size = new Size(66, 17);
			this.replaceModeCheckBox.TabIndex = 9;
			this.replaceModeCheckBox.Text = "Replace";
			this.replaceModeCheckBox.UseVisualStyleBackColor = true;
			this.replaceModeCheckBox.CheckedChanged += new EventHandler(this.replaceModeCheckBox_CheckedChanged);
			this.cancelButton.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.cancelButton.DialogResult = DialogResult.Cancel;
			this.cancelButton.Enabled = false;
			this.cancelButton.Location = new Point(215, 100);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new Size(79, 23);
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "&Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new EventHandler(this.cancelButton_Click);
			this.cancelButton.KeyDown += new KeyEventHandler(this.FindDialog_KeyDown);
			base.AcceptButton = this.searchButton;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(384, 130);
			base.Controls.Add(this.replaceModeCheckBox);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.replaceHistoryComboBox);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.searchHistoryComboBox);
			base.Controls.Add(this.searchTypeComboBox);
			base.Controls.Add(this.cancelButton);
			base.Controls.Add(this.replaceAllButton);
			base.Controls.Add(this.replaceButton);
			base.Controls.Add(this.ignoreCaseCheckBox);
			base.Controls.Add(this.searchButton);
			base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			base.MaximizeBox = false;
			this.MaximumSize = new Size(800, 199);
			base.MinimizeBox = false;
			this.MinimumSize = new Size(392, 26);
			base.Name = "FindForm";
			base.Padding = new Padding(2);
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.Manual;
			this.Text = "Find Text";
			base.KeyDown += new KeyEventHandler(this.FindDialog_KeyDown);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public FindForm(FindDialog _findDialog, Stream restoreData, IFormatter formatter, string defaultText, bool replaceMode, bool offerReplace)
		{
			this.findDialog = _findDialog;
			base.Owner = this.findDialog.ParentControl.FindForm();
			this.InitializeComponent();
			this.findDialog.SearchMode = FindDialog.SearchModes.Ready;
			this.replaceModeCheckBox.Visible = offerReplace;
			foreach (FindForm.SearchType searchType in Enum.GetValues(typeof(FindForm.SearchType)))
			{
				this.searchTypeComboBox.Items.Add(searchType.ToString()[0] + Regex.Replace(searchType.ToString().Substring(1), "(\\B[A-Z])", " $1").ToLower());
			}
			this.searchTypeComboBox.SelectedIndex = 0;
			if (restoreData == null)
			{
				this.replaceModeCheckBox.Checked = replaceMode;
				Control parentControl = this.findDialog.ParentControl;
				Rectangle workingArea = Screen.GetWorkingArea(this);
				Rectangle rectangle = new Rectangle(parentControl.PointToScreen(new Point(parentControl.Width - base.Width, -base.Height)), base.Size);
				if (!Rectangle.Intersect(workingArea, rectangle).Equals(rectangle))
				{
					rectangle = new Rectangle(parentControl.PointToScreen(new Point(parentControl.Width - base.Width, parentControl.Height)), base.Size);
				}
				base.Bounds = rectangle;
			}
			else
			{
				this.ApplyRestoreData(restoreData, formatter);
				this.replaceModeCheckBox.Checked = replaceMode;
			}
			this.ApplySearchMode();
			if (defaultText != null)
			{
				this.searchHistoryComboBox.Text = defaultText;
			}
			this.Reshow();
		}

		private void searchButton_Click(object sender, EventArgs e)
		{
			if (this.searchHistoryComboBox.Items.Count == 0 || !this.searchHistoryComboBox.Text.Equals(this.searchHistoryComboBox.Items[this.searchHistoryComboBox.Items.Count - 1]))
			{
				this.searchHistoryComboBox.Items.Add(this.searchHistoryComboBox.Text);
			}
			this.SearchPressed();
		}

		private void replaceButton_Click(object sender, EventArgs e)
		{
			if (this.replaceHistoryComboBox.Items.Count == 0 || !this.replaceHistoryComboBox.Text.Equals(this.replaceHistoryComboBox.Items[this.replaceHistoryComboBox.Items.Count - 1]))
			{
				this.replaceHistoryComboBox.Items.Add(this.replaceHistoryComboBox.Text);
			}
			switch (this.findDialog.SearchMode)
			{
			case FindDialog.SearchModes.Ready:
			case FindDialog.SearchModes.SearchFailed:
				this.SearchPressed();
				break;
			case FindDialog.SearchModes.SearchAgain:
			case FindDialog.SearchModes.SearchFinished:
				this.findDialog.Replace(this.replaceHistoryComboBox.Text);
				this.cancelButton.Enabled = true;
				this.SearchPressed();
				break;
			}
		}

		private void replaceAllButton_Click(object sender, EventArgs e)
		{
			if (this.findDialog.SearchMode == FindDialog.SearchModes.Ready)
			{
				this.SearchPressed();
			}
			while (this.findDialog.SearchMode == FindDialog.SearchModes.SearchAgain)
			{
				this.findDialog.Replace(this.replaceHistoryComboBox.Text);
				this.numberFindAllReplaces++;
				this.findDialog.Search();
			}
			if (this.findDialog.SearchMode == FindDialog.SearchModes.SearchFinished)
			{
				this.findDialog.Replace(this.replaceHistoryComboBox.Text);
			}
			if (this.numberFindAllReplaces > 0)
			{
				new InfoForm(this.numberFindAllReplaces.ToString() + " occurance(s) replaced", base.Owner).ShowDialog();
				this.numberFindAllReplaces = 0;
			}
			this.cancelButton.Enabled = true;
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.findDialog.CancelReplace();
			this.cancelButton.Enabled = false;
		}

		private void searchHistoryComboBox_TextChanged(object sender, EventArgs e)
		{
			this.findDialog.SearchMode = FindDialog.SearchModes.Ready;
			if (this.searchHistoryComboBox.Text.Length > 0)
			{
				this.searchButton.Enabled = true;
				this.replaceButton.Enabled = true;
				this.replaceAllButton.Enabled = true;
			}
			else
			{
				this.searchButton.Enabled = false;
				this.replaceButton.Enabled = false;
				this.replaceAllButton.Enabled = false;
			}
		}

		private void searchTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.findDialog.SearchMode = FindDialog.SearchModes.Ready;
		}

		private void ignoreCaseCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			this.findDialog.SearchMode = FindDialog.SearchModes.Ready;
		}

		private void FindDialog_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F && e.Modifiers == Keys.Control)
			{
				if (this.replaceModeCheckBox.Checked)
				{
					this.replaceModeCheckBox.Checked = false;
				}
				else
				{
					this.searchHistoryComboBox.SelectAll();
					this.findDialog.SearchMode = FindDialog.SearchModes.Ready;
				}
				e.SuppressKeyPress = true;
			}
			if (e.KeyCode == Keys.H && e.Modifiers == Keys.Control)
			{
				if (this.replaceModeCheckBox.Visible && !this.replaceModeCheckBox.Checked)
				{
					this.replaceModeCheckBox.Checked = true;
				}
				else
				{
					this.searchHistoryComboBox.SelectAll();
					this.findDialog.SearchMode = FindDialog.SearchModes.Ready;
				}
				e.SuppressKeyPress = true;
			}
			if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
			{
				this.searchHistoryComboBox.SelectAll();
				e.SuppressKeyPress = true;
			}
			else if (e.KeyCode == Keys.F3 && e.Modifiers == Keys.None)
			{
				this.SearchPressed();
				e.SuppressKeyPress = true;
			}
			else if (e.KeyCode == Keys.Escape)
			{
				base.Close();
				e.SuppressKeyPress = true;
			}
		}

		protected void SearchPressed()
		{
			if (this.searchButton.Enabled)
			{
				RegexOptions regexOptions = RegexOptions.None;
				if (this.ignoreCaseCheckBox.Checked)
				{
					regexOptions |= RegexOptions.IgnoreCase;
				}
				string pattern;
				switch (this.searchTypeComboBox.SelectedIndex)
				{
				case 1:
					pattern = this.searchHistoryComboBox.Text;
					goto IL_A9;
				case 2:
					pattern = Regex.Escape(this.searchHistoryComboBox.Text).Replace("\\*", ".*").Replace("\\?", ".");
					goto IL_A9;
				}
				pattern = Regex.Escape(this.searchHistoryComboBox.Text);
				IL_A9:
				Regex regex = null;
				try
				{
					regex = new Regex(pattern, regexOptions);
				}
				catch (Exception ex)
				{
					MessageBox.Show(this, ex.Message, "Regular expression error");
				}
				if (regex != null)
				{
					this.findDialog.SearchRegularExpression = regex;
					this.findDialog.Search();
					this.searchHistoryComboBox.SelectAll();
				}
			}
		}

		public void Reshow()
		{
			base.Show();
			base.BringToFront();
			this.searchHistoryComboBox.SelectAll();
			this.searchHistoryComboBox.Focus();
			this.findDialog.SearchMode = FindDialog.SearchModes.Ready;
		}

		public bool FindNextIsAvailable()
		{
			return this.searchButton.Enabled;
		}

		internal void ApplySearchMode()
		{
			switch (this.findDialog.SearchMode)
			{
			case FindDialog.SearchModes.Ready:
				this.searchButton.Text = "&Search";
				if (this.searchHistoryComboBox.Text.Length > 0)
				{
					this.searchButton.Enabled = true;
				}
				else
				{
					this.searchButton.Enabled = false;
				}
				break;
			case FindDialog.SearchModes.SearchAgain:
				this.searchButton.Text = "Search &Again";
				break;
			case FindDialog.SearchModes.SearchFailed:
				this.searchButton.Text = "Not found";
				this.searchButton.Enabled = false;
				new InfoForm("Search text was not found", base.Owner).ShowDialog();
				this.findDialog.SearchMode = FindDialog.SearchModes.Ready;
				break;
			case FindDialog.SearchModes.SearchFinished:
				this.searchButton.Text = "Not found";
				this.searchButton.Enabled = false;
				if (this.numberFindAllReplaces == 0)
				{
					new InfoForm("Finished searching document", base.Owner).ShowDialog();
				}
				this.findDialog.SearchMode = FindDialog.SearchModes.Ready;
				break;
			}
		}

		private static void SerializeList(Stream stream, IFormatter formatter, IList list)
		{
			formatter.Serialize(stream, list.Count);
			foreach (object current in list)
			{
				formatter.Serialize(stream, current);
			}
		}

		private static void DeserializeList(Stream stream, IFormatter formatter, IList list)
		{
			int num = (int)formatter.Deserialize(stream);
			for (int num2 = 0; num2 != num; num2++)
			{
				list.Add(formatter.Deserialize(stream));
			}
			if (num != list.Count)
			{
				throw new Exception("List did not deserialize to correct size");
			}
		}

		internal void GetRestoreData(Stream stream, IFormatter formatter)
		{
			formatter.Serialize(stream, base.Bounds);
			formatter.Serialize(stream, this.ignoreCaseCheckBox.Checked);
			formatter.Serialize(stream, this.searchTypeComboBox.SelectedIndex);
			formatter.Serialize(stream, this.searchHistoryComboBox.Text);
			SearchableControls.FindForm.SerializeList(stream, formatter, this.searchHistoryComboBox.Items);
			formatter.Serialize(stream, this.replaceHistoryComboBox.Text);
			SearchableControls.FindForm.SerializeList(stream, formatter, this.replaceHistoryComboBox.Items);
			formatter.Serialize(stream, this.replaceModeCheckBox.Checked);
		}

		private void ApplyRestoreData(Stream stream, IFormatter formatter)
		{
			base.Bounds = (Rectangle)formatter.Deserialize(stream);
			this.ignoreCaseCheckBox.Checked = (bool)formatter.Deserialize(stream);
			this.searchTypeComboBox.SelectedIndex = (int)formatter.Deserialize(stream);
			this.searchHistoryComboBox.Text = (string)formatter.Deserialize(stream);
			SearchableControls.FindForm.DeserializeList(stream, formatter, this.searchHistoryComboBox.Items);
			this.replaceHistoryComboBox.Text = (string)formatter.Deserialize(stream);
			SearchableControls.FindForm.DeserializeList(stream, formatter, this.replaceHistoryComboBox.Items);
			this.replaceModeCheckBox.Checked = (bool)formatter.Deserialize(stream);
		}

		private void replaceModeCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			this.SetAppearanceFromReplaceMode();
		}

		private void SetAppearanceFromReplaceMode()
		{
			if (this.replaceModeCheckBox.Checked)
			{
				this.searchButton.Location = new Point(this.searchButton.Location.X, 24);
				this.searchHistoryComboBox.Size = new Size(base.ClientSize.Width - 96, this.searchButton.Width);
				this.label2.Visible = true;
				this.replaceHistoryComboBox.Visible = true;
				this.replaceButton.Visible = true;
				this.replaceAllButton.Visible = true;
				this.cancelButton.Visible = true;
				this.MaximumSize = new Size(this.MaximumSize.Width, 2147483647);
				base.ClientSize = new Size(base.ClientSize.Width, 130);
				this.MinimumSize = new Size(this.MinimumSize.Width, base.Size.Height);
				this.MaximumSize = new Size(this.MaximumSize.Width, base.Size.Height);
				this.Text = "Find and Replace Text";
			}
			else
			{
				this.searchButton.Location = new Point(this.searchButton.Location.X, 54);
				this.searchHistoryComboBox.Size = new Size(base.ClientSize.Width - 12, this.searchHistoryComboBox.Width);
				this.label2.Visible = false;
				this.replaceHistoryComboBox.Visible = false;
				this.replaceButton.Visible = false;
				this.replaceAllButton.Visible = false;
				this.cancelButton.Visible = false;
				this.MinimumSize = new Size(this.MinimumSize.Width, 0);
				base.ClientSize = new Size(base.ClientSize.Width, 84);
				this.MinimumSize = new Size(this.MinimumSize.Width, base.Size.Height);
				this.MaximumSize = new Size(this.MaximumSize.Width, base.Size.Height);
				this.Text = "Find Text";
			}
		}
	}
}
