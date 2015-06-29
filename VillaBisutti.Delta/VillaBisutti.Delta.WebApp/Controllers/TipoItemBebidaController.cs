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
    public class TipoItemBebidaController : Controller
    {

        // GET: /TipoItemBebida/
        public ActionResult Index()
        {
			return View(new data.TipoItemBebida().GetCollection(0));
        }

        // GET: /TipoItemBebida/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.TipoItemBebida tipoitembebida = new data.TipoItemBebida().GetElement(id.HasValue ? id.Value : 0);
            if (tipoitembebida == null)
            {
                return HttpNotFound();
            }
            return View(tipoitembebida);
        }

        // GET: /TipoItemBebida/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoItemBebida/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult ItemCreated([Bind(Include = "Id,Nome,PadraoAniversario,PadraoBarmitzva,PadraoBatmitzva,PadraoCasamento,PadraoCorporativo,PadraoDebutante,PadraoOutro")] model.TipoItemBebida tipoitembebida)
        {
            if (ModelState.IsValid)
            {
				new data.TipoItemBebida().Insert(tipoitembebida);
                return RedirectToAction("Index");
            }

            return View(tipoitembebida);
        }

        // GET: /TipoItemBebida/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.TipoItemBebida tipoitembebida = new data.TipoItemBebida().GetElement(id.HasValue ? id.Value : 0);
            if (tipoitembebida == null)
            {
                return HttpNotFound();
            }
            return View(tipoitembebida);
        }

        // POST: /TipoItemBebida/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Nome,PadraoAniversario,PadraoBarmitzva,PadraoBatmitzva,PadraoCasamento,PadraoCorporativo,PadraoDebutante,PadraoOutro")] model.TipoItemBebida tipoitembebida)
        {
            if (ModelState.IsValid)
            {
				new data.TipoItemBebida().Update(tipoitembebida);
                return RedirectToAction("Index");
            }
            return View(tipoitembebida);
        }

        // GET: /TipoItemBebida/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.TipoItemBebida tipoitembebida = new data.TipoItemBebida().GetElement(id.HasValue ? id.Value : 0);
            if (tipoitembebida == null)
            {
                return HttpNotFound();
            }
            return View(tipoitembebida);
        }

        // POST: /TipoItemBebida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			new data.TipoItemBebida().Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
