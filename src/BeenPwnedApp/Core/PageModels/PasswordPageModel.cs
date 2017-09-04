using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using BeenPwned.App.Core.Services;
using Plugin.Connectivity;
using PropertyChanged;
using Xamarin.Forms;

namespace BeenPwned.App.Core.PageModels
{
    public class PasswordPageModel : BasePageModel
    {
        [AlsoNotifyFor(nameof(IsPwned), nameof(IsNotPwned))]
		public bool HasSearched { get; set; }

        [AlsoNotifyFor(nameof(IsNotPwned))]
        public bool IsPwned { get; set; }
        public bool IsNotPwned => !IsPwned && HasSearched;

		private string _filter;

		public string Filter
		{
			get { return _filter; }
			set
			{
				_filter = value;

				if (string.IsNullOrEmpty(_filter))
				{
                    IsPwned = false;
					HasSearched = false;
				}
			}
		}

		private ICommand _checkPwnedCommand;
		public ICommand SearchCommand => _checkPwnedCommand ?? (_checkPwnedCommand = new Command(async (arg) => await Search()));


		private async Task Search()
		{
            if (string.IsNullOrWhiteSpace(Filter))
            {
                await UserDialogs.Instance.AlertAsync("You need to enter a password", "No password entered", "OK");
                return;    
            }

            if (!CrossConnectivity.Current.IsConnected)
            {
                await UserDialogs.Instance.AlertAsync("It seems you have no active internet connection. Please verify that you have and try again.",
                                               "No internet", "OK");

                return;
            }

            IsPwned = false;
			HasSearched = false;
			IsLoading = true;

            IsPwned = await BeenPwnedService.Instance.GetIsPasswordPwned(Filter);

            IsLoading = false;
    		HasSearched = true;
		}
    }
}