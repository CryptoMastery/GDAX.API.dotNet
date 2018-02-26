using CryptoMastery.GDAX.API.Client;
using CryptoMastery.GDAX.API.Contracts.Configuration;

namespace CryptoMastery.GDAX.API.PublicServices
{
    public abstract class BasePublicService
    {
        protected readonly IServiceClient Client;

        protected BasePublicService(IConnectionSettingsProvider connectionSettingsProvider)
        {
            Client = new ServiceClient(connectionSettingsProvider);
        }
    }
}