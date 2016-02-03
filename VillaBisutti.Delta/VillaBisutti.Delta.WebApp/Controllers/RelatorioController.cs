using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using biz = VillaBisutti.Delta.Core.Business;
using data = VillaBisutti.Delta.Core.Data;

namespace VillaBisutti.Delta.WebApp.Controllers
{
	public class RelatorioController : Controller
	{
		public ActionResult Perfil(DateTime? inicio = null, DateTime? termino = null)
		{
			if (inicio == null)
				inicio = DateTime.Now.AddDays(3);
			if (termino == null)
				termino = DateTime.Now.AddDays(10);
			return View(biz.Evento.GetPerfil(inicio.Value, termino.Value));
		}
		public ActionResult BoloDoceBemCasado(DateTime? inicio = null, DateTime? termino = null, int fornecedorId = 0)
		{
			ViewBag.Fornecedor = new SelectList(new data.FornecedorBoloDoceBemCasado().GetCollection(0), "Id", "NomeFornecedor");
			if (inicio == null)
				inicio = DateTime.Now.AddDays(3);
			if (termino == null)
				termino = DateTime.Now.AddDays(10);
			return View(biz.BoloDoceBemCasado.GetReport(inicio.Value, termino.Value, fornecedorId));
		}
		public ActionResult Bebida(DateTime? inicio = null, DateTime? termino = null)
		{
			return View();
		}
	}
}