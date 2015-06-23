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
    public class ItemMontagemController : Controller
    {
        // GET: /ItemMontagem/
        public ActionResult Index()
        {
			return View(new data.ItemMontagem().GetCollection(0));
        }

        // GET: /ItemMontagem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.ItemMontagem itemmontagem = new data.ItemMontagem().GetElement(id.HasValue ? id.Value : 0);
            if (itemmontagem == null)
            {
                return HttpNotFound();
            }
            return View(itemmontagem);
        }

        // GET: /ItemMontagem/Create
        public ActionResult Create()
        {
			SelectList TipoItemMontagem = new SelectList(new data.TipoItemMontagem().GetCollection(0), "ID", "Name");
			ViewBag.TipoItemMontagem = TipoItemMontagem;
            return View();
        }

        // POST: /ItemMontagem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,Quantidade,TipoItemMontagemId")] model.ItemMontagem itemmontagem)
        {
            if (ModelState.IsValid)
            {
				new data.ItemMontagem().Insert(itemmontagem);
                return RedirectToAction("Index");
            }

            return View(itemmontagem);
        }

        // GET: /ItemMontagem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.ItemMontagem itemmontagem = new data.ItemMontagem().GetElement(id.HasValue ? id.Value : 0);
            if (itemmontagem == null)
            {
                return HttpNotFound();
            }
            return View(itemmontagem);
        }

        // POST: /ItemMontagem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,Quantidade,TipoItemMontagemId")] model.ItemMontagem itemmontagem)
        {
            if (ModelState.IsValid)
            {
				new data.ItemMontagem().Update(itemmontagem);
                return RedirectToAction("Index");
            }
            return View(itemmontagem);
        }

        // GET: /ItemMontagem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.ItemMontagem itemmontagem = new data.ItemMontagem().GetElement(id.HasValue ? id.Value : 0);
            if (itemmontagem == null)
            {
                return HttpNotFound();
            }
            return View(itemmontagem);
        }

        // POST: /ItemMontagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			new data.ItemMontagem().Delete(id);
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}
	}
}
