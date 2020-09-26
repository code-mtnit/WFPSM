using System;
using System.Collections;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using System.Xml;

namespace Sbn.Controls.AdvancedControls.AddressBar
{
	[TemplatePart(Name = "PART_Selected"), TemplatePart(Name = "PART_Header")]
	public class BreadcrumbItem : Selector
	{
		private const string partHeader = "PART_Header";

		private const string partSelected = "PART_Selected";

		public static readonly DependencyProperty IsDropDownPressedProperty;

		public static readonly DependencyProperty IsOverflowProperty;

		public static readonly DependencyProperty IsRootProperty;

		private static readonly DependencyPropertyKey SelectedBreadcrumbPropertyKey;

		public static readonly DependencyProperty OverflowItemTemplateSelectorProperty;

		public static readonly DependencyProperty OverflowItemTemplateProperty;

		public static readonly DependencyProperty ImageProperty;

		public static readonly DependencyProperty TraceProperty;

		public static readonly DependencyProperty HeaderProperty;

		public static readonly DependencyProperty HeaderTemplateProperty;

		public static readonly DependencyProperty HeaderTemplateSelectorProperty;

		public static readonly RoutedEvent DropDownPressedChangedEvent;

		public static readonly RoutedEvent TraceChangedEvent;

		private FrameworkElement headerControl;

		private FrameworkElement selectedControl;

		public static readonly RoutedEvent OverflowChangedEvent;

		public static readonly DependencyProperty SelectedBreadcrumbProperty;

		public static readonly DependencyProperty IsButtonVisibleProperty;

		public static readonly DependencyProperty IsImageVisibleProperty;

		public event RoutedPropertyChangedEventHandler<object> DropDownPressedChanged
		{
			add
			{
				base.AddHandler(BreadcrumbItem.DropDownPressedChangedEvent, value);
			}
			remove
			{
				base.RemoveHandler(BreadcrumbItem.DropDownPressedChangedEvent, value);
			}
		}

		public event RoutedPropertyChangedEventHandler<object> TraceChanged
		{
			add
			{
				base.AddHandler(BreadcrumbItem.TraceChangedEvent, value);
			}
			remove
			{
				base.RemoveHandler(BreadcrumbItem.TraceChangedEvent, value);
			}
		}

		public object Data
		{
			get
			{
				return (base.DataContext != null) ? base.DataContext : this;
			}
		}

		public bool IsDropDownPressed
		{
			get
			{
				return (bool)base.GetValue(BreadcrumbItem.IsDropDownPressedProperty);
			}
			set
			{
				base.SetValue(BreadcrumbItem.IsDropDownPressedProperty, value);
			}
		}

		public bool IsOverflow
		{
			get
			{
				return (bool)base.GetValue(BreadcrumbItem.IsOverflowProperty);
			}
			private set
			{
				base.SetValue(BreadcrumbItem.IsOverflowProperty, value);
			}
		}

		public bool IsRoot
		{
			get
			{
				return (bool)base.GetValue(BreadcrumbItem.IsRootProperty);
			}
			set
			{
				base.SetValue(BreadcrumbItem.IsRootProperty, value);
			}
		}

		public BreadcrumbItem SelectedBreadcrumb
		{
			get
			{
				return (BreadcrumbItem)base.GetValue(BreadcrumbItem.SelectedBreadcrumbProperty);
			}
			private set
			{
				base.SetValue(BreadcrumbItem.SelectedBreadcrumbPropertyKey, value);
			}
		}

		public DataTemplateSelector BreadcrumbTemplateSelector
		{
			get;
			set;
		}

		public DataTemplate BreadcrumbItemTemplate
		{
			get;
			set;
		}

		public DataTemplateSelector OverflowItemTemplateSelector
		{
			get
			{
				return (DataTemplateSelector)base.GetValue(BreadcrumbItem.OverflowItemTemplateSelectorProperty);
			}
			set
			{
				base.SetValue(BreadcrumbItem.OverflowItemTemplateSelectorProperty, value);
			}
		}

