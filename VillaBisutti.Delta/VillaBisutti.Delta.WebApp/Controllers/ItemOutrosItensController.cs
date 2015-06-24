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
    public class ItemOutrosItensController : Controller
    {
        private Context db = new Context();

        // GET: /ItemOutrosItens/
        public ActionResult Index()
        {
            var itemoutrositens = db.ItemOutrosItens.Include(i => i.TipoItemOutroItemItemDiverso);
            return View(itemoutrositens.ToList());
        }

        // GET: /ItemOutrosItens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemOutrosItens itemoutrositens = db.ItemOutrosItens.Find(id);
            if (itemoutrositens == null)
            {
                return HttpNotFound();
            }
            return View(itemoutrositens);
        }

        // GET: /ItemOutrosItens/Create
        public ActionResult Create()
        {
            ViewBag.TipoItemOutroItemItemDiversoId = new SelectList(db.TipoItemOutrosItens, "Id", "Nome");
            return View();
        }

        // POST: /ItemOutrosItens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,Quantidade,TipoItemOutroItemItemDiversoId")] ItemOutrosItens itemoutrositens)
        {
            if (ModelState.IsValid)
            {
                db.ItemOutrosItens.Add(itemoutrositens);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoItemOutroItemItemDiversoId = new SelectList(db.TipoItemOutrosItens, "Id", "Nome", itemoutrositens.TipoItemOutroItemItemDiversoId);
            return View(itemoutrositens);
        }

        // GET: /ItemOutrosItens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemOutrosItens itemoutrositens = db.ItemOutrosItens.Find(id);
            if (itemoutrositens == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoItemOutroItemItemDiversoId = new SelectList(db.TipoItemOutrosItens, "Id", "Nome", itemoutrositens.TipoItemOutroItemItemDiversoId);
            return View(itemoutrositens);
        }

        // POST: /ItemOutrosItens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,Quantidade,TipoItemOutroItemItemDiversoId")] ItemOutrosItens itemoutrositens)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemoutrositens).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoItemOutroItemItemDiversoId = new SelectList(db.TipoItemOutrosItens, "Id", "Nome", itemoutrositens.TipoItemOutroItemItemDiversoId);
            return View(itemoutrositens);
        }

        // GET: /ItemOutrosItens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemOutrosItens itemoutrositens = db.ItemOutrosItens.Find(id);
            if (itemoutrositens == null)
            {
                return HttpNotFound();
            }
            return View(itemoutrositens);
        }

        // POST: /ItemOutrosItens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemOutrosItens itemoutrositens = db.ItemOutrosItens.Find(id);
            db.ItemOutrosItens.Remove(itemoutrositens);
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
