using System;

namespace CryptoMastery.GDAX.API.Model
{
    public enum OrderTypes
    {
        Market,
        Limit,
        Stop
    }

    public static class OrderTypesMethods
    {
        public static string GetString(this OrderTypes orderType)
        {
            switch (orderType)
            {
                case OrderTypes.Limit:
                    return "limit";
                case OrderTypes.Stop:
                    return "stop";
                case OrderTypes.Market:
                    return "market";
                default:
                    throw new ArgumentException($"Unsupported orderType");
            }
        }

        public static OrderTypes FromString(this OrderTypes orderType, string orderTypeText)
        {
            switch (orderTypeText)
            {
                case "limit":
                    return OrderTypes.Limit;
                case "stop":
                    return OrderTypes.Stop;
                case "market":
                    return OrderTypes.Market;
                default:
                    throw new ArgumentException($"Unsupported orderType {orderTypeText}");
            }
        }
    }
}