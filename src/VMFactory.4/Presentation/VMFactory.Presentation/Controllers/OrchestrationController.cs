using System;
using System.Web.Http;
using VMFactory.Api.Business.Entity;

namespace VMFactory.Services.Controllers
{
    public class OrchestrationController : ApiController
    {
        public VirtualMachineRequest  RequestVirtualMachine() { return new VirtualMachineRequest() { CorrelationId = new Guid(), StartedOn = DateTime.UtcNow, Status = RequestStatus.Queued }; } 


        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <param name="vmRequestId">The vm request id.</param>
        /// <returns></returns>
        public VirtualMachineRequest GetStatus(string vmRequestId) { var vmRequest = new VirtualMachineRequest() { CorrelationId = new Guid(vmRequestId) }; return GetStatus(vmRequest); }



        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <param name="vmRequest">The vm request.</param>
        /// <returns></returns>
        public VirtualMachineRequest GetStatus(VirtualMachineRequest vmRequest) { return vmRequest; }     }
}
