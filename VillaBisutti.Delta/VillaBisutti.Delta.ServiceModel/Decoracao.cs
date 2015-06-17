using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.Decoracao
{
	[Route("/decoracoes/{Id}", "GET")]
	public class Get : IReturn<model.Decoracao>
	{
		public int Id { get; set; }
	}
	[Route("/decoracoes", "GET")]
	public class GetAll : IReturn<List<model.Decoracao>> { }
	[Route("/decoracoes", "POST")]
	public class New
	{
		public model.Decoracao entity { get; set; }
	}
	[Route("/decoracoes", "PUT")]
	public class Update
	{
		public model.Decoracao entity { get; set; }
	}
	[Route("/decoracoes/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
