using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CryptoMastery.GDAX.API.Contracts.Configuration;
using Newtonsoft.Json;

namespace CryptoMastery.GDAX.API.Client
{
    public class ServiceClient : IServiceClient, IDisposable
    {
        private const string CbAccessKey = "CB-ACCESS-KEY";
        private const string CbAccessSign = "CB-ACCESS-SIGN";
        private const string CbAccessTimestamp = "CB-ACCESS-TIMESTAMP";
        private const string CbAccessPassphrase = "CB-ACCESS-PASSPHRASE";
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        private readonly HttpClient _httpClient;

        public ServiceClient(IConnectionSettingsProvider connectionSettingsProvider)
        {
            _httpClient = new HttpClient {BaseAddress = connectionSettingsProvider.BaseUri};
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "GDAX .NET Client");
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public async Task<TResponse> InvokeRequest<TResponse>(HttpMethod method, string urlTemplate,
            params object[] args)
        {
            using (var request = new HttpRequestMessage(method, FormatUri(urlTemplate, args)))
            using (var response = await _httpClient.SendAsync(request).ConfigureAwait(false))
            {
                var content = await CheckResponseAndGetRawContent(response).ConfigureAwait(false);
                return JsonConvert.DeserializeObject<TResponse>(content);
            }
        }

        public async Task<TResponse> InvokeSecureRequest<TResponse>(ICredentialsProvider credentialsProvider,
            HttpMethod method,
            string urlTemplate, params object[] args)
        {
            var url = FormatUri(urlTemplate, args);
            using (var request = new HttpRequestMessage(method, url))
            {
                SetHeadersForSecureRequest(request, credentialsProvider, method, url, string.Empty);
                using (var response = await _httpClient.SendAsync(request).ConfigureAwait(false))
                {
                    var content = await CheckResponseAndGetRawContent(response).ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<TResponse>(content);
                }
            }
        }

        public async Task<TResponse> InvokeSecureRequestWithBody<TRequest, TResponse>(
            ICredentialsProvider credentialsProvider,
            HttpMethod method, string urlTemplate, TRequest requestBodyObject, params object[] args)
        {
            var url = FormatUri(urlTemplate, args);
            using (var request = new HttpRequestMessage(method, url))
            {
                var body = JsonConvert.SerializeObject(requestBodyObject, JsonSerializerSettings);
                request.Content = new StringContent(body, Encoding.UTF8, "application/json");

                SetHeadersForSecureRequest(request, credentialsProvider, method, url, body);

                using (var response = await _httpClient.SendAsync(request).ConfigureAwait(false))
                {
                    var content = await CheckResponseAndGetRawContent(response).ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<TResponse>(content);
                }
            }
        }

        private static string FormatUri(string uriTemplate, params object[] args)
        {
            var url = string.Format(uriTemplate, args);
            return url;
        }

        private static async Task<string> CheckResponseAndGetRawContent(HttpResponseMessage response)
        {
            var responseContent = response.Content;

            if (responseContent == null) throw new WebException($"{response.StatusCode} / No Content");

            var rawContent = await responseContent.ReadAsStringAsync().ConfigureAwait(false);

            if (!response.IsSuccessStatusCode) throw new WebException($"{response.StatusCode}: {rawContent}");

            return rawContent;
        }

        private static long GetTimeStampInSecordsSinceUnixEpoch(DateTime currentTime)
        {
            return Convert.ToInt64((currentTime.ToUniversalTime() - Epoch).TotalSeconds);
        }

        private static string GenerateSignature(long timeStamp, HttpMethod method, string requestPath, string body,
            string secret)
        {
            var concatenatedString = $"{timeStamp}{method.ToString().ToUpper()}{requestPath}{body}";
            var concatenatedStringBytes = Encoding.UTF8.GetBytes(concatenatedString);
            var secretBytes = Convert.FromBase64String(secret);

            using (var hmac = new HMACSHA256(secretBytes))
            {
                return Convert.ToBase64String(hmac.ComputeHash(concatenatedStringBytes));
            }
        }

        private static void SetHeadersForSecureRequest(HttpRequestMessage request,
            ICredentialsProvider credentialsProvider,
            HttpMethod httpMethod, string url, string body)
        {
            var currentTime = DateTime.Now;
            var timeStamp = GetTimeStampInSecordsSinceUnixEpoch(currentTime);
            request.Headers.Add(CbAccessKey, credentialsProvider.ApiKey);
            request.Headers.Add(CbAccessPassphrase, credentialsProvider.PassPhrase);
            request.Headers.Add(CbAccessTimestamp, timeStamp.ToString());
            request.Headers.Add(CbAccessSign,
                GenerateSignature(timeStamp, httpMethod, url, body, credentialsProvider.Secret));
        }
    }
}