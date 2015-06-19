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
	public class FotoVideo : Service
	{
		public model.ItemFotoVideoSelecionado Get(svc.FotoVideo.Get request)
		{
			return new data.FotoVideo().GetElement(request.Id);
		}
		public List<model.ItemFotoVideoSelecionado> Get(svc.FotoVideo.GetAll request)
		{
			return new data.FotoVideo().GetCollection(0);
		}
		public HttpResult Post(svc.FotoVideo.New request)
		{
			new data.FotoVideo().Insert(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Put(svc.FotoVideo.Update request)
		{
			new data.FotoVideo().Update(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Delete(svc.FotoVideo.Delete request)
		{
			new data.FotoVideo().Delete(request.Id);
			return new HttpResult(request, HttpStatusCode.OK);
		}
	}
}
