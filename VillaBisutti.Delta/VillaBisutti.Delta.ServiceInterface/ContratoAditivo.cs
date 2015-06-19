﻿using ServiceStack.ServiceInterface;
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
	public class ContratoAditivo : Service
	{
		public model.ContratoAditivo Get(svc.ContratoAditivo.Get request)
		{
			return new data.ContratoAditivo().GetElement(request.Id);
		}
		public List<model.ContratoAditivo> Get(svc.ContratoAditivo.GetAll request)
		{
			return new data.ContratoAditivo().GetCollection(0);
		}
		public HttpResult Post(svc.ContratoAditivo.New request)
		{
			new data.ContratoAditivo().Insert(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Put(svc.ContratoAditivo.Update request)
		{
			new data.ContratoAditivo().Update(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Delete(svc.ContratoAditivo.Delete request)
		{
			new data.ItemBebidaSelecionado().Delete(request.Id);
			return new HttpResult(request, HttpStatusCode.OK);
		}
	}
}
