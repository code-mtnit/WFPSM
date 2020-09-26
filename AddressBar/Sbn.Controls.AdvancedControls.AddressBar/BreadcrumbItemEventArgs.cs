using System;
using System.Windows;

namespace Sbn.Controls.AdvancedControls.AddressBar
{
	public class BreadcrumbItemEventArgs : RoutedEventArgs
	{
		public BreadcrumbItem Item
		{
			get;
			private set;
		}

		public BreadcrumbItemEventArgs(BreadcrumbItem item, RoutedEvent routedEvent) : base(routedEvent)
		{
			this.Item = item;
		}
	}
}
