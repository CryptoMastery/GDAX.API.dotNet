﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using CryptoMastery.GDAX.API.Contracts.Configuration;
using CryptoMastery.GDAX.API.Contracts.PrivateServices;
using CryptoMastery.GDAX.API.Model;

namespace CryptoMastery.GDAX.API.PrivateServices
{
    public class OrdersService : BasePrivateService, IOrdersService
    {
        private const string OrdersEndpoint = "/orders";
        private const string OrdersByIdEndpoint = "/orders/{0}";

        public OrdersService(ICredentialsProvider credentialsProvider,
            IConnectionSettingsProvider connectionSettingsProvider)
            : base(credentialsProvider, connectionSettingsProvider)
        {
        }

        public Task<Order> PlaceLimitGTCOrderAsync(
            Sides orderSide,
            string productId,
            decimal price,
            decimal size,
            OrderSelfTradePreventionFlags selfTradePreventionFlag = OrderSelfTradePreventionFlags.DecreaseAndCancel
        )
        {
            var orderRequest = new OrderRequest
            {
                OrderSide = orderSide.GetString(),
                OrderType = OrderTypes.Limit.GetString(),
                TimeInForceFlag = LimitOrderTimeInForceFlags.GTC.GetString(),
                ProductId = productId,
                Price = price,
                Size = size,
                SelfTradePreventionFlag = selfTradePreventionFlag.GetString(),
                PostOnly = true
            };
            return Client.InvokeSecureRequestWithBody<OrderRequest, Order>(
                CredentialsProvider,
                HttpMethod.Post,
                OrdersEndpoint,
                orderRequest);
        }

        public Task<Order> PlaceLimitGTCOrderAsync(
            Sides orderSide,
            string productId,
            decimal price,
            decimal size,
            Guid clientOrderId,
            OrderSelfTradePreventionFlags selfTradePreventionFlag = OrderSelfTradePreventionFlags.DecreaseAndCancel
        )
        {
            var orderRequest = new OrderRequest
            {
                OrderSide = orderSide.GetString(),
                OrderType = OrderTypes.Limit.GetString(),
                TimeInForceFlag = LimitOrderTimeInForceFlags.GTC.GetString(),
                ProductId = productId,
                Price = price,
                Size = size,
                SelfTradePreventionFlag = selfTradePreventionFlag.GetString(),
                ClientOrderId = clientOrderId,
                PostOnly = true
            };
            return Client.InvokeSecureRequestWithBody<OrderRequest, Order>(
                CredentialsProvider,
                HttpMethod.Post,
                OrdersEndpoint,
                orderRequest);
        }

        public Task<Order> GetOrderByIdAsync(Guid orderId)
        {
            return Client.InvokeSecureRequest<Order>(CredentialsProvider, HttpMethod.Get, OrdersByIdEndpoint, orderId);
        }

        public Task<Order> CancelOrderAsync(Guid orderId)
        {
            return Client.InvokeSecureRequest<Order>(CredentialsProvider, HttpMethod.Get, OrdersByIdEndpoint, orderId);
        }

        public Task<List<Order>> GetOrdersAsync()
        {
            return Client.InvokeSecureRequest<List<Order>>(CredentialsProvider, HttpMethod.Get, OrdersEndpoint);
        }

        public Task<List<string>> CancelAllOrdersAsync()
        {
            return Client.InvokeSecureRequest<List<string>>(CredentialsProvider, HttpMethod.Delete, OrdersEndpoint);
        }

        [DataContract]
        private class OrderRequest
        {
            [DataMember(Name = "side")]
            public string OrderSide { get; set; }

            [DataMember(Name = "product_id")]
            public string ProductId { get; set; }

            [DataMember(Name = "type")]
            public string OrderType { get; set; }

            [DataMember(Name = "client_oid")]
            public Guid? ClientOrderId { get; set; }

            [DataMember(Name = "stp")]
            public string SelfTradePreventionFlag { get; set; }

            [DataMember(Name = "time_in_force")]
            public string TimeInForceFlag { get; set; }

            [DataMember(Name = "price")]
            public decimal? Price { get; set; }

            [DataMember(Name = "size")]
            public decimal? Size { get; set; }

            [DataMember(Name = "post_only")]
            public bool PostOnly { get; set; }
        }
    }
}