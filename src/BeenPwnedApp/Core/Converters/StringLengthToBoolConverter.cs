using System;
using System.Globalization;
using Xamarin.Forms;

namespace BeenPwned.App.Core.Converters
{
    public class StringLengthToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var length = System.Convert.ToInt32(value);

            if (length > 0)
                return true;

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}