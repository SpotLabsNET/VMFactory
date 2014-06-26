using System;
using VMFactory.Api.Business.Entity;

namespace VMFactory.Services
{

    public class VMRequestManagement : IVMRequestManagement
    {
        /// <summary>
        /// Update VMRequest status
        /// </summary>
        /// <param name="id">VMRequest id</param>
        /// <param name="newStatus">New status to associate to the VMRequest</param>
        /// <param name="additionalLogInfo">Additional log info</param>
        public void UpdateStatus(
            long id,
            VMFactory.Api.Business.Entity.RequestStatus newStatus,
            string additionalLogInfo)
        {

            VirtualMachineRequest vmRequest = new VirtualMachineRequest(id);

            vmRequest.Status = newStatus;
            vmRequest.ProcessLog = additionalLogInfo;

            /*
            if (!string.IsNullOrEmpty(additionalLogInfo))
            {
                if (string.IsNullOrEmpty(vmRequest.ProcessLog))
                    vmRequest.ProcessLog = additionalLogInfo;
                else
                    vmRequest.ProcessLog += string.Format("\n{0}", additionalLogInfo);
            }
            */

            bool result = vmRequest.Save();

            if (result == false)
                throw new Exception("Unable to update information!");

        }


        public VirtualMachineRequest Get(long id)
        {
            return new VirtualMachineRequest(id);
        }

        /*
        public void Create(VirtualMachineRequest request)
        {
            throw new NotImplementedException();
        }
        */
    }
}
