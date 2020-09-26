using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Hatefnet.Products.Controls.Magnifier
{
	public class ConfigurationForm : Form
	{
		private Configuration mConfiguration;

		private IContainer components = null;

		private Label lbl_ZoomFactor;

		private CheckBox cb_Symmetry;

		private PictureBox pb_About;

		private Button btn_Close;

		private TrackBar tb_ZoomFactor;

		private GroupBox groupBox1;

		private CheckBox cb_CloseOnMouseUp;

		private CheckBox cb_DoubleBuffered;

		private CheckBox cb_RememberLastPoint;

		private CheckBox cb_ReturnToOrigin;

		private CheckBox cb_ShowInTaskbar;

		private CheckBox cb_HideMouseCursor;

		private CheckBox cb_TopMostWindow;

		private Label lbl_ZF;

		private Label lbl_SF;

		private Label lbl_MW;

		private Label lbl_MH;

		private TrackBar tb_SpeedFactor;

		private TrackBar tb_Width;

		private TrackBar tb_Height;

		private Label lbl_SpeedFactor;

		private Label lbl_Width;

		private Label lbl_Height;

		public ConfigurationForm(Configuration configuration)
		{
			this.InitializeComponent();
			this.InitConfigutationSettings(configuration);
		}

		private void InitConfigutationSettings(Configuration configuration)
		{
			this.mConfiguration = configuration;
			this.tb_ZoomFactor.Maximum = (int)Configuration.ZOOM_FACTOR_MAX;
			this.tb_ZoomFactor.Minimum = (int)Configuration.ZOOM_FACTOR_MIN;
			this.tb_ZoomFactor.Value = (int)this.mConfiguration.ZoomFactor;
			this.tb_SpeedFactor.Maximum = (int)(100f * Configuration.SPEED_FACTOR_MAX);
			this.tb_SpeedFactor.Minimum = (int)(100f * Configuration.SPEED_FACTOR_MIN);
			this.tb_SpeedFactor.Value = (int)(100f * this.mConfiguration.SpeedFactor);
			this.tb_Width.Maximum = 1000;
			this.tb_Width.Minimum = 100;
			this.tb_Width.Value = this.mConfiguration.MagnifierWidth;
			this.tb_Height.Maximum = 1000;
			this.tb_Height.Minimum = 100;
			this.tb_Height.Value = this.mConfiguration.MagnifierHeight;
			this.lbl_ZoomFactor.Text = this.mConfiguration.ZoomFactor.ToString();
			this.lbl_SpeedFactor.Text = this.mConfiguration.SpeedFactor.ToString();
			this.lbl_Width.Text = this.mConfiguration.MagnifierWidth.ToString();
			this.lbl_Height.Text = this.mConfiguration.MagnifierHeight.ToString();
			this.cb_CloseOnMouseUp.Checked = this.mConfiguration.CloseOnMouseUp;
			this.cb_DoubleBuffered.Checked = this.mConfiguration.DoubleBuffered;
			this.cb_HideMouseCursor.Checked = this.mConfiguration.HideMouseCursor;
			this.cb_RememberLastPoint.Checked = this.mConfiguration.RememberLastPoint;
			this.cb_ReturnToOrigin.Checked = this.mConfiguration.ReturnToOrigin;
			this.cb_ShowInTaskbar.Checked = this.mConfiguration.ShowInTaskbar;
			this.cb_TopMostWindow.Checked = this.mConfiguration.TopMostWindow;
			base.ShowInTaskbar = false;
		}

		private void tb_ZoomFactor_Scroll(object sender, EventArgs e)
		{
			TrackBar trackBar = (TrackBar)sender;
			this.mConfiguration.ZoomFactor = (float)trackBar.Value;
			this.lbl_ZoomFactor.Text = this.mConfiguration.ZoomFactor.ToString();
		}

		private void tb_SpeedFactor_Scroll(object sender, EventArgs e)
		{
			TrackBar trackBar = (TrackBar)sender;
			this.mConfiguration.SpeedFactor = (float)trackBar.Value / 100f;
			this.lbl_SpeedFactor.Text = this.mConfiguration.SpeedFactor.ToString();
		}

		private void tb_Width_Scroll(object sender, EventArgs e)
		{
			TrackBar trackBar = (TrackBar)sender;
			this.mConfiguration.MagnifierWidth = trackBar.Value;
			this.lbl_Width.Text = this.mConfiguration.MagnifierWidth.ToString();
			if (this.cb_Symmetry.Checked)
			{
				this.tb_Height.Value = trackBar.Value;
				this.mConfiguration.MagnifierHeight = trackBar.Value;
				this.lbl_Height.Text = this.mConfiguration.MagnifierHeight.ToString();
			}
		}

		private void tb_Height_Scroll(object sender, EventArgs e)
		{
			TrackBar trackBar = (TrackBar)sender;
			this.mConfiguration.MagnifierHeight = trackBar.Value;
			this.lbl_Height.Text = this.mConfiguration.MagnifierHeight.ToString();
		}

		private void cb_Symmetry_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = (CheckBox)sender;
			if (checkBox.Checked)
			{
				this.tb_Height.Enabled = false;
			}
			else
			{
				this.tb_Height.Enabled = true;
			}
		}

		private void pb_About_MouseEnter(object sender, EventArgs e)
		{
			this.Cursor = Cursors.Hand;
		}

		private void pb_About_MouseLeave(object sender, EventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		private void pb_About_Click(object sender, EventArgs e)
		{
		}

		private void btn_Close_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void cb_CloseOnMouseUp_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = (CheckBox)sender;
			this.mConfiguration.CloseOnMouseUp = checkBox.Checked;
		}

		private void cb_DoubleBuffered_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = (CheckBox)sender;
			this.mConfiguration.DoubleBuffered = checkBox.Checked;
		}

		private void cb_HideMouseCursor_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = (CheckBox)sender;
			this.mConfiguration.HideMouseCursor = checkBox.Checked;
		}

		private void cb_RememberLastPoint_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = (CheckBox)sender;
			this.mConfiguration.RememberLastPoint = checkBox.Checked;
		}

		private void cb_ReturnToOrigin_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = (CheckBox)sender;
			this.mConfiguration.ReturnToOrigin = checkBox.Checked;
		}

		private void cb_ShowInTaskbar_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = (CheckBox)sender;
			this.mConfiguration.ShowInTaskbar = checkBox.Checked;
		}

		private void cb_TopMostWindow_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = (CheckBox)sender;
			this.mConfiguration.TopMostWindow = checkBox.Checked;
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ConfigurationForm));
			this.lbl_ZoomFactor = new Label();
			this.cb_Symmetry = new CheckBox();
			this.btn_Close = new Button();
			this.tb_ZoomFactor = new TrackBar();
			this.groupBox1 = new GroupBox();
			this.cb_CloseOnMouseUp = new CheckBox();
			this.cb_DoubleBuffered = new CheckBox();
			this.cb_RememberLastPoint = new CheckBox();
			this.cb_ReturnToOrigin = new CheckBox();
			this.cb_ShowInTaskbar = new CheckBox();
			this.cb_HideMouseCursor = new CheckBox();
			this.cb_TopMostWindow = new CheckBox();
			this.lbl_ZF = new Label();
			this.lbl_SF = new Label();
			this.lbl_MW = new Label();
			this.lbl_MH = new Label();
			this.tb_SpeedFactor = new TrackBar();
			this.tb_Width = new TrackBar();
			this.tb_Height = new TrackBar();
			this.lbl_SpeedFactor = new Label();
			this.lbl_Width = new Label();
			this.lbl_Height = new Label();
			this.pb_About = new PictureBox();
			((ISupportInitialize)this.tb_ZoomFactor).BeginInit();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.tb_SpeedFactor).BeginInit();
			((ISupportInitialize)this.tb_Width).BeginInit();
			((ISupportInitialize)this.tb_Height).BeginInit();
			((ISupportInitialize)this.pb_About).BeginInit();
			base.SuspendLayout();
			this.lbl_ZoomFactor.Location = new Point(323, 20);
			this.lbl_ZoomFactor.Name = "lbl_ZoomFactor";
			this.lbl_ZoomFactor.Size = new Size(60, 16);
			this.lbl_ZoomFactor.TabIndex = 21;
			this.lbl_ZoomFactor.Text = "?";
			this.cb_Symmetry.Checked = true;
			this.cb_Symmetry.CheckState = CheckState.Checked;
			this.cb_Symmetry.Location = new Point(99, 208);
			this.cb_Symmetry.Name = "cb_Symmetry";
			this.cb_Symmetry.Size = new Size(104, 20);
			this.cb_Symmetry.TabIndex = 18;
			this.cb_Symmetry.Text = "Keep symmetry";
			this.cb_Symmetry.CheckedChanged += new EventHandler(this.cb_Symmetry_CheckedChanged);
			this.btn_Close.Location = new Point(467, 236);
			this.btn_Close.Name = "btn_Close";
			this.btn_Close.Size = new Size(104, 28);
			this.btn_Close.TabIndex = 16;
			this.btn_Close.Text = "Close";
			this.btn_Close.Click += new EventHandler(this.btn_Close_Click);
			this.tb_ZoomFactor.Location = new Point(99, 12);
			this.tb_ZoomFactor.Name = "tb_ZoomFactor";
			this.tb_ZoomFactor.Size = new Size(220, 42);
			this.tb_ZoomFactor.TabIndex = 15;
			this.tb_ZoomFactor.Scroll += new EventHandler(this.tb_ZoomFactor_Scroll);
			this.groupBox1.Controls.Add(this.cb_CloseOnMouseUp);
			this.groupBox1.Controls.Add(this.cb_DoubleBuffered);
			this.groupBox1.Controls.Add(this.cb_RememberLastPoint);
			this.groupBox1.Controls.Add(this.cb_ReturnToOrigin);
			this.groupBox1.Controls.Add(this.cb_ShowInTaskbar);
			this.groupBox1.Controls.Add(this.cb_HideMouseCursor);
			this.groupBox1.Controls.Add(this.cb_TopMostWindow);
			this.groupBox1.Location = new Point(391, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(180, 188);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = " Boolean Settings ";
			this.cb_CloseOnMouseUp.Location = new Point(12, 24);
			this.cb_CloseOnMouseUp.Name = "cb_CloseOnMouseUp";
			this.cb_CloseOnMouseUp.Size = new Size(148, 16);
			this.cb_CloseOnMouseUp.TabIndex = 1;
			this.cb_CloseOnMouseUp.Text = "Close On Mouse Up";
			this.cb_CloseOnMouseUp.CheckedChanged += new EventHandler(this.cb_CloseOnMouseUp_CheckedChanged);
			this.cb_DoubleBuffered.Location = new Point(12, 44);
			this.cb_DoubleBuffered.Name = "cb_DoubleBuffered";
			this.cb_DoubleBuffered.Size = new Size(148, 16);
			this.cb_DoubleBuffered.TabIndex = 1;
			this.cb_DoubleBuffered.Text = "Double Buffered";
			this.cb_DoubleBuffered.CheckedChanged += new EventHandler(this.cb_DoubleBuffered_CheckedChanged);
			this.cb_RememberLastPoint.Location = new Point(12, 84);
			this.cb_RememberLastPoint.Name = "cb_RememberLastPoint";
			this.cb_RememberLastPoint.Size = new Size(148, 16);
			this.cb_RememberLastPoint.TabIndex = 1;
			this.cb_RememberLastPoint.Text = "Remember Last Point";
			this.cb_RememberLastPoint.CheckedChanged += new EventHandler(this.cb_RememberLastPoint_CheckedChanged);
			this.cb_ReturnToOrigin.Location = new Point(12, 104);
			this.cb_ReturnToOrigin.Name = "cb_ReturnToOrigin";
			this.cb_ReturnToOrigin.Size = new Size(148, 16);
			this.cb_ReturnToOrigin.TabIndex = 1;
			this.cb_ReturnToOrigin.Text = "Return To Origin";
			this.cb_ReturnToOrigin.CheckedChanged += new EventHandler(this.cb_ReturnToOrigin_CheckedChanged);
			this.cb_ShowInTaskbar.Location = new Point(12, 124);
			this.cb_ShowInTaskbar.Name = "cb_ShowInTaskbar";
			this.cb_ShowInTaskbar.Size = new Size(148, 16);
			this.cb_ShowInTaskbar.TabIndex = 1;
			this.cb_ShowInTaskbar.Text = "Show In Taskbar";
			this.cb_ShowInTaskbar.CheckedChanged += new EventHandler(this.cb_ShowInTaskbar_CheckedChanged);
			this.cb_HideMouseCursor.Location = new Point(12, 64);
			this.cb_HideMouseCursor.Name = "cb_HideMouseCursor";
			this.cb_HideMouseCursor.Size = new Size(148, 16);
			this.cb_HideMouseCursor.TabIndex = 1;
			this.cb_HideMouseCursor.Text = "Hide Mouse Cursor";
			this.cb_HideMouseCursor.CheckedChanged += new EventHandler(this.cb_HideMouseCursor_CheckedChanged);
			this.cb_TopMostWindow.Location = new Point(12, 144);
			this.cb_TopMostWindow.Name = "cb_TopMostWindow";
			this.cb_TopMostWindow.Size = new Size(148, 16);
			this.cb_TopMostWindow.TabIndex = 1;
			this.cb_TopMostWindow.Text = "Top Most Window";
			this.cb_TopMostWindow.CheckedChanged += new EventHandler(this.cb_TopMostWindow_CheckedChanged);
			this.lbl_ZF.Location = new Point(7, 20);
			this.lbl_ZF.Name = "lbl_ZF";
			this.lbl_ZF.Size = new Size(88, 16);
			this.lbl_ZF.TabIndex = 8;
			this.lbl_ZF.Text = "Zoom Factor";
			this.lbl_SF.Location = new Point(7, 64);
			this.lbl_SF.Name = "lbl_SF";
			this.lbl_SF.Size = new Size(88, 16);
			this.lbl_SF.TabIndex = 9;
			this.lbl_SF.Text = "Speed Factor";
			this.lbl_MW.Location = new Point(7, 112);
			this.lbl_MW.Name = "lbl_MW";
			this.lbl_MW.Size = new Size(88, 16);
			this.lbl_MW.TabIndex = 7;
			this.lbl_MW.Text = "Magnifier Width";
			this.lbl_MH.Location = new Point(7, 160);
			this.lbl_MH.Name = "lbl_MH";
			this.lbl_MH.Size = new Size(88, 16);
			this.lbl_MH.TabIndex = 10;
			this.lbl_MH.Text = "Magnifier Height";
			this.tb_SpeedFactor.Location = new Point(99, 60);
			this.tb_SpeedFactor.Name = "tb_SpeedFactor";
			this.tb_SpeedFactor.Size = new Size(220, 42);
			this.tb_SpeedFactor.TabIndex = 14;
			this.tb_SpeedFactor.Scroll += new EventHandler(this.tb_SpeedFactor_Scroll);
			this.tb_Width.Location = new Point(99, 108);
			this.tb_Width.Name = "tb_Width";
			this.tb_Width.Size = new Size(220, 42);
			this.tb_Width.TabIndex = 13;
			this.tb_Width.Scroll += new EventHandler(this.tb_Width_Scroll);
			this.tb_Height.Enabled = false;
			this.tb_Height.Location = new Point(99, 156);
			this.tb_Height.Name = "tb_Height";
			this.tb_Height.Size = new Size(220, 42);
			this.tb_Height.TabIndex = 12;
			this.tb_Height.Scroll += new EventHandler(this.tb_Height_Scroll);
			this.lbl_SpeedFactor.Location = new Point(323, 64);
			this.lbl_SpeedFactor.Name = "lbl_SpeedFactor";
			this.lbl_SpeedFactor.Size = new Size(60, 16);
			this.lbl_SpeedFactor.TabIndex = 22;
			this.lbl_SpeedFactor.Text = "?";
			this.lbl_Width.Location = new Point(323, 112);
			this.lbl_Width.Name = "lbl_Width";
			this.lbl_Width.Size = new Size(60, 16);
			this.lbl_Width.TabIndex = 19;
			this.lbl_Width.Text = "?";
			this.lbl_Height.Location = new Point(323, 164);
			this.lbl_Height.Name = "lbl_Height";
			this.lbl_Height.Size = new Size(60, 16);
			this.lbl_Height.TabIndex = 20;
			this.lbl_Height.Text = "?";
			this.pb_About.Cursor = Cursors.Hand;
			this.pb_About.Image = (Image)componentResourceManager.GetObject("pb_About.Image");
			this.pb_About.Location = new Point(267, 232);
			this.pb_About.Name = "pb_About";
			this.pb_About.Size = new Size(35, 32);
			this.pb_About.TabIndex = 17;
			this.pb_About.TabStop = false;
			this.pb_About.MouseLeave += new EventHandler(this.pb_About_MouseLeave);
			this.pb_About.Click += new EventHandler(this.pb_About_Click);
			this.pb_About.MouseEnter += new EventHandler(this.pb_About_MouseEnter);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(586, 275);
			base.Controls.Add(this.lbl_ZoomFactor);
			base.Controls.Add(this.cb_Symmetry);
			base.Controls.Add(this.pb_About);
			base.Controls.Add(this.btn_Close);
			base.Controls.Add(this.tb_ZoomFactor);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.lbl_ZF);
			base.Controls.Add(this.lbl_SF);
			base.Controls.Add(this.lbl_MW);
			base.Controls.Add(this.lbl_MH);
			base.Controls.Add(this.tb_SpeedFactor);
			base.Controls.Add(this.tb_Width);
			base.Controls.Add(this.tb_Height);
			base.Controls.Add(this.lbl_SpeedFactor);
			base.Controls.Add(this.lbl_Width);
			base.Controls.Add(this.lbl_Height);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Name = "ConfigurationForm";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Configuration";
			((ISupportInitialize)this.tb_ZoomFactor).EndInit();
			this.groupBox1.ResumeLayout(false);
			((ISupportInitialize)this.tb_SpeedFactor).EndInit();
			((ISupportInitialize)this.tb_Width).EndInit();
			((ISupportInitialize)this.tb_Height).EndInit();
			((ISupportInitialize)this.pb_About).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
