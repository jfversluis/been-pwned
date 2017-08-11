using Foundation;
using UIKit;
using Xamarin.Forms;

namespace BeenPwned.App.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();

            LoadApplication(new BeenPwnedApp());

            return base.FinishedLaunching(app, options);
        }
    }
}