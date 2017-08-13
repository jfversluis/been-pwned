using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Akavache;
using BeenPwned.Api.Models;
using BeenPwned.App.Core.Services;
using MvvmHelpers;
using Xamarin.Forms;

namespace BeenPwned.App.Core.PageModels
{
    public class BreachesPageModel : BasePageModel
    {
        bool _isNavigating;

		private readonly ObservableRangeCollection<Breach> _breaches = new ObservableRangeCollection<Breach>();
        public ObservableCollection<Breach> Breaches { get { return _breaches; } }

        public ICommand OpenBreachCommand => new Command(async (item) => await OpenBreach(item), (arg) => !_isNavigating);

		private ICommand _refreshCommand;
		public ICommand RefreshCommand
		{
			get
			{
				return _refreshCommand ??
					(_refreshCommand = new Command(ExecuteRefreshCommand));
			}
		}

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

            GetBreaches();
        }

        public async Task OpenBreach(object breach)
        {
            _isNavigating = true;

            await CoreMethods.PushPageModel<BreachPageModel>(breach, false, true);

            _isNavigating = false;
        }

		public void GetBreaches(bool force = false)
		{
			var cache = BlobCache.LocalMachine;
            cache.GetAndFetchLatest("breaches", GetRemoteBreaches,
				offset =>
				{
					TimeSpan elapsed = DateTimeOffset.Now - offset;
					var invalidate = (force || elapsed > new TimeSpan(24, 0, 0));
					return invalidate;
				})
				.Subscribe((contributions) =>
				{
                    _breaches.ReplaceRange(contributions);
				});
		}

        private async Task<IEnumerable<Breach>> GetRemoteBreaches()
		{
            return await BeenPwnedService.Instance.GetAllBreaches();
		}

		private void ExecuteRefreshCommand()
		{
            IsLoading = true;

            GetBreaches(true);

            IsLoading = false;
		}
    }
}