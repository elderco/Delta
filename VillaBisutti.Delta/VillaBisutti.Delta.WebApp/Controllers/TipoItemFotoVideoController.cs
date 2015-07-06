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
    public class TipoItemFotoVideoController : Controller
    {

        // GET: /TipoItemFotoVideo/
        public ActionResult Index()
        {
			return View(new data.TipoItemFotoVideo().GetCollection(0));
        }

        // GET: /TipoItemFotoVideo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.TipoItemFotoVideo tipoitemfotovideo = new data.TipoItemFotoVideo().GetElement(id.HasValue ? id.Value : 0);
            if (tipoitemfotovideo == null)
            {
                return HttpNotFound();
            }
            return View(tipoitemfotovideo);
        }

        // GET: /TipoItemFotoVideo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoItemFotoVideo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult ItemCreated([Bind(Include = "Id,Nome,PadraoAniversario,PadraoBarmitzva,PadraoBatmitzva,PadraoCasamento,PadraoCorporativo,PadraoDebutante,PadraoOutro,CopiaBebida,CopiaDecoracao,CopiaMontagem,CopiaBoloDoceBemCasado,CopiaSomIluminacao,CopiaOutrosItens")] model.TipoItemFotoVideo tipoitemfotovideo)
        {
            if (ModelState.IsValid)
            {
				new data.TipoItemFotoVideo().Insert(tipoitemfotovideo);
				return RedirectToAction("Index", "ItemFotoVideo");
            }

            return View(tipoitemfotovideo);
        }

        // GET: /TipoItemFotoVideo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.TipoItemFotoVideo tipoitemfotovideo = new data.TipoItemFotoVideo().GetElement(id.HasValue ? id.Value : 0);
            if (tipoitemfotovideo == null)
            {
                return HttpNotFound();
            }
            return View(tipoitemfotovideo);
        }

        // POST: /TipoItemFotoVideo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Nome,PadraoAniversario,PadraoBarmitzva,PadraoBatmitzva,PadraoCasamento,PadraoCorporativo,PadraoDebutante,PadraoOutro,CopiaBebida,CopiaDecoracao,CopiaMontagem,CopiaBoloDoceBemCasado,CopiaSomIluminacao,CopiaOutrosItens")] model.TipoItemFotoVideo tipoitemfotovideo)
        {
            if (ModelState.IsValid)
            {
				new data.TipoItemFotoVideo().Update(tipoitemfotovideo);
				return RedirectToAction("Index", "ItemFotoVideo");
            }
            return View(tipoitemfotovideo);
        }

        // GET: /TipoItemFotoVideo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.TipoItemFotoVideo tipoitemfotovideo = new data.TipoItemFotoVideo().GetElement(id.HasValue ? id.Value : 0);
            if (tipoitemfotovideo == null)
            {
                return HttpNotFound();
            }
            return View(tipoitemfotovideo);
        }

        // POST: /TipoItemFotoVideo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			new data.TipoItemFotoVideo().Delete(id);
			return RedirectToAction("Index", "ItemFotoVideo");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
