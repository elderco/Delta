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
    public class ItemFotoVideoSelecionadoController : Controller
    {
		// GET: /ItemFotoVideoSelecionado/ListFornecimentoBisutti/5
		public ActionResult ListFornecimentoBisutti(int id)
		{
			ViewBag.Id = id;
			return View(new data.ItemFotoVideoSelecionado().GetItensCompartimentados(id, true, true));
		}

		// GET: /ItemFotoVideoSelecionado/ListFornecimentoTerceiro/5
		public ActionResult ListFornecimentoTerceiro(int id)
		{
			ViewBag.Id = id;
			return View(new data.ItemFotoVideoSelecionado().GetItensCompartimentados(id, true, false));
		}

		// GET: /ItemFotoVideoSelecionado/ListFornecimentoContratante/5
		public ActionResult ListFornecimentoContratante(int id)
		{
			ViewBag.Id = id;
			return View(new data.ItemFotoVideoSelecionado().GetItensCompartimentados(id, false, false));
		}

		public ActionResult EditFornecimentoBisutti(int id)
		{
			ViewBag.Id = id;
			return View(new data.ItemFotoVideoSelecionado().GetElement(id));
		}
		// GET: /ItemFotoVideoSelecionado/EditFornecimentoTerceiro/5
		public ActionResult EditFornecimentoTerceiro(int id)
		{
			ViewBag.Id = id;
			return View(new data.ItemFotoVideoSelecionado().GetElement(id));
		}

		// GET: /ItemFotoVideoSelecionado/EditFornecimentoContratante/5
		public ActionResult EditFornecimentoContratante(int id)
		{
			ViewBag.Id = id;
			return View(new data.ItemFotoVideoSelecionado().GetElement(id));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditPost([Bind(Include = "Id,Quantidade,ContatoFornecimento,HorarioEntrega,Definido,FornecedorStartado,Contratado,Observacoes,retorno")] model.ItemFotoVideoSelecionado itemfotovideoselecionado)
		{
			model.ItemFotoVideoSelecionado itemOriginal = new data.ItemFotoVideoSelecionado().GetElement(itemfotovideoselecionado.Id);
			itemOriginal.Quantidade = itemfotovideoselecionado.Quantidade;
			itemOriginal.ContatoFornecimento = itemfotovideoselecionado.ContatoFornecimento;
			itemOriginal.HorarioEntrega = itemfotovideoselecionado.HorarioEntrega;
			itemOriginal.Observacoes = itemfotovideoselecionado.Observacoes;
			itemOriginal.Definido = itemfotovideoselecionado.Definido;
			itemOriginal.Contratado = itemfotovideoselecionado.Contratado;
			itemOriginal.FornecedorStartado = itemfotovideoselecionado.FornecedorStartado;
			new data.ItemFotoVideoSelecionado().Update(itemOriginal);
			return new HttpStatusCodeResult(HttpStatusCode.OK);
		}

		// GET: /ItemFotoVideoSelecionado/Create
		public ActionResult Create(int id)
		{
			ViewBag.Id = id;
			ViewBag.ContratoAditivoId = new SelectList(new data.ContratoAditivo().GetContratosEvento(id), "Id", "NumeroContrato");
			ViewBag.TipoItemFotoVideoId = new SelectList(new data.TipoItemFotoVideo().GetCollection(0), "Id", "Nome");
			return View();
		}

		// POST: /ItemBebidaSelecionado/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CreateItemFotoVideoSelecionado([Bind(Include = "Id,EventoId,ItemBebidaId,ContratoAditivoId,ContratacaoBisutti,FornecimentoBisutti,Quantidade,Observacoes")] model.ItemFotoVideoSelecionado itemfotovideoselecionado)
		{
			new data.ItemFotoVideoSelecionado().Insert(itemfotovideoselecionado);
			return Redirect(Request.UrlReferrer.AbsolutePath);
		}

		// GET: /ItemFotoVideoSelecionado/Delete/5
		public ActionResult Delete(int? id)
		{
			new data.ItemFotoVideoSelecionado().Delete(id.Value);
			return Redirect(Request.UrlReferrer.AbsolutePath);
		}

		// POST: /ItemFotoVideoSelecionado/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			//ItemFotoVideoSelecionado itemfotovideoselecionado = db.ItemFotoVideoSelecionado.Find(id);
			//db.ItemFotoVideoSelecionado.Remove(itemfotovideoselecionado);
			//db.SaveChanges();
			//return RedirectToAction("Index");
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
