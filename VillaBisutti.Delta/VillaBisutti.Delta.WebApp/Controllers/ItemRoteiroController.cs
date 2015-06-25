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
    public class ItemRoteiroController : Controller
    {
        // GET: /ItemRoteiro/
        public ActionResult Index()
        {
			return View(new data.ItemRoteiro().GetCollection(0));
        }

        // GET: /ItemRoteiro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.ItemRoteiro itemroteiro = new data.ItemRoteiro().GetElement(id.HasValue ? id.Value : 0);
			if (itemroteiro == null)
            {
                return HttpNotFound();
            }
            return View(itemroteiro);
        }

        // GET: /ItemRoteiro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ItemRoteiro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Titulo,HorarioInicio,Importante,Observacao,RoteiroPadraoId,RoteiroId")] model.ItemRoteiro itemroteiro)
        {
            if (ModelState.IsValid)
            {
				new data.ItemRoteiro().Insert(itemroteiro);
                return RedirectToAction("Index");
            }
            return View(itemroteiro);
        }

        // GET: /ItemRoteiro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model.ItemRoteiro itemroteiro = new data.ItemRoteiro().GetElement(id.HasValue ? id.Value : 0);
			if (itemroteiro == null)
            {
                return HttpNotFound();
            }
            return View(itemroteiro);
        }

        // POST: /ItemRoteiro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Titulo,HorarioInicio,Importante,Observacao,RoteiroPadraoId,RoteiroId")] model.ItemRoteiro itemroteiro)
        {
            if (ModelState.IsValid)
            {
				new data.ItemRoteiro().Update(itemroteiro);
                return RedirectToAction("Index");
            }
            return View(itemroteiro);
        }

        // GET: /ItemRoteiro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.ItemRoteiro itemroteiro = new data.ItemRoteiro().GetElement(id.HasValue ? id.Value : 0);
			if (itemroteiro == null)
            {
                return HttpNotFound();
            }
            return View(itemroteiro);
        }

        // POST: /ItemRoteiro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			new data.ItemRoteiro().Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
