using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VMFactory.Api.Data.Models;

namespace VMFactory.Presentation.Controllers
{
    public class VMTemplateController : VMFactoryBaseController
    {
        private VMFSupportContext db = new VMFSupportContext();

        //
        // GET: /VMTemplate/

        public ActionResult Index() { return View(db.VMTemplates.ToList()); }

        //
        // GET: /VMTemplate/Details/5

        public ActionResult Details(int id = 0) { VMTemplate vmtemplate = db.VMTemplates.Find(id); if (vmtemplate == null) { return HttpNotFound(); } return View(vmtemplate); }

        //
        // GET: /VMTemplate/Create

        public ActionResult Create() { return View(); }

        //
        // POST: /VMTemplate/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMTemplate vmtemplate) { try { if (ModelState.IsValid) { db.VMTemplates.Add(vmtemplate); db.SaveChanges(); return View("Success"); }  return View(vmtemplate); } catch (Exception e) { Api.Core.Exceptions.ExceptionManager.HandleException(e); return View("Error"); }  }

        //
        // GET: /VMTemplate/Edit/5

        public ActionResult Edit(int id = 0) { VMTemplate vmtemplate = db.VMTemplates.Find(id); if (vmtemplate == null) { return HttpNotFound(); } return View(vmtemplate);         }

        //
        // POST: /VMTemplate/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VMTemplate vmtemplate) { if (ModelState.IsValid) { db.Entry(vmtemplate).State = EntityState.Modified; db.SaveChanges(); return RedirectToAction("Index"); } return View(vmtemplate); }

        //
        // GET: /VMTemplate/Delete/5

        public ActionResult Delete(int id = 0) { VMTemplate vmtemplate = db.VMTemplates.Find(id); if (vmtemplate == null) { return HttpNotFound(); } return View(vmtemplate); }

        //
        // POST: /VMTemplate/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) { VMTemplate vmtemplate = db.VMTemplates.Find(id); db.VMTemplates.Remove(vmtemplate); db.SaveChanges(); return RedirectToAction("Index"); }

        protected override void Dispose(bool disposing) { db.Dispose(); base.Dispose(disposing); }
    }
}