using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoMastery.GDAX.API.Contracts.Configuration;
using CryptoMastery.GDAX.API.Contracts.PublicServices;
using CryptoMastery.GDAX.API.Model;

namespace CryptoMastery.GDAX.API.PublicServices
{
    public class CurrenciesService : BasePublicService, ICurrenciesService
    {
        private const string GetCurrenciesEndpoint = "/currencies";

        public CurrenciesService(IConnectionSettingsProvider connectionSettingsProvider) : base(
            connectionSettingsProvider)
        {
        }

        public Task<List<Currency>> GetCurrenciesAsync()
        {
            return Client.InvokeRequest<List<Currency>>(HttpMethod.Get, GetCurrenciesEndpoint);
        }
    }
}