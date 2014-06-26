using System;
using System.Linq;
using System.Xml;
using VMFactory.Api.Core.Exceptions;
using VMFactory.Api.Data.Models;


namespace VMFactory.Api.Business.Entity
{
    public class VirtualMachineRequest
    {

        #region properties

        /// <summary>
        /// Virtual machine request id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Virtual machine request correlation id
        /// </summary>
        public Guid CorrelationId { get; set; }

        /// <summary>
        /// Virtual machine request status
        /// </summary>
        public RequestStatus Status { get; set; }

        /// <summary>
        /// Virtual machine request request start date
        /// </summary>
        public DateTime RequestedOn { get; set; }

        /// <summary>
        /// Virtual machine request requester identity
        /// </summary>
        public string RequestedBy { get; set; }

        /// <summary>
        /// Virtual machine request processing start date
        /// </summary>
        public DateTime StartedOn { get; set; }

        /// <summary>
        /// Virtual machine request completion date
        /// </summary>
        public DateTime CompletedOn { get; set; }

        /// <summary>
        /// Virtual machine request mdt configuration
        /// </summary>
        public XmlDataDocument MdtConfiguration { get; set; }

        /// <summary>
        /// Virtual machine request deployment configuration
        /// </summary>
        public XmlDataDocument DeploymentConfiguration { get; set; }

        /// <summary>
        /// Is virtual machine request valid
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Virtual machine request template id
        /// </summary>
        public string TemplateId { get; set; }

        /// <summary>
        /// Virtual machine request processing log
        /// </summary>
        public string ProcessLog { get; set; }

        #endregion


        #region constructors

        public VirtualMachineRequest( long Id) { using (var db = new VMFSupportContext()) { var x = db.VMRequests;  var requests = from r in db.VMRequests where r.Id == Id select r;  if (requests.Count() == 0) throw new ArgumentException("Virtual machine couldn't be found!"); else Populate(requests.First()); } }

        /// <summary>
        /// This constructor translates the data entity into the business entity
        /// </summary>
        /// <param name="dataRequest"></param>
        public VirtualMachineRequest(VMRequest dataRequest) { Populate(dataRequest); }

        private void Populate(VMRequest dataRequest) { this.IsValid = false;  try {  this.Id = dataRequest.Id;  if (!string.IsNullOrEmpty(dataRequest.MDTConfigurationSettings)) { if (this.MdtConfiguration == null) this.MdtConfiguration = new XmlDataDocument();  this.MdtConfiguration.LoadXml(dataRequest.MDTConfigurationSettings); }  if (!string.IsNullOrEmpty(dataRequest.TargetConfiguration)) { if (this.DeploymentConfiguration == null) this.DeploymentConfiguration = new XmlDataDocument();  this.DeploymentConfiguration.LoadXml(dataRequest.TargetConfiguration); }  this.RequestedBy = dataRequest.CreatedBy;  if (dataRequest.CreatedOn != null) this.RequestedOn = (DateTime) dataRequest.CreatedOn;  if (dataRequest.VMTemplate != null) this.TemplateId = dataRequest.VMTemplate.Id.ToString();  if (dataRequest.RequestStatus != null) this.Status = (RequestStatus)dataRequest.RequestStatus;  this.ProcessLog = dataRequest.ProcessLog;  this.IsValid = true;  } catch (Exception ex) { ExceptionManager.HandleException(ex); }   }


        public VirtualMachineRequest() { this.Status = RequestStatus.None; }
        #endregion


        #region public methods
        /// <summary>
        /// Saves this instance.
        /// The only properties saved/updated will be the: request status and last udpdated date.
        /// </summary>
        /// <returns></returns>
        public bool Save() { bool result = false; try {  using (var db = new VMFSupportContext()) {  VMRequest request = (from v in db.VMRequests where v.Id == this.Id select v).First();  if (request == null) throw new TechnicalException("Virtual machine request not found!");  if (request.RequestStatus != (int)this.Status) { request.RequestStatus = (int)this.Status; request.LastUpdated = DateTime.UtcNow; }  if (request.ProcessLog != this.ProcessLog) { request.ProcessLog = this.ProcessLog; request.LastUpdated = DateTime.UtcNow; }  db.SaveChanges();  result = true; }  } catch (Exception e) { ExceptionManager.HandleException(e); throw; }  return result; }


        #endregion


    }
}
