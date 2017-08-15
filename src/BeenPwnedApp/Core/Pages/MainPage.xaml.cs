using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BeenPwned.App.Core.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            BreachesList.SelectedItem = null;
        }
    }
}
