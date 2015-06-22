using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.ItemGastronomia
{
	[Route("/item-gastronomia/{Id}", "GET")]
	public class Get : IReturn<model.ItemGastronomia>
	{
		public int Id { get; set; }
	}
	[Route("/item-gastronomia", "GET")]
	public class GetAll : IReturn<List<model.ItemGastronomia>> { }
	[Route("/item-gastronomia", "POST")]
	public class New
	{
		public model.ItemGastronomia entity { get; set; }
	}
	[Route("/item-gastronomia", "PUT")]
	public class Update
	{
		public model.ItemGastronomia entity { get; set; }
	}
	[Route("/item-gastronomia/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
