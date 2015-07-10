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
    public class FotoVideoController : Controller
    {
        private Context db = new Context();

        // GET: /FotoVideo/
        public ActionResult Index()
        {
            var fotovideo = db.FotoVideo.Include(f => f.Evento);
            return View(fotovideo.ToList());
        }

        // GET: /FotoVideo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FotoVideo fotovideo = db.FotoVideo.Find(id);
            if (fotovideo == null)
            {
                return HttpNotFound();
            }
            return View(fotovideo);
        }

        // GET: /FotoVideo/Create
        public ActionResult Create()
        {
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria");
            return View();
        }

        // POST: /FotoVideo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EventoId,Observacoes")] FotoVideo fotovideo)
        {
            if (ModelState.IsValid)
            {
                db.FotoVideo.Add(fotovideo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", fotovideo.EventoId);
            return View(fotovideo);
        }

        // GET: /FotoVideo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FotoVideo fotovideo = db.FotoVideo.Find(id);
            if (fotovideo == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", fotovideo.EventoId);
            return View(fotovideo);
        }

        // POST: /FotoVideo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EventoId,Observacoes")] FotoVideo fotovideo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fotovideo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", fotovideo.EventoId);
            return View(fotovideo);
        }

        // GET: /FotoVideo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FotoVideo fotovideo = db.FotoVideo.Find(id);
            if (fotovideo == null)
            {
                return HttpNotFound();
            }
            return View(fotovideo);
        }

        // POST: /FotoVideo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FotoVideo fotovideo = db.FotoVideo.Find(id);
            db.FotoVideo.Remove(fotovideo);
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
