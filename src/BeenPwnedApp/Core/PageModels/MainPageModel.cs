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
                    IsError = false;
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

            try
            {
                var resultBreaches = await BeenPwnedService.Instance.GetBreachesForAccount(Filter);


                var breachesGroup = BreachesAndPastes.SingleOrDefault(b => b.Name == "Breaches");

                if (breachesGroup == null)
                    BreachesAndPastes.Add(new SearchListGroup("Breaches"));

                BreachesAndPastes.Single(b => b.Name == "Breaches").ReplaceRange(resultBreaches);


                IEnumerable<Paste> resultPastes = null;

                try
                {
                    resultPastes = await BeenPwnedService.Instance.GetPastesForAccount(Filter);

                    var pastesGroup = BreachesAndPastes.SingleOrDefault(b => b.Name == "Pastes");

                    if (resultPastes.Count() > 0)
                    {
                        if (pastesGroup == null)
                            BreachesAndPastes.Add(new SearchListGroup("Pastes"));

                        BreachesAndPastes.Single(b => b.Name == "Pastes").ReplaceRange(resultPastes);
                    }
                    else
                    {
                        BreachesAndPastes.Remove(pastesGroup);
                    }
                }
                catch (ArgumentException)
                {
                    // If the given acount is not a (valid) e-mailaddress an ArgumentException will be thrown
                    BreachesAndPastes.SingleOrDefault(b => b.Name == "Pastes")?.Clear();
                    BreachesAndPastes.Remove(BreachesAndPastes.Where(g => g.Name == "Pastes").SingleOrDefault());
                }

                HasItems = BreachesAndPastes.SelectMany(g => g).Any();
                var breachCount = resultBreaches?.Count() ?? 0;
                var pasteCount = resultPastes?.Count() ?? 0;

                BreachedDescription = $"Pwned on {breachCount} breached site(s) and found {pasteCount} paste(s).";
            }
            catch
            {
                IsError = true;
            }
            finally
            {
				IsLoading = false;
				HasSearched = true;
            }
        }
    }
}