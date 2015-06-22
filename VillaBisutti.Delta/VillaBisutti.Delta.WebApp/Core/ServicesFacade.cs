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
		//private static HttpClient _client;
		//private static HttpClient Client
		//{
		//	get
		//	{
		//		if (_client == null)
		//		{
		//			_client = new HttpClient();
		//			_client.BaseAddress = new Uri(ApiURL);
		//			_client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		//		}
		//		return _client;
		//	}
		//}
		//public List<Delta.Core.Model.TipoItemDecoracao> TiposDecoracao()
		//{
		//	HttpResponseMessage response = Client.GetAsync("/tipo-item-bebida");
			
		//	return "";
		//}
	}
}