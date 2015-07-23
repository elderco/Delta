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

        // POST: Perfils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(model.Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                new data.Perfil().Update(perfil);
                return Redirect(Request.UrlReferrer.AbsolutePath);
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
            model.Perfil perfil = new data.Perfil().GetElement(id.HasValue? id.Value : 0);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edited(model.Perfil perfil)
        {
            new data.Perfil().Update(perfil);
            return Redirect(Request.UrlReferrer.AbsolutePath);
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

       

        //// POST: Perfils/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Nome")] Perfil perfil)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Perfil.Add(perfil);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(perfil);
        //}

       

       


        //// POST: Perfils/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Perfil perfil = db.Perfil.Find(id);
        //    db.Perfil.Remove(perfil);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}

