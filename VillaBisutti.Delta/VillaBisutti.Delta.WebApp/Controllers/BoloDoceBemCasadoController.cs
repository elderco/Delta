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
    public class BoloDoceBemCasadoController : Controller
    {
		public ActionResult Index(int id)
		{
			ViewBag.Id = id;
			ViewBag.ContratoAditivoId = new SelectList(new data.ContratoAditivo().GetContratosEvento(id), "Id", "NumeroContrato");
			ViewBag.TipoItemBoloDoceBemCasadoId = new SelectList(new data.TipoItemBoloDoceBemCasado().GetCollection(0), "Id", "Nome");
			ViewBag.FornecedorId = new SelectList(new data.FornecedorBoloDoceBemCasado().GetCollection(0), "Id", "NomeFornecedor");
			return View(new data.BoloDoceBemCasado().GetElement(id));
		}

		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			model.BoloDoceBemCasado bolodocebemcasado = new data.BoloDoceBemCasado().GetElement(id.Value);
			if (bolodocebemcasado == null)
			{
				return HttpNotFound();
			}
			ViewBag.EventoId = id;
			return View(bolodocebemcasado);
		}

		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edited([Bind(Include = "EventoId,Id,Observacoes")] model.BoloDoceBemCasado bolodocebemcasado)
		{
			new data.BoloDoceBemCasado().Update(bolodocebemcasado);
			return Redirect(Request.UrlReferrer.AbsolutePath);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
			}
			base.Dispose(disposing);
		}
       
    }
}
