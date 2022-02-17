using FineosClaimService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace FineosClaimService.ServiceContracts.Interfaces
{
    [ServiceContract]
    public interface IClaimService
    {

        [OperationContract]
        Task<ClaimRequest> AddClaimRequest(ClaimRequest claimRequest);

    }

}
