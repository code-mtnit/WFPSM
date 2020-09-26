using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Sbn.Controls.AdvancedControls.AddressBar
{
	[TemplatePart(Name = "PART_button"), TemplatePart(Name = "PART_DropDown"), TemplatePart(Name = "PART_Toggle"), TemplatePart(Name = "PART_Menu")]
	public class BreadcrumbButton : HeaderedItemsControl
	{
		public enum ButtonMode
		{
			Breadcrumb,
			Overflow,
			DropDown
		}

		private const string partMenu = "PART_Menu";

		private const string partToggle = "PART_Toggle";

		private const string partButton = "PART_button";

		private const string partDropDown = "PART_DropDown";

		public static readonly DependencyProperty ImageProperty;

		public static readonly DependencyProperty SelectedItemProperty;

		public static readonly RoutedEvent SelectedItemChanged;

		public static readonly RoutedEvent ClickEvent;

		private ContextMenu contextMenu;

		private Control dropDownBtn;

		private bool isPressed = false;

		private static RoutedUICommand openOverflowCommand;

		private static RoutedUICommand selectCommand;

		public static readonly DependencyProperty ModeProperty;

		public static readonly DependencyProperty IsPressedProperty;

		public static readonly DependencyProperty IsDropDownPressedProperty;

		public static readonly DependencyProperty DropDownContentTemplateProperty;

		public static readonly DependencyProperty IsDropDownVisibleProperty;

		public static readonly DependencyProperty IsButtonVisibleProperty;

		public static readonly DependencyProperty IsImageVisibleProperty;

		public static readonly DependencyProperty EnableVisualButtonStyleProperty;

		public event RoutedEventHandler Click
		{
			add
			{
				base.AddHandler(BreadcrumbButton.ClickEvent, value);
			}
			remove
			{
				base.RemoveHandler(BreadcrumbButton.ClickEvent, value);
			}
		}

		public event RoutedEventHandler Select
		{
			add
			{
				base.AddHandler(BreadcrumbButton.SelectedItemChanged, value);
			}
			remove
			{
				base.RemoveHandler(BreadcrumbButton.SelectedItemChanged, value);
			}
		}

		public static RoutedUICommand OpenOverflowCommand
		{
			get
			{
				return BreadcrumbButton.openOverflowCommand;
			}
		}

		public static RoutedUICommand SelectCommand
		{
			get
			{
				return BreadcrumbButton.selectCommand;
			}
		}

		public ImageSource Image
		{
			get
			{
				return (ImageSource)base.GetValue(BreadcrumbButton.ImageProperty);
			}
			set
			{
				base.SetValue(BreadcrumbButton.ImageProperty, value);
			}
		}

		public object SelectedItem
		{
			get
			{
				return base.GetValue(BreadcrumbButton.SelectedItemProperty);
			}
			set
			{
				base.SetValue(BreadcrumbButton.SelectedItemProperty, value);
			}
		}

		public BreadcrumbButton.ButtonMode Mode
		{
			get
			{
				return (BreadcrumbButton.ButtonMode)base.GetValue(BreadcrumbButton.ModeProperty);
			}
			set
			{
				base.SetValue(BreadcrumbButton.ModeProperty, value);
			}
		}

		public bool IsPressed
		{
			get
			{
				return (bool)base.GetValue(BreadcrumbButton.IsPressedProperty);
			}
			set
			{
				base.SetValue(BreadcrumbButton.IsPressedProperty, value);
			}
		}

		public bool IsDropDownPressed
		{
			get
			{
				return (bool)base.GetValue(BreadcrumbButton.IsDropDownPressedProperty);
			}
			set
			{
				base.SetValue(BreadcrumbButton.IsDropDownPressedProperty, value);
			}
		}

		public DataTemplate DropDownContentTemplate
		{
			get
			{
				return (DataTemplate)base.GetValue(BreadcrumbButton.DropDownContentTemplateProperty);
			}
			set
			{
				base.SetValue(BreadcrumbButton.DropDownContentTemplateProperty, value);
			}
		}

		public bool IsDropDownVisible
		{
			get
			{
				return (bool)base.GetValue(BreadcrumbButton.IsDropDownVisibleProperty);
			}
			set
			{
				base.SetValue(BreadcrumbButton.IsDropDownVisibleProperty, value);
			}
		}

		public bool IsButtonVisible
		{
			get
			{
				return (bool)base.GetValue(BreadcrumbButton.IsButtonVisibleProperty);
			}
			set
			{
				base.SetValue(BreadcrumbButton.IsButtonVisibleProperty, value);
			}
		}

		public bool IsImageVisible
		{
			get
			{
				return (bool)base.GetValue(BreadcrumbButton.IsImageVisibleProperty);
			}
			set
			{
				base.SetValue(BreadcrumbButton.IsImageVisibleProperty, value);
			}
		}

		public bool EnableVisualButtonStyle
		{
			get
			{
				return (bool)base.GetValue(BreadcrumbButton.EnableVisualButtonStyleProperty);
			}
			set
			{
				base.SetValue(BreadcrumbButton.EnableVisualButtonStyleProperty, value);
			}
		}

		static BreadcrumbButton()
		{
			BreadcrumbButton.ImageProperty = DependencyProperty.Register("Image", typeof(object), typeof(BreadcrumbButton), new UIPropertyMetadata(null));
			BreadcrumbButton.SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(BreadcrumbButton), new UIPropertyMetadata(null, new PropertyChangedCallback(BreadcrumbButton.SelectedItemChangedEvent)));
			BreadcrumbButton.SelectedItemChanged = EventManager.RegisterRoutedEvent("SelectedItemChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(BreadcrumbButton));
			BreadcrumbButton.ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(BreadcrumbButton));
			BreadcrumbButton.openOverflowCommand = new RoutedUICommand("Open Overflow", "OpenOverflowCommand", typeof(BreadcrumbButton));
			BreadcrumbButton.selectCommand = new RoutedUICommand("Select", "SelectCommand", typeof(BreadcrumbButton));
			BreadcrumbButton.ModeProperty = DependencyProperty.Register("Mode", typeof(BreadcrumbButton.ButtonMode), typeof(BreadcrumbButton), new UIPropertyMetadata(BreadcrumbButton.ButtonMode.Breadcrumb));
			BreadcrumbButton.IsPressedProperty = DependencyProperty.Register("IsPressed", typeof(bool), typeof(BreadcrumbButton), new UIPropertyMetadata(false));
			BreadcrumbButton.IsDropDownPressedProperty = DependencyProperty.Register("IsDropDownPressed", typeof(bool), typeof(BreadcrumbButton), new UIPropertyMetadata(false, new PropertyChangedCallback(BreadcrumbButton.OverflowPressedChanged)));
			BreadcrumbButton.DropDownContentTemplateProperty = DependencyProperty.Register("DropDownContentTemplate", typeof(DataTemplate), typeof(BreadcrumbButton), new UIPropertyMetadata(null));
			BreadcrumbButton.IsDropDownVisibleProperty = DependencyProperty.Register("IsDropDownVisible", typeof(bool), typeof(BreadcrumbButton), new UIPropertyMetadata(true));
			BreadcrumbButton.IsButtonVisibleProperty = DependencyProperty.Register("IsButtonVisible", typeof(bool), typeof(BreadcrumbButton), new UIPropertyMetadata(true));
			BreadcrumbButton.IsImageVisibleProperty = DependencyProperty.Register("IsImageVisible", typeof(bool), typeof(BreadcrumbButton), new UIPropertyMetadata(true));
			BreadcrumbButton.EnableVisualButtonStyleProperty = DependencyProperty.Register("EnableVisualButtonStyle", typeof(bool), typeof(BreadcrumbButton), new UIPropertyMetadata(true));
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(BreadcrumbButton), new FrameworkPropertyMetadata(typeof(BreadcrumbButton)));
		}

		public BreadcrumbButton()
		{
			base.CommandBindings.Add(new CommandBinding(BreadcrumbButton.SelectCommand, new ExecutedRoutedEventHandler(this.SelectCommandExecuted)));
			base.CommandBindings.Add(new CommandBinding(BreadcrumbButton.OpenOverflowCommand, new ExecutedRoutedEventHandler(this.OpenOverflowCommandExecuted), new CanExecuteRoutedEventHandler(this.OpenOverflowCommandCanExecute)));
			base.InputBindings.Add(new KeyBinding(BreadcrumbButton.SelectCommand, new KeyGesture(Key.Return)));
			base.InputBindings.Add(new KeyBinding(BreadcrumbButton.SelectCommand, new KeyGesture(Key.Space)));
			base.InputBindings.Add(new KeyBinding(BreadcrumbButton.OpenOverflowCommand, new KeyGesture(Key.Down)));
			base.InputBindings.Add(new KeyBinding(BreadcrumbButton.OpenOverflowCommand, new KeyGesture(Key.Up)));
		}

		protected override void OnMouseLeave(MouseEventArgs e)
		{
			this.IsPressed = false;
		}

		protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			e.Handled = true;
			this.IsPressed = (this.isPressed = true);
			base.OnMouseLeftButtonDown(e);
		}

		protected override void OnMouseUp(MouseButtonEventArgs e)
		{
			e.Handled = true;
			if (this.isPressed)
			{
				RoutedEventArgs e2 = new RoutedEventArgs(BreadcrumbButton.ClickEvent);
				base.RaiseEvent(e2);
				BreadcrumbButton.selectCommand.Execute(null, this);
			}
			this.IsPressed = (this.isPressed = false);
			base.OnMouseUp(e);
		}

		private void SelectCommandExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			this.SelectedItem = null;
			RoutedEventArgs e2 = new RoutedEventArgs(ButtonBase.ClickEvent);
			base.RaiseEvent(e2);
		}

		private void OpenOverflowCommandExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			this.IsDropDownPressed = true;
		}

		private void OpenOverflowCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = (base.Items.Count > 0);
		}

		public override void OnApplyTemplate()
		{
			this.dropDownBtn = (base.GetTemplateChild("PART_DropDown") as Control);
			this.contextMenu = (base.GetTemplateChild("PART_Menu") as ContextMenu);
			if (this.contextMenu != null)
			{
				this.contextMenu.Opened += new RoutedEventHandler(this.contextMenu_Opened);
			}
			if (this.dropDownBtn != null)
			{
				this.dropDownBtn.MouseDown += new MouseButtonEventHandler(this.dropDownBtn_MouseDown);
			}
			base.OnApplyTemplate();
		}

		private void dropDownBtn_MouseDown(object sender, MouseButtonEventArgs e)
		{
			e.Handled = true;
			this.IsDropDownPressed = !this.IsDropDownPressed;
		}

		private void contextMenu_Opened(object sender, RoutedEventArgs e)
		{
			this.contextMenu.Items.Clear();
			this.contextMenu.ItemTemplate = base.ItemTemplate;
			this.contextMenu.ItemTemplateSelector = base.ItemTemplateSelector;
			foreach (object current in ((IEnumerable)base.Items))
			{
				if (!(current is MenuItem) && !(current is Separator))
				{
					MenuItem menuItem = new MenuItem();
					menuItem.DataContext = current;
					BreadcrumbItem breadcrumbItem = current as BreadcrumbItem;
					if (breadcrumbItem == null)
					{
						BreadcrumbItem breadcrumbItem2 = base.TemplatedParent as BreadcrumbItem;
						if (breadcrumbItem2 != null)
						{
							breadcrumbItem = breadcrumbItem2.ContainerFromItem(current);
						}
					}
					if (breadcrumbItem != null)
					{
						menuItem.Header = breadcrumbItem.TraceValue;
					}
					menuItem.Icon = new Image
					{
						Source = ((breadcrumbItem != null) ? breadcrumbItem.Image : null),
						SnapsToDevicePixels = true,
						Stretch = Stretch.Fill,
						VerticalAlignment = VerticalAlignment.Center,
						HorizontalAlignment = HorizontalAlignment.Center,
						Width = 16.0,
						Height = 16.0
					};
					menuItem.Click += new RoutedEventHandler(this.item_Click);
					if (current != null && current.Equals(this.SelectedItem))
					{
						menuItem.FontWeight = FontWeights.Bold;
						menuItem.Background = Brushes.LightSkyBlue;
					}
					menuItem.ItemTemplate = base.ItemTemplate;
					menuItem.ItemTemplateSelector = base.ItemTemplateSelector;
					this.contextMenu.Items.Add(menuItem);
				}
				else
				{
					this.contextMenu.Items.Add(current);
				}
			}
			this.contextMenu.Placement = PlacementMode.Relative;
			this.contextMenu.PlacementTarget = this.dropDownBtn;
			this.contextMenu.VerticalOffset = this.dropDownBtn.ActualHeight;
		}

		private void item_Click(object sender, RoutedEventArgs e)
		{
			MenuItem menuItem = e.Source as MenuItem;
			object dataContext = menuItem.DataContext;
			this.RemoveSelectedItem(dataContext);
			this.SelectedItem = dataContext;
		}

		private void RemoveSelectedItem(object dataItem)
		{
			if (dataItem != null && dataItem.Equals(this.SelectedItem))
			{
				this.SelectedItem = null;
			}
		}

		private static void SelectedItemChangedEvent(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BreadcrumbButton breadcrumbButton = d as BreadcrumbButton;
			if (breadcrumbButton.IsInitialized)
			{
				RoutedEventArgs e2 = new RoutedEventArgs(BreadcrumbButton.SelectedItemChanged);
				breadcrumbButton.RaiseEvent(e2);
			}
		}

		protected override void OnMouseEnter(MouseEventArgs e)
		{
			this.isPressed = (e.LeftButton == MouseButtonState.Pressed);
			FrameworkElement frameworkElement = base.TemplatedParent as FrameworkElement;
			while (frameworkElement != null && !(frameworkElement is BreadcrumbBar))
			{
				frameworkElement = (VisualTreeHelper.GetParent(frameworkElement) as FrameworkElement);
			}
			BreadcrumbBar breadcrumbBar = frameworkElement as BreadcrumbBar;
			if (breadcrumbBar != null && breadcrumbBar.IsKeyboardFocusWithin)
			{
				base.Focus();
			}
			this.IsPressed = this.isPressed;
			base.OnMouseEnter(e);
		}

		private static void OverflowPressedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BreadcrumbButton breadcrumbButton = d as BreadcrumbButton;
			breadcrumbButton.OnOverflowPressedChanged();
		}

		protected virtual void OnOverflowPressedChanged()
		{
		}
	}
}
