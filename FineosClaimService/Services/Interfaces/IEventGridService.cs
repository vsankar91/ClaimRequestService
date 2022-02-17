using System.Threading.Tasks;

namespace FineosClaimService.Services.Interfaces
{
    public interface IEventGridService
    {
        Task TriggerEvent<T>(string subject, string eventType, T payload);
    }
}