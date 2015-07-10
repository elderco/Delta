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
    public class ItemSomIluminacaoSelecionadoController : Controller
    {
        private Context db = new Context();

        // GET: /ItemSomIluminacaoSelecionado/
        public ActionResult Index()
        {
            var itemsomiluminacaoselecionado = db.ItemSomIluminacaoSelecionado.Include(i => i.ContratoAditivo).Include(i => i.Evento);
            return View(itemsomiluminacaoselecionado.ToList());
        }

        // GET: /ItemSomIluminacaoSelecionado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemSomIluminacaoSelecionado itemsomiluminacaoselecionado = db.ItemSomIluminacaoSelecionado.Find(id);
            if (itemsomiluminacaoselecionado == null)
            {
                return HttpNotFound();
            }
            return View(itemsomiluminacaoselecionado);
        }

        // GET: /ItemSomIluminacaoSelecionado/Create
        public ActionResult Create()
        {
            ViewBag.ContratoAditivoId = new SelectList(db.ContratoAditivo, "Id", "Arquivo");
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria");
            return View();
        }

        // POST: /ItemSomIluminacaoSelecionado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,EventoId,ContratoAditivoId,ItemSomIId,Definido,Contratado,ContratacaoBisutti,FornecimentoBisutti,Quantidade,HorarioMontagem,ContatoFornecimento,Observacoes")] ItemSomIluminacaoSelecionado itemsomiluminacaoselecionado)
        {
            if (ModelState.IsValid)
            {
                db.ItemSomIluminacaoSelecionado.Add(itemsomiluminacaoselecionado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContratoAditivoId = new SelectList(db.ContratoAditivo, "Id", "Arquivo", itemsomiluminacaoselecionado.ContratoAditivoId);
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", itemsomiluminacaoselecionado.EventoId);
            return View(itemsomiluminacaoselecionado);
        }

        // GET: /ItemSomIluminacaoSelecionado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemSomIluminacaoSelecionado itemsomiluminacaoselecionado = db.ItemSomIluminacaoSelecionado.Find(id);
            if (itemsomiluminacaoselecionado == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContratoAditivoId = new SelectList(db.ContratoAditivo, "Id", "Arquivo", itemsomiluminacaoselecionado.ContratoAditivoId);
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", itemsomiluminacaoselecionado.EventoId);
            return View(itemsomiluminacaoselecionado);
        }

        // POST: /ItemSomIluminacaoSelecionado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,EventoId,ContratoAditivoId,ItemSomIId,Definido,Contratado,ContratacaoBisutti,FornecimentoBisutti,Quantidade,HorarioMontagem,ContatoFornecimento,Observacoes")] ItemSomIluminacaoSelecionado itemsomiluminacaoselecionado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemsomiluminacaoselecionado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContratoAditivoId = new SelectList(db.ContratoAditivo, "Id", "Arquivo", itemsomiluminacaoselecionado.ContratoAditivoId);
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", itemsomiluminacaoselecionado.EventoId);
            return View(itemsomiluminacaoselecionado);
        }

        // GET: /ItemSomIluminacaoSelecionado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemSomIluminacaoSelecionado itemsomiluminacaoselecionado = db.ItemSomIluminacaoSelecionado.Find(id);
            if (itemsomiluminacaoselecionado == null)
            {
                return HttpNotFound();
            }
            return View(itemsomiluminacaoselecionado);
        }

        // POST: /ItemSomIluminacaoSelecionado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemSomIluminacaoSelecionado itemsomiluminacaoselecionado = db.ItemSomIluminacaoSelecionado.Find(id);
            db.ItemSomIluminacaoSelecionado.Remove(itemsomiluminacaoselecionado);
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
