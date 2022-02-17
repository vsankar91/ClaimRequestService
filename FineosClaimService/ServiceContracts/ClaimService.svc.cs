using FineosClaimService.Models;
using FineosClaimService.Repositories.Interfaces;
using FineosClaimService.ServiceContracts.Interfaces;
using FineosClaimService.Tasks.Interfaces;
using System.Threading.Tasks;

namespace FineosClaimService.ServiceContracts
{
    public class ClaimService : IClaimService
    {
        private readonly IClaimRequestTask _claimRequestTask;

        public ClaimService(IClaimRequestTask claimRequestTask)
        {
            _claimRequestTask = claimRequestTask;
        }

        public async Task<ClaimRequest> AddClaimRequest(ClaimRequest claimRequest)
        {
            var addedClaimrequest = await _claimRequestTask.AddClaimRequestAsync(claimRequest);
            return addedClaimrequest;
        }
    }
}
