using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Mvc;
using VMFactory.Api.Data.Models;

namespace VMFactory.Presentation.Controllers
{
    public class VMRequestController : VMFactoryBaseController
    {
        private VMFSupportContext db = new VMFSupportContext();

        //
        // GET: /Default1/
        [Authorize]
        public ActionResult Index() { string currentUserEmailAddress = ""; if (IsRegistered()) { currentUserEmailAddress = ViewBag.EMail;  var vmrequests = db.VMRequests.Where(r => r.CreatedBy == currentUserEmailAddress).OrderByDescending(r => r.CreatedOn).Include(v => v.RequestStatu).Include(v => v.VMTemplate); return View(vmrequests.ToList()); } else return RedirectToAction("Register", "Home"); }

        //
        // GET: /Default1/Details/5
        [Authorize]
        public ActionResult Details(long id = 0) { if (IsRegistered()) {  VMRequest vmrequest = db.VMRequests.Find(id); if (vmrequest == null) return HttpNotFound();   if ( vmrequest.CreatedBy != ViewBag.EMail) return HttpNotFound();  return View(vmrequest); } else return RedirectToAction("Register", "Home"); } 

        //
        // GET: /Default1/Create
        [Authorize]
        public ActionResult Create() { ViewBag.RequestStatus = new SelectList(db.RequestStatus, "Id", "Name"); ViewBag.TemplateId = new SelectList(db.VMTemplates, "Id", "UniqueName");  VMRequest request = new VMRequest(); if (IsRegistered()) { request.CreatedBy = ViewBag.Email;  return View(request); } else return RedirectToAction("Register", "Home"); }

        //
        // POST: /Default1/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMRequest vmrequest) { bool redirectToVMOutputList = false;  if (ModelState.IsValid) { string vmUrl = string.Empty; StringBuilder message = new StringBuilder();  try { vmrequest.RequestStatus = (int)VMFactory.Api.Business.Entity.RequestStatus.None; vmrequest.LastUpdated = DateTime.UtcNow; vmrequest.CreatedOn = vmrequest.LastUpdated; db.VMRequests.Add(vmrequest); db.SaveChanges();  var existingVms = db.VMOutputs.Where( c => c.VMRequest.TemplateId == vmrequest.TemplateId && c.VMRequest.CreatedBy == vmrequest.CreatedBy).OrderByDescending(c => c.VMRequest.CreatedBy); if (existingVms.Count() > 0) { StringBuilder vmList = new StringBuilder("Here is a list of prebuilt VMs for the selected template:"); foreach (VMOutput v in existingVms) vmList.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td><a href=\"{3}\" target=\"_blank\">Download</a></td></tr>\n", v.VMTemplate.DisplayName, v.FileName, v.LastModified, v.DownloadUrl);  message.Append(vmList.ToString());  redirectToVMOutputList = true;  }  SendConfirmationEmail(vmrequest.CreatedBy, message.ToString());  if (redirectToVMOutputList) return RedirectToAction("ListAvailable", "VMOutput", new { templateId = vmrequest.TemplateId }); else return View("Success"); } catch (DbEntityValidationException e) { Api.Core.Exceptions.ExceptionManager.HandleException(e); return View("Error");; } }  ViewBag.RequestStatus = new SelectList(db.RequestStatus, "Id", "Name", vmrequest.RequestStatus); ViewBag.TemplateId = new SelectList(db.VMTemplates, "Id", "UniqueName", vmrequest.TemplateId); return View(vmrequest);         }


        // to refacture
        private void SendConfirmationEmail(string destination, string vmUrlList ) {  try { ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; }; if (string.IsNullOrEmpty(vmUrlList)) vmUrlList = "<tr><td colspan=\"4\">Presently no pre-built VM is available for download.</td></tr>\n" ; VMFactory.Api.Core.Helper.Email.SendEmail( ConfigurationManager.AppSettings["OutgoingEmailSmtpServer"].ToString(), ConfigurationManager.AppSettings["OutgoingEmailFromAddress"].ToString(), destination, "VM creation request ", Api.Business.Templates.VMRequestEmailTemplate.body.Replace("{{ROWS}}", vmUrlList).Replace("{{VMFACTORYURL}}", this.HttpContext.ApplicationInstance.Request.Url.AbsoluteUri), new System.Net.NetworkCredential(ConfigurationManager.AppSettings["OutgoingEmailSmtpUser"].ToString(), ConfigurationManager.AppSettings["OutgoingEmailSmtpPassword"].ToString()), true);             } catch (Exception e) { Api.Core.Exceptions.ExceptionManager.HandleException(e); } } 
        // end to refacture




        //
        // GET: /Default1/Edit/5
        [Authorize]
        public ActionResult Edit(long id = 0) { VMRequest vmrequest = db.VMRequests.Find(id); if (vmrequest == null) return HttpNotFound();  ViewBag.RequestStatus = new SelectList(db.RequestStatus, "Id", "Name", vmrequest.RequestStatus); ViewBag.TemplateId = new SelectList(db.VMTemplates, "Id", "UniqueName", vmrequest.TemplateId); return View(vmrequest); }

        //
        // POST: /Default1/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VMRequest vmrequest) { if (ModelState.IsValid) { db.Entry(vmrequest).State = EntityState.Modified; db.SaveChanges(); return RedirectToAction("Index"); } ViewBag.RequestStatus = new SelectList(db.RequestStatus, "Id", "Name", vmrequest.RequestStatus); ViewBag.TemplateId = new SelectList(db.VMTemplates, "Id", "UniqueName", vmrequest.TemplateId); return View(vmrequest); } 
        //
        // GET: /Default1/Delete/5
        [Authorize]
        public ActionResult Delete(long id = 0) { VMRequest vmrequest = db.VMRequests.Find(id); if (vmrequest == null) return HttpNotFound();  return View(vmrequest); }

        //
        // POST: /Default1/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id) { VMRequest vmrequest = db.VMRequests.Find(id); db.VMRequests.Remove(vmrequest); db.SaveChanges(); return RedirectToAction("Index"); }

        protected override void Dispose(bool disposing) { db.Dispose(); base.Dispose(disposing); }
    }
}