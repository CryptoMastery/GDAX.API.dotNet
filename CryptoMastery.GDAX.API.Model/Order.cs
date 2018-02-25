using System;
using System.Runtime.Serialization;

namespace CryptoMastery.GDAX.API.Model
{
    [DataContract]
    public class Order
    {
        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        [DataMember(Name = "side")]
        public string SideText { get; set; }

        public Sides Side => new Sides().FromString(SideText);

        [DataMember(Name = "type")]
        public string TypeText { get; set; }

        public OrderTypes Type => new OrderTypes().FromString(TypeText);

        [DataMember(Name = "stp")]
        public string SelfTradePreventionFlagText { get; set; }

        public OrderSelfTradePreventionFlags SelfTradePreventionFlag =>
            new OrderSelfTradePreventionFlags().FromString(SelfTradePreventionFlagText);

        [DataMember(Name = "time_in_force")]
        public string LimitOrderTimeInForceFlagText { get; set; }

        public LimitOrderTimeInForceFlags? LimitOrderTimeInForceFlag
        {
            get
            {
                if (LimitOrderTimeInForceFlagText == null)
                    return null;
                return new LimitOrderTimeInForceFlags().FromString(LimitOrderTimeInForceFlagText);
            }
        }

        [DataMember(Name = "post_only")]
        public bool PostOnly { get; set; }

        [DataMember(Name = "price")]
        public decimal? Price { get; set; }

        [DataMember(Name = "size")]
        public decimal? Size { get; set; }

        [DataMember(Name = "product_id")]
        public string ProductId { get; set; }

        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "fill_fees")]
        public decimal? FillFees { get; set; }

        [DataMember(Name = "filled_size")]
        public decimal? FilledSize { get; set; }

        [DataMember(Name = "executed_value")]
        public decimal? ExecutedValue { get; set; }

        [DataMember(Name = "status")]
        public string StatusText { get; set; }

        [DataMember(Name = "settled")]
        public bool? Settled { get; set; }

        public OrderStatuses Status => new OrderStatuses().FromString(StatusText);
    }
}