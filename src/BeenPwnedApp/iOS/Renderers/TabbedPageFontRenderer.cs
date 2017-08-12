using System;
using BeenPwned.App.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(TabbedPageFontRenderer))]
namespace BeenPwned.App.iOS.Renderers
{
    public class TabbedPageFontRenderer : TabbedRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            UITabBar.Appearance.SelectedImageTintColor = UIColor.FromRGB(46, 130, 167);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (TabBar.Items != null)
            {
                var items = TabBar.Items;

                foreach (var t in items)
                {
                    var txtFont = new UITextAttributes()
                    {
                        Font = UIFont.FromName("Ubuntu-Regular", 10)
                    };

                    t.SetTitleTextAttributes(txtFont, UIControlState.Normal);
                }
            }
        }
    }
}
