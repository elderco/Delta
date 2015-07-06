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
    public class BoloDoceBemCasadoController : Controller
    {

        // GET: /BoloDoceBemCasado/
        public ActionResult Index()
        {
			return View(new data.BoloDoceBemCasado().GetCollection(0));
        }

        // GET: /BoloDoceBemCasado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.BoloDoceBemCasado bolodocebemcasado = new data.BoloDoceBemCasado().GetElement(id.HasValue ? id.Value : 0);
            if (bolodocebemcasado == null)
            {
                return HttpNotFound();
            }
            return View(bolodocebemcasado);
        }

        // GET: /BoloDoceBemCasado/Create
        public ActionResult Create()
        {
			SelectList BoloDoceBemCasado = new SelectList(new data.BoloDoceBemCasado().GetCollection(0).OrderBy(tid => tid.EventoId), "Id", "EventoId");
			ViewBag.BoloDoceBemCasado = BoloDoceBemCasado;
			return View();
        }

        // POST: /BoloDoceBemCasado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EventoId,Id,Observacoes")] model.BoloDoceBemCasado bolodocebemcasado)
        {
            if (ModelState.IsValid)
            {
				new data.BoloDoceBemCasado().Insert(bolodocebemcasado);
                return RedirectToAction("Index");
            }
            return View(bolodocebemcasado);
        }

        // GET: /BoloDoceBemCasado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.BoloDoceBemCasado bolodocebemcasado = new data.BoloDoceBemCasado().GetElement(id.HasValue ? id.Value : 0);
            if (bolodocebemcasado == null)
            {
                return HttpNotFound();
            }
			SelectList BoloDoceBemCasado = new SelectList(new data.BoloDoceBemCasado().GetCollection(0).OrderBy(tid => tid.EventoId), "Id", "EventoId");
			ViewBag.BoloDoceBemCasado = bolodocebemcasado;
			return View(bolodocebemcasado);
        }

        // POST: /BoloDoceBemCasado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EventoId,Id,Observacoes")] model.BoloDoceBemCasado bolodocebemcasado)
        {
            if (ModelState.IsValid)
            {
				new data.BoloDoceBemCasado().Update(bolodocebemcasado);
                return RedirectToAction("Index");
            }
            return View(bolodocebemcasado);
        }

        // GET: /BoloDoceBemCasado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.BoloDoceBemCasado bolodocebemcasado = new data.BoloDoceBemCasado().GetElement(id.HasValue ? id.Value : 0);
            if (bolodocebemcasado == null)
            {
                return HttpNotFound();
            }
            return View(bolodocebemcasado);
        }

        // POST: /BoloDoceBemCasado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			new data.BoloDoceBemCasado().Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
