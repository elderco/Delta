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
	public class ItemFormaBoloDoceBemCasado : Controller
	{
		// GET: /Default1/
		public ActionResult Index()
		{
			return View(new data.ItemFormaBoloDoceBemCasado().GetCollection(0));
		}

		// GET: /Default1/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			model.ItemFormaBoloDoceBemCasado itemformabolodocebemcasado = new data.ItemFormaBoloDoceBemCasado().GetElement(id.HasValue ? id.Value : 0);
			if (itemformabolodocebemcasado == null)
			{
				return HttpNotFound();
			}
			return View(itemformabolodocebemcasado);
		}

		// GET: /Default1/Create
		public ActionResult Create()
		{
			SelectList ItemFormaBoloDoceBemCasado = new SelectList(new data.ItemFormaBoloDoceBemCasado().GetCollection(0).OrderBy(tid => tid.Nome), "Id", "Nome");
			ViewBag.ItemFormaBoloDoceBemCasado = ItemFormaBoloDoceBemCasado;
			return View();
		}

		// POST: /Default1/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult ItemCreated([Bind(Include = "Id,Nome,FornecedorId")] model.ItemFormaBoloDoceBemCasado itemformabolodocebemcasado)
		{
			if (ModelState.IsValid)
			{
				new data.ItemFormaBoloDoceBemCasado().Insert(itemformabolodocebemcasado);
				return RedirectToAction("Index");
			}
			return View(itemformabolodocebemcasado);
		}

		// GET: /Default1/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			model.ItemFormaBoloDoceBemCasado itemformabolodocebemcasado = new data.ItemFormaBoloDoceBemCasado().GetElement(id.HasValue ? id.Value : 0);
			if (itemformabolodocebemcasado == null)
			{
				return HttpNotFound();
			}
			SelectList ItemFormaBoloDoceBemCasado = new SelectList(new data.ItemFormaBoloDoceBemCasado().GetCollection(0).OrderBy(tid => tid.Nome), "Id", "Nome");
			ViewBag.ItemFormaBoloDoceBemCasado = ItemFormaBoloDoceBemCasado;
			return View(itemformabolodocebemcasado);
		}

		// POST: /Default1/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Nome,FornecedorId")] model.ItemFormaBoloDoceBemCasado itemformabolodocebemcasado)
		{
			if (ModelState.IsValid)
			{
				new data.ItemFormaBoloDoceBemCasado().Update(itemformabolodocebemcasado);
				return RedirectToAction("Index");
			}
			return View(itemformabolodocebemcasado);
		}

		// GET: /Default1/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			model.ItemFormaBoloDoceBemCasado itemformabolodocebemcasado = new data.ItemFormaBoloDoceBemCasado().GetElement(id.HasValue ? id.Value : 0);
			if (itemformabolodocebemcasado == null)
			{
				return HttpNotFound();
			}
			return View(itemformabolodocebemcasado);
		}

		// POST: /Default1/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			new data.ItemFormaBoloDoceBemCasado().Delete(id);
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}
	}
}
