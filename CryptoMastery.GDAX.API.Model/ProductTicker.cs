using System;
using System.Runtime.Serialization;

namespace CryptoMastery.GDAX.API.Model
{
    [DataContract]
    public class ProductTicker
    {
        [DataMember(Name = "trade_id")]
        public long TradeId { get; set; }

        [DataMember(Name = "price")]
        public decimal Price { get; set; }

        [DataMember(Name = "size")]
        public decimal Size { get; set; }

        [DataMember(Name = "bid")]
        public decimal Bid { get; set; }

        [DataMember(Name = "ask")]
        public decimal Ask { get; set; }

        [DataMember(Name = "volume")]
        public decimal Volume { get; set; }

        [DataMember(Name = "time")]
        public DateTime Time { get; set; }
    }
}