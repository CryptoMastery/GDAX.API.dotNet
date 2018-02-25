using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoMastery.GDAX.API.Model;

namespace CryptoMastery.GDAX.API.Contracts.PrivateServices
{
    public interface IOrdersService
    {
        Task<Order> PlaceLimitGTCOrderAsync(
            Sides orderSide,
            string productId,
            decimal price,
            decimal size,
            OrderSelfTradePreventionFlags selfTradePreventionFlag = OrderSelfTradePreventionFlags.DecreaseAndCancel
        );

        Task<Order> PlaceLimitGTCOrderAsync(
            Sides orderSide,
            string productId,
            decimal price,
            decimal size,
            Guid clientOrderId,
            OrderSelfTradePreventionFlags selfTradePreventionFlag = OrderSelfTradePreventionFlags.DecreaseAndCancel
        );

        Task<Order> CancelOrderAsync(Guid orderId);

        Task<List<Order>> GetOrdersAsync();

        Task<List<string>> CancelAllOrdersAsync();

        Task<Order> GetOrderByIdAsync(Guid orderId);
    }
}