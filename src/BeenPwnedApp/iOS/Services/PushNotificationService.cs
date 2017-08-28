using BeenPwned.App.Core.Interfaces;
using BeenPwned.App.Helpers;
using BeenPwned.App.iOS.Services;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(PushNotificationService))]

namespace BeenPwned.App.iOS.Services
{
    public class PushNotificationService : IPushNotificationService
    {
		public bool IsRegistered
		{
			get
			{
				return UIApplication.SharedApplication.IsRegisteredForRemoteNotifications &&
					UIApplication.SharedApplication.CurrentUserNotificationSettings.Types != UIUserNotificationType.None;
			}
		}

		public void RegisterForPushNotifications()
		{
			Settings.Current.IsPushEnabled = true;
            Settings.Current.IsPushEnableAttempted = true;

			var settings = UIUserNotificationSettings.GetSettingsForTypes(
				UIUserNotificationType.Alert
				| UIUserNotificationType.Badge
				| UIUserNotificationType.Sound,
				new NSSet());

			UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
			UIApplication.SharedApplication.RegisterForRemoteNotifications();
		}

		public void OpenSettings()
		{
			UIApplication.SharedApplication.OpenUrl(new NSUrl(UIApplication.OpenSettingsUrlString));
		}
    }
}