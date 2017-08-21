using BeenPwned.App.Core.Controls;
using BeenPwned.App.iOS.Renderers;
using Foundation;
using SafariServices;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedWebView), typeof(ExtendedWebViewRenderer))]
namespace BeenPwned.App.iOS.Renderers
{
    public class ExtendedWebViewRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            // Bugfix to get rid of the black line at the bottom.
            Opaque = false;
            BackgroundColor = UIColor.Clear;

            ScrollView.ScrollEnabled = false;
            ScrollView.Bounces = false;

            Delegate = new ExtendedUIWebViewDelegate(this);
        }
    }

    public class ExtendedUIWebViewDelegate : UIWebViewDelegate
    {
        ExtendedWebViewRenderer webViewRenderer;

        public ExtendedUIWebViewDelegate(ExtendedWebViewRenderer _webViewRenderer = null)
        {
            webViewRenderer = _webViewRenderer ?? new ExtendedWebViewRenderer();
        }

        public override bool ShouldStartLoad(UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType)
        {
            if (navigationType == UIWebViewNavigationType.LinkClicked)
            {
                
				if (UIDevice.CurrentDevice.CheckSystemVersion(9, 0))
				{
                    using (var sfViewController = new SFSafariViewController(request.Url, false))
                    {
                        try
                        {
                            sfViewController.PreferredBarTintColor = ((Color)BeenPwnedApp.Current.Resources["NavigationBackgroundColor"]).ToUIColor();
                        }
                        catch { } // Intentionally left blank, no worries if the color cannot be set

						UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(sfViewController, true, null);
					}
				}
				else
				{
                    UIApplication.SharedApplication.OpenUrl(request.Url);
				}
                return false;
            }

            return true;
        }

        public override async void LoadingFinished(UIWebView webView)
        {
            // TODO: Find out why this doesn't work as it should.
            var wv = webViewRenderer.Element as ExtendedWebView;
            if (wv != null)
            {
                await System.Threading.Tasks.Task.Delay(100); // wait here till content is rendered
                wv.HeightRequest = (double)webView.ScrollView.ContentSize.Height;
            }
        }
    }
}