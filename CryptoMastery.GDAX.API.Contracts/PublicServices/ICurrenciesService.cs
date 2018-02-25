using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoMastery.GDAX.API.Model;

namespace CryptoMastery.GDAX.API.Contracts.PublicServices
{
    public interface ICurrenciesService
    {
        Task<List<Currency>> GetCurrenciesAsync();
    }
}