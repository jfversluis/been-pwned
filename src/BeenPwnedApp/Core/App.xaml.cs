﻿using Akavache;
using BeenPwned.App.Core.PageModels;
using BeenPwned.App.Helpers;
using FreshMvvm;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BeenPwned.App
{
    public partial class BeenPwnedApp : Application
    {
        public static BeenPwnedApp Instance;

        public BeenPwnedApp()
        {
            InitializeComponent();

            BlobCache.ApplicationName = "BeenPwned";

            Instance = this;

            if (!Settings.Current.SkippedTutorial)
            {
                var page = FreshPageModelResolver.ResolvePageModel<TutorialPageModel>();

                MainPage = new FreshNavigationContainer(page)
                {
                    BarTextColor = Color.White,
                    BarBackgroundColor = Color.FromHex("#3a9ac4"),
                };
            }
            else
            {
                SwitchToMainPage();
            }
        }

        public void SwitchToMainPage()
        {
            var tabbed = new FreshTabbedNavigationContainer();

            tabbed.AddTab<MainPageModel>("Been pwned?", "icon-pwned.png");
            tabbed.AddTab<BreachesPageModel>("Breaches", "icon-breaches.png");
            tabbed.AddTab<PasswordPageModel>("Passwords", "icon-password.png");

            MainPage = tabbed;
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}