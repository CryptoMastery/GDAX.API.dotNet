namespace CryptoMastery.GDAX.API.Contracts.Configuration
{
    public interface ICredentialsProvider
    {
        string ApiKey { get; }

        string Secret { get; }

        string PassPhrase { get; }
    }
}