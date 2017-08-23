using System;
using System.ComponentModel;
using BeenPwned.App.iOS.Renderers;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SearchBar), typeof(SimpleSearchBarRenderer))]
namespace BeenPwned.App.iOS.Renderers
{
    public class SimpleSearchBarRenderer : SearchBarRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //Override needed, otherwise the original Xamarin code will force show the Cancel button on the right side of the entry field
            if (e.PropertyName == SearchBar.TextProperty.PropertyName)
            {
                Control.Text = Element.Text;
            }

            if (e.PropertyName != SearchBar.CancelButtonColorProperty.PropertyName && e.PropertyName != SearchBar.TextProperty.PropertyName)
                base.OnElementPropertyChanged(sender, e);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.SearchBar> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            var searchBar = e.NewElement;

            Control.AutocapitalizationType = UITextAutocapitalizationType.None;
            Control.AutocorrectionType = UITextAutocorrectionType.No;
            Control.SearchBarStyle = UISearchBarStyle.Minimal;

            // Handles the cursor color
            Control.TintColor = UIColor.White;

            // Handles customizing the search icon.
            var searchImage = UIImage.FromBundle("icon-search.png").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
            Control.SetImageforSearchBarIcon(searchImage, UISearchBarIcon.Search, UIControlState.Normal);

            // Handles customizing the clear icon.
            var searchTextField = Control.ValueForKey(new NSString("_searchField")) as UITextField;
            var clearButton = searchTextField.ValueForKey(new NSString("_clearButton")) as UIButton;
            var newClearImage = clearButton.ImageView?.Image?.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
            Control.SetImageforSearchBarIcon(newClearImage, UISearchBarIcon.Clear, UIControlState.Normal);

            // Styles the placeholder and the cursor
            var textfieldAppearance = UITextField.AppearanceWhenContainedIn(typeof(UISearchBar));
            textfieldAppearance.TintColor = UIColor.White;

            // Styles the placeholder text
            UILabel.AppearanceWhenContainedIn(typeof(UISearchBar)).TextColor = UIColor.White;
        }
    }
}
