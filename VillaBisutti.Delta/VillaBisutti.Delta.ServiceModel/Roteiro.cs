using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.Roteiro
{
	[Route("/roteiros/{Id}", "GET")]
	public class Get : IReturn<model.Roteiro>
	{
		public int Id { get; set; }
	}
	[Route("/roteiros", "GET")]
	public class GetAll : IReturn<List<model.Roteiro>> { }
	[Route("/roteiros", "POST")]
	public class New
	{
		public model.Roteiro entity { get; set; }
	}
	[Route("/roteiros", "PUT")]
	public class Update
	{
		public model.Roteiro entity { get; set; }
	}
	[Route("/roteiros/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
