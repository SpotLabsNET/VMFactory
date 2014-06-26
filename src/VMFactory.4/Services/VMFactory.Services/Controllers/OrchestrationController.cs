using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VMFactory.Services.Common;
using VMFactory.Services.Common.Entity;

namespace VMFactory.Services.Controllers
{
    public class OrchestrationController : ApiController
    {
        public VirtualMachineRequest  RequestVirtualMachine()
        {
            //QUESTION: what should we be passing in to create a new virtual machine?

            //sample vm request
            return new VirtualMachineRequest()
            {
                Id = new Guid(),
                StartedOn = DateTime.Now.AddSeconds(-20),
                Status = RequestStatus.Queued
            };
        }



        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <param name="vmRequestId">The vm request id.</param>
        /// <returns></returns>
        public VirtualMachineRequest GetStatus(string vmRequestId)
        {
            //do a lookup and find the vm request
            var vmRequest = new VirtualMachineRequest()
            {
                Id = new Guid(vmRequestId)
            };
            return GetStatus(vmRequest);
        }



        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <param name="vmRequest">The vm request.</param>
        /// <returns></returns>
        public VirtualMachineRequest GetStatus(VirtualMachineRequest vmRequest)
        {
            //get the status of the request being passed in
            return vmRequest;
        }
    }
}
