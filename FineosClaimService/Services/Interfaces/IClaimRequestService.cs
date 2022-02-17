using FineosClaimService.Models;
using System.Threading.Tasks;

namespace FineosClaimService.Services.Interfaces
{
    public interface IClaimRequestService
    {
        Task<ClaimRequest> AddClaimRequestAsync(ClaimRequest claimRequest);
    }
}