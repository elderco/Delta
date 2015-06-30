using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VillaBisutti.Delta.Core.Model;
using VillaBisutti.Delta.Core.Data;

namespace VillaBisutti.Delta.WebApp.Controllers
{
    public class CronogramaCerimonialController : Controller
    {
        private Context db = new Context();

        // GET: /CronogramaCerimonial/
        public ActionResult Index()
        {
            return View(db.CronogramaCerimonial.ToList());
        }

        // GET: /CronogramaCerimonial/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CronogramaCerimonial cronogramacerimonial = db.CronogramaCerimonial.Find(id);
            if (cronogramacerimonial == null)
            {
                return HttpNotFound();
            }
            return View(cronogramacerimonial);
        }

        // GET: /CronogramaCerimonial/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CronogramaCerimonial/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id")] CronogramaCerimonial cronogramacerimonial)
        {
            if (ModelState.IsValid)
            {
                db.CronogramaCerimonial.Add(cronogramacerimonial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cronogramacerimonial);
        }

        // GET: /CronogramaCerimonial/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CronogramaCerimonial cronogramacerimonial = db.CronogramaCerimonial.Find(id);
            if (cronogramacerimonial == null)
            {
                return HttpNotFound();
            }
            return View(cronogramacerimonial);
        }

        // POST: /CronogramaCerimonial/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id")] CronogramaCerimonial cronogramacerimonial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cronogramacerimonial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cronogramacerimonial);
        }

        // GET: /CronogramaCerimonial/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CronogramaCerimonial cronogramacerimonial = db.CronogramaCerimonial.Find(id);
            if (cronogramacerimonial == null)
            {
                return HttpNotFound();
            }
            return View(cronogramacerimonial);
        }

        // POST: /CronogramaCerimonial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CronogramaCerimonial cronogramacerimonial = db.CronogramaCerimonial.Find(id);
            db.CronogramaCerimonial.Remove(cronogramacerimonial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
