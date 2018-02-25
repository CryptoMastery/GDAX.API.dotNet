using System.Runtime.Serialization;

namespace CryptoMastery.GDAX.API.Model
{
    [DataContract]
    public class Currency
    {
        public static readonly string USD = "USD";
        public static readonly string BTC = "BTC";
        public static readonly string LTC = "LTC";
        public static readonly string ETH = "ETH";

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "min_size")]
        public decimal MinSize { get; set; }
    }
}