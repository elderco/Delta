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
    public class FornecedorBoloDoceBemCasadoController : Controller
    {
        private Context db = new Context();

        // GET: /FornecedorBoloDoceBemCasado/
        public ActionResult Index()
        {
            return View(db.FornecedorBoloDoceBemCasado.ToList());
        }

        // GET: /FornecedorBoloDoceBemCasado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorBoloDoceBemCasado fornecedorbolodocebemcasado = db.FornecedorBoloDoceBemCasado.Find(id);
            if (fornecedorbolodocebemcasado == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorbolodocebemcasado);
        }

        // GET: /FornecedorBoloDoceBemCasado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /FornecedorBoloDoceBemCasado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,NomeFornecedor")] FornecedorBoloDoceBemCasado fornecedorbolodocebemcasado)
        {
            if (ModelState.IsValid)
            {
                db.FornecedorBoloDoceBemCasado.Add(fornecedorbolodocebemcasado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fornecedorbolodocebemcasado);
        }

        // GET: /FornecedorBoloDoceBemCasado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorBoloDoceBemCasado fornecedorbolodocebemcasado = db.FornecedorBoloDoceBemCasado.Find(id);
            if (fornecedorbolodocebemcasado == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorbolodocebemcasado);
        }

        // POST: /FornecedorBoloDoceBemCasado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,NomeFornecedor")] FornecedorBoloDoceBemCasado fornecedorbolodocebemcasado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fornecedorbolodocebemcasado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fornecedorbolodocebemcasado);
        }

        // GET: /FornecedorBoloDoceBemCasado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorBoloDoceBemCasado fornecedorbolodocebemcasado = db.FornecedorBoloDoceBemCasado.Find(id);
            if (fornecedorbolodocebemcasado == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorbolodocebemcasado);
        }

        // POST: /FornecedorBoloDoceBemCasado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FornecedorBoloDoceBemCasado fornecedorbolodocebemcasado = db.FornecedorBoloDoceBemCasado.Find(id);
            db.FornecedorBoloDoceBemCasado.Remove(fornecedorbolodocebemcasado);
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
