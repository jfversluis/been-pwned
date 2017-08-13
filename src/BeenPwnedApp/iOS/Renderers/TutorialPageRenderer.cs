using System;
using BeenPwned.App.Core.Controls;
using BeenPwned.App.Core.iOS.Extensions;
using BeenPwned.App.Core.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TutorialBasePage), typeof(TutorialPageRenderer))]
namespace BeenPwned.App.Core.iOS.Renderers
{
    public class TutorialPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes
            {
                Font = UIFont.FromName("Ubuntu-Bold", 18),
                TextColor = UIColor.White
            });

            var textAttributes = new UITextAttributes()
            {
                TextColor = Color.White.ToUIColor(),
                Font = UIFont.FromName("Ubuntu-Regular", 16)
            };

            UIBarButtonItem.Appearance.SetTitleTextAttributes(textAttributes, UIControlState.Normal);
            UIBarButtonItem.Appearance.SetTitleTextAttributes(textAttributes, UIControlState.Highlighted);

            var color = (Color)Xamarin.Forms.Application.Current.Resources["TutorialNavigationBackgroundColor"];

            UINavigationBar.Appearance.SetBackgroundImage(color.ToUIColor().ToUIImage(), UIBarMetrics.Default);
            UINavigationBar.Appearance.BarTintColor = color.ToUIColor();
            UINavigationBar.Appearance.TintColor = UIColor.White;
            UINavigationBar.Appearance.BackgroundColor = color.ToUIColor();
            UINavigationBar.Appearance.ShadowImage = color.ToUIColor().ToUIImage();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            ModalPresentationCapturesStatusBarAppearance = true;
            UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);
        }
    }
}