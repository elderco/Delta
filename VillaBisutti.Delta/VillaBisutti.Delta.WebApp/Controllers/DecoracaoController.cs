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
    public class DecoracaoController : Controller
    {
        private Context db = new Context();

        // GET: /Decoracao/
        public ActionResult Index()
        {
            var decoracao = db.Decoracao.Include(d => d.Evento);
            return View(decoracao.ToList());
        }

        // GET: /Decoracao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Decoracao decoracao = db.Decoracao.Find(id);
            if (decoracao == null)
            {
                return HttpNotFound();
            }
            return View(decoracao);
        }

        // GET: /Decoracao/Create
        public ActionResult Create()
        {
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria");
            return View();
        }

        // POST: /Decoracao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EventoId,CoresCerimonia,Observacoes")] Decoracao decoracao)
        {
            if (ModelState.IsValid)
            {
                db.Decoracao.Add(decoracao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", decoracao.EventoId);
            return View(decoracao);
        }

        // GET: /Decoracao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Decoracao decoracao = db.Decoracao.Find(id);
            if (decoracao == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", decoracao.EventoId);
            return View(decoracao);
        }

        // POST: /Decoracao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EventoId,CoresCerimonia,Observacoes")] Decoracao decoracao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(decoracao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", decoracao.EventoId);
            return View(decoracao);
        }

        // GET: /Decoracao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Decoracao decoracao = db.Decoracao.Find(id);
            if (decoracao == null)
            {
                return HttpNotFound();
            }
            return View(decoracao);
        }

        // POST: /Decoracao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Decoracao decoracao = db.Decoracao.Find(id);
            db.Decoracao.Remove(decoracao);
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
