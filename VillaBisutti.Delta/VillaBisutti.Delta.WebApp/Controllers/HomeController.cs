using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using model = VillaBisutti.Delta.Core.Model;
using data = VillaBisutti.Delta.Core.Data;

namespace VillaBisutti.Delta.WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HomeConfiguracao()
        {
            return View();
        }
		public ActionResult MenuEventos()
		{
			//Buscar no Data.Localizacao todas as casas
			//Incluir na lista os eventos da casa
			List<model.Local> casas = new data.Local().GetPorProdutor(SessionFacade.UsuarioLogado.Id);//SessionFacade.UsuarioLogado.Id);
			return View(casas);
		}
	}
}