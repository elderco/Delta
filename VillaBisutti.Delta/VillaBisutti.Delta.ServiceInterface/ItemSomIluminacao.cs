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
	public class ItemSomIluminacao : Service
	{
		public model.ItemSomIluminacaoSelecionado Get(svc.SomIluminacao.Get request)
		{
			return new data.SomIluminacao().GetElement(request.Id);
		}
		public List<model.ItemSomIluminacaoSelecionado> Get(svc.SomIluminacao.GetAll request)
		{
			return new data.SomIluminacao().GetCollection(0);
		}
		public HttpResult Post(svc.SomIluminacao.New request)
		{
			new data.SomIluminacao().Insert(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Put(svc.SomIluminacao.Update request)
		{
			new data.SomIluminacao().Update(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Delete(svc.Bebida.Delete request)
		{
			new data.SomIluminacao().Delete(request.Id);
			return new HttpResult(request, HttpStatusCode.OK);
		}
	}
}
