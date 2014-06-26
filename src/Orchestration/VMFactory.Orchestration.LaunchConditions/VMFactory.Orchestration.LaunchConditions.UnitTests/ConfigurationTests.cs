using System;
using Xunit;
using VMFactory.Orchestration.LaunchConditions;
using VMFactory.Orchestration.LaunchConditions.Fakes;
using System.Configuration;
using System.Xml;

namespace VMFactory.Orchestration.LaunchConditions.UnitTests
{
 
    public class ConfigurationTests
    {
        string configPath = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
        [Fact]
        public void Should_Error_if_ConfigurationStore_is_Null()
        {
            ValidateLaunch canLaunch;
            IConfigurationStore configurationStore = null;
            IVMData hyperV = new StubIVMData();
            ConfigurationException ex = Assert.Throws<ConfigurationErrorsException>(() => canLaunch = new ValidateLaunch(configurationStore,hyperV));
            Assert.Equal("Missing Configuration Store", ex.Message);
        }
        [Fact]
        public void Should_Error_if_HyperVData_is_Null()
        {
            ValidateLaunch canLaunch;
            IConfigurationStore configurationStore = new StubIConfigurationStore();
            IVMData hyperV = null;
            ConfigurationException ex = Assert.Throws<ConfigurationErrorsException>(() => canLaunch = new ValidateLaunch(configurationStore,hyperV));
            Assert.Equal("Missing Configuration Store", ex.Message);
        }

        [Fact]
        public void Should_Error_if_Missing_Max_VM_Running_Setting_Stub()
        {
            string expectedMessage = "Missing Configuration Setting: MAX_NUMBER_OF_VMs_RUNNING";
           
            IVMData hyperV = new StubIVMData()
            {
                GetNumberOfRunningVMsStringStringString = (string a,string b,string c) => { return 2; }
            };

            IConfigurationStore configurationStore =
                new StubIConfigurationStore()
                {
                    NumberOfVMsAllowedGet = () => { throw new ConfigurationErrorsException(expectedMessage); }
                };

            ValidateLaunch canLaunch = new ValidateLaunch(configurationStore,hyperV);
            ConfigurationException ex = Assert.Throws<ConfigurationErrorsException>(() => canLaunch.VerifyLaunchConditions());
            Assert.Equal(expectedMessage, ex.Message);
        }
      
