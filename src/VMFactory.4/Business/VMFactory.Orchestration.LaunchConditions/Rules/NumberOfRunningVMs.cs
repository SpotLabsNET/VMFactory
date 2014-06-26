using VMFactory.Api.Core.Configuration;

namespace VMFactory.Orchestration.LaunchConditions.Rules
{
    class NumberOfRunningVMs : ILaunchConditionRule
    {
        private IVMData hyperV;
        private IConfigurationStore configurationStore;
        
        public NumberOfRunningVMs(
            IConfigurationStore store, 
            IVMData hyperVData)
        {
            this.configurationStore = store;
            this.hyperV = hyperVData;
        }

        public bool Check()
        {
            int numberOfRunningVMs =
                hyperV.GetNumberOfRunningVMs(configurationStore.ServerName,
                configurationStore.UserName, configurationStore.Password);
            
            return numberOfRunningVMs < configurationStore.NumberOfVMsAllowed;
        }

       
    }
}
