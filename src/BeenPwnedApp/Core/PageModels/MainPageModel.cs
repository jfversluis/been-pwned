using BeenPwned.Api;
using FreshMvvm;

namespace BeenPwned.App.Core.PageModels
{
    public class MainPageModel : FreshBasePageModel
    {
        private readonly BeenPwnedClient _pwnedClient;

        public MainPageModel()
        {
            _pwnedClient = new BeenPwnedClient("BeenPwned-iOS");
        }
    }
}
