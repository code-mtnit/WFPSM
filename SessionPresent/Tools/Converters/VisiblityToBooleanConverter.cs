using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;

namespace SessionPresent.Tools
{
    public class VisiblityToBooleanConverter : MarkupExtension, IValueConverter
    {
        static VisiblityToBooleanConverter rowConverter;


        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            bool b = (bool)value;

            if (b)
                return System.Windows.Visibility.Visible;
            else
                return System.Windows.Visibility.Collapsed;

            return value;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (((System.Windows.Visibility)value) == System.Windows.Visibility.Visible)
                    return true;
                else
                    return false;
            }
            catch
            {

            }

            return false;
            
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (rowConverter == null)
                rowConverter = new VisiblityToBooleanConverter();

            return rowConverter;
        }

        public VisiblityToBooleanConverter()
        {

        }
    }
}
