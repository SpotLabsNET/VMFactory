using System;
using System.Diagnostics;
using VMFactory.Api.Core.Log;

namespace VMFactory.Api.Core.Exceptions
{
    public static class ExceptionManager
    {

        static int HIGH_PRIORITY = 50;

        /// <summary>
        /// Defaults the handler.
        /// </summary>
        /// <param name="e">The e.</param>
        private static void DefaultHandler(BaseException e) {  if (e == null) return;  if (e.CorrelationId == null) e.CorrelationId = Guid.NewGuid();  LogManager.Log(e.Message, LogCategory.General, HIGH_PRIORITY, System.Diagnostics.TraceEventType.Error, e.CustomMessage, e.Properties, e.CorrelationId);  LogManager.TraceData(e.Message, e.CorrelationId, HIGH_PRIORITY, TraceEventType.Error);  } 


        /// <summary>
        /// Defaults the handler.
        /// </summary>
        /// <param name="e">The e.</param>
        private static void DefaultHandler(Exception e) {  BaseException be = new BaseException(e); DefaultHandler(be);  }


        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="exp">The exp.</param>
        //public static void HandleException(TechnicalException exp)
        //{
        //    DefaultHandler(exp);
        //}

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="exp">The exp.</param>
        //public static void HandleException(ServiceNotAvailableException exp)
        //{
        //    DefaultHandler(exp);
        //}

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="exp">The exp.</param>
        //public static void HandleException(IOException exp)
        //{
        //    DefaultHandler(exp);
        //}

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="exp">The exp.</param>
        public static void HandleException(Exception exp) { DefaultHandler(exp); }


    }
}
