using BeenPwned.App.Core.Interfaces;
using BeenPwned.App.iOS.Services;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(PushNotificationService))]

namespace BeenPwned.App.iOS.Services
{
    public class PushNotificationService : IPushNotificationService
    {
		public void RegisterForPushNotifications()
		{
			var settings = UIUserNotificationSettings.GetSettingsForTypes(
				UIUserNotificationType.Alert
				| UIUserNotificationType.Badge
				| UIUserNotificationType.Sound,
				new NSSet());

			UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
			UIApplication.SharedApplication.RegisterForRemoteNotifications();
		}
    }
}