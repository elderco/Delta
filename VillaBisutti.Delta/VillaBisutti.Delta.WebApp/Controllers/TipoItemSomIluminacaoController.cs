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
    public class TipoItemSomIluminacaoController : Controller
    {
        private Context db = new Context();

        // GET: /TipoItemSomIluminacao/
        public ActionResult Index()
        {
            return View(db.TipoItemSomIluminacao.ToList());
        }

        // GET: /TipoItemSomIluminacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoItemSomIluminacao tipoitemsomiluminacao = db.TipoItemSomIluminacao.Find(id);
            if (tipoitemsomiluminacao == null)
            {
                return HttpNotFound();
            }
            return View(tipoitemsomiluminacao);
        }

        // GET: /TipoItemSomIluminacao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoItemSomIluminacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome")] TipoItemSomIluminacao tipoitemsomiluminacao)
        {
            if (ModelState.IsValid)
            {
                db.TipoItemSomIluminacao.Add(tipoitemsomiluminacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoitemsomiluminacao);
        }

        // GET: /TipoItemSomIluminacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoItemSomIluminacao tipoitemsomiluminacao = db.TipoItemSomIluminacao.Find(id);
            if (tipoitemsomiluminacao == null)
            {
                return HttpNotFound();
            }
            return View(tipoitemsomiluminacao);
        }

        // POST: /TipoItemSomIluminacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome")] TipoItemSomIluminacao tipoitemsomiluminacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoitemsomiluminacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoitemsomiluminacao);
        }

        // GET: /TipoItemSomIluminacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoItemSomIluminacao tipoitemsomiluminacao = db.TipoItemSomIluminacao.Find(id);
            if (tipoitemsomiluminacao == null)
            {
                return HttpNotFound();
            }
            return View(tipoitemsomiluminacao);
        }

        // POST: /TipoItemSomIluminacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoItemSomIluminacao tipoitemsomiluminacao = db.TipoItemSomIluminacao.Find(id);
            db.TipoItemSomIluminacao.Remove(tipoitemsomiluminacao);
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