		public DataTemplate OverflowItemTemplate
		{
			get
			{
				return (DataTemplate)base.GetValue(BreadcrumbItem.OverflowItemTemplateProperty);
			}
			set
			{
				base.SetValue(BreadcrumbItem.OverflowItemTemplateProperty, value);
			}
		}

		public ImageSource Image
		{
			get
			{
				return (ImageSource)base.GetValue(BreadcrumbItem.ImageProperty);
			}
			set
			{
				base.SetValue(BreadcrumbItem.ImageProperty, value);
			}
		}

		public object Trace
		{
			get
			{
				return base.GetValue(BreadcrumbItem.TraceProperty);
			}
			set
			{
				base.SetValue(BreadcrumbItem.TraceProperty, value);
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

		public object Header
		{
			get
			{
				return base.GetValue(BreadcrumbItem.HeaderProperty);
			}
			set
			{
				base.SetValue(BreadcrumbItem.HeaderProperty, value);
			}
		}

		public DataTemplate HeaderTemplate
		{
			get
			{
				return (DataTemplate)base.GetValue(BreadcrumbItem.HeaderTemplateProperty);
			}
			set
			{
				base.SetValue(BreadcrumbItem.HeaderTemplateProperty, value);
			}
		}

		public DataTemplateSelector HeaderTemplateSelector
		{
			get
			{
				return (DataTemplateSelector)base.GetValue(BreadcrumbItem.HeaderTemplateSelectorProperty);
			}
			set
			{
				base.SetValue(BreadcrumbItem.HeaderTemplateSelectorProperty, value);
			}
		}

		public BreadcrumbBar BreadcrumbBar
		{
			get
			{
				DependencyObject dependencyObject = this;
				BreadcrumbBar result;
				while (dependencyObject != null)
				{
					dependencyObject = LogicalTreeHelper.GetParent(dependencyObject);
					if (dependencyObject is BreadcrumbBar)
					{
						result = (dependencyObject as BreadcrumbBar);
						return result;
					}
				}
				result = null;
				return result;
			}
		}

		public BreadcrumbItem ParentBreadcrumbItem
		{
			get
			{
				return LogicalTreeHelper.GetParent(this) as BreadcrumbItem;
			}
		}

		public string TraceValue
		{
			get
			{
				XmlNode xmlNode = this.Trace as XmlNode;
				string result;
				if (xmlNode != null)
				{
					result = xmlNode.Value;
				}
				else if (this.Trace != null)
				{
					result = this.Trace.ToString();
				}
				else if (this.Header != null)
				{
					result = this.Header.ToString();
				}
				else
				{
					result = string.Empty;
				}
				return result;
			}
		}

		protected override IEnumerator LogicalChildren
		{
			get
			{
				object selectedBreadcrumb = this.SelectedBreadcrumb;
				IEnumerator result;
				if (selectedBreadcrumb == null)
				{
					result = base.LogicalChildren;
				}
				else
				{
					if (base.TemplatedParent != null)
					{
						DependencyObject dependencyObject = selectedBreadcrumb as DependencyObject;
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
						this.SelectedBreadcrumb
					};
					result = array.GetEnumerator();
				}
				return result;
			}
		}

		public bool IsButtonVisible
		{
			get
			{
				return (bool)base.GetValue(BreadcrumbItem.IsButtonVisibleProperty);
			}
			set
			{
				base.SetValue(BreadcrumbItem.IsButtonVisibleProperty, value);
			}
		}

		public bool IsImageVisible
		{
			get
			{
				return (bool)base.GetValue(BreadcrumbItem.IsImageVisibleProperty);
			}
			set
			{
				base.SetValue(BreadcrumbItem.IsImageVisibleProperty, value);
			}
		}

		static BreadcrumbItem()
		{
			BreadcrumbItem.IsDropDownPressedProperty = DependencyProperty.Register("IsDropDownPressed", typeof(bool), typeof(BreadcrumbItem), new UIPropertyMetadata(false, new PropertyChangedCallback(BreadcrumbItem.DropDownPressedPropertyChanged)));
			BreadcrumbItem.IsOverflowProperty = DependencyProperty.Register("IsOverflow", typeof(bool), typeof(BreadcrumbItem), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsParentMeasure | FrameworkPropertyMetadataOptions.AffectsParentArrange, new PropertyChangedCallback(BreadcrumbItem.OverflowPropertyChanged)));
			BreadcrumbItem.IsRootProperty = DependencyProperty.Register("IsRoot", typeof(bool), typeof(BreadcrumbItem), new UIPropertyMetadata(false));
			BreadcrumbItem.SelectedBreadcrumbPropertyKey = DependencyProperty.RegisterReadOnly("SelectedBreadcrumb", typeof(BreadcrumbItem), typeof(BreadcrumbItem), new UIPropertyMetadata(null, new PropertyChangedCallback(BreadcrumbItem.SelectedBreadcrumbPropertyChanged)));
			BreadcrumbItem.ImageProperty = DependencyProperty.Register("Image", typeof(ImageSource), typeof(BreadcrumbItem), new UIPropertyMetadata(null));
			BreadcrumbItem.TraceProperty = DependencyProperty.Register("Trace", typeof(object), typeof(BreadcrumbItem), new UIPropertyMetadata(null, new PropertyChangedCallback(BreadcrumbItem.TracePropertyChanged)));
			BreadcrumbItem.HeaderProperty = DependencyProperty.Register("Header", typeof(object), typeof(BreadcrumbItem), new UIPropertyMetadata(null, new PropertyChangedCallback(BreadcrumbItem.HeaderPropertyChanged)));
			BreadcrumbItem.DropDownPressedChangedEvent = EventManager.RegisterRoutedEvent("DropDownPressedChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<object>), typeof(BreadcrumbItem));
			BreadcrumbItem.TraceChangedEvent = EventManager.RegisterRoutedEvent("TraceChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<object>), typeof(BreadcrumbItem));
			BreadcrumbItem.OverflowChangedEvent = EventManager.RegisterRoutedEvent("OverflowChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(BreadcrumbItem));
			BreadcrumbItem.SelectedBreadcrumbProperty = BreadcrumbItem.SelectedBreadcrumbPropertyKey.DependencyProperty;
			BreadcrumbItem.IsButtonVisibleProperty = DependencyProperty.Register("IsButtonVisible", typeof(bool), typeof(BreadcrumbItem), new UIPropertyMetadata(true));
			BreadcrumbItem.IsImageVisibleProperty = DependencyProperty.Register("IsImageVisible", typeof(bool), typeof(BreadcrumbItem), new UIPropertyMetadata(false));
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(BreadcrumbItem), new FrameworkPropertyMetadata(typeof(BreadcrumbItem)));
			BreadcrumbItem.OverflowItemTemplateProperty = BreadcrumbBar.OverflowItemTemplateProperty.AddOwner(typeof(BreadcrumbItem), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));
			BreadcrumbItem.OverflowItemTemplateSelectorProperty = BreadcrumbBar.OverflowItemTemplateSelectorProperty.AddOwner(typeof(BreadcrumbItem), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));
			BreadcrumbItem.HeaderTemplateSelectorProperty = BreadcrumbBar.BreadcrumbItemTemplateSelectorProperty.AddOwner(typeof(BreadcrumbItem), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));
			BreadcrumbItem.HeaderTemplateProperty = BreadcrumbBar.BreadcrumbItemTemplateProperty.AddOwner(typeof(BreadcrumbItem), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));
		}

		protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
		{
			base.OnItemsChanged(e);
		}

		private static void HeaderPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			BreadcrumbItem breadcrumbItem = sender as BreadcrumbItem;
		}

		private static void TracePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			BreadcrumbItem breadcrumbItem = sender as BreadcrumbItem;
			RoutedPropertyChangedEventArgs<object> e2 = new RoutedPropertyChangedEventArgs<object>(e.OldValue, e.NewValue, BreadcrumbItem.TraceChangedEvent);
			breadcrumbItem.RaiseEvent(e2);
		}

		public static BreadcrumbItem CreateItem(object dataContext)
		{
			BreadcrumbItem breadcrumbItem = dataContext as BreadcrumbItem;
			if (breadcrumbItem == null && dataContext != null)
			{
				breadcrumbItem = new BreadcrumbItem();
				breadcrumbItem.DataContext = dataContext;
			}
			return breadcrumbItem;
		}

		private static void SelectedBreadcrumbPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BreadcrumbItem breadcrumbItem = d as BreadcrumbItem;
			breadcrumbItem.OnSelectedBreadcrumbChanged(e.OldValue, e.NewValue);
		}

		protected virtual void OnSelectedBreadcrumbChanged(object oldItem, object newItem)
		{
			if (this.SelectedBreadcrumb != null)
			{
				this.SelectedBreadcrumb.SelectedItem = null;
			}
		}

		protected override bool IsItemItsOwnContainerOverride(object item)
		{
			return item is BreadcrumbItem;
		}

		protected override DependencyObject GetContainerForItemOverride()
		{
			return new BreadcrumbItem();
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this.headerControl = (base.GetTemplateChild("PART_Header") as FrameworkElement);
			this.selectedControl = (base.GetTemplateChild("PART_Selected") as FrameworkElement);
			this.ApplyBinding();
		}

		public static void DropDownPressedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BreadcrumbItem breadcrumbItem = d as BreadcrumbItem;
			breadcrumbItem.OnDropDownPressedChanged();
		}

		protected virtual void OnDropDownPressedChanged()
		{
			RoutedEventArgs e = new RoutedEventArgs(BreadcrumbItem.DropDownPressedChangedEvent);
			base.RaiseEvent(e);
		}

		public static void OverflowPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BreadcrumbItem breadcrumbItem = d as BreadcrumbItem;
			breadcrumbItem.OnOverflowChanged((bool)e.NewValue);
		}

		protected virtual void OnOverflowChanged(bool newValue)
		{
			RoutedEventArgs e = new RoutedEventArgs(BreadcrumbItem.OverflowChangedEvent);
			base.RaiseEvent(e);
		}

		protected override Size MeasureOverride(Size constraint)
		{
			if (base.SelectedItem != null)
			{
				this.headerControl.Visibility = Visibility.Visible;
				this.headerControl.Measure(constraint);
				Size size = new Size(constraint.Width - this.headerControl.DesiredSize.Width, constraint.Height);
				this.selectedControl.Measure(new Size(double.PositiveInfinity, constraint.Height));
				double num = this.headerControl.DesiredSize.Width + this.selectedControl.DesiredSize.Width;
				if (num > constraint.Width || (this.IsRoot && base.SelectedItem != null))
				{
					this.headerControl.Visibility = Visibility.Collapsed;
				}
			}
			else if (this.headerControl != null)
			{
				this.headerControl.Visibility = Visibility.Visible;
			}
			this.IsOverflow = (this.headerControl != null && this.headerControl.Visibility != Visibility.Visible);
			return base.MeasureOverride(constraint);
		}

		protected override void OnSelectionChanged(SelectionChangedEventArgs e)
		{
			if (base.SelectedItem == null)
			{
				this.SelectedBreadcrumb = null;
			}
			else
			{
				this.SelectedBreadcrumb = this.ContainerFromItem(base.SelectedItem);
			}
			base.OnSelectionChanged(e);
		}

		public BreadcrumbItem ContainerFromItem(object item)
		{
			BreadcrumbItem breadcrumbItem = item as BreadcrumbItem;
			if (breadcrumbItem == null)
			{
				breadcrumbItem = BreadcrumbItem.CreateItem(item);
				if (breadcrumbItem != null)
				{
					base.AddLogicalChild(breadcrumbItem);
					breadcrumbItem.ApplyTemplate();
				}
			}
			return breadcrumbItem;
		}

		public void ApplyBinding()
		{
			object dataContext = base.DataContext;
			if (dataContext != null)
			{
				DataTemplate dataTemplate = this.HeaderTemplate;
				DataTemplateSelector headerTemplateSelector = this.HeaderTemplateSelector;
				if (headerTemplateSelector != null)
				{
					dataTemplate = headerTemplateSelector.SelectTemplate(dataContext, this);
				}
				if (dataTemplate == null)
				{
					DataTemplateKey resourceKey = BreadcrumbItem.GetResourceKey(dataContext);
					if (resourceKey != null)
					{
						dataTemplate = (base.TryFindResource(resourceKey) as DataTemplate);
					}
				}
				this.SelectedItem = null;
				HierarchicalDataTemplate hierarchicalDataTemplate = dataTemplate as HierarchicalDataTemplate;
				if (dataTemplate != null)
				{
					this.Header = dataTemplate.LoadContent();
				}
				else
				{
					this.Header = dataContext;
				}
				this.DataContext = dataContext;
				if (hierarchicalDataTemplate != null)
				{
					this.SetBinding(ItemsControl.ItemsSourceProperty, hierarchicalDataTemplate.ItemsSource);
				}
				BreadcrumbBar breadcrumbBar = this.BreadcrumbBar;
				if (breadcrumbBar != null)
				{
					if (this.TraceBinding == null)
					{
						this.TraceBinding = breadcrumbBar.TraceBinding;
					}
					if (this.ImageBinding == null)
					{
						this.ImageBinding = breadcrumbBar.ImageBinding;
					}
				}
				if (this.TraceBinding != null)
				{
					this.SetBinding(BreadcrumbItem.TraceProperty, this.TraceBinding);
				}
				if (this.ImageBinding != null)
				{
					this.SetBinding(BreadcrumbItem.ImageProperty, this.ImageBinding);
				}
				this.ApplyProperties(dataContext);
			}
		}

		private static DataTemplateKey GetResourceKey(object item)
		{
			XmlDataProvider xmlDataProvider = item as XmlDataProvider;
			DataTemplateKey result;
			if (xmlDataProvider != null)
			{
				result = new DataTemplateKey(xmlDataProvider.XPath);
			}
			else
			{
				XmlNode xmlNode = item as XmlNode;
				if (xmlNode != null)
				{
					result = new DataTemplateKey(xmlNode.Name);
				}
				else
				{
					result = new DataTemplateKey(item.GetType());
				}
			}
			return result;
		}

		private void ApplyProperties(object item)
		{
			ApplyPropertiesEventArgs applyPropertiesEventArgs = new ApplyPropertiesEventArgs(item, this, BreadcrumbBar.ApplyPropertiesEvent);
			applyPropertiesEventArgs.Image = this.Image;
			applyPropertiesEventArgs.Trace = this.Trace;
			applyPropertiesEventArgs.FontSize = base.FontSize;
			applyPropertiesEventArgs.TraceValue = this.TraceValue;
			base.RaiseEvent(applyPropertiesEventArgs);
			this.Image = applyPropertiesEventArgs.Image;
			this.Trace = applyPropertiesEventArgs.Trace;
			base.FontSize = applyPropertiesEventArgs.FontSize;
		}

		public string GetTracePathValue()
		{
			ApplyPropertiesEventArgs applyPropertiesEventArgs = new ApplyPropertiesEventArgs(base.DataContext, this, BreadcrumbBar.ApplyPropertiesEvent);
			applyPropertiesEventArgs.Trace = this.Trace;
			applyPropertiesEventArgs.TraceValue = this.TraceValue;
			base.RaiseEvent(applyPropertiesEventArgs);
			return applyPropertiesEventArgs.TraceValue;
		}

		public object GetTraceItem(string trace)
		{
			object result;
			foreach (object current in ((IEnumerable)base.Items))
			{
				BreadcrumbItem breadcrumbItem = this.ContainerFromItem(current);
				if (current == null)
				{
					result = null;
					return result;
				}
				string traceValue = breadcrumbItem.TraceValue;
				if (traceValue != null && traceValue.Equals(trace, StringComparison.InvariantCultureIgnoreCase))
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}
	}
}
