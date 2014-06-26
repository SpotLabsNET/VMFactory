using System;
using System.Collections.Generic;

namespace VMFactory.Engine
{
    sealed class ProcessResult
    {

        public bool IsRunning { get; set; }

        public Guid RequestId { get; set; }

        public ProcessStatus CurrentStatus { get; set; }

        public List<string> ErrorMessages = new List<string>();

        #region constructors

        public ProcessResult(Guid requestId)
        {
            this.RequestId = requestId;
            this.CurrentStatus = ProcessStatus.None;
        }

        public ProcessResult()
        {
            this.RequestId = new Guid();
            this.CurrentStatus = ProcessStatus.None;
        }

        #endregion

    }
}
