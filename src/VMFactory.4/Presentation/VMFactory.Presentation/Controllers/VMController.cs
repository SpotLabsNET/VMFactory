using System.Web.Mvc;

namespace VMFactory.Presentation.Controllers
{
    public class VMController : VMFactoryBaseController
    {
        //
        // GET: /VM/
        //[Authorize]
        public ActionResult Index() { return View(); }

        //
        // GET: /VM/Details/5
        //[Authorize]
        public ActionResult Details(int id) { return View(); }

        //
        // GET: /VM/Create
        //[Authorize]
        public ActionResult Create() { return View(); }


        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Status() { return View(); }


        //
        // POST: /VM/Create
        //[Authorize]
        [HttpPost]
        public ActionResult Create(FormCollection collection) { try { return RedirectToAction("Index"); } catch { return View(); } } 


        //
        // POST: /VM/Create
        //[Authorize]
        [HttpPost]
        public ActionResult RequestTemplate(FormCollection collection) { try { return RedirectToAction("Index"); } catch { return View(); } } 



        //
        // GET: /VM/Edit/5
        //[Authorize]
        public ActionResult Edit(int id) { return View(); }

        //
        // POST: /VM/Edit/5
        //[Authorize]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) { try { return RedirectToAction("Index"); } catch { return View(); } } 
        //
        // GET: /VM/Delete/5
        //[Authorize]
        public ActionResult Delete(int id) { return View(); }

        //
        // POST: /VM/Delete/5
        //[Authorize]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) { try { return RedirectToAction("Index"); } catch { return View(); } } 



        // show the RequestTemplate Form
        //[Authorize]
        public ActionResult RequestTemplate() {  return View(); }



        //// process the RequestTemplate form
        ////[Authorize]
        //[HttpPost]
        //public ActionResult CreateRequestTemplate(FormCollection fc, string searchString)
        //{
        //    try
        //    {
        //        // dump what we receive

        //        return RedirectToAction("Index");

        //    }
        //    catch (Exception ex)
        //    {

        //        return RedirectToAction("Error", "Shared");
        //    }


        //}



    }
}
