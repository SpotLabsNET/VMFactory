using System;

namespace VMFactory.Api.Core.Exceptions
{
    
        [Serializable]
        public class IOException : BaseException
        {
            /// <summary>
            /// this type of exception will be thrown each time there is an exception accessing the input files.
            /// </summary>
            /// <param name="exception"></param>
            /// <param name="customMessage"></param>
            public IOException(Exception exception, string customMessage, Operation operation) : base(SeverityLevel.Fatal, LogLevel.Event, exception, customMessage, operation) {  }
        }
}
