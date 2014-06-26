using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMFactory.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VMFactory.Api.Business.Entity;
namespace VMFactory.Services.Tests
{
    [TestClass()]
    public class VMRequestManagementTests
    {
        /// <summary>
        /// Update the request status for a non existing machine id
        /// shoud return an ArgumentException
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateStatus_InvalidMachineId()
        {
            VMRequestManagement management = new VMRequestManagement();
            management.UpdateStatus(0, RequestStatus.None, null);
        }

        [TestMethod()]
        public void UpdateStatus_ExistingRequest()
        {
            VMRequestManagement management = new VMRequestManagement();

            VirtualMachineRequest request = null;
            for (int i = 1; i < int.MaxValue; i++)
            {
                try
                {
                    request = management.Get(i);
                    break;
                }
                catch (ArgumentException)
                { }
                catch
                {
                    Assert.Fail("Unable to retrieve existing requests");
                }
            }

            RequestStatus originalStatus = request.Status;

            management.UpdateStatus(request.Id, RequestStatus.None, null);

            VirtualMachineRequest newRequest = management.Get(request.Id);
            Assert.IsTrue(newRequest.Status == RequestStatus.None);

            management.UpdateStatus(request.Id, originalStatus, "test");
        }

    }
}
