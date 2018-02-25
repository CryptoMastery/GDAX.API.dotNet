using System;

namespace CryptoMastery.GDAX.API.Contracts.Configuration
{
    public class ConnectionSettings
    {
        public ConnectionSettings(Uri baseUri)
        {
            BaseUri = baseUri;
        }

        public static ConnectionSettings DefaultProduction { get; } =
            new ConnectionSettings(new Uri("https://api.gdax.com"));

        public static ConnectionSettings DefaultSandbox { get; } =
            new ConnectionSettings(new Uri("https://api-public.sandbox.gdax.com"));

        public Uri BaseUri { get; }
    }
}