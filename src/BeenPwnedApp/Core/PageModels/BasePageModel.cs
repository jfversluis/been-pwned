using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using PropertyChanged;
using Xamarin.Forms;

namespace BeenPwned.App.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class BasePageModel : FreshBasePageModel
    {
        protected bool _isNavigating;

        public bool IsLoading { get; set; }

		private ICommand _openSettingsCommand;
		public ICommand OpenSettingsCommand => _openSettingsCommand ?? (_openSettingsCommand = new Command(async (i) => await OpenSettings(), (arg) => !_isNavigating));

        private async Task OpenSettings()
        {
            _isNavigating = true;

            await CoreMethods.PushPageModel<SettingsPageModel>();

            _isNavigating = false;
        }
    }
}