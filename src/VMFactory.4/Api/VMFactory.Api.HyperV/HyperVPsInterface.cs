using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using VMFactory.Api.Core.Powershell;


namespace VMFactory.Api.HyperV
{
    public class HyperVPsInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PsInterface"/> class.
        /// </summary>
        public HyperVPsInterface() { this._iss = InitialSessionState.CreateDefault(); _iss.ImportPSModule(new string[] { "Hyper-V" }); }

        private InitialSessionState _iss;


        public ICollection<PSObject> CreateVM() { throw new NotImplementedException(); }

        public ICollection<PSObject> StartVM() { throw new NotImplementedException(); }

        public ICollection<PSObject> RemoveVM() { throw new NotImplementedException(); }


        /// <summary>
        /// Get the vhd path for a given named vm
        /// </summary>
        /// <param name="vmName">Name of the VM</param>
        /// <returns></returns>
        public string GetVHDPath( string vmName) { PipelineExecutor pexec = new PipelineExecutor();  Dictionary<string, object> getVHDPathParameters = new Dictionary<string, object>(); getVHDPathParameters.Add("VMName", vmName);  ICollection<PSObject> results = pexec.RunScript(".\\PsScripts\\GetVHDPath.ps1", getVHDPathParameters, this._iss);  if (null != results && null != results.ElementAt(2))  return results.ElementAt(2).ToString();  return String.Empty; }
    }
}
