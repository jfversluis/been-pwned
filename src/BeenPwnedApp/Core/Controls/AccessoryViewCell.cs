
using System;
using Xamarin.Forms;

namespace BeenPwned.App.Core.Controls
{
    public class AccessoryViewCell : ViewCell
    {
        public static readonly BindableProperty AccessoryProperty = BindableProperty.Create(
           propertyName: nameof(Accessory),
           returnType: typeof(string),
           declaringType: typeof(AccessoryViewCell),
           defaultValue: "",
           defaultBindingMode: BindingMode.TwoWay,
           propertyChanged: HandleAccessoryChanged
       );

        static void HandleAccessoryChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (AccessoryViewCell)bindable;
            view.Accessory = (string)newValue;
        }

        public string Accessory
        {
            get { return (string)GetValue(AccessoryProperty); }
            set { SetValue(AccessoryProperty, value); }
        }
    }
}
