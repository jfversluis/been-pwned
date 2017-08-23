using System;
using System.Threading.Tasks;
using System.Windows.Input;
using BeenPwned.App.Core.Interfaces;
using Xamarin.Forms;

namespace BeenPwned.App.Core.PageModels
{
    public class SettingsPageModel : BasePageModel
    {
		private ICommand _openUrlCommand;
		public ICommand OpenUrlCommand => _openUrlCommand ?? (_openUrlCommand = new Command<string>((url) => OpenUrl(url), (arg) => !_isNavigating));

		private ICommand _openPushSettingsCommand;
		public ICommand OpenPushSettingsCommand => _openPushSettingsCommand ?? (_openPushSettingsCommand = new Command<string>(async (o) => await OpenPushSettings(), (arg) => !_isNavigating));

        private void OpenUrl(string url)
        {
			if (Device.RuntimePlatform != Device.iOS)
				Device.OpenUri(new Uri(url));
			else
				DependencyService.Get<IBrowserService>()?.OpenUrl(url);
        }

        private async Task OpenPushSettings()
        {
            _isNavigating = true;

            await CoreMethods.PushPageModel<PushNotificationsPageModel>();

            _isNavigating = false;
        }
	}
}