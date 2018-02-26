using System;
using CryptoMastery.GDAX.API.Contracts.Configuration;

namespace CryptoMastery.GDAX.API.Sample
{
    public class SampleCredentailsProvider : ICredentialsProvider
    {
        public SampleCredentailsProvider()
        {
            var apiKey = Environment.GetEnvironmentVariable("GDAX_API_KEY");
            if (string.IsNullOrEmpty(apiKey))
                throw new ApplicationException("GDAX_API_KEY environment variable is not set");

            var secret = Environment.GetEnvironmentVariable("GDAX_SECRET");
            if (string.IsNullOrEmpty(secret))
                throw new ApplicationException("GDAX_SECRET environment variable is not set");

            var passPhrase = Environment.GetEnvironmentVariable("GDAX_PASSPHRASE");
            if (string.IsNullOrEmpty(passPhrase))
                throw new ApplicationException("GDAX_PASSPHRASE environment variable is not set");

            ApiKey = apiKey;
            Secret = secret;
            PassPhrase = passPhrase;
        }

        public string ApiKey { get; }
        public string Secret { get; }
        public string PassPhrase { get; }
    }
}