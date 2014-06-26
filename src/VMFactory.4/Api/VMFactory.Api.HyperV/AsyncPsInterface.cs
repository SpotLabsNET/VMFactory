//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Collections.ObjectModel;
//using System.Management.Automation;
//using System.Management.Automation.Runspaces;
//using VMFactory.Api.Core.Powershell;

//using System.ComponentModel;


//namespace VMFactory.Api.HyperV
//{
//    public class AsyncPsInterface : IDisposable, ISynchronizeInvoke
//    {

//        #region Properties



//        private string _VmName = string.Empty;
//        public string VmName
//        {
//            get { return _VmName; }

//            set { _VmName = value; }

//        }

//        bool _InvokeRequired;
//        public bool InvokeRequired
//        {
//            get { return _InvokeRequired; }

//            set { _InvokeRequired = value; }
//        }
        
        
//        #endregion


//        /// <summary>
//        /// Powershell runspace
//        /// </summary>
//        private Runspace runSpace;




//        /// <summary>
//        /// The active AsyncPipelineExecutor instance
//        /// </summary>
//        private AsyncPipelineExecutor pipelineExecutor;

//        #region Constructors
//        //public AsyncPsInterface()
//        //{
//        //    // create Powershell runspace
//        //    runSpace = RunspaceFactory.CreateRunspace();
//        //    // open it
//        //    runSpace.Open();

            

//        //}

//        ISynchronizeInvoke obj;
//        #endregion



//        #region sample
//        //public void Sample()
//        //{

//        //    pipelineExecutor = new AsyncPipelineExecutor(runSpace, this, "my ps command here");
//        //    pipelineExecutor.OnDataReady += new AsyncPipelineExecutor.DataReadyDelegate(samplePipelineExecutor_OnDataReady);
//        //    pipelineExecutor.OnDataEnd += new AsyncPipelineExecutor.DataEndDelegate(samplePipelineExecutor_OnDataEnd);
//        //    pipelineExecutor.OnErrorReady += new AsyncPipelineExecutor.ErrorReadyDelegate(samplePipelineExecutor_OnErrorReady);
//        //    pipelineExecutor.Start();

        
//        //}

//        ///// <summary>
//        ///// Samples the pipeline executor on data end.
//        ///// </summary>
//        ///// <param name="sender">The sender.</param>
//        //private void samplePipelineExecutor_OnDataEnd(AsyncPipelineExecutor sender)
//        //{
//        //    if (sender.Pipeline.PipelineStateInfo.State == PipelineState.Failed)
//        //    {
//        //        // add error processing here
//        //    }
//        //    else
//        //    {
//        //        // add success processing here
//        //    }
//        //}


//        ///// <summary>
//        ///// Samples the pipeline executor on data ready.
//        ///// </summary>
//        ///// <param name="sender">The sender.</param>
//        ///// <param name="data">The data.</param>
//        //private void samplePipelineExecutor_OnDataReady(AsyncPipelineExecutor sender, ICollection<PSObject> data)
//        //{
//        //    foreach (PSObject obj in data)
//        //    {
//        //        // process data returned by the script
//        //    }
//        //}


//        ///// <summary>
//        ///// Samples the pipeline executor_ on error ready.
//        ///// </summary>
//        ///// <param name="sender">The sender.</param>
//        ///// <param name="data">The data.</param>
//        //void samplePipelineExecutor_OnErrorReady(AsyncPipelineExecutor sender, ICollection<object> data)
//        //{
//        //    foreach (object e in data)
//        //    {
//        //        // oops, got errors, process them
//        //    }
//        //}

//        #endregion

//        public object EndInvoke(IAsyncResult result)
//        {
//            throw new NotImplementedException();
//        }

//        public object Invoke(Delegate ldel, object[] objects)
//        {
//            throw new NotImplementedException();
//        }


//        public IAsyncResult BeginInvoke(Delegate ldel, object[] objects)
//        {
//            throw new NotImplementedException();
//        }


//        public void Dispose()
//        {


//        }





//    }
//}
