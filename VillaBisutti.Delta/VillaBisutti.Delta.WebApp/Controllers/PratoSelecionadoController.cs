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
using biz = VillaBisutti.Delta.Core.Business;
using dto = VillaBisutti.Delta.Core.DTO;

namespace VillaBisutti.Delta.WebApp.Controllers
{
    public class PratoSelecionadoController : Controller
    {

        // GET: /PratoSelecionado/
        public ActionResult Index()
        {
			ViewBag.CardapioId = new SelectList(new data.Cardapio().GetCollection(0), "Id", "Nome");
			ViewBag.TipoServicoId = new SelectList(new data.TipoServico().GetCollection(0), "Id", "Nome");
            return View();
        }

		// GET: /PratoSelecionado/Configuracao/?cardapioId=5&tipoServicoId=5
		public ActionResult Configuracao(int cardapioId, int tipoServicoId)
		{
			return View(new dto.PratoSelecionado(cardapioId, tipoServicoId));
		}

		public ActionResult Copiar(int cardapioId, int tipoServicoId)
		{
			new biz.PratoSelecionado().ImportarPratosDosCardapios(cardapioId, tipoServicoId);
			return RedirectToAction("Configuracao", "PratoSelecionado", new { cardapioId = cardapioId, tipoServicoId = tipoServicoId });
		}
        // GET: /PratoSelecionado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model.PratoSelecionado pratoselecionado = new data.PratoSelecionado().GetElement(id.Value);
            if (pratoselecionado == null)
            {
                return HttpNotFound();
            }
            return View(pratoselecionado);
        }

        // POST: /PratoSelecionado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edited([Bind(Include="Id,Degustar")] model.PratoSelecionado pratoselecionado)
        {
			model.PratoSelecionado original = new data.PratoSelecionado().GetElement(pratoselecionado.Id);
			pratoselecionado.TipoServicoId = original.TipoServicoId;
			pratoselecionado.CardapioId = original.CardapioId;
			new data.PratoSelecionado().Update(pratoselecionado);
            return Redirect(Request.UrlReferrer.AbsolutePath);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
