using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VillaBisutti.Delta.Core.Data;
using VillaBisutti.Delta.Core.Model;
using model = VillaBisutti.Delta.Core.Model;
using data = VillaBisutti.Delta.Core.Data;

namespace VillaBisutti.Delta.WebApp.Controllers
{
    public class ItemOutrosItensSelecionadoController : Controller
    {
        public ActionResult Create(int id)
        {
            ViewBag.Id = id;
            ViewBag.ContratoAditivoId = new SelectList(new data.ContratoAditivo().GetContratosEvento(id), "Id", "NumeroContrato");
            ViewBag.TipoItemOutrosItensId = new SelectList(new data.TipoItemOutrosItens().GetCollection(0), "Id", "Nome");
            return View(new data.OutrosItens().GetElement(id));
        }

        // GET: ItemOutrosItensSelecionado
        public ActionResult ListFornecimentoBisutti(int id)
        {
            ViewBag.Id = id;
            return View(new data.ItemOutrosItensSelecionado().GetItensCompartimentados(id, true, true));
        }

        public ActionResult ListFornecimentoTerceiro(int id)
        {
            ViewBag.Id = id;
            return View(new data.ItemOutrosItensSelecionado().GetItensCompartimentados(id, true, false));
        }
        public ActionResult ListFornecimentoContratante(int id)
        {
            ViewBag.Id = id;
            return View(new data.ItemOutrosItensSelecionado().GetItensCompartimentados(id, false, false));
        }

        public ActionResult EditFornecimentoBisutti(int id)
        {
            ViewBag.Id = id;
            return View(new data.ItemOutrosItensSelecionado().GetElement(id));
        }

        public ActionResult EditFornecimentoTerceiro(int id)
        {
            ViewBag.Id = id;
            return View(new data.ItemOutrosItensSelecionado().GetElement(id));
        }

        public ActionResult EditFornecimentoContratante(int id)
        {
            ViewBag.Id = id;
            return View(new data.ItemOutrosItensSelecionado().GetElement(id));
        }

        public ActionResult EditPost([Bind(Include = "Id,Quantidade,ContatoFornecimento,HorarioEntrega,Definido,FornecedorStartado,Contratado,Observacoes,retorno")] model.ItemOutrosItensSelecionado itemOutrosItensselecionado)
        {
            model.ItemOutrosItensSelecionado itemOriginal = new data.ItemOutrosItensSelecionado().GetElement(itemOutrosItensselecionado.Id);
            itemOriginal.Quantidade = itemOutrosItensselecionado.Quantidade;
            itemOriginal.ContatoFornecimento = itemOutrosItensselecionado.ContatoFornecimento;
            itemOriginal.HorarioEntrega = itemOutrosItensselecionado.HorarioEntrega;
            itemOriginal.Observacoes = itemOutrosItensselecionado.Observacoes;
            itemOriginal.Definido = itemOutrosItensselecionado.Definido;
            itemOriginal.Contratado = itemOutrosItensselecionado.Contratado;
            itemOriginal.FornecedorStartado = itemOutrosItensselecionado.FornecedorStartado;
            new data.ItemOutrosItensSelecionado().Update(itemOriginal);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult CreateItemOutrosItensSelecionado([Bind(Include= "Id,EventoId,ItemOutrosItensId,ContratoAditivoId,ContratacaoBisutti,FornecimentoBisutti,Quantidade,Observacoes")] model.ItemOutrosItensSelecionado itemOutrosItensSelecionados)
        {
            new data.ItemOutrosItensSelecionado().Insert(itemOutrosItensSelecionados);
            return Redirect(Request.UrlReferrer.AbsolutePath);
        }

        public ActionResult Delete(int? id)
        {
            new data.ItemOutrosItensSelecionado().Delete(id.Value);
            return Redirect(Request.UrlReferrer.AbsolutePath);
        }

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
