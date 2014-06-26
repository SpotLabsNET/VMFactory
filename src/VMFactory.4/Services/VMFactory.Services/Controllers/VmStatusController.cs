using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VMFactory.Api.Data.Models;
using VMFactory.Services.Models;

namespace VMFactory.Services.Controllers
{
    public class VmStatusesController : ApiController
    {
        private VMFSupportContext db = new VMFSupportContext();

        [AcceptVerbs("PUT")]
        public void SetStatuses(int id, VmStatus status)
        {
            var vmRequest = (from vms in db.VMRequests
                             where vms.Id == id
                             select vms).Single<VMRequest>();

            vmRequest.RequestStatusLogs.Add(new RequestStatusLog()
            {
                RequestStatusDetails = status.StatusInformation,
                InsertedOn = DateTime.Now,                 
            });

            vmRequest.RequestStatus = status.CurrentState;

            db.SaveChanges();
        }
    }
}
