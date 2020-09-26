using System;
using System.Windows;
using System.Windows.Media;

namespace Sbn.Controls.AdvancedControls.AddressBar
{
	public class ApplyPropertiesEventArgs : RoutedEventArgs
	{
		public BreadcrumbItem Breadcrumb
		{
			get;
			private set;
		}

		public object Item
		{
			get;
			private set;
		}

		public ImageSource Image
		{
			get;
			set;
		}

		public double FontSize
		{
			get;
			set;
		}

		public object Trace
		{
			get;
			set;
		}

		public string TraceValue
		{
			get;
			set;
		}

		public ApplyPropertiesEventArgs(object item, BreadcrumbItem breadcrumb, RoutedEvent routedEvent) : base(routedEvent)
		{
			this.Item = item;
			this.Breadcrumb = breadcrumb;
		}
	}
}
