using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using VMFactory.Api.Core.Configuration;
using VMFactory.Api.Core.Log;



namespace VMFactory.Api.Core
{
    public class LogManager
    {
        private static readonly object _lock = new object();

        private const int Defaultpriority = 5;

        private static bool outputDebug = false;

        static TraceManager defaultTrace = null;


        private static LogWriter defaultWriter = null;// = EnterpriseLibraryContainer.Current.GetInstance<LogWriter>();
        public static LogWriter DefaultWriter { get { if (defaultWriter == null) lock (_lock) {  /* no need for double check pattern throws "Object Synchronization method was called from an unsynchronized block of code." this is a know issue http://unity.codeplex.com/workitem/7019?ProjectName=unity IGNORE EXCEPTION I updated this for Unity 6.0 */ defaultWriter = new LogWriterFactory().Create(); }  return defaultWriter; } }


        /// <summary>
        /// Initializes a new instance of the <see cref="LogManager"/> class.
        /// </summary>
        public LogManager() { defaultWriter = new LogWriterFactory().Create(); defaultTrace = new TraceManager(defaultWriter); try { if (!Directory.Exists(@"C:\Temp")) { Directory.CreateDirectory(@"C:\Temp"); } } catch { Trace.WriteLine(@"WARNING: Folder C:\Temp cannot be created for disk log files"); } } 
        /// <summary>
        /// Logs the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        //public static void Log(string msg)
        //{
        //    Log(msg, Guid.NewGuid());
        //}

        //public static void Log(Exception e)
        //{
        //    string message = string.Format("Exception with message: {0} with stack trace: {1}", e.Message, e.StackTrace);

        //    Log(message, Guid.NewGuid());
        //}

        /// <summary>
        /// Logs the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="category">The category.</param>
        /// <param name="priority">The priority.</param>
        /// <param name="eventId">The event id.</param>
        /// <param name="type">The type.</param>
        /// <param name="title">The title.</param>
        /// <param name="properties">The properties.</param>
        /// <param name="correlationId">The correlation id.</param>
        //[Description("Sending log entries to a database")]
        //public static void Log(string msg, LogCategory category, int priority, int eventId, TraceEventType type, string title, IDictionary<string, object> properties, Guid? correlationId)
        //{
        //    // Check if logging is enabled before creating log entries.
        //    if (defaultWriter != null)
        //        if (defaultWriter.IsLoggingEnabled())
        //        {
        //            var entry = new LogEntry
        //            {
        //                Message = msg,
        //                RelatedActivityId = correlationId,
        //                Severity = type
        //            };

        //            entry.Categories.Add(Defaults.DEFAULT_LOG_CATEGORY.ToString());
        //            entry.Title = string.IsNullOrEmpty(title) ? Defaults.DEFAULT_LOG_TITLE : title;
        //            entry.ExtendedProperties = properties;

        //            // Create a LogEntry using the constructor parameters. 
        //            defaultWriter.Write(entry);
        //        }
        //        else
        //        {
        //            Trace.WriteLine("Logging is disabled in the configuration.");
        //        }
        //    else
        //        Trace.WriteLine("Logging is disabled in the configuration. Log writter is not valid.");

        //}

        /// <summary>
        /// Logs the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="category">The category. Send null for default.</param>
        /// <param name="priority">The priority. Send null for default.</param>
        /// <param name="type">The type.</param>
        /// <param name="title">The title.</param>
        /// <param name="properties">The properties.</param>
        /// <param name="correlationId">The correlation id.</param>
        [Description("Sending log entries to a database")]
        public static void Log(string msg, LogCategory category, int priority, TraceEventType type, string title, IDictionary<string, object> properties, Guid? correlationId) { if (defaultWriter != null) { if (defaultWriter.IsLoggingEnabled()) { var entry = new LogEntry { Message = msg }; entry.Categories.Add(category.ToString()); entry.RelatedActivityId = correlationId; entry.Title = string.IsNullOrEmpty(title) ? Defaults.DEFAULT_LOG_TITLE : title; entry.Priority = int.MinValue == priority ? Defaults.DEFAULT_LOG_PRIORITY : priority; entry.ExtendedProperties = properties; defaultWriter.Write(entry); }                 else { Trace.WriteLine("Logging is disabled in the configuration."); } } else { System.Diagnostics.Trace.WriteLine("Log Manager is invalid (Null). Dumping the Log entry to trace event."); System.Diagnostics.Trace.WriteLine(string.Format("Msg: {0}\n Category: {1}\n Priority: {2} Title {3} Correlation ID: {4}", msg, category.ToString(), priority.ToString(), title, correlationId.ToString()));  } } 
        /// <summary>
        /// Logs the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="type">The type.</param>
        /// <param name="correlationId">The correlation id.</param>
        //public static void Log(string msg, TraceEventType type, Guid? correlationId)
        //{

