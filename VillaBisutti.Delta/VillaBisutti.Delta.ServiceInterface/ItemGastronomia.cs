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
	public class ItemGastronomia : Service
	{
		public model.ItemGastronomia Get(svc.ItemGastronomia.Get request)
		{
			return new data.ItemGastronomia().GetElement(request.Id);
		}
		public List<model.ItemGastronomia> Get(svc.ItemGastronomia.GetAll request)
		{
			return new data.ItemGastronomia().GetCollection(0);
		}
		public HttpResult Post(svc.ItemGastronomia.New request)
		{
			new data.ItemGastronomia().Insert(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Put(svc.ItemGastronomia.Update request)
		{
			new data.ItemGastronomia().Update(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Delete(svc.ItemGastronomia.Delete request)
		{
			new data.ItemGastronomia().Delete(request.Id);
			return new HttpResult(request, HttpStatusCode.OK);
		}
	}
}
