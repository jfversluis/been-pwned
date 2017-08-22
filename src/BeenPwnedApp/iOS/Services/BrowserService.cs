using BeenPwned.App.Core.Interfaces;
using BeenPwned.App.iOS.Services;
using Foundation;
using SafariServices;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: Dependency(typeof(BrowserService))]

namespace BeenPwned.App.iOS.Services
{
    public class BrowserService : IBrowserService
    {
        public void OpenUrl(string url)
        {
			if (UIDevice.CurrentDevice.CheckSystemVersion(9, 0))
			{
				using (var sfViewController = new SFSafariViewController(new NSUrl(url), false))
				{
                    sfViewController.PreferredBarTintColor = ((Color)BeenPwnedApp.Current.Resources["NavigationBackgroundColor"]).ToUIColor();
					UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(sfViewController, true, null);
				}
			}
			else
			{
				UIApplication.SharedApplication.OpenUrl(new NSUrl(url));
			}
        }
    }
}