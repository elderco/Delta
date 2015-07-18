using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VillaBisutti.Delta.Core.Model;
using VillaBisutti.Delta.Core.Data;

namespace VillaBisutti.Delta.WebApp.Controllers
{
    public class ItemDecoracaoControllerSelecionadoController : Controller
    {
        private Context db = new Context();

        // GET: /ItemDecoracaoControllerSelecionado/
        public ActionResult Index()
        {
            var itemdecoracaoselecionado = db.ItemDecoracaoSelecionado.Include(i => i.ContratoAditivo).Include(i => i.Evento).Include(i => i.ItemDecoracao);
            return View(itemdecoracaoselecionado.ToList());
        }

        // GET: /ItemDecoracaoControllerSelecionado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemDecoracaoSelecionado itemdecoracaoselecionado = db.ItemDecoracaoSelecionado.Find(id);
            if (itemdecoracaoselecionado == null)
            {
                return HttpNotFound();
            }
            return View(itemdecoracaoselecionado);
        }

        // GET: /ItemDecoracaoControllerSelecionado/Create
        public ActionResult Create()
        {
            ViewBag.ContratoAditivoId = new SelectList(db.ContratoAditivo, "Id", "Arquivo");
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria");
            ViewBag.ItemDecoracaoId = new SelectList(db.ItemDecoracao, "Id", "Nome");
            return View();
        }

        // POST: /ItemDecoracaoControllerSelecionado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,EventoId,ContratoAditivoId,ItemDecoracaoId,Definido,ContratacaoBisutti,FornecimentoBisutti,Contratado,FornecedorStartado,Quantidade,ContatoFornecimento,Observacoes,HorarioMontagem")] ItemDecoracaoSelecionado itemdecoracaoselecionado)
        {
            if (ModelState.IsValid)
            {
                db.ItemDecoracaoSelecionado.Add(itemdecoracaoselecionado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContratoAditivoId = new SelectList(db.ContratoAditivo, "Id", "Arquivo", itemdecoracaoselecionado.ContratoAditivoId);
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", itemdecoracaoselecionado.EventoId);
            ViewBag.ItemDecoracaoId = new SelectList(db.ItemDecoracao, "Id", "Nome", itemdecoracaoselecionado.ItemDecoracaoId);
            return View(itemdecoracaoselecionado);
        }

        // GET: /ItemDecoracaoControllerSelecionado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemDecoracaoSelecionado itemdecoracaoselecionado = db.ItemDecoracaoSelecionado.Find(id);
            if (itemdecoracaoselecionado == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContratoAditivoId = new SelectList(db.ContratoAditivo, "Id", "Arquivo", itemdecoracaoselecionado.ContratoAditivoId);
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", itemdecoracaoselecionado.EventoId);
            ViewBag.ItemDecoracaoId = new SelectList(db.ItemDecoracao, "Id", "Nome", itemdecoracaoselecionado.ItemDecoracaoId);
            return View(itemdecoracaoselecionado);
        }

        // POST: /ItemDecoracaoControllerSelecionado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,EventoId,ContratoAditivoId,ItemDecoracaoId,Definido,ContratacaoBisutti,FornecimentoBisutti,Contratado,FornecedorStartado,Quantidade,ContatoFornecimento,Observacoes,HorarioMontagem")] ItemDecoracaoSelecionado itemdecoracaoselecionado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemdecoracaoselecionado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContratoAditivoId = new SelectList(db.ContratoAditivo, "Id", "Arquivo", itemdecoracaoselecionado.ContratoAditivoId);
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", itemdecoracaoselecionado.EventoId);
            ViewBag.ItemDecoracaoId = new SelectList(db.ItemDecoracao, "Id", "Nome", itemdecoracaoselecionado.ItemDecoracaoId);
            return View(itemdecoracaoselecionado);
        }

        // GET: /ItemDecoracaoControllerSelecionado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemDecoracaoSelecionado itemdecoracaoselecionado = db.ItemDecoracaoSelecionado.Find(id);
            if (itemdecoracaoselecionado == null)
            {
                return HttpNotFound();
            }
            return View(itemdecoracaoselecionado);
        }

        // POST: /ItemDecoracaoControllerSelecionado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemDecoracaoSelecionado itemdecoracaoselecionado = db.ItemDecoracaoSelecionado.Find(id);
            db.ItemDecoracaoSelecionado.Remove(itemdecoracaoselecionado);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
