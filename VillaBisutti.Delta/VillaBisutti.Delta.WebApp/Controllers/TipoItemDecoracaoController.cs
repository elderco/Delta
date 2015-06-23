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
    public class TipoItemDecoracaoController : Controller
    {
        private Context db = new Context();

        // GET: /TipoItemDecoracao/
        public ActionResult Index()
        {
            return View(db.TipoItemDecoracao.ToList());
        }

        // GET: /TipoItemDecoracao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoItemDecoracao tipoitemdecoracao = db.TipoItemDecoracao.Find(id);
            if (tipoitemdecoracao == null)
            {
                return HttpNotFound();
            }
            return View(tipoitemdecoracao);
        }

        // GET: /TipoItemDecoracao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoItemDecoracao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,PadraoAniversario,PadraoBarmitzva,PadraoBatmitzva,PadraoCasamento,PadraoCorporativo,PadraoDebutante,PadraoOutro")] TipoItemDecoracao tipoitemdecoracao)
        {
            if (ModelState.IsValid)
            {
                db.TipoItemDecoracao.Add(tipoitemdecoracao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoitemdecoracao);
        }

        // GET: /TipoItemDecoracao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoItemDecoracao tipoitemdecoracao = db.TipoItemDecoracao.Find(id);
            if (tipoitemdecoracao == null)
            {
                return HttpNotFound();
            }
            return View(tipoitemdecoracao);
        }

        // POST: /TipoItemDecoracao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,PadraoAniversario,PadraoBarmitzva,PadraoBatmitzva,PadraoCasamento,PadraoCorporativo,PadraoDebutante,PadraoOutro")] TipoItemDecoracao tipoitemdecoracao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoitemdecoracao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoitemdecoracao);
        }

        // GET: /TipoItemDecoracao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoItemDecoracao tipoitemdecoracao = db.TipoItemDecoracao.Find(id);
            if (tipoitemdecoracao == null)
            {
                return HttpNotFound();
            }
            return View(tipoitemdecoracao);
        }

        // POST: /TipoItemDecoracao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoItemDecoracao tipoitemdecoracao = db.TipoItemDecoracao.Find(id);
            db.TipoItemDecoracao.Remove(tipoitemdecoracao);
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
