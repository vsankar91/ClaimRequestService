using System.Threading.Tasks;

namespace FineosClaimService.Services.Interfaces
{
    public interface IServiceBusMessagingService
    {
        Task SendMessageAsync<T>(T payload);
    }
}