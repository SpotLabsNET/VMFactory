using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMFactory.Orchestration.LaunchConditions.Rules
{
    class NumberOfRunningVMs : ILaunchConditionRule
    {
        private IVMData hyperV;
        private IConfigurationStore configurationStore;
        
        public NumberOfRunningVMs(IConfigurationStore store, IVMData hyperVData)
        {
            this.configurationStore = store;
            this.hyperV = hyperVData;
        }
        public bool Check()
        {
            int numberRunning =
                hyperV.GetNumberOfRunningVMs(configurationStore.ServerName,
                configurationStore.UserName, configurationStore.Password);
            return numberRunning <= configurationStore.NumberOfVMsAllowed;
        }

       
    }
}
