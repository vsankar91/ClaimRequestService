using FineosClaimService.DataAccess.Interfaces;
using FineosClaimService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FineosClaimService.DataAccess
{
    public class FineosClaimsDBContext : DbContext, IFineosClaimsDBContext
    {
        public FineosClaimsDBContext() : base("name=FineosClaimsDBConnectionString")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<FineosClaimsDBContext>());
        }

        public DbSet<ClaimRequest> ClaimRequests { get; set; }
    }
}