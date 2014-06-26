using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMFactory.Orchestration.LaunchConditions.Fakes;
using Xunit;

namespace VMFactory.Orchestration.LaunchConditions.UnitTests
{
    class RuleTests
    {
        [Fact]
        public void Should_Return_False_if_Too_Many_VMs_Running()
        {
            int allowedNumberOfVMs = 2;
            IConfigurationStore configurationStore =
               new StubIConfigurationStore()
               {
                   NumberOfVMsAllowedGet = () => { return allowedNumberOfVMs; }
               };
            IVMData hyperV = new StubIVMData()
            {
                GetNumberOfRunningVMsStringStringString = (string a, string b, string c) => { return allowedNumberOfVMs + 1; }
            };
            ValidateLaunch canLaunch = new ValidateLaunch(configurationStore, hyperV);
            Assert.False(canLaunch.VerifyLaunchConditions());


        }
        [Fact]
        public void Should_Return_True_if_Running_VMs_Is_Less_Than_Config_Limit()
        {
            int allowedNumberOfVMs = 2;
            IConfigurationStore configurationStore =
               new StubIConfigurationStore()
               {
                   NumberOfVMsAllowedGet = () => { return allowedNumberOfVMs; }
               };

            IVMData hyperV = new StubIVMData()
            {
                GetNumberOfRunningVMsStringStringString = (string a, string b, string c) => { return allowedNumberOfVMs - 1; }
            };
            ValidateLaunch canLaunch = new ValidateLaunch(configurationStore, hyperV);
            Assert.True(canLaunch.VerifyLaunchConditions());


        }

        [Fact]
        public void Should_Return_True_if_Running_VMs_Is_Same_As_Config_Limit()
        {
            int allowedNumberOfVMs = 2;
            IConfigurationStore configurationStore =
               new StubIConfigurationStore()
               {
                   NumberOfVMsAllowedGet = () => { return allowedNumberOfVMs; }
               };

            IVMData hyperV = new StubIVMData()
            {
                GetNumberOfRunningVMsStringStringString = (string a, string b, string c) => { return allowedNumberOfVMs; }
            };
            ValidateLaunch canLaunch = new ValidateLaunch(configurationStore, hyperV);
            Assert.True(canLaunch.VerifyLaunchConditions());


        }
    }
}
