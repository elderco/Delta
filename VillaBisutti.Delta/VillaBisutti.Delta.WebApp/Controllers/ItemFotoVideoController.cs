using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using model = VillaBisutti.Delta.Core.Model;
using data = VillaBisutti.Delta.Core.Data;

namespace VillaBisutti.Delta.WebApp.Controllers
{
    public class ItemFotoVideoController : Controller
    { 
        // GET: /ItemFotoVideo/
        public ActionResult Index()
        {
			return View(new data.ItemFotoVideo().GetCollection(0));
        }

        // GET: /ItemFotoVideo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.ItemFotoVideo itemfotovideo = new data.ItemFotoVideo().GetElement(id.HasValue ? id.Value : 0);
			if (itemfotovideo == null)
            {
                return HttpNotFound();
            }
            return View(itemfotovideo);
        }

        // GET: /ItemFotoVideo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ItemFotoVideo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,Quantidade,TipoItemFotoVideoId")] model.ItemFotoVideo itemfotovideo)
        {
            if (ModelState.IsValid)
            {
				new data.ItemFotoVideo().Insert(itemfotovideo);
				return RedirectToAction("Index");
            }
            return View(itemfotovideo);
        }

        // GET: /ItemFotoVideo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.ItemFotoVideo itemfotovideo = new data.ItemFotoVideo().GetElement(id.HasValue ? id.Value : 0);
			if (itemfotovideo == null)
            {
                return HttpNotFound();
            }
            return View(itemfotovideo);
        }

        // POST: /ItemFotoVideo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,Quantidade,TipoItemFotoVideoId")] model.ItemFotoVideo itemfotovideo)
        {
            if (ModelState.IsValid)
            {
				new data.ItemFotoVideo().Update(itemfotovideo);
                return RedirectToAction("Index");
            }
            return View(itemfotovideo);
        }

        // GET: /ItemFotoVideo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model.ItemFotoVideo itemfotovideo = new  data.ItemFotoVideo().GetElement(id.HasValue ? id.Value);
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
			new data.ItemFotoVideo().Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
