using System;
using System.Collections.Generic;
using VMFactory.Api.Core.Configuration;
using VMFactory.Api.HyperV;

namespace VMFactory.Prototype.Orchestrator.HyperV
{
    public static class HyperVHelper
    {




        /// <summary>
        /// Starts the vm.
        /// </summary>
        /// <param name="vmName">Name of the vm.</param>
        /// <returns></returns>
        public static bool StartVM(string vmName = null)
        {
            bool tResult = false;  try { Console.WriteLine("Starting - StartVM"); VMFactory.Api.HyperV.PsInterface psi = new PsInterface();  Dictionary<String, object> parameters = new Dictionary<string, object>();   parameters.Add("vmName", vmName);  psi.Command = PsOperation.StartVm;  psi.Parameters = parameters;  PsExecutionResult result = psi.Execute();  if (result.Success) { Console.WriteLine("Success!!"); Console.WriteLine(result.ResultMessage); } else { Console.WriteLine(result.ResultMessage); Console.WriteLine(result.Exception.Message); Console.WriteLine(result.Exception.StackTrace); }  tResult = true;  } catch (Exception e) { Console.WriteLine(String.Format("{0}\n{1}", e.Message, e.StackTrace));  tResult = false;  } finally { if (DefaultConfigurationStore.Current.RequestUserConfirmation) { Console.WriteLine("Finished. Press ENTER to exit"); Console.ReadLine(); } } return tResult;
        }

        /// <summary>
        /// Stops the vm.
        /// </summary>
        /// <param name="vmName">Name of the vm.</param>
        /// <returns></returns>
        public static bool StopVM(
            string vmName = null)
        {
            bool tResult = false;  try { Console.WriteLine("Starting - StopVM"); VMFactory.Api.HyperV.PsInterface psi = new PsInterface(); Dictionary<String, object> parameters = new Dictionary<string, object>();  parameters.Add("vmName", vmName); psi.Command = PsOperation.StopVm; psi.Parameters = parameters;  PsExecutionResult result = psi.Execute(); if (result.Success) { Console.WriteLine("Success!!"); Console.WriteLine(result.ResultMessage); } else { Console.WriteLine(result.ResultMessage); Console.WriteLine(result.Exception.Message); Console.WriteLine(result.Exception.StackTrace); }  tResult = true;  } catch (Exception e) { Console.WriteLine(String.Format("{0}\n{1}", e.Message, e.StackTrace)); tResult = false; } finally { if (DefaultConfigurationStore.Current.RequestUserConfirmation) { Console.WriteLine("Finished. Press ENTER to exit"); Console.ReadLine(); } } return tResult;
        }


        /// <summary>
        /// Stops the vm.
        /// </summary>
        /// <param name="vmName">Name of the vm.</param>
        /// <returns></returns>
        public static bool RemoveVM(     string vmName = null) 
        {
            bool tResult = false;  try { Console.WriteLine("Starting - RemoveVM"); VMFactory.Api.HyperV.PsInterface psi = new PsInterface();  Dictionary<String, object> parameters = new Dictionary<string, object>();   parameters.Add("vmName", vmName); psi.Command = PsOperation.RemoveVm; psi.Parameters = parameters;  PsExecutionResult result = psi.Execute(); if (result.Success) { Console.WriteLine("Success!!"); Console.WriteLine(result.ResultMessage); } else { Console.WriteLine(result.ResultMessage); Console.WriteLine(result.Exception.Message); Console.WriteLine(result.Exception.StackTrace); }  tResult = true;  } catch (Exception e) { Console.WriteLine(String.Format("{0}\n{1}", e.Message, e.StackTrace));  tResult = false;  } finally { if (DefaultConfigurationStore.Current.RequestUserConfirmation) { Console.WriteLine("Finished. Press ENTER to exit"); Console.ReadLine(); } } return tResult;
        }





        /// <summary>
        /// Copies the and import vm.
        /// </summary>
        /// <param name="baseVmName">Name of the base vm.</param>
        /// <param name="baseVmSourcePath">The base vm source path.</param>
        /// <param name="destinationFolder">The destination folder.</param>
        /// <param name="baseVmConfigFile">The base vm configuration file.</param>
        /// <param name="newVmName">New name of the vm.</param>
        public static void CopyAndImportVM( string baseVmName, string baseVmSourcePath, string destinationFolder, string baseVmConfigFile, string newVmName)
        {
            try { Console.WriteLine("Starting - VMCopyAndImportVM"); VMFactory.Api.HyperV.PsInterface psi = new PsInterface(); Dictionary<String, object> parameters = new Dictionary<string, object>();  parameters.Add("Source", baseVmSourcePath); parameters.Add("Destination", destinationFolder); parameters.Add("VMPath", baseVmConfigFile); parameters.Add("vmName", newVmName); parameters.Add("VMBaseName", baseVmName);  psi.Command = PsOperation.VMCopyAndImport; psi.VmName = "MyTestVm"; psi.Parameters = parameters;  PsExecutionResult result = psi.Execute();                 if (result.Success) { Console.WriteLine("Success!!"); Console.WriteLine(result.ResultMessage); } else { Console.WriteLine(result.ResultMessage); Console.WriteLine(result.Exception.Message); Console.WriteLine(result.Exception.StackTrace); } } catch (Exception e) { Console.WriteLine(String.Format("{0}\n{1}", e.Message, e.StackTrace)); } finally { if (DefaultConfigurationStore.Current.RequestUserConfirmation) { Console.WriteLine("Finished. Press ENTER to exit"); Console.ReadLine(); } }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="driveLetter"></param>
        /// <param name="dismPath"></param>
        /// <param name="vmName"></param>
        /// <param name="vmId"></param>
        /// <param name="vmStatusSvcUrl"></param>
        /// <param name="cfgFileName"></param>
        /// <returns></returns>
        public static bool PreLoadVHDBootData( string driveLetter, string dismPath, string vmName, string vmId, string vmStatusSvcUrl, string cfgFileName )
        {
            bool tResult = false;  try { Console.WriteLine("Starting - PreLoadVHDBootData"); VMFactory.Api.HyperV.PsInterface psi = new PsInterface(); Dictionary<String, object> parameters = new Dictionary<string, object>();  parameters.Add("driveLetter", driveLetter); parameters.Add("dismPath", dismPath); parameters.Add("vmName", vmName); parameters.Add("vmId", vmId); parameters.Add("vmStatusSvcUrl", vmStatusSvcUrl); parameters.Add("cfgFileName", cfgFileName); psi.Command = PsOperation.PreLoadVHDBootData; psi.Parameters = parameters;  PsExecutionResult result = psi.Execute(); if (result.Success) { Console.WriteLine("Success!!"); Console.WriteLine(result.ResultMessage); } else { Console.WriteLine(result.ResultMessage); Console.WriteLine(result.Exception.Message); Console.WriteLine(result.Exception.StackTrace); } tResult = true;  }             catch (Exception e) { Console.WriteLine(String.Format("{0}\n{1}", e.Message, e.StackTrace));  tResult = false;  } finally { if (DefaultConfigurationStore.Current.RequestUserConfirmation) { Console.WriteLine("Finished. Press ENTER to exit"); Console.ReadLine(); } }              return tResult;
        }

    }
}
