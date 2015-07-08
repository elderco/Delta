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
    public class FotoController : Controller
    {
        // GET: /Foto/
        public ActionResult Index()
        {
			return View(new data.Foto().GetCollection(0));
        }

        // GET: /Foto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.Foto foto = new data.Foto().GetElement(id.HasValue ? id.Value : 0);
            if (foto == null)
            {
                return HttpNotFound();
            }
            return View(foto);
        }

        // GET: /Foto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Foto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,URL,Legenda")] model.Foto foto)
        {
            if (ModelState.IsValid)
            {
				new data.Foto().Insert(foto);
                return RedirectToAction("Index");
            }

            return View(foto);
        }

        // GET: /Foto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model.Foto foto = new data.Foto().GetElement(id.HasValue ? id.Value : 0);
			if (foto == null)
            {
                return HttpNotFound();
            }
            return View(foto);
        }

        // POST: /Foto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,URL,Legenda")] model.Foto foto)
        {
            if (ModelState.IsValid)
            {
				new data.Foto().Update(foto);
                return RedirectToAction("Index");
            }
            return View(foto);
        }

        // GET: /Foto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.Foto foto = new data.Foto().GetElement(id.HasValue ? id.Value : 0);
			if (foto == null)
            {
                return HttpNotFound();
            }
            return View(foto);
        }

        // POST: /Foto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			new data.Foto().Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
