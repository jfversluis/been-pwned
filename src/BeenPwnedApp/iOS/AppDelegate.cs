using CarouselView.FormsPlugin.iOS;
using FFImageLoading.Forms.Touch;
using Foundation;
using Lottie.Forms.iOS.Renderers;
using UIKit;
using Xamarin.Forms;

namespace BeenPwned.App.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            Forms.Init();

            CarouselViewRenderer.Init();
            AnimationViewRenderer.Init();
            CachedImageRenderer.Init();

            UIApplication.SharedApplication.SetStatusBarHidden(false, false);

            LoadApplication(new BeenPwnedApp());

            UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);

            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}