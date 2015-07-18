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
    public class ItemDecoracaoCerimonialSelecionadoController : Controller
    {
        private Context db = new Context();

        // GET: /ItemDecoracaoCerimonialSelecionado/
        public ActionResult Index()
        {
            var itemdecoracaocerimonialselecionado = db.ItemDecoracaoCerimonialSelecionado.Include(i => i.ContratoAditivo).Include(i => i.Evento).Include(i => i.ItemDecoracaoCerimonial);
            return View(itemdecoracaocerimonialselecionado.ToList());
        }

        // GET: /ItemDecoracaoCerimonialSelecionado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemDecoracaoCerimonialSelecionado itemdecoracaocerimonialselecionado = db.ItemDecoracaoCerimonialSelecionado.Find(id);
            if (itemdecoracaocerimonialselecionado == null)
            {
                return HttpNotFound();
            }
            return View(itemdecoracaocerimonialselecionado);
        }

        // GET: /ItemDecoracaoCerimonialSelecionado/Create
        public ActionResult Create()
        {
            ViewBag.ContratoAditivoId = new SelectList(db.ContratoAditivo, "Id", "Arquivo");
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria");
            ViewBag.ItemDecoracaoCerimonialId = new SelectList(db.ItemDecoracaoCerimonial, "Id", "Nome");
            return View();
        }

        // POST: /ItemDecoracaoCerimonialSelecionado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,EventoId,ContratoAditivoId,ItemDecoracaoCerimonialId,Definido,ContratacaoBisutti,FornecimentoBisutti,Contratado,FornecedorStartado,Quantidade,ContatoFornecimento,Observacoes,HorarioMontagem")] ItemDecoracaoCerimonialSelecionado itemdecoracaocerimonialselecionado)
        {
            if (ModelState.IsValid)
            {
                db.ItemDecoracaoCerimonialSelecionado.Add(itemdecoracaocerimonialselecionado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContratoAditivoId = new SelectList(db.ContratoAditivo, "Id", "Arquivo", itemdecoracaocerimonialselecionado.ContratoAditivoId);
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", itemdecoracaocerimonialselecionado.EventoId);
            ViewBag.ItemDecoracaoCerimonialId = new SelectList(db.ItemDecoracaoCerimonial, "Id", "Nome", itemdecoracaocerimonialselecionado.ItemDecoracaoCerimonialId);
            return View(itemdecoracaocerimonialselecionado);
        }

        // GET: /ItemDecoracaoCerimonialSelecionado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemDecoracaoCerimonialSelecionado itemdecoracaocerimonialselecionado = db.ItemDecoracaoCerimonialSelecionado.Find(id);
            if (itemdecoracaocerimonialselecionado == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContratoAditivoId = new SelectList(db.ContratoAditivo, "Id", "Arquivo", itemdecoracaocerimonialselecionado.ContratoAditivoId);
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", itemdecoracaocerimonialselecionado.EventoId);
            ViewBag.ItemDecoracaoCerimonialId = new SelectList(db.ItemDecoracaoCerimonial, "Id", "Nome", itemdecoracaocerimonialselecionado.ItemDecoracaoCerimonialId);
            return View(itemdecoracaocerimonialselecionado);
        }

        // POST: /ItemDecoracaoCerimonialSelecionado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,EventoId,ContratoAditivoId,ItemDecoracaoCerimonialId,Definido,ContratacaoBisutti,FornecimentoBisutti,Contratado,FornecedorStartado,Quantidade,ContatoFornecimento,Observacoes,HorarioMontagem")] ItemDecoracaoCerimonialSelecionado itemdecoracaocerimonialselecionado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemdecoracaocerimonialselecionado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContratoAditivoId = new SelectList(db.ContratoAditivo, "Id", "Arquivo", itemdecoracaocerimonialselecionado.ContratoAditivoId);
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", itemdecoracaocerimonialselecionado.EventoId);
            ViewBag.ItemDecoracaoCerimonialId = new SelectList(db.ItemDecoracaoCerimonial, "Id", "Nome", itemdecoracaocerimonialselecionado.ItemDecoracaoCerimonialId);
            return View(itemdecoracaocerimonialselecionado);
        }

        // GET: /ItemDecoracaoCerimonialSelecionado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemDecoracaoCerimonialSelecionado itemdecoracaocerimonialselecionado = db.ItemDecoracaoCerimonialSelecionado.Find(id);
            if (itemdecoracaocerimonialselecionado == null)
            {
                return HttpNotFound();
            }
            return View(itemdecoracaocerimonialselecionado);
        }

        // POST: /ItemDecoracaoCerimonialSelecionado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemDecoracaoCerimonialSelecionado itemdecoracaocerimonialselecionado = db.ItemDecoracaoCerimonialSelecionado.Find(id);
            db.ItemDecoracaoCerimonialSelecionado.Remove(itemdecoracaocerimonialselecionado);
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
