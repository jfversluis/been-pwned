using System;
using System.Windows.Input;
using Acr.UserDialogs;
using BeenPwned.App.Core.Interfaces;
using Xamarin.Forms;

namespace BeenPwned.App.Core.PageModels
{
    public class PushNotificationsPageModel : BasePageModel
    {
		private ICommand _togglePushNotificationsCommand;
        public ICommand TogglePushNotificationsCommand => _togglePushNotificationsCommand ?? (_togglePushNotificationsCommand = new Command(TogglePushNotifications));

        private IPushNotificationService _pushNotificationService;

        public PushNotificationsPageModel()
        {
            _pushNotificationService = DependencyService.Get<IPushNotificationService>();

            if (_pushNotificationService == null)
                UserDialogs.Instance.Alert("Error initializing push notification service.", "Error", "OK");
        }

        private void TogglePushNotifications()
        {
            _pushNotificationService.RegisterForPushNotifications();
        }
    }
}