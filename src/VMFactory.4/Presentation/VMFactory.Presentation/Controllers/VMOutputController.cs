using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VMFactory.Api.Data.Models;

namespace VMFactory.Presentation.Controllers
{
    public class VMOutputController : VMFactoryBaseController
    {
        private VMFSupportContext db = new VMFSupportContext();

        //
        // GET: /VMOutput/
        public ActionResult Index() { string currentUserEmailAddress = "rui.melo@portaldomar.com"; if (IsRegistered()) { var vmoutputs = from vo in db.VMOutputs join req in db.VMRequests on vo.VMRequestId equals req.Id where req.CreatedBy == currentUserEmailAddress select vo;  return View(vmoutputs.ToList()); }             else           return RedirectToAction("Register", "Home"); }


        //
        // GET: /VMOutput/ListAvailable
        public ActionResult ListAvailable(int templateId = 0) { string currentUserEmailAddress = ViewBag.EMail;  var vmoutputs = db.VMOutputs.Where( c => c.VMRequest.TemplateId == templateId && c.VMRequest.CreatedBy == currentUserEmailAddress).Include(v => v.VMTemplate).Include(v => v.VMRequest).OrderByDescending( c => c.VMRequest.CreatedBy);  return View(vmoutputs.ToList()); } 

        //
        // GET: /VMOutput/Details/5
        public ActionResult Details(int id = 0) { VMOutput vmoutput = db.VMOutputs.Find(id); if (vmoutput == null) return HttpNotFound();  return View(vmoutput); } 

        //
        // GET: /VMOutput/Create
        public ActionResult Create() { ViewBag.VMTemplateId = new SelectList(db.VMTemplates, "Id", "UniqueName"); ViewBag.VMRequestId = new SelectList(db.VMRequests, "Id", "DisplayName"); return View(); } 

        //
        // POST: /VMOutput/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMOutput vmoutput) { if (ModelState.IsValid) { db.VMOutputs.Add(vmoutput); db.SaveChanges(); return RedirectToAction("Index"); } ViewBag.VMTemplateId = new SelectList(db.VMTemplates, "Id", "UniqueName", vmoutput.VMTemplateId); ViewBag.VMRequestId = new SelectList(db.VMRequests, "Id", "DisplayName", vmoutput.VMRequestId); return View(vmoutput); } 

        //
        // GET: /VMOutput/Edit/5
        public ActionResult Edit(int id = 0) { VMOutput vmoutput = db.VMOutputs.Find(id); if (vmoutput == null) return HttpNotFound(); ViewBag.VMTemplateId = new SelectList(db.VMTemplates, "Id", "UniqueName", vmoutput.VMTemplateId); ViewBag.VMRequestId = new SelectList(db.VMRequests, "Id", "DisplayName", vmoutput.VMRequestId); return View(vmoutput); }

        //
        // POST: /VMOutput/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VMOutput vmoutput) { if (ModelState.IsValid) { db.Entry(vmoutput).State = EntityState.Modified; db.SaveChanges(); return RedirectToAction("Index"); } ViewBag.VMTemplateId = new SelectList(db.VMTemplates, "Id", "UniqueName", vmoutput.VMTemplateId); ViewBag.VMRequestId = new SelectList(db.VMRequests, "Id", "DisplayName", vmoutput.VMRequestId); return View(vmoutput); }

        //
        // GET: /VMOutput/Delete/5
        public ActionResult Delete(int id = 0) { VMOutput vmoutput = db.VMOutputs.Find(id); if (vmoutput == null) return HttpNotFound();  return View(vmoutput); } 

        //
        // POST: /VMOutput/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) { VMOutput vmoutput = db.VMOutputs.Find(id); db.VMOutputs.Remove(vmoutput); db.SaveChanges(); return RedirectToAction("Index"); } 
        protected override void Dispose(bool disposing) { db.Dispose(); base.Dispose(disposing); }
    }
}