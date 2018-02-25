namespace CryptoMastery.GDAX.API.Model
{
    public class TradingSettings
    {
        public TradingSettings(
            string productId,
            decimal buyThreshold,
            decimal sellThreshold,
            string currentOrderFile,
            string ordersLogFile,
            int pollingInterval)
        {
            ProductId = productId;
            BuyThreshold = buyThreshold;
            SellThreshold = sellThreshold;
            CurrentOrderFile = currentOrderFile;
            OrdersLogFile = ordersLogFile;
            PollingInterval = pollingInterval;
        }

        public string ProductId { get; }

        public decimal BuyThreshold { get; }

        public decimal SellThreshold { get; }

        public string CurrentOrderFile { get; }

        public string OrdersLogFile { get; }

        public int PollingInterval { get; }
    }
}