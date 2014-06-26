using System.ServiceModel;
using VMFactory.Api.Business.Entity;

namespace VMFactory.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IVMRequestManagement" in both code and config file together.
    [ServiceContract(Namespace="http://VMFactory.Services")]
    public interface IVMRequestManagement
    {
        [OperationContract]
        void UpdateStatus(
            long id, 
            RequestStatus newStatus, 
            string additionalLogInfo);

        [OperationContract]
        VirtualMachineRequest Get(long id);

        /*
        [OperationContract]
        void Create(VirtualMachineRequest request);
        */
    }
}
