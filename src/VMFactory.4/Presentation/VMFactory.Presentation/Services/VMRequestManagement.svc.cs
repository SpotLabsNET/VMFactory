using VMFactory.Api.Business.Entity;

namespace VMFactory.Presentation.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "VMRequestManagement" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select VMRequestManagement.svc or VMRequestManagement.svc.cs at the Solution Explorer and start debugging.
    public class VMRequestManagement : IVMRequestManagement
    {

        /// <summary>
        /// Update VMRequest status
        /// </summary>
        /// <param name="id">VMRequest id</param>
        /// <param name="newStatus">New status to associate to the VMRequest</param>
        public void UpdateStatus( long id, VMFactory.Api.Business.Entity.RequestStatus newStatus) { VirtualMachineRequest vmRequest = new VirtualMachineRequest(id);  vmRequest.Status = newStatus;  vmRequest.Save(); }
    }
}
