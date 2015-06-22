using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.Area
{
	[Route("/area/{Id}", "GET")]
	public class Get : IReturn<model.Area>
	{
		public int Id { get; set; }
	}
	[Route("/area", "GET")]
	public class GetAll : IReturn<List<model.Area>>	{ 	}
	[Route("/area", "POST")]
	public class New
	{
		public model.Area entity { get; set; }
	}
	[Route("/area", "PUT")]
	public class Update
	{
		public model.Area entity { get; set; }
	}
	[Route("/area/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
