using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using model = VillaBisutti.Delta.Core.Model;
using data = VillaBisutti.Delta.Core.Data;

namespace VillaBisutti.Delta.WebApp.Controllers
{
    public class LocalController : Controller
    {

        // GET: /Local/
        public ActionResult Index()
        {
			return View(new data.Local().GetCollection(0));
        }

        // GET: /Local/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.Local local = new data.Local().GetElement(id.HasValue ? id.Value : 0);
            if (local == null)
            {
                return HttpNotFound();
            }
            return View(local);
        }

        // GET: /Local/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Local/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,NomeCasa,SiglaCasa,EnderecoCasa")] model.Local local)
        {
            if (ModelState.IsValid)
            {
				new data.Local().Insert(local);
                return RedirectToAction("Index");
            }
            return View(local);
        }

        // GET: /Local/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.Local local = new data.Local().GetElement(id.HasValue ? id.Value : 0);
            if (local == null)
            {
                return HttpNotFound();
            }
            return View(local);
        }

        // POST: /Local/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,NomeCasa,SiglaCasa,EnderecoCasa")] model.Local local)
        {
            if (ModelState.IsValid)
            {
				new data.Local().Update(local);
                return RedirectToAction("Index");
            }
            return View(local);
        }

        // GET: /Local/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.Local local = new data.Local().GetElement(id.HasValue ? id.Value : 0);
            if (local == null)
            {
                return HttpNotFound();
            }
            return View(local);
        }

        // POST: /Local/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			new data.Local().Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
