using System.Data.Entity;

namespace FineosClaimService.DataAccess.Configuration
{
    class DbConnectionConfiguration : DbConfiguration
    {
        public DbConnectionConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new DbConnectionExecutionStrategy());
        }
    }
}