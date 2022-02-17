using FineosClaimService.DataAccess;
using FineosClaimService.Models;
using FineosClaimService.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace FineosClaimService.Repositories
{
    public class ClaimRequestRepository : IClaimRequestRepository
    {
        private readonly FineosClaimsDBContext _dbContext;

        public ClaimRequestRepository(FineosClaimsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ClaimRequest> AddClaimRequestAsync(ClaimRequest claimRequest)
        {
            try
            {
                var newRecord = _dbContext.ClaimRequests.Add(claimRequest);
                await _dbContext.SaveChangesAsync();
                return newRecord;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}