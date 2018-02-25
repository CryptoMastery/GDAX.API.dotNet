using System;
using System.Runtime.Serialization;

namespace CryptoMastery.GDAX.API.Model
{
    [DataContract]
    public class Time
    {
        [DataMember(Name = "iso")]
        public DateTime ServerTime { get; set; }

        [DataMember(Name = "epoch")]
        public decimal Epoch { get; set; }
    }
}