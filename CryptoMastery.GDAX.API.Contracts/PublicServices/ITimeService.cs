using System.Threading.Tasks;
using CryptoMastery.GDAX.API.Model;

namespace CryptoMastery.GDAX.API.Contracts.PublicServices
{
    public interface ITimeService
    {
        Task<Time> GetTimeAsync();
    }
}