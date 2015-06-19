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
	public class CronogramaCerimonialPadrao : Service
	{
		public model.CronogramaCerimonialPadrao Get(svc.CronogramaCerimonialPadrao.Get request)
		{
			return new data.CronogramaCerimonialPadrao().GetElement(request.Id);
		}
		public List<model.CronogramaCerimonialPadrao> Get(svc.CronogramaCerimonialPadrao.GetAll request)
		{
			return new data.CronogramaCerimonialPadrao().GetCollection(0);
		}
		public HttpResult Post(svc.CronogramaCerimonialPadrao.New request)
		{
			new data.CronogramaCerimonialPadrao().Insert(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Put(svc.CronogramaCerimonialPadrao.Update request)
		{
			new data.CronogramaCerimonialPadrao().Update(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Delete(svc.CronogramaCerimonialPadrao.Delete request)
		{
			new data.ItemBebidaSelecionado().Delete(request.Id);
			return new HttpResult(request, HttpStatusCode.OK);
		}
	}
}
