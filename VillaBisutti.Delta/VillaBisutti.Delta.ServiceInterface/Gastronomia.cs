using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;
using data = VillaBisutti.Delta.Core.Data;
using svc = VillaBisutti.Delta.ServiceModel;
using ServiceStack.Common.Web;
using System.Net;


namespace VillaBisutti.Delta.ServiceInterface
{
	public class Gastronomia : Service
	{
		public model.ItemGastronomiaSelecionado Get(svc.Gastronomia.Get request)
		{
			return new data.ItemGastronomiaSelecionado().GetElement(request.Id);
		}
		public List<model.ItemGastronomiaSelecionado> Get(svc.Gastronomia.GetAll request)
		{
			return new data.ItemGastronomiaSelecionado().GetCollection(0);
		}
		public HttpResult Post(svc.Gastronomia.New request)
		{
			new data.ItemGastronomiaSelecionado().Insert(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Put(svc.Gastronomia.Update request)
		{
			new data.ItemGastronomiaSelecionado().Update(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Delete(svc.Gastronomia.Delete request)
		{
			new data.ItemGastronomiaSelecionado().Delete(request.Id);
			return new HttpResult(request, HttpStatusCode.OK);
		}
	}
}
