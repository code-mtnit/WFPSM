using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Sbn.FramWork.Windows.Forms.ExtendedDataGridView
{
	internal class ExtendedDataGridViewColumnCollectionEditor : UITypeEditor
	{
		private Form m_dlgColumnEditor;

		private ExtendedDataGridViewColumnCollectionEditor()
		{
		}

		public static Form CreateColumnEditor()
		{
			Type type = Assembly.Load("System.Design").GetType("System.Windows.Forms.Design.DataGridViewColumnCollectionDialog");
			ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
			ConstructorInfo constructorInfo = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)[0];
			Form form = (Form)constructorInfo.Invoke(new object[1]);
			form.MaximizeBox = true;
			form.Size = new Size(10, 10);
			form.Load += new EventHandler(ExtendedDataGridViewColumnCollectionEditor.form_Load);
			return form;
		}

		private static void form_Load(object sender, EventArgs e)
		{
			ExtendedDataGridViewColumnCollectionEditor.LoadData((Form)sender);
		}

		public static void SetGrid(Form form, DataGridView grid)
		{
			form.GetType().GetMethod("SetLiveDataGridView", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(form, new object[]
			{
				grid
			});
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			object result;
			if (provider != null)
			{
				IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
				if (windowsFormsEditorService == null || context.Instance == null)
				{
					result = value;
					return result;
				}
				IDesignerHost designerHost = (IDesignerHost)provider.GetService(typeof(IDesignerHost));
				if (designerHost == null)
				{
					result = value;
					return result;
				}
				if (this.m_dlgColumnEditor == null)
				{
					this.m_dlgColumnEditor = ExtendedDataGridViewColumnCollectionEditor.CreateColumnEditor();
				}
				ExtendedDataGridViewColumnCollectionEditor.SetGrid(this.m_dlgColumnEditor, (DataGridView)context.Instance);
				using (DesignerTransaction designerTransaction = designerHost.CreateTransaction("DataGridViewColumnCollectionTransaction"))
				{
					if (windowsFormsEditorService.ShowDialog(this.m_dlgColumnEditor) != DialogResult.OK)
					{
						designerTransaction.Cancel();
					}
				}
			}
			ExtendedDataGridViewColumnCollectionEditor.SaveData(this.m_dlgColumnEditor);
			result = value;
			return result;
		}

		public static void SaveData(Form form)
		{
		}

		private static void LoadData(Form form)
		{
		}

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}
	}
}
