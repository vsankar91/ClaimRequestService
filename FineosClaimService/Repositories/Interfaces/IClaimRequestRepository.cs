using FineosClaimService.Models;
using System.Threading.Tasks;

namespace FineosClaimService.Repositories.Interfaces
{
    public interface IClaimRequestRepository
    {
        Task<ClaimRequest> AddClaimRequestAsync(ClaimRequest claimRequest);
    }
}