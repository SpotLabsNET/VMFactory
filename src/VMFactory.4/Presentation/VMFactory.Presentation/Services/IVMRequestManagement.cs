using System.ServiceModel;
using VMFactory.Api.Business.Entity;

namespace VMFactory.Presentation.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IVMRequestManagement" in both code and config file together.
    [ServiceContract]
    public interface IVMRequestManagement
    {
        [OperationContract]
        void UpdateStatus(long id, RequestStatus newStatus);
    }
}
