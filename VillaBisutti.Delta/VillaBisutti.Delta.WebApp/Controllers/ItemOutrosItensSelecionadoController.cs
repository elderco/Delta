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
        public ActionResult Index(int id)
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
    }
}
