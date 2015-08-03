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
    [Authorize]
    public class ContratoAditivoController : Controller
    {

        // GET: /ContratoAditivo/
        public ActionResult Index(int id)
        {
			ViewBag.Id = id;
			return View(new data.ContratoAditivo().GetContratosEvento(id));
        }

        // GET: /ContratoAditivo/Create
		public ActionResult Create(int id)
        {
			ViewBag.Id = id;
			return View();
        }

        // POST: /ContratoAditivo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult ItemCreated([Bind(Include = "Id,EvtId,Arquivo,NumeroContrato,DataContrato")] model.ContratoAditivo contratoaditivo)
        {
            if (ModelState.IsValid)
            {
				new data.ContratoAditivo().Insert(contratoaditivo);
				return Redirect(Request.UrlReferrer.AbsolutePath);
            }
            return View(contratoaditivo);
        }


        // GET: /ContratoAditivo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model.ContratoAditivo contratoaditivo = new data.ContratoAditivo().GetElement(id.HasValue ? id.Value : 0);
            if (contratoaditivo == null)
            {
                return HttpNotFound();
            }
            return View(contratoaditivo);
        }

        // POST: /ContratoAditivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			new data.ContratoAditivo().Delete(id);
			return Redirect(Request.UrlReferrer.AbsolutePath);
			//return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
