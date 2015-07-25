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
    public class UsuarioController : Controller
    {
        // GET: /Usuario/
        public ActionResult Index()
        {
			return View(new data.Usuario().GetCollection(0));
        }
        public ActionResult Buscar(int combo, string texto)
        {
            return View(new data.Perfil().Filtrar(combo, texto));
        }

		public ActionResult Create()
		{
            ViewBag.Perfis = new SelectList(new data.Perfil().GetCollection(0),"Id","Nome");
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult ItemCreated([Bind(Include = "Id,Nome,Email,Senha,PerfilId")] model.Usuario usuario)
		{
			if (ModelState.IsValid)
			{
				new data.Usuario().Insert(usuario);
				return RedirectToAction("Index", "Usuario");
			}
			return View(usuario);
		}

         //GET: /Usuario/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			model.Usuario usuario = new data.Usuario().GetElement(id.HasValue ? id.Value : 0);
			if (usuario == null)
			{
				return HttpNotFound();
			}
			return View(usuario);
		}

		// GET: /Usuario/Edit/5
		public ActionResult Edit(int? id)
		{
            model.Usuario usuario = new data.Usuario().GetElement(id.HasValue ? id.Value : 0);
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
               
                SelectList perfis = new SelectList(new data.Perfil().GetCollection(0), "Id", "Nome");
                ViewBag.Profile = perfis;
                if (usuario == null)
                {
                    return HttpNotFound();
                } 
            }
			return View(usuario);
		}

		// POST: /Usuario/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Nome,Email,PerfilId,Senha")] model.Usuario usuario)
		{
			if (ModelState.IsValid)
			{
				new data.Usuario().Update(usuario);
				return RedirectToAction("Index", "Usuario");
			}
			return View(usuario);
		}

		// GET: /Usuario/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			model.Usuario usuario = new data.Usuario().GetElement(id.HasValue ? id.Value : 0);
			if (usuario == null)
			{
				return HttpNotFound();
			}
			return View(usuario);
		}

		// POST: /Usuario/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			new data.Usuario().Delete(id);
			return RedirectToAction("Index", "Usuario");
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}
    }
}
