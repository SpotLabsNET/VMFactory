using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace VMFactory.VMService
{

    public class VirtualMachineFactory : IVirtualMachineFactory
    {


        /// <summary>
        /// Requests the virtual machine.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public CreateVirtualMachineResponse RequestVirtualMachine(CreateVirtualMachineRequest request)
        { 
            CreateVirtualMachineResponse response = new CreateVirtualMachineResponse();

            return response;
        }


        /// <summary>
        /// Gets the virtual machine info.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public GetVirtualMachineInfoResponse GetVirtualMachineInfo(GetVirtualMachineInfoRequest request)
        {
            GetVirtualMachineInfoResponse response = new GetVirtualMachineInfoResponse();

            return response;

        }


    }
}
