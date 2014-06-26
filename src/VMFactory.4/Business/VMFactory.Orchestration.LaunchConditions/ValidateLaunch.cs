using System.Collections.Generic;
using System.Configuration;
using VMFactory.Api.Core.Configuration;
using VMFactory.Orchestration.LaunchConditions.Rules;

namespace VMFactory.Orchestration.LaunchConditions
{
    public class ValidateLaunch
    {
        private IConfigurationStore configurationStore;
        private List<ILaunchConditionRule> rules = null;
        private IVMData hyperVDataAccess = null;

        public ValidateLaunch() { this.configurationStore = DefaultConfigurationStore.Current; } 
        public ValidateLaunch(IConfigurationStore configurationStore, IVMData hypervData) { if (configurationStore != null && hypervData != null) { this.configurationStore = configurationStore; this.hyperVDataAccess = hypervData; } else { throw new ConfigurationErrorsException("Missing Configuration Store"); }  }

        public bool VerifyLaunchConditions() { bool ruleResult = false;  if (this.rules == null) { rules = new List<ILaunchConditionRule>(); LoadLaunchConditionRules(); }  foreach (ILaunchConditionRule rule in this.rules) { ruleResult = rule.Check(); if (ruleResult == false) { return ruleResult; } }  return ruleResult;  }

        private void LoadLaunchConditionRules() { this.hyperVDataAccess = new HyperVData(); this.rules.Add( new NumberOfRunningVMs( this.configurationStore,this.hyperVDataAccess)); } 
        
    }
}
