using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoMastery.GDAX.API.Model;

namespace CryptoMastery.GDAX.API.Contracts.PrivateServices
{
    public interface IFillsService
    {
        Task<List<Fill>> GetFillsAsync(Guid orderId);
    }
}