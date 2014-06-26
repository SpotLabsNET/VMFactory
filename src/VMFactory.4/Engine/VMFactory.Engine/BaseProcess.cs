using System;
using System.Text;
using VMFactory.Api.Business.Entity;

namespace VMFactory.Engine
{


    /// <summary>
    /// base class for the processing of the VM Request
    /// 
    /// </summary>
    public sealed class BaseProcess
    {

        
        private ProcessResult Result { get; set;}
        
        VirtualMachineRequest VMRequest  { get; set;}
        
        private StringBuilder _ProcessLog = new StringBuilder(); StringBuilder ProcessLog { get { return _ProcessLog; } } 
        


        private BaseProcess() { this.Result = new ProcessResult(); this.Result.CurrentStatus = ProcessStatus.Running; this.VMRequest = new VirtualMachineRequest(); } 


        public void Execute() { while (Result.CurrentStatus == ProcessStatus.Running) { if (IsReadyForExecution()) { Console.WriteLine("Get next virtual machine request"); VMRequest = VirtualMachine.GetNextVirtualMachineRequest();  if (VMRequest == null) { Console.WriteLine("No request to process!"); System.Threading.Thread.Sleep(10000); this.Result.CurrentStatus = ProcessStatus.Finished; } else { if (VMRequest.Status == RequestStatus.None) { this._ProcessLog.Append(String.Format("Loaded request: ID [{0}], Requester [{1}], Requested on [{2}], Current Time [{3}]", VMRequest.Id, VMRequest.RequestedBy, VMRequest.RequestedOn, DateTime.UtcNow)); }  if (VMRequest.IsValid) { this._ProcessLog.Append("Request is valid."); ProcessRequest();  this._ProcessLog.Append("Request processing is complete.");  } else { this._ProcessLog.Append("Request is invalid."); }                     }                 } else { AbortExecution();  }             }   }         

        private bool IsReadyForExecution() { bool result = true;  Console.WriteLine("Validate conditions to run application");  return result; } 

        private void AbortExecution() { this.Result.IsRunning = false; this.Result.CurrentStatus = ProcessStatus.InvalidProcessorStatus; this.Result.ErrorMessages.Add("Processor is not ready for execution. Probable cause: resource depletion. ");  } 

        /// <summary>
        /// Processes the VM Requests.
        /// </summary>
        private void ProcessRequest() {  VMRequest.Status = RequestStatus.InProgress; VMRequest.Save();  try { } catch { VMRequest.Status = RequestStatus.Failed; VMRequest.Save(); }  }       

        static BaseProcess current = new BaseProcess();

        public static BaseProcess Current { get { return current; } } 

    }
}
