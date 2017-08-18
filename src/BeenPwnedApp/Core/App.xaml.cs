using Akavache;
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

            if (!Settings.SkippedTutorial)
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

            tabbed.AddTab<MainPageModel>("Been pwned?", Device.RuntimePlatform == Device.iOS ? "icon-pwned.png" : null);
            tabbed.AddTab<BreachesPageModel>("Breaches", Device.RuntimePlatform == Device.iOS ? "icon-breaches.png" : null);
            tabbed.AddTab<PasswordPageModel>("Passwords", Device.RuntimePlatform == Device.iOS ? "icon-password.png" : null);

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