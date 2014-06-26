using System.Globalization;
using System.Management;

namespace VMFactory.Orchestration.LaunchConditions
{
    public class HyperVData : IVMData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="servername"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int GetNumberOfRunningVMs( string servername, string username, string password) { ConnectionOptions options = new ConnectionOptions(); options.Username =username; options.Password = password; options.Authentication = AuthenticationLevel.PacketPrivacy; options.Impersonation = ImpersonationLevel.Impersonate;  ManagementScope scope = new ManagementScope("\\\\" + servername + "\\root\\virtualization\\v2");   string vmQueryWql = string.Format( CultureInfo.InvariantCulture, "SELECT * FROM Msvm_ComputerSystem WHERE EnabledState = 2");  SelectQuery vmQuery = new SelectQuery(vmQueryWql);  using (ManagementObjectSearcher vmSearcher = new ManagementObjectSearcher(scope, vmQuery)) using (ManagementObjectCollection vmCollection = vmSearcher.Get()) { return vmCollection.Count-1; }  }
    }
}
