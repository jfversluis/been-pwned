using CarouselView.FormsPlugin.iOS;
using FFImageLoading.Forms.Touch;
using Foundation;
using Lottie.Forms.iOS.Renderers;
using StoreKit;
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

            // TODO dummy to prevent the dll being trashed by the linker.
            // Should be a better solution...
            var foo = new FFImageLoading.Svg.Forms.SvgCachedImage();

            UIApplication.SharedApplication.SetStatusBarHidden(false, false);
            LoadApplication(new BeenPwnedApp());

            UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);

#if !DEBUG
            // Periodically let the app ask for a review
            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 3))
                SKStoreReviewController.RequestReview();
#endif

            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}