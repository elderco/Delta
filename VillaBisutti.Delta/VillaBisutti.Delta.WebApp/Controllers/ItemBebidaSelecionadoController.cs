﻿using System;
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
	public class ItemBebidaSelecionadoController : Controller
	{
		// GET: /ItemBebidaSelecionado/ListFornecimentoBisutti/5
		public ActionResult ListFornecimentoBisutti(int id)
		{
			ViewBag.Id = id;
			return View(new data.ItemBebidaSelecionado().GetItensCompartimentados(id, true, true));
		}

		// GET: /ItemBebidaSelecionado/ListFornecimentoTerceiro/5
		public ActionResult ListFornecimentoTerceiro(int id)
		{
			ViewBag.Id = id;
			return View(new data.ItemBebidaSelecionado().GetItensCompartimentados(id, true, false));
		}

		// GET: /ItemBebidaSelecionado/ListFornecimentoContratante/5
		public ActionResult ListFornecimentoContratante(int id)
		{
			ViewBag.Id = id;
			return View(new data.ItemBebidaSelecionado().GetItensCompartimentados(id, false, false));
		}

		public ActionResult EditFornecimentoBisutti(int id)
		{
			ViewBag.Id = id;
			return View(new data.ItemBebidaSelecionado().GetElement(id));
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditFornecimentoBisuttiPost([Bind(Include = "Id,Quantidade,Observacoes,Definido")] model.ItemBebidaSelecionado itembebidaselecionado)
		{
			model.ItemBebidaSelecionado itemOriginal = new data.ItemBebidaSelecionado().GetElement(itembebidaselecionado.Id);
			itemOriginal.Quantidade = itembebidaselecionado.Quantidade;
			itemOriginal.Observacoes = itembebidaselecionado.Observacoes;
			itemOriginal.Definido = itembebidaselecionado.Definido;
			new data.ItemBebidaSelecionado().Update(itemOriginal);
			return Redirect(Request.UrlReferrer.AbsolutePath);
		}

		// GET: /ItemBebidaSelecionado/ListFornecimentoTerceiro/5
		public ActionResult EditFornecimentoTerceiro(int id)
		{
			ViewBag.Id = id;
			return View(new data.ItemBebidaSelecionado().GetElement(id));
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditFornecimentoTerceiroPost([Bind(Include = "Id,Quantidade,ContatoFornecimento,HorarioEntrega,Contratado,FornecedorStartado,Observacoes,Definido")] model.ItemBebidaSelecionado itembebidaselecionado)
		{
			model.ItemBebidaSelecionado itemOriginal = new data.ItemBebidaSelecionado().GetElement(itembebidaselecionado.Id);
			itemOriginal.Quantidade = itembebidaselecionado.Quantidade;
			itemOriginal.ContatoFornecimento = itembebidaselecionado.ContatoFornecimento;
			itemOriginal.HorarioEntrega = itembebidaselecionado.HorarioEntrega;
			itemOriginal.Observacoes = itembebidaselecionado.Observacoes;
			itemOriginal.Definido = itembebidaselecionado.Definido;
			itemOriginal.Contratado = itembebidaselecionado.Contratado;
			itemOriginal.FornecedorStartado = itembebidaselecionado.FornecedorStartado;
			new data.ItemBebidaSelecionado().Update(itemOriginal);
			return Redirect(Request.UrlReferrer.AbsolutePath);
		}

		// GET: /ItemBebidaSelecionado/ListFornecimentoContratante/5
		public ActionResult EditFornecimentoContratante(int id)
		{
			ViewBag.Id = id;
			return View(new data.ItemBebidaSelecionado().GetElement(id));
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditFornecimentoContratantePost([Bind(Include = "Id,Quantidade,ContatoFornecimento,HorarioEntrega,Observacoes")] model.ItemBebidaSelecionado itembebidaselecionado)
		{
			model.ItemBebidaSelecionado itemOriginal = new data.ItemBebidaSelecionado().GetElement(itembebidaselecionado.Id);
			itemOriginal.Quantidade = itembebidaselecionado.Quantidade;
			itemOriginal.ContatoFornecimento = itembebidaselecionado.ContatoFornecimento;
			itemOriginal.HorarioEntrega = itembebidaselecionado.HorarioEntrega;
			itemOriginal.Observacoes = itembebidaselecionado.Observacoes;
			new data.ItemBebidaSelecionado().Update(itemOriginal);
			return Redirect(Request.UrlReferrer.AbsolutePath);
		}

		// GET: /ItemBebidaSelecionado/Create
		public ActionResult Create(int id)
		{
			ViewBag.Id = id;
			ViewBag.ContratoAditivoId = new SelectList(new data.ContratoAditivo().GetContratosEvento(id), "Id", "Arquivo");
			ViewBag.TipoItemBebidaId = new SelectList(new data.TipoItemBebida().GetCollection(0), "Id", "Nome");
			return View();
		}

		// POST: /ItemBebidaSelecionado/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CreateItemBebidaSelecionado([Bind(Include = "Id,EventoId,ItemBebidaId,ContratoAditivoId,ContratacaoBisutti,FornecimentoBisutti,Quantidade,Observacoes")] model.ItemBebidaSelecionado itembebidaselecionado)
		{
			//itembebidaselecionado.Definido = false;
			//itembebidaselecionado.FornecedorStartado = false;
			//itembebidaselecionado.Contratado = false;
			//itembebidaselecionado.ContatoFornecimento = string.Empty;
			//itembebidaselecionado.Entrega = new model.Horario();
			//itembebidaselecionado.HorarioEntrega = 0;
			new data.ItemBebidaSelecionado().Insert(itembebidaselecionado);
			return Redirect(Request.UrlReferrer.AbsolutePath);
		}

		// GET: /ItemBebidaSelecionado/Delete/5
		public ActionResult Delete(int? id)
		{
			new data.ItemBebidaSelecionado().Delete(id.Value);
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
