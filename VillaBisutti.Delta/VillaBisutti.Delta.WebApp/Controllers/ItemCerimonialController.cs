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
    public class ItemCerimonialController : Controller
    {
        // GET: /ItemCerimonial/
        public ActionResult Index()
        {
			ViewBag.TipoEvento = TipoEvento;
			return View(new data.ItemCerimonial().GetFromTipoEvento(TipoEvento));
        }

        // GET: /ItemCerimonial/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCerimonial itemcerimonial = db.ItemCerimonial.Find(id);
            if (itemcerimonial == null)
            {
                return HttpNotFound();
            }
            return View(itemcerimonial);
        }

        // GET: /ItemCerimonial/Create
        public ActionResult Create()
        {
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "NomeResponsavel");
            return View();
        }

        // POST: /ItemCerimonial/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Titulo,HorarioInicio,Importante,Observacao,TipoEvento,EventoId")] ItemCerimonial itemcerimonial)
        {
            if (ModelState.IsValid)
            {
                db.ItemCerimonial.Add(itemcerimonial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventoId = new SelectList(db.Evento, "Id", "NomeResponsavel", itemcerimonial.EventoId);
            return View(itemcerimonial);
        }

        // GET: /ItemCerimonial/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCerimonial itemcerimonial = db.ItemCerimonial.Find(id);
            if (itemcerimonial == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "NomeResponsavel", itemcerimonial.EventoId);
            return View(itemcerimonial);
        }

        // POST: /ItemCerimonial/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Titulo,HorarioInicio,Importante,Observacao,TipoEvento,EventoId")] ItemCerimonial itemcerimonial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemcerimonial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "NomeResponsavel", itemcerimonial.EventoId);
            return View(itemcerimonial);
        }

        // GET: /ItemCerimonial/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCerimonial itemcerimonial = db.ItemCerimonial.Find(id);
            if (itemcerimonial == null)
            {
                return HttpNotFound();
            }
            return View(itemcerimonial);
        }

        // POST: /ItemCerimonial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemCerimonial itemcerimonial = db.ItemCerimonial.Find(id);
            db.ItemCerimonial.Remove(itemcerimonial);
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
