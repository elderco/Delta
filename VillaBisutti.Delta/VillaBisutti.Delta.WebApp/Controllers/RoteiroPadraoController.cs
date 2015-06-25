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
    public class RoteiroPadraoController : Controller
    {
		 // GET: /RoteiroPadrao/
        public ActionResult Index()
        {
            return View(new data.RoteiroPadrao().GetCollection(0));
        }

        // GET: /RoteiroPadrao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.RoteiroPadrao roteiropadrao = new data.RoteiroPadrao().GetElement(id.HasValue ? id.Value : 0);
			if (roteiropadrao == null)
            {
                return HttpNotFound();
            }
            return View(roteiropadrao);
        }

        // GET: /RoteiroPadrao/Create
        public ActionResult Create()
        {
			SelectList roteiropadrao = new SelectList(new data.RoteiroPadrao().GetCollection(0),"Id");
            return View();
        }

        // POST: /RoteiroPadrao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id")] model.RoteiroPadrao roteiropadrao)
        {
            if (ModelState.IsValid)
            {
				new data.RoteiroPadrao().Insert(roteiropadrao);
                return RedirectToAction("Index");
            }

            return View(roteiropadrao);
        }

        // GET: /RoteiroPadrao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.RoteiroPadrao roteiropadrao = new data.RoteiroPadrao().GetElement(id.HasValue ? id.Value : 0);
			if (roteiropadrao == null)
            {
                return HttpNotFound();
            }
            return View(roteiropadrao);
        }

        // POST: /RoteiroPadrao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id")] model.RoteiroPadrao roteiropadrao)
        {
            if (ModelState.IsValid)
            {
				new data.RoteiroPadrao().Update(roteiropadrao);
                return RedirectToAction("Index");
            }
            return View(roteiropadrao);
        }

        // GET: /RoteiroPadrao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.RoteiroPadrao roteiropadrao = new data.RoteiroPadrao().GetElement(id.HasValue ? id.Value : 0);
			if (roteiropadrao == null)
            {
                return HttpNotFound();
            }
            return View(roteiropadrao);
        }

        // POST: /RoteiroPadrao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			new data.RoteiroPadrao().Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
