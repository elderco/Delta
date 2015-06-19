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
	public class Roteiro : Service
	{
		public model.Roteiro Get(svc.Roteiro.Get request)
		{
			return new data.Roteiro().GetElement(request.Id);
		}
		public List<model.Roteiro> Get(svc.Roteiro.GetAll request)
		{
			return new data.Roteiro().GetCollection(0);
		}
		public HttpResult Post(svc.Roteiro.New request)
		{
			new data.Roteiro().Insert(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Put(svc.Roteiro.Update request)
		{
			new data.Roteiro().Update(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Delete(svc.Roteiro.Delete request)
		{
			new data.Roteiro().Delete(request.Id);
			return new HttpResult(request, HttpStatusCode.OK);
		}
	}
}
