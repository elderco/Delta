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
using dto = VillaBisutti.Delta.Core.DTO;

namespace VillaBisutti.Delta.WebApp.Controllers
{
	public class TipoPratoPadraoController : Controller
	{

		// GET: /TipoPratoPadrao/
		public ActionResult Index()
		{
			return View(new dto.TipoPratoPadrao());
		}

		// POST: /TipoPratoPadrao/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edited([Bind(Include = "Id,QuantidadePratos")] model.TipoPratoPadrao tipopratopadrao)
		{
			model.TipoPratoPadrao original = new data.TipoPratoPadrao().GetElement(tipopratopadrao.Id);
			tipopratopadrao.CardapioId = original.CardapioId;
			tipopratopadrao.TipoPratoId = original.TipoPratoId;
			tipopratopadrao.TipoServico = original.TipoServico;
			new data.TipoPratoPadrao().Update(tipopratopadrao);
			return Redirect(Request.UrlReferrer.AbsolutePath);
		}
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}
	}
}
