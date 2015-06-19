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
	public class TipoItemGastronomia : Service
	{
		public model.TipoItemGastronomia Get(svc.TipoItemGastronomia.Get request)
		{
			return new data.TipoItemGastronomia().GetElement(request.Id);
		}
		public List<model.TipoItemGastronomia> Get(svc.TipoItemGastronomia.GetAll request)
		{
			return new data.TipoItemGastronomia().GetCollection(0);
		}
		public HttpResult Post(svc.TipoItemGastronomia.New request)
		{
			new data.TipoItemGastronomia().Insert(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Put(svc.TipoItemGastronomia.Update request)
		{
			new data.TipoItemGastronomia().Update(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Delete(svc.TipoItemGastronomia.Delete request)
		{
			new data.TipoItemGastronomia().Delete(request.Id);
			return new HttpResult(request, HttpStatusCode.OK);
		}
	}
}
