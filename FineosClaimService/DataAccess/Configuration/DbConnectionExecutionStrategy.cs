using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FineosClaimService.DataAccess.Configuration
{
     public class DbConnectionExecutionStrategy : DbExecutionStrategy
    {
        /// <summary>
        /// The default retry limit is 5, which means that the total amount of time spent 
        /// between retries is 26 seconds plus the random factor.
        /// </summary>
        public DbConnectionExecutionStrategy()
        {
        }

        /// <summary>
        /// Creates a new instance of "DbConnectionExecutionStrategy" with the specified limits for
        /// number of retries and the delay between retries.
        /// </summary>
        /// <param name="maxRetryCount"> The maximum number of retry attempts. </param>
        /// <param name="maxDelay"> The maximum delay in milliseconds between retries. </param>
        public DbConnectionExecutionStrategy(int maxRetryCount, TimeSpan maxDelay)
            : base(maxRetryCount, maxDelay)
        {
        }

        protected override bool ShouldRetryOn(Exception ex)
        {
            bool retry = false;

            SqlException sqlException = ex as SqlException;
            if (sqlException != null)
            {
                int[] errorsToRetry =
                {
                    //https://docs.microsoft.com/en-us/azure/azure-sql/database/troubleshoot-common-errors-issues
                    1205,  //Deadlock
                    -2,    //Timeout
                    2601,  //primary key violation. Normally you wouldn't want to retry these, 
                          //but some procs in my database can cause it, because it's a crappy 
                          //legacy junkpile.
                   926, 4060, 40197, 40501, 40613, 49918, 49919, 49920, 4221
                };
                if (sqlException.Errors.Cast<SqlError>().Any(x => errorsToRetry.Contains(x.Number)))
                {
                    retry = true;
                }
                else
                {
                    //Add some error logging on this line for errors we aren't retrying.
                    //Make sure you record the Number property of sqlError. 
                    //If you see an error pop up that you want to retry, you can look in 
                    //your log and add that number to the list above.
                }
            }
            if (ex is TimeoutException)
            {
                retry = true;
            }
            return retry;
        }
    }
}