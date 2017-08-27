using Android.App;
using Android.OS;

namespace BeenPwned.App.Droid
{
	[Activity(Label = "been pwned?", Icon = "@drawable/icon", Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
	public class SplashscreenActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			StartActivity(typeof(MainActivity));
		}
	}
}