using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Sbn.Controls.AdvancedControls.AddressBar
{
	public class AeroChrome : ContentControl
	{
		public static readonly DependencyProperty RenderPressedProperty;

		public static readonly DependencyProperty RenderMouseOverProperty;

		public static readonly DependencyProperty MouseOverBackgroundProperty;

		public static readonly DependencyProperty MousePressedBackgroundProperty;

		public bool RenderPressed
		{
			get
			{
				return (bool)base.GetValue(AeroChrome.RenderPressedProperty);
			}
			set
			{
				base.SetValue(AeroChrome.RenderPressedProperty, value);
			}
		}

		public bool RenderMouseOver
		{
			get
			{
				return (bool)base.GetValue(AeroChrome.RenderMouseOverProperty);
			}
			set
			{
				base.SetValue(AeroChrome.RenderMouseOverProperty, value);
			}
		}

		public Brush MouseOverBackground
		{
			get
			{
				return (Brush)base.GetValue(AeroChrome.MouseOverBackgroundProperty);
			}
			set
			{
				base.SetValue(AeroChrome.MouseOverBackgroundProperty, value);
			}
		}

		public Brush MousePressedBackground
		{
			get
			{
				return (Brush)base.GetValue(AeroChrome.MousePressedBackgroundProperty);
			}
			set
			{
				base.SetValue(AeroChrome.MousePressedBackgroundProperty, value);
			}
		}

		static AeroChrome()
		{
			AeroChrome.RenderPressedProperty = DependencyProperty.Register("RenderPressed", typeof(bool), typeof(AeroChrome), new UIPropertyMetadata(false));
			AeroChrome.RenderMouseOverProperty = DependencyProperty.Register("RenderMouseOver", typeof(bool), typeof(AeroChrome), new UIPropertyMetadata(false));
			AeroChrome.MouseOverBackgroundProperty = DependencyProperty.Register("MouseOverBackground", typeof(Brush), typeof(AeroChrome), new UIPropertyMetadata(null));
			AeroChrome.MousePressedBackgroundProperty = DependencyProperty.Register("MousePressedBackground", typeof(Brush), typeof(AeroChrome), new UIPropertyMetadata(null));
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(AeroChrome), new FrameworkPropertyMetadata(typeof(AeroChrome)));
		}
	}
}
