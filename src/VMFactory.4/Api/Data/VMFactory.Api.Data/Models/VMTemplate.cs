using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace VMFactory.Api.Data.Models
{
    public partial class VMTemplate
    {
        public VMTemplate()
        {
            this.VMOutputs = new List<VMOutput>();
            this.VMRequests = new List<VMRequest>();
        }

        public int Id { get; set; }

        [DisplayName("Template")]
        public string UniqueName { get; set; }
        public string DisplayName { get; set; }
        public string MdtBaseConfig { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> LastModified { get; set; }
        public virtual ICollection<VMOutput> VMOutputs { get; set; }
        public virtual ICollection<VMRequest> VMRequests { get; set; }
    }
}
