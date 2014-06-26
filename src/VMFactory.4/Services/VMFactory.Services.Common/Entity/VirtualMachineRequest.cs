using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMFactory.Api.Business.Entity;

namespace VMFactory.Services.Common.Entity
{
    public class VirtualMachineRequest
    {
        public Guid Id { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime CompletedOn { get; set; }
    }
}
