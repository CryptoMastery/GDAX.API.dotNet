using System;
using System.Runtime.Serialization;

namespace CryptoMastery.GDAX.API.Model
{
    [DataContract]
    public class Account
    {
        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        [DataMember(Name = "currency")]
        public string Currency { get; set; }

        [DataMember(Name = "balance")]
        public decimal Balance { get; set; }

        [DataMember(Name = "available")]
        public decimal Available { get; set; }

        [DataMember(Name = "hold")]
        public decimal Hold { get; set; }

        [DataMember(Name = "profile_id")]
        public Guid ProfileId { get; set; }
    }
}