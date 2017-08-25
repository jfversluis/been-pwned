using System;
using BeenPwned.App.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ListView), typeof(ColoredListViewIndexRenderer))]
namespace BeenPwned.App.iOS.Renderers
{
    public class ColoredListViewIndexRenderer : ListViewRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            var nativeTableView = Control as UITableView;

            var textColor = (Color)Xamarin.Forms.Application.Current.Resources["SectionIndexTextColor"];
            var backgroundColor = (Color)Xamarin.Forms.Application.Current.Resources["SectionIndexBackgroundColor"];

            nativeTableView.SectionIndexBackgroundColor = backgroundColor.ToUIColor();
            nativeTableView.SectionIndexColor = textColor.ToUIColor();
        }

    }
}
