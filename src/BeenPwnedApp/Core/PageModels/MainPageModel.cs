using System;
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
        public ObservableRangeCollection<Breach> Breaches { get; set; } = new ObservableRangeCollection<Breach>();
        public ObservableRangeCollection<Paste> Pastes { get; set; } = new ObservableRangeCollection<Paste>();

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

        public string BreachedDescription { get; set; }

        private async Task CheckPwned()
        {
            HasItems = false;
            HasSearched = false;
            IsLoading = true;

            var resultBreaches = await BeenPwnedService.Instance.GetBreachesForAccount(Filter);
            Breaches.ReplaceRange(resultBreaches);

            try
            {
                var resultPastes = await BeenPwnedService.Instance.GetPastesForAccount(Filter);
                Pastes.ReplaceRange(resultPastes);
            }
            catch(ArgumentException)
            {
                // If the given acount is not a (valid) e-mailaddress an ArgumentException will be thrown
                Pastes.Clear();
            }

            HasItems = Breaches.Count > 0 || Pastes.Count > 0;
            BreachedDescription = $"Pwned on {Breaches.Count} breached site(s) and found {Pastes.Count} paste(s).";

            IsLoading = false;
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