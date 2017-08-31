using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using BeenPwned.App.Core.Interfaces;
using BeenPwned.App.Helpers;
using Xamarin.Forms;

namespace BeenPwned.App.Core.PageModels
{
    public class PushNotificationsPageModel : BasePageModel
    {
        public string PushStatusButton { get; set; }

		private ICommand _enablePushNotificationsCommand;
        public ICommand EnablePushNotificationsCommand => _enablePushNotificationsCommand ?? (_enablePushNotificationsCommand = new Command(async () => await EnablePushNotifications()));

        private IPushNotificationService _pushNotificationService;

        public PushNotificationsPageModel()
        {
            _pushNotificationService = DependencyService.Get<IPushNotificationService>();

            if (_pushNotificationService == null)
                UserDialogs.Instance.Alert("Error initializing push notification service.", "Error", "OK");
        }

        public override void Init(object initData)
        {
            base.Init(initData);

            UpdateItems();

            Settings.Current.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(Settings.IsPushEnabled))
                    UpdateItems();
            };
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

            UpdateItems();
        }

        private void UpdateItems()
        {
            PushStatusButton = Settings.Current.IsPushEnabled ? "Push notifications enabled" : "Enable push notifications";
        }

        private async Task EnablePushNotifications()
        {
            if (_pushNotificationService.IsRegistered)
                return;

            if (!_pushNotificationService.IsRegistered && Settings.Current.IsPushEnableAttempted)
            {
                if (await UserDialogs.Instance.ConfirmAsync("To enable push notifications, please go into Settings, Tap Notifications, and set Allow Notifications to on.",
                                                            "Enable push notifications", "Go to Settings", "Not now"))
                {
                    _pushNotificationService.OpenSettings();
                }

                return;
            }

            _pushNotificationService.RegisterForPushNotifications();
        }
    }
}