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
    public class ContratoAditivoController : Controller
    {

        // GET: /ContratoAditivo/
        public ActionResult Index(int id)
        {
			ViewBag.Id = id;
			model.ContratoAditivo contratoaditivo = new data.ContratoAditivo().GetElement(id);
			return View(contratoaditivo);
        }

        // GET: /ContratoAditivo/Details/5
        public ActionResult Details(int? id)
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

        // GET: /ContratoAditivo/Create
        public ActionResult Create()
        {
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
                return RedirectToAction("Index");
            }

            return View(contratoaditivo);
        }

        // GET: /ContratoAditivo/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: /ContratoAditivo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,TipoEventoId,TipoEvento")] model.ContratoAditivo contratoaditivo)
        {
            if (ModelState.IsValid)
            {
				new data.ContratoAditivo().Update(contratoaditivo);
                return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
