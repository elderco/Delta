using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace VillaBisutti.Delta.WebApp.Core
{
	public static class ServicesFacade
	{
		private static string ApiURL
		{
			get
			{
				return ConfigurationManager.AppSettings["ApiURL"].ToString();
			}
		}
		public static string EventoRoute
		{
			get
			{
				return ApiURL + "/evento";
			}
		}
	}
}