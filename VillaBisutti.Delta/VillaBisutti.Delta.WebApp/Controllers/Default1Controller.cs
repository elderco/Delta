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
    public class Default1Controller : Controller
    {
        private Context db = new Context();

        // GET: /Default1/
        public ActionResult Index()
        {
            var itemformabolodocebemcasado = db.ItemFormaBoloDoceBemCasado.Include(i => i.Fornecedor);
            return View(itemformabolodocebemcasado.ToList());
        }

        // GET: /Default1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemFormaBoloDoceBemCasado itemformabolodocebemcasado = db.ItemFormaBoloDoceBemCasado.Find(id);
            if (itemformabolodocebemcasado == null)
            {
                return HttpNotFound();
            }
            return View(itemformabolodocebemcasado);
        }

        // GET: /Default1/Create
        public ActionResult Create()
        {
            ViewBag.FornecedorId = new SelectList(db.FornecedorBoloDoceBemCasado, "Id", "NomeFornecedor");
            return View();
        }

        // POST: /Default1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,FornecedorId")] ItemFormaBoloDoceBemCasado itemformabolodocebemcasado)
        {
            if (ModelState.IsValid)
            {
                db.ItemFormaBoloDoceBemCasado.Add(itemformabolodocebemcasado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FornecedorId = new SelectList(db.FornecedorBoloDoceBemCasado, "Id", "NomeFornecedor", itemformabolodocebemcasado.FornecedorId);
            return View(itemformabolodocebemcasado);
        }

        // GET: /Default1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemFormaBoloDoceBemCasado itemformabolodocebemcasado = db.ItemFormaBoloDoceBemCasado.Find(id);
            if (itemformabolodocebemcasado == null)
            {
                return HttpNotFound();
            }
            ViewBag.FornecedorId = new SelectList(db.FornecedorBoloDoceBemCasado, "Id", "NomeFornecedor", itemformabolodocebemcasado.FornecedorId);
            return View(itemformabolodocebemcasado);
        }

        // POST: /Default1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,FornecedorId")] ItemFormaBoloDoceBemCasado itemformabolodocebemcasado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemformabolodocebemcasado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FornecedorId = new SelectList(db.FornecedorBoloDoceBemCasado, "Id", "NomeFornecedor", itemformabolodocebemcasado.FornecedorId);
            return View(itemformabolodocebemcasado);
        }

        // GET: /Default1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemFormaBoloDoceBemCasado itemformabolodocebemcasado = db.ItemFormaBoloDoceBemCasado.Find(id);
            if (itemformabolodocebemcasado == null)
            {
                return HttpNotFound();
            }
            return View(itemformabolodocebemcasado);
        }

        // POST: /Default1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemFormaBoloDoceBemCasado itemformabolodocebemcasado = db.ItemFormaBoloDoceBemCasado.Find(id);
            db.ItemFormaBoloDoceBemCasado.Remove(itemformabolodocebemcasado);
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
