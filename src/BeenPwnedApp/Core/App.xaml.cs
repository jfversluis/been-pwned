using Xamarin.Forms;

namespace BeenPwned.App
{
    public partial class BeenPwnedApp : Application
    {
        public BeenPwnedApp()
        {
            InitializeComponent();

            MainPage = new MainPage();
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