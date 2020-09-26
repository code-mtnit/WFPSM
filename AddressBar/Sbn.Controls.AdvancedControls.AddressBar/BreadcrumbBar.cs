using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace Sbn.Controls.AdvancedControls.AddressBar
{
	[ContentProperty("Root"), TemplatePart(Name = "PART_Root"), TemplatePart(Name = "PART_ComboBox")]
	public class BreadcrumbBar : Control, IAddChild
	{
		private const string partComboBox = "PART_ComboBox";

		private const string partRoot = "PART_Root";

		private const int breadcrumbsToHide = 1;

		public static readonly DependencyProperty HasDropDownItemsProperty;

		public static readonly DependencyProperty DropDownItemsPanelProperty;

		private static readonly DependencyPropertyKey IsRootSelectedPropertyKey;

		public static readonly DependencyProperty IsRootSelectedProperty;

		public static readonly DependencyProperty DropDownItemTemplateProperty;

		public static readonly DependencyProperty IsEditableProperty;

		public static readonly DependencyProperty DropDownItemTemplateSelectorProperty;

		public static readonly DependencyProperty OverflowItemTemplateSelectorProperty;

		public static readonly DependencyProperty OverflowItemTemplateProperty;

		private static readonly DependencyPropertyKey CollapsedTracesPropertyKey;

		public static readonly DependencyProperty CollapsedTracesProperty;

		public static readonly DependencyProperty RootProperty;

		public static readonly DependencyProperty SelectedItemProperty;

		private static readonly DependencyPropertyKey SelectedBreadcrumbPropertyKey;

		public static readonly DependencyProperty SelectedBreadcrumbProperty;

		public static readonly DependencyProperty IsOverflowPressedProperty;

		private static readonly DependencyPropertyKey RootItemPropertyKey;

		private static readonly DependencyProperty RootItemProperty;

		public static readonly DependencyProperty BreadcrumbItemTemplateSelectorProperty;

		public static readonly DependencyProperty BreadcrumbItemTemplateProperty;

		private static readonly DependencyPropertyKey OverflowModePropertyKey;

		public static readonly DependencyProperty OverflowModeProperty;

		public static readonly DependencyProperty IsDropDownOpenProperty;

		public static readonly DependencyProperty SeparatorStringProperty;

		public static readonly DependencyProperty PathProperty;

		public static readonly DependencyProperty DropDownItemsSourceProperty;

		public static readonly DependencyProperty SelectedDropDownIndexProperty;

		public static readonly DependencyProperty ProgressValueProperty;

		public static readonly DependencyProperty ProgressMaximumProperty;

		public static readonly DependencyProperty ProgressMinimumProperty;

		public static readonly RoutedEvent BreadcrumbItemDropDownOpenedEvent;

		public static readonly RoutedEvent BreadcrumbItemDropDownClosedEvent;

		public static readonly RoutedEvent ProgressValueChangedEvent;

		public static readonly RoutedEvent ApplyPropertiesEvent;

		public static readonly RoutedEvent SelectedBreadcrumbChangedEvent;

		public static readonly RoutedEvent PathChangedEvent;

		public static readonly RoutedEvent PopulateItemsEvent;

		public static readonly RoutedEvent PathConversionEvent;

		private static RoutedUICommand showDropDownCommand;

		private static RoutedUICommand selectRootCommand;

		private static RoutedUICommand selectTraceCommand;

		private ItemsControl comboBoxControlItems;

		private string initPath;

		private ObservableCollection<object> traces;

		private BreadcrumbItem selectedBreadcrumb;

		private ComboBox comboBox;

		private BreadcrumbButton rootButton;

		private ObservableCollection<ButtonBase> buttons = new ObservableCollection<ButtonBase>();

		public event ApplyPropertiesEventHandler ApplyProperties
		{
			add
			{
				base.AddHandler(BreadcrumbBar.ApplyPropertiesEvent, value);
			}
			remove
			{
				base.RemoveHandler(BreadcrumbBar.ApplyPropertiesEvent, value);
			}
		}

		public event RoutedEventHandler SelectedBreadcrumbChanged
		{
			add
			{
				base.AddHandler(BreadcrumbBar.SelectedBreadcrumbChangedEvent, value);
			}
			remove
			{
				base.RemoveHandler(BreadcrumbBar.SelectedBreadcrumbChangedEvent, value);
			}
		}

		public event RoutedPropertyChangedEventHandler<string> PathChanged
		{
			add
			{
				base.AddHandler(BreadcrumbBar.PathChangedEvent, value);
			}
			remove
			{
				base.RemoveHandler(BreadcrumbBar.PathChangedEvent, value);
			}
		}

		public event BreadcrumbItemEventHandler PopulateItems
		{
			add
			{
				base.AddHandler(BreadcrumbBar.PopulateItemsEvent, value);
			}
			remove
			{
				base.RemoveHandler(BreadcrumbBar.PopulateItemsEvent, value);
			}
		}

		public event PathConversionEventHandler PathConversion
		{
			add
			{
				base.AddHandler(BreadcrumbBar.PathConversionEvent, value);
			}
			remove
			{
				base.RemoveHandler(BreadcrumbBar.PathConversionEvent, value);
			}
		}

		public event BreadcrumbItemEventHandler BreadcrumbItemDropDownOpened
		{
			add
			{
				base.AddHandler(BreadcrumbBar.BreadcrumbItemDropDownOpenedEvent, value);
			}
			remove
			{
				base.RemoveHandler(BreadcrumbBar.BreadcrumbItemDropDownOpenedEvent, value);
			}
		}

		public event BreadcrumbItemEventHandler BreadcrumbItemDropDownClosed
		{
			add
			{
				base.AddHandler(BreadcrumbBar.BreadcrumbItemDropDownClosedEvent, value);
			}
			remove
			{
				base.RemoveHandler(BreadcrumbBar.BreadcrumbItemDropDownClosedEvent, value);
			}
		}

		public event RoutedEventHandler ProgressValueChanged
		{
			add
			{
				base.AddHandler(BreadcrumbBar.ProgressValueChangedEvent, value);
			}
			remove
			{
				base.RemoveHandler(BreadcrumbBar.ProgressValueChangedEvent, value);
			}
		}

		public static RoutedUICommand ShowDropDownCommand
		{
			get
			{
				return BreadcrumbBar.showDropDownCommand;
			}
		}

		public static RoutedUICommand SelectTraceCommand
		{
			get
			{
				return BreadcrumbBar.selectTraceCommand;
			}
		}

		public static RoutedUICommand SelectRootCommand
		{
			get
			{
				return BreadcrumbBar.selectRootCommand;
			}
		}

		public bool IsRootSelected
		{
			get
			{
				return (bool)base.GetValue(BreadcrumbBar.IsRootSelectedProperty);
			}
			private set
			{
				base.SetValue(BreadcrumbBar.IsRootSelectedPropertyKey, value);
			}
		}

		public DataTemplateSelector OverflowItemTemplateSelector
		{
			get
			{
				return (DataTemplateSelector)base.GetValue(BreadcrumbBar.OverflowItemTemplateSelectorProperty);
			}
			set
			{
				base.SetValue(BreadcrumbBar.OverflowItemTemplateSelectorProperty, value);
			}
		}

		public DataTemplate OverflowItemTemplate
		{
			get
			{
				return (DataTemplate)base.GetValue(BreadcrumbBar.OverflowItemTemplateProperty);
			}
			set
			{
				base.SetValue(BreadcrumbBar.OverflowItemTemplateProperty, value);
			}
		}

		public IEnumerable CollapsedTraces
		{
			get
			{
				return (IEnumerable)base.GetValue(BreadcrumbBar.CollapsedTracesProperty);
			}
			private set
			{
				base.SetValue(BreadcrumbBar.CollapsedTracesPropertyKey, value);
			}
		}

		public object Root
		{
			get
			{
				return base.GetValue(BreadcrumbBar.RootProperty);
			}
			set
			{
				base.SetValue(BreadcrumbBar.RootProperty, value);
			}
		}

		public object SelectedItem
		{
			get
			{
				return base.GetValue(BreadcrumbBar.SelectedItemProperty);
			}
			private set
			{
				base.SetValue(BreadcrumbBar.SelectedItemProperty, value);
			}
		}

		public BreadcrumbItem SelectedBreadcrumb
		{
			get
			{
				return (BreadcrumbItem)base.GetValue(BreadcrumbBar.SelectedBreadcrumbProperty);
			}
			private set
			{
				this.selectedBreadcrumb = value;
				base.SetValue(BreadcrumbBar.SelectedBreadcrumbPropertyKey, value);
			}
		}

		public bool IsOverflowPressed
		{
			get
			{
				return (bool)base.GetValue(BreadcrumbBar.IsOverflowPressedProperty);
			}
			private set
			{
				base.SetValue(BreadcrumbBar.IsOverflowPressedProperty, value);
			}
		}

		public BreadcrumbItem RootItem
		{
			get
			{
				return (BreadcrumbItem)base.GetValue(BreadcrumbBar.RootItemProperty);
			}
			protected set
			{
				base.SetValue(BreadcrumbBar.RootItemPropertyKey, value);
			}
		}

		public DataTemplateSelector BreadcrumbItemTemplateSelector
		{
			get
			{
				return (DataTemplateSelector)base.GetValue(BreadcrumbBar.BreadcrumbItemTemplateSelectorProperty);
			}
			set
			{
				base.SetValue(BreadcrumbBar.BreadcrumbItemTemplateSelectorProperty, value);
			}
		}

		public DataTemplate BreadcrumbItemTemplate
		{
			get
			{
				return (DataTemplate)base.GetValue(BreadcrumbBar.BreadcrumbItemTemplateProperty);
			}
			set
			{
				base.SetValue(BreadcrumbBar.BreadcrumbItemTemplateProperty, value);
			}
		}

		public BreadcrumbButton.ButtonMode OverflowMode
		{
			get
			{
				return (BreadcrumbButton.ButtonMode)base.GetValue(BreadcrumbBar.OverflowModeProperty);
			}
			private set
			{
				base.SetValue(BreadcrumbBar.OverflowModePropertyKey, value);
			}
		}

		public IEnumerable DropDownItemsSource
		{
			get
			{
				return (IEnumerable)base.GetValue(BreadcrumbBar.DropDownItemsSourceProperty);
			}
			set
			{
				base.SetValue(BreadcrumbBar.DropDownItemsSourceProperty, value);
			}
		}

		public bool IsDropDownOpen
		{
			get
			{
				return (bool)base.GetValue(BreadcrumbBar.IsDropDownOpenProperty);
			}
			set
			{
				base.SetValue(BreadcrumbBar.IsDropDownOpenProperty, value);
			}
		}

		public string SeparatorString
		{
			get
			{
				return (string)base.GetValue(BreadcrumbBar.SeparatorStringProperty);
			}
			set
			{
				base.SetValue(BreadcrumbBar.SeparatorStringProperty, value);
			}
		}

		public string Path
		{
			get
			{
				return (string)base.GetValue(BreadcrumbBar.PathProperty);
			}
			set
			{
				base.SetValue(BreadcrumbBar.PathProperty, value);
			}
		}

		public ObservableCollection<ButtonBase> Buttons
		{
			get
			{
				return this.buttons;
			}
		}

		public ItemCollection DropDownItems
		{
			get
			{
				return this.comboBoxControlItems.Items;
			}
		}

		public bool HasDropDownItems
		{
			get
			{
				return (bool)base.GetValue(BreadcrumbBar.HasDropDownItemsProperty);
			}
			private set
			{
				base.SetValue(BreadcrumbBar.HasDropDownItemsProperty, value);
			}
		}

		public ItemsPanelTemplate DropDownItemsPanel
		{
			get
			{
				return (ItemsPanelTemplate)base.GetValue(BreadcrumbBar.DropDownItemsPanelProperty);
			}
			set
			{
				base.SetValue(BreadcrumbBar.DropDownItemsPanelProperty, value);
			}
		}

		public DataTemplateSelector DropDownItemTemplateSelector
		{
			get
			{
				return (DataTemplateSelector)base.GetValue(BreadcrumbBar.DropDownItemTemplateSelectorProperty);
			}
			set
			{
				base.SetValue(BreadcrumbBar.DropDownItemTemplateSelectorProperty, value);
			}
		}

		public DataTemplate DropDownItemTemplate
		{
			get
			{
				return (DataTemplate)base.GetValue(BreadcrumbBar.DropDownItemTemplateProperty);
			}
			set
			{
				base.SetValue(BreadcrumbBar.DropDownItemTemplateProperty, value);
			}
		}

		public bool IsEditable
		{
			get
			{
				return (bool)base.GetValue(BreadcrumbBar.IsEditableProperty);
			}
			set
			{
				base.SetValue(BreadcrumbBar.IsEditableProperty, value);
			}
		}

		public int SelectedDropDownIndex
		{
			get
			{
				return (int)base.GetValue(BreadcrumbBar.SelectedDropDownIndexProperty);
			}
			set
			{
				base.SetValue(BreadcrumbBar.SelectedDropDownIndexProperty, value);
			}
		}

		public double ProgressValue
		{
			get
			{
				return (double)base.GetValue(BreadcrumbBar.ProgressValueProperty);
			}
			set
			{
				base.SetValue(BreadcrumbBar.ProgressValueProperty, value);
			}
		}

		public double ProgressMaximum
		{
			get
			{
				return (double)base.GetValue(BreadcrumbBar.ProgressMaximumProperty);
			}
			set
			{
				base.SetValue(BreadcrumbBar.ProgressMaximumProperty, value);
			}
		}

		public double ProgressMimimum
		{
			get
			{
				return (double)base.GetValue(BreadcrumbBar.ProgressMinimumProperty);
			}
			set
			{
				base.SetValue(BreadcrumbBar.ProgressMinimumProperty, value);
			}
		}

		protected override IEnumerator LogicalChildren
		{
			get
			{
				object rootItem = this.RootItem;
				IEnumerator result;
				if (rootItem == null)
				{
					result = base.LogicalChildren;
				}
				else
				{
					if (base.TemplatedParent != null)
					{
						DependencyObject dependencyObject = rootItem as DependencyObject;
						if (dependencyObject != null)
						{
							DependencyObject parent = LogicalTreeHelper.GetParent(dependencyObject);
							if (parent != null && parent != this)
							{
								result = base.LogicalChildren;
								return result;
							}
						}
					}
					object[] array = new object[]
					{
						this.RootItem
					};
					result = array.GetEnumerator();
				}
				return result;
			}
		}

		public BindingBase TraceBinding
		{
			get;
			set;
		}

		public BindingBase ImageBinding
		{
			get;
			set;
		}

		static BreadcrumbBar()
		{
			BreadcrumbBar.HasDropDownItemsProperty = DependencyProperty.Register("HasDropDownItems", typeof(bool), typeof(BreadcrumbBar), new UIPropertyMetadata(false));
			BreadcrumbBar.DropDownItemsPanelProperty = DependencyProperty.Register("DropDownItemsPanel", typeof(ItemsPanelTemplate), typeof(BreadcrumbBar), new UIPropertyMetadata(null));
			BreadcrumbBar.IsRootSelectedPropertyKey = DependencyProperty.RegisterReadOnly("IsRootSelected", typeof(bool), typeof(BreadcrumbBar), new UIPropertyMetadata(true));
			BreadcrumbBar.IsRootSelectedProperty = BreadcrumbBar.IsRootSelectedPropertyKey.DependencyProperty;
			BreadcrumbBar.DropDownItemTemplateProperty = DependencyProperty.Register("DropDownItemTemplate", typeof(DataTemplate), typeof(BreadcrumbBar), new UIPropertyMetadata(null));
			BreadcrumbBar.IsEditableProperty = DependencyProperty.Register("IsEditable", typeof(bool), typeof(BreadcrumbBar), new UIPropertyMetadata(true));
			BreadcrumbBar.DropDownItemTemplateSelectorProperty = DependencyProperty.Register("DropDownItemTemplateSelector", typeof(DataTemplateSelector), typeof(BreadcrumbBar), new UIPropertyMetadata(null));
			BreadcrumbBar.OverflowItemTemplateSelectorProperty = DependencyProperty.Register("OverflowItemTemplateSelector", typeof(DataTemplateSelector), typeof(BreadcrumbBar), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));
			BreadcrumbBar.OverflowItemTemplateProperty = DependencyProperty.Register("OverflowItemTemplate", typeof(DataTemplate), typeof(BreadcrumbBar), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));
			BreadcrumbBar.CollapsedTracesPropertyKey = DependencyProperty.RegisterReadOnly("CollapsedTraces", typeof(IEnumerable), typeof(BreadcrumbBar), new UIPropertyMetadata(null));
			BreadcrumbBar.CollapsedTracesProperty = BreadcrumbBar.CollapsedTracesPropertyKey.DependencyProperty;
			BreadcrumbBar.RootProperty = DependencyProperty.Register("Root", typeof(object), typeof(BreadcrumbBar), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(BreadcrumbBar.RootPropertyChanged)));
			BreadcrumbBar.SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(BreadcrumbBar), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange, new PropertyChangedCallback(BreadcrumbBar.SelectedItemPropertyChanged)));
			BreadcrumbBar.SelectedBreadcrumbPropertyKey = DependencyProperty.RegisterReadOnly("SelectedBreadcrumb", typeof(BreadcrumbItem), typeof(BreadcrumbBar), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(BreadcrumbBar.SelectedBreadcrumbPropertyChanged)));
			BreadcrumbBar.SelectedBreadcrumbProperty = BreadcrumbBar.SelectedBreadcrumbPropertyKey.DependencyProperty;
			BreadcrumbBar.IsOverflowPressedProperty = DependencyProperty.Register("IsOverflowPressed", typeof(bool), typeof(BreadcrumbBar), new UIPropertyMetadata(false, new PropertyChangedCallback(BreadcrumbBar.OverflowPressedChanged)));
			BreadcrumbBar.RootItemPropertyKey = DependencyProperty.RegisterReadOnly("RootItem", typeof(BreadcrumbItem), typeof(BreadcrumbBar), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));
			BreadcrumbBar.RootItemProperty = BreadcrumbBar.RootItemPropertyKey.DependencyProperty;
			BreadcrumbBar.BreadcrumbItemTemplateSelectorProperty = DependencyProperty.Register("BreadcrumbItemTemplateSelector", typeof(DataTemplateSelector), typeof(BreadcrumbBar), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));
			BreadcrumbBar.BreadcrumbItemTemplateProperty = DependencyProperty.Register("BreadcrumbItemTemplate", typeof(DataTemplate), typeof(BreadcrumbBar), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));
			BreadcrumbBar.OverflowModePropertyKey = DependencyProperty.RegisterReadOnly("OverflowMode", typeof(BreadcrumbButton.ButtonMode), typeof(BreadcrumbBar), new FrameworkPropertyMetadata(BreadcrumbButton.ButtonMode.Overflow, FrameworkPropertyMetadataOptions.AffectsRender));
			BreadcrumbBar.OverflowModeProperty = BreadcrumbBar.OverflowModePropertyKey.DependencyProperty;
			BreadcrumbBar.IsDropDownOpenProperty = DependencyProperty.Register("IsDropDownOpen", typeof(bool), typeof(BreadcrumbBar), new UIPropertyMetadata(false, new PropertyChangedCallback(BreadcrumbBar.IsDropDownOpenChanged)));
			BreadcrumbBar.SeparatorStringProperty = DependencyProperty.Register("SeparatorString", typeof(string), typeof(BreadcrumbBar), new UIPropertyMetadata("\\"));
			BreadcrumbBar.PathProperty = DependencyProperty.Register("Path", typeof(string), typeof(BreadcrumbBar), new UIPropertyMetadata(null, new PropertyChangedCallback(BreadcrumbBar.PathPropertyChanged)));
			BreadcrumbBar.DropDownItemsSourceProperty = DependencyProperty.Register("DropDownItemsSource", typeof(IEnumerable), typeof(BreadcrumbBar), new UIPropertyMetadata(null, new PropertyChangedCallback(BreadcrumbBar.DropDownItemsSourcePropertyChanged)));
			BreadcrumbBar.SelectedDropDownIndexProperty = DependencyProperty.Register("SelectedDropDownIndex", typeof(int), typeof(BreadcrumbBar), new UIPropertyMetadata(-1));
			BreadcrumbBar.ProgressValueProperty = DependencyProperty.Register("ProgressValue", typeof(double), typeof(BreadcrumbBar), new UIPropertyMetadata(0.0, new PropertyChangedCallback(BreadcrumbBar.ProgressValuePropertyChanged), new CoerceValueCallback(BreadcrumbBar.CoerceProgressValue)));
			BreadcrumbBar.ProgressMaximumProperty = DependencyProperty.Register("ProgressMaximum", typeof(double), typeof(BreadcrumbBar), new UIPropertyMetadata(100.0, null, new CoerceValueCallback(BreadcrumbBar.CoerceProgressMaximum)));
			BreadcrumbBar.ProgressMinimumProperty = DependencyProperty.Register("ProgressMinimum", typeof(double), typeof(BreadcrumbBar), new UIPropertyMetadata(0.0, null, new CoerceValueCallback(BreadcrumbBar.CoerceProgressMinimum)));
			BreadcrumbBar.BreadcrumbItemDropDownOpenedEvent = EventManager.RegisterRoutedEvent("BreadcrumbItemDropDownOpened", RoutingStrategy.Bubble, typeof(BreadcrumbItemEventHandler), typeof(BreadcrumbBar));
			BreadcrumbBar.BreadcrumbItemDropDownClosedEvent = EventManager.RegisterRoutedEvent("BreadcrumbItemDropDownClosed", RoutingStrategy.Bubble, typeof(BreadcrumbItemEventHandler), typeof(BreadcrumbBar));
			BreadcrumbBar.ProgressValueChangedEvent = EventManager.RegisterRoutedEvent("ProgressValueChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(BreadcrumbBar));
			BreadcrumbBar.ApplyPropertiesEvent = EventManager.RegisterRoutedEvent("ApplyProperties", RoutingStrategy.Bubble, typeof(ApplyPropertiesEventHandler), typeof(BreadcrumbBar));
			BreadcrumbBar.SelectedBreadcrumbChangedEvent = EventManager.RegisterRoutedEvent("SelectedBreadcrumbChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<BreadcrumbItem>), typeof(BreadcrumbBar));
			BreadcrumbBar.PathChangedEvent = EventManager.RegisterRoutedEvent("PathChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<string>), typeof(BreadcrumbBar));
			BreadcrumbBar.PopulateItemsEvent = EventManager.RegisterRoutedEvent("PopulateItems", RoutingStrategy.Bubble, typeof(BreadcrumbItemEventHandler), typeof(BreadcrumbBar));
			BreadcrumbBar.PathConversionEvent = EventManager.RegisterRoutedEvent("PathConversion", RoutingStrategy.Bubble, typeof(PathConversionEventHandler), typeof(BreadcrumbBar));
			BreadcrumbBar.showDropDownCommand = new RoutedUICommand("Show DropDown", "ShowDropDownCommand", typeof(BreadcrumbBar));
			BreadcrumbBar.selectRootCommand = new RoutedUICommand("Select", "SelectRootCommand", typeof(BreadcrumbBar));
			BreadcrumbBar.selectTraceCommand = new RoutedUICommand("Select", "SelectTraceCommand", typeof(BreadcrumbBar));
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(BreadcrumbBar), new FrameworkPropertyMetadata(typeof(BreadcrumbBar)));
			Control.BorderThicknessProperty.OverrideMetadata(typeof(BreadcrumbBar), new FrameworkPropertyMetadata(new Thickness(1.0)));
			Control.BorderBrushProperty.OverrideMetadata(typeof(BreadcrumbBar), new FrameworkPropertyMetadata(Brushes.Black));
			Color color = default(Color);
			color.R = 245;
			color.G = 245;
			color.B = 245;
			color.A = 255;
			Control.BackgroundProperty.OverrideMetadata(typeof(BreadcrumbBar), new FrameworkPropertyMetadata(new SolidColorBrush(color)));
			CommandManager.RegisterClassCommandBinding(typeof(FrameworkElement), new CommandBinding(BreadcrumbBar.selectRootCommand, new ExecutedRoutedEventHandler(BreadcrumbBar.SelectRootCommandExecuted)));
			CommandManager.RegisterClassCommandBinding(typeof(FrameworkElement), new CommandBinding(BreadcrumbBar.selectTraceCommand, new ExecutedRoutedEventHandler(BreadcrumbBar.SelectTraceCommandExecuted)));
			CommandManager.RegisterClassCommandBinding(typeof(FrameworkElement), new CommandBinding(BreadcrumbBar.showDropDownCommand, new ExecutedRoutedEventHandler(BreadcrumbBar.ShowDropDownExecuted)));
		}

		public BreadcrumbBar()
		{
			this.comboBoxControlItems = new ItemsControl();
			Binding binding = new Binding("HasItems");
			binding.Source = this.comboBoxControlItems;
			base.SetBinding(BreadcrumbBar.HasDropDownItemsProperty, binding);
			this.traces = new ObservableCollection<object>();
			this.CollapsedTraces = this.traces;
			base.AddHandler(Selector.SelectionChangedEvent, new RoutedEventHandler(this.breadcrumbItemSelectedItemChanged));
			base.AddHandler(BreadcrumbItem.TraceChangedEvent, new RoutedEventHandler(this.breadcrumbItemTraceValueChanged));
			base.AddHandler(Selector.SelectionChangedEvent, new RoutedEventHandler(this.breadcrumbItemSelectionChangedEvent));
			base.AddHandler(BreadcrumbItem.DropDownPressedChangedEvent, new RoutedEventHandler(this.breadcrumbItemDropDownChangedEvent));
			base.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(this.buttonClickedEvent));
			this.traces.Add(null);
			base.InputBindings.Add(new KeyBinding(BreadcrumbBar.ShowDropDownCommand, new KeyGesture(Key.Down, ModifierKeys.Alt)));
		}

		private static void IsDropDownOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BreadcrumbBar breadcrumbBar = d as BreadcrumbBar;
			breadcrumbBar.OnDropDownOpenChanged((bool)e.OldValue, (bool)e.NewValue);
		}

		private static void SelectedBreadcrumbPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BreadcrumbBar breadcrumbBar = d as BreadcrumbBar;
			BreadcrumbItem breadcrumbItem = e.NewValue as BreadcrumbItem;
			breadcrumbBar.IsRootSelected = (breadcrumbItem == breadcrumbBar.RootItem);
			if (breadcrumbBar.IsInitialized)
			{
				RoutedPropertyChangedEventArgs<BreadcrumbItem> e2 = new RoutedPropertyChangedEventArgs<BreadcrumbItem>(e.OldValue as BreadcrumbItem, e.NewValue as BreadcrumbItem, BreadcrumbBar.SelectedBreadcrumbChangedEvent);
				breadcrumbBar.RaiseEvent(e2);
			}
		}

		protected virtual void OnSelectedBreadcrumbChanged(DependencyPropertyChangedEventArgs e)
		{
			if (this.SelectedBreadcrumb != null)
			{
				this.SelectedBreadcrumb.SelectedItem = null;
			}
		}

		private static void PathPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BreadcrumbBar breadcrumbBar = d as BreadcrumbBar;
			string text = e.NewValue as string;
			if (!breadcrumbBar.IsInitialized)
			{
				breadcrumbBar.Path = (breadcrumbBar.initPath = text);
			}
			else
			{
				breadcrumbBar.BuildBreadcrumbsFromPath(text);
				breadcrumbBar.OnPathChanged(e.OldValue as string, text);
			}
		}

		protected virtual void OnPathChanged(string oldValue, string newValue)
		{
			this.BuildBreadcrumbsFromPath(this.Path);
			if (base.IsLoaded)
			{
				RoutedPropertyChangedEventArgs<string> e = new RoutedPropertyChangedEventArgs<string>(oldValue, newValue, BreadcrumbBar.PathChangedEvent);
				base.RaiseEvent(e);
			}
		}

		private bool BuildBreadcrumbsFromPath(string newPath)
		{
			PathConversionEventArgs pathConversionEventArgs = new PathConversionEventArgs(PathConversionEventArgs.ConversionMode.EditToDisplay, newPath, this.Root, BreadcrumbBar.PathConversionEvent);
			base.RaiseEvent(pathConversionEventArgs);
			newPath = pathConversionEventArgs.DisplayPath;
			BreadcrumbItem breadcrumbItem = this.RootItem;
			bool result;
			if (breadcrumbItem == null)
			{
				this.Path = null;
				result = false;
			}
			else
			{
				newPath = this.RemoveLastEmptySeparator(newPath);
				string[] array = newPath.Split(new string[]
				{
					this.SeparatorString
				}, StringSplitOptions.None);
				if (array.Length == 0)
				{
					this.RootItem.SelectedItem = null;
				}
				int num = 0;
				List<int> list = new List<int>();
				int num2 = array.Length;
				int num3 = 1;
				if (num3 > 0 && array[num] == this.RootItem.TraceValue)
				{
					num2--;
					num++;
					num3--;
				}
				for (int i = num; i < array.Length; i++)
				{
					if (breadcrumbItem == null)
					{
						break;
					}
					string trace = array[i];
					this.OnPopulateItems(breadcrumbItem);
					object traceItem = breadcrumbItem.GetTraceItem(trace);
					if (traceItem == null)
					{
						break;
					}
					list.Add(breadcrumbItem.Items.IndexOf(traceItem));
					BreadcrumbItem breadcrumbItem2 = breadcrumbItem.ContainerFromItem(traceItem);
					breadcrumbItem = breadcrumbItem2;
				}
				if (num2 != list.Count)
				{
					this.Path = this.GetDisplayPath();
					result = false;
				}
				else
				{
					base.RemoveHandler(Selector.SelectionChangedEvent, new RoutedEventHandler(this.breadcrumbItemSelectedItemChanged));
					try
					{
						breadcrumbItem = this.RootItem;
						for (int i = 0; i < list.Count; i++)
						{
							if (breadcrumbItem == null)
							{
								break;
							}
							breadcrumbItem.SelectedIndex = list[i];
							breadcrumbItem = breadcrumbItem.SelectedBreadcrumb;
						}
						if (breadcrumbItem != null)
						{
							breadcrumbItem.SelectedItem = null;
						}
						this.SelectedBreadcrumb = breadcrumbItem;
						this.SelectedItem = ((breadcrumbItem != null) ? breadcrumbItem.Data : null);
					}
					finally
					{
						base.AddHandler(Selector.SelectionChangedEvent, new RoutedEventHandler(this.breadcrumbItemSelectedItemChanged));
					}
					result = true;
				}
			}
			return result;
		}

		private string RemoveLastEmptySeparator(string path)
		{
			path = path.Trim();
			int length = this.SeparatorString.Length;
			if (path.EndsWith(this.SeparatorString))
			{
				path = path.Remove(path.Length - length, length);
			}
			return path;
		}

		private static void DropDownItemsSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BreadcrumbBar breadcrumbBar = d as BreadcrumbBar;
			breadcrumbBar.comboBoxControlItems.ItemsSource = (e.NewValue as IEnumerable);
		}

		protected virtual void OnDropDownOpenChanged(bool oldValue, bool newValue)
		{
			if (this.comboBox != null && newValue)
			{
				this.SetInputState();
				if (this.IsEditable)
				{
					this.comboBox.Visibility = Visibility.Visible;
					this.comboBox.IsDropDownOpen = true;
				}
			}
		}

		private static void SelectRootCommandExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			BreadcrumbItem breadcrumbItem = e.Parameter as BreadcrumbItem;
			if (breadcrumbItem != null)
			{
				breadcrumbItem.SelectedItem = null;
			}
		}

		private static void SelectTraceCommandExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			BreadcrumbItem breadcrumbItem = e.Parameter as BreadcrumbItem;
			if (breadcrumbItem != null)
			{
				breadcrumbItem.SelectedItem = null;
			}
		}

		private static void ShowDropDownExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			BreadcrumbBar breadcrumbBar = sender as BreadcrumbBar;
			if (breadcrumbBar.IsEditable && breadcrumbBar.DropDownItems.Count > 0)
			{
				breadcrumbBar.IsDropDownOpen = true;
			}
		}

		private void breadcrumbItemSelectedItemChanged(object sender, RoutedEventArgs e)
		{
			BreadcrumbItem breadcrumbItem = e.OriginalSource as BreadcrumbItem;
			if (breadcrumbItem != null && breadcrumbItem.SelectedBreadcrumb != null)
			{
				breadcrumbItem = breadcrumbItem.SelectedBreadcrumb;
			}
			this.SelectedBreadcrumb = breadcrumbItem;
			if (this.SelectedBreadcrumb != null)
			{
				this.SelectedItem = this.SelectedBreadcrumb.Data;
			}
			this.Path = this.GetEditPath();
		}

		private void breadcrumbItemTraceValueChanged(object sender, RoutedEventArgs e)
		{
			if (e.OriginalSource == this.RootItem)
			{
				this.Path = this.GetEditPath();
			}
		}

		private void breadcrumbItemSelectionChangedEvent(object sender, RoutedEventArgs e)
		{
			BreadcrumbItem breadcrumbItem = e.Source as BreadcrumbItem;
			if (breadcrumbItem != null && breadcrumbItem.SelectedBreadcrumb != null)
			{
				this.OnPopulateItems(breadcrumbItem.SelectedBreadcrumb);
			}
		}

		private void breadcrumbItemDropDownChangedEvent(object sender, RoutedEventArgs e)
		{
			BreadcrumbItem breadcrumbItem = e.Source as BreadcrumbItem;
			if (breadcrumbItem.IsDropDownPressed)
			{
				this.OnBreadcrumbItemDropDownOpened(e);
			}
			else
			{
				this.OnBreadcrumbItemDropDownClosed(e);
			}
		}

		private void buttonClickedEvent(object sender, RoutedEventArgs e)
		{
			if (base.IsKeyboardFocusWithin)
			{
				base.Focus();
			}
		}

		protected virtual void OnPopulateItems(BreadcrumbItem item)
		{
			BreadcrumbItemEventArgs e = new BreadcrumbItemEventArgs(item, BreadcrumbBar.PopulateItemsEvent);
			base.RaiseEvent(e);
		}

		protected virtual void OnBreadcrumbItemDropDownOpened(RoutedEventArgs e)
		{
			BreadcrumbItemEventArgs e2 = new BreadcrumbItemEventArgs(e.Source as BreadcrumbItem, BreadcrumbBar.BreadcrumbItemDropDownOpenedEvent);
			base.RaiseEvent(e2);
		}

		protected virtual void OnBreadcrumbItemDropDownClosed(RoutedEventArgs e)
		{
			BreadcrumbItemEventArgs e2 = new BreadcrumbItemEventArgs(e.Source as BreadcrumbItem, BreadcrumbBar.BreadcrumbItemDropDownClosedEvent);
			base.RaiseEvent(e2);
		}

		protected override Size ArrangeOverride(Size arrangeBounds)
		{
			Size result = base.ArrangeOverride(arrangeBounds);
			this.CheckOverflowImage();
			return result;
		}

		private void CheckOverflowImage()
		{
			this.OverflowMode = ((this.RootItem != null && this.RootItem.SelectedBreadcrumb != null && this.RootItem.SelectedBreadcrumb.IsOverflow) ? BreadcrumbButton.ButtonMode.Overflow : BreadcrumbButton.ButtonMode.Breadcrumb);
		}

		private void BuildTraces()
		{
			BreadcrumbItem breadcrumbItem = this.RootItem;
			this.traces.Clear();
			if (breadcrumbItem != null && breadcrumbItem.IsOverflow)
			{
				foreach (object current in ((IEnumerable)breadcrumbItem.Items))
				{
					MenuItem menuItem = new MenuItem();
					menuItem.Tag = current;
					BreadcrumbItem breadcrumbItem2 = breadcrumbItem.ContainerFromItem(current);
					menuItem.Header = breadcrumbItem2.TraceValue;
					menuItem.Click += new RoutedEventHandler(this.menuItem_Click);
					menuItem.Icon = this.GetImage((breadcrumbItem2 != null) ? breadcrumbItem2.Image : null);
					if (current == this.RootItem.SelectedItem)
					{
						menuItem.FontWeight = FontWeights.Bold;
						menuItem.Background = Brushes.LightSkyBlue;
					}
					this.traces.Add(menuItem);
				}
				this.traces.Insert(0, new Separator());
				MenuItem menuItem2 = new MenuItem();
				menuItem2.Header = breadcrumbItem.TraceValue;
				menuItem2.Command = BreadcrumbBar.SelectRootCommand;
				menuItem2.CommandParameter = breadcrumbItem;
				menuItem2.Icon = this.GetImage(breadcrumbItem.Image);
				this.traces.Insert(0, menuItem2);
			}
			for (breadcrumbItem = ((breadcrumbItem != null) ? breadcrumbItem.SelectedBreadcrumb : null); breadcrumbItem != null; breadcrumbItem = breadcrumbItem.SelectedBreadcrumb)
			{
				if (!breadcrumbItem.IsOverflow)
				{
					break;
				}
				MenuItem menuItem3 = new MenuItem();
				menuItem3.Header = breadcrumbItem.TraceValue;
				menuItem3.Command = BreadcrumbBar.SelectRootCommand;
				menuItem3.CommandParameter = breadcrumbItem;
				menuItem3.Icon = this.GetImage(breadcrumbItem.Image);
				this.traces.Insert(0, menuItem3);
			}
		}

		private object GetImage(ImageSource imageSource)
		{
			object result;
			if (imageSource == null)
			{
				result = null;
			}
			else
			{
				Image image = new Image();
				image.Source = imageSource;
				image.Stretch = Stretch.Fill;
				image.SnapsToDevicePixels = true;
				image.Width = (image.Height = 16.0);
				result = image;
			}
			return result;
		}

		private void menuItem_Click(object sender, RoutedEventArgs e)
		{
			MenuItem menuItem = e.Source as MenuItem;
			if (this.RootItem != null && menuItem != null)
			{
				object tag = menuItem.Tag;
				if (tag != null && tag.Equals(this.RootItem.SelectedItem))
				{
					this.RootItem.SelectedItem = null;
				}
				this.RootItem.SelectedItem = tag;
			}
		}

		private static void RootPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BreadcrumbBar breadcrumbBar = d as BreadcrumbBar;
			breadcrumbBar.OnRootChanged(e.OldValue, e.NewValue);
		}

		private static void SelectedItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BreadcrumbBar breadcrumbBar = d as BreadcrumbBar;
			breadcrumbBar.OnSelectedItemChanged(e.OldValue, e.NewValue);
		}

		protected virtual void OnSelectedItemChanged(object oldvalue, object newValue)
		{
		}

		public virtual void OnRootChanged(object oldValue, object newValue)
		{
			newValue = this.GetFirstItem(newValue);
			BreadcrumbItem breadcrumbItem = oldValue as BreadcrumbItem;
			if (breadcrumbItem != null)
			{
				breadcrumbItem.IsRoot = false;
			}
			if (newValue == null)
			{
				this.RootItem = null;
				this.Path = null;
			}
			else
			{
				BreadcrumbItem breadcrumbItem2 = newValue as BreadcrumbItem;
				if (breadcrumbItem2 == null)
				{
					breadcrumbItem2 = BreadcrumbItem.CreateItem(newValue);
				}
				if (breadcrumbItem2 != null)
				{
					breadcrumbItem2.IsRoot = true;
				}
				base.RemoveLogicalChild(oldValue);
				this.RootItem = breadcrumbItem2;
				if (breadcrumbItem2 != null)
				{
					if (LogicalTreeHelper.GetParent(breadcrumbItem2) == null)
					{
						base.AddLogicalChild(breadcrumbItem2);
					}
				}
				this.SelectedItem = ((breadcrumbItem2 != null) ? breadcrumbItem2.DataContext : null);
				if (base.IsInitialized)
				{
					this.SelectedBreadcrumb = breadcrumbItem2;
				}
				else
				{
					this.selectedBreadcrumb = breadcrumbItem2;
				}
			}
		}

		private object GetFirstItem(object entity)
		{
			ICollection collection = entity as ICollection;
			object result;
			if (collection != null)
			{
				using (IEnumerator enumerator = collection.GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						object current = enumerator.Current;
						result = current;
						return result;
					}
				}
			}
			result = entity;
			return result;
		}

		private static void OverflowPressedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BreadcrumbBar breadcrumbBar = d as BreadcrumbBar;
			breadcrumbBar.OnOverflowPressedChanged();
		}

		protected virtual void OnOverflowPressedChanged()
		{
			if (this.IsOverflowPressed)
			{
				this.BuildTraces();
			}
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this.comboBox = (base.GetTemplateChild("PART_ComboBox") as ComboBox);
			this.rootButton = (base.GetTemplateChild("PART_Root") as BreadcrumbButton);
			if (this.comboBox != null)
			{
				this.comboBox.DropDownClosed += new EventHandler(this.comboBox_DropDownClosed);
				this.comboBox.IsKeyboardFocusWithinChanged += new DependencyPropertyChangedEventHandler(this.comboBox_IsKeyboardFocusWithinChanged);
				this.comboBox.KeyDown += new KeyEventHandler(this.comboBox_KeyDown);
			}
			if (this.rootButton != null)
			{
				this.rootButton.Click += new RoutedEventHandler(this.rootButton_Click);
			}
		}

		protected override void OnInitialized(EventArgs e)
		{
			base.OnInitialized(e);
			if (this.initPath != null)
			{
				this.initPath = null;
				this.BuildBreadcrumbsFromPath(this.Path);
			}
		}

		private void comboBox_KeyDown(object sender, KeyEventArgs e)
		{
			Key key = e.Key;
			if (key != Key.Return)
			{
				if (key != Key.Escape)
				{
					return;
				}
				this.Exit(false);
			}
			else
			{
				this.Exit(true);
			}
			e.Handled = true;
		}

		private void comboBox_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (!(bool)e.NewValue)
			{
				this.Exit(true);
			}
		}

		protected override void OnMouseDown(MouseButtonEventArgs e)
		{
			if (!e.Handled)
			{
				if (e.ChangedButton == MouseButton.Left && e.LeftButton == MouseButtonState.Pressed)
				{
					e.Handled = true;
					this.SetInputState();
				}
				base.OnMouseDown(e);
			}
		}

		private void rootButton_Click(object sender, RoutedEventArgs e)
		{
			this.SetInputState();
		}

		private void SetInputState()
		{
			if (this.comboBox != null && this.IsEditable)
			{
				this.comboBox.Text = this.Path;
				this.comboBox.Visibility = Visibility.Visible;
				this.comboBox.Focus();
			}
		}

		public string GetEditPath()
		{
			string displayPath = this.GetDisplayPath();
			PathConversionEventArgs pathConversionEventArgs = new PathConversionEventArgs(PathConversionEventArgs.ConversionMode.DisplayToEdit, displayPath, this.Root, BreadcrumbBar.PathConversionEvent);
			base.RaiseEvent(pathConversionEventArgs);
			return pathConversionEventArgs.EditPath;
		}

		public string PathFromBreadcrumbItem(BreadcrumbItem item)
		{
			StringBuilder stringBuilder = new StringBuilder();
			while (item != null)
			{
				if (item == this.RootItem && stringBuilder.Length > 0)
				{
					break;
				}
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Insert(0, this.SeparatorString);
				}
				stringBuilder.Insert(0, item.TraceValue);
				item = item.ParentBreadcrumbItem;
			}
			PathConversionEventArgs pathConversionEventArgs = new PathConversionEventArgs(PathConversionEventArgs.ConversionMode.DisplayToEdit, stringBuilder.ToString(), this.Root, BreadcrumbBar.PathConversionEvent);
			base.RaiseEvent(pathConversionEventArgs);
			return pathConversionEventArgs.EditPath;
		}

		public string GetDisplayPath()
		{
			string separatorString = this.SeparatorString;
			StringBuilder stringBuilder = new StringBuilder();
			BreadcrumbItem rootItem = this.RootItem;
			int num = 0;
			while (rootItem != null)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(separatorString);
				}
				if (num >= 1 || rootItem.SelectedItem == null)
				{
					stringBuilder.Append(rootItem.GetTracePathValue());
				}
				num++;
				rootItem = rootItem.SelectedBreadcrumb;
			}
			return stringBuilder.ToString();
		}

		private void Exit(bool updatePath)
		{
			if (this.comboBox != null)
			{
				if (updatePath && this.comboBox.IsVisible)
				{
					this.Path = this.comboBox.Text;
				}
				this.comboBox.Visibility = Visibility.Hidden;
			}
		}

		private void comboBox_DropDownClosed(object sender, EventArgs e)
		{
			this.IsDropDownOpen = false;
			this.Path = this.comboBox.Text;
		}

		private static object CoerceProgressValue(DependencyObject d, object baseValue)
		{
			BreadcrumbBar breadcrumbBar = d as BreadcrumbBar;
			double num = (double)baseValue;
			if (num > breadcrumbBar.ProgressMaximum)
			{
				num = breadcrumbBar.ProgressMaximum;
			}
			if (num < breadcrumbBar.ProgressMimimum)
			{
				num = breadcrumbBar.ProgressMimimum;
			}
			return num;
		}

		private static void ProgressValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			RoutedEventArgs e2 = new RoutedEventArgs(BreadcrumbBar.ProgressValueChangedEvent);
			BreadcrumbBar breadcrumbBar = d as BreadcrumbBar;
			breadcrumbBar.RaiseEvent(e2);
		}

		protected override void OnMouseLeave(MouseEventArgs e)
		{
			if (base.IsKeyboardFocusWithin)
			{
				base.Focus();
			}
			base.OnMouseLeave(e);
		}

		private static object CoerceProgressMaximum(DependencyObject d, object baseValue)
		{
			BreadcrumbBar breadcrumbBar = d as BreadcrumbBar;
			double num = (double)baseValue;
			if (num < breadcrumbBar.ProgressMimimum)
			{
				num = breadcrumbBar.ProgressMimimum;
			}
			if (num < breadcrumbBar.ProgressValue)
			{
				breadcrumbBar.ProgressValue = num;
			}
			if (num < 0.0)
			{
				num = 0.0;
			}
			return num;
		}

		private static object CoerceProgressMinimum(DependencyObject d, object baseValue)
		{
			BreadcrumbBar breadcrumbBar = d as BreadcrumbBar;
			double num = (double)baseValue;
			if (num > breadcrumbBar.ProgressMaximum)
			{
				num = breadcrumbBar.ProgressMaximum;
			}
			if (num > breadcrumbBar.ProgressValue)
			{
				breadcrumbBar.ProgressValue = num;
			}
			return num;
		}

		public void AddChild(object value)
		{
			this.Root = value;
		}

		public void AddText(string text)
		{
			this.AddChild(text);
		}
	}
}
