using System;
using System.Globalization;
using Xamarin.Forms;

namespace BeenPwned.App.Core.Converters
{
    public class HtmlToSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                var htmlSource = new HtmlWebViewSource();
                htmlSource.Html = "<style type=\"text/css\">" +
                    "@font-face { font-family: Ubuntu; src: url('Fonts/Ubuntu-Regular.ttf') }" +
                    "body { font-family: Ubuntu; font-size: 14px; }" +
                "</style>" + value;
                return htmlSource;
            }

            return new HtmlWebViewSource();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
