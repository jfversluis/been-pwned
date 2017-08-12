using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BeenPwned.App.Core.ViewCells
{
    public partial class CheckMarkCell : ViewCell
    {
        public static readonly BindableProperty CheckedProperty =
            BindableProperty.Create(nameof(Checked), typeof(bool), typeof(CheckMarkCell), defaultBindingMode: BindingMode.TwoWay, defaultValue: false, propertyChanging: (bindable, oldValue, newValue) =>
             {
                 var ctrl = (CheckMarkCell)bindable;
                 ctrl.Checked = (bool)newValue;
             });

        public bool Checked
        {
            get { return (bool)GetValue(CheckedProperty); }
            set
            {
                SetValue(CheckedProperty, value);
                CheckImage.Source = value ? "check.png" : "nocheck.png";
            }
        }

        public static readonly BindableProperty LabelProperty =
            BindableProperty.Create(nameof(Label), typeof(string), typeof(CheckMarkCell), defaultBindingMode: BindingMode.TwoWay, defaultValue: string.Empty, propertyChanging: (bindable, oldValue, newValue) =>
             {
                 var ctrl = (CheckMarkCell)bindable;
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

        public CheckMarkCell()
        {
            InitializeComponent();
        }
    }
}
