namespace FineosClaimService
{
    public interface IConfiguration
    {
        string ServiceBusConnectionString { get; }

        string ClaimRequestQeueName { get; }

        string ClaimRequestTopicEndPoint { get; }

        string ClaimRequestTopicAccessKey { get; }
    }
}