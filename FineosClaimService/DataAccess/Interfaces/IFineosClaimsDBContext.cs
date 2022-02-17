using FineosClaimService.Models;
using System.Data.Entity;

namespace FineosClaimService.DataAccess.Interfaces
{
    public interface IFineosClaimsDBContext
    {
        DbSet<ClaimRequest> ClaimRequests { get; set; }
    }
}