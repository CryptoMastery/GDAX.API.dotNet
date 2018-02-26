using System.Net.Http;
using System.Threading.Tasks;
using CryptoMastery.GDAX.API.Contracts.Configuration;
using CryptoMastery.GDAX.API.Contracts.PublicServices;
using CryptoMastery.GDAX.API.Model;

namespace CryptoMastery.GDAX.API.PublicServices
{
    public class TimeService : BasePublicService, ITimeService
    {
        private const string GetTimeEndpoint = "/time";

        public TimeService(IConnectionSettingsProvider connectionSettingsProvider) : base(
            connectionSettingsProvider)
        {
        }

        public Task<Time> GetTimeAsync()
        {
            return Client.InvokeRequest<Time>(HttpMethod.Get, GetTimeEndpoint);
        }
    }
}