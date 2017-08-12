using System.Collections.ObjectModel;
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

        public ObservableCollection<Breach> Breaches { get; set; } = new ObservableCollection<Breach>();
        public ICommand OpenBreachCommand => new Command(async (item) => await OpenBreach(item), (arg) => !_isNavigating);
        private readonly BeenPwnedClient _pwnedClient;

        public BreachesPageModel()
        {
            _pwnedClient = new BeenPwnedClient("BeenPwned-iOS");
        }

        public async override void Init(object initData)
        {
            base.Init(initData);

            var breaches = await _pwnedClient.GetAllBreaches();

            foreach (var breach in breaches)
                Breaches.Add(breach);
        }

        public async Task OpenBreach(object breach)
        {
            _isNavigating = true;
            await CoreMethods.PushPageModel<BreachPageModel>(breach, false, true);
            _isNavigating = false;
        }
    }
}