using System;
using BeenPwned.Api;
using Xamarin.Forms;

namespace BeenPwned.App.Core.Services
{
    internal class BeenPwnedService
    {
        private static Lazy<BeenPwnedClient> _pwnedClient = new Lazy<BeenPwnedClient>(() => new BeenPwnedClient($"BeenPwned-{Device.RuntimePlatform}"));
        internal static BeenPwnedClient Instance => _pwnedClient.Value;
    }
}