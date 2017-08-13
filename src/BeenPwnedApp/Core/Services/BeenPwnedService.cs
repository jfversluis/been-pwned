using System;
using System.Collections.Generic;
using Akavache;
using BeenPwned.Api;
using BeenPwned.Api.Models;
using Xamarin.Forms;

namespace BeenPwned.App.Core.Services
{
    internal class BeenPwnedService
    {
        private IBeenPwnedClient _pwnedClient = new BeenPwnedClient($"BeenPwned-{Device.RuntimePlatform}");
		private static Lazy<BeenPwnedService> _pwnedService = new Lazy<BeenPwnedService>(() => new BeenPwnedService());
        internal static BeenPwnedService Instance => _pwnedService.Value;

        internal IObservable<IEnumerable<Breach>> GetAllBreaches(bool force = false)
        {
			var cache = BlobCache.LocalMachine;
            return cache.GetAndFetchLatest("breaches", async () => await _pwnedClient.GetAllBreaches(),
                offset =>
                {
                    TimeSpan elapsed = DateTimeOffset.Now - offset;
                    var invalidate = (force || elapsed > new TimeSpan(24, 0, 0));
                    return invalidate;
                });
        }
    }
}