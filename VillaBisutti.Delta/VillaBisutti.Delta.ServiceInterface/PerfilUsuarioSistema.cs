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
	public class PerfilUsuarioSistema : Service
	{
		public model.PerfilUsuarioSistema Get(svc.PerfilUsuarioSistema.Get request)
		{
			return new data.PerfilUsuarioSistema().GetElement(request.Id);
		}
		public List<model.PerfilUsuarioSistema> Get(svc.PerfilUsuarioSistema.GetAll request)
		{
			return new data.PerfilUsuarioSistema().GetCollection(0);
		}
		public HttpResult Post(svc.PerfilUsuarioSistema.New request)
		{
			new data.PerfilUsuarioSistema().Insert(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Put(svc.PerfilUsuarioSistema.Update request)
		{
			new data.PerfilUsuarioSistema().Update(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Delete(svc.PerfilUsuarioSistema.Delete request)
		{
			new data.PerfilUsuarioSistema().Delete(request.Id);
			return new HttpResult(request, HttpStatusCode.OK);
		}
	}
}
