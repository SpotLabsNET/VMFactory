using System;
using System.Collections.Generic;


namespace VMFactory.Api.Core.Exceptions
{

        [Serializable]
        public class BaseException : ApplicationException
        {
            // defines the severity level of the Exception
            private SeverityLevel severityLevelOfException;

            // defines the logLevel of the Exception
            private LogLevel logLevelOfException;

            //operation type
            private Operation operation;

            private Exception innerException;

            // Custom Message 
            private string customMessage;

            //properties to log
            private IDictionary<string, object> _properties; public IDictionary<string, object> Properties { get { if (this._properties == null) this._properties = new Dictionary<string, object>();  return this._properties; } set { this._properties = value; } }

            //log correlation id
            private Guid? _correlationId = null; public Guid? CorrelationId { get { if (this._correlationId == null) this._correlationId = Guid.NewGuid();  return this._correlationId; } set { this._correlationId = value; } }

            /// <summary>
            /// Public accessor of customMessage
            /// </summary>
            public string CustomMessage { get { return this.customMessage; } set { this.customMessage = value; } }

            /// <summary>
            /// Standard default Constructor
            /// </summary>
            public BaseException() {  }


            /// <summary>
            /// Standard default Constructor
            /// </summary>
            public BaseException(Exception e) { this.logLevelOfException = LogLevel.Event; this.innerException = e; this.customMessage = e.Message; }
            
            
            /// <summary>
            /// 
            /// </summary>
            /// <param name="severityLevel"></param>
            /// <param name="logLevel"></param>
            /// <param name="exception"></param>
            /// <param name="customMessage"></param>
            /// <param name="operation"></param>
            /// <param name="entityType"></param>
            public BaseException(SeverityLevel severityLevel, LogLevel logLevel, Exception exception, string customMessage, Operation operation) { this.severityLevelOfException = severityLevel; this.logLevelOfException = logLevel; this.innerException = exception; this.customMessage = customMessage; this.operation = operation; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="severityLevel"></param>
            /// <param name="logLevel"></param>
            /// <param name="exception"></param>
            /// <param name="customMessage"></param>
            /// <param name="operation"></param>
            /// <param name="entityType"></param>
            /// <param name="properties"></param>
            /// <param name="CorrelationId"></param>
            public BaseException(SeverityLevel severityLevel, LogLevel logLevel, Exception exception, string customMessage, Operation operation, IDictionary<string, object> properties, Guid? correlationId) { this.severityLevelOfException = severityLevel; this.logLevelOfException = logLevel; this.innerException = exception; this.customMessage = customMessage; this.operation = operation; this.Properties = properties; this.CorrelationId = correlationId; }
        }


}
