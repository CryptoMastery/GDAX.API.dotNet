using System;

namespace CryptoMastery.GDAX.API.Model
{
    public enum OrderSelfTradePreventionFlags
    {
        DecreaseAndCancel,
        CancelOldest,
        CancelNewest,
        CancelBoth
    }

    public static class OrderSelfTradePreventionFlagsMethods
    {
        public static string GetString(this OrderSelfTradePreventionFlags flag)
        {
            switch (flag)
            {
                case OrderSelfTradePreventionFlags.DecreaseAndCancel:
                    return "dc";
                case OrderSelfTradePreventionFlags.CancelOldest:
                    return "co";
                case OrderSelfTradePreventionFlags.CancelNewest:
                    return "cn";
                case OrderSelfTradePreventionFlags.CancelBoth:
                    return "cb";
                default:
                    throw new ArgumentException($"Unsupported OrderSelfTradePreventionFlag");
            }
        }

        public static OrderSelfTradePreventionFlags FromString(this OrderSelfTradePreventionFlags flag, string flagText)
        {
            switch (flagText)
            {
                case "dc":
                    return OrderSelfTradePreventionFlags.DecreaseAndCancel;
                case "co":
                    return OrderSelfTradePreventionFlags.CancelOldest;
                case "cn":
                    return OrderSelfTradePreventionFlags.CancelNewest;
                case "cb":
                    return OrderSelfTradePreventionFlags.CancelBoth;
                default:
                    throw new ArgumentException($"Unsupported OrderSelfTradePreventionFlag {flagText}");
            }
        }
    }
}