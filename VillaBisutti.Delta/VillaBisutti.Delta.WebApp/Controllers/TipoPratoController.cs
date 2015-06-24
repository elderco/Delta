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
    public class TipoPratoController : Controller
    {
        private Context db = new Context();

        // GET: /TipoPrato/
        public ActionResult Index()
        {
            return View(db.TipoPrato.ToList());
        }

        // GET: /TipoPrato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPrato tipoprato = db.TipoPrato.Find(id);
            if (tipoprato == null)
            {
                return HttpNotFound();
            }
            return View(tipoprato);
        }

        // GET: /TipoPrato/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoPrato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome")] TipoPrato tipoprato)
        {
            if (ModelState.IsValid)
            {
                db.TipoPrato.Add(tipoprato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoprato);
        }

        // GET: /TipoPrato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPrato tipoprato = db.TipoPrato.Find(id);
            if (tipoprato == null)
            {
                return HttpNotFound();
            }
            return View(tipoprato);
        }

        // POST: /TipoPrato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome")] TipoPrato tipoprato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoprato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoprato);
        }

        // GET: /TipoPrato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPrato tipoprato = db.TipoPrato.Find(id);
            if (tipoprato == null)
            {
                return HttpNotFound();
            }
            return View(tipoprato);
        }

        // POST: /TipoPrato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoPrato tipoprato = db.TipoPrato.Find(id);
            db.TipoPrato.Remove(tipoprato);
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
