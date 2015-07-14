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
    public class ItemSomIluminacaoSelecionadoController : Controller
    {
		// GET: /ItemSomIluminacaoSelecionado/ListFornecimentoBisutti/5
		public ActionResult ListFornecimentoBisutti(int id)
		{
			ViewBag.Id = id;
			return View(new data.ItemSomIluminacaoSelecionado().GetItensCompartimentados(id, true, true));
		}

		// GET: /ItemSomIluminacaoSelecionado/ListFornecimentoTerceiro/5
		public ActionResult ListFornecimentoTerceiro(int id)
		{
			ViewBag.Id = id;
			return View(new data.ItemSomIluminacaoSelecionado().GetItensCompartimentados(id, true, false));
		}

		// GET: /ItemSomIluminacaoSelecionado/ListFornecimentoContratante/5
		public ActionResult ListFornecimentoContratante(int id)
		{
			ViewBag.Id = id;
			return View(new data.ItemSomIluminacaoSelecionado().GetItensCompartimentados(id, false, false));
		}

		public ActionResult EditFornecimentoBisutti(int id)
		{
			ViewBag.Id = id;
			return View(new data.ItemSomIluminacaoSelecionado().GetElement(id));
		}

		// GET: /ItemSomIluminacaoSelecionado/ListFornecimentoTerceiro/5
		public ActionResult EditFornecimentoTerceiro(int id)
		{
			ViewBag.Id = id;
			return View(new data.ItemSomIluminacaoSelecionado().GetElement(id));
		}

		// GET: /ItemSomIluminacaoSelecionado/ListFornecimentoContratante/5
		public ActionResult EditFornecimentoContratante(int id)
		{
			ViewBag.Id = id;
			return View(new data.ItemSomIluminacaoSelecionado().GetElement(id));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditPost([Bind(Include = "Id,Quantidade,ContatoFornecimento,HorarioMontagem,Definido,FornecedorStartado,Contratado,Observacoes")] model.ItemSomIluminacaoSelecionado itemsomiluminacaoselecionado)
		{
			model.ItemSomIluminacaoSelecionado itemOriginal = new data.ItemSomIluminacaoSelecionado().GetElement(itemsomiluminacaoselecionado.Id);
			itemOriginal.Quantidade = itemsomiluminacaoselecionado.Quantidade;
			itemOriginal.ContatoFornecimento = itemsomiluminacaoselecionado.ContatoFornecimento;
			itemOriginal.HorarioMontagem = itemsomiluminacaoselecionado.HorarioMontagem;
			itemOriginal.Observacoes = itemsomiluminacaoselecionado.Observacoes;
			itemOriginal.Definido = itemsomiluminacaoselecionado.Definido;
			itemOriginal.Contratado = itemsomiluminacaoselecionado.Contratado;
			itemOriginal.FornecedorStartado = itemsomiluminacaoselecionado.FornecedorStartado;
			new data.ItemSomIluminacaoSelecionado().Update(itemOriginal);
			return Redirect(Request.UrlReferrer.AbsolutePath);
		}

		// GET: /ItemBebidaSelecionado/Create
		public ActionResult Create(int id)
		{
			ViewBag.Id = id;
			ViewBag.ContratoAditivoId = new SelectList(new data.ContratoAditivo().GetContratosEvento(id), "Id", "NumeroContrato");
			ViewBag.TipoSomIluminacaoId = new SelectList(new data.TipoItemSomIluminacao().GetCollection(0), "Id", "Nome");
			return View();
		}

		// POST: /ItemBebidaSelecionado/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CreateItemBebidaSelecionado([Bind(Include = "Id,EventoId,ItemSomIluminacaoId,ContratoAditivoId,ContratacaoBisutti,FornecimentoBisutti,Quantidade,Observacoes")] model.ItemSomIluminacaoSelecionado itemsomiluminacaoselecionado)
		{
			new data.ItemSomIluminacaoSelecionado().Insert(itemsomiluminacaoselecionado);
			return Redirect(Request.UrlReferrer.AbsolutePath);
		}

		// GET: /ItemBebidaSelecionado/Delete/5
		public ActionResult Delete(int? id)
		{
			new data.ItemSomIluminacaoSelecionado().Delete(id.Value);
			return Redirect(Request.UrlReferrer.AbsolutePath);
		}

		// POST: /ItemBebidaSelecionado/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			//ItemBebidaSelecionado itembebidaselecionado = db.ItemBebidaSelecionado.Find(id);
			//db.ItemBebidaSelecionado.Remove(itembebidaselecionado);
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