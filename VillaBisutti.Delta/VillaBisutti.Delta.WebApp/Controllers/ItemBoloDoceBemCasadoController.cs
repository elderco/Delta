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
    public class ItemBoloDoceBemCasadoController : Controller
    {
        // GET: /ItemBoloDoceBemCasado/
        public ActionResult Index()
        {
			return View(new data.ItemBoloDoceBemCasado().GetCollection(0));
        }

        // GET: /ItemBoloDoceBemCasado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model.ItemBoloDoceBemCasado itembolodocebemcasado = new data.ItemBoloDoceBemCasado().GetElement(id.HasValue ? id.Value : 0);
			if (itembolodocebemcasado == null)
            {
                return HttpNotFound();
            }
            return View(itembolodocebemcasado);
        }

        // GET: /ItemBoloDoceBemCasado/Create
        public ActionResult Create()
        {
			SelectList ItemBoloDoceBemCasado = new SelectList(new data.ItemBoloDoceBemCasado().GetCollection(0).OrderBy(tid => tid.Nome), "Id", "Nome");
			ViewBag.ItemBoloDoceBemCasado = ItemBoloDoceBemCasado;
			return View();
        }

        // POST: /ItemBoloDoceBemCasado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult ItemCreated([Bind(Include = "Id,Nome,Quantidade,FornecedorId")] model.ItemBoloDoceBemCasado itembolodocebemcasado)
        {
            if (ModelState.IsValid)
            {
                new data.ItemBoloDoceBemCasado().Insert(itembolodocebemcasado);
                return RedirectToAction("Index");
            }
			return View(itembolodocebemcasado);
        }

        // GET: /ItemBoloDoceBemCasado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.ItemBoloDoceBemCasado itembolodocebemcasado = new data.ItemBoloDoceBemCasado().GetElement(id.HasValue ? id.Value : 0);
			if (itembolodocebemcasado == null)
            {
                return HttpNotFound();
            }
			SelectList ItemBoloDoceBemCasado = new SelectList(new data.ItemBoloDoceBemCasado().GetCollection(0).OrderBy(tid => tid.Nome), "Id", "Nome");
			ViewBag.ItemBoloDoceBemCasado = ItemBoloDoceBemCasado; 
			return View(itembolodocebemcasado);
        }

        // POST: /ItemBoloDoceBemCasado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,Quantidade,FornecedorId")] model.ItemBoloDoceBemCasado itembolodocebemcasado)
        {
            if (ModelState.IsValid)
            {
				new data.ItemBoloDoceBemCasado().Update(itembolodocebemcasado);
                return RedirectToAction("Index");
            }
			return View(itembolodocebemcasado);
        }

        // GET: /ItemBoloDoceBemCasado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.ItemBoloDoceBemCasado itembolodocebemcasado = new data.ItemBoloDoceBemCasado().GetElement(id.HasValue ? id.Value : 0);
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
			new data.ItemBoloDoceBemCasado().Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
