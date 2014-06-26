using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Threading;


namespace VMFactory.Api.Core.Powershell
{
    /// <summary>
    /// Class that assists in asynchronously executing and retrieving the results of a powershell script pipeline.
    /// </summary>
    public class AsyncPipelineExecutor
    {
        #region public types, members
        /// <summary>
        /// Gets the powershell Pipeline associated with this AsyncPipelineExecutor
        /// </summary>
        public Pipeline Pipeline { get { return pipeline; } }

        public delegate void DataReadyDelegate(AsyncPipelineExecutor sender, ICollection<PSObject> data);
        public delegate void DataEndDelegate(AsyncPipelineExecutor sender);
        public delegate void ErrorReadyDelegate(AsyncPipelineExecutor sender, ICollection<object> data);

        /// <summary>
        /// Occurs when there is new data available from the powershell script.
        /// </summary>
        public event DataReadyDelegate OnDataReady;

        /// <summary>
        /// Occurs when powershell script completed its execution.
        /// </summary>
        public event DataEndDelegate OnDataEnd;

        /// <summary>
        /// Occurs when there is new errordata available from the powershell script.
        /// </summary>
        public event ErrorReadyDelegate OnErrorReady;

        #endregion

        #region private types, members

        /// <summary>
        /// The object that is used to invoke the events on.
        /// </summary>
        private ISynchronizeInvoke invoker;

        /// <summary>
        /// The powershell script pipeline that will be executed asynchronously.
        /// </summary>
        private Pipeline pipeline;

        /// <summary>
        /// Local delegate to a private method
        /// </summary>
        private DataReadyDelegate synchDataReady;

        /// <summary>
        /// Local delegate to a private method
        /// </summary>
        private DataEndDelegate synchDataEnd;

        /// <summary>
        /// Local delegate to a private method
        /// </summary>
        private ErrorReadyDelegate synchErrorReady;

        /// <summary>
        /// Event set when the user wants to stop script execution.
        /// </summary>
        private ManualResetEvent stopEvent;

        /// <summary>
        /// Array of waithandles, used in the StoppableInvoke() method.
        /// </summary>
        private WaitHandle[] waitHandles;
        #endregion

        #region public methods
        /// <summary>
        /// Constructor, creates a new AsyncPipelineExecutor for the given powershell script.
        /// </summary>
        /// <param name="runSpace">Powershell runspace to use for creating and executing the script.</param>
        /// <param name="invoker">The object to synchronize the DataReady and DataEnd events with. 
        /// Normally you'd pass the form or component here.</param>
        /// <param name="command">The script to run</param>
        public AsyncPipelineExecutor(Runspace runSpace, ISynchronizeInvoke invoker, string command) { this.invoker = invoker;  synchDataReady = new DataReadyDelegate(SynchDataReady); synchDataEnd = new DataEndDelegate(SynchDataEnd); synchErrorReady = new ErrorReadyDelegate(SynchErrorReady);  stopEvent = new ManualResetEvent(false); waitHandles = new WaitHandle[] { null, stopEvent }; pipeline = runSpace.CreatePipeline(command);  pipeline.Output.DataReady += new EventHandler(Output_DataReady); pipeline.Error.DataReady += new EventHandler(Error_DataReady); } 
        void Error_DataReady(object sender, EventArgs e) { Collection<object> data = pipeline.Error.NonBlockingRead(); if (data.Count > 0) { StoppableInvoke(synchErrorReady, new object[] { this, data }); } }

        /// <summary>
        /// Start executing the script in the background.
        /// </summary>
        public void Start() { if (pipeline.PipelineStateInfo.State == PipelineState.NotStarted) { pipeline.Input.Close(); pipeline.InvokeAsync(); } }

        /// <summary>
        /// Stop executing the script.
        /// </summary>
        public void Stop() { stopEvent.Set(); pipeline.Stop(); }
        #endregion

        #region private methods

        /// <summary>
        /// Special Invoke method that operates similarly to <see cref="ISynchronizeInvoke.Invoke"/> but in addition to that, it can be 
        /// aborted by setting the stopEvent. This avoids potential deadlocks that are possible when using the regular 
        /// <see cref="ISynchronizeInvoke.Invoke"/> method.
        /// </summary>
        /// <param name="method">A <see cref="System.Delegate"/> to a method that takes parameters of the same number and type that are 
        /// contained in <paramref name="args"/></param>
        /// <param name="args">An array of type <see cref="System.Object"/> to pass as arguments to the given method. This can be null if 
        /// no arguments are needed </param>
        /// <returns>The <see cref="Object"/> returned by the asynchronous operation</returns>
        private object StoppableInvoke(Delegate method, object[] args) { IAsyncResult asyncResult = invoker.BeginInvoke(method, args); waitHandles[0] = asyncResult.AsyncWaitHandle; return (WaitHandle.WaitAny(waitHandles) == 0) ? invoker.EndInvoke(asyncResult) : null; }

        /// <summary>
        /// Event handler for the DataReady event of the powershell script pipeline.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Output_DataReady(object sender, EventArgs e) { Collection<PSObject> data = pipeline.Output.NonBlockingRead(); if (data.Count > 0) { StoppableInvoke(synchDataReady, new object[] { this, data }); } if (pipeline.Output.EndOfPipeline) { StoppableInvoke(synchDataEnd, new object[] { this }); }         } 
        /// <summary>
        /// private DataReady handling method that will pass the call on to any event handlers that are
        /// attached to the OnDataReady event of this <see cref="AsyncPipelineExecutor"/> instance.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        private void SynchDataReady(AsyncPipelineExecutor sender, ICollection<PSObject> data) { DataReadyDelegate delegateDataReadyCopy = OnDataReady; if (delegateDataReadyCopy != null) { delegateDataReadyCopy(sender, data); } }

        /// <summary>
        /// private DataEnd handling method that will pass the call on to any handlers that are
        /// attached to the OnDataEnd event of this <see cref="AsyncPipelineExecutor"/> instance.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        private void SynchDataEnd(AsyncPipelineExecutor sender) { DataEndDelegate delegateDataEndCopy = OnDataEnd; if (delegateDataEndCopy != null) { delegateDataEndCopy(sender); } }

        /// <summary>
        /// private ErrorReady handling method that will pass the call on to any event handlers that are
        /// attached to the OnErrorReady event of this <see cref="AsyncPipelineExecutor"/> instance.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        private void SynchErrorReady(AsyncPipelineExecutor sender, ICollection<object> data) { ErrorReadyDelegate delegateErrorReadyCopy = OnErrorReady; if (delegateErrorReadyCopy != null) { delegateErrorReadyCopy(sender, data); } }

        #endregion
    }
}
