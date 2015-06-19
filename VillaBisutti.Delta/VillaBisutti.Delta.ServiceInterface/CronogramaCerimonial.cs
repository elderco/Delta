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
	public class CronogramaCerimonial : Service
	{
		public model.CronogramaCerimonial Get(svc.CronogramaCerimonial.Get request)
		{
			return new data.CronogramaCerimonial().GetElement(request.Id);
		}
		public List<model.CronogramaCerimonial> Get(svc.CronogramaCerimonial.GetAll request)
		{
			return new data.CronogramaCerimonial().GetCollection(0);
		}
		public HttpResult Post(svc.CronogramaCerimonial.New request)
		{
			new data.CronogramaCerimonial().Insert(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Put(svc.CronogramaCerimonial.Update request)
		{
			new data.CronogramaCerimonial().Update(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Delete(svc.CronogramaCerimonial.Delete request)
		{
			new data.CronogramaCerimonial().Delete(request.Id);
			return new HttpResult(request, HttpStatusCode.OK);
		}
	}
}
