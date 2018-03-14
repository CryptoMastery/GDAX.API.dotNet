using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoMastery.GDAX.API.Model;

namespace CryptoMastery.GDAX.API.Contracts.PublicServices
{
    public interface IProductsService
    {
        Task<List<Product>> GetProductsAsyc();

        Task<ProductTicker> GetProductTickerAsyc(string productId);

        Task<List<Candle>> GetProductHistoricalRatesAsyc(string productId, RateGranularities granularity,
            DateTime start, DateTime end);

        Task<List<Candle>> GetProductHistoricalRatesAsyc(string productId, RateGranularities granularity);
    }
}