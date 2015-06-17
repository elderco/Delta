using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.Montagem
{
	[Route("/montagens/{Id}", "GET")]
	public class Get : IReturn<model.Montagem>
	{
		public int Id { get; set; }
	}
	[Route("/montagens", "GET")]
	public class GetAll : IReturn<List<model.Montagem>> { }
	[Route("/montagens", "POST")]
	public class New
	{
		public model.Montagem entity { get; set; }
	}
	[Route("/montagens", "PUT")]
	public class Update
	{
		public model.Montagem entity { get; set; }
	}
	[Route("/montagens/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
