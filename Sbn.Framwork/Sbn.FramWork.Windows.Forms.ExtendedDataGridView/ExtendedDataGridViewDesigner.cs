using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Sbn.FramWork.Windows.Forms.ExtendedDataGridView
{
	internal class ExtendedDataGridViewDesigner : ControlDesigner
	{
		private class DataGridViewColumnEditingActionList : DesignerActionList
		{
			private ExtendedDataGridViewDesigner m_owner;

			public DataGridViewColumnEditingActionList(ExtendedDataGridViewDesigner owner) : base(owner.Component)
			{
				this.m_owner = owner;
			}

			public void AddColumn()
			{
				this.m_owner.OnAddColumn(this, EventArgs.Empty);
			}

			public void EditColumns()
			{
				this.m_owner.OnEditColumns(this, EventArgs.Empty);
			}

			public override DesignerActionItemCollection GetSortedActionItems()
			{
				return new DesignerActionItemCollection
				{
					new DesignerActionMethodItem(this, "EditColumns", "Edit Columns...", true),
					new DesignerActionMethodItem(this, "AddColumn", "Add Column...", true)
				};
			}
		}

		private class DataGridViewPropertiesActionList : DesignerActionList
		{
			private ExtendedDataGridViewDesigner m_owner;

			public bool AllowUserToAddRows
			{
				get
				{
					return ((DataGridView)this.m_owner.Component).AllowUserToAddRows;
				}
				set
				{
					if (value != this.AllowUserToAddRows)
					{
						this.SetProperty("AllowUserToAddRows", "DataGridView{0}AddingTransactionString", value);
					}
				}
			}

			public bool AllowUserToDeleteRows
			{
				get
				{
					return ((DataGridView)this.m_owner.Component).AllowUserToDeleteRows;
				}
				set
				{
					if (value != this.AllowUserToDeleteRows)
					{
						this.SetProperty("AllowUserToDeleteRows", "DataGridView{0}DeletingTransactionString", value);
					}
				}
			}

			public bool AllowUserToOrderColumns
			{
				get
				{
					return ((DataGridView)this.m_owner.Component).AllowUserToOrderColumns;
				}
				set
				{
					if (value != this.AllowUserToOrderColumns)
					{
						this.SetProperty("AllowUserToOrderColumns", "DataGridView{0}ColumnReorderingTransactionString", value);
					}
				}
			}

			public bool ReadOnly
			{
				get
				{
					return !((DataGridView)this.m_owner.Component).ReadOnly;
				}
				set
				{
					if (value != this.ReadOnly)
					{
						this.SetProperty("ReadOnly", "DataGridView{0}EditingTransactionString", !value);
					}
				}
			}

			public DataGridViewPropertiesActionList(ExtendedDataGridViewDesigner owner) : base(owner.Component)
			{
				this.m_owner = owner;
			}

			public override DesignerActionItemCollection GetSortedActionItems()
			{
				return new DesignerActionItemCollection
				{
					new DesignerActionPropertyItem("AllowUserToAddRows", "Enable Adding"),
					new DesignerActionPropertyItem("ReadOnly", "Enable Editing"),
					new DesignerActionPropertyItem("AllowUserToDeleteRows", "Enable Deleting"),
					new DesignerActionPropertyItem("AllowUserToOrderColumns", "Enable Column Reordering")
				};
			}

			public void SetProperty(string propertyName, string transactionName, bool value)
			{
				IDesignerHost designerHost = this.m_owner.Component.Site.GetService(typeof(IDesignerHost)) as IDesignerHost;
				DesignerTransaction designerTransaction = designerHost.CreateTransaction(string.Format(transactionName, value ? "Enable" : "Disable"));
				try
				{
					IComponentChangeService componentChangeService = this.m_owner.Component.Site.GetService(typeof(IComponentChangeService)) as IComponentChangeService;
					PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(this.m_owner.Component)[propertyName];
					componentChangeService.OnComponentChanging(this.m_owner.Component, propertyDescriptor);
					propertyDescriptor.SetValue(this.m_owner.Component, value);
					componentChangeService.OnComponentChanged(this.m_owner.Component, propertyDescriptor, null, null);
					designerTransaction.Commit();
					designerTransaction = null;
				}
				finally
				{
					if (designerTransaction != null)
					{
						designerTransaction.Cancel();
					}
				}
			}
		}

		[ComplexBindingProperties("DataSource", "DataMember")]
		private class DataGridViewChooseDataSourceActionList : DesignerActionList
		{
			private ExtendedDataGridViewDesigner m_owner;

			[AttributeProvider(typeof(IListSource))]
			public object DataSource
			{
				get
				{
					return this.m_owner.DataSource;
				}
				set
				{
					DataGridView component = (DataGridView)this.m_owner.Component;
					IDesignerHost designerHost = this.m_owner.Component.Site.GetService(typeof(IDesignerHost)) as IDesignerHost;
					PropertyDescriptor member = TypeDescriptor.GetProperties(component)["DataSource"];
					IComponentChangeService componentChangeService = this.m_owner.Component.Site.GetService(typeof(IComponentChangeService)) as IComponentChangeService;
					DesignerTransaction designerTransaction = designerHost.CreateTransaction("DataGridViewChooseDataSourceTransactionString");
					try
					{
						componentChangeService.OnComponentChanging(component, member);
						this.m_owner.DataSource = value;
						componentChangeService.OnComponentChanged(component, member, null, null);
						designerTransaction.Commit();
						designerTransaction = null;
					}
					finally
					{
						if (designerTransaction != null)
						{
							designerTransaction.Cancel();
						}
					}
				}
			}

			public DataGridViewChooseDataSourceActionList(ExtendedDataGridViewDesigner owner) : base(owner.Component)
			{
				this.m_owner = owner;
			}

			public override DesignerActionItemCollection GetSortedActionItems()
			{
				return new DesignerActionItemCollection
				{
					new DesignerActionPropertyItem("DataSource", "Choose Data Source")
					{
						RelatedComponent = this.m_owner.Component
					}
				};
			}
		}

		private DesignerActionListCollection m_actionLists;

		public override DesignerActionListCollection ActionLists
		{
			get
			{
				if (this.m_actionLists == null)
				{
					this.BuildActionLists();
				}
				return this.m_actionLists;
			}
		}

		public object DataSource
		{
			get
			{
				return ((DataGridView)base.Component).DataSource;
			}
			set
			{
				DataGridView dataGridView = base.Component as DataGridView;
				if (dataGridView.AutoGenerateColumns && dataGridView.DataSource == null && value != null)
				{
					dataGridView.AutoGenerateColumns = false;
				}
				dataGridView.DataSource = value;
			}
		}

		private void BuildActionLists()
		{
			this.m_actionLists = new DesignerActionListCollection();
			this.m_actionLists.Add(new ExtendedDataGridViewDesigner.DataGridViewChooseDataSourceActionList(this));
			this.m_actionLists.Add(new ExtendedDataGridViewDesigner.DataGridViewColumnEditingActionList(this));
			this.m_actionLists.Add(new ExtendedDataGridViewDesigner.DataGridViewPropertiesActionList(this));
		}

		public static Form CreateColumnAdd(DataGridView grid)
		{
			Type type = Assembly.Load("System.Design").GetType("System.Windows.Forms.Design.DataGridViewAddColumnDialog");
			ConstructorInfo constructorInfo = type.GetConstructors()[0];
			Form form = (Form)constructorInfo.Invoke(new object[]
			{
				grid.Columns,
				grid
			});
			type.GetMethod("Start", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(form, new object[]
			{
				grid.Columns.Count,
				true
			});
			return form;
		}

		public void OnAddColumn(object sender, EventArgs e)
		{
			DesignerTransaction designerTransaction = (base.Component.Site.GetService(typeof(IDesignerHost)) as IDesignerHost).CreateTransaction("DataGridViewAddColumnTransactionString");
			DialogResult dialogResult = DialogResult.Cancel;
			Form dialog = ExtendedDataGridViewDesigner.CreateColumnAdd((DataGridView)base.Component);
			try
			{
				dialogResult = this.ShowDialog(dialog);
			}
			finally
			{
				if (dialogResult == DialogResult.OK)
				{
					designerTransaction.Commit();
				}
				else
				{
					designerTransaction.Cancel();
				}
			}
		}

		public void OnEditColumns(object sender, EventArgs e)
		{
			IDesignerHost designerHost = base.Component.Site.GetService(typeof(IDesignerHost)) as IDesignerHost;
			Form form = ExtendedDataGridViewColumnCollectionEditor.CreateColumnEditor();
			ExtendedDataGridViewColumnCollectionEditor.SetGrid(form, (DataGridView)base.Component);
			DesignerTransaction designerTransaction = designerHost.CreateTransaction("DataGridViewEditColumnsTransactionString");
			DialogResult dialogResult = DialogResult.Cancel;
			try
			{
				dialogResult = this.ShowDialog(form);
			}
			finally
			{
				if (dialogResult == DialogResult.OK)
				{
					designerTransaction.Commit();
				}
				else
				{
					designerTransaction.Cancel();
				}
				ExtendedDataGridViewColumnCollectionEditor.SaveData(form);
			}
		}

		private DialogResult ShowDialog(Form dialog)
		{
			IUIService iUIService = base.Component.Site.GetService(typeof(IUIService)) as IUIService;
			DialogResult result;
			if (iUIService != null)
			{
				result = iUIService.ShowDialog(dialog);
			}
			else
			{
				result = dialog.ShowDialog(base.Component as IWin32Window);
			}
			return result;
		}
	}
}
