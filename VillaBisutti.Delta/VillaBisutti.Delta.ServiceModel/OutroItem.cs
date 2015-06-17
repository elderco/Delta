using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.OutroItem
{
	[Route("/outrositens/{Id}", "GET")]
	public class Get : IReturn<model.OutroItem>
	{
		public int Id { get; set; }
	}
	[Route("/outrositens", "GET")]
	public class GetAll : IReturn<List<model.OutroItem>> { }
	[Route("/outrositens", "POST")]
	public class New
	{
		public model.OutroItem entity { get; set; }
	}
	[Route("/outrositens", "PUT")]
	public class Update
	{
		public model.OutroItem entity { get; set; }
	}
	[Route("/outrositens/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
