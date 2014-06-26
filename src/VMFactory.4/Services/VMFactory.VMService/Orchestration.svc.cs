using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Collections.ObjectModel;


namespace VMFactory.VMService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Orchestration" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Orchestration.svc or Orchestration.svc.cs at the Solution Explorer and start debugging.
    public class Orchestration : IOrchestration
    {

        /// <summary>
        /// Starts the vm.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public StartVmResponse StartVm(StartVmRequest request)
        {
            StartVmResponse response = new StartVmResponse();

            // add code here

            return response;
        }

        /// <summary>
        /// Shutdowns the VM.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public ShutdownVMResponse ShutdownVM(ShutdownVMRequest request)
        {
            ShutdownVMResponse response = new ShutdownVMResponse();

            // add code here

            return response;
        
        }

        /// <summary>
        /// Packs the VM.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public PackVMResponse PackVM(PackVMRequest request)
        {
            PackVMResponse response = new PackVMResponse();

            return response;
        
        }

    
    }
}
