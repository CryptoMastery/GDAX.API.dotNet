using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoMastery.GDAX.API.Contracts.Configuration;
using CryptoMastery.GDAX.API.Contracts.PrivateServices;
using CryptoMastery.GDAX.API.Model;

namespace CryptoMastery.GDAX.API.PrivateServices
{
    public class FillsService : BasePrivateService, IFillsService
    {
        private const string GetFillsByOrderIdEndpoint = "/fills?order_id={0}";

        public FillsService(ICredentialsProvider credentialsProvider,
            IConnectionSettingsProvider connectionSettingsProvider)
            : base(credentialsProvider, connectionSettingsProvider)
        {
        }

        public Task<List<Fill>> GetFillsAsync(Guid orderId)
        {
            return Client.InvokeSecureRequest<List<Fill>>(CredentialsProvider, HttpMethod.Get,
                GetFillsByOrderIdEndpoint,
                orderId);
        }
    }
}