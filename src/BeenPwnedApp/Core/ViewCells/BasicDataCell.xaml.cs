using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BeenPwned.App.Core.ViewCells
{
    public partial class BasicDataCell : ViewCell
    {

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(BasicDataCell), defaultBindingMode: BindingMode.TwoWay, defaultValue: string.Empty, propertyChanging: (bindable, oldValue, newValue) =>
             {
                 var ctrl = (BasicDataCell)bindable;
                 ctrl.Text = newValue?.ToString();
             });

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set
            {
                SetValue(TextProperty, value);
                TextLabel.Text = value;
            }
        }

        public static readonly BindableProperty LabelProperty =
            BindableProperty.Create(nameof(Label), typeof(string), typeof(BasicDataCell), defaultBindingMode: BindingMode.TwoWay, defaultValue: string.Empty, propertyChanging: (bindable, oldValue, newValue) =>
             {
                 var ctrl = (BasicDataCell)bindable;
                 ctrl.Label = (string)newValue;
             });

        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set
            {
                SetValue(LabelProperty, value);
                DescriptionLabel.Text = value;
            }
        }

        public BasicDataCell()
        {
            InitializeComponent();
        }
    }
}
