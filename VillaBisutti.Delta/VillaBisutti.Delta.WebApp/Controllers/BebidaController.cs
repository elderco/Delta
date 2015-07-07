﻿using System;
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
    public class BebidaController : Controller
    {
        // GET: /Bebida/
        public ActionResult Index(int id)
        {
			ViewBag.Id = id;
			model.Bebida bebida = new data.Bebida().GetElement(id);
            return View(bebida);
        }

        // GET: /Bebida/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.Bebida bebida = new data.Bebida().GetElement(id.Value);
            if (bebida == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventoId = id;
            return View(bebida);
        }

        // POST: /Bebida/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EventoId,Id,Observacoes")] model.Bebida bebida)
        {
            if (ModelState.IsValid)
            {
				new data.Bebida().Update(bebida);
                return RedirectToAction("Index");
            }
            ViewBag.EventoId = bebida.Id;
            return View(bebida);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }
    }
}