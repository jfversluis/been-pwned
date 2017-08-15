using System;
using System.Threading.Tasks;
using System.Windows.Input;
using BeenPwned.App.Core.Services;
using Xamarin.Forms;

namespace BeenPwned.App.Core.PageModels
{
    public class MainPageModel : BasePageModel
    {
        public string Account { get; set; }

        private ICommand _checkPwnedCommand;
		public ICommand CheckPwnedCommand => _checkPwnedCommand ?? (_checkPwnedCommand = new Command<string>(async (account) => await CheckPwned(account), (arg) => !_isNavigating));

        private async Task CheckPwned(string account)
        {
            var resultBreaches = await BeenPwnedService.Instance.GetBreachesForAccount(account);
        }
    }
}