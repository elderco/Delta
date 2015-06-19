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
	public class Montagem : Service
	{
		public model.ItemMontagemSelecionado Get(svc.Montagem.Get request)
		{
			return new data.Montagem().GetElement(request.Id);
		}
		public List<model.ItemMontagemSelecionado> Get(svc.Montagem.GetAll request)
		{
			return new data.Montagem().GetCollection(0);
		}
		public HttpResult Post(svc.Montagem.New request)
		{
			new data.Montagem().Insert(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Put(svc.Montagem.Update request)
		{
			new data.Montagem().Update(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Delete(svc.Montagem.Delete request)
		{
			new data.Montagem().Delete(request.Id);
			return new HttpResult(request, HttpStatusCode.OK);
		}
	}
}
