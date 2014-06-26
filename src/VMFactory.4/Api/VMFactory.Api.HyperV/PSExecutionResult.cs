using System;

namespace VMFactory.Api.HyperV
{
    public class PsExecutionResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether [success].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [success]; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; set; }


        /// <summary>
        /// Gets or sets the result message.
        /// </summary>
        /// <value>
        /// The result message.
        /// </value>
        public string ResultMessage { get; set; }


        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>
        /// The exception.
        /// </value>
        public Exception Exception { get; set; }


        public PsExecutionResult() {  this.Success = false; this.ResultMessage = string.Empty;  }
    }
}
