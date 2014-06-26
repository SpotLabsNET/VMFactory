using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMFactory.Api.Core.Exceptions
{
    [Serializable]
    public class DataException : BaseException
    {
        /// <summary>
        /// this type of exception will be thrown each time there is a general technical exception inside the system.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="customMessage"></param>
        public DataException(Exception exception, string customMessage, Operation operation)
            : base(SeverityLevel.Critical, LogLevel.Event, exception, customMessage, operation)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TechnicalException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        public DataException(string customMessage)
            : base(SeverityLevel.Critical, LogLevel.Event, new Exception(customMessage), customMessage, Operation.NotAplicable)
        {

        }
    }
}
