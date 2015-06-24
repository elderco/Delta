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
    public class ItemFotoVideoController : Controller
    {
        private Context db = new Context();

        // GET: /ItemFotoVideo/
        public ActionResult Index()
        {
            var itemfotovideo = db.ItemFotoVideo.Include(i => i.TipoItemFotoVideo);
            return View(itemfotovideo.ToList());
        }

        // GET: /ItemFotoVideo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemFotoVideo itemfotovideo = db.ItemFotoVideo.Find(id);
            if (itemfotovideo == null)
            {
                return HttpNotFound();
            }
            return View(itemfotovideo);
        }

        // GET: /ItemFotoVideo/Create
        public ActionResult Create()
        {
            ViewBag.TipoItemFotoVideoId = new SelectList(db.TipoItemFotoVideo, "Id", "Nome");
            return View();
        }

        // POST: /ItemFotoVideo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,Quantidade,TipoItemFotoVideoId")] ItemFotoVideo itemfotovideo)
        {
            if (ModelState.IsValid)
            {
                db.ItemFotoVideo.Add(itemfotovideo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoItemFotoVideoId = new SelectList(db.TipoItemFotoVideo, "Id", "Nome", itemfotovideo.TipoItemFotoVideoId);
            return View(itemfotovideo);
        }

        // GET: /ItemFotoVideo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemFotoVideo itemfotovideo = db.ItemFotoVideo.Find(id);
            if (itemfotovideo == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoItemFotoVideoId = new SelectList(db.TipoItemFotoVideo, "Id", "Nome", itemfotovideo.TipoItemFotoVideoId);
            return View(itemfotovideo);
        }

        // POST: /ItemFotoVideo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,Quantidade,TipoItemFotoVideoId")] ItemFotoVideo itemfotovideo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemfotovideo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoItemFotoVideoId = new SelectList(db.TipoItemFotoVideo, "Id", "Nome", itemfotovideo.TipoItemFotoVideoId);
            return View(itemfotovideo);
        }

        // GET: /ItemFotoVideo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemFotoVideo itemfotovideo = db.ItemFotoVideo.Find(id);
            if (itemfotovideo == null)
            {
                return HttpNotFound();
            }
            return View(itemfotovideo);
        }

        // POST: /ItemFotoVideo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemFotoVideo itemfotovideo = db.ItemFotoVideo.Find(id);
            db.ItemFotoVideo.Remove(itemfotovideo);
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
