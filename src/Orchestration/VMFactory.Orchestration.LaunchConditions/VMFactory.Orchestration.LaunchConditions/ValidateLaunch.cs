using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMFactory.Orchestration.LaunchConditions.Rules;

namespace VMFactory.Orchestration.LaunchConditions
{
    public class ValidateLaunch
    {
        private IConfigurationStore configurationStore;
        private List<ILaunchConditionRule> rules = new List<ILaunchConditionRule>();
        private IVMData hyperVDataAccess;

        public ValidateLaunch()
        {
            //if no config store passed in then load default.
            this.configurationStore = new DefaultConfigurationStore();
            this.hyperVDataAccess = new HyperVData();
        }

        public ValidateLaunch(IConfigurationStore configurationStore,IVMData hypervData)
        {
            if (configurationStore != null && hypervData !=null)
            {
                this.configurationStore = configurationStore;
                this.hyperVDataAccess = hypervData;
            }
            else
            { 
                throw new ConfigurationErrorsException("Missing Configuration Store");
            }
                 
        }

        public bool VerifyLaunchConditions()
        {
            bool ruleResult = false;
            LoadLaunchConditionRules();
            foreach (ILaunchConditionRule rule in this.rules)
            {
                ruleResult = rule.Check();
                if (ruleResult == false)
                {
                    return ruleResult;
                }
            }
            return ruleResult;
           
        }

        private void LoadLaunchConditionRules()
        {
            this.rules.Add(new NumberOfRunningVMs(this.configurationStore,this.hyperVDataAccess));
        }

        
    }
}
