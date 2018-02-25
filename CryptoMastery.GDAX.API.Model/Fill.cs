using System;
using System.Runtime.Serialization;

namespace CryptoMastery.GDAX.API.Model
{
    [DataContract]
    public class Fill
    {
        [DataMember(Name = "trade_id")]
        public long TradeId { get; set; }

        [DataMember(Name = "product_id")]
        public string ProductId { get; set; }

        [DataMember(Name = "price")]
        public decimal Price { get; set; }

        [DataMember(Name = "size")]
        public decimal Size { get; set; }

        [DataMember(Name = "order_id")]
        public Guid OrderId { get; set; }

        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "liquidity")]
        public string LiquidityText { get; set; }

        public Liquidities Liquidity => new Liquidities().FromString(LiquidityText);

        [DataMember(Name = "fee")]
        public decimal Fee { get; set; }

        [DataMember(Name = "settled")]
        public bool Settled { get; set; }

        [DataMember(Name = "side")]
        public string SideText { get; set; }

        public Sides Side => new Sides().FromString(SideText);
    }
}