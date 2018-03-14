using System;
using System.Threading.Tasks;
using CryptoMastery.GDAX.API.Configuration;
using CryptoMastery.GDAX.API.Model;
using CryptoMastery.GDAX.API.PrivateServices;
using CryptoMastery.GDAX.API.PublicServices;

namespace CryptoMastery.GDAX.API.Sample
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            try
            {
                Console.WriteLine("Sample Started");
                await Sample();
                Console.WriteLine("Sample Complete");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }
        }

        private static async Task Sample()
        {
            //Historical Prices
            //FOR SOME REASON SANDBOX DOESN'T PROVIDE HISTORICAL PRICES
            var prodSettingsProvider = new ConnectionSettingsProvider(ConnectionSettingsProvider.DefaultProduction);
            var historicalPricesService = new ProductsService(prodSettingsProvider);
            var prices =
                await historicalPricesService.GetProductHistoricalRatesAsyc("BTC-USD", RateGranularities.Gr1Minute);
            Console.WriteLine($"{prices.Count} latest prices found");
            var start = DateTime.Now.AddHours(-10);
            var end = start.AddMinutes(10);
            prices = await historicalPricesService.GetProductHistoricalRatesAsyc("BTC-USD", RateGranularities.Gr1Minute,
                start, end);
            Console.WriteLine($"{prices.Count} prices between {start} and {end} found");

            //Use Sandbox for the rest of APIs
            var settingsProvider = new ConnectionSettingsProvider(ConnectionSettingsProvider.DefaultSandbox);
            var credentailsProvider = new SampleCredentailsProvider();

            //Currencies
            var currencyService = new CurrenciesService(settingsProvider);
            var currencies = await currencyService.GetCurrenciesAsync();
            Console.WriteLine($"{currencies.Count} currencies found");

            //Products
            var prdService = new ProductsService(settingsProvider);
            var products = await prdService.GetProductsAsyc();
            Console.WriteLine($"{products.Count} products found");
            var productTicker = await prdService.GetProductTickerAsyc("BTC-USD");
            Console.WriteLine($"Latest price for BTC-USD is {productTicker.Price}");

            //Time
            var timeService = new TimeService(settingsProvider);
            var time = await timeService.GetTimeAsync();
            Console.WriteLine($"Service time: {time.ServerTime}");

            //Accounts
            var acctService = new AccountsService(credentailsProvider, settingsProvider);
            var accts = await acctService.GetAccountsAsync();
            Console.WriteLine($"{currencies.Count} accounts found");
            if (accts.Count > 0)
            {
                var acct = await acctService.GetAccountByIdAsync(accts[0].Id);
                Console.WriteLine($"Account with id: {acct.Id} retrieved");
                var acctHolds = await acctService.GetAccountHoldsAsync(accts[1].Id);
                Console.WriteLine($"{acctHolds.Count} account holds found for account {accts[1].Id}");
            }

            //Orders
            var orderService = new OrdersService(credentailsProvider, settingsProvider);
            //Buy BTC
            var order = await orderService.PlaceLimitGTCOrderAsync(Sides.Buy, Product.BTC_USD, 9000m, 0.01m);
            Console.WriteLine($"Order with id {order.Id} has been placed");
            var orders = await orderService.GetOrdersAsync();
            Console.WriteLine($"{orders.Count} orders found");
            var ord1 = await orderService.GetOrderByIdAsync(order.Id);
            Console.WriteLine($"Order with id: {ord1.Id} retrieved");

            //Fills
            var fillsService = new FillsService(credentailsProvider, settingsProvider);
            var fills = await fillsService.GetFillsAsync(ord1.Id);
            Console.WriteLine($"{fills.Count} fills found for order {ord1.Id}");

            //Order Calcellation
            var msg = await orderService.CancelOrderAsync(order.Id);
            Console.WriteLine($"Order with id: {msg[0]} cancelled");
        }
    }
}