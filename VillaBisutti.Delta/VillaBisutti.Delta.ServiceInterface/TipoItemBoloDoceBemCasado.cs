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
	public class TipoItemBoloDoceBemCasado : Service
	{
		public model.TipoItemBoloDoceBemCasado Get(svc.TipoItemBoloDoceBemCasado.Get request)
		{
			return new data.TipoItemBoloDoceBemCasado().GetElement(request.Id);
		}
		public List<model.TipoItemBoloDoceBemCasado> Get(svc.TipoItemBoloDoceBemCasado.GetAll request)
		{
			return new data.TipoItemBoloDoceBemCasado().GetCollection(0);
		}
		public HttpResult Post(svc.TipoItemBoloDoceBemCasado.New request)
		{
			new data.TipoItemBoloDoceBemCasado().Insert(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Put(svc.TipoItemBoloDoceBemCasado.Update request)
		{
			new data.TipoItemBoloDoceBemCasado().Update(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Delete(svc.TipoItemBoloDoceBemCasado.Delete request)
		{
			new data.TipoItemBoloDoceBemCasado().Delete(request.Id);
			return new HttpResult(request, HttpStatusCode.OK);
		}
	}
}