        //    // Check if logging is enabled before creating log entries.
        //    if (defaultWriter != null)
        //        if (defaultWriter.IsLoggingEnabled())
        //        {
        //            // initialize the correlationId if it is null
        //            if (null == correlationId)
        //                correlationId = Guid.NewGuid();

        //            var entry = new LogEntry { Message = msg, RelatedActivityId = correlationId };

        //            entry.Categories.Add(Defaults.DEFAULT_LOG_CATEGORY.ToString());
        //            entry.Severity = type;
        //            entry.Title = Defaults.DEFAULT_LOG_TITLE;

        //            // priority
        //            entry.Priority = Defaults.DEFAULT_LOG_PRIORITY;

        //            // Create a LogEntry using the constructor parameters. 
        //            defaultWriter.Write(entry);
        //        }
        //        else
        //        {
        //            Trace.WriteLine("Logging is disabled in the configuration.");
        //        }
        //    else
        //        Trace.WriteLine("Logging is disabled in the configuration. Invalid Log Writter.");

        //}

        /// <summary>
        /// Logs the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="correlationId">The correlation id.</param>
        //public static void Log(string msg, Guid? correlationId)
        //{
        //    // Check if logging is enabled before creating log entries.
        //    if (DefaultWriter.IsLoggingEnabled())
        //    {
        //        var entry = new LogEntry { Message = msg };

        //        entry.RelatedActivityId = correlationId;
        //        entry.Categories.Add(Defaults.DEFAULT_LOG_CATEGORY.ToString());
        //        entry.Severity = Defaults.DEFAULT_TRACEEVENT_TYPE;
        //        entry.Title = Defaults.DEFAULT_LOG_TITLE;

        //        // priority
        //        entry.Priority = Defaults.DEFAULT_LOG_PRIORITY;

        //        // Create a LogEntry using the constructor parameters. 
        //        defaultWriter.Write(entry);
        //    }
        //    else
        //    {
        //        Trace.WriteLine("Logging is disabled in the configuration.");
        //    }
        //}


        /// <summary>
        /// Traces the data.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        //public static void TraceData(string msg)
        //{
        //    TraceData(msg, Guid.NewGuid(), 10, TraceEventType.Verbose);
        //}

        /// <summary>
        /// Traces the data.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="correlationId">The correlation id.</param>
        /// <param name="priority">The priority.</param>
        /// <param name="tracetype">The tracetype.</param>
        public static void TraceData(string msg, Guid? correlationId, int priority, TraceEventType tracetype) { if (DefaultWriter.IsLoggingEnabled()) {  Debug.WriteLineIf(outputDebug, msg); var entry = new LogEntry { Message = msg }; entry.RelatedActivityId = correlationId; if (correlationId.HasValue) entry.ActivityId = (Guid)correlationId; entry.Categories.Add(Defaults.DEFAULT_LOG_CATEGORY.ToString()); entry.Severity = tracetype; entry.Title = Defaults.DEFAULT_LOG_TITLE; entry.Priority = priority; DefaultWriter.Write(entry);  } else { Trace.WriteLine(String.Format( "COLME: [{3}] [{2}] CORRID: [{1}] MSG: {0}", msg, correlationId, priority, tracetype.ToString() )); } } 

        /// <summary>
        /// Traces the data.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="id">The id.</param>
        /// <param name="entity">The entity.</param>
        /// <param name="correlationId">The correlation id.</param>
        /// <param name="priority">The priority.</param>
        /// <param name="tracetype">The tracetype.</param>
        //public static void TraceData(string msg, string id, string entity, Guid? correlationId, int priority, TraceEventType tracetype)
        //{
        //    //LogWriter lw = DefaultWriter;

        //    if (DefaultWriter.IsLoggingEnabled())
        //    {
        //        Entry reportEntry = new Entry()
        //        {
        //            Entity = entity,
        //            Msg = msg,
        //            Id = id
        //        };

        //        LogEntry entry = new LogEntry
        //        {
        //            Message = reportEntry.ToString(),
        //            Severity = tracetype,
        //            Title = Defaults.DEFAULT_LOG_TITLE,
        //            Priority = priority,
        //            RelatedActivityId = correlationId
        //        };

        //        if (correlationId.HasValue)
        //            entry.ActivityId = (Guid)correlationId;

        //        entry.Categories.Add(Defaults.DEFAULT_LOG_CATEGORY.ToString());

        //        // create a LogEntry using the constructor parameters. 
        //        DefaultWriter.Write(entry);
        //    }
        //    else
        //    {
        //        Trace.WriteLine(String.Format(
        //                "COLME: [{5}] [{4}] CORRID: [{3}] Entity:({2}, {1}) MSG: {0}",
        //                msg,                    //0
        //                id,                     //1
        //                entity,                 //2
        //                correlationId,          //3
        //                priority,               //4
        //                tracetype.ToString()    //5
        //            ));
        //        //Trace.WriteLine("Logging is disabled in the configuration.");
        //    }
        //}
    }
}
