using System;
using System.Collections.Generic;

namespace VMFactory.Api.Data.Models
{
    public partial class VMRequest
    {
        public VMRequest()
        {
            this.VMOutputs = new List<VMOutput>();
        }

        public long Id { get; set; }
        public string DisplayName { get; set; }
        public string MachineName { get; set; }
        public string MDTConfigurationSettings { get; set; }
        public string TargetConfiguration { get; set; }
        public Nullable<int> RequestStatus { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public string ProcessLog { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<int> TemplateId { get; set; }
        public virtual RequestStatu RequestStatu { get; set; }
        public virtual ICollection<VMOutput> VMOutputs { get; set; }
        public virtual VMTemplate VMTemplate { get; set; }
    }
}
