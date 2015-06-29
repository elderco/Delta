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
    public class ItemSomIluminacaoController : Controller
    {
        // GET: /ItemSomIluminacao/
        public ActionResult Index()
        {
             return View(new data.ItemSomIluminacao().GetCollection(0));
        }

        // GET: /ItemSomIluminacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.ItemSomIluminacao itemsomiluminacao = new data.ItemSomIluminacao().GetElement(id.HasValue ? id.Value : 0);
			if (itemsomiluminacao == null)
            {
                return HttpNotFound();
            }
            return View(itemsomiluminacao);
        }

        // GET: /ItemSomIluminacao/Create
        public ActionResult Create()
        {
			SelectList TipoItemSomIluminacao = new SelectList(new data.TipoItemSomIluminacao().GetCollection(0).OrderBy(tid => tid.Nome), "Id", "Nome");
			ViewBag.TipoItemSomIluminacao = TipoItemSomIluminacao;
            return View();
        }

        // POST: /ItemSomIluminacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult ItemCreated([Bind(Include = "Id,Nome,Quantidade,TipoItemSomIluminacaoId")] model.ItemSomIluminacao itemsomiluminacao)
        {
            if (ModelState.IsValid)
            {
				new data.ItemSomIluminacao().Insert(itemsomiluminacao);
				return RedirectToAction("Index");
            }
			return View(itemsomiluminacao);
        }

        // GET: /ItemSomIluminacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.ItemSomIluminacao itemsomiluminacao = new data.ItemSomIluminacao().GetElement(id.HasValue ? id.Value : 0);
			if (itemsomiluminacao == null)
            {
                return HttpNotFound();
            }
			SelectList TipoItemSomIluminacao = new SelectList(new data.TipoItemSomIluminacao().GetCollection(0).OrderBy(tid => tid.Nome), "Id", "Nome");
			ViewBag.TipoItemSomIluminacao = TipoItemSomIluminacao;
            return View(itemsomiluminacao);
        }

        // POST: /ItemSomIluminacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,Quantidade,TipoItemSomIluminacaoId")] model.ItemSomIluminacao itemsomiluminacao)
        {
            if (ModelState.IsValid)
            {
				new data.ItemSomIluminacao().Update(itemsomiluminacao);
                return RedirectToAction("Index");
            }
            return View(itemsomiluminacao);
        }

        // GET: /ItemSomIluminacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.ItemSomIluminacao itemsomiluminacao = new data.ItemSomIluminacao().GetElement(id.HasValue ? id.Value : 0);
			if (itemsomiluminacao == null)
            {
                return HttpNotFound();
            }
            return View(itemsomiluminacao);
        }

        // POST: /ItemSomIluminacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			new data.ItemSomIluminacao().Delete(id);
			return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
