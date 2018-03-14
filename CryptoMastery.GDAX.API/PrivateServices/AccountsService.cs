using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoMastery.GDAX.API.Contracts.Configuration;
using CryptoMastery.GDAX.API.Contracts.PrivateServices;
using CryptoMastery.GDAX.API.Model;

namespace CryptoMastery.GDAX.API.PrivateServices
{
    public class AccountsService : BasePrivateService, IAccountsService
    {
        private const string GetAccountsEndpoint = "/accounts";
        private const string GetAccountByIdEndpoint = "/accounts/{0}";
        private const string GetAccountHoldsEndpoint = "/accounts/{0}/holds";

        public AccountsService(ICredentialsProvider credentialsProvider,
            IConnectionSettingsProvider connectionSettingsProvider)
            : base(credentialsProvider, connectionSettingsProvider)
        {
        }

        public async Task<List<Account>> GetAccountsAsync()
        {
            return await Client.InvokeSecureRequest<List<Account>>(CredentialsProvider, HttpMethod.Get,
                GetAccountsEndpoint);
        }

        public async Task<Account> GetAccountByIdAsync(Guid accountId)
        {
            return await Client.InvokeSecureRequest<Account>(CredentialsProvider, HttpMethod.Get,
                GetAccountByIdEndpoint,
                accountId);
        }

        public async Task<List<AccountHold>> GetAccountHoldsAsync(Guid accountId)
        {
            return await Client.InvokeSecureRequest<List<AccountHold>>(CredentialsProvider, HttpMethod.Get,
                GetAccountHoldsEndpoint,
                accountId);
        }
    }
}