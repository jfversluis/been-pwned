using System;
using CarouselView.FormsPlugin.iOS;
using FFImageLoading.Forms.Touch;
using Foundation;
using Lottie.Forms.iOS.Renderers;
using StoreKit;
using UIKit;
using WindowsAzure.Messaging;
using Xamarin.Forms;

namespace BeenPwned.App.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
		private SBNotificationHub _hub { get; set; }

		public const string ConnectionString = "Endpoint=sb://beenpwnedhub-ns.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=4w0mdntJjCkg+2miI3LnaHhZsifBQsXvm8wnjOu7jcg=";
		public const string NotificationHubPath = "beenpwnedhub";

		public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            Forms.Init();

            CarouselViewRenderer.Init();
            AnimationViewRenderer.Init();
            CachedImageRenderer.Init();

            // TODO dummy to prevent the dll being trashed by the linker.
            // Should be a better solution...
            var foo = new FFImageLoading.Svg.Forms.SvgCachedImage();

            UIApplication.SharedApplication.SetStatusBarHidden(false, false);
            LoadApplication(new BeenPwnedApp());

            UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);

            // Periodically let the app ask for a review
			if (UIDevice.CurrentDevice.CheckSystemVersion(10, 3))
				SKStoreReviewController.RequestReview();
            
            return base.FinishedLaunching(uiApplication, launchOptions);
        }

		public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
		{
			// Create a new notification hub with the connection string and hub path
			_hub = new SBNotificationHub(ConnectionString, NotificationHubPath);

			// Unregister any previous instances using the device token
			_hub.UnregisterAllAsync(deviceToken, (error) =>
			{
				if (error != null)
				{
					// Error unregistering
                    Console.WriteLine($"Error: {error.Description}");
					return;
				}

				// Register this device with the notification hub
                _hub.RegisterNativeAsync(deviceToken, null, (registerError) =>
				{
					if (registerError != null)
					{
                        // Error registering
                        Console.WriteLine($"Error: {error.Description}");
					}
				});
			});
		}
    }
}