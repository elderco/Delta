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
	public class BoloDoceBemCasado : Service
	{
		public model.ItemBoloDoceBemCasadoSelecionado Get(svc.BoloDoceBemCasado.Get request)
		{
			return new data.BoloDoceBemCasado().GetElement(request.Id);
		}
		public List<model.ItemBoloDoceBemCasadoSelecionado> Get(svc.BoloDoceBemCasado.GetAll request)
		{
			return new data.BoloDoceBemCasado().GetCollection(0);
		}
		public HttpResult Post(svc.BoloDoceBemCasado.New request)
		{
			new data.BoloDoceBemCasado().Insert(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Put(svc.BoloDoceBemCasado.Update request)
		{
			new data.BoloDoceBemCasado().Update(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Delete(svc.BoloDoceBemCasado.Delete request)
		{
			new data.BoloDoceBemCasado().Delete(request.Id);
			return new HttpResult(request, HttpStatusCode.OK);
		}
	}
}
