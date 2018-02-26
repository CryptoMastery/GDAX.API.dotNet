using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoMastery.GDAX.API.Contracts.Configuration;
using CryptoMastery.GDAX.API.Contracts.PublicServices;
using CryptoMastery.GDAX.API.Model;

namespace CryptoMastery.GDAX.API.PublicServices
{
    public class ProductsService : BasePublicService, IProductsService
    {
        private const string GetProductsEndpoint = "/products";
        private const string GetProductTickerEndpoint = "/products/{0}/ticker";

        public ProductsService(IConnectionSettingsProvider connectionSettingsProvider) : base(
            connectionSettingsProvider)
        {
        }

        public Task<List<Product>> GetProductsAsyc()
        {
            return Client.InvokeRequest<List<Product>>(HttpMethod.Get, GetProductsEndpoint);
        }

        public Task<ProductTicker> GetProductTickerAsyc(string productId)
        {
            return Client.InvokeRequest<ProductTicker>(HttpMethod.Get, GetProductTickerEndpoint, productId);
        }
    }
}