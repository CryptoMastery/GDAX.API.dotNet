using System;

namespace CryptoMastery.GDAX.API.Model
{
    public enum Liquidities
    {
        Taker,
        Maker
    }

    public static class LiquiditiesMethods
    {
        public static string GetString(this Liquidities liquidity)
        {
            switch (liquidity)
            {
                case Liquidities.Maker:
                    return "M";
                case Liquidities.Taker:
                    return "T";
                default:
                    throw new ArgumentException($"Unsupported liquidity");
            }
        }

        public static Liquidities FromString(this Liquidities liquidity, string liquidityText)
        {
            switch (liquidityText)
            {
                case "M":
                    return Liquidities.Maker;
                case "T":
                    return Liquidities.Taker;
                default:
                    throw new ArgumentException($"Unsupported liquidity {liquidityText}");
            }
        }
    }
}