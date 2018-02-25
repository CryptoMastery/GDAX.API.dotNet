namespace CryptoMastery.GDAX.API.Contracts.Configuration
{
    public class Credentials
    {
        public Credentials(string apiKey, string secret, string passPhrase)
        {
            ApiKey = apiKey;
            Secret = secret;
            PassPhrase = passPhrase;
        }

        public string ApiKey { get; }

        public string Secret { get; }

        public string PassPhrase { get; }
    }
}