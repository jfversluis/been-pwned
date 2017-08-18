using System.Threading.Tasks;
using System.Windows.Input;
using BeenPwned.Api.Models;
using BeenPwned.App.Core.Services;
using MvvmHelpers;
using Xamarin.Forms;

namespace BeenPwned.App.Core.PageModels
{
    public class MainPageModel : BasePageModel
    {
        public ObservableRangeCollection<Breach> Breaches { get; set; }
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
                    Breaches.Clear();
                    HasItems = false;
                    HasSearched = false;
                }
            }
        }

        private ICommand _openBreachCommand;
        public ICommand OpenBreachCommand => _openBreachCommand ?? (_openBreachCommand = new Command(async (item) => await OpenBreach(item), (arg) => !_isNavigating));

        private ICommand _checkPwnedCommand;
        public ICommand CheckPwnedCommand => _checkPwnedCommand ?? (_checkPwnedCommand = new Command(async (arg) => await CheckPwned(), (arg) => !_isNavigating));

        public MainPageModel()
        {
            Breaches = new ObservableRangeCollection<Breach>();
        }

        private async Task CheckPwned()
        {
            HasItems = false;
            HasSearched = false;
            IsLoading = true;

            var resultBreaches = await BeenPwnedService.Instance.GetBreachesForAccount(Filter);
            Breaches.ReplaceRange(resultBreaches);
            HasItems = Breaches.Count > 0;
            IsLoading = false;

            HasItems = false;
            HasSearched = true;
        }

        public async Task OpenBreach(object breach)
        {
            _isNavigating = true;

            await CoreMethods.PushPageModel<BreachPageModel>(breach, false, true);

            _isNavigating = false;
        }
    }
}