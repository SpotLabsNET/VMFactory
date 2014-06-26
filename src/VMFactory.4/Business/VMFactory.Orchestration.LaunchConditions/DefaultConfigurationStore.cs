using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace VMFactory.Orchestration.LaunchConditions
{


    // moved to the VMFactory.Api.Core.Configuration

    //public class DefaultConfigurationStore : IConfigurationStore
    //{
    //    public int NumberOfVMsAllowed
    //    {           
    //        get
    //        {
    //            int result;
    //            bool validValue;
    //            validValue = int.TryParse(GetConfigValue("MAX_NUMBER_OF_VMs_RUNNING"),out result);
    //            if (validValue)
    //                return result;
    //            else
    //                throw new ConfigurationErrorsException("Bad Configuration Setting: MAX_NUMBER_OF_VMs_RUNNING");
    //        }           
    //    }
    //    private string GetConfigValue(string keyName)
    //    {
    //        string value = ConfigurationManager.AppSettings[keyName];
    //        if(String.IsNullOrEmpty(value))
    //        {
    //            throw new ConfigurationErrorsException("Missing Configuration Setting: " + keyName);
    //        }
    //        return value;
    //    }


    //    public string ServerName
    //    {         
    //        get { return GetConfigValue("HYPERV_HOST_NAME"); }
    //    }

    //    public string Password
    //    {
    //        get { return GetConfigValue("HYPERV_PWD"); }
    //    }

    //    public string UserName
    //    {
    //        get { return GetConfigValue("HYPERV_USER_NAME"); }
    //    }
    //}
}
