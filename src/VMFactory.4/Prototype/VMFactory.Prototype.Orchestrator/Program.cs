using System;
using System.Linq;
using System.Threading;
using VMFactory.Api.Business.Entity;
using VMFactory.Api.Core.Configuration;
using VMFactory.Api.Data.Models;
using VMFactory.Prototype.Orchestrator.Operations;


namespace VMFactory.Prototype.Orchestrator
{
    class Program
    {
        
        static void Main(string[] args)
        {
             Console.WriteLine(string.Format("{0}: VM Factory Orchestration Simulator", DateTime.UtcNow)); Console.WriteLine(string.Format("{0}: Hit CRT+C to exit.", DateTime.UtcNow));  bool isCriticalException = false;  while (true) {  using (VMFSupportContext db = new VMFSupportContext()) {  try { Console.WriteLine(string.Format("\n{0}: Checking request queue.", DateTime.UtcNow)); var queuedVms = db.VMRequests.Where(c => (c.RequestStatus == null || c.RequestStatus == (int)RequestStatus.None || c.RequestStatus == (int)RequestStatus.InstallationCompleted)); if (queuedVms.Count() > 0) {  Console.WriteLine(string.Format("{1}: Found {0} VMs queued.", queuedVms.Count(), DateTime.UtcNow)); VMRequest vmToProcess = queuedVms.First(); if (vmToProcess.RequestStatus == (int)RequestStatus.None) { CreateVM.CreateVirtualMachine(vmToProcess, db); } if (vmToProcess.RequestStatus == (int)RequestStatus.InstallationCompleted) { Console.WriteLine( string.Format( "{2}: VM [{1}]({0}) ready for finalization", vmToProcess.Id, vmToProcess.DisplayName, DateTime.UtcNow)); DeployVM.DeployVirtualMachineForDownload(vmToProcess, db);  } } else { Console.WriteLine(string.Format("{0}: No VMs on the queue!", DateTime.UtcNow)); Thread.Sleep(DefaultConfigurationStore.Current.WaitTimeBetweenCicles * 1000); } }                     catch (InvalidOperationException ioe) { Console.WriteLine(string.Format("{0}: Failed! Exception detail bellow.", DateTime.UtcNow));  Console.WriteLine( string.Format( "{2}: Processing Error \n {0} \n {1}", ioe.Message, ioe.StackTrace, DateTime.UtcNow)); isCriticalException = true; }                     catch (Exception ex) { Console.WriteLine( string.Format( "{2}: Processing Error \n {0} \n {1}", ex.Message, ex.StackTrace, DateTime.UtcNow)); } finally { } if (isCriticalException) { Console.WriteLine(string.Format("{0}: Critical error found. Operation stopped. Press <RETURN> to exit.", DateTime.UtcNow)); if (DefaultConfigurationStore.Current.RequestUserConfirmation) Console.ReadLine(); return; } Thread.Sleep(10000); }             }
        }

    }

}
