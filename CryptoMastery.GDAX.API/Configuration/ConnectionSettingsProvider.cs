using System;
using CryptoMastery.GDAX.API.Contracts.Configuration;

namespace CryptoMastery.GDAX.API.Configuration
{
    public class ConnectionSettingsProvider : IConnectionSettingsProvider
    {
        public ConnectionSettingsProvider(Uri baseUri)
        {
            BaseUri = baseUri;
        }

        public static Uri DefaultProduction { get; } =
            new Uri("https://api.gdax.com");

        public static Uri DefaultSandbox { get; } =
            new Uri("https://api-public.sandbox.gdax.com");

        public Uri BaseUri { get; }
    }
}