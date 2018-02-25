using System.Runtime.Serialization;

namespace CryptoMastery.GDAX.API.Model
{
    [DataContract]
    public class Product
    {
        public static readonly string BTC_USD = "BTC-USD";
        public static readonly string BTC_GBP = "BTC-GBP";
        public static readonly string BTC_EUR = "BTC-EUR";
        public static readonly string ETH_BTC = "ETH-BTC";
        public static readonly string ETH_USD = "ETH-USD";
        public static readonly string LTC_BTC = "LTC-BTC";
        public static readonly string LTC_USD = "LTC-USD";
        public static readonly string ETH_EUR = "ETH-EUR";

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "base_currency")]
        public string BaseCurrency { get; set; }

        [DataMember(Name = "quote_currency")]
        public string QuoteCurrency { get; set; }

        [DataMember(Name = "base_min_size")]
        public decimal BaseMinSize { get; set; }

        [DataMember(Name = "base_max_size")]
        public decimal BaseMaxSize { get; set; }

        [DataMember(Name = "quote_increment")]
        public decimal QuoteIncerement { get; set; }
    }
}