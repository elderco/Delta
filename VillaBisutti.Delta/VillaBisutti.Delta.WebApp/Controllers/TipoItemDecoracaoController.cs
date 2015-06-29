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
    public class TipoItemDecoracaoController : Controller
    {

        // GET: /TipoItemDecoracao/
        public ActionResult Index()
        {
            return View(new data.TipoItemDecoracao().GetCollection(0));
        }

        // GET: /TipoItemDecoracao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.TipoItemDecoracao tipoitemdecoracao = new data.TipoItemDecoracao().GetElement(id.HasValue ? id.Value : 0);
			if (tipoitemdecoracao == null)
            {
                return HttpNotFound();
            }
			return View(tipoitemdecoracao);
        }

        // GET: /TipoItemDecoracao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoItemDecoracao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult ItemCreated([Bind(Include = "Id,Nome,PadraoAniversario,PadraoBarmitzva,PadraoBatmitzva,PadraoCasamento,PadraoCorporativo,PadraoDebutante,PadraoOutro")] model.TipoItemDecoracao tipoitemdecoracao)
        {
            if (ModelState.IsValid)
            {
				new data.TipoItemDecoracao().Insert(tipoitemdecoracao);
                return RedirectToAction("Index", "ItemDecoracao");
            }

            return View(tipoitemdecoracao);
        }

        // GET: /TipoItemDecoracao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.TipoItemDecoracao tipoitemdecoracao = new data.TipoItemDecoracao().GetElement(id.HasValue ? id.Value : 0);
           if (tipoitemdecoracao == null)
            {
                return HttpNotFound();
            }
            return View(tipoitemdecoracao);
        }

        // POST: /TipoItemDecoracao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,PadraoAniversario,PadraoBarmitzva,PadraoBatmitzva,PadraoCasamento,PadraoCorporativo,PadraoDebutante,PadraoOutro")] model.TipoItemDecoracao tipoitemdecoracao)
        {
            if (ModelState.IsValid)
            {
				new data.TipoItemDecoracao().Update(tipoitemdecoracao);
				return RedirectToAction("Index", "ItemDecoracao");
            }
            return View(tipoitemdecoracao);
        }

        // GET: /TipoItemDecoracao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.TipoItemDecoracao tipoitemdecoracao = new data.TipoItemDecoracao().GetElement(id.HasValue ? id.Value : 0);
			if (tipoitemdecoracao == null)
            {
                return HttpNotFound();
            }
            return View(tipoitemdecoracao);
        }

        // POST: /TipoItemDecoracao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			new data.TipoItemDecoracao().Delete(id);
			return RedirectToAction("Index", "ItemDecoracao");
        }

        protected override void Dispose(bool disposing)
        {
			base.Dispose(disposing);
        }
    }
}
