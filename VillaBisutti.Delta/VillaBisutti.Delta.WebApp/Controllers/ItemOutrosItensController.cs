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
    public class ItemOutrosItensController : Controller
    {
        // GET: /ItemOutrosItens/
        public ActionResult Index()
        {
            return View(new data.ItemOutrosItemItemDiverso().GetCollection(0));
        }

        // GET: /ItemOutrosItens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.ItemOutrosItens itemoutrositens = new data.ItemOutrosItemItemDiverso().GetElement(id.HasValue ? id.Value : 0);
			if (itemoutrositens == null)
            {
                return HttpNotFound();
            }
            return View(itemoutrositens);
        }

        // GET: /ItemOutrosItens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ItemOutrosItens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,Quantidade,TipoItemOutroItemItemDiversoId")] model.ItemOutrosItens itemoutrositens)
        {
            if (ModelState.IsValid)
            {
				new data.ItemOutrosItemItemDiverso().Insert(itemoutrositens);
				return RedirectToAction("Index");
            }
			return View(itemoutrositens);
        }

        // GET: /ItemOutrosItens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.ItemOutrosItens itemoutrositens = new data.ItemOutrosItemItemDiverso().GetElement(id.HasValue ? id.Value : 0);
			if (itemoutrositens == null)
            {
                return HttpNotFound();
            }
			return View(itemoutrositens);
        }

        // POST: /ItemOutrosItens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,Quantidade,TipoItemOutroItemItemDiversoId")] model.ItemOutrosItens itemoutrositens)
        {
            if (ModelState.IsValid)
            {
				new data.ItemOutrosItemItemDiverso().Update(itemoutrositens);
                return RedirectToAction("Index");
            }
            return View(itemoutrositens);
        }

        // GET: /ItemOutrosItens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.ItemOutrosItens itemoutrositens = new data.ItemOutrosItemItemDiverso().GetElement(id.HasValue ? id.Value : 0);
			if (itemoutrositens == null)
            {
                return HttpNotFound();
            }
            return View(itemoutrositens);
        }

        // POST: /ItemOutrosItens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new data.ItemOutrosItemItemDiverso().Delete(id);
			return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
