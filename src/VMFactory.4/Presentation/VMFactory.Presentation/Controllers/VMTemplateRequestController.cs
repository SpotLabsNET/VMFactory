using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VMFactory.Api.Data.Models;

namespace VMFactory.Presentation.Controllers
{
    public class VMTemplateRequestController : VMFactoryBaseController
    {
        private VMFSupportContext db = new VMFSupportContext();

        //
        // GET: /VMTemplateRequest/

        public ActionResult Index() { return View(db.VMTemplateRequests.ToList()); }

        //
        // GET: /VMTemplateRequest/Details/5

        public ActionResult Details(int id = 0) { VMTemplateRequest vmtemplaterequest = db.VMTemplateRequests.Find(id); if (vmtemplaterequest == null) return HttpNotFound();  return View(vmtemplaterequest); }

        //
        // GET: /VMTemplateRequest/Create

        public ActionResult Create() { return View(); }

        //
        // POST: /VMTemplateRequest/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMTemplateRequest vmtemplaterequest) { try { if (ModelState.IsValid) { db.VMTemplateRequests.Add(vmtemplaterequest); db.SaveChanges(); return View("Success"); }  return View(vmtemplaterequest); } catch (Exception e) { Api.Core.Exceptions.ExceptionManager.HandleException(e); return View("Error"); } }

        //
        // GET: /VMTemplateRequest/Edit/5

        public ActionResult Edit(int id = 0) { VMTemplateRequest vmtemplaterequest = db.VMTemplateRequests.Find(id); if (vmtemplaterequest == null) { return HttpNotFound(); } return View(vmtemplaterequest); }

        //
        // POST: /VMTemplateRequest/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VMTemplateRequest vmtemplaterequest) { if (ModelState.IsValid) { db.Entry(vmtemplaterequest).State = EntityState.Modified; db.SaveChanges(); return RedirectToAction("Index"); } return View(vmtemplaterequest); }

        //
        // GET: /VMTemplateRequest/Delete/5

        public ActionResult Delete(int id = 0) { VMTemplateRequest vmtemplaterequest = db.VMTemplateRequests.Find(id); if (vmtemplaterequest == null) { return HttpNotFound(); } return View(vmtemplaterequest); }

        //
        // POST: /VMTemplateRequest/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) { VMTemplateRequest vmtemplaterequest = db.VMTemplateRequests.Find(id); db.VMTemplateRequests.Remove(vmtemplaterequest); db.SaveChanges(); return RedirectToAction("Index"); }

        protected override void Dispose(bool disposing) { db.Dispose(); base.Dispose(disposing); }
    }
}