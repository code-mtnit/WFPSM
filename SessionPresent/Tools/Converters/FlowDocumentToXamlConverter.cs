using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Markup;

namespace SessionPresent.Tools.Converters
{
    public class FlowDocumentToXamlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var fDocument = new FlowDocument();
            if (value != null)
            {
                string strDoc = (string) value;
                fDocument = XamlReader.Parse(strDoc) as FlowDocument;
            }

            return fDocument;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var flDocument = value as FlowDocument;
            if (flDocument == null)
                return string.Empty;

            return XamlWriter.Save(flDocument);
        }
    }
}
