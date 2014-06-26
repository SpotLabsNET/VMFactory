using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using VMFactory.Api.Business.Entity;
using VMFactory.Api.Core.Configuration;
using VMFactory.Api.Data.Models;
using VMFactory.Api.HyperV;
using VMFactory.Prototype.Orchestrator.Email;
using VMFactory.Prototype.Orchestrator.HyperV;

namespace VMFactory.Prototype.Orchestrator.Operations
{
    public class DeployVM
    {

        public static void DeployVirtualMachineForDownload(VMRequest vmToProcess, VMFSupportContext db) {  Debug.WriteLine("VM [{1}]({0}) Shutting down.", vmToProcess.Id, vmToProcess.DisplayName); if (HyperVHelper.StopVM(vmToProcess.DisplayName)) { Debug.WriteLine("VM [{1}]({0}) Compressing", vmToProcess.Id, vmToProcess.DisplayName);  vmToProcess.RequestStatus = (int)RequestStatus.Packaging; vmToProcess.ProcessLog = "Compressing VHD file."; db.SaveChanges();  VMFinalization finalization = new VMFinalization();  Guid internalId = Guid.NewGuid();  string dropFolder = string.Format( DefaultConfigurationStore.Current.VhdSplitDropLocationTemplate, internalId);  if (finalization.FinalizeVM( vmToProcess.DisplayName, dropFolder, DefaultConfigurationStore.Current.VhdSplitBlockSize, null, null)) { Debug.WriteLine("VM [{1}]({0}) Updating request information", vmToProcess.Id, vmToProcess.DisplayName);  vmToProcess.RequestStatus = (int)RequestStatus.Deploying; vmToProcess.ProcessLog = "Deploying result."; db.SaveChanges(); vmToProcess.VMOutputs.Clear(); DirectoryInfo dirInfo = new DirectoryInfo(dropFolder);                     foreach (FileInfo file in dirInfo.GetFiles()) { VMOutput vmOut = new VMOutput(); vmOut.FileName = file.Name; vmOut.DownloadUrl = string.Concat(DefaultConfigurationStore.Current.BaseVmDownloadUrl, "/", internalId, "/", file.Name);  vmOut.VMRequest = vmToProcess; vmOut.VMRequestId = vmToProcess.Id; vmOut.VMTemplate = vmToProcess.VMTemplate; vmOut.VMTemplateId = vmToProcess.VMTemplate.Id; vmOut.CreatedOn = file.CreationTime.ToUniversalTime(); vmOut.LastModified = file.LastWriteTime;  vmOut.Log += "File added to the VM Output file list.";  vmToProcess.VMOutputs.Add(vmOut); } Debug.WriteLine("VM [{1}]({0}) Sending email to the user", vmToProcess.Id, vmToProcess.DisplayName); try { EmailHelper.SendConfirmationEmail( vmToProcess.DisplayName, vmToProcess.CreatedBy, vmToProcess.VMOutputs ); } catch (Exception ex) { Console.WriteLine("Processing Error (unable to send email alert) \n {0} \n {1}\n\n", ex.Message, ex.StackTrace); } vmToProcess.RequestStatus = (int)RequestStatus.ReadyForPickup; vmToProcess.ProcessLog = "Done.";  var valErrors = db.GetValidationErrors();                     if (valErrors.Count() > 0) { foreach (var valErr in valErrors) { foreach (var valerrCol in valErr.ValidationErrors) { Console.WriteLine("Validation errors on update: {0} - {1}", valerrCol.PropertyName, valerrCol.ErrorMessage); } } } else db.SaveChanges(); if (HyperVHelper.RemoveVM(vmToProcess.DisplayName)) { try { DirectoryInfo dir = new DirectoryInfo(vmToProcess.DestinationFolder); dir.Delete(true); } catch (Exception ex) { Console.WriteLine("Processing Error (unable to delete VM info) \n {0} \n {1}\n\npath: ", ex.Message, ex.StackTrace, vmToProcess.DestinationFolder); } } else { Console.WriteLine("Processing Error (unable to remove VM from Hyper-V)"); } } } else { Console.WriteLine("Unable to stop machine: {0}", vmToProcess.DisplayName); }   } 
    }
}
