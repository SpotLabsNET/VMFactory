using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;

namespace VMFactory.Api.Core.Powershell
{
    public class PipelineExecutor
    {
        private static string scriptFolder = @".\PsScripts\";

        /// <summary>
        /// Runs the given powershell script and returns the script output.
        /// </summary>
        /// <param name="scriptText">the powershell script text to run</param>
        /// <returns>output of the script</returns>
        //public string RunScript(string scriptText)
        //{

        //    // create a pipeline and feed it the script text
        //    Pipeline pipeline = CreateRunspaceWithPipeline();
        //    pipeline.Commands.AddScript(scriptText);

        //    // add an extra command to transform the script output objects into nicely formatted strings
        //    // remove this line to get the actual objects that the script returns. For example, the script
        //    // "Get-Process" returns a collection of System.Diagnostics.Process instances.
        //    pipeline.Commands.Add("Out-String");

        //    // execute the script
        //    Collection<PSObject> results = pipeline.Invoke();

        //    // close the runspace
        //    pipeline.Runspace.Close();

        //    // convert the script result into a single string
        //    StringBuilder stringBuilder = new StringBuilder();
        //    foreach (PSObject obj in results)
        //    {
        //        stringBuilder.AppendLine(obj.ToString());
        //    }

        //    return stringBuilder.ToString();
        //}

        /// <summary>
        /// Runs the given powershell script and returns the script output.
        /// </summary>
        /// <param name="scriptText">the powershell script text to run</param>
        /// <returns>output of the script</returns>
        public string RunScriptReturnStr( string scriptText, Dictionary<String, object> parameters, InitialSessionState iss = null) { scriptText = string.Concat(scriptFolder, scriptText);  Pipeline pipeline = CreateRunspaceWithPipeline(iss);  Command scCmd = new Command(scriptText, false);  if (parameters != null && parameters.Count() > 0) { foreach (var parameter in parameters) { scCmd.Parameters.Add(null, parameter.Value.ToString()); } }  pipeline.Commands.Add(scCmd);  pipeline.Commands.Add("Out-String");  Collection<PSObject> results = pipeline.Invoke();  pipeline.Runspace.Close();  StringBuilder stringBuilder = new StringBuilder(); foreach (PSObject obj in results) { stringBuilder.AppendLine(obj.ToString()); } return stringBuilder.ToString(); } 
        /// <summary>
        /// Runs the given powershell script and returns the script output.
        /// THis script is only used by the finalization process and should be
        /// refactured to work at the remaining operations.
        /// </summary>
        /// <param name="scriptText">the powershell script text to run</param>
        /// <returns>output of the script</returns>
        public ICollection<PSObject> RunScript(string scriptPath, Dictionary<string, object> parameters = null, InitialSessionState iss = null) { Pipeline pipeline = CreateRunspaceWithPipeline(iss);  Command getVHD = new Command(VMFactory.Api.Core.Helper.Utils.ReadScriptAsString(scriptPath), true); if (null != parameters && parameters.Count() > 0) { foreach (var parameter in parameters) { getVHD.Parameters.Add(new CommandParameter(parameter.Key, parameter.Value)); } } pipeline.Commands.Add(getVHD);  ICollection<PSObject> results = pipeline.Invoke();  pipeline.Runspace.Close();  return results; } 

        /// <summary>
        /// Create powershell runspace with pipeline
        /// </summary>
        /// <param name="iss"></param>
        /// <returns></returns>
        private Pipeline CreateRunspaceWithPipeline( InitialSessionState iss = null)         { Runspace runspace; if (null != iss) runspace = RunspaceFactory.CreateRunspace(iss); else runspace = RunspaceFactory.CreateRunspace(); runspace.Open();  RunspaceInvoke runSpaceInvoker = new RunspaceInvoke(runspace); runSpaceInvoker.Invoke("Set-ExecutionPolicy RemoteSigned -Scope Process");  Pipeline pipeline = runspace.CreatePipeline();  return pipeline; } 
    }
}



