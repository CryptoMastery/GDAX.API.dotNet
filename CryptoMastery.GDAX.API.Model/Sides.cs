using System;

namespace CryptoMastery.GDAX.API.Model
{
    public enum Sides
    {
        Buy,
        Sell
    }

    public static class SidesMethods
    {
        public static string GetString(this Sides side)
        {
            switch (side)
            {
                case Sides.Buy:
                    return "buy";
                case Sides.Sell:
                    return "sell";
                default:
                    throw new ArgumentException($"Unsupported side");
            }
        }

        public static Sides FromString(this Sides side, string sideText)
        {
            switch (sideText)
            {
                case "buy":
                    return Sides.Buy;
                case "sell":
                    return Sides.Sell;
                default:
                    throw new ArgumentException($"Unsupported side {sideText}");
            }
        }
    }
}