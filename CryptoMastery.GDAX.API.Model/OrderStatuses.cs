using System;

namespace CryptoMastery.GDAX.API.Model
{
    public enum OrderStatuses
    {
        Open,
        Pending,
        Active,
        Done,
        Settled
    }

    public static class OrderStatusesMethods
    {
        public static string GetString(this OrderStatuses orderStatus)
        {
            switch (orderStatus)
            {
                case OrderStatuses.Open:
                    return "open";
                case OrderStatuses.Pending:
                    return "pending";
                case OrderStatuses.Active:
                    return "active";
                case OrderStatuses.Done:
                    return "done";
                case OrderStatuses.Settled:
                    return "settled";
                default:
                    throw new ArgumentException($"Unsupported orderStatus");
            }
        }

        public static OrderStatuses FromString(this OrderStatuses orderStatus, string orderStatusText)
        {
            switch (orderStatusText)
            {
                case "open":
                    return OrderStatuses.Open;
                case "pending":
                    return OrderStatuses.Pending;
                case "active":
                    return OrderStatuses.Active;
                case "done":
                    return OrderStatuses.Done;
                case "settled":
                    return OrderStatuses.Settled;
                default:
                    throw new ArgumentException($"Unsupported orderStatus {orderStatusText}");
            }
        }
    }
}