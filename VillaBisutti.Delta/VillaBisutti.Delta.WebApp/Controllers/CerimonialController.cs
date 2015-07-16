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
    public class CerimonialController : Controller
    {
        // GET: /Cerimonial/
		public ActionResult Index(int EventoId)
		{
			ViewBag.EventoId = EventoId;
			return View(new data.ItemCerimonial().GetFromTipoEvento(EventoId));
		}

		// GET: /Cerimonial/Create
		public ActionResult Create(int EventoId)
		{
			ViewBag.EventoId = EventoId;
			return View();
		}

		// POST: /Cerimonial/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult ItemCreated([Bind(Include = "Id,Titulo,HorarioInicio,Importante,Observacao,EventoId,CerimoniaId")] model.ItemCerimonial itemcerimonial)
		{
			new data.ItemCerimonial().Insert(itemcerimonial);
			return RedirectToAction("Index", new { TipoEvento = (int)itemcerimonial.EventoId });

		}

		// GET: /Cerimonial/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			model.ItemCerimonial itemcerimonial = new data.ItemCerimonial().GetElement(id.HasValue ? id.Value : 0);
			if (itemcerimonial == null)
			{
				return HttpNotFound();
			}
			return View(itemcerimonial);
		}

		// POST: /Cerimonial/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Titulo,HorarioInicio,Importante,Observacao,EventoId,EventoId")] model.ItemCerimonial itemcerimonial)
		{
			if (ModelState.IsValid)
			{
				new data.ItemCerimonial().Update(itemcerimonial);
				return RedirectToAction("Index");
			}
			return View(itemcerimonial);
		}

		// GET: /Cerimonial/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			model.ItemCerimonial itemcerimonial = new data.ItemCerimonial().GetElement(id.HasValue ? id.Value : 0);
			if (itemcerimonial == null)
			{
				return HttpNotFound();
			}
			return View(itemcerimonial);
		}

		// POST: /Cerimonial/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			int EventoId = (int)(new data.ItemCerimonial().GetElement(id).EventoId);
			new data.ItemCerimonial().Delete(id);
			return RedirectToAction("Index", new { EventoId = EventoId });
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}
	}
}
