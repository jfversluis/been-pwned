using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using BeenPwned.App.Core.Services;
using Xamarin.Forms;

namespace BeenPwned.App.Core.PageModels
{
    public class PasswordPageModel : BasePageModel
    {
		public bool HasItems { get; set; }
		public bool HasSearched { get; set; }

		private string _filter;

		public string Filter
		{
			get { return _filter; }
			set
			{
				_filter = value;

				if (string.IsNullOrEmpty(_filter))
				{
					HasItems = false;
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

			HasItems = false;
			HasSearched = false;
			IsLoading = true;

            HasItems = await BeenPwnedService.Instance.GetIsPasswordPwned(Filter);

            IsLoading = false;
    		HasSearched = true;
		}
    }
}