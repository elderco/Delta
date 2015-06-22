using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.Roteiro
{
	[Route("/roteiro/{Id}", "GET")]
	public class Get : IReturn<model.Roteiro>
	{
		public int Id { get; set; }
	}
	[Route("/roteiro", "GET")]
	public class GetAll : IReturn<List<model.Roteiro>> { }
	[Route("/roteiro", "POST")]
	public class New
	{
		public model.Roteiro entity { get; set; }
	}
	[Route("/roteiro", "PUT")]
	public class Update
	{
		public model.Roteiro entity { get; set; }
	}
	[Route("/roteiro/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
