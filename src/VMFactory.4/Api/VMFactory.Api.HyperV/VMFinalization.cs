using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using VMFactory.Api.Core.Configuration;

namespace VMFactory.Api.HyperV
{
    /// <summary>
    /// Helper class used for Finalizing a VM Request.
    /// Use this class to help process, package, drop and notify
    /// necessary parties of a vm finalization task.
    /// </summary>
    public class VMFinalization
    {
        /// <summary>
        /// Call that locates the .vhd associated with a Virtual Machine, compresses it, and then drops it to a location.
        /// </summary>
        /// <param name="id">Guid of the Virtual Machine.</param>
        /// <param name="dropLocation">Location to drop the result to.</param>
        /// <param name="sizeOfEachVolume">Size in Megabytes for each volume.  Pass 0 for a single volume.</param>
        /// <param name="processingLocation">Optional.  Location to copy the .vhd to prior to compression.</param>
        /// <param name="usersToEmail">Optional.  List of users to send emails to.</param>
        /// <returns></returns>
        public bool FinalizeVM( String vmName, String dropLocation, long sizeOfEachVolume, String processingLocation = null, ICollection<String> usersToEmail = null) { HyperVPsInterface hyperVInterface = new HyperVPsInterface();  string vhdPath = hyperVInterface.GetVHDPath(vmName); if (String.IsNullOrEmpty(vhdPath)) { return false; }  Console.WriteLine(string.Format("VHD location: {0}", vhdPath));  if (!CompressVHD(vhdPath, dropLocation, vmName + ".7z", sizeOfEachVolume)) { return false; }  return true; } 
        /// <summary>
        /// compresses a file
        /// </summary>
        /// <param name="vhdPath">path to the file</param>
        /// <param name="dropLocation">location to copy the result to</param>
        /// <param name="sizeOfEachVolume">size in Megabytes for each volume.  Pass 0 for a single volume.</param>
        /// <returns></returns>
        private bool CompressVHD( string vhdPath, string dropLocation, string compressedFileName, long sizeOfEachVolume) {  if (Directory.Exists(dropLocation)) { DirectoryInfo directoryInfo = new DirectoryInfo(dropLocation); try { directoryInfo.Delete(true); } catch (Exception exception) { Console.WriteLine(string.Format("Error removing drop location '{0}'\n{1}\n{2}", dropLocation, exception.Message, exception.StackTrace)); } }  ProcessStartInfo procInfo = new ProcessStartInfo(); procInfo.FileName = ".\\Finalization\\7za.exe"; StringBuilder sBuilder = new StringBuilder(); sBuilder.Clear();  sBuilder.Append("a \"" + dropLocation +  compressedFileName + "\" \"" + vhdPath + "\" ");  if (sizeOfEachVolume > 0) { sizeOfEachVolume *= 1048576; FileInfo fInfo = new FileInfo(vhdPath); long numberOfVolumes = fInfo.Length / sizeOfEachVolume; long lastVolumeSize = fInfo.Length % sizeOfEachVolume; for (long i = numberOfVolumes; i > 0; i--) { sBuilder.Append(" -v" + sizeOfEachVolume + "b"); } sBuilder.Append(" -v" + lastVolumeSize + "b"); }  sBuilder.Append(" -mx=" + DefaultConfigurationStore.Current.VhdCompressionLevel.ToString()); sBuilder.Append(" -w\"" + DefaultConfigurationStore.Current.VhdSplitTempDropLocation + "\"");  procInfo.WindowStyle = ProcessWindowStyle.Hidden; procInfo.Arguments = sBuilder.ToString();  Console.WriteLine( string.Format( "{0} {1}", procInfo.FileName, procInfo.Arguments));  Process proc = Process.Start(procInfo); proc.WaitForExit();  return true; }

    }
}
