using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoMastery.GDAX.API.Model;

namespace CryptoMastery.GDAX.API.Contracts.PrivateServices
{
    public interface IAccountsService
    {
        Task<List<Account>> GetAccountsAsync();

        Task<Account> GetAccountByIdAsync(Guid accountId);

        Task<List<AccountHold>> GetAccountHoldsAsync(Guid accountId);
    }
}