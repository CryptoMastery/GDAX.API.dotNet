using System.Net.Http;
using System.Threading.Tasks;
using CryptoMastery.GDAX.API.Contracts.Configuration;

namespace CryptoMastery.GDAX.API.Client
{
    public interface IServiceClient
    {
        Task<TResponse> InvokeRequest<TResponse>(HttpMethod method, string urlTemplate, params object[] args);

        Task<TResponse> InvokeSecureRequest<TResponse>(ICredentialsProvider credentialsProvider, HttpMethod method,
            string urlTemplate,
            params object[] args);

        Task<TResponse> InvokeSecureRequestWithBody<TRequest, TResponse>(ICredentialsProvider credentialsProvider,
            HttpMethod method,
            string urlTemplate, TRequest requestBodyObject, params object[] args);
    }
}