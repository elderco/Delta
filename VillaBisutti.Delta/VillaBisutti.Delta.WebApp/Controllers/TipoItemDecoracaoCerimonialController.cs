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
    [Authorize]
    public class TipoItemDecoracaoCerimonialController : Controller
	{
		public ActionResult ListNaoSelecionados(int id)
		{
			return View(new data.TipoItemDecoracaoCerimonial().ListNaoSelecionados(id));
		}
		public ActionResult Index()
		{
			return View(new data.TipoItemDecoracaoCerimonial().GetCollection(0));
		}

		// GET: /TipoItemDecoracao/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			model.TipoItemDecoracaoCerimonial tipoitemdecoracaocerimonial = new data.TipoItemDecoracaoCerimonial().GetElement(id.HasValue ? id.Value : 0);
			if (tipoitemdecoracaocerimonial == null)
			{
				return HttpNotFound();
			}
			return View(tipoitemdecoracaocerimonial);
		}

		// GET: /TipoItemDecoracao/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: /TipoItemDecoracao/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult ItemCreated([Bind(Include = "Id,Nome,PadraoAniversario,PadraoBarmitzva,PadraoBatmitzva,PadraoBodas,PadraoCasamento,PadraoCorporativo,PadraoDebutante,PadraoOutro,CopiaBebida,CopiaMontagem,CopiaBoloDoceBemCasado,CopiaFotoVideo,CopiaSomIluminacao,CopiaOutrosItens")] model.TipoItemDecoracaoCerimonial tipoitemdecoracaocerimonial)
		{
			if (ModelState.IsValid)
			{
				new data.TipoItemDecoracaoCerimonial().Insert(tipoitemdecoracaocerimonial);
				return RedirectToAction("Index", "ItemDecoracaoCerimonial");
			}

			return View(tipoitemdecoracaocerimonial);
		}

		// GET: /TipoItemDecoracao/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			model.TipoItemDecoracaoCerimonial tipoitemdecoracaocerimonial = new data.TipoItemDecoracaoCerimonial().GetElement(id.HasValue ? id.Value : 0);
			if (tipoitemdecoracaocerimonial == null)
			{
				return HttpNotFound();
			}
			return View(tipoitemdecoracaocerimonial);
		}

		// POST: /TipoItemDecoracao/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Nome,PadraoAniversario,PadraoBarmitzva,PadraoBatmitzva,PadraoBodas,PadraoCasamento,PadraoCorporativo,PadraoDebutante,PadraoOutro,CopiaBebida,CopiaMontagem,CopiaBoloDoceBemCasado,CopiaFotoVideo,CopiaSomIluminacao,CopiaOutrosItens")] model.TipoItemDecoracaoCerimonial tipoitemdecoracaocerimonial)
		{
			if (ModelState.IsValid)
			{
				new data.TipoItemDecoracaoCerimonial().Update(tipoitemdecoracaocerimonial);
				return RedirectToAction("Index", "ItemDecoracaoCerimonial");
			}
			return View(tipoitemdecoracaocerimonial);
		}

		// GET: /TipoItemDecoracao/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			model.TipoItemDecoracaoCerimonial tipoitemdecoracaocerimonial = new data.TipoItemDecoracaoCerimonial().GetElement(id.HasValue ? id.Value : 0);
			if (tipoitemdecoracaocerimonial == null)
			{
				return HttpNotFound();
			}
			return View(tipoitemdecoracaocerimonial);
		}

		// POST: /TipoItemDecoracao/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			new data.TipoItemDecoracaoCerimonial().Delete(id);
			return RedirectToAction("Index", "ItemDecoracaoCerimonial");
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}
	}
}
