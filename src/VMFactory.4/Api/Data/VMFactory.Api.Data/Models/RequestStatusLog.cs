using System;

namespace VMFactory.Api.Data.Models
{
    public class RequestStatusLog
    {
        public long RequestStatusLogId { get; set; }
        
        public string RequestStatusDetails { get; set; }

        public DateTime InsertedOn { get; set; }

        public virtual RequestStatu RequestStatus { get; set; }

        public virtual VMRequest VMRequest { get; set; }

    }
}
