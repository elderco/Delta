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
    [Authorize]
    public class ItemBoloDoceBemCasadoSelecionadoController : Controller
	{
		public ActionResult ListFornecimentoBisutti(int id)
		{
			ViewBag.Id = id;
			return View(new data.ItemBoloDoceBemCasadoSelecionado().GetItensCompartimentados(id, true, true));
		}

		public ActionResult ListFornecimentoTerceiro(int id)
		{
			ViewBag.Id = id;
			return View(new data.ItemBoloDoceBemCasadoSelecionado().GetItensCompartimentados(id, true, false));
		}

		public ActionResult ListFornecimentoContratante(int id)
		{
			ViewBag.Id = id;
			return View(new data.ItemBoloDoceBemCasadoSelecionado().GetItensCompartimentados(id, false, false));
		}

		public ActionResult EditFornecimentoBisutti(int id)
		{
			ViewBag.Id = id;
			return View(new data.ItemBoloDoceBemCasadoSelecionado().GetElement(id));
		}

		public ActionResult EditFornecimentoTerceiro(int id)
		{
			ViewBag.Id = id;
			return View(new data.ItemBoloDoceBemCasadoSelecionado().GetElement(id));
		}

		public ActionResult EditFornecimentoContratante(int id)
		{
			ViewBag.Id = id;
			return View(new data.ItemBoloDoceBemCasadoSelecionado().GetElement(id));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditPost([Bind(Include = "Id,Quantidade,ContatoFornecimento,HorarioEntrega,Definido,FornecedorStartado,Contratado,Observacoes,retorno")] model.ItemBoloDoceBemCasadoSelecionado itembolodocebemcasado)
		{
			model.ItemBoloDoceBemCasadoSelecionado itemOriginal = new data.ItemBoloDoceBemCasadoSelecionado().GetElement(itembolodocebemcasado.Id);
			itemOriginal.Quantidade = itembolodocebemcasado.Quantidade;
			itemOriginal.ContatoFornecimento = itembolodocebemcasado.ContatoFornecimento;
			itemOriginal.HorarioEntrega = itembolodocebemcasado.HorarioEntrega;
			itemOriginal.Observacoes = itembolodocebemcasado.Observacoes;
			itemOriginal.Definido = itembolodocebemcasado.Definido;
			itemOriginal.Contratado = itembolodocebemcasado.Contratado;
			itemOriginal.FornecedorStartado = itembolodocebemcasado.FornecedorStartado;
			new data.ItemBoloDoceBemCasadoSelecionado().Update(itemOriginal);
			return View(itemOriginal);
		}

		public ActionResult Create(int id)
		{
			ViewBag.Id = id;
			ViewBag.ContratoAditivoId = new SelectList(new data.ContratoAditivo().GetContratosEvento(id), "Id", "NumeroContrato");
			ViewBag.TipoItemBoloDoceBemCasadoId = new SelectList(new data.TipoItemBoloDoceBemCasado().GetCollection(0), "Id", "Nome");
			return View();
		}

		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CreateItemBoloDoceBemCasadoSelecionado([Bind(Include = "Id,EventoId,ItemBoloDoceBemCasadoId,ContratoAditivoId,ContratacaoBisutti,FornecimentoBisutti,Quantidade,Observacoes")] model.ItemBoloDoceBemCasadoSelecionado itembolodocebemcasado)
		{
			new data.ItemBoloDoceBemCasadoSelecionado().Insert(itembolodocebemcasado);
			return Redirect(Request.UrlReferrer.AbsolutePath);
		}

		public ActionResult Delete(int? id)
		{
			new data.ItemBoloDoceBemCasadoSelecionado().Delete(id.Value);
			return Redirect(Request.UrlReferrer.AbsolutePath);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			return View();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				//db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
