using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VillaBisutti.Delta.Core.Data;
using VillaBisutti.Delta.Core.Model;
using data = VillaBisutti.Delta.Core.Data;
using model = VillaBisutti.Delta.Core.Model;
using bus = VillaBisutti.Delta.Core.Business;


namespace VillaBisutti.Delta.WebApp.Controllers
{
    public class PerfilController : Controller
    {
        // GET: Perfils
        public ActionResult Index()
        {
            return View(new data.Perfil().GetCollection(0));
        }

        // GET: Perfils/Create
        public ActionResult Create()
        {
            ViewBag.Modulos = new data.Modulo().GetCollection(0);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ItemCreated([Bind(Include= "Id,Nome,Modulos")]model.Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                new data.Perfil().Insert(perfil);
                return RedirectToAction("Index");
            }
            return View(perfil);
        }

        // get: perfils/edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model.Perfil perfil = new data.Perfil().GetPerfil(id.HasValue ? id.Value : 0);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edited([Bind(Include="Id,Nome,Modulos")] model.Perfil perfil)
        {
            new bus.PerfilAlterado().AlterarPerfil(perfil);
            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }
        // GET: Perfils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model.Perfil perfil = new data.Perfil().GetContextPerfil(id.Value);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // POST: Perfils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new data.Perfil().Delete(id);
            return RedirectToAction("Index");
        }
    }
}

