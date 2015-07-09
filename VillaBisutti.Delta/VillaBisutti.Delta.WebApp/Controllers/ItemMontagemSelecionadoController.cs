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
    public class ItemMontagemSelecionadoController : Controller
    {
        public ActionResult Details(int? id)
        {
            return View();
        }

        // GET: /ItemMontagemSelecionado/Create
        public ActionResult Create(int id)
        {
            ViewBag.Id = id;
            ViewBag.ContratoAditivoId = new SelectList(new data.ContratoAditivo().GetContratosEvento(0), "Id", "Arquivo");
            ViewBag.TipoItemMontagemId = new SelectList(new data.TipoItemBebida().GetCollection(0), "Id", "Nome");
            return View();
        }

        // POST: /ItemMontagemSelecionado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EventoId,Observacoes")] model.ItemMontagemSelecionado montagem)
        {
            return View(montagem);
        }

        // GET: /ItemMontagemSelecionado/Edit/5
        public ActionResult Edit(int? id)
        {
            return View();
        }

        // POST: /ItemMontagemSelecionado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventoId,Observacoes")] model.ItemMontagemSelecionado montagem)
        {
            return View(montagem);
        }

        // GET: /ItemMontagemSelecionado/Delete/5
        public ActionResult Delete(int? id)
        {
            return View();
        }

        // POST: /ItemMontagemSelecionado/Delete/5
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
            }
            base.Dispose(disposing);
        }
    }
}