        [Fact]
        public void Should_Error_if_Missing_Max_VM_Running_Setting()
        {
            string expectedMessage = "Missing Configuration Setting: MAX_NUMBER_OF_VMs_RUNNING";
            string oldConfig = RemoveConfigNode(configPath, "MAX_NUMBER_OF_VMs_RUNNING");

            DefaultConfigurationStore store = new DefaultConfigurationStore();

            IVMData hyperV = new StubIVMData()
            {
                GetNumberOfRunningVMsStringStringString = (string a, string b, string c) => { return 2; }
            };

            ValidateLaunch canLaunch = new ValidateLaunch(store,hyperV);
            ConfigurationException ex = Assert.Throws<ConfigurationErrorsException>(() => canLaunch.VerifyLaunchConditions());

            RestoreConfiguration(configPath, oldConfig);
            Assert.Equal(expectedMessage, ex.Message); 
        }
        [Fact]
        public void Should_Error_if_Missing_HyperV_Host_Name_Setting()
        {
            string expectedMessage = "Missing Configuration Setting: HYPERV_HOST_NAME";
            string oldConfig = RemoveConfigNode(configPath, "HYPERV_HOST_NAME");

            DefaultConfigurationStore store = new DefaultConfigurationStore();
           
            IVMData hyperV = new HyperVData();
            ValidateLaunch canLaunch = new ValidateLaunch(store, hyperV);
            ConfigurationException ex = Assert.Throws<ConfigurationErrorsException>(() => canLaunch.VerifyLaunchConditions());

            RestoreConfiguration(configPath, oldConfig);
            Assert.Equal(expectedMessage, ex.Message);
        }
        [Fact]
        public void Should_Error_if_Missing_HyperV_Password_Setting()
        {
            string expectedMessage = "Missing Configuration Setting: HYPERV_PWD";
            string oldConfig = RemoveConfigNode(configPath, "HYPERV_PWD");

            DefaultConfigurationStore store = new DefaultConfigurationStore();

            IVMData hyperV = new HyperVData();
            ValidateLaunch canLaunch = new ValidateLaunch(store, hyperV);
            ConfigurationException ex = Assert.Throws<ConfigurationErrorsException>(() => canLaunch.VerifyLaunchConditions());

            RestoreConfiguration(configPath, oldConfig);
            Assert.Equal(expectedMessage, ex.Message);
        }
        [Fact]
        public void Should_Error_if_Missing_HyperV_User_Name_Setting()
        {
            string expectedMessage = "Missing Configuration Setting: HYPERV_USER_NAME";
            string oldConfig = RemoveConfigNode(configPath, "HYPERV_USER_NAME");

            DefaultConfigurationStore store = new DefaultConfigurationStore();

            IVMData hyperV = new HyperVData();
            ValidateLaunch canLaunch = new ValidateLaunch(store, hyperV);
            ConfigurationException ex = Assert.Throws<ConfigurationErrorsException>(() => canLaunch.VerifyLaunchConditions());

            RestoreConfiguration(configPath, oldConfig);
            Assert.Equal(expectedMessage, ex.Message);
        }
        [Fact]
        public void Should_Error_if_Non_Int_Max_VM_Running_Setting()
        {
            string expectedMessage = "Bad Configuration Setting: MAX_NUMBER_OF_VMs_RUNNING";
            string oldConfig = UpdateConfigValue(configPath,"MAX_NUMBER_OF_VMs_RUNNING", "NOT_AN_INT");

            DefaultConfigurationStore store = new DefaultConfigurationStore();

            IVMData hyperV = new StubIVMData()
            {
                GetNumberOfRunningVMsStringStringString = (string a, string b, string c) => { return 2; }
            };

            ValidateLaunch canLaunch = new ValidateLaunch(store,hyperV);
            ConfigurationException ex = Assert.Throws<ConfigurationErrorsException>(() => canLaunch.VerifyLaunchConditions());

            RestoreConfiguration(configPath, oldConfig);
            Assert.Equal(expectedMessage, ex.Message);
        }

        

        #region ConfigHelpers
        private static void RestoreConfiguration(string configPath, string oldConfig)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(oldConfig);
            xmldoc.Save(configPath);
            ConfigurationManager.RefreshSection("appSettings");
        }
        private XmlDocument LoadConfig(string filePath)
        {
            string configPath = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(configPath);          
            return xmlDoc;
        }
        private string RemoveConfigNode(string configPath,string keyName)
        {          
            XmlDocument xmlDoc = LoadConfig(configPath);
            string oldConfig = xmlDoc.InnerXml;
            XmlNode node = xmlDoc.SelectSingleNode(@"/configuration/appSettings/add[@key='" + keyName + "']");
            xmlDoc.DocumentElement.FirstChild.RemoveChild(node);
            xmlDoc.Save(configPath);
            ConfigurationManager.RefreshSection("appSettings");
            return oldConfig;

        }
        private string UpdateConfigValue(string configPath,string keyName,string newValue)
        {           
            XmlDocument xmlDoc = LoadConfig(configPath);
            string oldConfig = xmlDoc.InnerXml;
            XmlNode node = xmlDoc.SelectSingleNode(@"/configuration/appSettings/add[@key='" + keyName + "']");
            node.Attributes.GetNamedItem("value").Value = newValue;
            xmlDoc.Save(configPath);
            ConfigurationManager.RefreshSection("appSettings");
            return oldConfig; 
        }
        private string GetConfigValue(string configPath, string keyName)
        {
            XmlDocument xmlDoc = LoadConfig(configPath);
            string oldConfig = xmlDoc.InnerXml;
            XmlNode node = xmlDoc.SelectSingleNode(@"/configuration/appSettings/add[@key='" + keyName + "']");
            return node.Attributes.GetNamedItem("value").Value;
        }
        #endregion
    }
}
