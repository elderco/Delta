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
    public class TipoItemBebidaController : Controller
    {
        private Context db = new Context();

        // GET: /TipoItemBebida/
        public ActionResult Index()
        {
            return View(db.TipoItemBebida.ToList());
        }

        // GET: /TipoItemBebida/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoItemBebida tipoitembebida = db.TipoItemBebida.Find(id);
            if (tipoitembebida == null)
            {
                return HttpNotFound();
            }
            return View(tipoitembebida);
        }

        // GET: /TipoItemBebida/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoItemBebida/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome")] TipoItemBebida tipoitembebida)
        {
            if (ModelState.IsValid)
            {
                db.TipoItemBebida.Add(tipoitembebida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoitembebida);
        }

        // GET: /TipoItemBebida/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoItemBebida tipoitembebida = db.TipoItemBebida.Find(id);
            if (tipoitembebida == null)
            {
                return HttpNotFound();
            }
            return View(tipoitembebida);
        }

        // POST: /TipoItemBebida/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome")] TipoItemBebida tipoitembebida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoitembebida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoitembebida);
        }

        // GET: /TipoItemBebida/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoItemBebida tipoitembebida = db.TipoItemBebida.Find(id);
            if (tipoitembebida == null)
            {
                return HttpNotFound();
            }
            return View(tipoitembebida);
        }

        // POST: /TipoItemBebida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoItemBebida tipoitembebida = db.TipoItemBebida.Find(id);
            db.TipoItemBebida.Remove(tipoitembebida);
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
