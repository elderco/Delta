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
			return View(new data.ItemBebidaSelecionado().GetItensCompartimentados(id, true, true));
		}

		// GET: /ItemBebidaSelecionado/ListFornecimentoTerceiro/5
		public ActionResult EditFornecimentoTerceiro(int id)
		{
			ViewBag.Id = id;
			return View(new data.ItemBebidaSelecionado().GetItensCompartimentados(id, true, false));
		}

		// GET: /ItemBebidaSelecionado/ListFornecimentoContratante/5
		public ActionResult EditFornecimentoContratante(int id)
		{
			ViewBag.Id = id;
			return View(new data.ItemBebidaSelecionado().GetItensCompartimentados(id, false, false));
		}

		// GET: /ItemBebidaSelecionado/Details/5
		public ActionResult Details(int? id)
		{
			//if (id == null)
			//{
			//	return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			//}
			//ItemBebidaSelecionado itembebidaselecionado = db.ItemBebidaSelecionado.Find(id);
			//if (itembebidaselecionado == null)
			//{
			//	return HttpNotFound();
			//}
			//return View(itembebidaselecionado);
			return View();
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
		public ActionResult Create([Bind(Include = "Id,EventoId,ContratoAditivoId,ItemBebidaId,Definido,Contratado,ContratacaoBisutti,FornecimentoBisutti,FornecedorStartado,Quantidade,HorarioEntrega,ContatoFornecimento,Observacoes")] model.ItemBebidaSelecionado itembebidaselecionado)
		{
			//if (ModelState.IsValid)
			//{
			//	db.ItemBebidaSelecionado.Add(itembebidaselecionado);
			//	db.SaveChanges();
			//	return RedirectToAction("Index");
			//}

			//ViewBag.ContratoAditivoId = new SelectList(db.ContratoAdivitivo, "Id", "Arquivo", itembebidaselecionado.ContratoAditivoId);
			//ViewBag.EventoId = new SelectList(db.Evento, "Id", "NomeResponsavel", itembebidaselecionado.EventoId);
			//ViewBag.ItemBebidaId = new SelectList(db.ItemBebida, "Id", "Nome", itembebidaselecionado.ItemBebidaId);
			//return View(itembebidaselecionado);
			return View();
		}

		// GET: /ItemBebidaSelecionado/Edit/5
		public ActionResult Edit(int? id)
		{
			//if (id == null)
			//{
			//	return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			//}
			//ItemBebidaSelecionado itembebidaselecionado = db.ItemBebidaSelecionado.Find(id);
			//if (itembebidaselecionado == null)
			//{
			//	return HttpNotFound();
			//}
			//ViewBag.ContratoAditivoId = new SelectList(db.ContratoAdivitivo, "Id", "Arquivo", itembebidaselecionado.ContratoAditivoId);
			//ViewBag.EventoId = new SelectList(db.Evento, "Id", "NomeResponsavel", itembebidaselecionado.EventoId);
			//ViewBag.ItemBebidaId = new SelectList(db.ItemBebida, "Id", "Nome", itembebidaselecionado.ItemBebidaId);
			//return View(itembebidaselecionado);
			return View();
		}

		// POST: /ItemBebidaSelecionado/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,EventoId,ContratoAditivoId,ItemBebidaId,Definido,Contratado,ContratacaoBisutti,FornecimentoBisutti,FornecedorStartado,Quantidade,HorarioEntrega,ContatoFornecimento,Observacoes")] model.ItemBebidaSelecionado itembebidaselecionado)
		{
			//if (ModelState.IsValid)
			//{
			//	db.Entry(itembebidaselecionado).State = EntityState.Modified;
			//	db.SaveChanges();
			//	return RedirectToAction("Index");
			//}
			//ViewBag.ContratoAditivoId = new SelectList(db.ContratoAdivitivo, "Id", "Arquivo", itembebidaselecionado.ContratoAditivoId);
			//ViewBag.EventoId = new SelectList(db.Evento, "Id", "NomeResponsavel", itembebidaselecionado.EventoId);
			//ViewBag.ItemBebidaId = new SelectList(db.ItemBebida, "Id", "Nome", itembebidaselecionado.ItemBebidaId);
			//return View(itembebidaselecionado);
			return View();
		}

		// GET: /ItemBebidaSelecionado/Delete/5
		public ActionResult Delete(int? id)
		{
			//if (id == null)
			//{
			//	return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			//}
			//ItemBebidaSelecionado itembebidaselecionado = db.ItemBebidaSelecionado.Find(id);
			//if (itembebidaselecionado == null)
			//{
			//	return HttpNotFound();
			//}
			//return View(itembebidaselecionado);
			return View();
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
