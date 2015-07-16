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
    public class RoteiroController : Controller
    {
        private Context db = new Context();

        // GET: /Roteiro/
        public ActionResult Index()
        {
            var itemroteiro = db.ItemRoteiro.Include(i => i.Evento);
            return View(itemroteiro.ToList());
        }

        // GET: /Roteiro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemRoteiro itemroteiro = db.ItemRoteiro.Find(id);
            if (itemroteiro == null)
            {
                return HttpNotFound();
            }
            return View(itemroteiro);
        }

        // GET: /Roteiro/Create
        public ActionResult Create()
        {
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria");
            return View();
        }

        // POST: /Roteiro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Titulo,HorarioInicio,Importante,Observacao,TipoEvento,EventoId")] ItemRoteiro itemroteiro)
        {
            if (ModelState.IsValid)
            {
                db.ItemRoteiro.Add(itemroteiro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", itemroteiro.EventoId);
            return View(itemroteiro);
        }

        // GET: /Roteiro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemRoteiro itemroteiro = db.ItemRoteiro.Find(id);
            if (itemroteiro == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", itemroteiro.EventoId);
            return View(itemroteiro);
        }

        // POST: /Roteiro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Titulo,HorarioInicio,Importante,Observacao,TipoEvento,EventoId")] ItemRoteiro itemroteiro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemroteiro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", itemroteiro.EventoId);
            return View(itemroteiro);
        }

        // GET: /Roteiro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemRoteiro itemroteiro = db.ItemRoteiro.Find(id);
            if (itemroteiro == null)
            {
                return HttpNotFound();
            }
            return View(itemroteiro);
        }

        // POST: /Roteiro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemRoteiro itemroteiro = db.ItemRoteiro.Find(id);
            db.ItemRoteiro.Remove(itemroteiro);
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
