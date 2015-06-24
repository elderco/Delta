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
    public class ItemBebidaController : Controller
    {
        private Context db = new Context();

        // GET: /ItemBebida/
        public ActionResult Index()
        {
            var itembebida = db.ItemBebida.Include(i => i.TipoItemBebida);
            return View(itembebida.ToList());
        }

        // GET: /ItemBebida/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemBebida itembebida = db.ItemBebida.Find(id);
            if (itembebida == null)
            {
                return HttpNotFound();
            }
            return View(itembebida);
        }

        // GET: /ItemBebida/Create
        public ActionResult Create()
        {
            ViewBag.TipoItemBebidaId = new SelectList(db.TipoItemBebida, "Id", "Nome");
            return View();
        }

        // POST: /ItemBebida/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,Quantidade,TipoItemBebidaId")] ItemBebida itembebida)
        {
            if (ModelState.IsValid)
            {
                db.ItemBebida.Add(itembebida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoItemBebidaId = new SelectList(db.TipoItemBebida, "Id", "Nome", itembebida.TipoItemBebidaId);
            return View(itembebida);
        }

        // GET: /ItemBebida/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemBebida itembebida = db.ItemBebida.Find(id);
            if (itembebida == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoItemBebidaId = new SelectList(db.TipoItemBebida, "Id", "Nome", itembebida.TipoItemBebidaId);
            return View(itembebida);
        }

        // POST: /ItemBebida/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,Quantidade,TipoItemBebidaId")] ItemBebida itembebida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itembebida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoItemBebidaId = new SelectList(db.TipoItemBebida, "Id", "Nome", itembebida.TipoItemBebidaId);
            return View(itembebida);
        }

        // GET: /ItemBebida/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemBebida itembebida = db.ItemBebida.Find(id);
            if (itembebida == null)
            {
                return HttpNotFound();
            }
            return View(itembebida);
        }

        // POST: /ItemBebida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemBebida itembebida = db.ItemBebida.Find(id);
            db.ItemBebida.Remove(itembebida);
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
