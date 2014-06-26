using System;

namespace VMFactory.Api.Core.Exceptions
{
    [Serializable]
    public class TechnicalException : BaseException
    {
        /// <summary>
        /// this type of exception will be thrown each time there is a general technical exception inside the system.
        /// This type of exception will never be shared with the customer.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="customMessage"></param>
        //public TechnicalException(Exception exception, string customMessage, Operation operation)
        //    : base(SeverityLevel.Fatal, LogLevel.Event, exception, customMessage, operation)
        //{

        //}

        /// <summary>
        /// Initializes a new instance of the <see cref="TechnicalException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        public TechnicalException(string customMessage) : base(SeverityLevel.Fatal, LogLevel.Event, new Exception(customMessage), customMessage, Operation.NotAplicable) {  }
    }
}
