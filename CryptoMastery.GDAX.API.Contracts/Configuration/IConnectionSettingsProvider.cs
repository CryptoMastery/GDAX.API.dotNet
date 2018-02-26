using System;

namespace CryptoMastery.GDAX.API.Contracts.Configuration
{
    public interface IConnectionSettingsProvider
    {
        Uri BaseUri { get; }
    }
}