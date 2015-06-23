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
    public class ItemDecoracaoController : Controller
    {
        // GET: /ItemDecoracao/
        public ActionResult Index()
        {
            return View(new data.ItemDecoracao().GetCollection(0));
        }

        // GET: /ItemDecoracao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.ItemDecoracao itemdecoracao = new data.ItemDecoracao().GetElement(id.HasValue ? id.Value : 0);
            if (itemdecoracao == null)
            {
                return HttpNotFound();
            }
            return View(itemdecoracao);
        }

        // GET: /ItemDecoracao/Create
        public ActionResult Create()
        {
			SelectList TipoItemDecoracao = new SelectList(new data.TipoItemDecoracao().GetCollection(0).OrderBy(tid => tid.Nome), "Id", "Nome");
			ViewBag.Caetano = TipoItemDecoracao;
            return View();
        }

        // POST: /ItemDecoracao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,Quantidade,TipoItemDecoracaoId")] model.ItemDecoracao itemdecoracao)
        {
            if (ModelState.IsValid)
            {
				new data.ItemDecoracao().Insert(itemdecoracao);
                return RedirectToAction("Index");
            }

			return View(itemdecoracao);
        }

        // GET: /ItemDecoracao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.ItemDecoracao itemdecoracao = new data.ItemDecoracao().GetElement(id.HasValue ? id.Value : 0);
            if (itemdecoracao == null)
            {
                return HttpNotFound();
            }
            return View(itemdecoracao);
        }

        // POST: /ItemDecoracao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,Quantidade,TipoItemDecoracaoId")] model.ItemDecoracao itemdecoracao)
        {
            if (ModelState.IsValid)
            {
				new data.ItemDecoracao().Update(itemdecoracao);
                return RedirectToAction("Index");
            }
            return View(itemdecoracao);
        }

        // GET: /ItemDecoracao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.ItemDecoracao itemdecoracao = new data.ItemDecoracao().GetElement(id.HasValue ? id.Value : 0);
            if (itemdecoracao == null)
            {
                return HttpNotFound();
            }
            return View(itemdecoracao);
        }

        // POST: /ItemDecoracao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			new data.ItemDecoracao().Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
