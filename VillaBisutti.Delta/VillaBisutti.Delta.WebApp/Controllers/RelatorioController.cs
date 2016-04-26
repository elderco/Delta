using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using biz = VillaBisutti.Delta.Core.Business;
using data = VillaBisutti.Delta.Core.Data;
using model = VillaBisutti.Delta.Core.Model;

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
		public ActionResult ItensContratar(DateTime? inicio = null, DateTime? termino = null, bool? definido = null, bool? contratado = null, bool? fornecedorStartado = null, string fornecimento = "BISUTTI", string area = "|")
		{
			if (area == "|")
				return View(new List<model.Itens>());
			bool fornecimentoBisutti = false, responsabilidadeBisutti = false;
			if (fornecimento == "BISUTTI")
			{
				fornecimentoBisutti = true;
				responsabilidadeBisutti = true;
			}
			else if (fornecimento == "TERCEIRO")
			{
				responsabilidadeBisutti = true;
			}
			if (inicio == null)
				inicio = DateTime.Now.AddDays(14);
			if (termino == null)
				termino = DateTime.Now.AddDays(15);
			return View(biz.ItensContratar.GetReport(area, inicio.Value, termino.Value, definido, contratado, fornecedorStartado, fornecimentoBisutti, responsabilidadeBisutti));
		}
	}
}