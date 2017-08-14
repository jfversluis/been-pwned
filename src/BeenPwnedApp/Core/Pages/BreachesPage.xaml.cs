using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FFImageLoading;
using FFImageLoading.Forms;
using Xamarin.Forms;

namespace BeenPwned.App.Core.Pages
{
    public partial class BreachesPage : ContentPage
    {
        public BreachesPage()
        {
            InitializeComponent();
        }

        void Handle_Success(object sender, FFImageLoading.Forms.CachedImageEvents.SuccessEventArgs e)
        {
            //    var image = sender as CachedImage;
            //    var bytes = image.GetImageAsPngAsync();

            //    // If it is not grayscale we can skip the transformations.
            //    if (!IsGrayScale(bytes))
            //        image.Transformations.Clear();
            //}

            //private static bool IsGrayScale(byte[] image)
            //{
            //var bitmap =

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            BreachesList.SelectedItem = null;
        }
    }
}
