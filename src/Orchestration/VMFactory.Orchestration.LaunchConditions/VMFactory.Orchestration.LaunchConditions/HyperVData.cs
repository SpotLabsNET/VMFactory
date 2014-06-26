using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Globalization;

namespace VMFactory.Orchestration.LaunchConditions
{
    public class HyperVData : IVMData
    {
        public int GetNumberOfRunningVMs(string servername, string username, string password)
        {           
            ConnectionOptions options = new ConnectionOptions();
            options.Username =username;
            options.Password = password;
            options.Authentication = AuthenticationLevel.PacketPrivacy;
            options.Impersonation = ImpersonationLevel.Impersonate;
            //ManagementScope scope =
                //new ManagementScope("\\\\" + servername + "\\root\\virtualization\\v2",options);

            ManagementScope scope =
               new ManagementScope("\\\\" + servername + "\\root\\virtualization\\v2");


            string vmQueryWql = string.Format(CultureInfo.InvariantCulture,
           "SELECT * FROM Msvm_ComputerSystem WHERE EnabledState=2");

            SelectQuery vmQuery = new SelectQuery(vmQueryWql);

            using (ManagementObjectSearcher vmSearcher = new ManagementObjectSearcher(scope, vmQuery))
            using (ManagementObjectCollection vmCollection = vmSearcher.Get())
            {                
                return vmCollection.Count-1;                
            }

        }
    }
}
