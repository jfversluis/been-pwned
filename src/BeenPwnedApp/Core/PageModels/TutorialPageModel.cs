using System.Collections.Generic;
using System.Windows.Input;
using BeenPwned.App.Helpers;
using FreshMvvm;
using Xamarin.Forms;

namespace BeenPwned.App.Core.PageModels
{
    public class TutorialPageModel : FreshBasePageModel
    {
        public List<TutorialItem> Items { get; set; }

        public ICommand SkipTutorialCommand => new Command((item) => SkipTutorial());

        public TutorialPageModel()
        {
            // TODO: Replace the images with Lottie animations
            // Won't work for now due to a bug in Lottie: https://github.com/martijn00/LottieXamarin/issues/91
            Items = new List<TutorialItem>() {
                new TutorialItem(){
                    Title="Welcome to HIBP",
                    SubTitle="All of the awesome HIBP functionality within the reach of your thumb.",
                    ImageUrl="logo.png"
                },
                new TutorialItem(){
                    Title="Have you been pwned?",
                    SubTitle="Check if you have an account that has been compromised in a data breach.",
                    ImageUrl="pwned.png"
                },
                new TutorialItem(){
                    Title="Verify safe passwords",
                    SubTitle="Hundreds of millions of real world passwords exposed in data breaches searchable.",
                    ImageUrl="passwords.png"
                },
                new TutorialItem(){
                    Title="View data breaches",
                    SubTitle="Breached websites that have been loaded into this service.",
                    ImageUrl="breaches.png"
                }
            };
        }

        void SkipTutorial()
        {
            // User wants to skip the tutorial, so we save that to our settings.
            // Next time he won't be shown the tutorial anymore.
            Settings.SkippedTutorial = true;

            BeenPwnedApp.Instance.SwitchToMainPage();
        }
    }

    public class TutorialItem
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
    }
}
