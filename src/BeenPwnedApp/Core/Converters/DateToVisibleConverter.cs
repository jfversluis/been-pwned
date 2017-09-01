using System;
using System.Globalization;
using Xamarin.Forms;

namespace BeenPwned.App.Core.Converters
{
    public class DateToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var addedDate = value as DateTime?;

            if (addedDate == null)
                return false;

            return addedDate.Value.Date == DateTime.Now.Date;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}