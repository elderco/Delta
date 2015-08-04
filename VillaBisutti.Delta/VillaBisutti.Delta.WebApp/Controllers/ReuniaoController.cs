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
using biz = VillaBisutti.Delta.Core.Business;

namespace VillaBisutti.Delta.WebApp.Controllers
{
	public class ReuniaoController : Controller
	{

		// GET: /Reuniao/
		public ActionResult Index(int id)
		{
			ViewBag.Id = id;
			ViewBag.TipoReuniaoId = new data.TipoReuniao().GetCollection(0);
			ViewBag.UsuarioId = new data.Usuario().GetCollection(0);
			return View(new data.Reuniao().ReunioesEvento(id));
		}

		// POST: /Reuniao/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,EventoId,UsuarioId,TipoReuniaoId,Data,HorarioReuniao,Observacoes,Definida,Executada")] model.Reuniao reuniao)
		{
			new data.Reuniao().Insert(reuniao);
			return Redirect(Request.UrlReferrer.AbsoluteUri);
		}

		// POST: /Reuniao/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,EventoId,UsuarioId,TipoReuniaoId,Data,HorarioReuniao,Observacoes,Definida,Executada")] model.Reuniao reuniao)
		{
			new data.Reuniao().Update(reuniao);
			return Redirect(Request.UrlReferrer.AbsoluteUri);
		}

		// GET: /Reuniao/Delete/5
		public ActionResult Delete(int? id)
		{
			return View(new data.Reuniao().GetElement(id.Value));
		}

		// POST: /Reuniao/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			new data.Reuniao().Delete(id);
			return Redirect(Request.UrlReferrer.AbsoluteUri);
		}
		public ActionResult Copy(int eventoId)
		{
			new biz.Reuniao().CopiarReunioesPadrao(eventoId);
			return Redirect(Request.UrlReferrer.AbsoluteUri);
		}
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}
	}
}
