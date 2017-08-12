using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace BeenPwned.App.Helpers
{
    public static class Settings
    {
        static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        const string SkippedTutorialKey = "skippedTutorial";
        static readonly bool SkippedTutorialDefault = false;

        #endregion


        public static bool SkippedTutorial
        {
            get
            {
                return AppSettings.GetValueOrDefault(SkippedTutorialKey, SkippedTutorialDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SkippedTutorialKey, value);
            }
        }

    }
}
