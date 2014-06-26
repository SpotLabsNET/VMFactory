using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using VMFactory.Api.HyperV;

namespace VMFactory.Services.Common.Finalization
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
        public bool FinalizeVM(Guid id, String dropLocation, long sizeOfEachVolume, String processingLocation = null, ICollection<String> usersToEmail = null)
        {
            HyperVPsInterface hyperVInterface = new HyperVPsInterface();
            //TODO: refacture 
            //string vhdPath = hyperVInterface.GetVHDPath(id);
            //if (String.IsNullOrEmpty(vhdPath))
            //{
            //    return false;
            //}
            //if (!compressVHD(vhdPath, dropLocation, sizeOfEachVolume))
            //{
            //    return false;
            //}
            ////email users
            return true;
        }

        /// <summary>
        /// compresses a file
        /// </summary>
        /// <param name="vhdPath">path to the file</param>
        /// <param name="dropLocation">location to copy the result to</param>
        /// <param name="sizeOfEachVolume">size in Megabytes for each volume.  Pass 0 for a single volume.</param>
        /// <returns></returns>
        private bool compressVHD(string vhdPath, string dropLocation, long sizeOfEachVolume)
        {

            ProcessStartInfo procInfo = new ProcessStartInfo();
            procInfo.FileName = ".\\Finalization\\7za.exe";
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Clear();
            sBuilder.Append("a");
            
            if (sizeOfEachVolume > 0)
            {
                sizeOfEachVolume *= 1048576;//bytes in a megabyte
                FileInfo fInfo = new FileInfo(vhdPath);
                long numberOfVolumes = fInfo.Length / sizeOfEachVolume;
                long lastVolumeSize = fInfo.Length % sizeOfEachVolume;
                for (long i = numberOfVolumes; i > 0; i--)
                {
                    sBuilder.Append("-v" + sizeOfEachVolume + "m");
                }
                sBuilder.Append("-v" + lastVolumeSize + "m");
            }

            sBuilder.Append("\"" + dropLocation + "\" \"" + vhdPath + "\" -mx=9");
            
            procInfo.WindowStyle = ProcessWindowStyle.Hidden;

            Process proc = Process.Start(procInfo);
            proc.WaitForExit();

            return true;
        }

    }
}
