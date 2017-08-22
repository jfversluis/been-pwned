using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using BeenPwned.Api.Models;
using BeenPwned.App.Core.Models;
using BeenPwned.App.Core.Services;
using MvvmHelpers;
using Xamarin.Forms;

namespace BeenPwned.App.Core.PageModels
{
    public class MainPageModel : BasePageModel
    {
        public ObservableRangeCollection<SearchListGroup> BreachesAndPastes { get; set; } = new ObservableRangeCollection<SearchListGroup>();

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
                    BreachesAndPastes.Clear();
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

        public MainPageModel()
        {
			BreachesAndPastes.Add(new SearchListGroup("Breaches"));
			BreachesAndPastes.Add(new SearchListGroup("Pastes"));
        }

        public async Task OpenBreach(object breachOrPaste)
		{
			_isNavigating = true;

            if (breachOrPaste is Breach)
			    await CoreMethods.PushPageModel<BreachPageModel>(breachOrPaste, false, true);
            else if (breachOrPaste is Paste)
				await CoreMethods.PushPageModel<PastePageModel>(breachOrPaste, false, true);

			_isNavigating = false;
		}

        private async Task CheckPwned()
        {
            HasItems = false;
            HasSearched = false;
            IsLoading = true;

            var resultBreaches = await BeenPwnedService.Instance.GetBreachesForAccount(Filter);
            BreachesAndPastes.Single(b => b.Name == "Breaches").ReplaceRange(resultBreaches);

            IEnumerable<Paste> resultPastes = null;

            try
            {
                resultPastes = await BeenPwnedService.Instance.GetPastesForAccount(Filter);
                BreachesAndPastes.Single(b => b.Name == "Pastes").ReplaceRange(resultPastes);
            }
            catch (ArgumentException)
            {
                // If the given acount is not a (valid) e-mailaddress an ArgumentException will be thrown
                BreachesAndPastes.Single(b => b.Name == "Pastes").Clear();
            }

            HasItems = BreachesAndPastes.Count > 0;
            BreachedDescription = $"Pwned on {resultBreaches.Count()} breached site(s) and found {resultPastes?.Count()} paste(s).";

            IsLoading = false;
            HasSearched = true;
        }
    }
}