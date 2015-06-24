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
    public class ItemBebidaController : Controller
    {
        // GET: /ItemBebida/
        public ActionResult Index()
        {
            return View(new data.ItemBebida().GetCollection(0));
        }

        // GET: /ItemBebida/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.ItemBebida itembebida = new data.ItemBebida().GetElement(id.HasValue ? id.Value : 0);
			if (itembebida == null)
            {
                return HttpNotFound();
            }
            return View(itembebida);
        }

        // GET: /ItemBebida/Create
        public ActionResult Create()
        {
			SelectList TipoItemBebida = new SelectList(new data.TipoItemBebida().GetCollection(0).OrderBy(tid => tid.Nome), "Id", "Nome");
			ViewBag.TipoItemBebida = TipoItemBebida;
            return View();
        }

        // POST: /ItemBebida/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,Quantidade,TipoItemBebidaId")] model.ItemBebida itembebida)
        {
            if (ModelState.IsValid)
            {
				new data.ItemBebida().Insert(itembebida);
				return RedirectToAction("Index");
            }
            return View(itembebida);
        }

        // GET: /ItemBebida/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.ItemBebida itembebida = new data.ItemBebida().GetElement(id.HasValue ? id.Value : 0);
			if (itembebida == null)
            {
                return HttpNotFound();
            }
            return View(itembebida);
        }

        // POST: /ItemBebida/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,Quantidade,TipoItemBebidaId")] model.ItemBebida itembebida)
        {
            if (ModelState.IsValid)
            {
				new data.ItemBebida().Update(itembebida);
                return RedirectToAction("Index");
            }
            return View(itembebida);
        }

        // GET: /ItemBebida/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.ItemBebida itembebida = new data.ItemBebida().GetElement(id.HasValue ? id.Value : 0);
			if (itembebida == null)
            {
                return HttpNotFound();
            }
            return View(itembebida);
        }

        // POST: /ItemBebida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			new data.ItemBebida().Delete(id);
			return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
