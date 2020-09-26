using System;
using System.Windows;

namespace Sbn.Controls.AdvancedControls.AddressBar
{
	public class PathConversionEventArgs : RoutedEventArgs
	{
		public enum ConversionMode
		{
			DisplayToEdit,
			EditToDisplay
		}

		public string DisplayPath
		{
			get;
			set;
		}

		public string EditPath
		{
			get;
			set;
		}

		public PathConversionEventArgs.ConversionMode Mode
		{
			get;
			private set;
		}

		public object Root
		{
			get;
			private set;
		}

		public PathConversionEventArgs(PathConversionEventArgs.ConversionMode mode, string path, object root, RoutedEvent routedEvent) : base(routedEvent)
		{
			this.Mode = mode;
			this.EditPath = path;
			this.DisplayPath = path;
			this.Root = root;
		}
	}
}
