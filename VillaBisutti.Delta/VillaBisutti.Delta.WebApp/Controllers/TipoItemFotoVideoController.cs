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
    public class TipoItemFotoVideoController : Controller
    {
        private Context db = new Context();

        // GET: /TipoItemFotoVideo/
        public ActionResult Index()
        {
            return View(db.TipoItemFotoVideo.ToList());
        }

        // GET: /TipoItemFotoVideo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoItemFotoVideo tipoitemfotovideo = db.TipoItemFotoVideo.Find(id);
            if (tipoitemfotovideo == null)
            {
                return HttpNotFound();
            }
            return View(tipoitemfotovideo);
        }

        // GET: /TipoItemFotoVideo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoItemFotoVideo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome")] TipoItemFotoVideo tipoitemfotovideo)
        {
            if (ModelState.IsValid)
            {
                db.TipoItemFotoVideo.Add(tipoitemfotovideo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoitemfotovideo);
        }

        // GET: /TipoItemFotoVideo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoItemFotoVideo tipoitemfotovideo = db.TipoItemFotoVideo.Find(id);
            if (tipoitemfotovideo == null)
            {
                return HttpNotFound();
            }
            return View(tipoitemfotovideo);
        }

        // POST: /TipoItemFotoVideo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome")] TipoItemFotoVideo tipoitemfotovideo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoitemfotovideo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoitemfotovideo);
        }

        // GET: /TipoItemFotoVideo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoItemFotoVideo tipoitemfotovideo = db.TipoItemFotoVideo.Find(id);
            if (tipoitemfotovideo == null)
            {
                return HttpNotFound();
            }
            return View(tipoitemfotovideo);
        }

        // POST: /TipoItemFotoVideo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoItemFotoVideo tipoitemfotovideo = db.TipoItemFotoVideo.Find(id);
            db.TipoItemFotoVideo.Remove(tipoitemfotovideo);
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
