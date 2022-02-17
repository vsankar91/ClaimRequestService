using FineosClaimService.Models;
using FineosClaimService.Repositories.Interfaces;
using FineosClaimService.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace FineosClaimService.Services
{
    public class ClaimRequestService : IClaimRequestService
    {

        private readonly IClaimRequestRepository _claimRequestRepository;

        public ClaimRequestService(IClaimRequestRepository claimRequestRepository)
        {
            _claimRequestRepository = claimRequestRepository;
        }

        public async Task<ClaimRequest> AddClaimRequestAsync(ClaimRequest claimRequest)
        {
            try
            {
                var result = await _claimRequestRepository.AddClaimRequestAsync(claimRequest);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}