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
    public class TipoItemMontagemController : Controller
    {
        private Context db = new Context();

        // GET: /TipoItemMontagem/
        public ActionResult Index()
        {
            return View(db.TipoItemMontagem.ToList());
        }

        // GET: /TipoItemMontagem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoItemMontagem tipoitemmontagem = db.TipoItemMontagem.Find(id);
            if (tipoitemmontagem == null)
            {
                return HttpNotFound();
            }
            return View(tipoitemmontagem);
        }

        // GET: /TipoItemMontagem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoItemMontagem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,PadraoAniversario,PadraoBarmitzva,PadraoBatmitzva,PadraoCasamento,PadraoCorporativo,PadraoDebutante,PadraoOutro")] TipoItemMontagem tipoitemmontagem)
        {
            if (ModelState.IsValid)
            {
                db.TipoItemMontagem.Add(tipoitemmontagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoitemmontagem);
        }

        // GET: /TipoItemMontagem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoItemMontagem tipoitemmontagem = db.TipoItemMontagem.Find(id);
            if (tipoitemmontagem == null)
            {
                return HttpNotFound();
            }
            return View(tipoitemmontagem);
        }

        // POST: /TipoItemMontagem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,PadraoAniversario,PadraoBarmitzva,PadraoBatmitzva,PadraoCasamento,PadraoCorporativo,PadraoDebutante,PadraoOutro")] TipoItemMontagem tipoitemmontagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoitemmontagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoitemmontagem);
        }

        // GET: /TipoItemMontagem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoItemMontagem tipoitemmontagem = db.TipoItemMontagem.Find(id);
            if (tipoitemmontagem == null)
            {
                return HttpNotFound();
            }
            return View(tipoitemmontagem);
        }

        // POST: /TipoItemMontagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoItemMontagem tipoitemmontagem = db.TipoItemMontagem.Find(id);
            db.TipoItemMontagem.Remove(tipoitemmontagem);
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
