using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BeenPwned.App.Core.PageModels
{
    public class SettingsPageModel : BasePageModel
    {
		private ICommand _openUrlCommand;
		public ICommand OpenUrlCommand => _openUrlCommand ?? (_openUrlCommand = new Command<string>(async (url) => await OpenUrl(url), (arg) => !_isNavigating));

		private ICommand _openPushSettingsCommand;
		public ICommand OpenPushSettingsCommand => _openPushSettingsCommand ?? (_openPushSettingsCommand = new Command<string>(async (o) => await OpenPushSettings(), (arg) => !_isNavigating));

        private async Task OpenUrl(string url)
        {
            // TODO implement with IBrowserService from other branch
            Device.OpenUri(new Uri(url));
        }

        private async Task OpenPushSettings()
        {
            _isNavigating = true;

            await CoreMethods.PushPageModel<PushNotificationsPageModel>();

            _isNavigating = false;
        }
	}
}