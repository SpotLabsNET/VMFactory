using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Runspaces;
using VMFactory.Api.Core.Exceptions;
using VMFactory.Api.Core.Powershell;


namespace VMFactory.Api.HyperV
{
    public class PsInterface
    {



        #region Properties
        private InitialSessionState _iss = InitialSessionState.CreateDefault();

        private PsOperation _Command = PsOperation.None;
        /// <summary>
        /// Gets or sets the PowerShell command to be executed.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        public PsOperation Command { get { return _Command; }  set { _Command = value; }  }


        private string _VmName = string.Empty;
        /// <summary>
        /// Gets or sets the name of the vm.
        /// </summary>
        /// <value>
        /// The name of the vm.
        /// </value>
        public string VmName { get { return _VmName; }  set { _VmName = value; }  }


        private Dictionary<String, object> _Parameters = new Dictionary<string, object>();
        /// <summary>
        /// Gets or sets the parameters to pass to the PowerShell script.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        public Dictionary<String, object> Parameters { get { return _Parameters; }  set { _Parameters = value; } }



        #endregion


        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PsInterface"/> class.
        /// </summary>
        public PsInterface() { this._iss = InitialSessionState.CreateDefault(); _iss.ImportPSModule(new string[] { "Hyper-V" }); }


        /// <summary>
        /// Initializes a new instance of the <see cref="PsInterface"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="vmName">Name of the vm.</param>
        public PsInterface(PsOperation command, string vmName) { this.Command = command; this.VmName = vmName; }

        #endregion



        /// <summary>
        /// Executes this instance.
        /// </summary>
        /// <returns></returns>
        public PsExecutionResult Execute() {  PsExecutionResult result = new PsExecutionResult(); PipelineExecutor pexec = new PipelineExecutor(); string opResult = string.Empty;  try { result.ResultMessage = pexec.RunScriptReturnStr((HyperV.Definitions.HypervCommands[(int)this.Command]).ToString(), this._Parameters, this._iss); result.Success = true; }             catch (Exception ex) { result.Success = false; result.ResultMessage = string.Format("Error executing the command {0} for the VM {1} with the parameters {2}", this.Command.ToString(), this._VmName, string.Join(",", _Parameters.Select(kv => kv.Key.ToString() + "=" + kv.Value.ToString()).ToArray())); result.Exception = ex; ExceptionManager.HandleException(ex); }             finally { pexec = null; } return result;  }



    }
}
