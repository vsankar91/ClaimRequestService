using FineosClaimService.Models;
using FineosClaimService.Services.Interfaces;
using FineosClaimService.Tasks.Interfaces;
using System;
using System.Threading.Tasks;

namespace FineosClaimService.Tasks
{
    public class ClaimRequestTask : IClaimRequestTask
    {
        private readonly IClaimRequestService _claimRequestService;
        private readonly IEventGridService _eventGridService;

        public ClaimRequestTask(IClaimRequestService claimRequestService,
            IEventGridService eventGridService)
        {
            _claimRequestService = claimRequestService;
            _eventGridService = eventGridService;
        }

        public async Task<ClaimRequest> AddClaimRequestAsync(ClaimRequest claimRequest)
        {
            try
            {
                var addedClaimrequest = await _claimRequestService.AddClaimRequestAsync(claimRequest);
                await _eventGridService.TriggerEvent("ClaimRequest", "Created", addedClaimrequest);
                return addedClaimrequest;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}