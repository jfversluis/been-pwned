using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using BeenPwned.Api;
using BeenPwned.Api.Models;
using FreshMvvm;
using Xamarin.Forms;

namespace BeenPwned.App.Core.PageModels
{
    public class BreachesPageModel : FreshBasePageModel
    {
        bool _isNavigating;
        bool _dataLoaded;

        public ObservableCollection<Breach> Breaches { get; set; } = new ObservableCollection<Breach>();
        public ICommand OpenBreachCommand => new Command(async (item) => await OpenBreach(item), (arg) => !_isNavigating);
        private readonly BeenPwnedClient _pwnedClient;

        public BreachesPageModel()
        {
            _pwnedClient = new BeenPwnedClient("BeenPwned-iOS");
        }

        protected override async void ViewIsAppearing(object sender, System.EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

            // To prevent this from reloading every time a user comes back to it while its in memory.
            if (!_dataLoaded)
            {
                var breaches = await _pwnedClient.GetAllBreaches();

                foreach (var breach in breaches)
                    Breaches.Add(breach);

                _dataLoaded = true;
            }
        }

        public async Task OpenBreach(object breach)
        {
            _isNavigating = true;
            await CoreMethods.PushPageModel<BreachPageModel>(breach, false, true);
            _isNavigating = false;
        }
    }
}