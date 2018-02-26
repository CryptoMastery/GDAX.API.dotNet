using CryptoMastery.GDAX.API.Contracts.Configuration;
using CryptoMastery.GDAX.API.PublicServices;

namespace CryptoMastery.GDAX.API.PrivateServices
{
    public class BasePrivateService : BasePublicService
    {
        protected readonly ICredentialsProvider CredentialsProvider;

        protected BasePrivateService(ICredentialsProvider credentialsProvider,
            IConnectionSettingsProvider connectionSettingsProvider) : base(
            connectionSettingsProvider)
        {
            CredentialsProvider = credentialsProvider;
        }
    }
}