﻿using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using BeenPwned.Api.Models;
using BeenPwned.App.Core.Services;
using MvvmHelpers;
using Xamarin.Forms;
using System.Linq;

namespace BeenPwned.App.Core.PageModels
{
    public class BreachesPageModel : BasePageModel
    {
        private readonly ObservableRangeCollection<Grouping<string, Breach>> _breaches = new ObservableRangeCollection<Grouping<string, Breach>>();
        public ObservableCollection<Grouping<string, Breach>> Breaches { get { return _breaches; } }

        private ICommand _openBreachCommand;
        public ICommand OpenBreachCommand => _openBreachCommand ?? (_openBreachCommand = new Command(async (item) => await OpenBreach(item), (arg) => !_isNavigating));

        private ICommand _refreshCommand;
        public ICommand RefreshCommand => _refreshCommand ?? (_refreshCommand = new Command(ExecuteRefreshCommand));

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            ExecuteRefreshCommand();
        }

        public async Task OpenBreach(object breach)
        {
            _isNavigating = true;

            await CoreMethods.PushPageModel<BreachPageModel>(breach, false, true);

            _isNavigating = false;
        }

        private void ExecuteRefreshCommand()
        {
            IsLoading = true;

            BeenPwnedService.Instance.GetAllBreaches()
                            .Subscribe((breaches) =>
                {
                    var sorted = from breach in breaches
                                 orderby breach.Name
                                 group breach by breach.Name[0].ToString().ToUpperInvariant() into breachGroup
                                 select new Grouping<string, Breach>(breachGroup.Key, breachGroup);
                
                    _breaches.ReplaceRange(sorted);
                });

            IsLoading = false;
        }
    }
}