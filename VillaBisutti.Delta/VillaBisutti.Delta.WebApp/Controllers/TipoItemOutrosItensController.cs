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
    public class TipoItemOutrosItensController : Controller
    {
        private Context db = new Context();

        // GET: /TipoItemOutrosItens/
        public ActionResult Index()
        {
            return View(db.TipoItemOutrosItens.ToList());
        }

        // GET: /TipoItemOutrosItens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoItemOutrosItens tipoitemoutrositens = db.TipoItemOutrosItens.Find(id);
            if (tipoitemoutrositens == null)
            {
                return HttpNotFound();
            }
            return View(tipoitemoutrositens);
        }

        // GET: /TipoItemOutrosItens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoItemOutrosItens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome")] TipoItemOutrosItens tipoitemoutrositens)
        {
            if (ModelState.IsValid)
            {
                db.TipoItemOutrosItens.Add(tipoitemoutrositens);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoitemoutrositens);
        }

        // GET: /TipoItemOutrosItens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoItemOutrosItens tipoitemoutrositens = db.TipoItemOutrosItens.Find(id);
            if (tipoitemoutrositens == null)
            {
                return HttpNotFound();
            }
            return View(tipoitemoutrositens);
        }

        // POST: /TipoItemOutrosItens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome")] TipoItemOutrosItens tipoitemoutrositens)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoitemoutrositens).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoitemoutrositens);
        }

        // GET: /TipoItemOutrosItens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoItemOutrosItens tipoitemoutrositens = db.TipoItemOutrosItens.Find(id);
            if (tipoitemoutrositens == null)
            {
                return HttpNotFound();
            }
            return View(tipoitemoutrositens);
        }

        // POST: /TipoItemOutrosItens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoItemOutrosItens tipoitemoutrositens = db.TipoItemOutrosItens.Find(id);
            db.TipoItemOutrosItens.Remove(tipoitemoutrositens);
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
