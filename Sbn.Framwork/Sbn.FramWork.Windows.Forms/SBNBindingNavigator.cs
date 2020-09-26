using Sbn.FramWork.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms
{
	public class SBNBindingNavigator : SBNToolStrip
	{
		private IContainer components = null;

		private ToolStripButton tsbtnMoveFirst;

		private ToolStripButton tsbtnMovePrevious;

		private ToolStripTextBox tstxtPosition;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripLabel tslblCountItem;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripButton tsbtnMoveNextItem;

		private ToolStripButton tsbtnMoveLastItem;

		private ToolStripSeparator toolStripSeparator3;

		private BindingSource _bindingSource;

		[DefaultValue(null), TypeConverter(typeof(ReferenceConverter))]
		public BindingSource BindingSource
		{
			get
			{
				return this._bindingSource;
			}
			set
			{
				this._bindingSource = value;
				if (this._bindingSource != null)
				{
					this.tsbtnMoveFirst.Enabled = true;
					this.tsbtnMoveLastItem.Enabled = true;
					this.tsbtnMoveNextItem.Enabled = true;
					this.tsbtnMovePrevious.Enabled = true;
					this.tslblCountItem.Text = "از{" + value.Count + "}";
					this._bindingSource.CurrentChanged += new EventHandler(this.BindingSourceCurrentChanged);
				}
				else
				{
					this.tsbtnMoveFirst.Enabled = false;
					this.tsbtnMoveLastItem.Enabled = false;
					this.tsbtnMoveNextItem.Enabled = false;
					this.tsbtnMovePrevious.Enabled = false;
				}
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
			this.tsbtnMoveFirst = new ToolStripButton();
			this.tsbtnMovePrevious = new ToolStripButton();
			this.tstxtPosition = new ToolStripTextBox();
			this.toolStripSeparator1 = new ToolStripSeparator();
			this.tslblCountItem = new ToolStripLabel();
			this.toolStripSeparator2 = new ToolStripSeparator();
			this.tsbtnMoveNextItem = new ToolStripButton();
			this.tsbtnMoveLastItem = new ToolStripButton();
			this.toolStripSeparator3 = new ToolStripSeparator();
			base.SuspendLayout();
			this.tsbtnMoveFirst.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.tsbtnMoveFirst.Enabled = false;
			this.tsbtnMoveFirst.Image = Resources.hide_right16;
			this.tsbtnMoveFirst.ImageTransparentColor = Color.Magenta;
			this.tsbtnMoveFirst.Name = "tsbtnMoveFirst";
			this.tsbtnMoveFirst.Size = new Size(23, 22);
			this.tsbtnMoveFirst.Text = "اولین";
			this.tsbtnMovePrevious.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.tsbtnMovePrevious.Enabled = false;
			this.tsbtnMovePrevious.Image = Resources.navigate_right16;
			this.tsbtnMovePrevious.ImageTransparentColor = Color.Magenta;
			this.tsbtnMovePrevious.Name = "tsbtnMovePrevious";
			this.tsbtnMovePrevious.Size = new Size(23, 22);
			this.tsbtnMovePrevious.Text = "قبلی";
			this.tstxtPosition.Name = "tstxtPosition";
			this.tstxtPosition.Size = new Size(50, 23);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new Size(6, 25);
			this.tslblCountItem.Name = "tslblCountItem";
			this.tslblCountItem.Size = new Size(36, 15);
			this.tslblCountItem.Text = "از {0 }";
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new Size(6, 6);
			this.tsbtnMoveNextItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.tsbtnMoveNextItem.Enabled = false;
			this.tsbtnMoveNextItem.Image = Resources.navigate_left16;
			this.tsbtnMoveNextItem.ImageTransparentColor = Color.Magenta;
			this.tsbtnMoveNextItem.Name = "tsbtnMoveNextItem";
			this.tsbtnMoveNextItem.Size = new Size(23, 20);
			this.tsbtnMoveNextItem.Text = "بعدی";
			this.tsbtnMoveLastItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.tsbtnMoveLastItem.Enabled = false;
			this.tsbtnMoveLastItem.Image = Resources.hide_left16;
			this.tsbtnMoveLastItem.ImageTransparentColor = Color.Magenta;
			this.tsbtnMoveLastItem.Name = "tsbtnMoveLastItem";
			this.tsbtnMoveLastItem.Size = new Size(23, 20);
			this.tsbtnMoveLastItem.Text = "آخرین";
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new Size(6, 6);
			this.Items.AddRange(new ToolStripItem[]
			{
				this.tsbtnMoveFirst,
				this.tsbtnMovePrevious,
				this.toolStripSeparator1,
				this.tstxtPosition,
				this.tslblCountItem,
				this.toolStripSeparator2,
				this.tsbtnMoveNextItem,
				this.tsbtnMoveLastItem,
				this.toolStripSeparator3
			});
			this.RightToLeft = RightToLeft.Yes;
			base.ResumeLayout(false);
		}

		public SBNBindingNavigator()
		{
			this.InitializeComponent();
			this.tsbtnMoveFirst.Click += new EventHandler(this.tsbtnMoveFirst_Click);
			this.tsbtnMoveLastItem.Click += new EventHandler(this.tsbtnMoveLastItem_Click);
			this.tsbtnMoveNextItem.Click += new EventHandler(this.tsbtnMoveNextItem_Click);
			this.tsbtnMovePrevious.Click += new EventHandler(this.tsbtnMovePrevious_Click);
		}

		private void tsbtnMovePrevious_Click(object sender, EventArgs e)
		{
			if (this.BindingSource != null)
			{
				this.BindingSource.MovePrevious();
			}
		}

		private void tsbtnMoveNextItem_Click(object sender, EventArgs e)
		{
			if (this.BindingSource != null)
			{
				this.BindingSource.MoveNext();
			}
		}

		private void tsbtnMoveLastItem_Click(object sender, EventArgs e)
		{
			if (this.BindingSource != null)
			{
				this.BindingSource.MoveLast();
			}
		}

		private void BindingSourceCurrentChanged(object sender, EventArgs e)
		{
			object current = this.BindingSource.Current;
			if (current != null)
			{
				this.tstxtPosition.Text = this.BindingSource.IndexOf(current).ToString(CultureInfo.InvariantCulture);
				this.tslblCountItem.Text = "از{" + this.BindingSource.Count + "}";
			}
			else
			{
				this.tstxtPosition.Text = "0";
			}
		}

		private void tsbtnMoveFirst_Click(object sender, EventArgs e)
		{
			if (this.BindingSource != null)
			{
				this.BindingSource.MoveFirst();
			}
		}
	}
}
