using System;

namespace CryptoMastery.GDAX.API.Model
{
    public class Candle
    {
        public long EpochTime { get; set; }
        public decimal Low { get; set; }
        public decimal High { get; set; }
        public decimal Open { get; set; }
        public decimal Close { get; set; }
        public decimal Volume { get; set; }
        public DateTime Time { get; set; }
    }
}