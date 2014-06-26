using System;
using System.Configuration;
using VMFactory.Api.Core.Log;

namespace VMFactory.Api.Core.Configuration
{
    public class DefaultConfigurationStore : IConfigurationStore
    {

        private static DefaultConfigurationStore current = null;



        /// <summary>
        /// This enum represents the maintenance mode configuration
        /// </summary>
        public enum MaintenanceModes { On, Off, Auto }




        static public DefaultConfigurationStore Current { get { if (current == null) current = new DefaultConfigurationStore();  return current; } }

        private DefaultConfigurationStore()
        { }

        // fill in the necessary defaults
        private const string DEFAULT_LOG_TITLE = "VM Factory Cloud Service";
        private const int DEFAULT_LOG_PRIORITY = 5;
        private const LogCategory DEFAULT_LOG_CATEGORY = LogCategory.Database;
        private const System.Diagnostics.TraceEventType DEFAULT_TRACEEVENT_TYPE = System.Diagnostics.TraceEventType.Information;

        private const string DEFAULT_PRODUCT_TRANSLATION_FORMAT = "{0}({1})";


        /// <summary>
        /// Gets the number of average parameters allowed.
        /// </summary>
        /// <value>
        /// The number of average parameters allowed.
        /// </value>
        /// <exception cref="System.Configuration.ConfigurationErrorsException">Bad Configuration Setting: MAX_NUMBER_OF_VMs_RUNNING</exception>
        public int NumberOfVMsAllowed { get { int result; bool validValue; validValue = int.TryParse(GetConfigValue("MAX_NUMBER_OF_VMs_RUNNING"),out result); if (validValue) return result; else throw new ConfigurationErrorsException("Bad Configuration Setting: MAX_NUMBER_OF_VMs_RUNNING"); } }



        /// <summary>
        /// Gets the configuration value.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <returns></returns>
        /// <exception cref="System.Configuration.ConfigurationErrorsException">Missing Configuration Setting:  + keyName</exception>
        private string GetConfigValue(string keyName) { string value = ConfigurationManager.AppSettings[keyName]; if(String.IsNullOrEmpty(value)) { throw new ConfigurationErrorsException("Missing Configuration Setting: " + keyName); } return value; }


