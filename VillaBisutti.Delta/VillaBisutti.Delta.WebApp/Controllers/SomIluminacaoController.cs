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
    public class SomIluminacaoController : Controller
    {
        private Context db = new Context();

        // GET: /SomIluminacao/
        public ActionResult Index()
        {
            var somiluminacao = db.SomIluminacao.Include(s => s.Evento);
            return View(somiluminacao.ToList());
        }

        // GET: /SomIluminacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SomIluminacao somiluminacao = db.SomIluminacao.Find(id);
            if (somiluminacao == null)
            {
                return HttpNotFound();
            }
            return View(somiluminacao);
        }

        // GET: /SomIluminacao/Create
        public ActionResult Create()
        {
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria");
            return View();
        }

        // POST: /SomIluminacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EventoId,Observacoes")] SomIluminacao somiluminacao)
        {
            if (ModelState.IsValid)
            {
                db.SomIluminacao.Add(somiluminacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", somiluminacao.EventoId);
            return View(somiluminacao);
        }

        // GET: /SomIluminacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SomIluminacao somiluminacao = db.SomIluminacao.Find(id);
            if (somiluminacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", somiluminacao.EventoId);
            return View(somiluminacao);
        }

        // POST: /SomIluminacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EventoId,Observacoes")] SomIluminacao somiluminacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(somiluminacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", somiluminacao.EventoId);
            return View(somiluminacao);
        }

        // GET: /SomIluminacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SomIluminacao somiluminacao = db.SomIluminacao.Find(id);
            if (somiluminacao == null)
            {
                return HttpNotFound();
            }
            return View(somiluminacao);
        }

        // POST: /SomIluminacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SomIluminacao somiluminacao = db.SomIluminacao.Find(id);
            db.SomIluminacao.Remove(somiluminacao);
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
