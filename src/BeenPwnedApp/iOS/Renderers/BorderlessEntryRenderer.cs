using System;
using BeenPwned.App.Core.Controls;
using BeenPwned.App.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessEntryRenderer))]
namespace BeenPwned.App.iOS.Renderers
{
    public class BorderlessEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BorderStyle = UITextBorderStyle.None;
                Control.Layer.BorderWidth = 0;

                // Sets the cursor and selectiond color.
                // Control.TintColor = ColorExtensions.FromResource("LightTextColor").ToUIColor();				
            }
        }
    }
}
