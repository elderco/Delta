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
    public class DecoracaoCerimonialController : Controller
    {
        private Context db = new Context();

        // GET: /DecoracaoCerimonial/
        public ActionResult Index()
        {
            var decoracaocerimonial = db.DecoracaoCerimonial.Include(d => d.Evento);
            return View(decoracaocerimonial.ToList());
        }

        // GET: /DecoracaoCerimonial/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DecoracaoCerimonial decoracaocerimonial = db.DecoracaoCerimonial.Find(id);
            if (decoracaocerimonial == null)
            {
                return HttpNotFound();
            }
            return View(decoracaocerimonial);
        }

        // GET: /DecoracaoCerimonial/Create
        public ActionResult Create()
        {
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria");
            return View();
        }

        // POST: /DecoracaoCerimonial/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EventoId,CoresCerimonia,Observacoes")] DecoracaoCerimonial decoracaocerimonial)
        {
            if (ModelState.IsValid)
            {
                db.DecoracaoCerimonial.Add(decoracaocerimonial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", decoracaocerimonial.EventoId);
            return View(decoracaocerimonial);
        }

        // GET: /DecoracaoCerimonial/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DecoracaoCerimonial decoracaocerimonial = db.DecoracaoCerimonial.Find(id);
            if (decoracaocerimonial == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", decoracaocerimonial.EventoId);
            return View(decoracaocerimonial);
        }

        // POST: /DecoracaoCerimonial/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EventoId,CoresCerimonia,Observacoes")] DecoracaoCerimonial decoracaocerimonial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(decoracaocerimonial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", decoracaocerimonial.EventoId);
            return View(decoracaocerimonial);
        }

        // GET: /DecoracaoCerimonial/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DecoracaoCerimonial decoracaocerimonial = db.DecoracaoCerimonial.Find(id);
            if (decoracaocerimonial == null)
            {
                return HttpNotFound();
            }
            return View(decoracaocerimonial);
        }

        // POST: /DecoracaoCerimonial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DecoracaoCerimonial decoracaocerimonial = db.DecoracaoCerimonial.Find(id);
            db.DecoracaoCerimonial.Remove(decoracaocerimonial);
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
