using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.ItemGastronomia
{
	[Route("/itemgastronomias/{Id}", "GET")]
	public class Get : IReturn<model.ItemGastronomia>
	{
		public int Id { get; set; }
	}
	[Route("/itemgastronomias", "GET")]
	public class GetAll : IReturn<List<model.ItemGastronomia>> { }
	[Route("/itemgastronomias", "POST")]
	public class New
	{
		public model.ItemGastronomia entity { get; set; }
	}
	[Route("/itemgastronomias", "PUT")]
	public class Update
	{
		public model.ItemGastronomia entity { get; set; }
	}
	[Route("/itemgastronomias/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
