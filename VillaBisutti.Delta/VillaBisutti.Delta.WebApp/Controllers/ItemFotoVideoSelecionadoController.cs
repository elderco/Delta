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
    public class ItemFotoVideoSelecionadoController : Controller
    {
        private Context db = new Context();

        // GET: /ItemFotoVideoSelecionado/
        public ActionResult Index()
        {
            var itemfotovideoselecionado = db.ItemFotoVideoSelecionado.Include(i => i.ContratoAditivo).Include(i => i.Evento).Include(i => i.ItemBebida);
            return View(itemfotovideoselecionado.ToList());
        }

        // GET: /ItemFotoVideoSelecionado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemFotoVideoSelecionado itemfotovideoselecionado = db.ItemFotoVideoSelecionado.Find(id);
            if (itemfotovideoselecionado == null)
            {
                return HttpNotFound();
            }
            return View(itemfotovideoselecionado);
        }

        // GET: /ItemFotoVideoSelecionado/Create
        public ActionResult Create()
        {
            ViewBag.ContratoAditivoId = new SelectList(db.ContratoAditivo, "Id", "Arquivo");
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria");
            ViewBag.ItemBebidaId = new SelectList(db.ItemBebida, "Id", "Nome");
            return View();
        }

        // POST: /ItemFotoVideoSelecionado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,EventoId,ContratoAditivoId,ItemBebidaId,Definido,Contratado,ContratacaoBisutti,FornecimentoBisutti,FornecedorStartado,Quantidade,ContatoFornecimento,Observacoes,HorarioEntrega")] ItemFotoVideoSelecionado itemfotovideoselecionado)
        {
            if (ModelState.IsValid)
            {
                db.ItemFotoVideoSelecionado.Add(itemfotovideoselecionado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContratoAditivoId = new SelectList(db.ContratoAditivo, "Id", "Arquivo", itemfotovideoselecionado.ContratoAditivoId);
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", itemfotovideoselecionado.EventoId);
            ViewBag.ItemBebidaId = new SelectList(db.ItemBebida, "Id", "Nome", itemfotovideoselecionado.ItemBebidaId);
            return View(itemfotovideoselecionado);
        }

        // GET: /ItemFotoVideoSelecionado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemFotoVideoSelecionado itemfotovideoselecionado = db.ItemFotoVideoSelecionado.Find(id);
            if (itemfotovideoselecionado == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContratoAditivoId = new SelectList(db.ContratoAditivo, "Id", "Arquivo", itemfotovideoselecionado.ContratoAditivoId);
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", itemfotovideoselecionado.EventoId);
            ViewBag.ItemBebidaId = new SelectList(db.ItemBebida, "Id", "Nome", itemfotovideoselecionado.ItemBebidaId);
            return View(itemfotovideoselecionado);
        }

        // POST: /ItemFotoVideoSelecionado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,EventoId,ContratoAditivoId,ItemBebidaId,Definido,Contratado,ContratacaoBisutti,FornecimentoBisutti,FornecedorStartado,Quantidade,ContatoFornecimento,Observacoes,HorarioEntrega")] ItemFotoVideoSelecionado itemfotovideoselecionado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemfotovideoselecionado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContratoAditivoId = new SelectList(db.ContratoAditivo, "Id", "Arquivo", itemfotovideoselecionado.ContratoAditivoId);
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "ContatoAssessoria", itemfotovideoselecionado.EventoId);
            ViewBag.ItemBebidaId = new SelectList(db.ItemBebida, "Id", "Nome", itemfotovideoselecionado.ItemBebidaId);
            return View(itemfotovideoselecionado);
        }

        // GET: /ItemFotoVideoSelecionado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemFotoVideoSelecionado itemfotovideoselecionado = db.ItemFotoVideoSelecionado.Find(id);
            if (itemfotovideoselecionado == null)
            {
                return HttpNotFound();
            }
            return View(itemfotovideoselecionado);
        }

        // POST: /ItemFotoVideoSelecionado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemFotoVideoSelecionado itemfotovideoselecionado = db.ItemFotoVideoSelecionado.Find(id);
            db.ItemFotoVideoSelecionado.Remove(itemfotovideoselecionado);
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
