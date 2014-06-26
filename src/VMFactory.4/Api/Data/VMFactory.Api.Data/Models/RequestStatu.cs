using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace VMFactory.Api.Data.Models
{
    public partial class RequestStatu
    {
        public RequestStatu()
        {
            this.VMRequests = new List<VMRequest>();
        }

        public int Id { get; set; }

        [DisplayName("Status")]
        public string Name { get; set; }

        public string Description { get; set; }
        public Nullable<int> StepSequence { get; set; }
        public virtual ICollection<VMRequest> VMRequests { get; set; }
    }
}
