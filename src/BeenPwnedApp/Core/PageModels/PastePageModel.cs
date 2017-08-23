using System;
using System.Windows.Input;
using BeenPwned.Api.Models;
using BeenPwned.App.Core.Interfaces;
using Xamarin.Forms;

namespace BeenPwned.App.Core.PageModels
{
    public class PastePageModel : BasePageModel
    {
		public Paste Paste { get; set; }

		private ICommand _openPasteUrlCommand;
		public ICommand OpenPasteUrlCommand => _openPasteUrlCommand ?? (_openPasteUrlCommand = new Command((i) => OpenPasteUrl(), (arg) => !_isNavigating));

		public override void Init(object initData)
		{
			base.Init(initData);

			if (initData != null)
			{
				Paste = (Paste)initData;
			}
		}

		public void OpenPasteUrl()
		{
			_isNavigating = true;

            var url = $"http://{Paste.Source}.com/{Paste.Id}";

            if (Device.RuntimePlatform != Device.iOS)
                Device.OpenUri(new Uri(url));
            else
                DependencyService.Get<IBrowserService>()?.OpenUrl(url);

			_isNavigating = false;
		}
    }
}