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
    public class TipoReuniaoController : Controller
    {
        // GET: /TipoReuniao/
        public ActionResult Index()
        {
            return View(new data.TipoReuniao().GetCollection(0));
        }

        // GET: /TipoReuniao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoReuniao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,DiasAntesEvento,MaximoEventosEnvolvidos,PodeDomingo,PodeSegunda,PodeTerca,PodeQuarta,PodeQuinta,PodeSexta,PodeSabado,AreaEnvolvida,MaximoAreaEnvolvida,Duracao,HorarioDisponibilidadeInicio,HorarioDisponibilidadeTermino")] model.TipoReuniao tiporeuniao)
        {
            if (ModelState.IsValid)
            {
				new data.TipoReuniao().Insert(tiporeuniao);
                return RedirectToAction("Index");
            }

            return View(tiporeuniao);
        }

        // GET: /TipoReuniao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model.TipoReuniao tiporeuniao = new data.TipoReuniao().GetElement(id.Value);
            if (tiporeuniao == null)
            {
                return HttpNotFound();
            }
            return View(tiporeuniao);
        }

        // POST: /TipoReuniao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,DiasAntesEvento,MaximoEventosEnvolvidos,PodeDomingo,PodeSegunda,PodeTerca,PodeQuarta,PodeQuinta,PodeSexta,PodeSabado,AreaEnvolvida,MaximoAreaEnvolvida,Duracao,HorarioDisponibilidadeInicio,HorarioDisponibilidadeTermino")] model.TipoReuniao tiporeuniao)
        {
            if (ModelState.IsValid)
            {
				new data.TipoReuniao().Update(tiporeuniao);
				return RedirectToAction("Index");
            }
            return View(tiporeuniao);
        }

        // GET: /TipoReuniao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.TipoReuniao tiporeuniao = new data.TipoReuniao().GetElement(id.Value);
            if (tiporeuniao == null)
            {
                return HttpNotFound();
            }
            return View(tiporeuniao);
        }

        // POST: /TipoReuniao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			new data.TipoReuniao().Delete(id);
			return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
