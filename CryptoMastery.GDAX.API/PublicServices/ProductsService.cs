using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoMastery.GDAX.API.Contracts.Configuration;
using CryptoMastery.GDAX.API.Contracts.PublicServices;
using CryptoMastery.GDAX.API.Helpers;
using CryptoMastery.GDAX.API.Model;
using Newtonsoft.Json.Linq;

namespace CryptoMastery.GDAX.API.PublicServices
{
    public class ProductsService : BasePublicService, IProductsService
    {
        private const string GetProductsEndpoint = "/products";
        private const string GetProductTickerEndpoint = "/products/{0}/ticker";
        private const string GetProductHistoricalRatesEndpoint = "/products/{0}/candles?granularity={1}";

        private const string GetProductHistoricalRatesForPeriodEndpoint =
            "/products/{0}/candles?granularity={1}&start={2}&end={3}";

        public ProductsService(IConnectionSettingsProvider connectionSettingsProvider) : base(
            connectionSettingsProvider)
        {
        }

        public async Task<List<Product>> GetProductsAsyc()
        {
            return await Client.InvokeRequest<List<Product>>(HttpMethod.Get, GetProductsEndpoint);
        }

        public async Task<ProductTicker> GetProductTickerAsyc(string productId)
        {
            return await Client.InvokeRequest<ProductTicker>(HttpMethod.Get, GetProductTickerEndpoint, productId);
        }

        public async Task<List<Candle>> GetProductHistoricalRatesAsyc(string productId, RateGranularities granularity,
            DateTime start, DateTime end)
        {
            var candlesArray = await Client.InvokeRequest<JArray>(HttpMethod.Get,
                GetProductHistoricalRatesForPeriodEndpoint,
                productId,
                (int) granularity,
                start.ToString("o"),
                end.ToString("o"));
            return JArrayToCandles(candlesArray);
        }

        public async Task<List<Candle>> GetProductHistoricalRatesAsyc(string productId, RateGranularities granularity)
        {
            var candlesArray = await Client.InvokeRequest<JArray>(HttpMethod.Get, GetProductHistoricalRatesEndpoint,
                productId, (int) granularity);
            return JArrayToCandles(candlesArray);
        }

        private List<Candle> JArrayToCandles(JArray candleData)
        {
            var candles = new List<Candle>();
            foreach (var t in candleData)
            {
                var candle = new Candle
                {
                    EpochTime = (long) t[0],
                    Time = TimeHelper.GetDateTimeFromSecondsSinceUnixEpoch((long) t[0]),
                    Low = (decimal) t[1],
                    High = (decimal) t[2],
                    Open = (decimal) t[3],
                    Close = (decimal) t[4],
                    Volume = (decimal) t[5]
                };
                candles.Add(candle);
            }

            return candles;
        }
    }
}