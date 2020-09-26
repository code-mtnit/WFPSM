using Hatefnet.Products.Controls.Magnifier.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Hatefnet.Products.Controls.Magnifier
{
	public class MagifierToolsTripButton : ToolStripButton
	{
		private Configuration mConfiguration = new Configuration();

		private Point mPointMouseDown;

		private Point mLastCursorPosition;

		private string mConfigFileName = "configData.xml";

		private IContainer components = null;

		public MagifierToolsTripButton()
		{
			this.InitializeComponent();
		}

		private void GetConfiguration()
		{
			try
			{
				this.mConfiguration = (Configuration)XmlUtility.Deserialize(this.mConfiguration.GetType(), this.mConfigFileName);
			}
			catch
			{
				this.mConfiguration = new Configuration();
			}
		}

		private void SaveConfiguration()
		{
			try
			{
				XmlUtility.Serialize(this.mConfiguration, this.mConfigFileName);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Serialization problem: " + ex.Message);
			}
		}

		public MagifierToolsTripButton(IContainer container)
		{
			container.Add(this);
			this.InitializeComponent();
		}

		public MagifierToolsTripButton(ToolStrip toolstrip)
		{
			toolstrip.Items.Add(this);
			this.InitializeComponent();
		}

		private void MagifierToolsTripButton_MouseDown(object sender, MouseEventArgs e)
		{
			this.mLastCursorPosition = Cursor.Position;
			this.mConfiguration.MagnifierHeight = 280;
			this.mConfiguration.MagnifierWidth = 280;
			this.mConfiguration.ZoomFactor = 2f;
			int x = this.mLastCursorPosition.X;
			int y = this.mLastCursorPosition.Y;
			MagnifierForm magnifierForm = new MagnifierForm(this.mConfiguration, this.mLastCursorPosition);
			magnifierForm.Show();
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
			this.Image = Resources.kghostview_24;
			base.MouseDown += new MouseEventHandler(this.MagifierToolsTripButton_MouseDown);
		}
	}
}
