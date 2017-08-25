using System.ComponentModel;
using System.Runtime.CompilerServices;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace BeenPwned.App.Helpers
{
    public class Settings : INotifyPropertyChanged
    {
        static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

		static Settings settings;

		public static Settings Current
		{
			get { return settings ?? (settings = new Settings()); }
		}

        #region Setting Constants

        private const string SkippedTutorialKey = "skippedTutorial";
        private static readonly bool SkippedTutorialDefault = false;

		private const string IsPushEnabledKey = "pushEnabled";
		private static readonly bool IsPushEnabledDefault = false;

		private const string IsPushEnabledAttemptedKey = "pushEnabledAttempted";
		private static readonly bool IsPushEnabledAttemptedDefault = false;

        public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([CallerMemberName]string name = "") =>
		    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        #endregion

        public bool SkippedTutorial
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

		public bool IsPushEnabled
		{
			get
			{
				return AppSettings.GetValueOrDefault(IsPushEnabledKey, IsPushEnabledDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(IsPushEnabledKey, value);
                OnPropertyChanged();
			}
		}

		public bool IsPushEnableAttempted
		{
			get
			{
				return AppSettings.GetValueOrDefault(IsPushEnabledAttemptedKey, IsPushEnabledAttemptedDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(IsPushEnabledAttemptedKey, value);
			}
		}
    }
}