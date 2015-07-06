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
    public class BebidaController : Controller
    {
		data.Context db = new data.Context();
        // GET: /Bebida/
        public ActionResult Index()
        {
            var bebida = db.Bebida.Include(b => b.Evento);
            return View(bebida.ToList());
        }

        // GET: /Bebida/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model.Bebida bebida = db.Bebida.Find(id);
            if (bebida == null)
            {
                return HttpNotFound();
            }
            return View(bebida);
        }

        // GET: /Bebida/Create
        public ActionResult Create()
        {
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "NomeResponsavel");
            return View();
        }

        // POST: /Bebida/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EventoId,Id,Observacoes")] model.Bebida bebida)
        {
            if (ModelState.IsValid)
            {
                db.Bebida.Add(bebida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventoId = new SelectList(db.Evento, "Id", "NomeResponsavel", bebida.EventoId);
            return View(bebida);
        }

        // GET: /Bebida/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model.Bebida bebida = db.Bebida.Find(id);
            if (bebida == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "NomeResponsavel", bebida.EventoId);
            return View(bebida);
        }

        // POST: /Bebida/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EventoId,Id,Observacoes")] model.Bebida bebida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bebida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "NomeResponsavel", bebida.EventoId);
            return View(bebida);
        }

        // GET: /Bebida/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model.Bebida bebida = db.Bebida.Find(id);
            if (bebida == null)
            {
                return HttpNotFound();
            }
            return View(bebida);
        }

        // POST: /Bebida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            model.Bebida bebida = db.Bebida.Find(id);
            db.Bebida.Remove(bebida);
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
