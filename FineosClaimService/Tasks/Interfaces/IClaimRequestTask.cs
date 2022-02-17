using FineosClaimService.Models;
using System.Threading.Tasks;

namespace FineosClaimService.Tasks.Interfaces
{
    public interface IClaimRequestTask
    {
        Task<ClaimRequest> AddClaimRequestAsync(ClaimRequest claimRequest);
    }
}