        /// <summary>
        /// Gets the name of the server.
        /// </summary>
        /// <value>
        /// The name of the server.
        /// </value>
        public string ServerName { get { return GetConfigValue("HYPERV_HOST_NAME"); } }

        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get { return GetConfigValue("HYPERV_PWD"); } }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get { return GetConfigValue("HYPERV_USER_NAME"); } }

        /// <summary>
        /// Gets the size of the VHD split block.
        /// </summary>
        /// <value>
        /// The size of the VHD split block.
        /// </value>
        public long VhdSplitBlockSize { get { long result = long.MinValue; long.TryParse(GetConfigValue("VHD_BLOCK_SPLIT_SIZE"), out result); return result;  }  }

        /// <summary>
        /// Get the compression level to be applied
        /// </summary>
        public long VhdCompressionLevel { get { long result = long.MinValue; long.TryParse(GetConfigValue("VHD_COMPRESSION_LEVEL"), out result); return result;  }  }

        /// <summary>
        /// Get the temp drop location for the VHD split blocks
        /// </summary>
        public string VhdSplitTempDropLocation { get { return GetConfigValue("VHD_TEMP_DROP_LOCATION"); }  }

        /// <summary>
        /// Get the drop location for the VHD split blocks
        /// </summary>
        public string VhdSplitDropLocation { get { return GetConfigValue("VHD_DROP_LOCATION"); }  }
        
        /// <summary>
        /// Get the drop location for the VHD split blocks
        /// </summary>
        public string VhdSplitDropLocationTemplate { get { return GetConfigValue("VHD_SPLIT_DROP_LOCATION_TEMPLATE"); }  }



        
         /// <summary>
        /// Get the drop location for the VHD split blocks
        /// </summary>
        public string BaseVmDownloadUrl { get { return GetConfigValue("BASE_VM_DOWNLOAD_URL"); }  }
        


        /// <summary>
        /// Gets the name of the base vm.
        /// </summary>
        /// <value>
        /// The name of the base vm.
        /// </value>
        public string BaseVmName { get { return GetConfigValue("BASE_VM_NAME");  } }


        /// <summary>
        /// Gets the base vm configuration file path.
        /// </summary>
        /// <value>
        /// The base vm configuration file path.
        /// </value>
        public string BaseVmConfigFilePath { get { return GetConfigValue("BASE_VM_CONFIG_FILE_PATH");  } }

        /// <summary>
        /// Gets the base vm source path.
        /// </summary>
        /// <value>
        /// The base vm source path.
        /// </value>
        public string BaseVmSourcePath { get { return GetConfigValue("BASE_VM_SOURCE_PATH"); } }


        /// <summary>
        /// Gets the new vm destination path template.
        /// </summary>
        /// <value>
        /// The new vm destination path template.
        /// </value>
        public string NewVmDestinationPathTemplate { get { return GetConfigValue("NEW_VM_DESTINATION_PATH_TEMPLATE"); } }


        /// <summary>
        /// Gets the temporary drive letter.
        /// </summary>
        /// <value>
        /// The temporary drive letter.
        /// </value>
        public string TemporaryDriveLetter { get { return GetConfigValue("TEMPORARY_DRIVE_LETTER"); } }


        /// <summary>
        /// Gets the dism path.
        /// </summary>
        /// <value>
        /// The dism path.
        /// </value>
        public string DismPath { get { return GetConfigValue("DISM_PATH"); } }

        /// <summary>
        /// Gets the VMF status service URL.
        /// </summary>
        /// <value>
        /// The VMF status service URL.
        /// </value>
        public string VmfStatusServiceUrl { get { return GetConfigValue("VMF_STATUS_SERVICE_URL"); } }


        /// <summary>
        /// Gets the VMF configuration file.
        /// </summary>
        /// <value>
        /// The VMF configuration file.
        /// </value> 
        public string VmfConfigFile { get { return GetConfigValue("VMF_CONFIG_FILE"); } }


        /// <summary>
        /// Gets the new vm VHD path template.
        /// </summary>
        /// <value>
        /// The new vm VHD path template.
        /// </value>
        public string NewVmVhdPathTemplate { get { return GetConfigValue("NEW_VM_VHD_PATH_TEMPLATE"); } }

        /// <summary>
        /// Gets the configuration to request user confirmation on each step
        /// </summary>
        public bool RequestUserConfirmation { get { return bool.Parse(GetConfigValue("REQUEST_USER_CONFIRMATION")); } }

        /// <summary>
        /// Gets the wait time (in seconds) between cicles
        /// </summary>
        public int WaitTimeBetweenCicles { get { return int.Parse(GetConfigValue("WAIT_TIME_BETWEEN_CICLES")); } }


        /// <summary>
        /// Gets the configuration to validate or not invitation codes
        /// </summary>
        public bool ValidateInvitationCodes { get { bool validateInvitationCode = true;  if (!bool.TryParse(GetConfigValue("VALIDATE_INVITATION_CODES"), out validateInvitationCode)) validateInvitationCode = true;  return validateInvitationCode; } }

        #region Site config

        /// <summary>
        /// Gets the outgoing email SMTP server.
        /// </summary>
        /// <value>
        /// The outgoing email SMTP server.
        /// </value>
        public string OutgoingEmailSmtpServer { get { return GetConfigValue("OutgoingEmailSmtpServer"); } }


        /// <summary>
        /// Gets the outgoing email SMTP user.
        /// </summary>
        /// <value>
        /// The outgoing email SMTP user.
        /// </value>
        public string OutgoingEmailSmtpUser { get { return GetConfigValue("OutgoingEmailSmtpUser"); } }


        /// <summary>
        /// Gets the outgoing email SMTP password.
        /// </summary>
        /// <value>
        /// The outgoing email SMTP password.
        /// </value>
        public string OutgoingEmailSmtpPassword { get { return GetConfigValue("OutgoingEmailSmtpPassword"); } }


        /// <summary>
        /// Gets the outgoing email from address.
        /// </summary>
        /// <value>
        /// The outgoing email from address.
        /// </value>
        public string OutgoingEmailFromAddress { get { return GetConfigValue("OutgoingEmailFromAddress"); } }


        /// <summary>
        /// Gets the maintenance mode.
        /// </summary>
        /// <value>
        /// The maintenance mode.
        /// </value>
        public MaintenanceModes MaintenanceMode { get { MaintenanceModes result = MaintenanceModes.Off;  switch (GetConfigValue("MAINTENANCE_MODE")) { case "On": result = MaintenanceModes.On; break; case "Auto": result = MaintenanceModes.Auto; break; default: break;  } return result; } }


        #endregion




    }

}
