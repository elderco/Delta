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
    public class PratoController : Controller
    {
        // GET: /Prato/
        public ActionResult Index()
        {
			return View(new data.Prato().GetCollection(0));
        }

        // GET: /Prato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.Prato prato = new data.Prato().GetElement(id.HasValue ? id.Value : 0);
            if (prato == null)
            {
                return HttpNotFound();
            }
            return View(prato);
        }

        // GET: /Prato/Create
        public ActionResult Create()
        {
			SelectList Prato = new SelectList(new data.Prato().GetCollection(0), "Id", "Nome");
			ViewBag.Prato = Prato;
            return View();
        }

        // POST: /Prato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult ItemCreated([Bind(Include = "Id,Nome,TipoPratoId")] model.Prato prato)
        {
            if (ModelState.IsValid)
            {
				new data.Prato().Insert(prato);
                return RedirectToAction("Index");
            }

            return View(prato);
        }

        // GET: /Prato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.Prato prato = new data.Prato().GetElement(id.HasValue ? id.Value : 0);
            if (prato == null)
            {
                return HttpNotFound();
            }
            return View(prato);
        }

        // POST: /Prato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,TipoPratoId")] model.Prato prato)
        {
            if (ModelState.IsValid)
            {
				new data.Prato().Update(prato);
                return RedirectToAction("Index");
            }
            return View(prato);
        }

        // GET: /Prato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.Prato prato = new data.Prato().GetElement(id.HasValue ? id.Value : 0);
            if (prato == null)
            {
                return HttpNotFound();
            }
            return View(prato);
        }

        // POST: /Prato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			new data.Prato().Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
			base.Dispose(disposing);
        }
    }
}
