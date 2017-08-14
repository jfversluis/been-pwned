using System;
using System.Globalization;
using BeenPwned.Api.Models;
using BeenPwned.App.Core.Helpers;
using FFImageLoading.Svg.Forms;
using Xamarin.Forms;

namespace BeenPwned.App.Core.Converters
{
    public class BreachToImageUrlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
			if (value is Breach)
			{
				var breach = value as Breach;

				if (breach.LogoType.ToLowerInvariant() == "svg")
					return SvgImageSource.FromUri(new Uri($"{Constants.HibpBaseImageUrl}{breach.Name}.{breach.LogoType}"));
				else
					return ImageSource.FromUri(new Uri($"{Constants.HibpBaseImageUrl}{breach.Name}.{breach.LogoType}"));
			}

			return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}