using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace SessionPresent.Tools.Converters
{
 

    public class TreeViewItemWidthConverter : MarkupExtension, IValueConverter
    {
        static TreeViewItemWidthConverter rowConverter;


        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            double b = (double)value;
            b = b - 65;

            if (b < 0)
                return 0;
            return b;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
          

            return 0;

        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (rowConverter == null)
                rowConverter = new TreeViewItemWidthConverter();

            return rowConverter;
        }

        public TreeViewItemWidthConverter()
        {

        }
    }

    public class ItemWidthConverter :  IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            return int.Parse(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return 0;

        }

    }


    public class TreeViewLineConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            TreeViewItem item = (TreeViewItem)value;
            ItemsControl ic = ItemsControl.ItemsControlFromItemContainer(item);
            return ic.ItemContainerGenerator.IndexFromContainer(item) == ic.Items.Count - 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return false;
        }
    }
}
