using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMFactory.Orchestration.LaunchConditions
{
    public interface IVMData
    {
        int GetNumberOfRunningVMs(string servername, string username, string password);
    }
}
