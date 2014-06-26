using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VMFactory.Services.Models
{
    public class VmStatus
    {
        public int VmId { get; set; }
        public string StatusInformation { get; set; }
        public int CurrentState { get; set; }
    }
}