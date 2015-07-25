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
    public class GastronomiaController : Controller
    {
        // GET: /Gastronomia/
        public ActionResult Index(int id)
        {
			ViewBag.Cardapios = new SelectList(new data.Cardapio().GetCollection(0).OrderBy(c => c.Nome), "Id", "Nome");
			ViewBag.TipoServicos = new SelectList(new data.TipoServico().GetCollection(0).OrderBy(ts => ts.Nome), "Id", "Nome");
			ViewBag.Id = id;
			return View(new data.Gastronomia().GetElement(id));
		}

        // GET: /Gastronomia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model.Gastronomia gastronomia = new data.Gastronomia().GetElement(id.Value);
            if (gastronomia == null)
            {
                return HttpNotFound();
            }
			ViewBag.EventoId = id;
			return View(gastronomia);
        }

        // POST: /Gastronomia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edited([Bind(Include="EventoId,Id,Observacoes,Evento")] model.Gastronomia gastronomia)
        {
			new data.Gastronomia().Update(gastronomia);
			return Redirect(Request.UrlReferrer.AbsolutePath);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
