using System.Net.Http;
using System.Threading.Tasks;
using CryptoMastery.GDAX.API.Contracts.Configuration;

namespace CryptoMastery.GDAX.API.Contracts.Client
{
    public interface IServiceClient
    {
        Task<TResponse> InvokeRequest<TResponse>(HttpMethod method, string urlTemplate, params object[] args);

        Task<TResponse> InvokeSecureRequest<TResponse>(Credentials credentials, HttpMethod method, string urlTemplate,
            params object[] args);

        Task<TResponse> InvokeSecureRequestWithBody<TRequest, TResponse>(Credentials credentials, HttpMethod method,
            string urlTemplate, TRequest requestBodyObject, params object[] args);
    }
}