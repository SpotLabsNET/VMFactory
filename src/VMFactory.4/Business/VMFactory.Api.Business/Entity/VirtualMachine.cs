using System;
using System.Linq;
using VMFactory.Api.Data.Models;

namespace VMFactory.Api.Business.Entity
{
    public class VirtualMachine
    {


        /// <summary>
        /// Gets the next virtual machine request.
        /// </summary>
        /// <returns></returns>
        public static VirtualMachineRequest GetNextVirtualMachineRequest() {  VirtualMachineRequest result = null;  try { using (var db = new VMFSupportContext()) { var x = db.VMRequests;  var dbRequests = from r in db.VMRequests where r.RequestStatus == (int)RequestStatus.None orderby r.CreatedOn select r;  result = new VirtualMachineRequest(dbRequests.First<VMRequest>());  } } catch (Exception e) {  }  return result;  }

    }
}
