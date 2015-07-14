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
    public class FotoVideoController : Controller
    {
        // GET: /FotoVideo/
        public ActionResult Index(int id)
        {
			ViewBag.Id = id;
			ViewBag.ContratoAditivoId = new SelectList(new data.ContratoAditivo().GetContratosEvento(id), "Id", "NumeroContrato");
			ViewBag.TipoItemFotoVideoId = new SelectList(new data.TipoItemFotoVideo().GetCollection(0), "Id", "Nome");
			return View(new data.FotoVideo().GetElement(id));
        }

        // GET: /FotoVideo/Edit/5
        public ActionResult Edit(int? id)
        {
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			model.FotoVideo fotovideo = new data.FotoVideo().GetElement(id.Value);
			if (fotovideo == null)
			{
				return HttpNotFound();
			}
			ViewBag.EventoId = id;
			return View(fotovideo);
        }

        // POST: /FotoVideo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edited([Bind(Include="EventoId,Observacoes")] model.FotoVideo fotovideo)
		{
			new data.FotoVideo().Update(fotovideo);
			return Redirect(Request.UrlReferrer.AbsolutePath);
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
