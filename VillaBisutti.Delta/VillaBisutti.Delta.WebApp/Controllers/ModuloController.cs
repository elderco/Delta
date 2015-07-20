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
    public class ModuloController : Controller
    {
        // GET: Moduloes
        public ActionResult Index()
        {
            return View(new data.Modulo().GetCollection(0));
        }

        // GET: Moduloes/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Modulo modulo = db.Moduloes.Find(id);
        //    if (modulo == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(modulo);
        //}

        //// GET: Moduloes/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Moduloes/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Nome,URL")] Modulo modulo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Moduloes.Add(modulo);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(modulo);
        //}

        //// GET: Moduloes/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Modulo modulo = db.Moduloes.Find(id);
        //    if (modulo == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(modulo);
        //}

        //// POST: Moduloes/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Nome,URL")] Modulo modulo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(modulo).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(modulo);
        //}

        //// GET: Moduloes/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Modulo modulo = db.Moduloes.Find(id);
        //    if (modulo == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(modulo);
        //}

        //// POST: Moduloes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Modulo modulo = db.Moduloes.Find(id);
        //    db.Moduloes.Remove(modulo);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
