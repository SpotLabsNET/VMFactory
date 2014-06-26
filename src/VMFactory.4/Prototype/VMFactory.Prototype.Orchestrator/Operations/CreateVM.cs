using System;
using System.Linq;
using System.Threading;
using VMFactory.Api.Business.Entity;
using VMFactory.Api.Core.Configuration;
using VMFactory.Api.Data.Models;
using VMFactory.Orchestration.LaunchConditions;
using VMFactory.Prototype.Orchestrator.HyperV;

namespace VMFactory.Prototype.Orchestrator.Operations
{
    public class CreateVM
    {


        public static void CreateVirtualMachine(VMRequest vmToProcess, VMFSupportContext db)
        {


            #region Start VM Creation process

            #region Lauch conditions
            // Check for launch conditions
            Console.WriteLine("Checking for launch conditions.");

            // Call the lauunch checker module
            bool readyToLounch = false;
            ValidateLaunch launchValidator = new ValidateLaunch();
            readyToLounch = launchValidator.VerifyLaunchConditions();
            Console.WriteLine("Completed with the result [{0}]", readyToLounch.ToString());

            // dump the screen info
            Console.WriteLine("Checking lounch conditions: {0}", "<TBD> Lounch conditions status");

            #endregion

            if (readyToLounch) {  Console.WriteLine(String.Format("Reserving VM request : {0} ({1})", vmToProcess.MachineName, vmToProcess.Id));  vmToProcess.RequestStatus = (int)RequestStatus.Queued; vmToProcess.ProcessLog = "";  var valErrors = db.GetValidationErrors();  if (valErrors.Count() > 0) { foreach (var valErr in valErrors) { foreach (var valerrCol in valErr.ValidationErrors) { Console.WriteLine(String.Format("Validation errors on update: {0} - {1}", valerrCol.PropertyName, valerrCol.ErrorMessage)); } } } else    db.SaveChanges();  Console.WriteLine(String.Format("Calling the StartProcess for VM : {0} ({1})", vmToProcess.MachineName, vmToProcess.Id)); vmToProcess.RequestStatus = (int)RequestStatus.InProgress; vmToProcess.ProcessLog = "Copying and importing base VM."; db.SaveChanges();   string baseVmSourcePath = DefaultConfigurationStore.Current.BaseVmSourcePath; string destinationFolder = vmToProcess.DestinationFolder;  string baseVmConfigFile = DefaultConfigurationStore.Current.BaseVmConfigFilePath.Replace(baseVmSourcePath, destinationFolder); string newVmName = vmToProcess.DisplayName; string baseVmName = DefaultConfigurationStore.Current.BaseVmName; HyperVHelper.CopyAndImportVM( baseVmName, baseVmSourcePath, destinationFolder, baseVmConfigFile, newVmName);  vmToProcess.ProcessLog = "Preloading boot data."; db.SaveChanges();  string driveLetter = DefaultConfigurationStore.Current.TemporaryDriveLetter; string dismPath = DefaultConfigurationStore.Current.DismPath; string vmId = vmToProcess.Id.ToString(); string vmStatusSvcUrl = DefaultConfigurationStore.Current.VmfStatusServiceUrl; string cfgFileName = DefaultConfigurationStore.Current.VmfConfigFile;  HyperVHelper.PreLoadVHDBootData( driveLetter, dismPath, vmToProcess.DisplayName, vmId, vmStatusSvcUrl, cfgFileName);  vmToProcess.ProcessLog = "Starting VM."; db.SaveChanges();  HyperVHelper.StartVM(vmToProcess.DisplayName);  Console.WriteLine(String.Format("Transferred control for MDT for VM: {0} ({1})", vmToProcess.MachineName, vmToProcess.Id));              }
            else { Console.WriteLine("No resources available at the moment. Skipping cycle");  Thread.Sleep(DefaultConfigurationStore.Current.WaitTimeBetweenCicles * 1000);  } 
            #endregion


        }




    }
}
