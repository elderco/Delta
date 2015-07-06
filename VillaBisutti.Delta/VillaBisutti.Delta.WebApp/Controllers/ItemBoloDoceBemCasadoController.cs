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
    public class ItemBoloDoceBemCasadoController : Controller
    {
        private Context db = new Context();

        // GET: /ItemBoloDoceBemCasado/
        public ActionResult Index()
        {
            var itembolodocebemcasado = db.ItemBoloDoceBemCasado.Include(i => i.Fornecedor);
            return View(itembolodocebemcasado.ToList());
        }

        // GET: /ItemBoloDoceBemCasado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemBoloDoceBemCasado itembolodocebemcasado = db.ItemBoloDoceBemCasado.Find(id);
            if (itembolodocebemcasado == null)
            {
                return HttpNotFound();
            }
            return View(itembolodocebemcasado);
        }

        // GET: /ItemBoloDoceBemCasado/Create
        public ActionResult Create()
        {
            ViewBag.FornecedorId = new SelectList(db.FornecedorBoloDoceBemCasado, "Id", "NomeFornecedor");
            return View();
        }

        // POST: /ItemBoloDoceBemCasado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,Quantidade,FornecedorId")] ItemBoloDoceBemCasado itembolodocebemcasado)
        {
            if (ModelState.IsValid)
            {
                db.ItemBoloDoceBemCasado.Add(itembolodocebemcasado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FornecedorId = new SelectList(db.FornecedorBoloDoceBemCasado, "Id", "NomeFornecedor", itembolodocebemcasado.FornecedorId);
            return View(itembolodocebemcasado);
        }

        // GET: /ItemBoloDoceBemCasado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemBoloDoceBemCasado itembolodocebemcasado = db.ItemBoloDoceBemCasado.Find(id);
            if (itembolodocebemcasado == null)
            {
                return HttpNotFound();
            }
            ViewBag.FornecedorId = new SelectList(db.FornecedorBoloDoceBemCasado, "Id", "NomeFornecedor", itembolodocebemcasado.FornecedorId);
            return View(itembolodocebemcasado);
        }

        // POST: /ItemBoloDoceBemCasado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,Quantidade,FornecedorId")] ItemBoloDoceBemCasado itembolodocebemcasado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itembolodocebemcasado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FornecedorId = new SelectList(db.FornecedorBoloDoceBemCasado, "Id", "NomeFornecedor", itembolodocebemcasado.FornecedorId);
            return View(itembolodocebemcasado);
        }

        // GET: /ItemBoloDoceBemCasado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemBoloDoceBemCasado itembolodocebemcasado = db.ItemBoloDoceBemCasado.Find(id);
            if (itembolodocebemcasado == null)
            {
                return HttpNotFound();
            }
            return View(itembolodocebemcasado);
        }

        // POST: /ItemBoloDoceBemCasado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemBoloDoceBemCasado itembolodocebemcasado = db.ItemBoloDoceBemCasado.Find(id);
            db.ItemBoloDoceBemCasado.Remove(itembolodocebemcasado);
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
