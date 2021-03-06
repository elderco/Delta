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
	public class ItemMontagem : Service
	{
		public model.ItemMontagem Get(svc.ItemMontagem.Get request)
		{
			return new data.ItemMontagem().GetElement(request.Id);
		}
		public List<model.ItemMontagem> Get(svc.ItemMontagem.GetAll request)
		{
			return new data.ItemMontagem().GetCollection(0);
		}
		public HttpResult Post(svc.ItemMontagem.New request)
		{
			new data.ItemMontagem().Insert(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Put(svc.ItemMontagem.Update request)
		{
			new data.ItemMontagem().Update(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Delete(svc.ItemMontagem.Delete request)
		{
			new data.ItemMontagem().Delete(request.Id);
			return new HttpResult(request, HttpStatusCode.OK);
		}
	}
}